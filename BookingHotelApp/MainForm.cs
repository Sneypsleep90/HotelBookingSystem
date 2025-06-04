using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace BookingApp
{
    public partial class MainForm : Form
    {
        private List<Booking> bookings = new();
        private List<Hotel> hotels = new();
        private List<Room> rooms = new();
        private readonly string bookingsFilePath = "bookings.json";
        private readonly string hotelsFilePath = "hotels.json";
        private readonly string roomsFilePath = "rooms.json";

        public MainForm()
        {
            InitializeComponent();
            LoadHotelsFromFile();
            LoadRoomsFromFile();
            LoadBookingsFromFile();
            if (hotels.Count == 0 && rooms.Count == 0 && bookings.Count == 0)
            {
                LoadSampleData();
                SaveHotelsToFile();
                SaveRoomsToFile();
                SaveBookingsToFile();
            }
            RefreshDataGrid();
        }

        private void LoadSampleData()
        {
            hotels.Add(new Hotel { Id = 1, Name = "Grand Hotel" });
            hotels.Add(new Hotel { Id = 2, Name = "Sunset Resort" });

            rooms.Add(new Room { Id = 1, HotelId = 1, RoomNumber = "101" });
            rooms.Add(new Room { Id = 2, HotelId = 1, RoomNumber = "102" });
            rooms.Add(new Room { Id = 3, HotelId = 1, RoomNumber = "103" });
            rooms.Add(new Room { Id = 4, HotelId = 1, RoomNumber = "104" });
            rooms.Add(new Room { Id = 5, HotelId = 1, RoomNumber = "105" });

            rooms.Add(new Room { Id = 6, HotelId = 2, RoomNumber = "201" });
            rooms.Add(new Room { Id = 7, HotelId = 2, RoomNumber = "202" });
            rooms.Add(new Room { Id = 8, HotelId = 2, RoomNumber = "203" });
            rooms.Add(new Room { Id = 9, HotelId = 2, RoomNumber = "204" });
            rooms.Add(new Room { Id = 10, HotelId = 2, RoomNumber = "205" });

            bookings.Add(new Booking { Id = 1, ClientName = "Иван Иванов", Date = DateTime.Now, Status = "Активна", HotelId = 1, RoomId = 1 });
            bookings.Add(new Booking { Id = 2, ClientName = "Петр Петров", Date = DateTime.Now.AddDays(1), Status = "Активна", HotelId = 2, RoomId = 6 });
        }

        private void LoadHotelsFromFile()
        {
            try
            {
                if (File.Exists(hotelsFilePath))
                {
                    string json = File.ReadAllText(hotelsFilePath);
                    hotels = JsonSerializer.Deserialize<List<Hotel>>(json) ?? new List<Hotel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отелей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveHotelsToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(hotels, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(hotelsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении отелей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomsFromFile()
        {
            try
            {
                if (File.Exists(roomsFilePath))
                {
                    string json = File.ReadAllText(roomsFilePath);
                    rooms = JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке номеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveRoomsToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(rooms, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(roomsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении номеров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookingsFromFile()
        {
            try
            {
                if (File.Exists(bookingsFilePath))
                {
                    string json = File.ReadAllText(bookingsFilePath);
                    bookings = JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке бронирований: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBookingsToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(bookings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(bookingsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении бронирований: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGrid()
        {
            dataGridViewBookings.DataSource = null;
            var displayData = bookings.Select(b => new
            {
                b.Id,
                b.ClientName,
                b.Date,
                b.Status,
                HotelName = hotels.FirstOrDefault(h => h.Id == b.HotelId)?.Name ?? "Неизвестный отель",
                RoomNumber = rooms.FirstOrDefault(r => r.Id == b.RoomId)?.RoomNumber ?? "Неизвестный номер"
            }).ToList();
            dataGridViewBookings.DataSource = displayData;
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            var addForm = new AddBookingForm(hotels, rooms, bookings);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (bookings.Any(b => b.Id == addForm.NewBooking.Id))
                {
                    MessageBox.Show("Бронь с таким ID уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bookings.Add(addForm.NewBooking);
                SaveBookingsToFile();
                RefreshDataGrid();
            }
        }

        private void btnAddHotel_Click(object sender, EventArgs e)
        {
            var addHotelForm = new AddHotelForm();
            if (addHotelForm.ShowDialog() == DialogResult.OK)
            {
                if (hotels.Any(h => h.Id == addHotelForm.NewHotel.Id))
                {
                    MessageBox.Show("Отель с таким ID уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                hotels.Add(addHotelForm.NewHotel);
                SaveHotelsToFile();
                RefreshDataGrid();
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            var addRoomForm = new AddRoomForm(hotels);
            if (addRoomForm.ShowDialog() == DialogResult.OK)
            {
                if (rooms.Any(r => r.Id == addRoomForm.NewRoom.Id))
                {
                    MessageBox.Show("Номер с таким ID уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                rooms.Add(addRoomForm.NewRoom);
                SaveRoomsToFile();
                RefreshDataGrid();
            }
        }

        private void btnDeleteHotel_Click(object sender, EventArgs e)
        {
            if (hotels.Count <= 1)
            {
                MessageBox.Show("Нельзя удалить последний отель!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var deleteHotelForm = new DeleteHotelForm(hotels, rooms, bookings);
            if (deleteHotelForm.ShowDialog() == DialogResult.OK)
            {
                var hotelToRemove = hotels.FirstOrDefault(h => h.Id == deleteHotelForm.SelectedHotelId);
                if (hotelToRemove != null)
                {
                    hotels.Remove(hotelToRemove);
                    rooms.RemoveAll(r => r.HotelId == hotelToRemove.Id);
                    SaveHotelsToFile();
                    SaveRoomsToFile();
                    RefreshDataGrid();
                }
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                var selectedBookingId = (int)dataGridViewBookings.SelectedRows[0].Cells["Id"].Value;
                var selectedBooking = bookings.FirstOrDefault(b => b.Id == selectedBookingId);
                if (selectedBooking != null && MessageBox.Show($"Отменить бронь {selectedBooking.Id}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectedBooking.Status = "Отменена";
                    SaveBookingsToFile();
                    RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите бронь для отмены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                var selectedBookingId = (int)dataGridViewBookings.SelectedRows[0].Cells["Id"].Value;
                var selectedBooking = bookings.FirstOrDefault(b => b.Id == selectedBookingId);
                if (selectedBooking != null && MessageBox.Show($"Удалить бронь {selectedBooking.Id} для {selectedBooking.ClientName}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bookings.Remove(selectedBooking);
                    SaveBookingsToFile();
                    RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите бронь для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            var filtered = bookings.Where(b =>
                b.Id.ToString().Contains(searchText) ||
                b.ClientName.ToLower().Contains(searchText) ||
                b.Date.ToString("dd.MM.yyyy").ToLower().Contains(searchText) ||
                hotels.FirstOrDefault(h => h.Id == b.HotelId)?.Name?.ToLower().Contains(searchText) == true ||
                rooms.FirstOrDefault(r => r.Id == b.RoomId)?.RoomNumber?.ToLower().Contains(searchText) == true)
                .Select(b => new
                {
                    b.Id,
                    b.ClientName,
                    b.Date,
                    b.Status,
                    HotelName = hotels.FirstOrDefault(h => h.Id == b.HotelId)?.Name ?? "Неизвестный отель",
                    RoomNumber = rooms.FirstOrDefault(r => r.Id == b.RoomId)?.RoomNumber ?? "Неизвестный номер"
                }).ToList();

            dataGridViewBookings.DataSource = filtered;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshDataGrid();
        }
    }
}