using System;
using System.ComponentModel.DataAnnotations;

namespace AGCI.AuxClasses
{
    public class ValidarCi : ValidationAttribute
    {
        public ValidarCi()
            : base("El {0} no es correcto")
        {

        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, name);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string ci = value.ToString();
                var año = int.Parse(ci.Substring(0, 2));
                var mes = int.Parse(ci.Substring(2, 2));
                var dia = int.Parse(ci.Substring(4, 2));
                try
                {
                    var fechaN = new DateTime(año, mes, dia);
                }
                catch (Exception)
                {
                    var mensaje = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensaje);
                }
            }
            return null;
        }
    }
}