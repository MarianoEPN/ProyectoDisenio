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

namespace CapaPresentacion.MenuOpciones
{
    public partial class FormEditarUsuario : Form
    {
        private Usuario usuario;
        private Carrera carrera;
        public FormEditarUsuario()
        {
            InitializeComponent();
        }

        public FormEditarUsuario(Usuario usuario, Carrera carrera)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.carrera = carrera;
        }
    }
}
