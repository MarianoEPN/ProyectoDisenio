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

namespace CapaPresentacion.MenuOpciones
{
    public partial class FormResultadosAprendizaje : Form
    {
        List<ResultadoAprendizaje> listaResultadoAprendizaje;
        Carrera carrera;
        public FormResultadosAprendizaje()
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
        public FormResultadosAprendizaje(Carrera carrera)
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            this.carrera = carrera;
        }
        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormResultadosAprendizaje_Load(object sender, EventArgs e)
        {
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();

            // Lista original de asignaturas
            listaResultadoAprendizaje = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id);
            

            // Asignar la lista original al DataGridView
            dtgAsignatura.DataSource = listaResultadoAprendizaje;
            dtgAsignatura.Columns["Id"].Visible = false;

            // Ocultar las columnas que no deseas mostrar
            dtgAsignatura.ClearSelection();
            dtgAsignatura.CurrentCell = null;

            // Interceptar cualquier intento de selección inicial
            dtgAsignatura.SelectionChanged += DtAsignatura_SelectionChanged;
        }

        private void DtAsignatura_SelectionChanged(object sender, EventArgs e)
        {
            // Si el DataGridView no está enfocado, limpia la selección
            if (!dtgAsignatura.Focused)
            {
                dtgAsignatura.ClearSelection();
                return;
            }

            // Mostrar u ocultar botones dependiendo de la selección
            if (dtgAsignatura.CurrentRow != null && dtgAsignatura.CurrentRow.Index >= 0)
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
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
            dtgAsignatura.DataSource = null;
            dtgAsignatura.DataSource = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id); ;
            dtgAsignatura.Columns["Id"].Visible = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgAsignatura.CurrentRow != null)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow row = dtgAsignatura.CurrentRow;

                    // Obtener el objeto completo, que corresponde a la fila seleccionada
                    ResultadoAprendizaje resultadoAprendizajeSeleccionado = (ResultadoAprendizaje)row.DataBoundItem;

                    ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();

                    resultadoAprendizajeNeg.EliminarResultadoAprendizaje(resultadoAprendizajeSeleccionado.Id);

                    ActualizarTabla();
                    row.Selected = false;

                    // Desactiva la selección inicial
                    dtgAsignatura.ClearSelection();
                    dtgAsignatura.CurrentCell = null;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                }

                MessageBox.Show("Resultado de asignatura eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se puede eliminar el objetivo de programa porque tiene registros relacionados", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormResulAprendizajeCRUD crud = new FormResulAprendizajeCRUD(carrera);
            this.Enabled = false;
            crud.ShowDialog();
            this.Enabled = true;
            ActualizarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgAsignatura.CurrentRow != null)
            {
                DataGridViewRow row = dtgAsignatura.CurrentRow;
                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ResultadoAprendizaje resultadoAprendizajeSeleccionado = (ResultadoAprendizaje)row.DataBoundItem;
                FormResulAprendizajeCRUD crud = new FormResulAprendizajeCRUD(resultadoAprendizajeSeleccionado, carrera);
                this.Enabled = false;
                crud.ShowDialog();
                this.Enabled = true;
                ActualizarTabla();
            }
        }
    }
}
