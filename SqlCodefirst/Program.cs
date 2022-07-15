using SqlCodefirst;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp2
{
    class Program
    {


        public static void add() {


            ModelDbContext context = new ModelDbContext();


            var students = new List<Pupils> { new Pupils() { PupilId = 1, Name = "Giorgi", LastName = "a", Gender = "male", Class = "11.1" }, new Pupils() { PupilId = 2, Name = "Levani", LastName = "a", Gender = "male", Class = "11.1" },
        new Pupils() { PupilId = 3, Name = "Nika", LastName = "a", Gender = "male", Class = "11.1" },
        new Pupils() { PupilId = 4, Name = "Dato", LastName = "a", Gender = "male", Class = "11.1" } };

            var Teacher = new List<Teachers> { new Teachers() { TeacherId = 1, Name = "Giorgi", LastName = "a", Gender = "male", Subject = "some" },
            new Teachers() { TeacherId = 2, Name = "Levani", LastName = "a", Gender = "male", Subject = "some" },
            new Teachers() { TeacherId = 3, Name = "Nika", LastName = "a", Gender = "male", Subject = "some" },
            new Teachers() { TeacherId = 4, Name = "Dato", LastName = "a", Gender = "male", Subject = "some" } };






            context.Teacher.AddRange(Teacher);
            context.Pupil.AddRange(students);

             context.SaveChanges();

             var CLass = new List<Classes> { new Classes() { Id = 1, Class = "11.1", TeacherId = 3, PupilId = 1 }, new Classes { Id = 2, Class = "11.1", TeacherId = 3, PupilId = 2 }, new Classes { Id = 3, Class = "11.1", TeacherId = 3, PupilId = 3}      };
            context.Class.AddRange(CLass);
           
          
            context.SaveChanges();
        }


    static void Main(string[] args)
        {
           add();
            Console.WriteLine(DisplayAllTeachers("Giorgi"));
        }

        private static DataTable DisplayAllTeachers(string Name)
        {
            
            DataTable dataTable = new DataTable();
            var Teacher = new List<Teachers>();
            int temp;
            using (var context = new ModelDbContext())
            {
                foreach (var g in context.Class)
                {
                    if (g.TeacherId == null)
                    {
                        context.Class.Remove(g);
                    }
                }

                List<int> x = new List<int>();
                foreach (var Pupil in context.Pupil)
                {
                    if (Pupil.Name == Name)
                    {
                        x.Add(Pupil.PupilId);
                        temp = Pupil.PupilId;
                        
                      Teacher.Add(context.Teacher.Find(context.Class.Find(temp).TeacherId));
                    }
                    

                }

               



            }
            return dataTable;
        }





    }
}



     
    

   


