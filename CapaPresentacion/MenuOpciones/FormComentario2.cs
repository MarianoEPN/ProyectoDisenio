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
        // Variables para identificar la relación en este contexto.
        // "perfilEgreso" representa el perfil de egreso (de tipo ResultadoAprendizaje)
        // "resultadoAsignatura" representa el resultado de aprendizaje de asignatura (de tipo ResultadoAprendizajeAsignatura)
        private ResultadoAprendizaje perfilEgreso;
        private Carrera carrera;
        private ResultadoAprendizajeAsignatura resultadoAsignatura;
        Asignatura asignatura;

        // Para indicar si se eliminó la relación
        public bool RelacionEliminada { get; private set; } = false;

        // Para guardar el id del match (en modo edición)
        private int relacionId = 0;

        // Indica si el formulario se abre en modo edición
        private bool esEdicion = false;

        // Constructor para modo CREACIÓN (nuevo match, sin relación previa)
        public FormComentario2(ResultadoAprendizaje perfilEgreso, Carrera carrera, ResultadoAprendizajeAsignatura resultadoAsignatura, Asignatura asignatura)
        {
            InitializeComponent();
            this.perfilEgreso = perfilEgreso;
            this.carrera = carrera;
            this.resultadoAsignatura = resultadoAsignatura;
            esEdicion = false;
            this.asignatura = asignatura;
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
            tbComentario.Text = comentario;
            this.asignatura = asignatura;
            esEdicion = true;
        }
        public FormComentario2()
        {
            InitializeComponent();
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
            // En este formulario vamos a mostrar en dos ComboBoxes la información del "perfil" y del "resultado"
            // Si deseas que sean fijos (no editables) en este contexto, puedes simplemente mostrarlos en Labels.
            // En este ejemplo, usaremos ComboBoxes para mantener la consistencia, pero los deshabilitaremos en modo edición.

            ResultadoAprendizajeNeg perfilNeg = new ResultadoAprendizajeNeg();
            // Supongamos que la lista de perfiles se obtiene para la carrera:
            var listaPerfiles = perfilNeg.ObtenerResultadosAprendizaje(carrera.Id);
            // Para los resultados de asignatura, se obtiene a partir del id de la asignatura.
            // Se supone que el id de la asignatura ya está definido en la variable 'asignaturaId'.
            // Por ejemplo:
            
            ResultadoAprendizajeAsignaturaNeg resultadoAsigNeg = new ResultadoAprendizajeAsignaturaNeg();
            var listaResultadosAsignatura = resultadoAsigNeg.ObtenerResultadosAprendizajeAsignatura(asignatura.Id);

            // Asignar las listas a los ComboBoxes (o a Labels si prefieres que sean fijos)
            gcmbPerfilEgreso.DataSource = listaPerfiles;
            //gcmbPerfilEgreso.DisplayMember = "Descripcion";  // O "Codigo", según prefieras
            //gcmbPerfilEgreso.ValueMember = "Id";

            gcmbResultadoAsignatura.DataSource = listaResultadosAsignatura;
            //gcmbResultadoAsignatura.DisplayMember = "Codigo" + " Descripcion";
            //gcmbResultadoAsignatura.ValueMember = "Id";

            // Seleccionar el elemento recibido en el constructor, si no es nulo.
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

            // Configurar el estado inicial del TextBox y los botones según el modo.
            if (esEdicion)
            {
                // En modo edición, el comentario se muestra en modo solo lectura
                tbComentario.ReadOnly = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnCrear.Visible = false; // Ocultar el botón Guardar hasta que se active la edición
                gcmbPerfilEgreso.Enabled = false;
                gcmbResultadoAsignatura.Enabled = false;
            }
            else
            {
                // En modo creación, se permite la edición inmediatamente
                tbComentario.ReadOnly = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnCrear.Visible = true;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Validar que el comentario no esté vacío
            if (string.IsNullOrEmpty(tbComentario.Text))
            {
                tbComentario.BorderColor = Color.Red;
                lbAdvertencia.Visible = true;
                return;
            }

            // Instanciar el objeto de la relación (MatchResultadoAprendizaje)
            MatchResultadoAprendizaje match = new MatchResultadoAprendizaje();
            // Usamos el campo NivelAporte para almacenar el comentario
            match.NivelAporte = tbComentario.Text;

            MatchResultadoAprendizajeNeg negocio = new MatchResultadoAprendizajeNeg();

            try
            {
                if (esEdicion)
                {
                    // Actualizar el match existente
                    match.Id = relacionId;
                    negocio.ActualizarMatchResultadoAprendizaje(match, gcmbResultadoAsignatura.SelectedItem as ResultadoAprendizajeAsignatura, gcmbPerfilEgreso.SelectedItem as ResultadoAprendizaje);
                    MessageBox.Show("Comentario actualizado.");
                }
                else
                {
                    // Insertar la nueva relación
                    negocio.InsertarMatchResultadoAprendizaje(match, gcmbResultadoAsignatura.SelectedItem as ResultadoAprendizajeAsignatura, gcmbPerfilEgreso.SelectedItem as ResultadoAprendizaje);
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
            // Permitir la edición del comentario
            tbComentario.Enabled = true;
            tbComentario.ReadOnly = false;
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
