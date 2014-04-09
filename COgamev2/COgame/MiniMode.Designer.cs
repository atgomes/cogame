namespace COgame
{
    partial class MiniMode
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
            this.destino = new System.Windows.Forms.CheckBox();
            this.limpar = new System.Windows.Forms.Button();
            this.systemPos = new System.Windows.Forms.TextBox();
            this.slotPos = new System.Windows.Forms.TextBox();
            this.galaxyPos = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.CPlan = new System.Windows.Forms.TextBox();
            this.DPlan = new System.Windows.Forms.TextBox();
            this.MPlan = new System.Windows.Forms.TextBox();
            this.Lista = new System.Windows.Forms.ListBox();
            this.modoEcra = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // destino
            // 
            this.destino.AutoSize = true;
            this.destino.Location = new System.Drawing.Point(94, 104);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(62, 17);
            this.destino.TabIndex = 43;
            this.destino.Text = "Destino";
            this.destino.UseVisualStyleBackColor = true;
            this.destino.Visible = false;
            // 
            // limpar
            // 
            this.limpar.Location = new System.Drawing.Point(218, 64);
            this.limpar.Name = "limpar";
            this.limpar.Size = new System.Drawing.Size(56, 28);
            this.limpar.TabIndex = 41;
            this.limpar.Text = "Delete";
            this.limpar.UseVisualStyleBackColor = true;
            // 
            // systemPos
            // 
            this.systemPos.Location = new System.Drawing.Point(156, 38);
            this.systemPos.Name = "systemPos";
            this.systemPos.Size = new System.Drawing.Size(56, 20);
            this.systemPos.TabIndex = 38;
            this.systemPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.systemPos.Enter += new System.EventHandler(this.LimpaCaixa);
            // 
            // slotPos
            // 
            this.slotPos.Location = new System.Drawing.Point(218, 38);
            this.slotPos.Name = "slotPos";
            this.slotPos.Size = new System.Drawing.Size(56, 20);
            this.slotPos.TabIndex = 39;
            this.slotPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slotPos.Enter += new System.EventHandler(this.LimpaCaixa);
            // 
            // galaxyPos
            // 
            this.galaxyPos.Location = new System.Drawing.Point(94, 38);
            this.galaxyPos.Name = "galaxyPos";
            this.galaxyPos.Size = new System.Drawing.Size(56, 20);
            this.galaxyPos.TabIndex = 37;
            this.galaxyPos.Tag = "";
            this.galaxyPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.galaxyPos.Enter += new System.EventHandler(this.LimpaCaixa);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(94, 64);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(118, 28);
            this.Confirm.TabIndex = 40;
            this.Confirm.Text = "OK";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // CPlan
            // 
            this.CPlan.Location = new System.Drawing.Point(156, 12);
            this.CPlan.Name = "CPlan";
            this.CPlan.Size = new System.Drawing.Size(56, 20);
            this.CPlan.TabIndex = 35;
            this.CPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CPlan.Enter += new System.EventHandler(this.LimpaCaixa);
            // 
            // DPlan
            // 
            this.DPlan.Location = new System.Drawing.Point(218, 12);
            this.DPlan.Name = "DPlan";
            this.DPlan.Size = new System.Drawing.Size(56, 20);
            this.DPlan.TabIndex = 36;
            this.DPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DPlan.Enter += new System.EventHandler(this.LimpaCaixa);
            // 
            // MPlan
            // 
            this.MPlan.Location = new System.Drawing.Point(94, 12);
            this.MPlan.Name = "MPlan";
            this.MPlan.Size = new System.Drawing.Size(56, 20);
            this.MPlan.TabIndex = 34;
            this.MPlan.Tag = "";
            this.MPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MPlan.Enter += new System.EventHandler(this.LimpaCaixa);
            // 
            // Lista
            // 
            this.Lista.FormattingEnabled = true;
            this.Lista.Items.AddRange(new object[] {
            "Planeta 1"});
            this.Lista.Location = new System.Drawing.Point(12, 12);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(76, 108);
            this.Lista.TabIndex = 42;
            this.Lista.TabStop = false;
            this.Lista.Tag = "0";
            this.Lista.UseTabStops = false;
            this.Lista.SelectedIndexChanged += new System.EventHandler(this.Lista_SelectedIndexChanged);
            // 
            // modoEcra
            // 
            this.modoEcra.AutoSize = true;
            this.modoEcra.Location = new System.Drawing.Point(172, 104);
            this.modoEcra.Name = "modoEcra";
            this.modoEcra.Size = new System.Drawing.Size(75, 17);
            this.modoEcra.TabIndex = 44;
            this.modoEcra.Text = "Mini Mode";
            this.modoEcra.UseVisualStyleBackColor = true;
            this.modoEcra.CheckedChanged += new System.EventHandler(this.modoEcra_CheckedChanged);
            // 
            // MiniMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 128);
            this.Controls.Add(this.modoEcra);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.limpar);
            this.Controls.Add(this.systemPos);
            this.Controls.Add(this.slotPos);
            this.Controls.Add(this.galaxyPos);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.CPlan);
            this.Controls.Add(this.DPlan);
            this.Controls.Add(this.MPlan);
            this.Controls.Add(this.Lista);
            this.Name = "MiniMode";
            this.Text = "COgame Mini Beta";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.MiniMode_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox destino;
        private System.Windows.Forms.Button limpar;
        private System.Windows.Forms.TextBox systemPos;
        private System.Windows.Forms.TextBox slotPos;
        private System.Windows.Forms.TextBox galaxyPos;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.TextBox CPlan;
        private System.Windows.Forms.TextBox DPlan;
        private System.Windows.Forms.TextBox MPlan;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.CheckBox modoEcra;
    }
}