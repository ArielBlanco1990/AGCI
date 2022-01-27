using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGCI.ViewModels
{
    public class ComponenteViewModel
    {
        public string Componente { get; set; }
        public List<NormasViewModel> Normas { get; set; }
    }
}
