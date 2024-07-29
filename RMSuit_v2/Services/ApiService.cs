using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RMSuit_v2.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

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
            return await GetListFromApi<Camarero>("https://37.59.32.58:1380/Master/Waiters/GetWaiters?initialCatalog=ELSIFON", c => c.Nombre);
        }

    public async Task<List<Camarero>> GetWaiters()
    {
        return await GetListFullFromApi<Camarero>("https://37.59.32.58:1380/Master/Waiters/GetWaiters?initialCatalog=ELSIFON");
    }

    public async Task<List<Drawing>> GetDrawings()
    {
        return await GetListFullFromApi<Drawing>("https://37.59.32.58:1380/Master/Drawings/GetDrawings?initialCatalog=ELSIFON");
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await GetListFullFromApi<Employee>("https://37.59.32.58:1380/Master/Employees/GetEmployees?initialCatalog=ELSIFON");
    }

    /*  public async Task<List<string>> GetListaSalonPhotos()
      {
          return await GetListFromApi<SalonPhoto>("https://37.59.32.58:1380/Master/SalonPhotos/GetSalonPhotos?initialCatalog=ELSIFON", sp => sp.Nombre);
      }
    */
    public async Task<List<Salon>> GetSalons()
    {
        return await GetListFullFromApi<Salon>("https://37.59.32.58:1380/Master/Salons/GetSalons");
    }

    /*     public async Task<List<string>> GetListaSalonTables()
       {
            return await GetListFromApi<SalonTable>("https://37.59.32.58:1380/Master/SalonTables/GetSalonTables", st => st.Nombre);
        }
    */
    private async Task<List<string>> GetListFromApi<T>(string url, Func<T, string> selector)
        {
            _logger.LogInformation("Comenzando la solicitud...");

            try
            {
                _logger.LogInformation($"Recibiendo datos desde la API: {url}");

                var httpResponseMessage = await _httpClient.GetAsync(url);
                httpResponseMessage.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa

                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                _logger.LogInformation($"Respuesta JSON: {jsonString}");

                var items = JsonSerializer.Deserialize<List<T>>(jsonString);

                if (items != null && items.Count > 0)
                {
                    _logger.LogInformation($"La lista contiene {items.Count} elementos");
                    return items.Select(selector).ToList();
                }
                else
                {
                    _logger.LogInformation("No hay datos disponibles desde la API.");
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
                _logger.LogError(ex, "Error inesperado al recibir datos");
                return new List<string>();
            }
        }

    private async Task<List<T>> GetListFullFromApi<T>(string url)
    {
        _logger.LogInformation("Comenzando la solicitud...");

        try
        {
            _logger.LogInformation($"Recibiendo datos desde la API: {url}");

            var httpResponseMessage = await _httpClient.GetAsync(url);
            httpResponseMessage.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa

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

