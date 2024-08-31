using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
	public class Category
	{
		[BsonId] // mongodb haberdar etmek için üstüne BsonId attribute işaretlenir.
		[BsonRepresentation(BsonType.ObjectId)] //tipinide işaretlenmesi lazım. dönüşümleri bu yapıcak.
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
