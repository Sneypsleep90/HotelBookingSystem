using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookingApp
{
    public partial class AddRoomForm : Form
    {
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Room NewRoom { get; private set; }
        private readonly List<Hotel> hotels;

        public AddRoomForm(List<Hotel> hotels)
        {
            this.hotels = hotels;
            InitializeComponent();
            LoadHotels();
        }

        private void LoadHotels()
        {
            cbHotels.Items.Clear();
            foreach (var hotel in hotels)
            {
                cbHotels.Items.Add(hotel.Name);
            }
            if (cbHotels.Items.Count > 0)
            {
                cbHotels.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Нет доступных отелей. Добавьте отель сначала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtRoomNumber.Text) || cbHotels.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID должен быть числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedHotelId = hotels[cbHotels.SelectedIndex].Id;

            NewRoom = new Room
            {
                Id = id,
                HotelId = selectedHotelId,
                RoomNumber = txtRoomNumber.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}