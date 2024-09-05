using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
	public class Response<T>
	{
		//başarılı olduğunda doldurulucak
		public T Data { get; private set; }

		[JsonIgnore] //response zaten statuscode var. yazılım içinde kullancaksam diye response içinde olmasına gerek yok diye jsonignore işaretlendi.
		public int StatusCode { get; private set; }
		[JsonIgnore]
		public bool IsSuccessful { get; private set; }

		//başarısız olduğunda doldurulucak
		public List<string> Errors { get; set; }
		
		//static factory method diye geçer bu metodlar.

		//zaten burada oluşturulduğu için dışarıdan setlenmesine gerek yok. başarılı olabilir ama data dönücek.
		public static Response<T> Success(T data, int statusCode) 
		{
			return new Response<T> { StatusCode = statusCode, Data = data , IsSuccessful  = true};
		}

		//başarılı olabilir ama data almasın update delete gibi overload metodu olsun.
		public static Response<T> Success(int statusCode) 
		{
			return new Response<T> { StatusCode = statusCode, Data = default(T), IsSuccessful = true };
		}

		//hata durumunda toplu dönülmesi. errordto su yerine bu şekilde yaptık.
		public static Response<T> Fail(List<string> errors, int statusCode) 
		{
			return new Response<T> 
			{ 
				Errors = errors,
				StatusCode = statusCode,
				IsSuccessful = false
			};
		}
		//tek hata varsa
		public static Response<T> Fail(string error, int statusCode) 
		{
			return new Response<T> {
				Errors = new List<string>() { error},
				StatusCode = statusCode,
				IsSuccessful = false
			};
		}
	}
}
