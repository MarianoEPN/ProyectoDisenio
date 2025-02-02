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

        public FormsComentario()
        {
            InitializeComponent();
        }

        public FormsComentario(ObjetivoEurace objetivoEurace, Carrera carrera, ResultadoAprendizaje resultadoAprendizaje)
        {
            InitializeComponent();
            this.objetivoEurace = objetivoEurace;
            this.carrera = carrera;
            this.resultadoAprendizaje = resultadoAprendizaje;
        }

        private void FormsComentario_Load(object sender, EventArgs e)
        {
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
            ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();

            gcmbObjetivoEurace.DataSource = null;
            gcmbResutadoAprendizaje.DataSource = null;
            gcmbResutadoAprendizaje.DataSource = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id);
            gcmbObjetivoEurace.DataSource = objetivoEuraceNeg.MostrarObjetivoEurace();

            int indiceFila = objetivoEuraceNeg.MostrarObjetivoEurace().FindIndex(objetivo => objetivo.Id == objetivoEurace.Id);
            gcmbObjetivoEurace.SelectedIndex = indiceFila;
            int indiceColumna = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id)
                                .FindIndex(resultado => resultado.Id == resultadoAprendizaje.Id);
            gcmbResutadoAprendizaje.SelectedIndex = indiceColumna;

            lbAdvertencia.Visible = false;

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
            bool camposCompletos = true;
            if (string.IsNullOrEmpty(tbComentario.Text))
            {
                // Cambiar color del borde a rojo
                tbComentario.BorderColor = Color.FromArgb(241, 90, 109);
                camposCompletos = false;
                lbAdvertencia.Text = "Debe completar todos los campos.";
                lbAdvertencia.Visible = true;
            }

            if (camposCompletos)
            {
                EuraceResultadoAprendizaje euraceResultadoAprendizaje = new EuraceResultadoAprendizaje();
                euraceResultadoAprendizaje.Comentario = tbComentario.Text;
                ObjetivoEurace objetivoSelected = gcmbObjetivoEurace.SelectedItem as ObjetivoEurace;
                ResultadoAprendizaje resultadoSelected = gcmbResutadoAprendizaje.SelectedItem as ResultadoAprendizaje;
                EuraceResultadoAprendizajeNeg euraceResultadoAprendizajeNeg = new EuraceResultadoAprendizajeNeg();
                euraceResultadoAprendizajeNeg.InsertarEuraceResultadoAprendizaje(euraceResultadoAprendizaje, objetivoSelected, resultadoSelected);
                MessageBox.Show("Se ingreso correctamente!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lbAdvertencia.Text = "Debe completar todos los campos.";
                lbAdvertencia.Visible = true;
            }
        }
    }
}
