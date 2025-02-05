using CapaEntidades;
using CapaNegocio;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.CRUD
{
    public partial class FormObjetivoProgramaCRUD : Form
    {
        private bool isDragging = false;
        private Point initialMousePosition;
        private ObjetivoPrograma objetivoPrograma;
        private Carrera carrera;

        public FormObjetivoProgramaCRUD()
        {
            InitializeComponent();
            lbAdvertencia.Visible = false;
            lblAccionAsignatura.Text = "Crear Objetivo Programa"; 
        }

        public FormObjetivoProgramaCRUD(Carrera carrera)
        {
            InitializeComponent();
            btnCrear.Text = "Crear";
            lbAdvertencia.Visible = false;
            lblAccionAsignatura.Text = "Crear Objetivo Programa";
            this.carrera = carrera;
        }

        public FormObjetivoProgramaCRUD(Carrera carrera, ObjetivoPrograma objetivoPrograma)
        {
            InitializeComponent();
            lbAdvertencia.Visible = false;
            tbCodigo.Text = objetivoPrograma.Codigo;
            tbNombre.Text = objetivoPrograma.Nombre;
            tbFortaleza.Text = objetivoPrograma.Fortalezas;
            tbDebilidad.Text = objetivoPrograma.Debilidades;
            this.objetivoPrograma = objetivoPrograma;
            this.carrera = carrera;
            lblAccionAsignatura.Text = "Editar Objetivo Programa";
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2ShadowPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                // Guarda la posición inicial del ratón
                initialMousePosition = e.Location;
            }
        }

        private void guna2ShadowPanel2_MouseMove(object sender, MouseEventArgs e)
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

        private void guna2ShadowPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<Guna2TextBox> listaTextBoxes = new List<Guna2TextBox>
            {
                tbCodigo,
                tbNombre,
                tbFortaleza,
                tbDebilidad
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
                    ObjetivoPrograma objetivo = new ObjetivoPrograma();
                    objetivo.Codigo = tbCodigo.Text;
                    objetivo.Nombre = tbNombre.Text;
                    objetivo.Debilidades = tbDebilidad.Text;
                    objetivo.Fortalezas = tbFortaleza.Text;

                    // Metodo de la capa de negocio para guardar la asignatura CREADA
                    ObjetivoProgramaNeg objetivoProgramaNeg = new ObjetivoProgramaNeg();
                    objetivoProgramaNeg.InsertarObjetivoPrograma(objetivo, carrera);

                    this.Close();
                }
                else
                {
                    
                    lbAdvertencia.Visible = true;
                }



            }
            else if (btnCrear.Text.Equals("Guardar"))
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
                    ObjetivoPrograma objetivoEditar = objetivoPrograma;
                    objetivoEditar.Codigo = tbCodigo.Text;
                    objetivoEditar.Nombre = tbNombre.Text;
                    objetivoEditar.Fortalezas = tbFortaleza.Text;
                    objetivoEditar.Debilidades = tbDebilidad.Text;

                    // Metodo de la capa de negocio para guardar la asignatura EDITADA
                    ObjetivoProgramaNeg objetivoProgramaNeg = new ObjetivoProgramaNeg();
                    objetivoProgramaNeg.ActualizarObjetivoPrograma(objetivoEditar, carrera);

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

        private void tbFortaleza_Enter(object sender, EventArgs e)
        {
            tbFortaleza.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbDebilidad_Enter(object sender, EventArgs e)
        {
            tbDebilidad.BorderColor = Color.FromArgb(213, 218, 223);
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
        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbCodigo.SelectionStart;

            // Filtra solo los números
            string nuevoTexto = new string(tbCodigo.Text.Where(char.IsDigit).ToArray());

            // Limita la longitud a 3 caracteres
            if (nuevoTexto.Length > 3)
            {
                nuevoTexto = nuevoTexto.Substring(0, 3);
            }

            // Actualiza el texto si ha cambiado
            if (tbCodigo.Text != nuevoTexto)
            {
                tbCodigo.Text = nuevoTexto;
                tbCodigo.SelectionStart = Math.Min(selectionStart, tbCodigo.Text.Length);
            }
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
