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
using Guna.UI2.WinForms;

namespace CapaPresentacion.CRUD
{
    public partial class FormObjetivoEuraceCrud : Form
    {
        private bool isDragging = false;
        private Point initialMousePosition;
        private ObjetivoEurace objetivoEditar;
        private ToolTip toolTipCodigo = new ToolTip();
        public FormObjetivoEuraceCrud()
        {
            InitializeComponent();
            btnCrear.Text = "Crear";
            lbAdvertencia.Visible = false;
            lblAccionAsignatura.Text = "Crear Objetivo EUR-ACE";
            toolTipCodigo.SetToolTip(tbCodigo, "Formato válido: X.X.X (Ejemplo: 5.2.1, 12.4.7)");
            tbCodigo.MouseHover += TbCodigo_MouseHover;
        }

        public FormObjetivoEuraceCrud(ObjetivoEurace objetivoEurace)
        {
            InitializeComponent();
            btnCrear.Text = "Guardar";
            lbAdvertencia.Visible = false;
            tbCodigo.Text = objetivoEurace.Codigo;
            tbNombre.Text = objetivoEurace.Nombre;
            tbDescripcion.Text = objetivoEurace.Descripcion;
            objetivoEditar = objetivoEurace;
            lblAccionAsignatura.Text = "Editar Objetivo EUR-ACE";
        }

        private void FormObjetivoEuraceCrud_Load(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<Guna2TextBox> listaTextBoxes = new List<Guna2TextBox>
            {
                tbCodigo,
                tbNombre,
                tbDescripcion
            };
            if (btnCrear.Text.Equals("Crear"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {
                    // 3. Verificar si está vacío o nulo
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        // Cambiar color del borde a rojo
                        txt.BorderColor = Color.FromArgb(241, 90, 109);
                        camposCompletos = false;
                    }
                    else
                    {

                    }
                }
                if (camposCompletos)
                {
                    ObjetivoEurace objetivo = new ObjetivoEurace();
                    objetivo.Codigo = tbCodigo.Text;
                    objetivo.Nombre = tbNombre.Text;
                    objetivo.Descripcion = tbDescripcion.Text;
                    ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();
                    objetivoEuraceNeg.InsertarObjetivoEurace(objetivo);
                    // Metodo de la capa de negocio para guardar la asignatura creada

                    this.Close();
                }
                else
                {
                    lbAdvertencia.Text = "Debe completar todos los campos.";
                    lbAdvertencia.Visible = true;
                }



            }
            else if (btnCrear.Text.Equals("Guardar"))
            {
                bool camposCompletos = true;
                foreach (var txt in listaTextBoxes)
                {
                    // 3. Verificar si está vacío o nulo
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        // Cambiar color del borde a rojo
                        txt.BorderColor = Color.FromArgb(241, 90, 109);
                        camposCompletos = false;
                    }
                    else
                    {

                    }
                }
                if (camposCompletos)
                {
                    ObjetivoEurace objetivo = objetivoEditar;
                    objetivo.Codigo = tbCodigo.Text;
                    objetivo.Nombre = tbNombre.Text;
                    objetivo.Descripcion = tbDescripcion.Text;
                    ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();
                    objetivoEuraceNeg.ActualizarObjetivoEurace(objetivo);
                    // Metodo de la capa de negocio para guardar la asignatura editada

                    this.Close();
                }
                else
                {
                    lbAdvertencia.Text = "Debe completar todos los campos.";
                    lbAdvertencia.Visible = true;
                }

            }
        }

        private void tbCodigo_Enter(object sender, EventArgs e)
        {
            tbCodigo.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbNombre_Enter(object sender, EventArgs e)
        {
            tbNombre.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void tbDescripcion_Enter(object sender, EventArgs e)
        {
            tbDescripcion.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private void guna2ShadowPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                // Guarda la posición inicial del ratón
                initialMousePosition = e.Location;
            }
        }

        private void guna2ShadowPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula la diferencia entre la posición actual y la inicial
                Point currentMousePosition = e.Location;
                int deltaX = currentMousePosition.X - initialMousePosition.X;
                int deltaY = currentMousePosition.Y - initialMousePosition.Y;

                // Mueve el formulario
                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }

        private void guna2ShadowPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
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

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbNombre.SelectionStart;

            // Filtra solo letras y espacios, y convierte a mayúsculas
            string nuevoTexto = new string(tbNombre.Text.Where(c => char.IsLetter(c) || c == ' ').ToArray()).ToUpper();

            // Si el texto cambió, actualízalo
            if (tbNombre.Text != nuevoTexto)
            {
                tbNombre.Text = nuevoTexto;
                tbNombre.SelectionStart = selectionStart > tbNombre.Text.Length ? tbNombre.Text.Length : selectionStart;
            }
        }

        private void tbCodigo_TextChanged(object sender, EventArgs e)
        {
            // Guarda la posición del cursor
            int selectionStart = tbCodigo.SelectionStart;

            // Filtra solo números y puntos
            string nuevoTexto = new string(tbCodigo.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // No permite iniciar con un punto
            if (nuevoTexto.StartsWith("."))
            {
                nuevoTexto = nuevoTexto.TrimStart('.');
            }

            // Permite un máximo de 2 puntos
            int countPuntos = nuevoTexto.Count(c => c == '.');
            if (countPuntos > 2)
            {
                int index = nuevoTexto.LastIndexOf('.');
                nuevoTexto = nuevoTexto.Remove(index, 1); // Elimina el último punto extra
            }

            // Divide en partes y asegura que cada parte tenga solo números
            string[] partes = nuevoTexto.Split('.');

            for (int i = 0; i < partes.Length; i++)
            {
                partes[i] = new string(partes[i].Where(char.IsDigit).ToArray());
            }

            // Reconstruye el formato permitiendo hasta 3 secciones
            nuevoTexto = string.Join(".", partes.Take(3));

            // Si el texto cambió, actualízalo
            if (tbCodigo.Text != nuevoTexto)
            {
                tbCodigo.Text = nuevoTexto;
                tbCodigo.SelectionStart = Math.Min(selectionStart, tbCodigo.Text.Length);
            }
        }
        private void TbCodigo_MouseHover(object sender, EventArgs e)
        {
            toolTipCodigo.Show("Formato válido: X.X.X (Ejemplo: 5.2.1, 12.4.7)", tbCodigo, 0, -20, 3000);
        }

    }
}
