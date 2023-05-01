using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Age { get; set; }
        public string Departement { get; set; }
        public DateTime DateOfJoining { get; set; }

    }
}