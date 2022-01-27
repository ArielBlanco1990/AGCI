using AGCI.Models;
using AGCI.AuxClasses;


namespace AGCI.ViewModels
{
    public class AreaViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string UnidadOrganizativa { get; set; }

        

       

        public AreaViewModel(Area area)
        {
            Id = area.Id;
            Nombre = area.Nombre;
            UnidadOrganizativa = area.UnidadOrganizativa.Nombre;
        }
    }
}