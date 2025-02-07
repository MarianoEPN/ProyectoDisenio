using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using Guna.UI2.WinForms;

namespace CapaPresentacion.MenuOpciones
{
    public partial class FormEditarUsuario : Form
    {
        private Usuario usuario;
        private Carrera carrera;
        public FormEditarUsuario()
        {
            InitializeComponent();
        }

        public FormEditarUsuario(Usuario usuario, Carrera carrera)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.carrera = carrera;
            tbNombreReg.Text = usuario.nombre;
            tbUsuarioReg.Text = usuario.Username;
            tbCorreo.Text = usuario.Correo;
            tbClaveReg.Text = usuario.Clave;
            tbClaveConfirmReg.Text = usuario.Clave;
            lblCarrera.Text = carrera.Nombre;
            tbPensum.Text = carrera.Pensum;
            tbPensum.Enabled = false;
            lblUsername.Text = usuario.Username;
            lblCorreo.Text = usuario.Correo;
            lbAdvertencia.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Guna2TextBox> listaTextBoxes = new List<Guna2TextBox>
    {
        tbNombreReg,
        tbUsuarioReg,
        tbCorreo,
        tbClaveReg,
        tbClaveConfirmReg
    };

            bool camposCompletos = true;
            foreach (var txt in listaTextBoxes)
            {
                // Verificar si está vacío o nulo
                if (string.IsNullOrEmpty(txt.Text))
                {
                    // Cambiar color del borde a rojo
                    txt.BorderColor = Color.FromArgb(241, 90, 109);
                    camposCompletos = false;
                }
            }

            if (camposCompletos)
            {
                if (tbClaveReg.Text.Equals(tbClaveConfirmReg.Text))
                {
                    usuario.nombre = tbNombreReg.Text;
                    usuario.Username = tbUsuarioReg.Text;
                    usuario.Correo = tbCorreo.Text;
                    usuario.Clave = tbClaveReg.Text;
                    int id = usuario.id;
                    UsuarioNeg usuarioNeg = new UsuarioNeg();
                    usuarioNeg.ActualizarUsuario(usuario, carrera);

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Se ha guardado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lbAdvertencia.Text = "Deben de coincidir las contraseñas.";
                    lbAdvertencia.Visible = true;
                }
            }
            else
            {
                lbAdvertencia.Text = "Debe completar todos los campos.";
                lbAdvertencia.Visible = true;
            }
        }

        private void pbVista2_Click(object sender, EventArgs e)
        {
            if (tbClaveReg.PasswordChar == '*')
            {
                tbClaveReg.PasswordChar = '\0'; // Muestra el texto real.
                pbVista2.Image = Properties.Resources.cerradura2; // Cambia a imagen "ojo abierto".
            }
            else
            {
                tbClaveReg.PasswordChar = '*'; // Oculta la contraseña.
                pbVista2.Image = Properties.Resources.cerradura1; // Cambia a imagen "ojo cerrado".
            }
        }

        private void pbVista3_Click(object sender, EventArgs e)
        {
            if (tbClaveConfirmReg.PasswordChar == '*')
            {
                tbClaveConfirmReg.PasswordChar = '\0'; // Muestra el texto real.
                pbVista3.Image = Properties.Resources.cerradura2; // Cambia a imagen "ojo abierto".
            }
            else
            {
                tbClaveConfirmReg.PasswordChar = '*'; // Oculta la contraseña.
                pbVista3.Image = Properties.Resources.cerradura1; // Cambia a imagen "ojo cerrado".
            }
        }
    }
}
