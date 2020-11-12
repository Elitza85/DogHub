using DogHub.Web.ViewModels.Dog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public interface IDogService
    {
        Task Register(RegisterDogInputModel input); 
    }
}
