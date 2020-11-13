using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public interface IDogsService
    {
        Task Register(RegisterDogInputModel input);

        DogProfileViewModel DogProfile(int id);
    }
}
