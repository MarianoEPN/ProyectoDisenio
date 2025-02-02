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

namespace CapaPresentacion.MenuOpciones
{
    public partial class FormPerfilEgreso_x_ObjetivosEurase : Form
    {
        private Carrera carrera;
        ObjetivoEurace[] listaObjetivoEurace;
        ResultadoAprendizaje[] listaResultadosAprendizaje;

        public FormPerfilEgreso_x_ObjetivosEurase()
        {
            InitializeComponent();
        }

        public FormPerfilEgreso_x_ObjetivosEurase(Carrera carrera)
        {
            InitializeComponent();
            this.carrera = carrera;
        }

        private void FormPerfilEgreso_x_ObjetivosEurase_Load(object sender, EventArgs e)
        {
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
            ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();
            // Simula datos de la tabla 1 y tabla 2
            var tabla1 = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id).ToArray(); // Nombre de columnas
            var tabla2 = objetivoEuraceNeg.MostrarObjetivoEurace().ToArray(); // Nombre de filas
            listaObjetivoEurace = tabla2;
            listaResultadosAprendizaje = tabla1;

            // Llenar el DataGridView
            LlenarDataGrid(tabla1, tabla2);
        }

        

        private void LlenarDataGrid(ResultadoAprendizaje[] columnas, ObjetivoEurace[] filas)
        {
            // Configuración inicial del DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.ColumnHeadersHeight = 75;
            dataGridView1.RowTemplate.Height = 100;

            // Habilitar el ajuste de texto en las celdas
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Habilitar el ajuste de texto en los encabezados de las columnas
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Configuración de selección y colores
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect; // Solo seleccionar celdas
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray; // Fondo de la celda seleccionada
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White; // Texto de la celda seleccionada

            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.GridColor = Color.WhiteSmoke; // Color de las líneas divisorias
            dataGridView1.BackgroundColor = Color.FromArgb(242, 245, 250);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Californian FB", 10.8f, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Agregar columnas al DataGridView
            dataGridView1.Columns.Add(" ", " ");
            foreach (var columna in columnas)
            {
                var imageColumn = new DataGridViewImageColumn
                {
                    Name = $"{columna.Codigo}:{Environment.NewLine}{columna.Descripcion}",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Add(imageColumn);
            }
            // Configurar la primera columna como de solo lectura
            dataGridView1.Columns[0].ReadOnly = true;

            // Agregar filas al DataGridView
            foreach (var fila in filas)
            {
                var nuevaFila = new DataGridViewRow();
                nuevaFila.CreateCells(dataGridView1);

                // Configuración de las celdas de las filas
                nuevaFila.Cells[0].Value = $"{fila.Codigo}:{Environment.NewLine}{fila.Descripcion}";
                nuevaFila.Cells[0].Style.Font = new Font("Californian FB", 10.8f, FontStyle.Bold);
                nuevaFila.Cells[0].Style.ForeColor = Color.DimGray;
                nuevaFila.Cells[0].Style.BackColor = Color.FromArgb(242, 245, 250);
                nuevaFila.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                nuevaFila.Cells[0].ReadOnly = true; // Hacer la primera celda de solo lectura

                // Configurar contenido de las celdas restantes
                for (int i = 1; i < nuevaFila.Cells.Count; i++)
                {
                    nuevaFila.Cells[i].Value = Properties.Resources.nada;
                    nuevaFila.Cells[i].Tag = null;
                }

                nuevaFila.DividerHeight = 5;
                dataGridView1.Rows.Add(nuevaFila);
            }

            // Ajustar tamaño de columnas y filas para uniformidad
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 120;
            }

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                fila.Height = 80;
            }

            // Limpiar cualquier selección inicial
            dataGridView1.ClearSelection();

            // Asignar evento para manejar doble clic en las celdas
            dataGridView1.CellMouseDoubleClick += DataGridView1_CellMouseDoubleClick;

            // Asignar evento para manejar el formato de las celdas
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Verificar si la celda es de solo lectura
                if (cell.ReadOnly)
                {
                    // Mantener el estilo original de la celda
                    e.CellStyle.BackColor = Color.FromArgb(242, 245, 250);
                    e.CellStyle.ForeColor = Color.DimGray;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(242, 245, 250);
                    e.CellStyle.SelectionForeColor = Color.DimGray;
                }
            }
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1) // Evitar la columna de encabezado de filas
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                int indiceFila = e.RowIndex;
                int indiceColumna = e.ColumnIndex - 1;

                ObjetivoEurace objetivoSelected = listaObjetivoEurace[indiceFila];
                ResultadoAprendizaje resultadoSelected = listaResultadosAprendizaje[indiceColumna];


                // Cambiar entre imagen "nada" y "match"
                if (cell.Tag == null)
                {
                    cell.Value = Properties.Resources.match8; // Mostrar la imagen de match
                    cell.Tag = "x"; // Registrar la lógica como "x"
                    FormsComentario comentario = new FormsComentario(objetivoSelected, carrera, resultadoSelected);
                    comentario.ShowDialog();

                }
                else
                {
                    cell.Value = Properties.Resources.nada; // Restaurar la imagen inicial
                    cell.Tag = null; // Eliminar la marca lógica
                }
            }
        }

        private void labelFila_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Californian FB", 20, FontStyle.Bold);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(33, 40, 58));
            e.Graphics.TranslateTransform(0, 290);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Perfil de Egreso", myfont, mybrush, 0, 0);
        }
    }
}
