using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ProductStates
    {
        [Key]
        public int ProductStateId { get; set; }

        [Required]
        public string Name { get; set; } // ("Disponible", "Defectuoso" o "Salido")
    }
}
