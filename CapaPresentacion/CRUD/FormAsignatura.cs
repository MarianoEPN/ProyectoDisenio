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
    public partial class FormAsignatura : Form
    {
        public FormAsignatura()
        {
            InitializeComponent();
        }

        private void FormAsignatura_Load(object sender, EventArgs e)
        {
            MessageBox.Show("HOLA");
            guna2TextBox1.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
