namespace Compilador_CSharp
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.compilar_btn = new System.Windows.Forms.Button();
            this.codigoTexto_txb = new System.Windows.Forms.TextBox();
            this.infoSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tabla.DefaultCellStyle = dataGridViewCellStyle3;
            this.tabla.Location = new System.Drawing.Point(466, 12);
            this.tabla.Name = "tabla";
            this.tabla.RowTemplate.ReadOnly = true;
            this.tabla.Size = new System.Drawing.Size(444, 408);
            this.tabla.TabIndex = 2;
            // 
            // compilar_btn
            // 
            this.compilar_btn.BackColor = System.Drawing.SystemColors.Control;
            this.compilar_btn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compilar_btn.Location = new System.Drawing.Point(466, 457);
            this.compilar_btn.Name = "compilar_btn";
            this.compilar_btn.Size = new System.Drawing.Size(444, 39);
            this.compilar_btn.TabIndex = 4;
            this.compilar_btn.Text = "Compilar";
            this.compilar_btn.UseVisualStyleBackColor = false;
            this.compilar_btn.Click += new System.EventHandler(this.Compilar_btn_Click);
            // 
            // codigoTexto_txb
            // 
            this.codigoTexto_txb.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoTexto_txb.Location = new System.Drawing.Point(12, 12);
            this.codigoTexto_txb.Multiline = true;
            this.codigoTexto_txb.Name = "codigoTexto_txb";
            this.codigoTexto_txb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codigoTexto_txb.Size = new System.Drawing.Size(448, 484);
            this.codigoTexto_txb.TabIndex = 1;
            this.codigoTexto_txb.Text = "namespace Martin {\r\n  public class Humano {\r\n    int x = 1 + 2;\r\n    int y = x + " +
    "10;\r\n    int r = x - 10;\r\n  }";
            // 
            // infoSelector
            // 
            this.infoSelector.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.infoSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.infoSelector.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoSelector.FormattingEnabled = true;
            this.infoSelector.Items.AddRange(new object[] {
            "Lista de Tokens",
            "Errores de TS"});
            this.infoSelector.Location = new System.Drawing.Point(466, 426);
            this.infoSelector.Name = "infoSelector";
            this.infoSelector.Size = new System.Drawing.Size(444, 25);
            this.infoSelector.TabIndex = 3;
            this.infoSelector.SelectedIndexChanged += new System.EventHandler(this.infoSelector_SelectedIndexChanged);
            this.infoSelector.Click += new System.EventHandler(this.infoSelector_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 508);
            this.Controls.Add(this.infoSelector);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.compilar_btn);
            this.Controls.Add(this.codigoTexto_txb);
            this.Name = "Form1";
            this.Text = "Compilador C#";
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Button compilar_btn;
        private System.Windows.Forms.TextBox codigoTexto_txb;
        private System.Windows.Forms.ComboBox infoSelector;
    }
}

