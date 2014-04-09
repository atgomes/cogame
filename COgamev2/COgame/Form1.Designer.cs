namespace COgame
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MetNeed = new System.Windows.Forms.TextBox();
            this.DeuNeed = new System.Windows.Forms.TextBox();
            this.CrisNeed = new System.Windows.Forms.TextBox();
            this.CGr = new System.Windows.Forms.RadioButton();
            this.CPe = new System.Windows.Forms.RadioButton();
            this.Calc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NPlan = new System.Windows.Forms.NumericUpDown();
            this.Lista = new System.Windows.Forms.ListBox();
            this.CPlan = new System.Windows.Forms.TextBox();
            this.DPlan = new System.Windows.Forms.TextBox();
            this.MPlan = new System.Windows.Forms.TextBox();
            this.Saida = new System.Windows.Forms.TextBox();
            this.LimTudo = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.ShowMet = new System.Windows.Forms.TextBox();
            this.ShowCris = new System.Windows.Forms.TextBox();
            this.ShowDeu = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manterAcimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inglêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemPos = new System.Windows.Forms.TextBox();
            this.slotPos = new System.Windows.Forms.TextBox();
            this.galaxyPos = new System.Windows.Forms.TextBox();
            this.limpar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.equilibrado = new System.Windows.Forms.RadioButton();
            this.ordemRecursos = new System.Windows.Forms.RadioButton();
            this.ordemLista = new System.Windows.Forms.RadioButton();
            this.insertPlanetName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.modoEcra = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPlan)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetNeed
            // 
            this.MetNeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetNeed.Location = new System.Drawing.Point(25, 60);
            this.MetNeed.Name = "MetNeed";
            this.MetNeed.Size = new System.Drawing.Size(56, 18);
            this.MetNeed.TabIndex = 1;
            this.MetNeed.Tag = "";
            this.MetNeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MetNeed.Enter += new System.EventHandler(this.limpaTexto);
            this.MetNeed.Leave += new System.EventHandler(this.MetNeed_Leave);
            // 
            // DeuNeed
            // 
            this.DeuNeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeuNeed.Location = new System.Drawing.Point(149, 60);
            this.DeuNeed.Name = "DeuNeed";
            this.DeuNeed.Size = new System.Drawing.Size(56, 18);
            this.DeuNeed.TabIndex = 3;
            this.DeuNeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DeuNeed.Enter += new System.EventHandler(this.limpaTexto);
            this.DeuNeed.Leave += new System.EventHandler(this.DeuNeed_Leave);
            // 
            // CrisNeed
            // 
            this.CrisNeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrisNeed.Location = new System.Drawing.Point(87, 60);
            this.CrisNeed.Name = "CrisNeed";
            this.CrisNeed.Size = new System.Drawing.Size(56, 18);
            this.CrisNeed.TabIndex = 2;
            this.CrisNeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CrisNeed.Enter += new System.EventHandler(this.limpaTexto);
            this.CrisNeed.Leave += new System.EventHandler(this.CrisNeed_Leave);
            // 
            // CGr
            // 
            this.CGr.AutoSize = true;
            this.CGr.Checked = true;
            this.CGr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CGr.Location = new System.Drawing.Point(22, 19);
            this.CGr.Name = "CGr";
            this.CGr.Size = new System.Drawing.Size(118, 17);
            this.CGr.TabIndex = 20;
            this.CGr.TabStop = true;
            this.CGr.Text = "Cargueiros Grandes";
            this.CGr.UseVisualStyleBackColor = true;
            this.CGr.Click += new System.EventHandler(this.actualizar);
            // 
            // CPe
            // 
            this.CPe.AutoSize = true;
            this.CPe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPe.Location = new System.Drawing.Point(22, 48);
            this.CPe.Name = "CPe";
            this.CPe.Size = new System.Drawing.Size(126, 17);
            this.CPe.TabIndex = 10;
            this.CPe.Text = "Cargueiros Pequenos";
            this.CPe.UseVisualStyleBackColor = true;
            this.CPe.Click += new System.EventHandler(this.actualizar);
            // 
            // Calc
            // 
            this.Calc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Calc.Location = new System.Drawing.Point(47, 296);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(111, 49);
            this.Calc.TabIndex = 13;
            this.Calc.Text = "Calcular";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.Calc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.groupBox1.Controls.Add(this.CGr);
            this.groupBox1.Controls.Add(this.CPe);
            this.groupBox1.Location = new System.Drawing.Point(216, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cargueiros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Recursos Necessários (M/C/D)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Número de Planetas";
            // 
            // NPlan
            // 
            this.NPlan.Location = new System.Drawing.Point(25, 127);
            this.NPlan.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NPlan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NPlan.Name = "NPlan";
            this.NPlan.Size = new System.Drawing.Size(56, 20);
            this.NPlan.TabIndex = 4;
            this.NPlan.TabStop = false;
            this.NPlan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NPlan.ValueChanged += new System.EventHandler(this.NPlan_ValueChanged);
            // 
            // Lista
            // 
            this.Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lista.FormattingEnabled = true;
            this.Lista.ItemHeight = 12;
            this.Lista.Items.AddRange(new object[] {
            "Planeta 1"});
            this.Lista.Location = new System.Drawing.Point(25, 156);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(56, 136);
            this.Lista.TabIndex = 15;
            this.Lista.TabStop = false;
            this.Lista.Tag = "0";
            this.Lista.UseTabStops = false;
            this.Lista.SelectedIndexChanged += new System.EventHandler(this.Lista_SelectedIndexChanged);
            this.Lista.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lista_MouseDoubleClick);
            // 
            // CPlan
            // 
            this.CPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPlan.Location = new System.Drawing.Point(149, 210);
            this.CPlan.Name = "CPlan";
            this.CPlan.Size = new System.Drawing.Size(56, 18);
            this.CPlan.TabIndex = 6;
            this.CPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CPlan.Enter += new System.EventHandler(this.limpaTexto);
            // 
            // DPlan
            // 
            this.DPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPlan.Location = new System.Drawing.Point(211, 210);
            this.DPlan.Name = "DPlan";
            this.DPlan.Size = new System.Drawing.Size(56, 18);
            this.DPlan.TabIndex = 7;
            this.DPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DPlan.Enter += new System.EventHandler(this.limpaTexto);
            // 
            // MPlan
            // 
            this.MPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MPlan.Location = new System.Drawing.Point(87, 210);
            this.MPlan.Name = "MPlan";
            this.MPlan.Size = new System.Drawing.Size(56, 18);
            this.MPlan.TabIndex = 5;
            this.MPlan.Tag = "0";
            this.MPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MPlan.TextChanged += new System.EventHandler(this.MPlan_TextChanged);
            this.MPlan.Enter += new System.EventHandler(this.limpaTexto);
            // 
            // Saida
            // 
            this.Saida.Location = new System.Drawing.Point(25, 356);
            this.Saida.Multiline = true;
            this.Saida.Name = "Saida";
            this.Saida.ReadOnly = true;
            this.Saida.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Saida.Size = new System.Drawing.Size(344, 163);
            this.Saida.TabIndex = 19;
            // 
            // LimTudo
            // 
            this.LimTudo.Location = new System.Drawing.Point(294, 322);
            this.LimTudo.Name = "LimTudo";
            this.LimTudo.Size = new System.Drawing.Size(75, 23);
            this.LimTudo.TabIndex = 14;
            this.LimTudo.Text = "Limpar Tudo";
            this.LimTudo.UseVisualStyleBackColor = true;
            this.LimTudo.Click += new System.EventHandler(this.LimTudo_Click);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(87, 262);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(118, 28);
            this.Confirm.TabIndex = 11;
            this.Confirm.Text = "OK";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // ShowMet
            // 
            this.ShowMet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowMet.Location = new System.Drawing.Point(25, 84);
            this.ShowMet.Name = "ShowMet";
            this.ShowMet.ReadOnly = true;
            this.ShowMet.Size = new System.Drawing.Size(56, 18);
            this.ShowMet.TabIndex = 23;
            this.ShowMet.TabStop = false;
            // 
            // ShowCris
            // 
            this.ShowCris.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowCris.Location = new System.Drawing.Point(87, 84);
            this.ShowCris.Name = "ShowCris";
            this.ShowCris.ReadOnly = true;
            this.ShowCris.Size = new System.Drawing.Size(56, 18);
            this.ShowCris.TabIndex = 24;
            this.ShowCris.TabStop = false;
            // 
            // ShowDeu
            // 
            this.ShowDeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowDeu.Location = new System.Drawing.Point(149, 84);
            this.ShowDeu.Name = "ShowDeu";
            this.ShowDeu.ReadOnly = true;
            this.ShowDeu.Size = new System.Drawing.Size(56, 18);
            this.ShowDeu.TabIndex = 25;
            this.ShowDeu.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.opçõesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.fileToolStripMenuItem.Text = "&Ficheiro";
            // 
            // carregarToolStripMenuItem
            // 
            this.carregarToolStripMenuItem.Name = "carregarToolStripMenuItem";
            this.carregarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.carregarToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.carregarToolStripMenuItem.Text = "&Carregar";
            this.carregarToolStripMenuItem.Click += new System.EventHandler(this.carregarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.guardarToolStripMenuItem.Text = "&Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sairToolStripMenuItem.Text = "Sai&r";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manterAcimaToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "&Opções";
            // 
            // manterAcimaToolStripMenuItem
            // 
            this.manterAcimaToolStripMenuItem.Name = "manterAcimaToolStripMenuItem";
            this.manterAcimaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.manterAcimaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.manterAcimaToolStripMenuItem.Text = "Manter Acima";
            this.manterAcimaToolStripMenuItem.Click += new System.EventHandler(this.manterAcimaToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portuguêsToolStripMenuItem,
            this.inglêsToolStripMenuItem});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // portuguêsToolStripMenuItem
            // 
            this.portuguêsToolStripMenuItem.Name = "portuguêsToolStripMenuItem";
            this.portuguêsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.portuguêsToolStripMenuItem.Text = "Português";
            this.portuguêsToolStripMenuItem.Click += new System.EventHandler(this.portuguesToolStripMenuItem_Click);
            // 
            // inglêsToolStripMenuItem
            // 
            this.inglêsToolStripMenuItem.Name = "inglêsToolStripMenuItem";
            this.inglêsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.inglêsToolStripMenuItem.Text = "Inglês";
            this.inglêsToolStripMenuItem.Click += new System.EventHandler(this.inglesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.aboutToolStripMenuItem.Text = "Sobre";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // systemPos
            // 
            this.systemPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemPos.Location = new System.Drawing.Point(149, 236);
            this.systemPos.Name = "systemPos";
            this.systemPos.Size = new System.Drawing.Size(56, 18);
            this.systemPos.TabIndex = 9;
            this.systemPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.systemPos.Enter += new System.EventHandler(this.limpaTexto);
            // 
            // slotPos
            // 
            this.slotPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotPos.Location = new System.Drawing.Point(211, 236);
            this.slotPos.Name = "slotPos";
            this.slotPos.Size = new System.Drawing.Size(56, 18);
            this.slotPos.TabIndex = 10;
            this.slotPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slotPos.Enter += new System.EventHandler(this.limpaTexto);
            // 
            // galaxyPos
            // 
            this.galaxyPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.galaxyPos.Location = new System.Drawing.Point(87, 236);
            this.galaxyPos.Name = "galaxyPos";
            this.galaxyPos.Size = new System.Drawing.Size(56, 18);
            this.galaxyPos.TabIndex = 8;
            this.galaxyPos.Tag = "";
            this.galaxyPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.galaxyPos.Enter += new System.EventHandler(this.limpaTexto);
            // 
            // limpar
            // 
            this.limpar.Location = new System.Drawing.Point(211, 262);
            this.limpar.Name = "limpar";
            this.limpar.Size = new System.Drawing.Size(56, 28);
            this.limpar.TabIndex = 12;
            this.limpar.Text = "Limpar";
            this.limpar.UseVisualStyleBackColor = true;
            this.limpar.Click += new System.EventHandler(this.limpar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Recursos (M/C/D)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Coordenadas";
            // 
            // destino
            // 
            this.destino.AutoSize = true;
            this.destino.Location = new System.Drawing.Point(274, 262);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(62, 17);
            this.destino.TabIndex = 33;
            this.destino.Text = "Destino";
            this.destino.UseVisualStyleBackColor = true;
            this.destino.CheckedChanged += new System.EventHandler(this.actualizar);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.equilibrado);
            this.groupBox2.Controls.Add(this.ordemRecursos);
            this.groupBox2.Controls.Add(this.ordemLista);
            this.groupBox2.Location = new System.Drawing.Point(216, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 100);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Método";
            // 
            // equilibrado
            // 
            this.equilibrado.AutoSize = true;
            this.equilibrado.Location = new System.Drawing.Point(7, 71);
            this.equilibrado.Name = "equilibrado";
            this.equilibrado.Size = new System.Drawing.Size(77, 17);
            this.equilibrado.TabIndex = 2;
            this.equilibrado.Text = "Equilibrado";
            this.equilibrado.UseVisualStyleBackColor = true;
            this.equilibrado.Click += new System.EventHandler(this.actualizar);
            // 
            // ordemRecursos
            // 
            this.ordemRecursos.AutoSize = true;
            this.ordemRecursos.Enabled = false;
            this.ordemRecursos.Location = new System.Drawing.Point(7, 45);
            this.ordemRecursos.Name = "ordemRecursos";
            this.ordemRecursos.Size = new System.Drawing.Size(119, 17);
            this.ordemRecursos.TabIndex = 1;
            this.ordemRecursos.Text = "Ordem de Recursos";
            this.ordemRecursos.UseVisualStyleBackColor = true;
            this.ordemRecursos.Click += new System.EventHandler(this.actualizar);
            // 
            // ordemLista
            // 
            this.ordemLista.AutoSize = true;
            this.ordemLista.Checked = true;
            this.ordemLista.Location = new System.Drawing.Point(7, 19);
            this.ordemLista.Name = "ordemLista";
            this.ordemLista.Size = new System.Drawing.Size(96, 17);
            this.ordemLista.TabIndex = 0;
            this.ordemLista.TabStop = true;
            this.ordemLista.Text = "Ordem da Lista";
            this.ordemLista.UseVisualStyleBackColor = true;
            this.ordemLista.Click += new System.EventHandler(this.actualizar);
            // 
            // insertPlanetName
            // 
            this.insertPlanetName.Location = new System.Drawing.Point(87, 149);
            this.insertPlanetName.MaxLength = 12;
            this.insertPlanetName.Name = "insertPlanetName";
            this.insertPlanetName.Size = new System.Drawing.Size(108, 20);
            this.insertPlanetName.TabIndex = 4;
            this.insertPlanetName.TabStop = false;
            this.insertPlanetName.Visible = false;
            this.insertPlanetName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.insertPlanetName_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 21);
            this.button1.TabIndex = 36;
            this.button1.Text = "ShowDataDebug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "cog";
            this.saveFileDialog1.FileName = "profile";
            // 
            // modoEcra
            // 
            this.modoEcra.AutoSize = true;
            this.modoEcra.Location = new System.Drawing.Point(87, 187);
            this.modoEcra.Name = "modoEcra";
            this.modoEcra.Size = new System.Drawing.Size(75, 17);
            this.modoEcra.TabIndex = 37;
            this.modoEcra.Text = "Mini Mode";
            this.modoEcra.UseVisualStyleBackColor = true;
            this.modoEcra.CheckedChanged += new System.EventHandler(this.modoEcra_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 531);
            this.Controls.Add(this.modoEcra);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.insertPlanetName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.limpar);
            this.Controls.Add(this.systemPos);
            this.Controls.Add(this.slotPos);
            this.Controls.Add(this.galaxyPos);
            this.Controls.Add(this.ShowDeu);
            this.Controls.Add(this.ShowCris);
            this.Controls.Add(this.ShowMet);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.LimTudo);
            this.Controls.Add(this.Saida);
            this.Controls.Add(this.CPlan);
            this.Controls.Add(this.DPlan);
            this.Controls.Add(this.MPlan);
            this.Controls.Add(this.Lista);
            this.Controls.Add(this.NPlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Calc);
            this.Controls.Add(this.CrisNeed);
            this.Controls.Add(this.DeuNeed);
            this.Controls.Add(this.MetNeed);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COgame Beta";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPlan)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MetNeed;
        private System.Windows.Forms.TextBox DeuNeed;
        private System.Windows.Forms.TextBox CrisNeed;
        private System.Windows.Forms.RadioButton CGr;
        private System.Windows.Forms.RadioButton CPe;
        private System.Windows.Forms.Button Calc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NPlan;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.TextBox CPlan;
        private System.Windows.Forms.TextBox DPlan;
        private System.Windows.Forms.TextBox MPlan;
        private System.Windows.Forms.TextBox Saida;
        private System.Windows.Forms.Button LimTudo;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.TextBox ShowMet;
        private System.Windows.Forms.TextBox ShowCris;
        private System.Windows.Forms.TextBox ShowDeu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.TextBox systemPos;
        private System.Windows.Forms.TextBox slotPos;
        private System.Windows.Forms.TextBox galaxyPos;
        private System.Windows.Forms.Button limpar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox destino;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manterAcimaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ordemRecursos;
        private System.Windows.Forms.RadioButton ordemLista;
        private System.Windows.Forms.TextBox insertPlanetName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton equilibrado;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portuguêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inglêsToolStripMenuItem;
        private System.Windows.Forms.CheckBox modoEcra;
    }
}

