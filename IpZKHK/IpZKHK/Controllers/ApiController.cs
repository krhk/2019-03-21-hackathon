using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IpZKHK.Models;
using KHK_OpenData.Lib.Entities;
using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Misto = IpZKHK.Models.Misto;

namespace IpZKHK.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET api/values
        private readonly DataContext dataContext;

        private double range = 5000;
        public ApiController([FromServices]DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpPost]
        public async Task<JsonResult> GetMisto(Souradnice souradnice)
        {
            Misto mesto = new Misto(souradnice, dataContext.PocetObyvatelEntitySet, dataContext.VekoveSlozeniEntitySet);
            return new JsonResult(mesto);
        }
        [HttpPost]
        public async Task<JsonResult> GetKino(Souradnice souradnice)
        {
            List<object> result = new List<object>();
            foreach(IEntity entity in dataContext.KinoEntitySet.GetList())
            {
                if ((entity).GetSouradnice()?.VzdalenostDo(souradnice) < range)
                {
                    result.Add(entity);
                }
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> GetKlub(Souradnice souradnice)
        {
            List<object> result = new List<object>();
            foreach (IEntity entity in dataContext.KlubEntitySet.GetList())
            {
                if ((entity).GetSouradnice()?.VzdalenostDo(souradnice) < range)
                {
                    result.Add(entity);
                }
            }
            return new JsonResult(result);
        }
    }
}
