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
using Guna.UI2.WinForms;

namespace CapaPresentacion.CRUD
{
    public partial class FormRRACRUD : Form
    {
        // Variables para almacenar la posición relativa del ratón en el panel
        private bool isDragging = false;
        private Point initialMousePosition;

        public FormRRACRUD()
        {
            InitializeComponent();
            lbAdvertenciaRRA.Visible = false;
        }

        public FormRRACRUD(Carrera carrera)
        {
            InitializeComponent();
            lbAdvertenciaRRA.Visible = false;
        }

        public FormRRACRUD(Carrera carrera, Asignatura asignatura)
        {
            InitializeComponent();
            lbAdvertenciaRRA.Visible = false;
            //tbCodigo.Text = asignatura.Nombre;
            //tbCodigo.Text = asignatura.Codigo;
            //tbNivel.Text = Convert.ToString(asignatura.Nivel);
            
            Asignatura = asignatura;
            // Seteamos el nombre de la asignatura
            //tbNombreRRA.Text = asignatura.Nombre; 
            tbNombreRRA.Enabled = false; // Bloqueamos para que no se pueda editar

            // Seteamos el código de la asignatura
            //tbCodigoRRA.Text = asignatura.Codigo; 
            tbCodigoRRA.Enabled = false; // Bloqueamos para que no se pueda editar

            // Asignamos los valores en el comboBoxTipoRRA si es necesario (en caso de que haya información predefinida)
            // Si se requiere algo específico en comboBoxTipoRRA, agregamos aquí el código correspondiente.
            comboBoxTipoRRA.SelectedIndex = 0; // O seleccionamos el valor correspondiente
        }


        private Asignatura Asignatura { get; set; }

        private void btnCancelarRRA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTituloRRA_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    string tipoObjetivo = comboBoxTipoRRA.SelectedItem.ToString(); // O el valor que quieras obtener del ComboBox
                    // Llamamos al método de la capa de negocio para guardar la asignatura y su descripción

                    MessageBox.Show("Se ha guardado con éxito el objetivo de aprendizaje de la asignatura.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //Asignatura asignatura = AsignaturaEditar;
                    
                    // Guardamos la descripción del objetivo de aprendizaje
                    string descripcionObjetivo = tbDescripcionRRA.Text;
                    string tipoObjetivo = comboBoxTipoRRA.SelectedItem.ToString();

                    // Llamamos al método de la capa de negocio para guardar la asignatura editada
                    // Aquí debes integrar la lógica para actualizar la asignatura

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

    // Convierte el texto a mayúsculas y elimina espacios
    string nuevoTexto = tbCodigoRRA.Text.Replace(" ", "").ToUpper();

    // Si el texto cambió, actualízalo
    if (tbCodigoRRA.Text != nuevoTexto)
    {
        tbCodigoRRA.Text = nuevoTexto;
        tbCodigoRRA.SelectionStart = selectionStart > tbCodigoRRA.Text.Length ? tbCodigoRRA.Text.Length : selectionStart;
    }
}

        private void btnCrearRRA_Click_1(object sender, EventArgs e)
        {

        }

        private void lbAdvertenciaRRA_Click(object sender, EventArgs e)
        {

        }
    }
}
