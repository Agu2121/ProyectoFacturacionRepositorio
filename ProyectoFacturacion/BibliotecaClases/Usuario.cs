using BibliotecaClases_BD;
using System;
using System.Data.SqlClient;

namespace BibliotecaClases
{
    public class Usuario
    {
        // Atributos
        private int _id;
        private string _nombreUsuario;
        private string _contraseña;

        // Propiedades
        public int IdUsuario
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        // Método para validar usuario usando la conexión proporcionada
        public bool ValidarUsuario(string nombreUsuario, string contraseña)
        {
            bool esValido = false;

            // Usar la clase Conexion para obtener una conexión a la base de datos
            using (SqlConnection miConexion = Conexion.ObtenerConexion())
            {
                try
                {
                    miConexion.Open();

                    // Consulta SQL para verificar si existe un usuario con el nombre y contraseña ingresados
                    // "COLLATE Latin1_General_CS_AS" se usa para hacer la comparación sensible a mayúsculas y minúsculas
                    string consulta = "SELECT COUNT(1) FROM Usuario" +
                        " WHERE NombreUsuario = @NombreUsuario COLLATE Latin1_General_CS_AS " +
                        "AND Contraseña = @Contraseña COLLATE Latin1_General_CS_AS";

                    // Crear un comando SQL para ejecutar la consulta anterior
                    using (SqlCommand comando = new SqlCommand(consulta, miConexion))
                    {
                        // Agregar los parámetros a la consulta
                        // Se asigna el nombre de usuario y la contraseña ingresados por el usuario
                        comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", contraseña);

                        // Ejecutar la consulta y obtener el resultado
                        // La consulta devuelve un número que indica si existe (1) o no (0) un usuario con esas credenciales
                        int count = Convert.ToInt32(comando.ExecuteScalar());

                        // Si el resultado es 1, las credenciales son correctas y válido pasa de false a true
                        esValido = count == 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al validar usuario: " + ex.Message);
                }
            }
            // Devolver si las credenciales del usuario son válidas (true) o no (false)
            return esValido;
        }
    }
}
