using System.ComponentModel.DataAnnotations;

namespace AGCI.ViewModels
{
    public class AutenticarseViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }
    }
}