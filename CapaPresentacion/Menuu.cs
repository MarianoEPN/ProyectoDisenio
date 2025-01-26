using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.CRUD;
using CapaPresentacion.MenuOpciones;
using Guna;

namespace CapaPresentacion
{
    public partial class Menuu : Form
    {
        // Variables para almacenar la posición relativa del ratón en el panel
        private bool isDragging = false;
        private Point initialMousePosition;

        bool sidebarExpanded;
        public Menuu()
        {
            InitializeComponent();

        }
        public Menuu(Form1 login)
        {
            InitializeComponent();
        }

        private void Menuu_Load(object sender, EventArgs e)
        {
            panelOpciones.Visible = false;
            container(new Bienvenido());

        }

        private void timerExpanded_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                panelBarra.Width -= 10;
                if (panelBarra.Width == panelBarra.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    timerExpanded.Stop();
                }
            }
            else 
            {
                panelBarra.Width += 10;
                if (panelBarra.Width == panelBarra.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    timerExpanded.Stop();
                }

            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerExpanded.Start();
        }

        private void container(object _form)
        {
            if (panelContainer.Controls.Count > 0) panelContainer.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(fm);
            panelContainer.Tag = fm;
            fm.Show(); 
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            container(new Bienvenido());
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if
                (!panelOpciones.Visible)
            {
                panelOpciones.Visible = true;
                btnBajar.BackgroundImage = Properties.Resources.up__2_;
            }

            else
            {
                panelOpciones.Visible = false;
                btnBajar.BackgroundImage = Properties.Resources.baja;

            }
        }

        private void panelControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAsigatura_Click(object sender, EventArgs e)
        {
            container(new FormAsignatura());
        }

        private void plBarra_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void plBarra_MouseMove(object sender, MouseEventArgs e)
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

        private void plBarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                // Guarda la posición inicial del ratón
                initialMousePosition = e.Location;
            }
        }

        private void btnRAA_Click(object sender, EventArgs e)
        {
            container(new FormResultadosAprendizaje());
        }

        private void btnEurase_Click(object sender, EventArgs e)
        {
            container(new FormObjetivosAprendizajeAsignatura());

        }
    }
}
