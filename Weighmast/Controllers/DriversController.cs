using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Weighmast.Data;
using Weighmast.Models;


namespace Weighmast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : Controller
    {
        
        public DriversController(DriversAPIDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DriversAPIDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            return Ok(await DbContext.Drivers.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddDriver(AddDriverRequest addDriverRequest)
        {
            var driver = new Driver()
            {
                DriverID = addDriverRequest.DriverID,
                FirstName = addDriverRequest.FirstName,
                LastName = addDriverRequest.LastName,
                Photo = addDriverRequest.Photo,
                Notes = addDriverRequest.Notes,
                AccountID = addDriverRequest.AccountID,
                IDProofScan = addDriverRequest.IDProofScan,
                IDProofType = addDriverRequest.IDProofType,
                IDProofNo = addDriverRequest.IDProofNo,
                Active = addDriverRequest.Active,
            };
            await DbContext.Drivers.AddAsync(driver);
            await DbContext.SaveChangesAsync();

            return Ok(driver);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDrivers([FromRoute] int id)
        {
            var driver = await DbContext.Drivers.FindAsync(id);
            if(driver == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(driver);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] int id,  UpdateDriverRequest updateDriverRequest)
        {
            var driver = await DbContext.Drivers.FindAsync(id);

            if (driver != null)
            {
                driver.FirstName = updateDriverRequest.FirstName;
                driver.LastName = updateDriverRequest.LastName;
                driver.Photo=updateDriverRequest.Photo;
                driver.Notes = updateDriverRequest.Notes;
                driver.IDProofScan = updateDriverRequest.IDProofScan;
                driver.IDProofType = updateDriverRequest.IDProofType;
                driver.IDProofNo = updateDriverRequest.IDProofNo;


                await DbContext.SaveChangesAsync();

                return Ok(driver);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] int id)
        {
            var driver = await DbContext.Drivers.FindAsync(id);

            if(driver != null)
            {
                DbContext.Remove(driver);
                await DbContext.SaveChangesAsync();
                return Ok(driver);
            }
            return NotFound();
        }
    }
}
