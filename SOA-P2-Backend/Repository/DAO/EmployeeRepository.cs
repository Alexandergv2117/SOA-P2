using Domain.Entities;
using Domain.Request;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmpleadoVM> GetList()
        {
            List<EmpleadoVM> list = new List<EmpleadoVM>();

            list = _context.Empleados.Include(x => x.Persona).Select(x => new EmpleadoVM()
            {
                curp = x.Persona.curp,
                name = x.Persona.name,
                last_name = x.Persona.last_name,
                birth_date = x.Persona.birth_date,
                num_employee = x.num_employee,
                email = x.email,
                date_hire = x.date_hire,
                status = x.status
            }).ToList();

            return list;
        }

        public EmpleadoVM GetEmpleadoById(int id)
        {
            EmpleadoVM empleadoVM = new EmpleadoVM();

            empleadoVM = _context.Empleados
                .Include(x => x.Persona)
                .Where(x => x.num_employee == id)
                .Select(x => new EmpleadoVM()
                {
                    curp = x.Persona.curp,
                    name = x.Persona.name,
                    last_name = x.Persona.last_name,
                    birth_date = x.Persona.birth_date,
                    num_employee = x.num_employee,
                    email = x.email,
                    date_hire = x.date_hire,
                    status = x.status
                })
                .FirstOrDefault();

            return empleadoVM;
        }

        public void AddEmployee(RequestPostCreateEmployee newEmployee)
        {
            _context.Personas.Add(new Persona
            {
                curp = newEmployee.curp,
                name = newEmployee.name,
                last_name = newEmployee.last_name,
                birth_date = DateTime.Parse(newEmployee.birth_date),
            });

            _context.Empleados.Add(new Empleado
            {
                id_people = newEmployee.curp,
                email = newEmployee.email,
                date_hire = DateTime.Now,
                status = true
            });

            _context.SaveChanges();
        }

		public void UpdateEmployee(RequestPatchUpdateEmployee newEmployee)
		{
			Persona? persona = _context.Personas.FirstOrDefault(a => a.curp == newEmployee.curp);

			if (persona != null)
			{
				Empleado? empleado = _context.Empleados.FirstOrDefault(a => a.id_people == persona.curp);

				persona.birth_date = DateTime.Parse(newEmployee.birth_date);
				persona.last_name = newEmployee.last_name;
				persona.name = newEmployee.name;
                
                if(empleado != null)
                {
					empleado.email = newEmployee.email;
				}

				_context.SaveChanges();
			}
		}

		public void DeleteEmployee(string idEmployee)
		{
			Persona? persona = _context.Personas.FirstOrDefault(a => a.curp == idEmployee);

			if (persona != null)
			{
				Empleado? empleado = _context.Empleados.FirstOrDefault(a => a.id_people == persona.curp);

				if (empleado != null)
				{
					_context.Empleados.Remove(empleado);
					_context.Personas.Remove(persona);

				}
				_context.SaveChanges();
			}
		}
	}
}
