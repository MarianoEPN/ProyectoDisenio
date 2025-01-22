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
using Guna;

namespace CapaPresentacion
{
    public partial class Menuu : Form
    {
        bool sidebarExpanded;
        public Menuu()
        {
            InitializeComponent();

        }

        private void Menuu_Load(object sender, EventArgs e)
        {
            panelOpciones.Visible = false;

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
            lblTitulo.Text = "Home";
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
            container(new Asignatura());
        }
    }
}
