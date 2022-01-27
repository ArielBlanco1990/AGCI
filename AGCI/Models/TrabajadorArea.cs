using AGCI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AGCI.Models
{
    
    public class TrabajadorArea
    {
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public int TrabajadorId { get; set; }
        public virtual Trabajador Trabajador { get; set; }
    }
}