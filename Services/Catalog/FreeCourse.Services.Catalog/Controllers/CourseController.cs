using FreeCourse.Services.Catalog.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Services.Catalog.Dtos;

namespace FreeCourse.Services.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : CustomBaseController
	{
		//her bir servise yonelik endpointimiz olacak. 
		private readonly ICourseService  _courseService;
		public CourseController(ICourseService courseService) 
		{
			_courseService = courseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll() 
		{
			var courses = await _courseService.GetAllAsync();
			return CreateActionResultInstance(courses);
		}

		[HttpGet("{id}")] // courses/4
		public async Task<IActionResult> GetById(string id) 
		{
			var course = await _courseService.GetByIdAsync(id);
			return CreateActionResultInstance(course);
		}

		[HttpGet]
		[Route("/api/[controller]/GetAllByUserId/{userId}")] //custom bir route yazdık.
		public async Task<IActionResult> GetAllByUserId(string userId) 
		{
			var courses = await _courseService.GetAllByUserIdAsync(userId);
			return CreateActionResultInstance(courses);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CourseCreateDto courseCreateDto) 
		{
			var response = await _courseService.CreateAsync(courseCreateDto);
			return CreateActionResultInstance(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto) 
		{
			var response = await _courseService.UpdateAsync(courseUpdateDto);
			return CreateActionResultInstance(response);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(string id) 
		{
			var response = await _courseService.DeleteAsync(id);
			return CreateActionResultInstance(response);
		}
	}
}
