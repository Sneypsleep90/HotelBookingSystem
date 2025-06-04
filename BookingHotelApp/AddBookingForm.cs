using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookingApp
{
    public partial class AddBookingForm : Form
    {
        private readonly List<Hotel> hotels;
        private readonly List<Room> rooms;
        private readonly List<Booking> bookings;
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Booking NewBooking { get; private set; }

        public AddBookingForm(List<Hotel> hotels, List<Room> rooms, List<Booking> bookings)
        {
            this.hotels = hotels;
            this.rooms = rooms;
            this.bookings = bookings;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            dtpDate.Value = DateTime.Now;
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
                MessageBox.Show("Нет доступных отелей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void cbHotels_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRooms.Items.Clear();
            if (cbHotels.SelectedIndex == -1) return;

            int selectedHotelId = hotels[cbHotels.SelectedIndex].Id;
            var availableRooms = rooms.Where(r => r.HotelId == selectedHotelId).ToList();

            if (!availableRooms.Any())
            {
                MessageBox.Show($"Для отеля '{cbHotels.SelectedItem}' нет доступных номеров.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbRooms.Enabled = false;
                return;
            }

            cbRooms.Enabled = true;
            foreach (var room in availableRooms)
            {
                cbRooms.Items.Add(room.RoomNumber);
            }
            if (cbRooms.Items.Count > 0)
            {
                cbRooms.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Введите корректный ID бронирования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("Введите имя клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbHotels.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отель!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите номер!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedHotelId = hotels[cbHotels.SelectedIndex].Id;
            var selectedRoom = rooms.FirstOrDefault(r => r.HotelId == selectedHotelId && r.RoomNumber == cbRooms.SelectedItem.ToString());
            if (selectedRoom == null)
            {
                MessageBox.Show("Выбранный номер не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingBooking = bookings.FirstOrDefault(b => b.RoomId == selectedRoom.Id && b.Date.Date == dtpDate.Value.Date && b.Status == "Активна");
            if (existingBooking != null)
            {
                MessageBox.Show("Этот номер уже забронирован на выбранную дату!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewBooking = new Booking
            {
                Id = id,
                ClientName = txtClientName.Text,
                Date = dtpDate.Value,
                Status = "Активна",
                HotelId = selectedHotelId,
                RoomId = selectedRoom.Id
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}