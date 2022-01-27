using System.ComponentModel.DataAnnotations;

namespace AGCI.ViewModels
{
    public class CambiarContraseñaViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña Actual")]
        public string ContraseñaActual { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña")]
        public string ContraseñaNueva { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme la Nueva Contraseña")]
        [Compare("ContraseñaNueva", ErrorMessage = "La contraseña nueva y la confirmación no coinciden.")]
        public string ConfimaContraseña { get; set; }
    }
}