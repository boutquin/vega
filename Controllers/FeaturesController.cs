namespace Vega.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using Vega.Model.View;
    using Vega.Services;

    [Route("api/features")]
    public class FeaturesController : Controller
    {
        private readonly IVegaRepository repository;

        public FeaturesController(IVegaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Feature>), 200)]
        public IActionResult GetFeatures()
        {
            return this.Ok(this.repository.GetFeatures());
        }
    }
}