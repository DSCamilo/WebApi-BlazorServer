using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services_CamiloBenitez.Models;

namespace Services_CamiloBenitez.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> Get();
        Task<Empleado> Get(int id);
        Task<Empleado> Create(Empleado empleado);
        Task Update(Empleado empleado);
        Task Delete(int id);

    }
}