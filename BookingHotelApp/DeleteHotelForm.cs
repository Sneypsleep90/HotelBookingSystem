using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookingApp
{
    public partial class DeleteHotelForm : Form
    {
        private readonly List<Hotel> hotels;
        private readonly List<Booking> bookings;
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int SelectedHotelId { get; private set; }

        public DeleteHotelForm(List<Hotel> hotels, List<Room> rooms, List<Booking> bookings)
        {
            this.hotels = hotels;
            this.bookings = bookings;
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
                MessageBox.Show("Нет отелей для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbHotels.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отель для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedHotelId = hotels[cbHotels.SelectedIndex].Id;
            string hotelName = hotels[cbHotels.SelectedIndex].Name;

            if (bookings.Any(b => b.HotelId == selectedHotelId && b.Status == "Активна"))
            {
                MessageBox.Show($"Нельзя удалить отель '{hotelName}', так как для него существуют активные бронирования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Вы уверены, что хотите удалить отель '{hotelName}'? Все связанные номера также будут удалены.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SelectedHotelId = selectedHotelId;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}