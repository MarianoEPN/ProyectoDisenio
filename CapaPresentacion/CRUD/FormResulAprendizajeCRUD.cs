using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace CapaPresentacion.CRUD
{
    public partial class FormResulAprendizajeCRUD : Form
    {
        private bool isDragging = false;
        private Point initialMousePosition;
        public FormResulAprendizajeCRUD()
        {
            InitializeComponent();
        }
        public FormResulAprendizajeCRUD(Carrera carrera)
        {
            InitializeComponent();
            lbAdvertenciaRA.Visible = false;
            tbNombreRA.Text = carrera.Nombre; // Preconfigura el nombre de la carrera
            tbNombreRA.ReadOnly = true;       // El usuario no puede modificar este campo
        }

        private void btnCancelarRA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarRA_Click(object sender, EventArgs e)
        {
            // Lista de campos obligatorios
            List<Guna2TextBox> listaTextBoxes = new List<Guna2TextBox>
            {
                tbCodigoRA,
                tbDescripcionRA
            };

            bool camposCompletos = true;

            foreach (var txt in listaTextBoxes)
            {
                // Verifica si el campo está vacío
                if (string.IsNullOrEmpty(txt.Text))
                {
                    txt.BorderColor = Color.FromArgb(241, 90, 109); // Resalta el borde en rojo
                    camposCompletos = false;
                }
                else
                {
                    txt.BorderColor = Color.FromArgb(213, 218, 223); // Restaura el color del borde
                }
            }

            // Si todos los campos están completos
            if (camposCompletos)
            {
                lbAdvertenciaRA.Visible = false; // Oculta la advertencia si estaba visible
                // Lógica para guardar el nuevo objetivo en la base de datos o lista
                MessageBox.Show("El objetivo fue ingresado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lbAdvertenciaRA.Visible = true; // Muestra la advertencia
            }
        }
        private void tbCodigoRA_Enter(object sender, EventArgs e)
        {
            tbCodigoRA.BorderColor = Color.FromArgb(213, 218, 223); // Restablece el color del borde
        }

        private void tbDescripcionRA_Enter(object sender, EventArgs e)
        {
            tbDescripcionRA.BorderColor = Color.FromArgb(213, 218, 223); // Restablece el color del borde
        }

        private void tbCodigoRA_TextChanged(object sender, EventArgs e)
        {
            tbCodigoRA.Text = tbCodigoRA.Text.ToUpper(); // Convierte a mayúsculas
            tbCodigoRA.SelectionStart = tbCodigoRA.Text.Length; // Mueve el cursor al final
        }

        private void guna2CustomGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                initialMousePosition = e.Location;
            }
        }

        private void guna2CustomGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.Location;
                int deltaX = currentMousePosition.X - initialMousePosition.X;
                int deltaY = currentMousePosition.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void guna2CustomGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
