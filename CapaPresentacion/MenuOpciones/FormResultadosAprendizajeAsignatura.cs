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
using CapaNegocio;
using CapaPresentacion.CRUD;

namespace CapaPresentacion
{
    public partial class FormResultadosAprendizajeAsignatura : Form
    {
        private Carrera carrera;
        private Asignatura asignatura;
        public FormResultadosAprendizajeAsignatura()
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        public FormResultadosAprendizajeAsignatura(Carrera carrera)
        {
            InitializeComponent();
            this.carrera = carrera;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void FormResultadosAprendizajeAsignatura_Load(object sender, EventArgs e)
        {
            if (carrera != null) {
                AsignaturaNeg asignaturaNeg = new AsignaturaNeg();
                cbbAsignatura.DataSource = asignaturaNeg.ObtenerAsignaturasPorCarrera(carrera.Id);
                // Ocultar las columnas que no deseas mostrar
                dtgRRA.ClearSelection();
                dtgRRA.CurrentCell = null;

                // Interceptar cualquier intento de selección inicial
                dtgRRA.SelectionChanged += DtRRA_SelectionChanged;
            }
        }

        private void DtRRA_SelectionChanged(object sender, EventArgs e)
        {
            // Si el DataGridView no está enfocado, limpia la selección
            if (!dtgRRA.Focused)
            {
                dtgRRA.ClearSelection();
                return;
            }

            // Mostrar u ocultar botones dependiendo de la selección
            if (dtgRRA.CurrentRow != null && dtgRRA.CurrentRow.Index >= 0)
            {
                btnEditar.Visible = true;  // Mostrar el botón Editar
                btnEliminar.Visible = true; // Mostrar el botón Eliminar
            }
            else
            {
                btnEditar.Visible = false;  // Ocultar el botón Editar
                btnEliminar.Visible = false; // Ocultar el botón Eliminar
            }
        }

        private void ActualizarTabla()
        {
            dtgRRA.DataSource = null;
            ResultadoAprendizajeAsignaturaNeg rra = new ResultadoAprendizajeAsignaturaNeg();
            dtgRRA.DataSource = rra.ObtenerResultadosAprendizajeAsignatura(((Asignatura)cbbAsignatura.SelectedItem).Id);
            dtgRRA.Columns["Id"].Visible = false;
        }

        private void cbbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAsignatura.SelectedItem != null) {
                ResultadoAprendizajeAsignaturaNeg rra = new ResultadoAprendizajeAsignaturaNeg();
                dtgRRA.DataSource = rra.ObtenerResultadosAprendizajeAsignatura(((Asignatura)cbbAsignatura.SelectedItem).Id);
                dtgRRA.Columns["Id"].Visible = false;
                dtgRRA.ClearSelection();
                dtgRRA.CurrentCell = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbbAsignatura.SelectedItem != null)
            {
                Asignatura asignaturaSeleccionada = (Asignatura)cbbAsignatura.SelectedItem;
                FormRRACRUD crud = new FormRRACRUD(asignaturaSeleccionada);
                this.Enabled = false;
                crud.ShowDialog();
                this.Enabled = true;
                ActualizarTabla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgRRA.CurrentRow != null)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dtgRRA.CurrentRow;

                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ResultadoAprendizajeAsignatura resultadoAprendizajeSeleccionado = (ResultadoAprendizajeAsignatura)row.DataBoundItem;

                ResultadoAprendizajeAsignaturaNeg resultadoAprendizajeNeg = new ResultadoAprendizajeAsignaturaNeg();

                resultadoAprendizajeNeg.EliminarResultadoAprendizajeAsignatura(resultadoAprendizajeSeleccionado.Id);

                ActualizarTabla();
                row.Selected = false;

                // Desactiva la selección inicial
                dtgRRA.ClearSelection();
                dtgRRA.CurrentCell = null;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgRRA.CurrentRow != null)
            {
                DataGridViewRow row = dtgRRA.CurrentRow;
                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ResultadoAprendizajeAsignatura resultadoAprendizajeSeleccionado = (ResultadoAprendizajeAsignatura)row.DataBoundItem;
                Asignatura asignaturaSeleccionada = (Asignatura)cbbAsignatura.SelectedItem;
                FormRRACRUD crud = new FormRRACRUD(resultadoAprendizajeSeleccionado, asignaturaSeleccionada);
                this.Enabled = false;
                crud.ShowDialog();
                this.Enabled = true;
                ActualizarTabla();
            }
        }
    }
}
