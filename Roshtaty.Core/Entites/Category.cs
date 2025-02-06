using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Entites
{
    public class Category :BaseEntity
    {
        public string CategoryName { get; set; }
       
        public int MainSystemId { get; set; } //Fk
        public Main_System MainSystem { get; set; }
    }
}
