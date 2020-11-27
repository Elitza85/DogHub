using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogHub.Web.Controllers
{
    public class JudgesController : Controller
    {
        public IActionResult JudgesList()
        {
            return this.View();
        }
    }
}
