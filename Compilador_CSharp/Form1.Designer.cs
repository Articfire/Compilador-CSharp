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
            this.tabla = new System.Windows.Forms.DataGridView();
            this.compilar_btn = new System.Windows.Forms.Button();
            this.codigoTexto_txb = new System.Windows.Forms.TextBox();
            this.tablaErrores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(516, 12);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(456, 262);
            this.tabla.TabIndex = 5;
            // 
            // compilar_btn
            // 
            this.compilar_btn.Location = new System.Drawing.Point(516, 483);
            this.compilar_btn.Name = "compilar_btn";
            this.compilar_btn.Size = new System.Drawing.Size(456, 34);
            this.compilar_btn.TabIndex = 4;
            this.compilar_btn.Text = "Compilar";
            this.compilar_btn.UseVisualStyleBackColor = true;
            this.compilar_btn.Click += new System.EventHandler(this.Compilar_btn_Click);
            // 
            // codigoTexto_txb
            // 
            this.codigoTexto_txb.Location = new System.Drawing.Point(12, 12);
            this.codigoTexto_txb.Multiline = true;
            this.codigoTexto_txb.Name = "codigoTexto_txb";
            this.codigoTexto_txb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codigoTexto_txb.Size = new System.Drawing.Size(498, 505);
            this.codigoTexto_txb.TabIndex = 3;
            this.codigoTexto_txb.Text = "namespace Martin{\r\npublic class Humano {\r\n  int x;\r\n}";
            // 
            // tablaErrores
            // 
            this.tablaErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaErrores.Location = new System.Drawing.Point(516, 280);
            this.tablaErrores.Name = "tablaErrores";
            this.tablaErrores.Size = new System.Drawing.Size(456, 197);
            this.tablaErrores.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 529);
            this.Controls.Add(this.tablaErrores);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.compilar_btn);
            this.Controls.Add(this.codigoTexto_txb);
            this.Name = "Form1";
            this.Text = "Compilador C#";
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Button compilar_btn;
        private System.Windows.Forms.TextBox codigoTexto_txb;
        private System.Windows.Forms.DataGridView tablaErrores;
    }
}

