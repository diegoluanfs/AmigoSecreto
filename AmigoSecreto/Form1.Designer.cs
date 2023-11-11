namespace AmigoSecreto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnSortear = new System.Windows.Forms.Button();
            this.dtView = new System.Windows.Forms.DataGridView();
            this.btnAmigoSecreto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(191, 279);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(86, 31);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do participante";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(58, 95);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(219, 27);
            this.txtNome.TabIndex = 2;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(58, 173);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(219, 27);
            this.txtTelefone.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telefone";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(276, 29);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(113, 31);
            this.btnMostrar.TabIndex = 5;
            this.btnMostrar.Text = "Mostrar Lista";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Visible = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnSortear
            // 
            this.btnSortear.Enabled = false;
            this.btnSortear.Location = new System.Drawing.Point(58, 281);
            this.btnSortear.Name = "btnSortear";
            this.btnSortear.Size = new System.Drawing.Size(94, 29);
            this.btnSortear.TabIndex = 6;
            this.btnSortear.Text = "Sortear";
            this.btnSortear.UseVisualStyleBackColor = true;
            this.btnSortear.Visible = false;
            this.btnSortear.Click += new System.EventHandler(this.btnSortear_Click);
            // 
            // dtView
            // 
            this.dtView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtView.Location = new System.Drawing.Point(388, 95);
            this.dtView.Name = "dtView";
            this.dtView.RowHeadersWidth = 51;
            this.dtView.RowTemplate.Height = 29;
            this.dtView.Size = new System.Drawing.Size(430, 215);
            this.dtView.TabIndex = 7;
            // 
            // btnAmigoSecreto
            // 
            this.btnAmigoSecreto.Enabled = false;
            this.btnAmigoSecreto.Location = new System.Drawing.Point(58, 221);
            this.btnAmigoSecreto.Name = "btnAmigoSecreto";
            this.btnAmigoSecreto.Size = new System.Drawing.Size(219, 41);
            this.btnAmigoSecreto.TabIndex = 8;
            this.btnAmigoSecreto.Text = "Amigo Secreto";
            this.btnAmigoSecreto.UseVisualStyleBackColor = true;
            this.btnAmigoSecreto.Visible = false;
            this.btnAmigoSecreto.Click += new System.EventHandler(this.btnAmigoSecreto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 377);
            this.Controls.Add(this.btnAmigoSecreto);
            this.Controls.Add(this.dtView);
            this.Controls.Add(this.btnSortear);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Button btnSalvar;
        private Label label1;
        private TextBox txtNome;
        private TextBox txtTelefone;
        private Label label2;
        private Button btnMostrar;
        private Button btnSortear;
        private DataGridView dtView;
        private Button btnAmigoSecreto;
    }
}