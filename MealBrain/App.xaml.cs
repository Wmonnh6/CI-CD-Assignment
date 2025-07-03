using MealBrain.Data.Repositories;

namespace MealBrain
{
    public partial class App : Application
    {
        public static IMeasurementRepository MeasurementRepository { get; set; }

        public App(IMeasurementRepository measurementRepository)
        {
            InitializeComponent();

            MeasurementRepository = measurementRepository;

            MainPage = new AppShell();
        }
    }
}
