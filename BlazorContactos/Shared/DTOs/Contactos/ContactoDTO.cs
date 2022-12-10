using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Shared.DTOs.Contactos
{
    public class ContactoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
    }
}
