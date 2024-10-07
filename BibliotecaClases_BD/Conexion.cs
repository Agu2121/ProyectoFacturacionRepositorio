using System.Data.SqlClient;

namespace BibliotecaClases_BD
{
    public class Conexion
    {
        // Cadena de conexión privada y de solo lectura
        private static readonly string _cadenaConexion = @"Data Source=LAPTOP-77UIDF0J\SQLEXPRESS;Initial Catalog=FacturacionBD;Integrated Security=True;Encrypt=False";

        // Es una propiedad estática que permite acceder a la cadena de conexión desde cualquier clase
        // sin tener que crear una nueva instancia de la clase Conexion.
        public static string CadenaConexion
        {
            get { return _cadenaConexion; }
        }

        // Este método devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión definida.
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
