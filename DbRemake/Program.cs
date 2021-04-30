using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRemake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            using (var ctx = new PeopleContext())
            {
                ctx.Peoples.Add(new People() { FirstName = "Dagboek",LastName = "woops" });
                ctx.SaveChanges();
            }
            Console.WriteLine("Ended");
        }
    }
    public class People 
    {
        public int PeopleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public int VdabNumber { get; set; }
        public bool Getrouwd { get; set; }
        public string email { get; set; }
        public int RoleId { get; set; }
    }
    public class Role
    {
        public string Name { get; set; }

        [Key]
        [ForeignKey("People")]
        public int RoleId { get; set; }
        public People People { get; set; }

    }
    public class Hobby
    {
        public int HobbyId { get; set; }
        public string Name { get; set; }
    }
    public class PeopleHobbies
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("People")]
        public int PeopleId { get; set; }
        public People People { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Hobby")]
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }


    }
    public class PeopleContext : DbContext
    {
        public PeopleContext() : base("name = ConnectString")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<NotitieboekjeContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PeopleContext>());
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PeopleHobbies> PeopleHobbies { get; set; }
        public DbSet<Role> Roles { get; set; }
       

    }
}
