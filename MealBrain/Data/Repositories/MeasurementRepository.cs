using System.Threading.Tasks;
using SQLite;
using MealBrain.Data.Entities;

namespace MealBrain.Data.Repositories
{
	public class MeasurementRepository : IMeasurementRepository
	{
		private readonly string _dbPath;

		private SQLiteAsyncConnection _connection;

		public string StatusMessage { get; set; }

		public MeasurementRepository(string dbPath)
		{
			_dbPath = dbPath;
		}

		public async Task DeleteMeasurementById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Measurement>> GetAllMeasurements()
		{
			try
			{
				await Init();

				return await _connection.Table<Measurement>().ToListAsync();
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to retrive measurement data. {0}", ex.Message);
			}

			return new List<Measurement>();
		}

		public Task<Measurement> GetMeasurementByAbbr(string abbr)
		{
			throw new NotImplementedException();
		}

		public Task<Measurement> GetMeasurementByName(string name)
		{
			throw new NotImplementedException();
		}

		public async Task InsertMeasurment(string name, string abbr)
		{
			int result = 0; // how many rows were inserted
			try
			{
				await Init();

				var newMeasure = new Measurement
				{
					Name = name,
					Abbreviation = abbr
				};
				result = await _connection.InsertAsync(newMeasure);

				// TODO: handle result == 0

				StatusMessage = string.Format("{0} record(s) inserted [Measurment Name: {1}, Measurement Abbreviation: {2}]", result, name, abbr);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to insert {0}. Error: {1}", name, ex.Message);
			}
		}

		public Task UpdateMeasurment(Measurement measurement)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// The Init method opens a connection to the database and makes sure that the table is created (if not exists)
		/// </summary>
		private async Task Init()
		{
			if(_connection is not null)
			{
				return;
			}

			_connection = new SQLiteAsyncConnection(_dbPath);
			await _connection.CreateTableAsync<Measurement>();
		}
	}
}
