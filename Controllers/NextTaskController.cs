using CountNextTaskDate.Models.DTOs;
using CountNextTaskDate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CountNextTaskDate.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NextTaskController : ControllerBase
	{

		private readonly INextTaskRepository _repository;

		public NextTaskController(INextTaskRepository repository)
		{
			_repository = repository;
		}



		[HttpPost]
		public async Task<IActionResult> Post(NextTaskRequest request)
		{
			return Created("",await _repository.Calculate(request));
		}

		[HttpGet]
		public async Task<IActionResult> GetLast()
		{
			return Ok(await _repository.Get());
		}
	}
}