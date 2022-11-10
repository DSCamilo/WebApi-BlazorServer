using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient httpClient;

        public EmpleadoService(HttpClient _httpClient){
            httpClient = _httpClient;
        }

         async Task<List<Empleado>> IEmpleadoService.getEmpleados()
        {
            return await httpClient.GetFromJsonAsync<List<Empleado>>("Empleados");

        }
        
    }
}