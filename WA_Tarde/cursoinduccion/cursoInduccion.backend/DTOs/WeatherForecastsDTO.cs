using cursoInduccion.backend.Model;
using cursoInduccion.backend.Validators;
using System.ComponentModel.DataAnnotations;

namespace cursoInduccion.backend.DTOs
{
    public class WeatherForecastsNewDTO
    {
        [DateValidator(DateValidator.Comparation.AFTER)]
        public DateOnly Fecha { get; set; }

        [Range(-30, 65, ErrorMessage = "Valor para {0} debe estar entre {1} y {2}.")]
        public int Celsius { get; set; }
        [StringLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        public string? Resumen { get; set; }

        public static WeatherForecastsNewDTO ToDTO(WeatherForecast obj)
        {
            return new WeatherForecastsNewDTO
            {
                Fecha = obj.Date,
                Celsius = obj.TemperatureC,
                Resumen = obj.Summary,
            };
        }

        public static WeatherForecast ToObject(WeatherForecastsNewDTO dto)
        {
            return new WeatherForecast
            {
                Date = dto.Fecha,
                TemperatureC = dto.Celsius,
                Summary = dto.Resumen
            };
        }
    }
    public class WeatherForecastsDTO : WeatherForecastsNewDTO
    {
        public int Id { get; set; }

        public new static WeatherForecastsDTO ToDTO(WeatherForecast obj)
        {
            return new WeatherForecastsDTO
            {
                Id = obj.Id,
                Fecha = obj.Date,
                Celsius = obj.TemperatureC,
                Resumen = obj.Summary,
            };
        }

        public static WeatherForecast ToObject(WeatherForecastsDTO dto)
        {
            return new WeatherForecast
            {
                Id = dto.Id,
                Date = dto.Fecha,
                TemperatureC = dto.Celsius,
                Summary = dto.Resumen
            };
        }
    }
}
