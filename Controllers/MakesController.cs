namespace Vega.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using Vega.Model.View;
    using Vega.Services;

    [Route("api/makes")]

    public class MakesController : Controller
    {
        private readonly IVegaRepository repository;

        public MakesController(IVegaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Make>), 200)]
        public IActionResult GetMakes()
        {
            return this.Ok(this.repository.GetMakes());
        }
    }
}