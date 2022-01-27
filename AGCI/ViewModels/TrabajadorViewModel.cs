using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AGCI.Models;
using AGCI.AuxClasses;
using System.Linq;
using System.Collections.Generic;

namespace AGCI.ViewModels
{
    public class TrabajadorViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "No. Identidad")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Inserte un número de identidad válido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Inserte un número de identidad válido")]
        [Remote("CiTrabajador", "Remote", AdditionalFields = "Id", ErrorMessage = "Ya existe un Trabajador con este No. de identidad")]
        public string Ci { get; set; }

        public string NombresApellidos { get; set; }

        public string Entidad { get; set; }
        public string Usuario { get; set; }
   
        public ICollection<TrabajadorArea> Areas { get; set; }



        public TrabajadorViewModel(Trabajador trabajador)
        {
            Id = trabajador.Id;
            Ci = trabajador.Ci;
            NombresApellidos = trabajador.Nombres + " " + trabajador.PrimerApellido + " " + trabajador.SegundoApellido;
            Entidad = trabajador.TrabajadorArea.First().Area.UnidadOrganizativa.Nombre;
            Areas = trabajador.TrabajadorArea;
            Usuario = trabajador.Usuario != null ? trabajador.Usuario.UserName : "";
        }

    }
}