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
using Guna.UI2.WinForms;

namespace CapaPresentacion
{
    public partial class FormMoldeCrud : Form
    {
        // Variables para almacenar la posición relativa del ratón en el panel
        private bool isDragging = false;
        private Point initialMousePosition;
        public Asignatura asignatura1;
        public FormMoldeCrud()
        {
            InitializeComponent();
            btnCrear.Text = "Crear";
            lblAccionAsignatura.Text = "Crear asignatura";
            lbAdvertencia.Visible = false;

        }
        public FormMoldeCrud(Asignatura asignatura)
        {
            InitializeComponent();
            btnCrear.Text = "Guardar";
            lblAccionAsignatura.Text = "Editar asignatura";
            lbAdvertencia.Visible = false;
            tbNombre.Text = asignatura.Nombre;
            tbCodigo.Text = asignatura.Codigo;
            tbNivel.Text = Convert.ToString(asignatura.Nivel);
            asignatura1 = asignatura;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<Guna2TextBox> listaTextBoxes = new List<Guna2TextBox>
        {
            tbCodigo,
            tbNombre,
            tbNivel
        };
            if (btnCrear.Text.Equals("Crear"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {
                    // 3. Verificar si está vacío o nulo
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        // Cambiar color del borde a rojo
                        txt.BorderColor = Color.Red;
                        camposCompletos = false;
                    }
                    else
                    {

                    }
                }
                if (camposCompletos)
                {
                    Asignatura asignatura = new Asignatura();
                    asignatura.Codigo = tbCodigo.Text;
                    asignatura.Nombre = tbNombre.Text;
                    asignatura.Nivel = Convert.ToInt32(tbNivel.Text);

                    //Temporal
                    asignatura1 = asignatura;

                    // Metodo de la capa de negocio para guardar la asignatura creada
                    
                    this.Close();
                }
                else 
                {
                    lbAdvertencia.Visible = true;
                }



            } else if (btnCrear.Text.Equals("Guardar"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {
                    // 3. Verificar si está vacío o nulo
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        // Cambiar color del borde a rojo
                        txt.BorderColor = Color.Red;
                        camposCompletos = false;
                    }
                    else
                    {

                    }
                }
                if (camposCompletos)
                {
                    Asignatura asignatura = asignatura1;        
                    asignatura.Codigo = tbCodigo.Text;
                    asignatura.Nombre = tbNombre.Text;
                    asignatura.Nivel = Convert.ToInt32(tbNivel.Text);

                    // Metodo de la capa de negocio para guardar la asignatura editada

                    this.Close();
                }
                else
                {
                    lbAdvertencia.Visible = true;
                }

            }
        }

        private void tbCodigo_Enter(object sender, EventArgs e)
        {
            tbCodigo.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbNombre_Enter(object sender, EventArgs e)
        {
            tbNombre.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbNivel_Enter(object sender, EventArgs e)
        {
            tbNivel.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Si no es dígito ni tecla de retroceso (Backspace), se descarta.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // No se procesa esa tecla
                return;
            }

            // 2. Si es un dígito pero es '0', se descarta (no se permite insertar cero).
            if (e.KeyChar == '0')
            {
                e.Handled = true; // No se procesa el cero
                return;
            }

            // 3. Si es un dígito pero ya hay un carácter (o más) en el textbox, no permite más.
            //    (así solo tendrías 1 dígito máximo)
            if (char.IsDigit(e.KeyChar) && tbNivel.Text.Length >= 1)
            {
                e.Handled = true; // Descartar
            }
        }


        private void guna2CustomGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                // Guarda la posición inicial del ratón
                initialMousePosition = e.Location;
            }
        }

        private void guna2CustomGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula la diferencia entre la posición actual y la inicial
                Point currentMousePosition = e.Location;
                int deltaX = currentMousePosition.X - initialMousePosition.X;
                int deltaY = currentMousePosition.Y - initialMousePosition.Y;

                // Mueve el formulario
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

        private void tbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y números
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)8) // (char)8 es el código de la tecla 'Backspace'
            {
                e.Handled = true; // Cancela la tecla no permitida
            }
            else
            {
                string text = tbCodigo.Text;
                int letterCount = text.Count(char.IsLetter);
                int numberCount = text.Count(char.IsDigit);

                // Permitir hasta 4 letras y 3 números
                if (char.IsLetter(e.KeyChar) && letterCount >= 4)
                {
                    e.Handled = true; // No permitir más de 4 letras
                }
                else if (char.IsDigit(e.KeyChar) && numberCount >= 3)
                {
                    e.Handled = true; // No permitir más de 3 números
                }
            }
        }

    }
}
