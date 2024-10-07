using BibliotecaClases;
using BibliotecaClases_BD;
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
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Contraseña = txtContraseña.Text;

            // Validar usuario
            bool comprobacion = usuario.ValidarUsuario(usuario.NombreUsuario, usuario.Contraseña);

            if (comprobacion)
            {
                Facturacion facturacion = new Facturacion();
                facturacion.Show();
                Hide();
                
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
    }
}
