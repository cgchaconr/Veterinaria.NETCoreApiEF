﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models{
    
    public class Mascotas
    {       
        
        public class mascota
        {
            [Required]
            public string Nombre { get; set; } = string.Empty;
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]            
            public string? FecNac { get; set; }
            [Required]
            [RegularExpression("M|F", ErrorMessage = "El genero debe ser 'M' o 'F'")]
            public string Genero { get; set; }
            [Required]
            public string Especie { get; set; } = string.Empty;

            public string Raza { get; set; } = string.Empty;

            public string? DuenoId { get; set; }
        }
        [Table("Mascotas")]
        public class Mascota:mascota
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }            

        }
    }
}
