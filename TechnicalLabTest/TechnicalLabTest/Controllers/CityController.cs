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
    public class CityController : ControllerBase
    {
        private TechnicalLabTestDb db;
        public CityController()
        {
            db = new TechnicalLabTestDb();
        }
        [HttpGet]
        public IActionResult Get()
        {


            var dataList = db.Cities.ToList();

            if (dataList?.Count == 0)
            {
                return BadRequest(new { error = "Empty Data List!" });
            }
            return Ok(dataList);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var data = db.Cities.FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest(new { error = "Can not Get Data!" });
            }

            return Ok(data);
        }
        [HttpGet("GetByCountryId/{countryId:int}")]
        public IActionResult GetByCountryId(int countryId)
        {

            var dataList = db.Cities.Where(c => c.CountryId == countryId).ToList();
            if (dataList?.Count == 0)
            {
                return BadRequest(new { error = "Can not Get Data!" });
            }

            return Ok(dataList);
        }

    }
}
