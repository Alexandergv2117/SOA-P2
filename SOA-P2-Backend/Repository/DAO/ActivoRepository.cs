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
    public class ActivoRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddActivo (RequestPostCreateActivo newActivo)
        {
            Activo activo = new Activo();
            activo = _context.Activos.FirstOrDefault(x => x.name == newActivo.name);

            if (activo == null) 
            {
                _context.Activos.Add(new Activo
                {
                    name = newActivo.name,
                    description = newActivo.description,
                    status = false
                });

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Activo GetById(int id)
        {
            Activo activo = new Activo();

            activo = _context.Activos.FirstOrDefault(x => x.id == id);

            return activo;
        }

        public bool UpdateStatusActivo(RequestPatchUpdateStatusActivo newStatus)
        {
            Activo activo = new Activo();
            activo = _context.Activos.FirstOrDefault(a => a.id == newStatus.id);

            if (activo != null)
            {
                activo.status = newStatus.status;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Activo> GetAll()
        {
            List<Activo> activos = new List<Activo>();

            activos = _context.Activos.ToList();

            return activos;
        }

        public bool Delete(RequestDeleteActivo requestDeleteActivo)
        {
            Activo activo = new Activo();

            activo = _context.Activos.Single(x => x.id == requestDeleteActivo.id && x.status == false);

            if (activo != null)
            {
                _context.Activos.Remove(activo);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
