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
    public partial class FormRelaciónRresultadosAprendizajeAsignatura_x_PerfilEgreso : Form
    {
        Carrera carrera;


        private ResultadoAprendizaje[] _perfilEgreso;
        private ResultadoAprendizajeAsignatura[] _raa;

        public FormRelaciónRresultadosAprendizajeAsignatura_x_PerfilEgreso()
        {
            InitializeComponent();
        }

        public FormRelaciónRresultadosAprendizajeAsignatura_x_PerfilEgreso(Carrera carrera)
        {
            InitializeComponent();
            this.carrera = carrera;
        }

        private void FormRelaciónRresultadosAprendizajeAsignatura_x_PerfilEgreso_Load(object sender, EventArgs e)
        {
            // Instanciar las clases de la capa de negocio para obtener datos.
            ResultadoAprendizajeAsignaturaNeg resultadoAprendizajeAsignaturaNeg = new ResultadoAprendizajeAsignaturaNeg();
            ResultadoAprendizajeNeg resultadoAprendizajeNeg = new ResultadoAprendizajeNeg();

            // Si la carrera es válida, cargar el ComboBox de asignaturas.
            if (carrera != null)
            {
                AsignaturaNeg asignaturaNeg = new AsignaturaNeg();
                cbbAsignatura.DataSource = asignaturaNeg.ObtenerAsignaturasPorCarrera(carrera.Id);
            }

            // Obtener la asignatura seleccionada en el ComboBox.
            Asignatura selected = cbbAsignatura.SelectedItem as Asignatura;

            // Obtener los datos:
            // - "PerfilEgreso": se usan los datos de ResultadoAprendizaje (para las columnas).
            // - "RAA": se obtienen los resultados de aprendizaje de asignatura (para las filas).
            var perfiles = resultadoAprendizajeNeg.ObtenerResultadosAprendizaje(carrera.Id).ToArray();
            var raa = resultadoAprendizajeAsignaturaNeg.ObtenerResultadosAprendizajeAsignatura(selected.Id).ToArray();

            // Guardar estos arreglos en variables globales para usarlos en el marcado de matches.
            _perfilEgreso = perfiles;
            _raa = raa;

            // Llenar el DataGridView.
            LlenarDataGrid(perfiles, raa);

            // Marcar las celdas que ya tienen un "match" (relación) en la base de datos.
            MarcarMatches();

        }

        private void MarcarMatches()
        {
            MatchResultadoAprendizajeNeg matchNeg = new MatchResultadoAprendizajeNeg();
            List<MatchResultadoAprendizaje> listaMatch = matchNeg.MostrarMatchResultadoAprendizajePorCarrera(carrera.Id);

            foreach (var match in listaMatch)
            {
                // Buscar el índice de la columna correspondiente al perfil.
                // Se utiliza el arreglo _perfilEgreso (que contiene los ResultadoAprendizaje usados para las columnas).
                int columnaIndex = Array.FindIndex(_perfilEgreso, p => p.Id == match.PerfilEgresoId) + 1; // +1 porque la primera columna es la etiqueta

                // Buscar el índice de la fila correspondiente al RAA.
                int filaIndex = Array.FindIndex(_raa, r => r.Id == match.SubResultadoAprendizageAsignaturaId);

                if (filaIndex >= 0 && columnaIndex >= 1)
                {
                    DataGridViewCell celda = dataGridView1.Rows[filaIndex].Cells[columnaIndex];
                    celda.Value = Properties.Resources.x1;  // Imagen que indica match (por ejemplo, una "X")
                    celda.Tag = "x";
                }
            }
        }

        private void LlenarDataGrid(ResultadoAprendizaje[] columnas, ResultadoAprendizajeAsignatura[] filas)
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
            // Agregar la primera columna (etiqueta).
            dataGridView1.Columns.Add(" ", " ");
            // Agregar una columna por cada perfil (columna de match).
            foreach (var columna in columnas)
            {
                var imageColumn = new DataGridViewImageColumn
                {
                    Name = $"{columna.Codigo}:{Environment.NewLine}{columna.Descripcion}",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Add(imageColumn);
            }
            // La primera columna se marca como solo lectura.
            dataGridView1.Columns[0].ReadOnly = true;

            // Agregar filas: cada fila se corresponde con un RAA.
            foreach (var fila in filas)
            {
                DataGridViewRow nuevaFila = new DataGridViewRow();
                nuevaFila.CreateCells(dataGridView1);

                // La primera celda muestra la etiqueta del RAA.
                nuevaFila.Cells[0].Value = $"{fila.Codigo}:{Environment.NewLine}{fila.Descripcion}";
                nuevaFila.Cells[0].Style.Font = new Font("Californian FB", 10.8f, FontStyle.Bold);
                nuevaFila.Cells[0].Style.ForeColor = Color.DimGray;
                nuevaFila.Cells[0].Style.BackColor = Color.FromArgb(242, 245, 250);
                nuevaFila.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                nuevaFila.Cells[0].ReadOnly = true;

                // Las demás celdas se inician con la imagen por defecto (por ejemplo, "nada").
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
            // Nos aseguramos de que el usuario hizo doble clic en una celda de datos (no en la etiqueta)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                int indiceFila = e.RowIndex;
                int indiceColumna = e.ColumnIndex - 1;

                // Seleccionar el "perfil" y el RAA correspondientes
                ResultadoAprendizaje perfilSelected = _perfilEgreso[indiceColumna];
                ResultadoAprendizajeAsignatura raaSelected = _raa[indiceFila];

                // Consultar la capa de negocio para ver si ya existe un match para estos dos elementos.
                MatchResultadoAprendizajeNeg negocio = new MatchResultadoAprendizajeNeg();
                var matchExistente = negocio.MostrarMatchResultadoAprendizajePorCarrera(carrera.Id)
                    .FirstOrDefault(m => m.PerfilEgresoId == perfilSelected.Id &&
                                         m.SubResultadoAprendizageAsignaturaId == raaSelected.Id);

                if (matchExistente == null)
                {
                    // Modo CREACIÓN: No existe un match, se abre el FormComentario2 sin comentario.
                    FormComentario2 comentarioForm = new FormComentario2(perfilSelected, carrera, raaSelected);
                    if (comentarioForm.ShowDialog() == DialogResult.OK)
                    {
                        cell.Value = Properties.Resources.x1;
                        cell.Tag = "x";
                    }
                }
                else
                {
                    // Modo EDICIÓN: Ya existe un match, se abre el FormComentario2 con el comentario actual.
                    FormComentario2 comentarioForm = new FormComentario2(
                        perfilSelected,
                        carrera,
                        raaSelected,
                        matchExistente.Id,
                        matchExistente.NivelAporte  // Se usa NivelAporte como el "comentario"
                    );

                    if (comentarioForm.ShowDialog() == DialogResult.OK)
                    {
                        cell.Value = Properties.Resources.x1;
                    }
                    else if (comentarioForm.DialogResult == DialogResult.Abort)
                    {
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
            e.Graphics.TranslateTransform(0, 470);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Resultados de Aprendizaje de Asignatura", myfont, mybrush, 0, 0);
        }
    }
}
