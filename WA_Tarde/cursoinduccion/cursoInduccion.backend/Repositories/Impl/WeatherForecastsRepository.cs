using cursoInduccion.backend.Data;
using cursoInduccion.backend.Model;
using Microsoft.EntityFrameworkCore;

namespace cursoInduccion.backend.Repositories.Impl
{
    public class WeatherForecastsRepository : BaseRepository, IWeatherForecastsRepository
    {
        public WeatherForecastsRepository(AppDbContext context) : base(context)
        {
        }

        Task<int> IWeatherForecastsRepository.Add(WeatherForecast weatherForecast)
        {
            _context.WeatherForecast.Add(weatherForecast);
            return _context.SaveChangesAsync();
        }

        bool IWeatherForecastsRepository.Exists(int id)
        {
            return _context.WeatherForecast.Any(e => e.Id == id);
        }

        async Task<WeatherForecast?> IWeatherForecastsRepository.FindAsync(int id)
        {
            return await _context.WeatherForecast.FindAsync(id);
        }

        async Task<IEnumerable<WeatherForecast>> IWeatherForecastsRepository.ListAsync()
        {
            return await _context.WeatherForecast.ToListAsync();
        }
        Task<int> IWeatherForecastsRepository.Update(WeatherForecast weatherForecast)
        {
            _context.Entry(weatherForecast).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        Task<int> IWeatherForecastsRepository.Remove(WeatherForecast weatherForecast)
        {
            _context.WeatherForecast.Remove(weatherForecast);
            return _context.SaveChangesAsync();
        }

    }
}
