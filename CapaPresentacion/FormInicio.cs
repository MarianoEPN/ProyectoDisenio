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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
            timer1.Enabled = true; // Habilitar el temporizador

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); // Detener el temporizador
            this.Close();  // Cerrar el Splash Screen
        }
    }
}
