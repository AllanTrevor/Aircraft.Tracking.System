﻿using System;
using Microsoft.AspNetCore.Mvc;
using Rusada.Core.Data;
using Aircraft.Tracking.Core.Poco;
using Aircraft.Tracking.Core.Services;
using Aircraft.Tracking.Api.Common;
using AutoMapper;

namespace Aircraft.Tracking.Api.Controllers
{
    public class AircraftInformationController : Controller
    {
        private readonly IAircraftInformationService service;
        private readonly IAircraftTrackerResponse response;     
        //private readonly IMapper mapper;


        public AircraftInformationController(IAircraftInformationService service, IAircraftTrackerResponse response, IMapper mapper)
        {
            this.service = service;
            this.response = response;
            //this.mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public AircraftTrackerResponse GetAll([FromQuery]ActiveStatusEnum activeStatusEnum)
        {

            var aircraftInformation = service.GetAll(activeStatusEnum);
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
            aircraftInformation.IsActive= true;
            aircraftInformation.CreatedDate = DateTime.Now;
            aircraftInformation.ModifiedDate = null;
            long id = service.Insert(aircraftInformation);

            if (id > 0)
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
            if (!ModelState.IsValid)
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Validations Failed");
            }

            aircraftInformation.IsActive = true;
            aircraftInformation.ModifiedDate = DateTime.Now;

            bool id = service.Update(aircraftInformation);
            if (id == true)
            {
                return this.response.GenerateResponseMessage("Success", "", "", "", "Updated Successfully!");
            }
            else
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Error Occured");
            }
        }


        [HttpPost]
        [Route("Delete/{id:int}")]
        public AircraftTrackerResponse Delete([FromRoute] int Id)
        {
            var aircraftInformation = service.Get(Id);
            if(aircraftInformation == null)
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Record Not Found");
            }
            aircraftInformation.IsActive = false;
            aircraftInformation.ModifiedDate = DateTime.Now;

            bool id = service.Update(aircraftInformation);
            if (id == true)
            {
                return this.response.GenerateResponseMessage("Success", "", "", "", "Deleted Successfully!");
            }
            else
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", "Error Occured");
            }
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public AircraftTrackerResponse GetById([FromRoute]string id)
        {
            AircraftInformation aircraftInformation = service.Get(id);
            if (aircraftInformation != null)
            {
                return this.response.GenerateResponseMessage("Success", "", "", "", aircraftInformation);
            }
            else
            {
                return this.response.GenerateResponseMessage("Error", "", "", "", aircraftInformation);
            }
        }

    }
}
