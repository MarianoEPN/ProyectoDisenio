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
    public partial class FormAsignatura : Form
    {
        List<Asignatura> listaAsignaturas;
        Carrera carrera;

        public FormAsignatura()
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        public FormAsignatura(Carrera carrera)
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            this.carrera = carrera;
        }

        private void Asignatura_Load(object sender, EventArgs e)
        {
            AsignaturaNeg asignaturaNeg = new AsignaturaNeg();

            // Lista original de asignaturas
            listaAsignaturas = asignaturaNeg.ObtenerAsignaturasPorCarrera(carrera.Id);

            // Asignar la lista original al DataGridView
            dtgAsignatura.DataSource = listaAsignaturas;
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
            AsignaturaNeg asignaturaNeg = new AsignaturaNeg();
            dtgAsignatura.DataSource = null;
            dtgAsignatura.DataSource = asignaturaNeg.ObtenerAsignaturasPorCarrera(carrera.Id);
            dtgAsignatura.Columns["Id"].Visible = false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAsignaturaCrud crud = new FormAsignaturaCrud(carrera);
            this.Enabled = false;
            crud.ShowDialog();
            this.Enabled = true;
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

                AsignaturaNeg asignaturaNeg = new AsignaturaNeg();

                asignaturaNeg.EliminarAsignatura(asignaturaSeleccionada.Id);
                
                ActualizarTabla();
                row.Selected = false;

                // Desactiva la selección inicial
                dtgAsignatura.ClearSelection();
                dtgAsignatura.CurrentCell = null;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
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

        private void FormAsignatura_KeyDown(object sender, KeyEventArgs e)
        {
            // Para usarlo a posterior para darle enter y utilizar el boton de busqueda
            /*
            if (e.KeyCode == Keys.Enter)
            {
                // Llama al evento del botón
                Button_Click(sender, e);
                e.Handled = true; // Evita que el evento se propague si es necesario
            }
            */
        }

        
    }
}
