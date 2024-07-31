using System.Threading.Tasks;
using System.Collections.Generic;
using RMSuit_v2.Models;
using RMSuit_v2.Services.Camareros;
using RMSuit_v2.Services.Empleados;
using RMSuit_v2.Services.Dibujos;
using RMSuit_v2.Services.Salones;

namespace RMSuit_v2.Services
{
    public class ApiService
    {
        private readonly CamarerosService _camarerosService;
        private readonly EmpleadosService _empleadosService;
        private readonly DibujosService _dibujosService;
        private readonly SalonesService _salonesService;

        public ApiService(CamarerosService camarerosService, EmpleadosService empleadosService, DibujosService dibujosService, SalonesService salonesService)
        {
            _camarerosService = camarerosService;
            _empleadosService = empleadosService;
            _dibujosService = dibujosService;
            _salonesService = salonesService;
        }

        // Métodos para camareros
        public async Task<List<string>> GetListaCamareros()
        {
            return await _camarerosService.GetListaCamareros();
        }

        public async Task<List<Camarero>> GetWaiters()
        {
            return await _camarerosService.GetWaiters();
        }

        public async Task<Camarero?> GetWaiterById(int id)
        {
            return await _camarerosService.GetWaiterById(id);
        }

        public async Task<bool> AddWaiter(AddWaiterRequest waiterRequest)
        {
            return await _camarerosService.AddWaiter(waiterRequest);
        }

        public async Task<bool> UpdateWaiter(int id, UpdateWaiterRequest waiterRequest)
        {
            return await _camarerosService.UpdateWaiter(id, waiterRequest);
        }

        public async Task<bool> DeleteWaiter(int id)
        {
            return await _camarerosService.DeleteWaiter(id);
        }

        // Métodos para empleados
        public async Task<List<Employee>> GetEmployees()
        {
            return await _empleadosService.GetEmployees();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _empleadosService.GetEmployeeById(id);
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            return await _empleadosService.AddEmployee(employee);
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            return await _empleadosService.UpdateEmployee(id, employee);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _empleadosService.DeleteEmployee(id);
        }

        // Métodos para dibujos
        public async Task<List<Drawing>> GetDrawings()
        {
            return await _dibujosService.GetDrawings();
        }

        // Métodos para salones
        public async Task<List<Salon>> GetSalons()
        {
            return await _salonesService.GetSalons();
        }
    }
}
