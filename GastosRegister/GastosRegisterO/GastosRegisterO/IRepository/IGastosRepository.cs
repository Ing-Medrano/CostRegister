using GastosRegisterO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GastosRegisterO.IRepository
{
    public interface IGastosRepository:IRepository<Gastos>
    {

        IEnumerable<SelectListItem> listaGastos();

        void Update(Gastos gastos);
        double Total();
      
    }
}
