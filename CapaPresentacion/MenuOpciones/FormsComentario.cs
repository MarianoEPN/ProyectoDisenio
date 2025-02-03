using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CapaPresentacion.MenuOpciones
{
    public partial class FormsComentario : Form
    {
        ObjetivoEurace objetivoEurace;
        Carrera carrera;
        ResultadoAprendizaje resultadoAprendizaje;

        // Propiedad para saber si se eliminó una relación
        public bool RelacionEliminada { get; private set; } = false;

        // Si en modo edición necesitamos guardar el id de la relación (opcional)
        private int relacionId = 0;

        // Variable que indica si el formulario se abre para edición (relación existente)
        private bool esEdicion = false;

        // Constructor para modo CREACIÓN (nuevo comentario, sin relación previa)
        public FormsComentario(ObjetivoEurace objetivoEurace, Carrera carrera, ResultadoAprendizaje resultadoAprendizaje)
        {
            InitializeComponent();
            this.objetivoEurace = objetivoEurace;
            this.carrera = carrera;
            this.resultadoAprendizaje = resultadoAprendizaje;
            esEdicion = false;  // Modo creación
        }


        // Constructor para modo EDICIÓN/Visualización (ya existe la relación, se envía además el comentario y opcionalmente el id)
        public FormsComentario(ObjetivoEurace objetivoEurace, Carrera carrera, ResultadoAprendizaje resultadoAprendizaje, int relacionId, string comentario)
        {
            InitializeComponent();
            this.objetivoEurace = objetivoEurace;
            this.carrera = carrera;
            this.resultadoAprendizaje = resultadoAprendizaje;
            this.relacionId = relacionId;
            tbComentario.Text = comentario; // Cargar el comentario existente
            esEdicion = true;  // Modo edición
        }

        public FormsComentario()
        {
            InitializeComponent();
        }


        private void FormsComentario_Load(object sender, EventArgs e)
        {
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
            ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();

            // Configurar los ComboBox
            gcmbObjetivoEurace.DataSource = null;
            gcmbResutadoAprendizaje.DataSource = null;
            gcmbResutadoAprendizaje.DataSource = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id);
            gcmbObjetivoEurace.DataSource = objetivoEuraceNeg.MostrarObjetivoEurace();

            // Seleccionar el item correspondiente en cada ComboBox
            int indiceFila = objetivoEuraceNeg.MostrarObjetivoEurace().FindIndex(obj => obj.Id == objetivoEurace.Id);
            gcmbObjetivoEurace.SelectedIndex = indiceFila;
            int indiceColumna = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id)
                                .FindIndex(res => res.Id == resultadoAprendizaje.Id);
            gcmbResutadoAprendizaje.SelectedIndex = indiceColumna;

            lbAdvertencia.Visible = false;

            // Configurar botones según el modo (crear o editar)
            if (esEdicion)
            {
                // Modo edición: mostrar botones editar y eliminar
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                // Bloquea la selección de objetivos y resultados para evitar cambios
                gcmbObjetivoEurace.Enabled = false;
                gcmbResutadoAprendizaje.Enabled = false;
            }
            else
            {
                // Modo creación: ocultar botones de editar y eliminar
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnClose.IconColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Properties.Resources.CircleWithe;
            btnClose.IconColor = Color.DimGray;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnMin.IconColor = Color.White;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = Properties.Resources.CircleWithe;
            btnMin.IconColor = Color.DimGray;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gcmbResutadoAprendizaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbComentario.Text))
            {
                tbComentario.BorderColor = Color.Red;
                lbAdvertencia.Visible = true;
                return;
            }

            EuraceResultadoAprendizaje relacion = new EuraceResultadoAprendizaje();
            relacion.Comentario = tbComentario.Text;

            ObjetivoEurace objetivo = gcmbObjetivoEurace.SelectedItem as ObjetivoEurace;
            ResultadoAprendizaje resultado = gcmbResutadoAprendizaje.SelectedItem as ResultadoAprendizaje;

            EuraceResultadoAprendizajeNeg negocio = new EuraceResultadoAprendizajeNeg();

            try
            {
                if (esEdicion)
                {
                    // Modo EDICIÓN: Actualizar
                    relacion.Id = relacionId;
                    negocio.ActualizarEuraceResultadoAprendizaje(relacion, objetivo, resultado);
                    MessageBox.Show("Comentario actualizado.");
                }
                else
                {
                    // Modo CREACIÓN: Insertar
                    negocio.InsertarEuraceResultadoAprendizaje(relacion, objetivo, resultado);
                    MessageBox.Show("Relación creada.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Permite que el usuario edite el comentario (por ejemplo, habilitando el TextBox)
            tbComentario.ReadOnly = false;
            MessageBox.Show("Ahora puedes editar el comentario.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar esta relación?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EuraceResultadoAprendizajeNeg negocio = new EuraceResultadoAprendizajeNeg();
                negocio.EliminarEuraceResultadoAprendizaje(relacionId);
                this.DialogResult = DialogResult.Abort; // Indicar eliminación
                this.Close();
            }
        }
    }
}
