using BibliotecaClases_BD;
using System;
using System.Data.SqlClient;

namespace BibliotecaClases
{
    public class Usuario
    {
        // Método para validar usuario
        public bool ValidarUsuario(string nombreUsuario, string contraseña)
        {
            using (SqlConnection miConexion = Conexion.ObtenerConexion())
            {
                miConexion.Open();
                string consulta = "SELECT COUNT(1) FROM Usuario WHERE NombreUsuario = @NombreUsuario COLLATE Latin1_General_CS_AS AND Contraseña = @Contraseña COLLATE Latin1_General_CS_AS";

                using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                {
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    return Convert.ToInt32(comando.ExecuteScalar()) == 1;
                }
            }
        }
    }
}
