using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Server.Model.Entities
{
    public class MedioContacto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        [Required]
        public string Celular { get; set; }
        public int ContactoId { get; set; }
        public Contacto Contactos { get; set; }

    }
}
