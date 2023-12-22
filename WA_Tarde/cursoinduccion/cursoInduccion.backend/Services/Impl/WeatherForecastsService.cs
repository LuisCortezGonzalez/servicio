using cursoInduccion.backend.Model;
using cursoInduccion.backend.Repositories;

namespace cursoInduccion.backend.Services.Impl
{
    public class WeatherForecastsService : IWeatherForecastsService
    {
        private readonly IWeatherForecastsRepository _weatherForecastsRepository;

        public WeatherForecastsService(IWeatherForecastsRepository weatherForecastsRepository)
        {
            this._weatherForecastsRepository = weatherForecastsRepository;
        }

        Task<int> IWeatherForecastsService.Add(WeatherForecast weatherForecast)
        {
            return _weatherForecastsRepository.Add(weatherForecast);
        }

        bool IWeatherForecastsService.Exists(int id)
        {
            return _weatherForecastsRepository.Exists(id);
        }

        Task<WeatherForecast?> IWeatherForecastsService.FindAsync(int id)
        {
            return _weatherForecastsRepository.FindAsync(id);
        }

        Task<IEnumerable<WeatherForecast>> IWeatherForecastsService.ToListAsync()
        {
            return _weatherForecastsRepository.ListAsync();
        }

        Task<int> IWeatherForecastsService.Remove(WeatherForecast weatherForecast)
        {
            return _weatherForecastsRepository.Remove(weatherForecast);
        }

        Task<int> IWeatherForecastsService.Update(WeatherForecast weatherForecast)
        {
            return _weatherForecastsRepository.Update(weatherForecast);
        }
    }
}
