using System;
using System.ComponentModel.DataAnnotations;

namespace GastosRegisterO.Models
{
    public class Gastos
    {
       

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string Asunto { get; set; }
        [Required(ErrorMessage ="*")]
        public DateTime FechaHora { get; set; }
        [Required(ErrorMessage = "*")]
        public double Costo { get; set; }
        public string Imagen { get; set; }



        

    }
}
