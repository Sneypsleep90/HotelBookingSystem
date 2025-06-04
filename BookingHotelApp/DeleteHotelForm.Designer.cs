namespace BookingApp
{
    partial class DeleteHotelForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelHotel = new System.Windows.Forms.Label();
            this.cbHotels = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(12, 20);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(46, 13);
            this.labelHotel.TabIndex = 0;
            this.labelHotel.Text = "Отель:";
            // 
            // cbHotels
            // 
            this.cbHotels.FormattingEnabled = true;
            this.cbHotels.Location = new System.Drawing.Point(100, 17);
            this.cbHotels.Name = "cbHotels";
            this.cbHotels.Size = new System.Drawing.Size(150, 21);
            this.cbHotels.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(100, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DeleteHotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbHotels);
            this.Controls.Add(this.labelHotel);
            this.Name = "DeleteHotelForm";
            this.Text = "Удалить отель";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox cbHotels;
        private System.Windows.Forms.Button btnDelete;
    }
}