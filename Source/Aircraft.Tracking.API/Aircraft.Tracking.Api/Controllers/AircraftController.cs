using System;
using Microsoft.AspNetCore.Mvc;
using Rusada.Core.Data;
using Aircraft.Tracking.Core.Poco;
using Aircraft.Tracking.Core.Services;
using Aircraft.Tracking.Api.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rusada.Core.Data.EF;

namespace Aircraft.Tracking.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AircraftController : Controller
    {
        private readonly IAircraftInformationService service;
        private readonly IAircraftTrackerResponse response;

        private readonly IAircraftService aircraftService;


        public AircraftController(IAircraftTrackerResponse response, IAircraftService aircraftService)
        {
            this.response = response;
            this.aircraftService = aircraftService;
        }

        [HttpGet]
        [Route("GetAll")]
        public AircraftTrackerResponse GetAll([FromQuery] ActiveStatusEnum activeStatusEnum)
        {

            var aircraftInformation = aircraftService.GetAll(activeStatusEnum);
            return this.response.GenerateResponseMessage("", "", " ", "", aircraftInformation);
        }


        [HttpPost]
        [Route("Insert")]
        public AircraftTrackerResponse Insert([FromBody] AircraftInformation aircraftInformation)
        {
            if (!ModelState.IsValid)
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Validations Failed");
            }
            aircraftInformation.IsActive = true;
            aircraftInformation.CreatedDate = DateTime.Now;
            aircraftInformation.ModifiedDate = null;
            aircraftInformation = aircraftService.Insert(aircraftInformation);

            if (aircraftInformation.Id > 0)
            {
                return this.response.GenerateResponseMessage("Success", "", "", "", "Created Successfully!");
            }
            else
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Error Occured");
            }

        }


        [HttpPost]
        [Route("Update")]
        public AircraftTrackerResponse Update([FromBody] AircraftInformation aircraftInformation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.response.GenerateResponseMessage("Error", "", "", "", "Validations Failed");
                }

                aircraftInformation.IsActive = true;
                aircraftInformation.ModifiedDate = DateTime.Now;

                aircraftInformation = aircraftService.Update(aircraftInformation);

                return this.response.GenerateResponseMessage("Success", "", "", "", "Updated Successfully!");
            }
            catch
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Error Occured");
            }
        }


        [HttpPost]
        [Route("Delete/{id:int}")]
        public AircraftTrackerResponse Delete([FromRoute] int Id)
        {
            try
            {
                var aircraftInformation = service.Get(Id);
                if (aircraftInformation == null)
                {
                    return this.response.GenerateResponseMessage("Error", "", "", "", "Record Not Found");
                }
                aircraftInformation.IsActive = false;
                aircraftInformation.ModifiedDate = DateTime.Now;

                aircraftInformation = aircraftService.Update(aircraftInformation);

                return this.response.GenerateResponseMessage("Success", "", "", "", "Deleted Successfully!");
            }
            catch
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Error Occured");
            }
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AircraftTrackerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AircraftTrackerResponse))]
        public IActionResult GetById([FromRoute] int id)
        {
            var aircraftInformation = aircraftService.Get(id);
            if (aircraftInformation != null)
            {
                return Ok(this.response.GenerateResponseMessage("Success", "", "", "", aircraftInformation));
            }
            else
            {
                return BadRequest(this.response.GenerateResponseMessage("Error", "", "", "", aircraftInformation));
            }
        }

        [HttpGet]
        [Route("GetByIdAsync/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AircraftTrackerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AircraftTrackerResponse))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var aircraftInformation = await aircraftService.GetAsync(id);
            if (aircraftInformation != null)
            {
                return Ok(this.response.GenerateResponseMessage("Success", "", "", "", aircraftInformation));
            }
            else
            {
                return BadRequest(this.response.GenerateResponseMessage("Error", "", "", "", aircraftInformation));
            }
        }

    }
}
