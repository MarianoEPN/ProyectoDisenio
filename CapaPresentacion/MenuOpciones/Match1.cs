using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Match1 : Form
    {
        public Match1()
        {
            InitializeComponent();

        }

        private void Match1_Load(object sender, EventArgs e)
        {
            // Simula datos de la tabla 1 y tabla 2
            var tabla1 = new[] { "Columna1", "Columna2", "Columna3", "Columna6", "Columna7", "Columna8", "Columna9", "Columna10" }; // Nombre de columnas
            var tabla2 = new[] { "Fila1", "Fila2", "Fila3", "Fila4", "Fila5", "Fila6", "Fila7", "Fila8", "Fila9" }; // Nombre de filas

            // Llenar el DataGridView
            LlenarDataGrid(tabla1, tabla2);


        }



        private void LlenarDataGrid(string[] columnas, string[] filas)
        {
            // Configuración inicial del DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.RowTemplate.Height = 100;

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
                    Name = columna,
                    HeaderText = columna,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Add(imageColumn);
            }

            // Agregar filas al DataGridView
            foreach (var fila in filas)
            {
                var nuevaFila = new DataGridViewRow();
                nuevaFila.CreateCells(dataGridView1);

                // Configuración de las celdas de las filas
                nuevaFila.Cells[0].Value = fila;
                nuevaFila.Cells[0].Style.Font = new Font("Californian FB", 10.8f, FontStyle.Bold);
                nuevaFila.Cells[0].Style.ForeColor = Color.DimGray;
                nuevaFila.Cells[0].Style.BackColor = Color.FromArgb(242, 245, 250);
                nuevaFila.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                column.Width = 100;
            }

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                fila.Height = 60;
            }

            // Limpiar cualquier selección inicial
            dataGridView1.ClearSelection();

            // Asignar evento para manejar doble clic en las celdas
            dataGridView1.CellMouseDoubleClick += DataGridView1_CellMouseDoubleClick;
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1) // Evitar la columna de encabezado de filas
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Cambiar entre imagen "nada" y "match"
                if (cell.Tag == null)
                {
                    cell.Value = Properties.Resources.match8; // Mostrar la imagen de match
                    cell.Tag = "x"; // Registrar la lógica como "x"
                }
                else
                {
                    cell.Value = Properties.Resources.nada; // Restaurar la imagen inicial
                    cell.Tag = null; // Eliminar la marca lógica
                }
            }
        }
      
    }
}
