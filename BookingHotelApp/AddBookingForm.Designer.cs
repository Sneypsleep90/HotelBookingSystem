namespace BookingApp
{
    partial class AddBookingForm
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
            this.labelId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.labelClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.labelHotel = new System.Windows.Forms.Label();
            this.cbHotels = new System.Windows.Forms.ComboBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.cbRooms = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 15);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(25, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(100, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(150, 20);
            this.txtId.TabIndex = 1;
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Location = new System.Drawing.Point(12, 41);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(81, 13);
            this.labelClientName.TabIndex = 2;
            this.labelClientName.Text = "Имя клиента:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(100, 38);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(150, 20);
            this.txtClientName.TabIndex = 3;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(12, 67);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(37, 13);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "Дата:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(100, 64);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDate.TabIndex = 5;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(12, 93);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(46, 13);
            this.labelHotel.TabIndex = 6;
            this.labelHotel.Text = "Отель:";
            // 
            // cbHotels
            // 
            this.cbHotels.FormattingEnabled = true;
            this.cbHotels.Location = new System.Drawing.Point(100, 90);
            this.cbHotels.Name = "cbHotels";
            this.cbHotels.Size = new System.Drawing.Size(150, 21);
            this.cbHotels.TabIndex = 7;
            this.cbHotels.SelectedIndexChanged += new System.EventHandler(this.cbHotels_SelectedIndexChanged);
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(12, 119);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(47, 13);
            this.labelRoom.TabIndex = 8;
            this.labelRoom.Text = "Номер:";
            // 
            // cbRooms
            // 
            this.cbRooms.FormattingEnabled = true;
            this.cbRooms.Location = new System.Drawing.Point(100, 116);
            this.cbRooms.Name = "cbRooms";
            this.cbRooms.Size = new System.Drawing.Size(150, 21);
            this.cbRooms.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbRooms);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.cbHotels);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.labelClientName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.labelId);
            this.Name = "AddBookingForm";
            this.Text = "Добавить бронирование";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox cbHotels;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.ComboBox cbRooms;
        private System.Windows.Forms.Button btnSave;
    }
}