using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Shared.ControllerBases
{
	public class CustomBaseController : ControllerBase
	{
		public IActionResult CreateActionResultInstance<T>(Response<T> response) 
		{
			//badrequest gibi donmeme gerek yok ortak bir yere aldık  her seferinde farklı farklı dönmiycek.
			return new ObjectResult(response) 
			{
				StatusCode = response.StatusCode
			};
		}
	}
}
