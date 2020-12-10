namespace DogHub.Web.Areas.Administration.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Messaging;
    using DogHub.Web.ViewModels.Administration.Dashboard;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardService : IDashboardService
    {
        private readonly string[] AllowedExtensions = new[] { "png", "jpg", "jpeg" };

        private readonly IDeletableEntityRepository<Organiser> organisersRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<Breed> breedsRepository;
        private readonly IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IEmailSender emailSender;

        public DashboardService(
            IDeletableEntityRepository<Organiser> organisersRepository,
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<Breed> breedsRepository,
            IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Dog> dogsRepository,
            IEmailSender emailSender)
        {
            this.organisersRepository = organisersRepository;
            this.competitionsRepository = competitionsRepository;
            this.breedsRepository = breedsRepository;
            this.judgeFormsRepository = judgeFormsRepository;
            this.usersRepository = usersRepository;
            this.dogsRepository = dogsRepository;
            this.emailSender = emailSender;
        }

        public async Task<string> CreateCompetition(CreateCompetitionInputModel input, string imagePath)
        {
            var competition = new Competition
            {
                BreedId = input.BreedId,
                CompetitionEnd = input.CompetitionEnd,
                CompetitionStart = input.CompetitionStart,
                Name = input.Name,
            };

            var organiser = this.organisersRepository.All()
                .FirstOrDefault(x => x.Name == input.OrganisedBy);
            if (organiser == null)
            {
                organiser = new Organiser
                {
                    Name = input.OrganisedBy,
                };
            }

            competition.Organiser = organiser;

            Directory.CreateDirectory($"{imagePath}/competitions/");
            var image = input.CompetitionImage;
            var extension = Path.GetExtension(image.FileName).TrimStart('.');
            if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extenstion {extension}");
            }

            var newImage = new CompetitionImage
            {
                Extension = extension,
            };
            competition.CompetitionImage = newImage;

            var filePath = $"{imagePath}/competitions/{newImage.Id}.{extension}";
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(fileStream);

            await this.competitionsRepository.AddAsync(competition);
            await this.competitionsRepository.SaveChangesAsync();

            return competition.Name;
        }

        public BreedsListViewModel BreedsListData()
        {
            var breedsPage = new BreedsListViewModel();
            breedsPage.AllBreeds = this.GelAllBreeds();
            return breedsPage;
        }

        public async Task<string> ApproveNewBreed(int breedId)
        {
            var breed = this.breedsRepository.All()
                .Where(x => x.Id == breedId).FirstOrDefault();
            breed.IsApproved = true;
            breed.IsUnderReview = false;

            await this.breedsRepository.SaveChangesAsync();

            return breed.Name;
        }

        public async Task<string> RejectBreed(int breedId)
        {
            var breed = this.breedsRepository.All()
                .Where(x => x.Id == breedId).FirstOrDefault();
            breed.IsRejected = true;
            breed.IsUnderReview = false;

            await this.breedsRepository.SaveChangesAsync();

            return breed.Name;
        }

        public JudgeAppFormsViewModel JudgeAppForms()
        {
            var appsPage = new JudgeAppFormsViewModel();
            appsPage.FormsList = this.GetAllForms();

            return appsPage;
        }

        public async Task<string> ApproveApplication(string userId)
        {
            var application = this.judgeFormsRepository.All()
                .Where(x => x.UserId == userId).FirstOrDefault();
            application.IsApproved = true;
            application.IsUnderReview = false;
            application.ApprovalDate = DateTime.Now;

            await this.judgeFormsRepository.SaveChangesAsync();

            return application.FirstName + " " + application.LastName;
        }

        public async Task<IActionResult> SendEmailApproval(string userId)
        {
            var html = new StringBuilder();
            var userData = this.judgeFormsRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            html.AppendLine($"<p>Dear Mr/Mrs {userData.FirstName} {userData.LastName},</p>");
            html.AppendLine("<p>Congratulations on your judge application form approval!</p>");
            html.AppendLine("<p>We would like to welcome you in the DogHub judges team.</p>");
            html.AppendLine("<p>Best Regards,</p>");
            html.AppendLine("<p>DogHub team</p>");

            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            await this.emailSender.SendEmailAsync("elitza_85@yahoo.co.uk", "DogHub", "digifel247@menece.com", "Judge Application Form Approval", html.ToString());
            await this.emailSender.SendEmailAsync("elitza_85@yahoo.co.uk", "DogHub", user.Email, "Judge Application Form Approval", html.ToString());

            return null;
        }

        public async Task<string> RejectApplication(string userId, string notes)
        {
            var application = this.judgeFormsRepository.All()
                .Where(x => x.UserId == userId).FirstOrDefault();
            application.IsRejected = true;
            application.IsUnderReview = false;
            application.EvaluatorNotes = notes;

            await this.judgeFormsRepository.SaveChangesAsync();

            return application.FirstName + " " + application.LastName;
        }

        public async Task<IActionResult> SendEmailRejection(string userId)
        {
            var html = new StringBuilder();
            var userData = this.judgeFormsRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            html.AppendLine($"<p>Dear Mr/Mrs {userData.FirstName} {userData.LastName},</p>");
            html.AppendLine("<p>We are sorry to inform you that your judge application form was rejected.</p>");
            html.AppendLine($"<p>The reason for that is: {userData.EvaluatorNotes}</p>");
            html.AppendLine("<p>When you accomplish all the requirements, you can apply again.</p>");
            html.AppendLine("<p>Best Regards,</p>");
            html.AppendLine("<p>DogHub team</p>");

            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            await this.emailSender.SendEmailAsync("elitza_85@yahoo.co.uk", "DogHub", "digifel247@menece.com", "Judge Application Form Rejection", html.ToString());
            await this.emailSender.SendEmailAsync("elitza_85@yahoo.co.uk", "DogHub", user.Email, "Judge Application Form Rejection", html.ToString());

            return null;
        }

        public IEnumerable<BreedsData> AllBreedsForReport()
        {
            var breeds = this.breedsRepository.All()
                .Where(x => x.IsApproved)
               .Select(x => new BreedsData
               {
                   BreedId = x.Id,
                   BreedName = x.Name,
                   TotalDogsOfBreed = x.BreedDogs.Count(),
               })
               .OrderByDescending(x => x.TotalDogsOfBreed)
               .ToList();

            var dogs = this.dogsRepository.All().ToList();
            foreach (var breedData in breeds)
            {
                int countMales = 0;
                int countFemales = 0;
                var breedId = breedData.BreedId;
                foreach (var dog in dogs)
                {
                    if (dog.BreedId == breedId && dog.Gender.ToString() == "Female")
                    {
                        countFemales++;
                    }
                    else if (dog.BreedId == breedId && dog.Gender.ToString() == "Male")
                    {
                        countMales++;
                    }
                }

                breeds.Where(b => b.BreedId == breedId).First().FemaleDogsOfBreed = countFemales;
                breeds.Where(b => b.BreedId == breedId).First().MaleDogsOfBreed = countMales;
            }

            return breeds;
        }

        public ReportViewModel GetReportData()
        {
            var viewModel = new ReportViewModel();
            viewModel.GetBreedsData = this.AllBreedsForReport();

            return viewModel;
        }

        private IEnumerable<BreedNames> GelAllBreeds()
        {
            return this.breedsRepository.All()
                .Where(x => x.IsUnderReview == true)
                .Select(x => new BreedNames
                {
                    BreedId = x.Id,
                    BreedName = x.Name,
                })
                .OrderBy(x => x.BreedName)
                .ToList();
        }

        private IEnumerable<SingleJudgeAppFormViewModel> GetAllForms()
        {
            return this.judgeFormsRepository.All()
                .Where(x => x.IsUnderReview == true)
                .Select(f => new SingleJudgeAppFormViewModel
                {
                    UserId = f.UserId,
                    FirstName = f.FirstName,
                    LastName = f.LastName,
                    YearsOfExperience = f.YearsOfExperience,
                    HasBeenJudgeAssistant = f.HasBeenJudgeAssistant,
                    NumberOfChampionsOwned = f.NumberOfChampionsOwned,
                    RaisedLitters = f.RaisedLitters,
                    JudgeInstituteCertificateUrl = f.JudgeInstituteCertificateUrl,
                }).ToList();
        }
    }
}
