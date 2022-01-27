using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGCI.Models;

namespace AGCI.DbConfigurations
{
    public class UnidadOrganizativaConfig:EntityTypeConfiguration<UnidadOrganizativa>
    {
        public UnidadOrganizativaConfig()
        {
            ToTable("rh_unidad_organizativa");
        }
    }
}
