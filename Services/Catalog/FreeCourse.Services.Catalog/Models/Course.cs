using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace FreeCourse.Services.Catalog.Models
{
	public class Course
	{
		[BsonId] // mongodb haberdar etmek için üstüne BsonId attribute işaretlenir.
		[BsonRepresentation(BsonType.ObjectId)] //tipinide işaretlenmesi lazım. dönüşümleri bu yapıcak.
		public string Id { get; set; }
		public string Name { get; set; } //kursun ismi

		[BsonRepresentation(BsonType.Decimal128)]
		public decimal Price { get; set; }
		public string Picture { get; set; } //kursun url

		[BsonRepresentation(BsonType.DateTime)]
		public DateTime CreatedTime { get; set; } //oluşturulma tarihi
		public string UserId { get; set; } // her bir kurs bir kullanıcıya ait sonuçta
		public Feature Feature { get; set; } 

		[BsonRepresentation(BsonType.ObjectId)]  //mongo dbye  hangi property ne iş yapıcak onu belirtmek için.
		public string CategoryId { get; set; }

		[BsonIgnore]
		public Category Category { get; set; } //kursun bağlı olduğu kategori var . kodlama esnasında kullanıcaz. mongodb tarafında karşılığı olmasın dersek bu attribute ile.

	}
}
