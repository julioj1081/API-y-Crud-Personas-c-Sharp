using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Web_Basico.Models
{
    public class Persona
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Apellidos { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        public string Direccion { get; set; }

        public int Edad { get; set; }
    }
}
