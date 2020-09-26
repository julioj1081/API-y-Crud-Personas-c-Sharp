using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//importaciones
using Microsoft.EntityFrameworkCore;
namespace API_Web_Basico.Models
{
    public class PersonasDBContext:DbContext
    {
        public PersonasDBContext(DbContextOptions<PersonasDBContext> options) : base(options)
        {

        }
        //llamamos a la clase Persona y Personas
        public DbSet<Persona> Personas { get; set; }
    }
}
