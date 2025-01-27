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
using CapaPresentacion.CRUD;

namespace CapaPresentacion
{
    public partial class FormAsignatura : Form
    {
        List<Asignatura> listaAsignaturas;

        public FormAsignatura()
        {
            InitializeComponent();
        }

        private void Asignatura_Load(object sender, EventArgs e)
        {
            // Lista original de asignaturas
             listaAsignaturas = new List<Asignatura>
    {
        new Asignatura { Id = 1, Codigo = "MAT101", Nombre = "Matemáticas Básicas", Nivel = 1 },
        new Asignatura { Id = 2, Codigo = "FIS202", Nombre = "Física General", Nivel = 2 },
        new Asignatura { Id = 3, Codigo = "QUI303", Nombre = "Química Orgánica", Nivel = 3 },
        new Asignatura { Id = 4, Codigo = "BIO404", Nombre = "Biología Celular", Nivel = 4 },
        new Asignatura { Id = 5, Codigo = "INF505", Nombre = "Programación Avanzada", Nivel = 5 }
    };

            // Asignar la lista original al DataGridView
            dtgAsignatura.DataSource = listaAsignaturas;

            // Ocultar las columnas que no deseas mostrar
            dtgAsignatura.Columns["Id"].Visible = false;    // Ocultar la columna Id
        }
        private void ActualizarTabla()
        {
            dtgAsignatura.DataSource = null;
            dtgAsignatura.DataSource = listaAsignaturas;
            // Ocultar las columnas que no deseas mostrar
            dtgAsignatura.Columns["Id"].Visible = false;    // Ocultar la columna Id
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAsignaturaCrud crud = new FormAsignaturaCrud();
            this.Enabled = false;
            crud.ShowDialog();
            this.Enabled = true;
            listaAsignaturas.Add(crud.AsignaturaEditar);
            ActualizarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgAsignatura.CurrentRow != null)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dtgAsignatura.CurrentRow;

                // Obtener el objeto completo, que corresponde a la fila seleccionada
                Asignatura asignaturaSeleccionada = (Asignatura)row.DataBoundItem;

                //listaAsignaturas.RemoveAll(a => a.Id == asignaturaSeleccionada.Id);
                //ActualizarTabla();
                //row.Selected = false;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgAsignatura.CurrentRow != null)
            {
                DataGridViewRow row = dtgAsignatura.CurrentRow;
                // Obtener el objeto completo, que corresponde a la fila seleccionada
                Asignatura asignaturaSeleccionada = (Asignatura)row.DataBoundItem;
                FormAsignaturaCrud crud = new FormAsignaturaCrud(asignaturaSeleccionada);
                this.Enabled = false;
                crud.ShowDialog();
                this.Enabled = true;
                ActualizarTabla();
            }
        }
    }
}
