﻿using System.ComponentModel.DataAnnotations;

namespace BlazorContactos.Server.Model.Entities
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } 

        public List<MedioContacto> MedioContactos { get; set; }
    }
}
