namespace vega.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.Extensions.Logging;

    using Vega.Helpers;
    using Vega.Model.View;
    using Vega.Services;

    [Route("api/vehicles")]    
    public class VehiclesController : Controller
    {
        private const string VehicleCreationUri = "GetVehicleById";

        private readonly IVegaRepository repository;
        private readonly ILogger<VehiclesController> logger;

        public VehiclesController(IVegaRepository repository, ILogger<VehiclesController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        // API: /api/vehicles/ POST
        [HttpPost]
        [ProducesResponseType(typeof(Vehicle), 201)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 406)]
        [ProducesResponseType(typeof(ModelStateDictionary), 422)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult CreateVehicle([FromBody] Vega.Model.Create.Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            if (!this.repository.ModelExists(vehicle.ModelId))
            {
                this.ModelState.AddModelError(nameof(Vega.Model.Create.Vehicle),
                    $"{vehicle.ModelId} is an unknown Model.");
            }


            foreach (var feature in vehicle.Features)
            {
                if (!this.repository.FeatureValidForModel(vehicle.ModelId, feature.Id))
                {
                    this.ModelState.AddModelError(nameof(Vega.Model.Create.Vehicle),
                        $"Feature {feature.Id} is not a valid feature for Model {vehicle.ModelId}.");
                }
            }

            if (!this.ModelState.IsValid)
            {
                // return 422
                return new UnprocessableEntityObjectResult(this.ModelState);
            }

            var vehicleToReturn = this.repository.CreateVehicle(vehicle);

            if (vehicleToReturn == null)
            {
                return this.BadRequest();
            }

            if (!this.repository.Save())
            {
                throw new Exception($"Creating vehicle with name {vehicleToReturn.Name} failed on save.");
            }

            return this.CreatedAtRoute(VehicleCreationUri,
                new { id = vehicleToReturn.Id },
                vehicleToReturn);
        }

        // API: /api/vehicles/ GET
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Vehicle>), 200)]
        public IActionResult GetVehicles()
        {
            return this.Ok(this.repository.GetVehicles());
        }

        // API: /api/vehicles/{id} GET
        [HttpGet("{id}", Name = VehicleCreationUri)]
        [ProducesResponseType(typeof(Vehicle), 200)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = this.repository.GetVehicleById(id);

            return vehicle == null
                       ? (IActionResult)this.NotFound()
                       : this.Ok(vehicle);
        }

        // API: /api/vehicles/ PUT
        [HttpPut]
        [ProducesResponseType(typeof(Vehicle), 201)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 406)]
        [ProducesResponseType(typeof(ModelStateDictionary), 422)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult UpdateVehicle([FromBody] Vega.Model.Update.Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            if (!this.repository.ModelExists(vehicle.ModelId))
            {
                this.ModelState.AddModelError(nameof(Vega.Model.Create.Vehicle),
                    $"{vehicle.ModelId} is an unknown Model.");
            }


            foreach (var feature in vehicle.Features)
            {
                if (!this.repository.FeatureValidForModel(vehicle.ModelId, feature.Id))
                {
                    this.ModelState.AddModelError(nameof(Vega.Model.Create.Vehicle),
                        $"Feature {feature.Id} is not a valid feature for Model {vehicle.ModelId}.");
                }
            }

            if (!this.ModelState.IsValid)
            {
                // return 422
                return new UnprocessableEntityObjectResult(this.ModelState);
            }

            var vehicleToReturn = this.repository.UpdateVehicle(vehicle);

            if (vehicleToReturn == null)
            {
                return this.BadRequest();
            }

            if (!this.repository.Save())
            {
                throw new Exception($"Updating vehicle {vehicleToReturn.Id} failed on save.");
            }

            return this.CreatedAtRoute(VehicleCreationUri,
                new { id = vehicleToReturn.Id },
                vehicleToReturn);
        }

        // API: /api/vehicles/{id} DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult DeleteVehicleById(int id)
        {
            if (!this.repository.DeleteVehicleById(id))
            {
                return this.NotFound();
            }

            if (!this.repository.Save())
            {
                throw new Exception($"Deleting vehicle {id} failed on save.");
            }

            this.logger.LogInformation(100, $"Vehicle {id} was deleted.");

            return this.NoContent();
        }
    }
}