using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalLabTest.DatabaseSet;

namespace TechnicalLabTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private TechnicalLabTestDb db;
        public LanguageController()
        {
            db = new TechnicalLabTestDb();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var dataList = db.Languages.ToList();

            if (dataList?.Count == 0)
            {
                return BadRequest(new { error = "Empty Data List!" });
            }
            return Ok(dataList);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var data = db.Languages.FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest(new { error = "Can not Get Data!" });
            }

            return Ok(data);
        }
    }
}
