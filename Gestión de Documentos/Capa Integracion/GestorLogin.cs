using Manejo_registros.Capa_Logica.LogicaServicios;
using Manejo_registros.Capa_Logica.LogicaNegocio;
using Manejo_registros.CapaConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Integracion
{
    public class GestorLogin : servicio, IDisposable
    {
        public GestorLogin()
        {

        }
        public void Dispose()
        {

        }
        public string LoginInsertar(string login_usuario, string login_contraseña, string login_correoElectronico, string login_administrador, string login_estado)
        {
            Login nuevo = new Login( login_usuario, login_contraseña, login_correoElectronico, login_administrador, login_estado);

            using (ServicioLogin servicioCL = new ServicioLogin())
                return servicioCL.LoginInsertar(nuevo);
        }

        public string LoginModificar(int login_id, string login_usuario, string login_contraseña, string login_correoElectronico, string login_administrador, string login_estado)
        {
            Login modificar = new Login(login_id, login_usuario, login_contraseña, login_correoElectronico, login_administrador, login_estado);

            using (ServicioLogin servicioCL = new ServicioLogin())
                return servicioCL.LoginModificar(modificar);
        }

        public object LoginListarA()
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
                return servicioCL.LoginListarA();
        }
        public object LoginListarI()
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
                return servicioCL.LoginListarI();
        }
        public DataSet LoginConsultar(int login_id)
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
            {
                return servicioCL.LoginConsultar(login_id);
            }
        }
        public DataSet LoginActivar(int login_id)
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
            {
                return servicioCL.LoginActivar(login_id);
            }
        }
        public DataSet LoginInactivar(int login_id)
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
            {
                return servicioCL.LoginInactivar(login_id);
            }
        }
        public DataSet LoginConsuLoginConsultarUsuarioltar(string Login_Usuario)
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
            {
                return servicioCL.LoginConsultarUsuario(Login_Usuario);
            }
        }

        public DataSet LoginConsultarCorreo(string Login_correoElectronico)
        {
            using (ServicioLogin servicioCL = new ServicioLogin())
            {
                return servicioCL.LoginConsultarCorreo(Login_correoElectronico);
            }
        }

    }
}
