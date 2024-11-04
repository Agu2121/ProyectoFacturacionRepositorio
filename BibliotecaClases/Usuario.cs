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
                // Consulta SQL que cuenta cuántos registros coinciden con el nombre de usuario y la contraseña proporcionados
                // 'COLLATE Latin1_General_CS_AS' asegura que la comparación sea sensible a mayúsculas y minúsculas
                string consulta = "SELECT COUNT(1) FROM Usuario WHERE NombreUsuario = @NombreUsuario COLLATE Latin1_General_CS_AS AND Contraseña = @Contraseña COLLATE Latin1_General_CS_AS";

                using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                {
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    // Ejecuta la consulta y convierte el resultado en un número entero
                    // Si el resultado es 1, significa que encontró una coincidencia exacta en la base de datos
                    return Convert.ToInt32(comando.ExecuteScalar()) == 1;
                }
            }
        }
    }
}
