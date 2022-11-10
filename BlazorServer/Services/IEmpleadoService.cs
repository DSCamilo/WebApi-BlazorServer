using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public interface IEmpleadoService
    {
             Task<List<Empleado>> getEmpleados();
    }
}