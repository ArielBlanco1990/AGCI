using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGCI.ViewModels
{
    public class GrupoPreguntaViewModel
    {
        public string Grupo { get; set; }
        public List<PreguntasViewModel> Preguntas { get; set; }

    }
}
