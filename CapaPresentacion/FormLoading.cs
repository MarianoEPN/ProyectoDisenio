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

namespace CapaPresentacion
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value == 100)
            {
                timer1.Stop();

                // Abrir el menú y cerrar este formulario
                Menuu menu = new Menuu();
                menu.FormClosed += FormLoading_FormClosed; // Asegura el cierre completo
                menu.Show();
                this.Hide();
            }
            else
            {
                guna2CircleProgressBar1.Value += 1;
                label_val.Text = (Convert.ToInt32(label_val.Text) + 1).ToString();
            }
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }

        private void FormLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Cierra la aplicación por completo

        }
    }
}
