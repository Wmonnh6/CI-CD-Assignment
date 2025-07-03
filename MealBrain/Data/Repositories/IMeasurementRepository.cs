using MealBrain.Data.Entities;

namespace MealBrain.Data.Repositories
{
	public interface IMeasurementRepository
	{
		//Create
		Task InsertMeasurment(string name, string abbr);

		//Read
		Task<Measurement> GetMeasurementByName(string name);
		Task<Measurement> GetMeasurementByAbbr(string abbr);
		Task<List<Measurement>> GetAllMeasurements();

		//Update
		Task UpdateMeasurment(Measurement measurement);

		//Delete
		Task DeleteMeasurementById(int id);
	}
}
