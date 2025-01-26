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

namespace CapaPresentacion.CRUD
{
    public partial class FormObjetivoEuraceCrud : Form
    {
        private bool isDragging = false;
        private Point initialMousePosition;
        private ObjetivoEurace objetivoEditar;

        public FormObjetivoEuraceCrud()
        {
            InitializeComponent();
            lbAdvertencia.Visible = false;
            lblAccionAsignatura.Text = "Crear \n Objetivo EUR-ACE";
        }

        public FormObjetivoEuraceCrud(ObjetivoEurace objetivoEurace)
        {
            InitializeComponent();
            lbAdvertencia.Visible = false;
            //tbCodigo.Text = objetivoEurace.Codigo;
            //tbNombre.Text = objetivoEurace.Nombre;
            //tbDescripcion.Text = objetivoEurace.Descripcion;
            objetivoEditar = objetivoEurace;
            lblAccionAsignatura.Text = "Editar \n Objetivo EUR-ACE";
        }

        private void FormObjetivoEuraceCrud_Load(object sender, EventArgs e)
        {

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
                tbDescripcion
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
                    ObjetivoEurace objetivo = new ObjetivoEurace();
                    //objetivo.Codigo = tbCodigo.Text;
                    //objetivo.Nombre = tbNombre.Text;
                    //objetivo.Descripcion = tbDescripcion.Text;

                    // Metodo de la capa de negocio para guardar la asignatura creada

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
                    ObjetivoEurace objetivo = new ObjetivoEurace();
                    //objetivo.Codigo = tbCodigo.Text;
                    //objetivo.Nombre = tbNombre.Text;
                    //objetivo.Descripcion = tbDescripcion.Text;

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

        private void tbDescripcion_Enter(object sender, EventArgs e)
        {
            tbDescripcion.BorderColor = Color.FromArgb(213, 218, 223);
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

        private void btnMax_MouseEnter(object sender, EventArgs e)
        {
            btnMax.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnMax.IconColor = Color.White;
        }

        private void btnMax_MouseLeave(object sender, EventArgs e)
        {
            btnMax.BackgroundImage = Properties.Resources.CircleWithe;
            btnMax.IconColor = Color.DimGray;
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
    }
}
