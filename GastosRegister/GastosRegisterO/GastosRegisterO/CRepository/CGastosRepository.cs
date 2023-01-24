using GastosRegisterO.Data;
using GastosRegisterO.IRepository;
using GastosRegisterO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GastosRegisterO.CRepository
{
    public class CGastosRepository : CRepository<Gastos>, IGastosRepository
    {
        protected new readonly ApplicationDbContext _context;
        public CGastosRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> listaGastos()
        {
            var lista = _context.gastos.Select(n => new SelectListItem() { 
            Text=n.Asunto,
            Value=n.Id.ToString()
            
            });
            return lista;
        }

        public double Total()
        {
            var total = _context.gastos.Select(n => n.Costo).Sum();
            return total;
            
        }

        public void Update(Gastos gastos)
        {
            var update = _context.gastos.FirstOrDefault(n => n.Id == gastos.Id);
            update.Asunto = gastos.Asunto;
            update.Imagen=gastos.Imagen;
            update.FechaHora=gastos.FechaHora;
            update.Costo = gastos.Costo;

            _context.SaveChanges();
        }
    }
}
