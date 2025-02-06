using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Entites
{
    public class Disease:BaseEntity
    {
        public string DiseaseName { get; set; }
        public int CategoryId { get; set; } //Fk
        public Category  Category { get; set; }
    }
}
