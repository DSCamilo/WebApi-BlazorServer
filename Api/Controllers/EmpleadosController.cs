using Microsoft.AspNetCore.Mvc;
using Services_CamiloBenitez.Repositories;
using Services_CamiloBenitez.Models;


namespace Services_CamiloBenitez.Controllers;


[ApiController]
[Route("[controller]")]
public class EmpleadosController : ControllerBase
{

    private readonly IEmpleadoRepository _empleadoRepository;

    public EmpleadosController(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    [HttpGet]
        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _empleadoRepository.Get();
        }

    [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleados(int id)
        {
            return await _empleadoRepository.Get(id);
        }


    [HttpPost]
        public async Task<ActionResult<Empleado>>PostEmpleados([FromBody] Empleado empleado)
        {
            var newEmpleado = await _empleadoRepository.Create(empleado);
            return CreatedAtAction(nameof(GetEmpleados), new { id = newEmpleado.Emp_Id }, newEmpleado);
        }
    
    [HttpPut]
        public async Task<ActionResult> PutEmpleados(int id, [FromBody] Empleado empleado)
        {
            if(id != empleado.Emp_Id)
            {
                return BadRequest();
            }

            await _empleadoRepository.Update(empleado);

            return NoContent();
        }

    
    [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var empleadoToDelete = await _empleadoRepository.Get(id);
            if (empleadoToDelete == null)
                return NotFound();

            await _empleadoRepository.Delete(empleadoToDelete.Emp_Id);
            return NoContent();
        }
   
}


