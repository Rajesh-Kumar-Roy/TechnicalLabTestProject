using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using TechnicalLabTest.DatabaseSet;
using TechnicalLabTest.Models;

namespace TechnicalLabTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {
        private TechnicalLabTestDb db;
        public PersonalInformationController()
        {
            db = new TechnicalLabTestDb();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var personalList = new List<PersonalInformation>();
          
            var dataList = db.PersonalInformations.Include(c=>c.PersonalInformationDetails).ThenInclude(d=>d.Language).Include(c=>c.City).Include(c=>c.Country).ToList();
            if (dataList?.Count == 0)
            {
                return BadRequest(new { error = "Empty Data List!" });
            }

            foreach (var data in dataList)
            {
                var obj = new PersonalInformation();
                obj.Id = data.Id;
                obj.Name = data.Name;
                obj.CityId = data.CityId;
                obj.CountryName = data.Country.Name;
                obj.CountryId = data.CountryId;
                obj.CityName = data.City.Name;
                obj.DateTime = data.DateTime.Date;
                obj.PersonalInformationDetails = GetDetails(data.PersonalInformationDetails);
                obj.File = data.File;
                personalList.Add(obj);
            }
            return Ok(personalList);
          
        }

        public List<PersonalInformationDetail> GetDetails(List<PersonalInformationDetail> dataDetails)
        {
            var objs = new List<PersonalInformationDetail>();
            foreach (var data in dataDetails)
            {
                var obj = new PersonalInformationDetail();
                obj.Id = data.Id;
                obj.PersonalInformationId = data.PersonalInformationId;
                obj.LanguageId = data.LanguageId;
                obj.LanguageName = data.Language?.Name;
                obj.IsChecked = true;
                objs.Add(obj);
            }

            return objs;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var data = db.PersonalInformations.Include(c => c.PersonalInformationDetails).ThenInclude(d => d.Language).Include(c => c.City).Include(c => c.Country).FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest(new { error = "Can not Get Data!" });
            }

            var obj = new PersonalInformation();
            obj.Id = data.Id;
            obj.Name = data.Name;
            obj.CityId = data.CityId;
            obj.CountryName = data.Country.Name;
            obj.CountryId = data.CountryId;
            obj.CityName = data.City.Name;
            obj.DateTime = data.DateTime.Date;
            obj.PersonalInformationDetails = data.PersonalInformationDetails;
            obj.File = data.File;
            return Ok(obj);
        }


        [HttpPost]
        public IActionResult Post([FromBody]PersonalInformation model)
        {
            if (ModelState.IsValid)
            {
                var detail = model.PersonalInformationDetails.Where(c => c.IsChecked).ToList();
                model.PersonalInformationDetails = new List<PersonalInformationDetail>();
                model.PersonalInformationDetails?.AddRange(detail);

                var result = db.PersonalInformations.Add(model);
                if (db.SaveChanges()> 0)
                {
                    return Ok(result.Entity);
                }

                return BadRequest(new { error = "Failed to Add!" });
            }

            return BadRequest(new { error = "Model Sate is Not Valid! " });
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonalInformation model)
        {
            if (ModelState.IsValid)
            {
                var modelDetail = model.PersonalInformationDetails;
                using (TransactionScope transactionScope = new TransactionScope())
                {

                    try

                    {
                       
                        db.Entry(modelDetail).State = EntityState.Modified;
                        db.Entry(model).State = EntityState.Modified;
                        var isUpdate = db.SaveChanges() > 0;
                        if (isUpdate)
                        {
                            return Ok(model);
                        }
                    }

                    catch (TransactionException ex)

                    {

                        transactionScope.Dispose();
                        return BadRequest(new { error = ex.Message });
                    }

                }
            }
            
            return BadRequest(new { error = "Failed!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.PersonalInformations.Include(c => c.PersonalInformationDetails)
                .FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest(new { error = "product not Found!" });
            }

            db.PersonalInformations.Remove(data);
            var isDelete = db.SaveChanges() > 0;

            if (!isDelete)
            {
                return BadRequest(new { error = "Failed To Delete!" }); 
            }

            return Ok(isDelete);
        }

    }
}
