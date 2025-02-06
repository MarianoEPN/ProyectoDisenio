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

        // Constructor para modo CREACIÓN en el que se abre el formulario solo con la Carrera,
        // dejando sin asignar los objetos objetivoEurace y resultadoAprendizaje para que el usuario los seleccione.
        public FormsComentario(Carrera carrera)
        {
            InitializeComponent();
            this.carrera = carrera;
            // Dejamos objetivoEurace y resultadoAprendizaje en null para que el usuario los elija
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

            // Configurar los ComboBox con los datos de la base de datos
            gcmbObjetivoEurace.DataSource = null;
            gcmbResutadoAprendizaje.DataSource = null;
            gcmbResutadoAprendizaje.DataSource = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id);
            gcmbObjetivoEurace.DataSource = objetivoEuraceNeg.MostrarObjetivoEurace();

            // Seleccionar el elemento correspondiente para cada ComboBox, solo si las variables no son nulas
            if (objetivoEurace != null)
            {
                int indiceFila = objetivoEuraceNeg.MostrarObjetivoEurace().FindIndex(obj => obj.Id == objetivoEurace.Id);
                gcmbObjetivoEurace.SelectedIndex = indiceFila;
            }
            else
            {
                gcmbObjetivoEurace.SelectedIndex = -1;
            }

            if (resultadoAprendizaje != null)
            {
                int indiceColumna = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id)
                                        .FindIndex(res => res.Id == resultadoAprendizaje.Id);
                gcmbResutadoAprendizaje.SelectedIndex = indiceColumna;
            }
            else
            {
                gcmbResutadoAprendizaje.SelectedIndex = -1;
            }

            lbAdvertencia.Visible = false;

            // Configurar el estado inicial de los controles:
            // En modo edición, el TextBox se carga con el comentario y se muestra en modo de solo lectura
            tbComentario.ReadOnly = true;  // inicialmente en modo edición, el TextBox es solo lectura

            if (esEdicion)
            {
                // Si estamos en modo edición, mostrar botones Editar y Eliminar
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                // Ocultar el botón de Guardar inicialmente
                btnCrear.Visible = false;
                // No permitir cambiar el objetivo y el resultado (ya definidos)
                gcmbObjetivoEurace.Enabled = false;
                gcmbResutadoAprendizaje.Enabled = false;
            }
            else
            {
                // En modo creación: no se muestran los botones de editar ni eliminar, solo el botón de Guardar
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnCrear.Visible = true;
                // En modo creación se permite editar el comentario
                tbComentario.ReadOnly = false;
                // Si en modo creación se abre sin objetivoEurace y resultadoAprendizaje (por ejemplo, al usar el botón Agregar),
                // habilitar los ComboBox para que el usuario pueda seleccionar la fila y columna.
                if (objetivoEurace == null && resultadoAprendizaje == null)
                {
                    gcmbObjetivoEurace.Enabled = true;
                    gcmbResutadoAprendizaje.Enabled = true;
                }
                else
                {
                    gcmbObjetivoEurace.Enabled = false;
                    gcmbResutadoAprendizaje.Enabled = false;
                }
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
            // Este método sirve para guardar, ya sea creando una nueva relación o actualizando una existente.
            // Se valida que el comentario no esté vacío
            if (string.IsNullOrEmpty(tbComentario.Text))
            {
                tbComentario.BorderColor = Color.Red;
                lbAdvertencia.Visible = true;
                return;
            }

            // Se instancia la entidad y se asigna el comentario del TextBox
            EuraceResultadoAprendizaje relacion = new EuraceResultadoAprendizaje();
            relacion.Comentario = tbComentario.Text;

            // Se obtienen los datos seleccionados de los ComboBox (en modo edición, estos ya están fijos)
            ObjetivoEurace objetivo = gcmbObjetivoEurace.SelectedItem as ObjetivoEurace;
            ResultadoAprendizaje resultado = gcmbResutadoAprendizaje.SelectedItem as ResultadoAprendizaje;

            EuraceResultadoAprendizajeNeg negocio = new EuraceResultadoAprendizajeNeg();

            try
            {
                if (esEdicion)
                {
                    // En modo edición se actualiza la relación existente
                    relacion.Id = relacionId; // se asigna el id de la relación existente
                    negocio.ActualizarEuraceResultadoAprendizaje(relacion, objetivo, resultado);
                    MessageBox.Show("Comentario actualizado.");
                }
                else
                {
                    // **Validación agregada:** Antes de crear, se verifica si ya existe un match para el objetivo y resultado seleccionados
                    var relacionExistente = negocio.BuscarEuraceResultadoAprendizaje(objetivo, resultado);
                    if (relacionExistente != null && relacionExistente.Count > 0)
                    {
                        MessageBox.Show("Ya existe un match para el objetivo y resultado seleccionados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // En modo creación se inserta una nueva relación
                    negocio.InsertarEuraceResultadoAprendizaje(relacion, objetivo, resultado);
                    MessageBox.Show("Relación creada.");
                }

                // Se cierra el formulario con DialogResult.OK para indicar que se realizó la operación correctamente
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
        public ObjetivoEurace GetObjetivoSeleccionado()
        {
            return gcmbObjetivoEurace.SelectedItem as ObjetivoEurace;
        }

        public ResultadoAprendizaje GetResultadoSeleccionado()
        {
            return gcmbResutadoAprendizaje.SelectedItem as ResultadoAprendizaje;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Permite que el usuario edite el comentario: habilita el TextBox para edición
            tbComentario.Enabled = true;
            tbComentario.ReadOnly = false;

            // Se puede notificar al usuario que ahora puede editar el comentario
            MessageBox.Show("Ahora puedes editar el comentario.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ocultar el botón Editar para que no se pueda volver a presionar
            btnEditar.Visible = false;
            // Mostrar el botón Guardar (btnCrear) y cambiar su texto a "Guardar Cambios"
            btnCrear.Visible = true;
            btnCrear.Text = "Guardar Cambios";
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
