namespace WsEstoqueClient
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
            this.botaoEstoque = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botaoEstoque
            // 
            this.botaoEstoque.Location = new System.Drawing.Point(64, 93);
            this.botaoEstoque.Name = "botaoEstoque";
            this.botaoEstoque.Size = new System.Drawing.Size(131, 23);
            this.botaoEstoque.TabIndex = 0;
            this.botaoEstoque.Text = "Chamar serviço";
            this.botaoEstoque.UseVisualStyleBackColor = true;
            this.botaoEstoque.Click += new System.EventHandler(this.botaoEstoque_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.botaoEstoque);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botaoEstoque;
    }
}

