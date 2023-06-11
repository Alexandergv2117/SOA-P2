using Domain.Entities;
using Domain.Request;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
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
            EmpleadoVM? empleadoVM = new EmpleadoVM();

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
            string passEncrypted = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(newEmployee.password));

                passEncrypted = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
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
                status = true,
                password = passEncrypted
            });

            _context.SaveChanges();
        }

        public bool validCredentials(RequestPostLogin user)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(user.password));

                string passEncrypted = BitConverter.ToString(bytes).Replace("-", "").ToLower();

                bool isValid = _context.Empleados.Any(e => e.email == user.email && e.password == passEncrypted);

                return isValid;
            }
        }

        public bool UpdateEmployee(RequestPutUpdateEmployee employee)
        {
            Persona? persona = new Persona();
            Empleado? empleado = new Empleado();
            empleado = _context.Empleados.FirstOrDefault(e => e.num_employee == employee.num_employee);

            if (empleado != null)
            {
                persona = _context.Personas.FirstOrDefault(a => a.curp == empleado.id_people);
                persona.name = employee.name;
                persona.last_name = employee.last_name;
                persona.birth_date = employee.birth_date;

                empleado.email = employee.email;
                empleado.status = employee.status;

                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public bool DeleteEmployee(int idEmployee)
        {
            Empleado? dataEmployee = new Empleado();
            Persona? persona = new Persona();

            dataEmployee = _context.Empleados.FirstOrDefault(e => e.num_employee == idEmployee);

            if (dataEmployee != null)
            {
                persona = _context.Personas.FirstOrDefault(p => p.curp == dataEmployee.id_people);

                if (persona != null)
                {
                    _context.Empleados.Remove(dataEmployee);
                    _context.Personas.Remove(persona);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
