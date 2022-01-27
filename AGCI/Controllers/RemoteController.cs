using System.Linq;
using System.Web.Mvc;

using AGCI.Models;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class RemoteController : Controller
    {
        private AGCIContext db = new AGCIContext();
       


        public JsonResult CiTrabajador(string ci, string id)
        {

            if (id != "undefined")
            {
                int actualId = int.Parse(id);
                if (db.Trabajadores.Any(t => t.Ci == ci && t.Id == actualId))
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            if (db.Trabajadores.Any(t=>t.Ci == ci))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


    

       


       


	}
}