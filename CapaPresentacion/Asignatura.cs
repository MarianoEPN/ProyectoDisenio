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
    public partial class Asignatura : Form
    {
        public Asignatura()
        {
            InitializeComponent();
        }

        private void Asignatura_Load(object sender, EventArgs e)
        {
            dtgAsignatura.Rows.Add(4);
            dtgAsignatura.Rows[0].Cells[2].Value = "Matematicas";
            dtgAsignatura.Rows[0].Cells[3].Value = "suma Resta";

            dtgAsignatura.Rows[1].Cells[2].Value = "lenguaje";
            dtgAsignatura.Rows[1].Cells[3].Value = "hablar con gente :v";

            dtgAsignatura.Rows[2].Cells[2].Value = "Transmicion";
            dtgAsignatura.Rows[2].Cells[3].Value = "comunicarse con gente ;p";

            dtgAsignatura.Rows[3].Cells[2].Value = "Diseño";
            dtgAsignatura.Rows[3].Cells[3].Value = "pelearse con gente :v";
        }
    }
}
