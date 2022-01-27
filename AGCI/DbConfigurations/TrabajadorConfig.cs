using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGCI.Models;

namespace AGCI.DbConfigurations
{
    public class TrabajadorConfig: EntityTypeConfiguration<Trabajador>
    {
        public TrabajadorConfig()
        {
            ToTable("rh_trabajadores");
            //HasOptional(t => t.PuestoDeTrabajo).WithMany(p => p.Trabajadores).WillCascadeOnDelete(false);
            
        }
    }
}
