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
    public partial class FormObjetivosPrograma : Form
    {
        List<ObjetivoPrograma> ListaObjetivosPrograma;
        Carrera carrera;
        public FormObjetivosPrograma()
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
        public FormObjetivosPrograma(Carrera carrera)
        {
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            this.carrera = carrera;
        }

        private void FormObjetivosPrograma_Load(object sender, EventArgs e)
        {
            ObjetivoProgramaNeg objetivoProgramaNeg = new ObjetivoProgramaNeg();

            ListaObjetivosPrograma = objetivoProgramaNeg.ObtenerObjetivosProgramaPorCarrera(carrera.Id);

            dtgObjetivoPrograma.DataSource = ListaObjetivosPrograma;
            dtgObjetivoPrograma.Columns["Id"].Visible = false;

            // Ocultar las columnas que no deseas mostrar
            dtgObjetivoPrograma.ClearSelection();
            dtgObjetivoPrograma.CurrentCell = null;

            // Interceptar cualquier intento de selección inicial
            dtgObjetivoPrograma.SelectionChanged += dtgObjetivoPrograma_SelectionChanged;
        }

        private void dtgObjetivoPrograma_SelectionChanged(object sender, EventArgs e)
        {
            // Si el DataGridView no está enfocado, limpia la selección
            if (!dtgObjetivoPrograma.Focused)
            {
                dtgObjetivoPrograma.ClearSelection();
                return;
            }

            // Mostrar u ocultar botones dependiendo de la selección
            if (dtgObjetivoPrograma.CurrentRow != null && dtgObjetivoPrograma.CurrentRow.Index >= 0)
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
            ObjetivoProgramaNeg objetivoProgramaNeg = new ObjetivoProgramaNeg();
            dtgObjetivoPrograma.DataSource = null;
            dtgObjetivoPrograma.DataSource = objetivoProgramaNeg.ObtenerObjetivosProgramaPorCarrera(carrera.Id); ;
            dtgObjetivoPrograma.Columns["Id"].Visible = false;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgObjetivoPrograma.CurrentRow != null)
            {
                DataGridViewRow row = dtgObjetivoPrograma.CurrentRow;
                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ObjetivoPrograma objetivoProgramaSeleccionado = (ObjetivoPrograma)row.DataBoundItem;
                FormObjetivoProgramaCRUD crud = new FormObjetivoProgramaCRUD(carrera,objetivoProgramaSeleccionado);
                this.Enabled = false;
                crud.ShowDialog();
                this.Enabled = true;
                ActualizarTabla();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormObjetivoProgramaCRUD crud = new FormObjetivoProgramaCRUD(carrera);
            this.Enabled = false;
            crud.ShowDialog();
            this.Enabled = true;
            ActualizarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgObjetivoPrograma.CurrentRow != null)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dtgObjetivoPrograma.CurrentRow;

                // Obtener el objeto completo, que corresponde a la fila seleccionada
                ObjetivoPrograma objetivoProgramaSeleccionado = (ObjetivoPrograma)row.DataBoundItem;

                ObjetivoProgramaNeg objetivoProgramaNeg = new ObjetivoProgramaNeg();

                objetivoProgramaNeg.EliminarObjetivoPrograma(objetivoProgramaSeleccionado.Id);

                ActualizarTabla();
                row.Selected = false;

                // Desactiva la selección inicial
                dtgObjetivoPrograma.ClearSelection();
                dtgObjetivoPrograma.CurrentCell = null;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
    }
}
