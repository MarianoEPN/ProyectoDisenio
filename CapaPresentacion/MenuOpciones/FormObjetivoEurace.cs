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
    public partial class FormObjetivoEurace : Form
    {
        List<ObjetivoEurace> ListaObjetivoEuraces; 
        public FormObjetivoEurace()
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void FormObjetivoEurace_Load(object sender, EventArgs e)
        {
            ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();
            // Lista original de asignaturas
            ListaObjetivoEuraces = objetivoEuraceNeg.MostrarObjetivoEurace();

            // Asignar la lista original al DataGridView
            dtgObjetivoEurace.DataSource = ListaObjetivoEuraces;
            dtgObjetivoEurace.Columns["Id"].Visible = false;

            // Ocultar las columnas que no deseas mostrar
            dtgObjetivoEurace.ClearSelection();
            dtgObjetivoEurace.CurrentCell = null;

            // Interceptar cualquier intento de selección inicial
            //dtgObjetivoEurace.SelectionChanged += DtAsignatura_SelectionChanged;
        }

        private void dtgObjetivoEurace_SelectionChanged(object sender, EventArgs e)
        {
            // Si el DataGridView no está enfocado, limpia la selección
            if (!dtgObjetivoEurace.Focused)
            {
                dtgObjetivoEurace.ClearSelection();
                return;
            }

            // Mostrar u ocultar botones dependiendo de la selección
            if (dtgObjetivoEurace.CurrentRow != null && dtgObjetivoEurace.CurrentRow.Index >= 0)
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
            ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();
            dtgObjetivoEurace.DataSource = null;
            dtgObjetivoEurace.DataSource = objetivoEuraceNeg.MostrarObjetivoEurace(); 
            dtgObjetivoEurace.Columns["Id"].Visible = false; 

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormObjetivoEuraceCrud crud = new FormObjetivoEuraceCrud();
            this.Enabled = false;
            crud.ShowDialog();
            this.Enabled = true;
            ActualizarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgObjetivoEurace.CurrentRow != null)
            {
                DataGridViewRow row = dtgObjetivoEurace.CurrentRow;
                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ObjetivoEurace objetivoSeleccionado = (ObjetivoEurace)row.DataBoundItem;
                FormObjetivoEuraceCrud crud = new FormObjetivoEuraceCrud(objetivoSeleccionado);
                this.Enabled = false;
                crud.ShowDialog();
                this.Enabled = true;
                ActualizarTabla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgObjetivoEurace.CurrentRow != null)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dtgObjetivoEurace.CurrentRow;

                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ObjetivoEurace objetivoSeleccionado = (ObjetivoEurace)row.DataBoundItem;

                ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();

                objetivoEuraceNeg.EliminarObjetivoEurace(objetivoSeleccionado.Id);

                ActualizarTabla();
                row.Selected = false;

                // Desactiva la selección inicial
                dtgObjetivoEurace.ClearSelection();
                dtgObjetivoEurace.CurrentCell = null;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
    }
}
