using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCodefirst
{
    internal class Models
    {


    }

    public class ModelDbContext : DbContext {

        public ModelDbContext() : base("DB") { }
        public DbSet<Teachers> Teacher { get; set; }
        public DbSet<Pupils> Pupil { get; set; } 

        public DbSet<Classes> Class { get; set; }




    }


    public class Teachers {
        
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public String Gender { get; set; }
        public String Subject { get; set; }
    }

    public class Pupils
    { 
        [Key]
        public int PupilId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public String Gender { get; set; }
        public String Class { get; set; }

    }

    public class Classes {

        [Key]
        public int Id { get; set; }

          public string Class { get; set; }

        public int TeacherId{ get; set; }

         public int PupilId { get; set; }
        
    }

}
