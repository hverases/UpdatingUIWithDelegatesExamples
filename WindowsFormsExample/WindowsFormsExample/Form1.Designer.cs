namespace WindowsFormsExample
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
            this.numUpDownTotalItems = new System.Windows.Forms.NumericUpDown();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.btnProcessItems = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblProcessingTime = new System.Windows.Forms.Label();
            this.numUpDownProcessingTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTotalItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownProcessingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // numUpDownTotalItems
            // 
            this.numUpDownTotalItems.Location = new System.Drawing.Point(57, 35);
            this.numUpDownTotalItems.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownTotalItems.Name = "numUpDownTotalItems";
            this.numUpDownTotalItems.Size = new System.Drawing.Size(120, 20);
            this.numUpDownTotalItems.TabIndex = 0;
            this.numUpDownTotalItems.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numUpDownTotalItems.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            this.numUpDownTotalItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numUpDown_KeyUp);
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Location = new System.Drawing.Point(54, 19);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(110, 13);
            this.lblTotalItems.TabIndex = 99;
            this.lblTotalItems.Text = "Total items to process";
            // 
            // btnProcessItems
            // 
            this.btnProcessItems.Location = new System.Drawing.Point(233, 94);
            this.btnProcessItems.Name = "btnProcessItems";
            this.btnProcessItems.Size = new System.Drawing.Size(101, 23);
            this.btnProcessItems.TabIndex = 2;
            this.btnProcessItems.Text = "Process items";
            this.btnProcessItems.UseVisualStyleBackColor = true;
            this.btnProcessItems.Click += new System.EventHandler(this.btnProcessItems_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(57, 144);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(453, 23);
            this.progressBar.TabIndex = 99;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(57, 170);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(453, 13);
            this.lblProgress.TabIndex = 99;
            this.lblProgress.Text = "Progress";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProcessingTime
            // 
            this.lblProcessingTime.AutoSize = true;
            this.lblProcessingTime.Location = new System.Drawing.Point(277, 19);
            this.lblProcessingTime.Name = "lblProcessingTime";
            this.lblProcessingTime.Size = new System.Drawing.Size(233, 13);
            this.lblProcessingTime.TabIndex = 99;
            this.lblProcessingTime.Text = "Processing time in milliseconds for each element";
            // 
            // numUpDownProcessingTime
            // 
            this.numUpDownProcessingTime.Location = new System.Drawing.Point(280, 34);
            this.numUpDownProcessingTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDownProcessingTime.Name = "numUpDownProcessingTime";
            this.numUpDownProcessingTime.Size = new System.Drawing.Size(230, 20);
            this.numUpDownProcessingTime.TabIndex = 1;
            this.numUpDownProcessingTime.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpDownProcessingTime.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            this.numUpDownProcessingTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numUpDown_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 205);
            this.Controls.Add(this.numUpDownProcessingTime);
            this.Controls.Add(this.lblProcessingTime);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnProcessItems);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.numUpDownTotalItems);
            this.Name = "Form1";
            this.Text = "Updating UI with delegates - Windows Forms Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTotalItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownProcessingTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpDownTotalItems;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Button btnProcessItems;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblProcessingTime;
        private System.Windows.Forms.NumericUpDown numUpDownProcessingTime;
    }
}
