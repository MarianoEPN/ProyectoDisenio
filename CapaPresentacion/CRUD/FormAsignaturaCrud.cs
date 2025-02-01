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

namespace CapaPresentacion.CRUD
{
    public partial class FormAsignaturaCrud : Form
    {    // Variables para almacenar la posición relativa del ratón en el panel
        private bool isDragging = false;
        private Point initialMousePosition;
        private Carrera carrera;
        private Asignatura asignatura;
        public FormAsignaturaCrud()
        {
            InitializeComponent();
            btnCrear.Text = "Crear";
            lbAdvertencia.Visible = false;
            lblAccionAsignatura.Text = "Crear asignatura";
        }
        public FormAsignaturaCrud(Carrera carrera)
        {
            InitializeComponent();
            btnCrear.Text = "Crear";
            lbAdvertencia.Visible = false;
            lblAccionAsignatura.Text = "Crear asignatura";
            this.carrera = carrera;
        }

        public FormAsignaturaCrud(Asignatura asignatura)
        {
            InitializeComponent();
            btnCrear.Text = "Guardar";
            lbAdvertencia.Visible = false;
            tbNombre.Text = asignatura.Nombre;
            tbCodigo.Text = asignatura.Codigo;
            tbNivel.Text = Convert.ToString(asignatura.Nivel);
            this.asignatura = asignatura;
            lblAccionAsignatura.Text = "Editar asignatura";
        }



        private void btnCancelar_Click(object sender, EventArgs e)
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
                        txt.BorderColor = Color.FromArgb(241, 90, 109);
                        camposCompletos = false;
                    }
                    else
                    {

                    }
                }
                
                if (camposCompletos)
                {
                    if (tbCodigo.Text.Length != 7)
                    {
                        lbAdvertencia.Text = "El codigo debe contener 7 caracteres.";
                        lbAdvertencia.Visible = true;
                        return;
                    }

                    Asignatura asignatura = new Asignatura();
                    asignatura.Codigo = tbCodigo.Text;
                    asignatura.Nombre = tbNombre.Text;
                    asignatura.Nivel = Convert.ToInt32(tbNivel.Text);
                    AsignaturaNeg asignaturaNeg = new AsignaturaNeg();
                    asignaturaNeg.InsertarAsignatura(asignatura, carrera);
                    this.Close();
                }
                else
                {
                    lbAdvertencia.Text = "Debe completar todos los campos.";
                    lbAdvertencia.Visible = true;
                }



            }
            else if (btnCrear.Text.Equals("Guardar"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {

                    if (string.IsNullOrEmpty(txt.Text))
                    {

                        txt.BorderColor = Color.FromArgb(241, 90, 109);
                        camposCompletos = false;
                    }
                    else
                    {

                    }
                }

                if (camposCompletos)
                {
                    if (tbCodigo.Text.Length != 7)
                    {
                        lbAdvertencia.Text = "El codigo debe contener 7 caracteres.";
                        lbAdvertencia.Visible = true;
                        return;
                    }
                    Asignatura asignaturaEditar = asignatura;
                    asignaturaEditar.Codigo = tbCodigo.Text;
                    asignaturaEditar.Nombre = tbNombre.Text;
                    asignaturaEditar.Nivel = Convert.ToInt32(tbNivel.Text);
                    AsignaturaNeg asignaturaNeg = new AsignaturaNeg();
                    asignaturaNeg.ActualizarAsignatura(asignaturaEditar);
                    this.Close();
                }
                else
                {
                    lbAdvertencia.Text = "Debe completar todos los campos.";
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

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            // Obtiene la posición actual del cursor
            int selectionStart = tbCodigo.SelectionStart;

            // Remueve los espacios y convierte a mayúsculas
            string nuevoTexto = tbCodigo.Text.Replace(" ", "").ToUpper();

            // Solo actualiza si hay cambios para evitar reejecuciones innecesarias
            if (tbCodigo.Text != nuevoTexto)
            {
                tbCodigo.Text = nuevoTexto;

                // Restaura la posición del cursor evitando problemas al escribir
                tbCodigo.SelectionStart = selectionStart > tbCodigo.Text.Length ? tbCodigo.Text.Length : selectionStart;
            }
        }


        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnClose.IconColor = Color.White;

        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.CircleWithe;
            btnClose.IconColor = Color.DimGray;

        }



        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnMin.IconColor = Color.White;

        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = Properties.Resources.CircleWithe;
            btnMin.IconColor = Color.DimGray;

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

        private void tbNivel_TextChanged(object sender, EventArgs e)
        {
            // Si el usuario ingresó más de un carácter, mantener solo el primero
            if (tbNivel.Text.Length > 1)
            {
                tbNivel.Text = tbNivel.Text.Substring(0, 1);
            }

            // Verificar que el único carácter permitido sea un número entre 1 y 9
            if (tbNivel.Text.Length == 1 && (tbNivel.Text[0] < '1' || tbNivel.Text[0] > '9'))
            {
                tbNivel.Text = ""; // Borra si el valor ingresado no está en el rango permitido
            }

            // Mueve el cursor al final del texto
            tbNivel.SelectionStart = tbNivel.Text.Length;
        }
        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbNombre.SelectionStart;

            // Filtra solo letras y espacios, y convierte a mayúsculas
            string nuevoTexto = new string(tbNombre.Text.Where(c => char.IsLetter(c) || c == ' ').ToArray()).ToUpper();

            // Si el texto cambió, actualízalo
            if (tbNombre.Text != nuevoTexto)
            {
                tbNombre.Text = nuevoTexto;
                tbNombre.SelectionStart = selectionStart > tbNombre.Text.Length ? tbNombre.Text.Length : selectionStart;
            }
        }

    }
}
