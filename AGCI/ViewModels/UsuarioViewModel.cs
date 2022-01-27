using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AGCI.Models;

namespace AGCI.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme la Contraseña")]
        [Compare("Contraseña", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string ConfirmarContraseña { get; set; }

        public List<string> Roles { get; set; }

        public UsuarioViewModel(Usuario usuario)
        {
            NombreUsuario = usuario.UserName;
            CorreoElectronico = usuario.Correo;
        }

        public UsuarioViewModel()
        {
            
        }

    }
}