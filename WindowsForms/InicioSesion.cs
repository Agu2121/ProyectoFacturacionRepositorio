using BibliotecaClases;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            // Validar usuario
            bool esValido = usuario.ValidarUsuario(txtNombreUsuario.Text, txtContraseña.Text);

            if (esValido)
            {
                // Establecer el DialogResult en OK para indicar que la autenticación fue exitosa.
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario de inicio de sesión y se abrirá el formulario de facturación (Programado en el main de Program.cs)
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
