namespace CapaPresentacion.CRUD
{
    partial class FormRRACRUD
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; de lo contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para el soporte del diseñador: no modifique
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.tbNombreRRA = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbAdvertenciaRRA = new System.Windows.Forms.Label();
            this.guna2ShadowPanelRRA = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2CirclePictureBoxRRA = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblTituloRRA = new System.Windows.Forms.Label();
            this.btnMinRRA = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnCloseRRA = new Guna.UI2.WinForms.Guna2ControlBox();
            this.tbCodigoRRA = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCodigoRRA = new System.Windows.Forms.Label();
            this.labelNombreRRA = new System.Windows.Forms.Label();
            this.btnCrearRRA = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelarRRA = new Guna.UI2.WinForms.Guna2Button();
            this.comboBoxTipoRRA = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelTipoRRA = new System.Windows.Forms.Label();
            this.labelDescripcionRRA = new System.Windows.Forms.Label();
            this.tbDescripcionRRA = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2AnimateWindowRRA = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2ShadowPanelRRA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBoxRRA)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // tbNombreRRA
            // 
            this.tbNombreRRA.Animated = true;
            this.tbNombreRRA.BorderThickness = 2;
            this.tbNombreRRA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNombreRRA.DefaultText = "";
            this.tbNombreRRA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNombreRRA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNombreRRA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNombreRRA.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNombreRRA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNombreRRA.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.tbNombreRRA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.tbNombreRRA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNombreRRA.Location = new System.Drawing.Point(152, 87);
            this.tbNombreRRA.Margin = new System.Windows.Forms.Padding(5);
            this.tbNombreRRA.Name = "tbNombreRRA";
            this.tbNombreRRA.PasswordChar = '\0';
            this.tbNombreRRA.PlaceholderText = "           Asignatura";
            this.tbNombreRRA.SelectedText = "";
            this.tbNombreRRA.Size = new System.Drawing.Size(269, 36);
            this.tbNombreRRA.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbNombreRRA.TabIndex = 40;
            this.tbNombreRRA.TextChanged += new System.EventHandler(this.tbNombreRRA_TextChanged);
            // 
            // lbAdvertenciaRRA
            // 
            this.lbAdvertenciaRRA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbAdvertenciaRRA.AutoSize = true;
            this.lbAdvertenciaRRA.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.lbAdvertenciaRRA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(109)))));
            this.lbAdvertenciaRRA.Location = new System.Drawing.Point(101, 529);
            this.lbAdvertenciaRRA.Name = "lbAdvertenciaRRA";
            this.lbAdvertenciaRRA.Size = new System.Drawing.Size(282, 23);
            this.lbAdvertenciaRRA.TabIndex = 38;
            this.lbAdvertenciaRRA.Text = "Debe completar todos los campos";
            this.lbAdvertenciaRRA.Click += new System.EventHandler(this.lbAdvertenciaRRA_Click);
            // 
            // guna2ShadowPanelRRA
            // 
            this.guna2ShadowPanelRRA.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanelRRA.Controls.Add(this.guna2CirclePictureBoxRRA);
            this.guna2ShadowPanelRRA.Controls.Add(this.lblTituloRRA);
            this.guna2ShadowPanelRRA.Controls.Add(this.btnMinRRA);
            this.guna2ShadowPanelRRA.Controls.Add(this.btnCloseRRA);
            this.guna2ShadowPanelRRA.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanelRRA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.guna2ShadowPanelRRA.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanelRRA.Name = "guna2ShadowPanelRRA";
            this.guna2ShadowPanelRRA.Radius = 5;
            this.guna2ShadowPanelRRA.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanelRRA.Size = new System.Drawing.Size(512, 63);
            this.guna2ShadowPanelRRA.TabIndex = 25;
            // 
            // guna2CirclePictureBoxRRA
            // 
            this.guna2CirclePictureBoxRRA.Image = global::CapaPresentacion.Properties.Resources.BuhoBlnaco;
            this.guna2CirclePictureBoxRRA.ImageRotate = 0F;
            this.guna2CirclePictureBoxRRA.Location = new System.Drawing.Point(12, 3);
            this.guna2CirclePictureBoxRRA.Name = "guna2CirclePictureBoxRRA";
            this.guna2CirclePictureBoxRRA.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBoxRRA.Size = new System.Drawing.Size(45, 57);
            this.guna2CirclePictureBoxRRA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBoxRRA.TabIndex = 26;
            this.guna2CirclePictureBoxRRA.TabStop = false;
            // 
            // lblTituloRRA
            // 
            this.lblTituloRRA.AutoSize = true;
            this.lblTituloRRA.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloRRA.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTituloRRA.ForeColor = System.Drawing.Color.White;
            this.lblTituloRRA.Location = new System.Drawing.Point(63, 15);
            this.lblTituloRRA.Name = "lblTituloRRA";
            this.lblTituloRRA.Size = new System.Drawing.Size(153, 32);
            this.lblTituloRRA.TabIndex = 30;
            this.lblTituloRRA.Text = "RAA CRUD";
            // 
            // btnMinRRA
            // 
            this.btnMinRRA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinRRA.BackColor = System.Drawing.Color.Transparent;
            this.btnMinRRA.BackgroundImage = global::CapaPresentacion.Properties.Resources.CircleWithe;
            this.btnMinRRA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinRRA.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinRRA.FillColor = System.Drawing.Color.Transparent;
            this.btnMinRRA.IconColor = System.Drawing.Color.DimGray;
            this.btnMinRRA.Location = new System.Drawing.Point(434, 15);
            this.btnMinRRA.Name = "btnMinRRA";
            this.btnMinRRA.Size = new System.Drawing.Size(30, 30);
            this.btnMinRRA.TabIndex = 8;
            // 
            // btnCloseRRA
            // 
            this.btnCloseRRA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseRRA.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseRRA.BackgroundImage = global::CapaPresentacion.Properties.Resources.CircleWithe;
            this.btnCloseRRA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseRRA.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseRRA.IconColor = System.Drawing.Color.DimGray;
            this.btnCloseRRA.Location = new System.Drawing.Point(470, 15);
            this.btnCloseRRA.Name = "btnCloseRRA";
            this.btnCloseRRA.Size = new System.Drawing.Size(30, 30);
            this.btnCloseRRA.TabIndex = 7;
            // 
            // tbCodigoRRA
            // 
            this.tbCodigoRRA.Animated = true;
            this.tbCodigoRRA.BackColor = System.Drawing.SystemColors.Control;
            this.tbCodigoRRA.BorderThickness = 2;
            this.tbCodigoRRA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCodigoRRA.DefaultText = "";
            this.tbCodigoRRA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCodigoRRA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCodigoRRA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCodigoRRA.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCodigoRRA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCodigoRRA.Font = new System.Drawing.Font("Californian FB", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodigoRRA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.tbCodigoRRA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCodigoRRA.Location = new System.Drawing.Point(152, 156);
            this.tbCodigoRRA.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tbCodigoRRA.Name = "tbCodigoRRA";
            this.tbCodigoRRA.PasswordChar = '\0';
            this.tbCodigoRRA.PlaceholderText = "Código de la Asignatura";
            this.tbCodigoRRA.SelectedText = "";
            this.tbCodigoRRA.Size = new System.Drawing.Size(269, 36);
            this.tbCodigoRRA.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.tbCodigoRRA.TabIndex = 21;
            this.tbCodigoRRA.TextChanged += new System.EventHandler(this.tbCodigoRRA_TextChanged_1);
            // 
            // lblCodigoRRA
            // 
            this.lblCodigoRRA.AutoSize = true;
            this.lblCodigoRRA.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigoRRA.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoRRA.ForeColor = System.Drawing.Color.DimGray;
            this.lblCodigoRRA.Location = new System.Drawing.Point(12, 163);
            this.lblCodigoRRA.Name = "lblCodigoRRA";
            this.lblCodigoRRA.Size = new System.Drawing.Size(98, 29);
            this.lblCodigoRRA.TabIndex = 26;
            this.lblCodigoRRA.Text = "Código:";
            // 
            // labelNombreRRA
            // 
            this.labelNombreRRA.AutoSize = true;
            this.labelNombreRRA.BackColor = System.Drawing.Color.Transparent;
            this.labelNombreRRA.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.labelNombreRRA.ForeColor = System.Drawing.Color.DimGray;
            this.labelNombreRRA.Location = new System.Drawing.Point(12, 87);
            this.labelNombreRRA.Name = "labelNombreRRA";
            this.labelNombreRRA.Size = new System.Drawing.Size(132, 29);
            this.labelNombreRRA.TabIndex = 27;
            this.labelNombreRRA.Text = "Asignatura:";
            // 
            // btnCrearRRA
            // 
            this.btnCrearRRA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCrearRRA.Animated = true;
            this.btnCrearRRA.AutoRoundedCorners = true;
            this.btnCrearRRA.BackColor = System.Drawing.Color.Transparent;
            this.btnCrearRRA.BorderRadius = 23;
            this.btnCrearRRA.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCrearRRA.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrearRRA.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrearRRA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrearRRA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrearRRA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCrearRRA.Font = new System.Drawing.Font("Californian FB", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnCrearRRA.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCrearRRA.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(109)))));
            this.btnCrearRRA.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCrearRRA.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCrearRRA.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCrearRRA.IndicateFocus = true;
            this.btnCrearRRA.Location = new System.Drawing.Point(91, 571);
            this.btnCrearRRA.Name = "btnCrearRRA";
            this.btnCrearRRA.Size = new System.Drawing.Size(138, 48);
            this.btnCrearRRA.TabIndex = 29;
            this.btnCrearRRA.Text = "Guardar";
            this.btnCrearRRA.UseTransparentBackground = true;
            this.btnCrearRRA.Click += new System.EventHandler(this.btnCrearRRA_Click_1);
            // 
            // btnCancelarRRA
            // 
            this.btnCancelarRRA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelarRRA.Animated = true;
            this.btnCancelarRRA.AutoRoundedCorners = true;
            this.btnCancelarRRA.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelarRRA.BorderRadius = 23;
            this.btnCancelarRRA.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancelarRRA.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelarRRA.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelarRRA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelarRRA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelarRRA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCancelarRRA.Font = new System.Drawing.Font("Californian FB", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnCancelarRRA.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelarRRA.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(109)))));
            this.btnCancelarRRA.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(40)))), ((int)(((byte)(58)))));
            this.btnCancelarRRA.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancelarRRA.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCancelarRRA.IndicateFocus = true;
            this.btnCancelarRRA.Location = new System.Drawing.Point(260, 571);
            this.btnCancelarRRA.Name = "btnCancelarRRA";
            this.btnCancelarRRA.Size = new System.Drawing.Size(138, 48);
            this.btnCancelarRRA.TabIndex = 30;
            this.btnCancelarRRA.Text = "Cancelar";
            this.btnCancelarRRA.UseTransparentBackground = true;
            // 
            // comboBoxTipoRRA
            // 
            this.comboBoxTipoRRA.BackColor = System.Drawing.Color.White;
            this.comboBoxTipoRRA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.comboBoxTipoRRA.BorderRadius = 10;
            this.comboBoxTipoRRA.BorderThickness = 2;
            this.comboBoxTipoRRA.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTipoRRA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoRRA.FocusedColor = System.Drawing.Color.Empty;
            this.comboBoxTipoRRA.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxTipoRRA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.comboBoxTipoRRA.FormattingEnabled = true;
            this.comboBoxTipoRRA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTipoRRA.ItemHeight = 30;
            this.comboBoxTipoRRA.Items.AddRange(new object[] {
            "Destreza",
            "Conocimiento",
            "Actitud"});
            this.comboBoxTipoRRA.Location = new System.Drawing.Point(152, 222);
            this.comboBoxTipoRRA.Name = "comboBoxTipoRRA";
            this.comboBoxTipoRRA.Size = new System.Drawing.Size(269, 36);
            this.comboBoxTipoRRA.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboBoxTipoRRA.TabIndex = 31;
            // 
            // labelTipoRRA
            // 
            this.labelTipoRRA.AutoSize = true;
            this.labelTipoRRA.BackColor = System.Drawing.Color.Transparent;
            this.labelTipoRRA.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.labelTipoRRA.ForeColor = System.Drawing.Color.DimGray;
            this.labelTipoRRA.Location = new System.Drawing.Point(12, 222);
            this.labelTipoRRA.Name = "labelTipoRRA";
            this.labelTipoRRA.Size = new System.Drawing.Size(69, 29);
            this.labelTipoRRA.TabIndex = 35;
            this.labelTipoRRA.Text = "Tipo:";
            // 
            // labelDescripcionRRA
            // 
            this.labelDescripcionRRA.AutoSize = true;
            this.labelDescripcionRRA.BackColor = System.Drawing.Color.Transparent;
            this.labelDescripcionRRA.Font = new System.Drawing.Font("Californian FB", 15F, System.Drawing.FontStyle.Bold);
            this.labelDescripcionRRA.ForeColor = System.Drawing.Color.DimGray;
            this.labelDescripcionRRA.Location = new System.Drawing.Point(12, 293);
            this.labelDescripcionRRA.Name = "labelDescripcionRRA";
            this.labelDescripcionRRA.Size = new System.Drawing.Size(142, 29);
            this.labelDescripcionRRA.TabIndex = 36;
            this.labelDescripcionRRA.Text = "Descripción";
            // 
            // tbDescripcionRRA
            // 
            this.tbDescripcionRRA.Animated = true;
            this.tbDescripcionRRA.BorderRadius = 10;
            this.tbDescripcionRRA.BorderThickness = 2;
            this.tbDescripcionRRA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDescripcionRRA.DefaultText = "";
            this.tbDescripcionRRA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDescripcionRRA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDescripcionRRA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDescripcionRRA.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDescripcionRRA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDescripcionRRA.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescripcionRRA.ForeColor = System.Drawing.Color.Black;
            this.tbDescripcionRRA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDescripcionRRA.Location = new System.Drawing.Point(17, 324);
            this.tbDescripcionRRA.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tbDescripcionRRA.Multiline = true;
            this.tbDescripcionRRA.Name = "tbDescripcionRRA";
            this.tbDescripcionRRA.PasswordChar = '\0';
            this.tbDescripcionRRA.PlaceholderText = "Escribe aquí...";
            this.tbDescripcionRRA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescripcionRRA.SelectedText = "";
            this.tbDescripcionRRA.Size = new System.Drawing.Size(483, 192);
            this.tbDescripcionRRA.TabIndex = 37;
            // 
            // guna2AnimateWindowRRA
            // 
            this.guna2AnimateWindowRRA.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.guna2AnimateWindowRRA.TargetForm = this;
            // 
            // FormRRACRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 629);
            this.Controls.Add(this.tbDescripcionRRA);
            this.Controls.Add(this.labelDescripcionRRA);
            this.Controls.Add(this.labelTipoRRA);
            this.Controls.Add(this.comboBoxTipoRRA);
            this.Controls.Add(this.btnCancelarRRA);
            this.Controls.Add(this.btnCrearRRA);
            this.Controls.Add(this.labelNombreRRA);
            this.Controls.Add(this.lblCodigoRRA);
            this.Controls.Add(this.guna2ShadowPanelRRA);
            this.Controls.Add(this.lbAdvertenciaRRA);
            this.Controls.Add(this.tbNombreRRA);
            this.Controls.Add(this.tbCodigoRRA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRRACRUD";
            this.Text = "FormRRA";
            this.guna2ShadowPanelRRA.ResumeLayout(false);
            this.guna2ShadowPanelRRA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBoxRRA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox tbNombreRRA;
        private Guna.UI2.WinForms.Guna2TextBox tbCodigoRRA;
        private System.Windows.Forms.Label lbAdvertenciaRRA;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanelRRA;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBoxRRA;
        private System.Windows.Forms.Label lblTituloRRA;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinRRA;
        private Guna.UI2.WinForms.Guna2ControlBox btnCloseRRA;
        private System.Windows.Forms.Label lblCodigoRRA;
        private System.Windows.Forms.Label labelNombreRRA;
        private Guna.UI2.WinForms.Guna2Button btnCrearRRA;
        private Guna.UI2.WinForms.Guna2Button btnCancelarRRA;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTipoRRA;
        private System.Windows.Forms.Label labelTipoRRA;
        private System.Windows.Forms.Label labelDescripcionRRA;
        private Guna.UI2.WinForms.Guna2TextBox tbDescripcionRRA;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindowRRA;
    }
}
