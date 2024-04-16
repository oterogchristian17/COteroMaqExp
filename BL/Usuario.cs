using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> GetByUserNamePassword(string username, string password)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Usuario", null } };
            try
            {
                using (DL.CoteroMaquinaExpContext context = new DL.CoteroMaquinaExpContext())
                {
                    var registro = (from usario in context.Usuarios

                                    where usario.UserName == username

                                    select new
                                    {

                                        UserName = usario.UserName,
                                        Password = usario.Password

                                    }).FirstOrDefault();

                    if (registro != null)
                    {
                        ML.Usuario user = new ML.Usuario();

                        user.UserName = registro.UserName;
                        user.Password = registro.Password;

                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = user;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }


    }
}
