using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.CRUD;
using CapaPresentacion.MenuOpciones;
using Guna;
using Guna.UI2.WinForms;

namespace CapaPresentacion
{
    public partial class Menuu : Form
    {
        // Variables para almacenar la posición relativa del ratón en el panel
        private bool isDragging = false;
        private Point initialMousePosition;
        private Usuario usuario;
        Form1 formLogin;
        Carrera carrera;

        bool sidebarExpanded;
        public Menuu()
        {
            InitializeComponent();

        }
        public Menuu(Form1 login, Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            formLogin = login;
        }

        private void Menuu_Load(object sender, EventArgs e)
        {
            panelOpciones.Visible = false;
            container(new Bienvenido());
            ConfigurarToolTip(); // Configura el ToolTip del botón
            CarreraNeg carreraNeg = new CarreraNeg();
            if (usuario != null)
            {
                carrera = carreraNeg.ObtenerCarreraPorUsuario(usuario.id);
            }
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
            container(new FormAsignatura(carrera));
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
            container(new FormResultadosAprendizajeAsignatura(carrera));

        }

        private void btnEurase_Click(object sender, EventArgs e)
        {
            container(new FormObjetivoEurace());
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

        private void panelEPN_MouseEnter(object sender, EventArgs e)
        {
            panelEPN.FillColor = Color.FromArgb(241, 90, 109);
        }

        private void panelEPN_MouseLeave(object sender, EventArgs e)
        {
            panelEPN.FillColor = Color.FromArgb(33, 40, 58);

        }

        private void ConfigurarToolTip()
        {
            // Configurar el texto del ToolTip para el botón
            ToolTip1.SetToolTip(btnRAAxPE, "RELACIÓN ENTRE LOS RESULTADOS DEL APRENDIZAJE DE LA ASIGNATURA Y EL PERFIL DE EGRESO");
            ToolTip1.SetToolTip(btnRAxOP, "RELACIÓN ENTRE LOS RESULTADOS DEL APRENDIZAJE Y OBJETIVOS DE PROGRAMA");
            ToolTip1.SetToolTip(btnRAA, "RESULTADOS DEL APRENDIZAJE DE LA ASIGNATURA");

        }

        private void btnRAAxPE_Click(object sender, EventArgs e)
        {
            container(new FormRelaciónRresultadosAprendizajeAsignatura_x_PerfilEgreso());

        }

        private void btnRA_Click(object sender, EventArgs e)
        {
            container(new FormResultadosAprendizaje(carrera));
        }
        bool menuExpand = false;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 165)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 53)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }

            }
        }

        private void btnOC_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void btnOP_Click(object sender, EventArgs e)
        {
            container(new FormObjetivosPrograma(carrera));

        }

        private void btnRAxOP_Click(object sender, EventArgs e)
        {
            container(new FormPerfilEgreso_x_ObjetivosEurase(carrera));

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            container(new FormEditarUsuario(usuario, carrera));

        }
    }
}
