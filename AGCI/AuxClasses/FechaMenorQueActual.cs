using System;
using System.ComponentModel.DataAnnotations;

namespace AGCI.AuxClasses
{
    public class FechaMenorQueActual : ValidationAttribute
    {
        public string FechaActual { get; set; }
        public FechaMenorQueActual()
            : base("La {0} debe ser menor o igual que la fecha actual, por favor verifique.")
        {
            FechaActual = "Fecha Actual";
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, name, FechaActual);
        }

        protected override ValidationResult IsValid(object valor, ValidationContext validationContext)
        {
            if (valor != null)
            {
                var estaFecha = (DateTime)valor;
                if (estaFecha > DateTime.Now)
                {
                    var error = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(error);
                }
            }         
            return null;
        }
    }
}