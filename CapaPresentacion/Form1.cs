﻿using System;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {

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

        private void tbClave_Enter(object sender, EventArgs e)
        {
            tbClave.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbClave_Enter_1(object sender, EventArgs e)
        {
            lblContraseñaL.Text = "Password";
            tbClave.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            lblCarrera.Text = "Username";
            tbUsuario.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbUsuarioReg_Enter(object sender, EventArgs e)
        {
            lblCarreraR.Text = "Username";
            tbUsuarioReg.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbClaveReg_Enter(object sender, EventArgs e)
        {
            lblContraseñaR.Text = "Password";

            tbClaveReg.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void btnRegistrarseReg_Click(object sender, EventArgs e)
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
            lblContraseñaR2.Text = "Confirm Password";

            tbClaveConfirmReg.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbPEA_Enter(object sender, EventArgs e)
        {
            lblPEA.Text = "PEA";

            tbPEA.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

        }

        private void tbCorreo_Enter(object sender, EventArgs e)
        {
            lblEmail.Text = "Email";

            tbCorreo.Text = ""; // Vacía el contenido del TextBox al recibir el foco.

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
    }
}
