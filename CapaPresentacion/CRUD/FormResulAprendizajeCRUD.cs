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
using CapaNegocio;

namespace CapaPresentacion.CRUD
{
    public partial class FormResulAprendizajeCRUD : Form
    {
        private bool isDragging = false;
        private Point initialMousePosition;
        private ResultadoAprendizaje resultadoAprendizaje;
        private Carrera carrera;
        public FormResulAprendizajeCRUD()
        {
            InitializeComponent();
            btnGuardarRA.Text = "Crear";
            lbAdvertenciaRA.Visible = false;
            lblUniversidadRA.Text = "Crear Resulado Aprendizaje";
        }
        public FormResulAprendizajeCRUD(Carrera carrera)
        {
            InitializeComponent();
            btnGuardarRA.Text = "Crear";
            lbAdvertenciaRA.Visible = false;
            lblUniversidadRA.Text = "Crear Resulado Aprendizaje";
            this.carrera = carrera;
            tbNombreRA.Text = carrera.Nombre; // Preconfigura el nombre de la carrera
            tbNombreRA.ReadOnly = true;       // El usuario no puede modificar este campo
        }

        public FormResulAprendizajeCRUD(ResultadoAprendizaje resultadoAprendizaje, Carrera carrera)
        {
            InitializeComponent();
            btnGuardarRA.Text = "Guardar";
            lbAdvertenciaRA.Visible = false;
            tbDescripcionRA.Text = resultadoAprendizaje.Descripcion;
            tbCodigoRA.Text = resultadoAprendizaje.Codigo;
            this.resultadoAprendizaje= resultadoAprendizaje;
            lblUniversidadRA.Text = "Editar Resulado Aprendizaje";
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

            if (btnGuardarRA.Text.Equals("Crear"))
            {
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

                    ResultadoAprendizaje resultadoAprendizaje = new ResultadoAprendizaje();
                    resultadoAprendizaje.Codigo = tbCodigoRA.Text;
                    resultadoAprendizaje.Descripcion = tbDescripcionRA.Text;
                    ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
                    resultadoAprendizajeNeg.InsertarResultadoAprendizaje(resultadoAprendizaje, carrera);
                    this.Close();
                    // Lógica para guardar el nuevo objetivo en la base de datos o lista
                    MessageBox.Show("El Resultado de Apredeizaje fue ingresado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    lbAdvertenciaRA.Visible = true; // Muestra la advertencia
                }
            }
            else if (btnGuardarRA.Text.Equals("Guardar"))
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

                    if (camposCompletos)
                    {
                        ResultadoAprendizaje resultadoAprendizajeEditar = resultadoAprendizaje;
                        resultadoAprendizajeEditar.Codigo = tbCodigoRA.Text;
                        resultadoAprendizajeEditar.Descripcion = tbDescripcionRA.Text;
                        ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
                        resultadoAprendizajeNeg.ActualizarResultadoAprendizaje(resultadoAprendizajeEditar);
                        this.Close();
                    }
                    else
                    {
                        lbAdvertenciaRA.Text = "Debe completar todos los campos.";
                        lbAdvertenciaRA.Visible = true;
                    }
                }




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

        private void tbNombreRA_TextChanged(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbNombreRA.SelectionStart;

            // Filtra solo letras y espacios, y convierte a mayúsculas
            string nuevoTexto = new string(tbNombreRA.Text.Where(c => char.IsLetter(c) || c == ' ').ToArray()).ToUpper();

            // Si el texto cambió, actualízalo
            if (tbNombreRA.Text != nuevoTexto)
            {
                tbNombreRA.Text = nuevoTexto;
                tbNombreRA.SelectionStart = selectionStart > tbNombreRA.Text.Length ? tbNombreRA.Text.Length : selectionStart;
            }
        }

        private void tbCodigoRA_TextChanged_1(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbCodigoRA.SelectionStart;

            // Filtra solo letras y números, y convierte a mayúsculas (sin espacios)
            string nuevoTexto = new string(tbCodigoRA.Text.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToUpper();

            // Si el texto cambió, actualízalo
            if (tbCodigoRA.Text != nuevoTexto)
            {
                tbCodigoRA.Text = nuevoTexto;
                tbCodigoRA.SelectionStart = selectionStart > tbCodigoRA.Text.Length ? tbCodigoRA.Text.Length : selectionStart;
            }
        }

    }
}
