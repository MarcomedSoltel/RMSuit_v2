using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RMSuit_v2.Models;
using Microsoft.Extensions.Logging;

namespace RMSuit_v2.Services.Salones
{
    public class SalonesService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SalonesService> _logger;

        public SalonesService(HttpClient httpClient, ILogger<SalonesService> logger)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);
            _logger = logger;
        }

        public async Task<List<Salon>> GetSalons()
        {
            return await GetListFullFromApi<Salon>("https://37.59.32.58:1380/Master/Salons/GetSalons?initialCatalog=ELSIFON");
        }

        private async Task<List<T>> GetListFullFromApi<T>(string url)
        {
            _logger.LogInformation("Comenzando la solicitud...");

            try
            {
                _logger.LogInformation($"Recibiendo datos desde la API: {url}");

                var httpResponseMessage = await _httpClient.GetAsync(url);
                httpResponseMessage.EnsureSuccessStatusCode();

                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                _logger.LogInformation($"Respuesta JSON: {jsonString}");

                var items = JsonSerializer.Deserialize<List<T>>(jsonString);

                if (items != null && items.Count > 0)
                {
                    _logger.LogInformation($"La lista contiene {items.Count} elementos");
                    return items;
                }
                else
                {
                    _logger.LogInformation("No hay datos disponibles desde la API.");
                    return new List<T>();
                }
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Error al analizar el JSON");
                return new List<T>();
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "Error de solicitud HTTP");
                return new List<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al recibir datos");
                return new List<T>();
            }
        }
    }
}
