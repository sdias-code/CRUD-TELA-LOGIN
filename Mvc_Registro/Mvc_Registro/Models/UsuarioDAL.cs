using System.Linq;

namespace Mvc_Registro.Models
{
    public class UsuarioDAL
    {
        public static bool VerificaEmail(string email)
        {
            using (CadastroEntities dc = new CadastroEntities())
            {
                var existeEmail = (from u in dc.Usuarios
                                   where u.Email == email
                                   select u).FirstOrDefault();

                if (existeEmail != null)
                    return true;
                else
                    return false;
            }
        }
    }
}