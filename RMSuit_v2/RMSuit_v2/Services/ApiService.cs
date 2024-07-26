using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RMSuit_v2.Models;
using Microsoft.Extensions.Logging;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        var handler = new HttpClientHandler
        {
            // Esto es para acceder cuando hay un aviso de seguridad donde debes confirmar que estás seguro para entrar
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        _httpClient = new HttpClient(handler);
        _logger = logger;
    }

    public async Task<List<string>> GetListaCamareros()
    {
        var url = "https://37.59.32.58:1380/Master/Camareros/GetCamareros?initialCatalog=ELSIFON";
        _logger.LogInformation("Comenzando la solicitud...");

        try
        {
            _logger.LogInformation($"Recibiendo camareros desde la API: {url}");

            var httpResponseMessage = await _httpClient.GetAsync(url);
            httpResponseMessage.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa

            var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
            _logger.LogInformation($"Respuesta JSON: {jsonString}");

            var camareros = JsonSerializer.Deserialize<List<Camarero>>(jsonString);

            if (camareros != null && camareros.Count > 0)
            {
                _logger.LogInformation($"La lista contiene {camareros.Count} camareros");
                return camareros.Select(c => c.Nombre).ToList();
            }
            else
            {
                _logger.LogInformation("No hay ningún camarero disponible desde la API.");
                return new List<string>();
            }
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, "Error al analizar el JSON");
            return new List<string>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, "Error de solicitud HTTP");
            return new List<string>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inesperado al recibir camareros");
            return new List<string>();
        }
    }
}
