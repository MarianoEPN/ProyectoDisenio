namespace CapaPresentacion
{
    partial class FormMoldeCrud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.tbDescripcion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTipo = new System.Windows.Forms.Label();
            this.comboBoxTipo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            this.labelNivel = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblAccionAsignatura = new System.Windows.Forms.Label();
            this.btnMin = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lbAdvertencia = new System.Windows.Forms.Label();
            this.tbNivel = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbNombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbCodigo = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Animated = true;
            this.tbDescripcion.BorderRadius = 10;
            this.tbDescripcion.BorderThickness = 2;
            this.tbDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDescripcion.DefaultText = "";
            this.tbDescripcion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDescripcion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDescripcion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDescripcion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDescripcion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDescripcion.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcion.ForeColor = System.Drawing.Color.Black;
            this.tbDescripcion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDescripcion.Location = new System.Drawing.Point(64, 528);
            this.tbDescripcion.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.PasswordChar = '\0';
            this.tbDescripcion.PlaceholderText = "Escribe aquí...";
            this.tbDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescripcion.SelectedText = "";
            this.tbDescripcion.Size = new System.Drawing.Size(388, 215);
            this.tbDescripcion.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(82, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 29);
            this.label3.TabIndex = 50;
            this.label3.Text = "Descripción";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.BackColor = System.Drawing.Color.Transparent;
            this.labelTipo.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.labelTipo.ForeColor = System.Drawing.Color.DimGray;
            this.labelTipo.Location = new System.Drawing.Point(88, 443);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(64, 29);
            this.labelTipo.TabIndex = 49;
            this.labelTipo.Text = "Tipo";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.BackColor = System.Drawing.Color.White;
            this.comboBoxTipo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.comboBoxTipo.BorderRadius = 10;
            this.comboBoxTipo.BorderThickness = 2;
            this.comboBoxTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FocusedColor = System.Drawing.Color.Empty;
            this.comboBoxTipo.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTipo.ItemHeight = 30;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Destreza",
            "Actitud",
            "Conocimiento"});
            this.comboBoxTipo.Location = new System.Drawing.Point(192, 436);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(224, 36);
            this.comboBoxTipo.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboBoxTipo.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Animated = true;
            this.btnCancelar.AutoRoundedCorners = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderRadius = 23;
            this.btnCancelar.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCancelar.Font = new System.Drawing.Font("Californian FB", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(109)))));
            this.btnCancelar.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCancelar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancelar.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCancelar.IndicateFocus = true;
            this.btnCancelar.Location = new System.Drawing.Point(268, 361);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 48);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseTransparentBackground = true;
            // 
            // btnCrear
            // 
            this.btnCrear.Animated = true;
            this.btnCrear.AutoRoundedCorners = true;
            this.btnCrear.BackColor = System.Drawing.Color.Transparent;
            this.btnCrear.BorderRadius = 23;
            this.btnCrear.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCrear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCrear.Font = new System.Drawing.Font("Californian FB", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnCrear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCrear.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(109)))));
            this.btnCrear.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCrear.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCrear.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCrear.IndicateFocus = true;
            this.btnCrear.Location = new System.Drawing.Point(106, 361);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(138, 48);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.UseTransparentBackground = true;
            // 
            // labelNivel
            // 
            this.labelNivel.AutoSize = true;
            this.labelNivel.BackColor = System.Drawing.Color.Transparent;
            this.labelNivel.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.labelNivel.ForeColor = System.Drawing.Color.DimGray;
            this.labelNivel.Location = new System.Drawing.Point(82, 248);
            this.labelNivel.Name = "labelNivel";
            this.labelNivel.Size = new System.Drawing.Size(70, 29);
            this.labelNivel.TabIndex = 45;
            this.labelNivel.Text = "Nivel";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.BackColor = System.Drawing.Color.Transparent;
            this.labelNombre.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.labelNombre.ForeColor = System.Drawing.Color.DimGray;
            this.labelNombre.Location = new System.Drawing.Point(72, 183);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(102, 29);
            this.labelNombre.TabIndex = 44;
            this.labelNombre.Text = "Nombre";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.lblCodigo.Location = new System.Drawing.Point(72, 105);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(93, 29);
            this.lblCodigo.TabIndex = 43;
            this.lblCodigo.Text = "Código";
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2ShadowPanel2.Controls.Add(this.lblAccionAsignatura);
            this.guna2ShadowPanel2.Controls.Add(this.btnMin);
            this.guna2ShadowPanel2.Controls.Add(this.btnClose);
            this.guna2ShadowPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 5;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(500, 63);
            this.guna2ShadowPanel2.TabIndex = 42;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::CapaPresentacion.Properties.Resources.BuhoBlnaco;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(12, 3);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(45, 57);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 26;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lblAccionAsignatura
            // 
            this.lblAccionAsignatura.AutoSize = true;
            this.lblAccionAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.lblAccionAsignatura.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccionAsignatura.ForeColor = System.Drawing.Color.White;
            this.lblAccionAsignatura.Location = new System.Drawing.Point(63, 15);
            this.lblAccionAsignatura.Name = "lblAccionAsignatura";
            this.lblAccionAsignatura.Size = new System.Drawing.Size(231, 32);
            this.lblAccionAsignatura.TabIndex = 28;
            this.lblAccionAsignatura.Text = "Nonbre del CRUD";
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::CapaPresentacion.Properties.Resources.CircleWithe;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMin.FillColor = System.Drawing.Color.Transparent;
            this.btnMin.IconColor = System.Drawing.Color.DimGray;
            this.btnMin.Location = new System.Drawing.Point(422, 15);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.TabIndex = 8;
            this.btnMin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::CapaPresentacion.Properties.Resources.CircleWithe;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.IconColor = System.Drawing.Color.DimGray;
            this.btnClose.Location = new System.Drawing.Point(458, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // lbAdvertencia
            // 
            this.lbAdvertencia.AutoSize = true;
            this.lbAdvertencia.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.lbAdvertencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(109)))));
            this.lbAdvertencia.Location = new System.Drawing.Point(113, 316);
            this.lbAdvertencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAdvertencia.Name = "lbAdvertencia";
            this.lbAdvertencia.Size = new System.Drawing.Size(282, 23);
            this.lbAdvertencia.TabIndex = 41;
            this.lbAdvertencia.Text = "Debe completar todos los campos";
            // 
            // tbNivel
            // 
            this.tbNivel.Animated = true;
            this.tbNivel.BorderThickness = 2;
            this.tbNivel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNivel.DefaultText = "";
            this.tbNivel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNivel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNivel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNivel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNivel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNivel.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.tbNivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.tbNivel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNivel.Location = new System.Drawing.Point(192, 248);
            this.tbNivel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tbNivel.Name = "tbNivel";
            this.tbNivel.PasswordChar = '\0';
            this.tbNivel.PlaceholderText = " 0";
            this.tbNivel.SelectedText = "";
            this.tbNivel.Size = new System.Drawing.Size(49, 36);
            this.tbNivel.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbNivel.TabIndex = 3;
            this.tbNivel.TextChanged += new System.EventHandler(this.tbNivel_TextChanged);
            // 
            // tbNombre
            // 
            this.tbNombre.Animated = true;
            this.tbNombre.BorderThickness = 2;
            this.tbNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNombre.DefaultText = "";
            this.tbNombre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNombre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNombre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNombre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNombre.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.tbNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.tbNombre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNombre.Location = new System.Drawing.Point(192, 183);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.PasswordChar = '\0';
            this.tbNombre.PlaceholderText = "MATERIA";
            this.tbNombre.SelectedText = "";
            this.tbNombre.Size = new System.Drawing.Size(224, 36);
            this.tbNombre.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbNombre.TabIndex = 2;
            this.tbNombre.TextChanged += new System.EventHandler(this.tbNombre_TextChanged);
            // 
            // tbCodigo
            // 
            this.tbCodigo.Animated = true;
            this.tbCodigo.BackColor = System.Drawing.SystemColors.Control;
            this.tbCodigo.BorderThickness = 2;
            this.tbCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCodigo.DefaultText = "";
            this.tbCodigo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCodigo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCodigo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCodigo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCodigo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCodigo.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.tbCodigo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCodigo.Location = new System.Drawing.Point(192, 102);
            this.tbCodigo.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tbCodigo.Name = "tbCodigo";
            this.tbCodigo.PasswordChar = '\0';
            this.tbCodigo.PlaceholderText = "FIEED100";
            this.tbCodigo.SelectedText = "";
            this.tbCodigo.Size = new System.Drawing.Size(224, 36);
            this.tbCodigo.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbCodigo.TabIndex = 1;
            this.tbCodigo.TextChanged += new System.EventHandler(this.tbCodigo_TextChanged);
            // 
            // FormMoldeCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(500, 750);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.labelNivel);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.lbAdvertencia);
            this.Controls.Add(this.tbNivel);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(700, 900);
            this.Name = "FormMoldeCrud";
            this.Text = "FormAsignatura";
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2TextBox tbDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTipo;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTipo;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
        private System.Windows.Forms.Label labelNivel;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label lblCodigo;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label lblAccionAsignatura;
        private Guna.UI2.WinForms.Guna2ControlBox btnMin;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lbAdvertencia;
        private Guna.UI2.WinForms.Guna2TextBox tbNivel;
        private Guna.UI2.WinForms.Guna2TextBox tbNombre;
        private Guna.UI2.WinForms.Guna2TextBox tbCodigo;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}