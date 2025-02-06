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
            // Inicializar servicios de la capa de negocios
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();
            ObjetivoEuraceNeg objetivoEuraceNeg = new ObjetivoEuraceNeg();
            EuraceResultadoAprendizajeNeg eraNeg = new EuraceResultadoAprendizajeNeg(); // Servicio de relaciones

            // Obtener datos para columnas y filas
            var resultadosAprendizaje = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id).ToArray();
            var objetivosEurace = objetivoEuraceNeg.MostrarObjetivoEurace().ToArray();

            // Guardar las listas globalmente para usarlas en otros métodos
            listaObjetivoEurace = objetivosEurace;
            listaResultadosAprendizaje = resultadosAprendizaje;

            // Llenar el DataGridView con los datos obtenidos
            LlenarDataGrid(resultadosAprendizaje, objetivosEurace);

            // Obtener relaciones existentes desde la base de datos para la carrera actual
            List<EuraceResultadoAprendizaje> relacionesExistentes = eraNeg.MostrarEuraceResultadoAprendizajePorCarrera(carrera.Id);

            // Marcar celdas con la imagen "X" en el DataGridView donde exista una relación
            foreach (var relacion in relacionesExistentes)
            {
                // Buscar el índice de la fila (objetivo) y la columna (resultado)
                int filaIndex = Array.FindIndex(listaObjetivoEurace, o => o.Id == relacion.ObjEuraceId);
                int columnaIndex = Array.FindIndex(listaResultadosAprendizaje, r => r.Id == relacion.ResultadoAprendizajeId) + 1; // +1 porque la columna 0 es la etiqueta

                if (filaIndex >= 0 && columnaIndex >= 1)
                {
                    DataGridViewCell celda = dataGridView1.Rows[filaIndex].Cells[columnaIndex];
                    celda.Value = Properties.Resources.x1; // Mostrar la imagen "X"
                    celda.Tag = "x"; // Marcar la celda como que tiene relación
                }
            }
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                int indiceFila = e.RowIndex;
                int indiceColumna = e.ColumnIndex - 1;

                ObjetivoEurace objetivoSelected = listaObjetivoEurace[indiceFila];
                ResultadoAprendizaje resultadoSelected = listaResultadosAprendizaje[indiceColumna];

                // Verificar si ya existe una relación
                EuraceResultadoAprendizajeNeg negocio = new EuraceResultadoAprendizajeNeg();
                var relacionExistente = negocio.BuscarEuraceResultadoAprendizaje(objetivoSelected, resultadoSelected).FirstOrDefault();

                if (relacionExistente == null)
                {
                    // Modo CREACIÓN: Abrir formulario sin comentario
                    FormsComentario comentarioForm = new FormsComentario(objetivoSelected, carrera, resultadoSelected);
                    if (comentarioForm.ShowDialog() == DialogResult.OK)
                    {
                        cell.Value = Properties.Resources.x1;
                        cell.Tag = "x";
                    }
                }
                else
                {

                    // Modo EDICIÓN: Abrir formulario con comentario existente
                    FormsComentario comentarioForm = new FormsComentario(
                        objetivoSelected,
                        carrera,
                        resultadoSelected,
                        relacionExistente.Id,
                        relacionExistente.Comentario
                    );

                    if (comentarioForm.ShowDialog() == DialogResult.OK)
                    {
                        // Actualizar comentario si se editó
                        cell.Value = Properties.Resources.x1;
                    }
                    else if (comentarioForm.DialogResult == DialogResult.Abort)
                    {
                        // Eliminar "X" si se borró la relación
                        cell.Value = Properties.Resources.nada;
                        cell.Tag = null;
                    }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            // Se abre el FormsComentario en modo creación, donde el usuario podrá seleccionar Objetivo y Resultado
            FormsComentario comentarioForm = new FormsComentario(carrera);
            if (comentarioForm.ShowDialog() == DialogResult.OK)
            {
                // Se recuperan los datos seleccionados a partir de los métodos públicos
                ObjetivoEurace objetivoSeleccionado = comentarioForm.GetObjetivoSeleccionado();
                ResultadoAprendizaje resultadoSeleccionado = comentarioForm.GetResultadoSeleccionado();

                // Actualizar el DataGridView: se busca la fila y columna correspondientes
                int filaIndex = Array.FindIndex(listaObjetivoEurace, o => o.Id == objetivoSeleccionado.Id);
                int columnaIndex = Array.FindIndex(listaResultadosAprendizaje, r => r.Id == resultadoSeleccionado.Id) + 1; // +1 porque la columna 0 es la etiqueta

                if (filaIndex >= 0 && columnaIndex >= 1)
                {
                    DataGridViewCell celda = dataGridView1.Rows[filaIndex].Cells[columnaIndex];
                    celda.Value = Properties.Resources.x1; // Asigna la imagen “X”
                    celda.Tag = "x";
                }
            }
        }


    }
}
