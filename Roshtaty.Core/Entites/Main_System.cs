using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Entites
{
    public class Main_System :BaseEntity
    {
        public string MainSystemName { get; set; }
        //  public ICollection<Category> Categories { get; set; } => IDon't need it in Business (Configuration with FluentAPi) 
    }
}
