using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scaffold_linha_de_comando_v5.Models;
using scaffold_linha_de_comando_v5.Services.Implementations;
using System.Collections.Generic;

namespace scaffold_linha_de_comando_v5.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly ILogger<PersonController> _logger;
		private IPersonServices _personServices;

		public PersonController(ILogger<PersonController> logger, IPersonServices personServices)
		{
			_logger = logger;
			_personServices = personServices;
		}

		[HttpGet]
		public IActionResult Get()
		{
			List<Person> persons = _personServices.FindAll();
			if (persons.Count == 0) return NotFound();
			return Ok(persons);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(long id)
		{
			Person person = _personServices.FindById(id);
			if (person == null) return NotFound();
			return Ok(person);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Person person)
		{
			if (person == null) return BadRequest();
			return Ok(_personServices.Create(person));
		}

		[HttpPut]
		public IActionResult Put([FromBody] Person person)
		{
			if (person == null) return BadRequest();
			return Ok(_personServices.Update(person));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			_personServices.Delete(id);
			return NoContent();
		}
	}
}
