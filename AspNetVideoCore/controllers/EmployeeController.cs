using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetVideoCore.controllers
{
    [Route("company/[controller]/[action]")]
    public class EmployeeController: Controller
    {

        public string Index()
        {
            return "Index Page";
        }

        public ContentResult Name()
        {
            return Content("Ranjan");
        }
    }
}
