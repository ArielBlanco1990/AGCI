using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AGCI.AuxClasses;
using AGCI.Models;


namespace AGCI.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "{0} debe ser de 11 dígitos")]
        [ValidarCi]
        [StringLength(11, ErrorMessage = "{0} no puede tener más de 11 dígitos")]
        public string Ci { get; set; }

        [Required]
        [RegularExpression("[a-z A-Z,ñ,Ñ,í,ó,á,é,ú,Í,Ó,Á,É,Ú,ü,Ü,. ]*", ErrorMessage = "No se permiten números")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [RegularExpression("[a-z A-Z,ñ,Ñ,í,ó,á,é,ú,Í,Ó,Á,É,Ú,ü,Ü,. ]*", ErrorMessage = "No se permiten números")]
        public string PrimerApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [RegularExpression("[a-z A-Z,ñ,Ñ,í,ó,á,é,ú,Í,Ó,Á,É,Ú,ü,Ü,. ]*", ErrorMessage = "No se permiten números")]
        public string SegundoApellido { get; set; }

     
        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public bool Activo { get; set; }
        [Display(Name = "# Expediente Laboral")]
        public string NoExpedienteLaboral { get; set; }

        public virtual ICollection<TrabajadorArea> TrabajadorArea { get; set; }

        public Trabajador()
        {
            this.TrabajadorArea = new HashSet<TrabajadorArea>();
        }

        [NotMapped]
        public string NombreCompleto
        {
            get { return Nombres + " " + PrimerApellido + " " + SegundoApellido; }
        }
    }
}

