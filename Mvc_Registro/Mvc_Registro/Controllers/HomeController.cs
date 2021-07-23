using System.Web.Mvc;
using Mvc_Registro.Models;

namespace Mvc_Registro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario _usuario)
        {
            if (ModelState.IsValid)
            {
                using (CadastroEntities dc = new CadastroEntities())
                {
                    //verifica duplicidade
                    if (!UsuarioDAL.VerificaEmail(_usuario.Email))
                    {
                        dc.Usuarios.Add(_usuario);
                        dc.SaveChanges();
                        ModelState.Clear();
                        _usuario = null;
                        ViewBag.Message = "Usuário registrado com sucesso.";
                    }
                    else
                    {
                        ViewBag.Message = "Email já cadastrado.";
                    }
                }
            }
            return View(_usuario);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Macoratti .net";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Macoratti .net";

            return View();
        }
    }
}