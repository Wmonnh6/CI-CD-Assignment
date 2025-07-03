using SQLite;

namespace MealBrain.Data.Entities
{
	[Table("measurement")]
	public class Measurement
	{
		[PrimaryKey, AutoIncrement, Column("id")]
		public int Id { get; set; }

		[MaxLength(50), Unique, Column("measurement_name")]
		public string Name { get; set; } = string.Empty;

		[MaxLength(10), Unique, Column("measurement_abbr")]
		public string Abbreviation { get; set; } = string.Empty;
	}
}
