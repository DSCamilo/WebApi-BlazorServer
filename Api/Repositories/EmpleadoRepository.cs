using Services_CamiloBenitez.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;


namespace Services_CamiloBenitez.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly string _connectionString;

        public EmpleadoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public async Task<Empleado> Create(Empleado empleado)
        {
            var sqlQuery = "INSERT INTO Empleados(Last_Name, First_Name, Gender, Title) VALUES (@Last_Name, @First_Name, @Gender, @Title )";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new 
                {
                    empleado.Last_Name,
                    empleado.First_Name,
                    empleado.Gender,
                    empleado.Title,
                    
                });

                return empleado;
            }
        }

        public async Task Delete(int id)
        {
            var sqlQuery = $"DELETE from Empleados WHERE Emp_Id={id}";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery);
            }
        }

        public async Task<IEnumerable<Empleado>> Get()
        {
            var sqlQuery = "SELECT * FROM Empleados";

            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryAsync<Empleado>(sqlQuery);
            } 
        }

        public async Task<Empleado> Get(int id)
        {
            var sqlQuery = "SELECT * FROM Empleados WHERE Emp_Id=@ToolId";

            using (var connection = new SqliteConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Empleado>(sqlQuery, new { ToolId = id });
            }
        }

        public async Task Update(Empleado empleado)
        {
            var sqlQuery = "UPDATE Empleados SET Last_Name=@Last_Name, First_Name=@First_Name, Gender=@Gender, Title=@Title WHERE Emp_Id=@Emp_Id";

            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    empleado.Emp_Id,
                    empleado.Last_Name,
                    empleado.First_Name,
                    empleado.Gender,
                    empleado.Title,
                });
            }
        }
    }
}