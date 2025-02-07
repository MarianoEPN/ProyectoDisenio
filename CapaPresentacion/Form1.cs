using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; // Necesario para SoundPlayer.
using CapaEntidades;
using CapaNegocio;
using System.Web.UI.WebControls;
using Guna;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Codigo para animar ventana Registro
        private Point targetLocationUp = new Point(187, 80);  // Posición objetivo al subir
        private Point targetLocationDown = new Point(187, 650); // Posición objetivo al bajar
        private int step = 20; // Velocidad del movimiento
        
        // Codigo para redondear Ventana

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // height of ellipse
    int nHeightEllipse // width of ellipse
);

        public Form1()
        {
            InitializeComponent();
            // Inicializar ventana redonda
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //
            // Configurar ComboBox para dibujo personalizado
           
            cbCarrera.ItemHeight = 40;
            cbCarrera.DrawMode = DrawMode.OwnerDrawVariable;
            cbCarrera.ItemHeight = 40;
            cbCarrera.MeasureItem += cbCarrera_MeasureItem;
            cbCarrera.DrawItem += cbCarrera_DrawItem;

        }

        // Creando una lista temporal para probar unicamente funcionamiento del login
        ICollection<Usuario> listaUsuarios;
        private void Form1_Load(object sender, EventArgs e)
        {
            UsuarioNeg usuarioNeg = new UsuarioNeg();
            listaUsuarios = usuarioNeg.MostrarUsuario();
            CargarCarreras();

        }

        private void CargarCarreras()
        {
            CarreraNeg carreraNeg = new CarreraNeg();
            List<Carrera> listaCarreras = carreraNeg.MostrarCarrera();

            cbCarrera.DataSource = listaCarreras;
            cbCarrera.SelectedIndex = -1;
        }


        // Apartado para la verificacion de los campos e ingreso del usuario al programa
        private void btnLogin_Click(object sender, EventArgs e)
        {

            //hasta que se implemente adecuadamente la capa de negocio se implementara un metodo para verificar usuarios

            bool verificarUsuario = false;

            if ((tbUsuario.Text == null || tbUsuario.Text == string.Empty))
            {
                tbUsuario.BorderColor = Color.Red;
                if ((tbClave.Text == null || tbClave.Text == string.Empty))
                {
                    
                    tbClave.BorderColor = Color.Red;
                    // Se puede agregar un label que indique completar los campos
                    return;
                }
                return;

            } else
            {
                if ((tbClave.Text == null || tbClave.Text == string.Empty))
                {
                    tbClave.BorderColor = Color.Red;
                    // Se puede agregar un label que indique completar los campos
                    return;
                }
            }         

            foreach (Usuario usuario in listaUsuarios)
            {
               if (tbUsuario.Text.Equals(usuario.Username) && tbClave.Text.Equals(usuario.Clave))
                {
                    // Mensaje para dar a entender que funciono
                    //MessageBox.Show("Acceso condedido");

                    FormLoading _load = new FormLoading(this, usuario);
                    _load.Show();
                    this.Hide();
                    verificarUsuario = true;
                    break;
                }
            }

            if (!verificarUsuario)
            {
                tbUsuario.BorderColor = Color.Red;
                tbClave.BorderColor = Color.Red;
                // Mensaje en un labelpara dar a entender que Usuario y/o contraseña son incorrectos.
                return;
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Movimiento hacia arriba
            if (panelRegistro.Location.Y > targetLocationUp.Y)
            {
                panelRegistro.Location = new Point(
                    panelRegistro.Location.X,
                    Math.Max(panelRegistro.Location.Y - step, targetLocationUp.Y)
                );
            }
            else
            {
                timer1.Stop(); // Detener cuando llegue al objetivo
            }
   
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // Detener el temporizador de subida
            timer2.Start(); // Inicia el temporizador de bajada
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (tbClave.PasswordChar == '*')
            {
                tbClave.PasswordChar = '\0'; // Muestra el texto real.
                pbVista.Image = Properties.Resources.cerradura2; // Cambia a imagen "ojo abierto".
            }
            else
            {
                tbClave.PasswordChar = '*'; // Oculta la contraseña.
                pbVista.Image = Properties.Resources.cerradura1; // Cambia a imagen "ojo cerrado".
            }

        }

        private void pbVista2_Click(object sender, EventArgs e)
        {
            if (tbClaveReg.PasswordChar == '*')
            {
                tbClaveReg.PasswordChar = '\0'; // Muestra el texto real.
                pbVista2.Image = Properties.Resources.cerradura2; // Cambia a imagen "ojo abierto".
            }
            else
            {
                tbClaveReg.PasswordChar = '*'; // Oculta la contraseña.
                pbVista2.Image = Properties.Resources.cerradura1; // Cambia a imagen "ojo cerrado".
            }

        }

       

        private void tbClave_Enter_1(object sender, EventArgs e)
        {
            tbClave.BorderColor = Color.FromArgb(213, 218, 223);
            //lblContraseñaL.Text = "Password";
            //tbClave.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            tbUsuario.BorderColor = Color.FromArgb(213, 218, 223);
            //lblCarrera.Text = "Username";
            //tbUsuario.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbUsuarioReg_Enter(object sender, EventArgs e)
        {


        }

        private void tbClaveReg_Enter(object sender, EventArgs e)
        {

        }

        

        private void pbVista3_Click(object sender, EventArgs e)
        {
            if (tbClaveConfirmReg.PasswordChar == '*')
            {
                tbClaveConfirmReg.PasswordChar = '\0'; // Muestra el texto real.
                pbVista3.Image = Properties.Resources.cerradura2; // Cambia a imagen "ojo abierto".
            }
            else
            {
                tbClaveConfirmReg.PasswordChar = '*'; // Oculta la contraseña.
                pbVista3.Image = Properties.Resources.cerradura1; // Cambia a imagen "ojo cerrado".
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Movimiento hacia abajo
            if (panelRegistro.Location.Y < targetLocationDown.Y)
            {
                panelRegistro.Location = new Point(
                    panelRegistro.Location.X,
                    Math.Min(panelRegistro.Location.Y + step, targetLocationDown.Y)
                );
            }
            else
            {
                timer2.Stop(); // Detener cuando llegue al objetivo
            }
            // Forzar redibujado
            panelRegistro.Refresh();
        }

        private void tbClave_TextChanged(object sender, EventArgs e)
        {
            if (tbClave.PasswordChar != '*')
            {
                tbClave.PasswordChar = '*'; // Muestra el texto real.
            }
        }

        private void tbClaveReg_TextChanged(object sender, EventArgs e)
        {
            if (tbClaveReg.PasswordChar != '*')
            {
                tbClaveReg.PasswordChar = '*'; // Muestra el texto real.
            }
        }

        private void tbClaveConfirmReg_TextChanged(object sender, EventArgs e)
        {
            if (tbClaveConfirmReg.PasswordChar != '*')
            {
                tbClaveConfirmReg.PasswordChar = '*'; // Muestra el texto real.
            }
        }

        private void tbClaveConfirmReg_Enter(object sender, EventArgs e)
        {


        }

        private void tbPEA_Enter(object sender, EventArgs e)
        {

        }

        private void tbCorreo_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer2.Stop(); // Detener el temporizador de bajada
            timer1.Start(); // Inicia el temporizador de subida
        }

        private void linKCreateR_Click(object sender, EventArgs e)
        {
            timer2.Stop(); // Detener el temporizador de bajada
            timer1.Start(); // Inicia el temporizador de subida
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Llama al evento del botón
                btnLogin_Click(sender, e);
                e.Handled = true; // Evita que el evento se propague si es necesario
            }
        }

        private void cbCarrera_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            Carrera carrera = (Carrera)cbCarrera.Items[e.Index];
            string[] lineas = WrapText(carrera.Nombre, 30);

            e.ItemHeight = lineas.Length * 18;
            cbCarrera.DropDownWidth = 300;
        }
        private void cbCarrera_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                Carrera carrera = (Carrera)cbCarrera.Items[e.Index];
                string[] lineas = WrapText(carrera.Nombre, 30);

                for (int i = 0; i < lineas.Length; i++)
                {
                    e.Graphics.DrawString(lineas[i], e.Font, brush, e.Bounds.X, e.Bounds.Y + (i * 18));
                }
            }
            e.DrawFocusRectangle();
        }
        private string[] WrapText(string text, int maxCharsPerLine)
        {
            List<string> lines = new List<string>();
            if (string.IsNullOrWhiteSpace(text)) return new string[] { "" };

            string[] words = text.Split(' ');
            StringBuilder currentLine = new StringBuilder();

            foreach (string word in words)
            {
                if ((currentLine.Length + word.Length) > maxCharsPerLine)
                {
                    lines.Add(currentLine.ToString().Trim());
                    currentLine.Clear();
                }
                currentLine.Append(word + " ");
            }

            if (currentLine.Length > 0)
            {
                lines.Add(currentLine.ToString().Trim());
            }

            return lines.ToArray();
        }

        private void cbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCarrera.SelectedItem is Carrera carreraSeleccionada)
            {
                // Aquí puedes acceder a las propiedades que necesites
                Console.WriteLine($"Seleccionaste: {carreraSeleccionada.Nombre} \n Pensum: {carreraSeleccionada.Pensum}");
            }
        }
        private bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }
        private void btnRegistrarseReg_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado una carrera
                if (cbCarrera.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una carrera");
                    return;
                }

                // Obtener la carrera seleccionada correctamente
                Carrera carreraSeleccionada = (Carrera)cbCarrera.SelectedItem;

                string nombreUsuario = tbUsuarioReg.Text.Trim();
                string correo = tbCorreo.Text.Trim();
                string contraseña = tbClaveReg.Text;
                string confirmarContraseña = tbClaveConfirmReg.Text;

                // Validaciones de campos vacíos
                if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                    string.IsNullOrWhiteSpace(correo) ||
                    string.IsNullOrWhiteSpace(contraseña) ||
                    string.IsNullOrWhiteSpace(confirmarContraseña))
                {
                    MessageBox.Show("Todos los campos deben ser completados");
                    return;
                }

                // Validar formato de correo
                if (!EsCorreoValido(correo))
                {
                    MessageBox.Show("El correo electrónico ingresado no es válido.");
                    return;
                }

                // Validar longitud de la contraseña
                if (contraseña.Length < 8)
                {
                    MessageBox.Show("La contraseña debe contener más de 8 caracteres");
                    return;
                }

                // Validar coincidencia de contraseñas
                if (!contraseña.Equals(confirmarContraseña))
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                    return;
                }

                // Crear el objeto Usuario con los datos correctos
                // Si deseas evitar que se almacene el valor "Usuario Computación" en el campo nombre,
                // puedes reemplazarlo por cadena vacía (o por otro valor) en este punto.
                Usuario usuarioObj = new Usuario
                {
                    // Se puede condicionar el valor; en este ejemplo, si es "Usuario Computación" se asigna vacío.
                    nombre = (nombreUsuario.Equals("Usuario Computación", StringComparison.OrdinalIgnoreCase)) ? "" : nombreUsuario,
                    Username = nombreUsuario,
                    // Se asigna el nombre de la carrera (tal como se selecciona en el ComboBox)
                    carrera = carreraSeleccionada.Nombre,
                    Correo = correo,
                    Clave = contraseña
                };

                // Registrar usuario utilizando la capa de negocio.
                UsuarioNeg negocio = new UsuarioNeg();
                bool resultado = negocio.RegistrarUsuario(usuarioObj);

                if (resultado)
                {
                    MessageBox.Show("Usuario registrado correctamente.");
                    // Limpiar campos después del registro exitoso
                    LimpiarCamposRegistro();
                    // Volver a la pantalla de login
                    btnVolver_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al registrar usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }


        private void LimpiarCamposRegistro()
        {
            tbUsuarioReg.Text = string.Empty;
            tbCorreo.Text = string.Empty;
            tbClaveReg.Text = string.Empty;
            tbClaveConfirmReg.Text = string.Empty;
            cbCarrera.SelectedIndex = -1;
        }

        private void tbCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUsuarioReg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
