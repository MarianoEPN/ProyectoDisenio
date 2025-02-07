using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using Guna.UI2.WinForms;

namespace CapaPresentacion.CRUD
{
    public partial class FormRRACRUD : Form
    {
        // Variables para almacenar la posición relativa del ratón en el panel
        private bool isDragging = false;
        private Point initialMousePosition;
        private Asignatura asignatura;
        private ResultadoAprendizajeAsignatura raaAsignatura;

        public FormRRACRUD()
        {
            InitializeComponent();
            TipoResultadoAsignaturaNeg tipoNeg = new TipoResultadoAsignaturaNeg();
            cbbTipoRRA.DataSource = tipoNeg.MostrarTipoResultadoAprendizaje();
            lbAdvertenciaRRA.Visible = false;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(tbCodigoRRA, "Formato permitido: 4 letras seguidas de 3 números (Ejemplo: ABCD123)");
        
    }

        public FormRRACRUD(Asignatura asignatura)
        {
            InitializeComponent();
            TipoResultadoAsignaturaNeg tipoNeg = new TipoResultadoAsignaturaNeg();
            cbbTipoRRA.DataSource = tipoNeg.MostrarTipoResultadoAprendizaje();
            lbAdvertenciaRRA.Visible = false;
            this.asignatura = asignatura;
            tbNombreRRA.Text = asignatura.Nombre;
            tbNombreRRA.Enabled = false;
            lblTituloRRA.Text = "Crear RAA";
            btnCrearRRA.Text = "Crear";
        }

        public FormRRACRUD(ResultadoAprendizajeAsignatura raaAsignatura, Asignatura asignatura)
        {
            InitializeComponent();
            TipoResultadoAsignaturaNeg tipoNeg = new TipoResultadoAsignaturaNeg();
            cbbTipoRRA.DataSource = tipoNeg.MostrarTipoResultadoAprendizaje();
            lbAdvertenciaRRA.Visible = false;
            tbNombreRRA.Text = asignatura.Nombre;
            tbNombreRRA.Enabled = false; // Bloqueamos para que no se pueda editar
            this.asignatura = asignatura;
            this.raaAsignatura = raaAsignatura;

            tbCodigoRRA.Text = raaAsignatura.Codigo;
            tbCodigoRRA.Enabled = true;
            tbDescripcionRRA.Text = raaAsignatura.Descripcion;
            lblTituloRRA.Text = "Editar RAA";
            // Seteamos el código de la asignatura
            //tbCodigoRRA.Text = asignatura.Codigo; 

            // Asignamos los valores en el comboBoxTipoRRA si es necesario (en caso de que haya información predefinida)
            // Si se requiere algo específico en comboBoxTipoRRA, agregamos aquí el código correspondiente.
            cbbTipoRRA.SelectedIndex = ObtenerIndice(raaAsignatura.Tipo.Id); // O seleccionamos el valor correspondiente
        }

        private int ObtenerIndice(int id)
        {
            TipoResultadoAsignaturaNeg tipoNeg = new TipoResultadoAsignaturaNeg();
            List<TipoResultadoAsignatura> listaTipo = tipoNeg.MostrarTipoResultadoAprendizaje();
            int indice = 0;
            foreach (TipoResultadoAsignatura tipo in listaTipo)
            {
                if(id == tipo.Id)
                {
                    return indice;
                }
                indice++;
            }
            return indice;

        }

        private void FormRRACRUD_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(tbCodigoRRA, "Formato permitido: número y punto (Ejemplo: 1.1.)");
        
    }


        private void btnCancelarRRA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTituloRRA_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCrearRRA_Click(object sender, EventArgs e)
        {
            List<Guna2TextBox> listaTextBoxes = new List<Guna2TextBox>
            {
                tbCodigoRRA,
                tbNombreRRA
            };

            if (btnCrearRRA.Text.Equals("Crear"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {
                    // Verificar si está vacío o nulo
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        // Cambiar color del borde a rojo
                        txt.BorderColor = Color.FromArgb(241, 90, 109);
                        camposCompletos = false;
                    }
                }

                if (camposCompletos)
                {
                    // Guardar la descripción del objetivo de aprendizaje
                    string descripcionObjetivo = tbDescripcionRRA.Text; // Asumiendo que la descripción está en tbDescripcionRRA
                    string tipoObjetivo = cbbTipoRRA.SelectedItem.ToString(); // O el valor que quieras obtener del ComboBox
                    // Llamamos al método de la capa de negocio para guardar la asignatura y su descripción
                    ResultadoAprendizajeAsignatura rra = new ResultadoAprendizajeAsignatura();
                    rra.Codigo = tbCodigoRRA.Text;
                    rra.Descripcion = tbDescripcionRRA.Text;
                    rra.Tipo = (TipoResultadoAsignatura)cbbTipoRRA.SelectedItem;
                    ResultadoAprendizajeAsignaturaNeg rraNeg = new ResultadoAprendizajeAsignaturaNeg();
                    rraNeg.InsertarResultadoAprendizajeAsignatura(rra, asignatura);
                    this.Close();
                }
                else
                {
                    lbAdvertenciaRRA.Visible = true;
                }
            }
            else if (btnCrearRRA.Text.Equals("Guardar"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {
                    // Verificar si está vacío o nulo
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        // Cambiar color del borde a rojo
                        txt.BorderColor = Color.FromArgb(241, 90, 109);
                        camposCompletos = false;
                    }
                }

                if (camposCompletos)
                {
                    raaAsignatura.Descripcion = tbDescripcionRRA.Text;
                    raaAsignatura.Tipo = (TipoResultadoAsignatura) cbbTipoRRA.SelectedItem;
                    raaAsignatura.Codigo = tbCodigoRRA.Text;
                    ResultadoAprendizajeAsignaturaNeg raaNeg = new ResultadoAprendizajeAsignaturaNeg();
                    raaNeg.ActualizarResultadoAprendizajeAsignatura(raaAsignatura, asignatura);
                    MessageBox.Show("Se ha guardado con éxito el objetivo de aprendizaje de la asignatura.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    lbAdvertenciaRRA.Visible = true;
                }
            }
        }

        private void tbCodigoRRA_Enter(object sender, EventArgs e)
        {
            tbCodigoRRA.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbNombreRRA_Enter(object sender, EventArgs e)
        {
            tbNombreRRA.BorderColor = Color.FromArgb(213, 218, 223);
        }

       

        private void tbNivelRRA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }

            
        }

        private void guna2ShadowPanelRRA_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                initialMousePosition = e.Location;
            }
        }

        private void guna2ShadowPanelRRA_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.Location;
                int deltaX = currentMousePosition.X - initialMousePosition.X;
                int deltaY = currentMousePosition.Y - initialMousePosition.Y;
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void guna2ShadowPanelRRA_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void tbCodigoRRA_TextChanged(object sender, EventArgs e)
        {
            tbCodigoRRA.Text = tbCodigoRRA.Text.ToUpper();
            tbCodigoRRA.SelectionStart = tbCodigoRRA.Text.Length;
        }

        private void btnCloseRRA_MouseEnter(object sender, EventArgs e)
        {
            btnCloseRRA.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnCloseRRA.IconColor = Color.White;
        }

        private void btnCloseRRA_MouseLeave(object sender, EventArgs e)
        {
            btnCloseRRA.BackgroundImage = Properties.Resources.CircleWithe;
            btnCloseRRA.IconColor = Color.DimGray;
        }



        private void btnMinRRA_MouseEnter(object sender, EventArgs e)
        {
            btnMinRRA.BackgroundImage = Properties.Resources.CirculoCerrar;
            btnMinRRA.IconColor = Color.White;
        }

        private void btnMinRRA_MouseLeave(object sender, EventArgs e)
        {
            btnMinRRA.BackgroundImage = Properties.Resources.CircleWithe;
            btnMinRRA.IconColor = Color.DimGray;
        }

        private void tbDescripcionRRA_Enter(object sender, EventArgs e)
        {
            tbDescripcionRRA.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbNombreRRA_TextChanged(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbNombreRRA.SelectionStart;

            // Filtra solo letras y espacios, y convierte a mayúsculas
            string nuevoTexto = new string(tbNombreRRA.Text.Where(c => char.IsLetter(c) || c == ' ').ToArray()).ToUpper();

            // Si el texto cambió, actualízalo
            if (tbNombreRRA.Text != nuevoTexto)
            {
                tbNombreRRA.Text = nuevoTexto;
                tbNombreRRA.SelectionStart = selectionStart > tbNombreRRA.Text.Length ? tbNombreRRA.Text.Length : selectionStart;
            }
        }


        private void tbCodigoRRA_TextChanged_1(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbCodigoRRA.SelectionStart;

            // Filtra solo números y puntos
            string nuevoTexto = new string(tbCodigoRRA.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Contar cuántos puntos hay
            int countPuntos = nuevoTexto.Count(c => c == '.');

            // No permitir más de dos puntos
            if (countPuntos > 2)
            {
                int lastIndex = nuevoTexto.LastIndexOf('.');
                nuevoTexto = nuevoTexto.Remove(lastIndex, 1);
            }

            // Validar la estructura X.X.
            if (nuevoTexto.Length > 5)
            {
                nuevoTexto = nuevoTexto.Substring(0, 4);
            }

            if (nuevoTexto.Length >= 1 && !char.IsDigit(nuevoTexto[0])) // Primer carácter debe ser número
            {
                nuevoTexto = "";
            }
            if (nuevoTexto.Length >= 2 && nuevoTexto[1] != '.') // Segundo carácter debe ser punto
            {
                nuevoTexto = nuevoTexto.Substring(0, 1);
            }
            if (nuevoTexto.Length >= 3 && !char.IsDigit(nuevoTexto[2])) // Tercer carácter debe ser número
            {
                nuevoTexto = nuevoTexto.Substring(0, 2);
            }
            if (nuevoTexto.Length >= 4 && !char.IsDigit(nuevoTexto[3])) // Tercer carácter debe ser número
            {
                nuevoTexto = nuevoTexto.Substring(0, 3);
            }
            if (nuevoTexto.Length >= 5 && nuevoTexto[4] != '.') // Cuarto carácter debe ser punto
            {
                nuevoTexto = nuevoTexto.Substring(0, 4);
            }

            // Si el texto cambió, actualízalo
            if (tbCodigoRRA.Text != nuevoTexto)
            {
                tbCodigoRRA.Text = nuevoTexto;
                tbCodigoRRA.SelectionStart = Math.Min(selectionStart, tbCodigoRRA.Text.Length);
            }
        }



        private void btnCrearRRA_Click_1(object sender, EventArgs e)
        {

        }

        private void lbAdvertenciaRRA_Click(object sender, EventArgs e)
        {

        }

        private void tbDescripcionRRA_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
