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

namespace CapaPresentacion.MenuOpciones
{
    public partial class FormComentario2 : Form
    {

        private ResultadoAprendizaje perfilEgreso;
        private Carrera carrera;
        private ResultadoAprendizajeAsignatura resultadoAsignatura;
        private Asignatura asignatura;
        private string[] listaAporte = { "ALTO", "MEDIO", "BAJO" };

        // Para indicar si se eliminó la relación
        public bool RelacionEliminada { get; private set; } = false;

        // Para guardar el id del match (en modo edición)
        private int relacionId = 0;

        // Indica si el formulario se abre en modo edición
        private bool esEdicion = false;

        // Constructor para modo CREACIÓN en el que se abre el formulario solo con la Carrera,
        public FormComentario2(Carrera carrera, Asignatura asignatura)
        {
            InitializeComponent();
            this.carrera = carrera;
            this.asignatura = asignatura;
            // Dejamos objetivoEurace y resultadoAprendizaje en null para que el usuario los elija
            esEdicion = false;  // Modo creación
            gcmbAporte.DataSource = listaAporte;
        }

        // Constructor para modo CREACIÓN (nuevo match, sin relación previa)
        public FormComentario2(ResultadoAprendizaje perfilEgreso, Carrera carrera, ResultadoAprendizajeAsignatura resultadoAsignatura, Asignatura asignatura)
        {
            InitializeComponent();
            this.perfilEgreso = perfilEgreso;
            this.carrera = carrera;
            this.resultadoAsignatura = resultadoAsignatura;
            esEdicion = false;
            this.asignatura = asignatura;
            gcmbAporte.DataSource = listaAporte;
        }

        // Constructor para modo EDICIÓN (ya existe la relación; se envía además el id y el comentario actual)
        public FormComentario2(ResultadoAprendizaje perfilEgreso, Carrera carrera, ResultadoAprendizajeAsignatura resultadoAsignatura, int relacionId, string comentario, Asignatura asignatura)
        {
            InitializeComponent();
            this.perfilEgreso = perfilEgreso;
            this.carrera = carrera;
            this.resultadoAsignatura = resultadoAsignatura;
            this.relacionId = relacionId;
            // Usamos el campo NivelAporte para mostrar el comentario (ajusta si deseas usar Comentario)
            //tbComentario.Text = comentario;
            this.asignatura = asignatura;
            esEdicion = true;
            gcmbAporte.DataSource = listaAporte;
            if (gcmbAporte.Items.Contains(comentario))
            {
                gcmbAporte.SelectedItem = comentario;
            }
            else 
            {
                gcmbAporte.SelectedIndex = -1;
            }
        }
        public FormComentario2()
        {
            InitializeComponent();
            gcmbAporte.DataSource = listaAporte;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormComentario2_Load(object sender, EventArgs e)
        {

            ResultadoAprendizajeNeg perfilNeg = new ResultadoAprendizajeNeg();
            ResultadoAprendizajeAsignaturaNeg resultadoAsigNeg = new ResultadoAprendizajeAsignaturaNeg();

            
            // Configurar los ComboBox con los datos de la base de datos
            gcmbResultadoAsignatura.DataSource = null;
            gcmbPerfilEgreso.DataSource = null;
            gcmbPerfilEgreso.DataSource = perfilNeg.ObtenerResultadosAprendizaje(carrera.Id);
            gcmbResultadoAsignatura.DataSource = resultadoAsigNeg.MostrarResultadoAprendizajeAsignatura();

            //
            // Supongamos que la lista de perfiles se obtiene para la carrera:
            var listaPerfiles = perfilNeg.ObtenerResultadosAprendizaje(carrera.Id);


            var listaResultadosAsignatura = resultadoAsigNeg.ObtenerResultadosAprendizajeAsignatura(asignatura.Id);

            gcmbPerfilEgreso.DataSource = listaPerfiles;


            gcmbResultadoAsignatura.DataSource = listaResultadosAsignatura;


            //


            if (perfilEgreso != null)
            {
                int indicePerfil = listaPerfiles.FindIndex(p => p.Id == perfilEgreso.Id);
                gcmbPerfilEgreso.SelectedIndex = (indicePerfil >= 0) ? indicePerfil : -1;
            }
            else
            {
                gcmbPerfilEgreso.SelectedIndex = -1;
            }

            if (resultadoAsignatura != null)
            {
                int indiceResultado = listaResultadosAsignatura.FindIndex(r => r.Id == resultadoAsignatura.Id);
                gcmbResultadoAsignatura.SelectedIndex = (indiceResultado >= 0) ? indiceResultado : -1;
            }
            else
            {
                gcmbResultadoAsignatura.SelectedIndex = -1;
            }

            lbAdvertencia.Visible = false;

            //tbComentario.ReadOnly = true;  // inicialmente en modo edición, el TextBox es solo lectura
            gcmbAporte.Enabled = false;


            // Configurar el estado inicial del TextBox y los botones según el modo.
            if (esEdicion)
            {
                // Si estamos en modo edición, mostrar botones Editar y Eliminar
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                // Ocultar el botón de Guardar inicialmente
                btnCrear.Visible = false;
                // No permitir cambiar el objetivo y el resultado (ya definidos)
                gcmbResultadoAsignatura.Enabled = false;
                gcmbPerfilEgreso.Enabled = false;
            }
            else
            {
                // En modo creación: no se muestran los botones de editar ni eliminar, solo el botón de Guardar
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnCrear.Visible = true;
                // En modo creación se permite editar el comentario
                //tbComentario.ReadOnly = false;
                gcmbAporte.Enabled = true;
                // Si en modo creación se abre sin objetivoEurace y resultadoAprendizaje (por ejemplo, al usar el botón Agregar),
                // habilitar los ComboBox para que el usuario pueda seleccionar la fila y columna.
                if (perfilEgreso == null && resultadoAsignatura == null)
                {
                    gcmbPerfilEgreso.Enabled = true;
                    gcmbResultadoAsignatura.Enabled = true;
                }
                else
                {
                    gcmbPerfilEgreso.Enabled = false;
                    gcmbResultadoAsignatura.Enabled = false;
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Validar que el comentario no esté vacío
           

            // Instanciar el objeto de la relación (MatchResultadoAprendizaje)
            MatchResultadoAprendizaje match = new MatchResultadoAprendizaje();
            // Usamos el campo NivelAporte para almacenar el comentario
            //match.NivelAporte = tbComentario.Text;
            match.NivelAporte = gcmbAporte.Text;


            // Se obtienen los datos seleccionados de los ComboBox (en modo edición, estos ya están fijos)
            ResultadoAprendizajeAsignatura objetivo = gcmbResultadoAsignatura.SelectedItem as ResultadoAprendizajeAsignatura;
            ResultadoAprendizaje resultado = gcmbPerfilEgreso.SelectedItem as ResultadoAprendizaje;

            MatchResultadoAprendizajeNeg negocio = new MatchResultadoAprendizajeNeg();

            try
            {
                if (esEdicion)
                {
                    // Actualizar el match existente
                    match.Id = relacionId;
                    negocio.ActualizarMatchResultadoAprendizaje(match, objetivo, resultado);
                    MessageBox.Show("Comentario actualizado.");

                }
                else
                {
                    var relacionExistente = negocio.BuscarMatchResultadoAprendizaje(objetivo, resultado);
                    if (relacionExistente != null && relacionExistente.Count > 0)
                    {
                        MessageBox.Show("Ya existe un match para el objetivo y resultado seleccionados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                        // Insertar la nueva relación
                    negocio.InsertarMatchResultadoAprendizaje(match, objetivo, resultado);
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
        public ResultadoAprendizajeAsignatura GetResultadoSeleccionado()
        {
            return gcmbResultadoAsignatura.SelectedItem as ResultadoAprendizajeAsignatura;
        }

        public ResultadoAprendizaje GetPerfilSeleccionado()
        {
            return gcmbPerfilEgreso.SelectedItem as ResultadoAprendizaje;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Permitir la edición del comentario
            //tbComentario.Enabled = true;
            //tbComentario.ReadOnly = false;
            gcmbAporte.Enabled = true;
            MessageBox.Show("Ahora puedes editar el comentario.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnEditar.Visible = false;
            btnCrear.Visible = true;
            btnCrear.Text = "Guardar Cambios";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar esta relación?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MatchResultadoAprendizajeNeg negocio = new MatchResultadoAprendizajeNeg();
                negocio.EliminarMatchResultadoAprendizaje(relacionId);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}
