using cursoInduccion.backend.Model;

namespace cursoInduccion.backend.Services
{
    public interface IWeatherForecastsService
    {
        Task<IEnumerable<WeatherForecast>> ToListAsync();
        Task<WeatherForecast?> FindAsync(int id);
        Task<int> Add(WeatherForecast weatherForecast);
        Task<int> Update(WeatherForecast weatherForecast);
        Task<int> Remove(WeatherForecast weatherForecast);
        bool Exists(int id);
    }
}
