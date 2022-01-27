using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AGCI.AuxClasses;
using AGCI.Models;

namespace AGCI.ViewModels
{
    public class ParamViewModel
    {

        public List<int> Areas { get; set; }

        public int? AreaId { get; set; }

        public int? Mes { get; set; }

        public int? Año { get; set; }




    }
}