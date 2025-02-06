using Roshtaty.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Specifications
{
    public class DiseasesSpecifications:BaseSpecifications<Disease>
    {
        public DiseasesSpecifications():base()
        {
            Includes.Add(P=> P.Category);
        }
        
        public DiseasesSpecifications(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.Category.MainSystem);
          
       
        }
    }
}
