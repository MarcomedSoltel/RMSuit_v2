using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using RMSuit_v2.Models;
using Microsoft.Extensions.Logging;
using System.Text;

namespace RMSuit_v2.Services.Empleados
{
    public class EmpleadosService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmpleadosService> _logger;

        public EmpleadosService(HttpClient httpClient, ILogger<EmpleadosService> logger)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);
            _logger = logger;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await GetListFullFromApi<Employee>("https://37.59.32.58:1380/Master/Employees/GetEmployees?initialCatalog=ELSIFON");
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://37.59.32.58:1380/Master/Employees/GetEmployee/{id}?initialCatalog=ELSIFON");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Employee>(json);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error al obtener empleado por ID: {Message}", ex.Message);
                return null;
            }
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://37.59.32.58:1380/Master/Employees/AddEmployee?initialCatalog=ELSIFON", jsonContent);

                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error al añadir empleado: {Message}", ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

                _logger.LogInformation("Enviando solicitud PUT a {Url} con contenido: {JsonContent}", $"https://37.59.32.58:1380/Master/Employees/UpdateEmployee/{id}?initialCatalog=ELSIFON", JsonSerializer.Serialize(employee));

                var response = await _httpClient.PutAsync($"https://37.59.32.58:1380/Master/Employees/UpdateEmployee/{id}?initialCatalog=ELSIFON", jsonContent);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error al actualizar empleado: {Message}", ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://37.59.32.58:1380/Master/Employees/DeleteEmployee/{id}?initialCatalog=ELSIFON");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error al eliminar empleado: {Message}", ex.Message);
                return false;
            }
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
