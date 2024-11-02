using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient; // Correct namespace

namespace Quanlyview
{
    public partial class Quanly : Form
    {
        private string strCon = @"Data Source=DESKTOP-R4MQ534\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        private SqlConnection sqlCon; // Khai báo SqlConnection

        public List<Employee> lstEmp = new List<Employee>();
        private BindingSource bs = new BindingSource();
        public bool isThoat = true;
        public event EventHandler DangXuat;

        private string employeeImagePath = string.Empty;
        private int nextId = 1;

        public Quanly()
        {
            InitializeComponent();
            SetupImageList();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMMM yyyy";
            dateTimePicker1.ShowUpDown = false;
            tbSearch.TextChanged += tbSearch_TextChanged;
            dgvEmployee.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Quanly_Load(object sender, EventArgs e)
        {
            lstEmp = GetData();
            bs.DataSource = lstEmp;
            dgvEmployee.DataSource = bs;
            SetupDataGridView();
            dateTimePicker1.Value = DateTime.Now;

            // Update nextId based on the highest current ID
            if (lstEmp.Count > 0)
            {
                nextId = lstEmp.Max(emp => emp.Id) + 1;
            }

            tbId.Text = nextId.ToString();
            tbId.ReadOnly = true; // ID is read-only
        }
        public List<Employee> GetData()
        {
            List<Employee> employees = new List<Employee>();

            using (System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(strCon))
            {
                sqlCon.Open(); // Mở kết nối

                // Câu truy vấn để lấy dữ liệu
                string query = "SELECT Id, Name, BirthDate, Gender, Address, Maduan, Maphongban, ImagePath FROM Employee";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon)) // Tạo SqlCommand
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Sử dụng using cho SqlDataReader
                    {
                        while (reader.Read()) // Đọc dữ liệu
                        {
                            Employee emp = new Employee
                            {
                                Id = reader.GetInt32(0), // Mã
                                Name = reader.GetString(1), // Tên
                                BirthDate = reader.GetDateTime(2), // Ngày sinh
                                Gender = reader.GetBoolean(3), // Giới tính
                                Address = reader.GetString(4), // Địa chỉ
                                Maduan = reader.GetString(5), // Mã dự án
                                Maphongban = reader.GetString(6), // Mã phòng ban
                                ImagePath = reader.IsDBNull(7) ? null : reader.GetString(7) // Ảnh
                            };
                            employees.Add(emp); // Thêm vào danh sách
                        }
                    }
                }
            }
            return employees; // Trả về danh sách nhân viên
        }
        //public List<Employee> GetData()
        //{
        //    List<Employee> employees = new List<Employee>();

        //    using (sqlCon = new SqlConnection(strCon)) // Sử dụng SqlConnection
        //    {
        //        try
        //        {
        //            sqlCon.Open();

        //            string query = "SELECT Id, Name, BirthDate, Gender, Address, Maduan, Maphongban, ImagePath FROM Employee";

        //            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Employee emp = new Employee
        //                        {
        //                            Id = reader.GetInt32(0),
        //                            Name = reader.GetString(1),
        //                            BirthDate = reader.GetDateTime(2),
        //                            Gender = reader.GetBoolean(3),
        //                            Address = reader.GetString(4),
        //                            Maduan = reader.GetString(5),
        //                            Maphongban = reader.GetString(6),
        //                            ImagePath = reader.IsDBNull(7) ? null : reader.GetString(7)
        //                        };
        //                        employees.Add(emp);
        //                    }
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Lỗi khi mở kết nối: " + ex.Message);
        //        }
        //    }
        //    return employees;
        //}
        private void SetupDataGridView()
        {
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.Columns[0].HeaderText = "STT";
            dgvEmployee.Columns[1].HeaderText = "Tên";
            dgvEmployee.Columns[2].HeaderText = "Ngày Sinh";
            dgvEmployee.Columns[3].HeaderText = "Giới Tính";
            dgvEmployee.Columns[4].HeaderText = "Địa Chỉ";
            dgvEmployee.Columns[5].HeaderText = "Mã Sinh Viên";
            dgvEmployee.Columns[6].HeaderText = "Mã Lớp";
            dgvEmployee.Columns[7].HeaderText = "Ảnh";
            // Set selection mode to full row select
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat?.Invoke(this, EventArgs.Empty);
        }

        private void Quanly_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat) Application.Exit();
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbAddress.Text) ||
                    string.IsNullOrWhiteSpace(tbMaduan.Text) ||
                    string.IsNullOrWhiteSpace(cbMaphongban.Text))
                {
                    MessageBox.Show("Lỗi: Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for numeric characters in the name
                if (tbName.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Lỗi: Tên không được chứa số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if mã sinh viên is numeric
                string newMaduan = tbMaduan.Text;
                if (!int.TryParse(newMaduan, out _))
                {
                    MessageBox.Show("Lỗi: Mã Sinh Viên chỉ được chứa số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate mã sinh viên
                if (lstEmp.Any(emp => emp.Maduan.Equals(newMaduan, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Lỗi: Mã Sinh Viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create new employee
                Employee newEmp = new Employee
                {
                    Id = nextId++,
                    Name = tbName.Text,
                    Gender = rbMale.Checked,
                    Address = tbAddress.Text,
                    Maduan = newMaduan,
                    Maphongban = cbMaphongban.Text,
                    ImagePath = employeeImagePath,
                    BirthDate = dateTimePicker1.Value.Date
                };

                lstEmp.Add(newEmp);
                bs.ResetBindings(false);
                ClearInputFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi: Vui lòng nhập đúng định dạng cho các trường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddEmployee(Employee newEmp)
        {
            using (System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(strCon))
            {
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO Employee (Id, Name, BirthDate, Gender, Address, Maduan, Maphongban, ImagePath) VALUES (@Id, @Name, @BirthDate, @Gender, @Address, @Maduan, @Maphongban, @ImagePath)";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@Id", newEmp.Id);
                        cmd.Parameters.AddWithValue("@Name", newEmp.Name);
                        cmd.Parameters.AddWithValue("@BirthDate", newEmp.BirthDate);
                        cmd.Parameters.AddWithValue("@Gender", newEmp.Gender);
                        cmd.Parameters.AddWithValue("@Address", newEmp.Address);
                        cmd.Parameters.AddWithValue("@Maduan", newEmp.Maduan);
                        cmd.Parameters.AddWithValue("@Maphongban", newEmp.Maphongban);
                        cmd.Parameters.AddWithValue("@ImagePath", (object)newEmp.ImagePath ?? DBNull.Value); // Handle null for ImagePath

                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    sqlCon.Close(); // Ensure connection is closed
                }
            }
        }


        private void UpdateEmployee(Employee emp)
        {
            System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(strCon);
            {
                sqlCon.Open();
                string query = "UPDATE Employees SET Name=@Name, BirthDate=@BirthDate, Gender=@Gender, Address=@Address, Maduan=@Maduan, Maphongban=@Maphongban, ImagePath=@ImagePath WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Id", emp.Id);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Address", emp.Address);
                    cmd.Parameters.AddWithValue("@Maduan", emp.Maduan);
                    cmd.Parameters.AddWithValue("@Maphongban", emp.Maphongban);
                    cmd.Parameters.AddWithValue("@ImagePath", emp.ImagePath);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void DeleteEmployee(int empId)
        {
            System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection(strCon);
            sqlCon.Open();
            string query = "DELETE FROM Employees WHERE Id=@Id";

            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                cmd.Parameters.AddWithValue("@Id", empId);
                cmd.ExecuteNonQuery();
            }
        }


        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow == null) return;

            int idx = dgvEmployee.CurrentRow.Index;
            Employee em = lstEmp[idx];

            try
            {
                // Check for empty fields
                if (string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbAddress.Text) ||
                    string.IsNullOrWhiteSpace(tbMaduan.Text) ||
                    string.IsNullOrWhiteSpace(cbMaphongban.Text))
                {
                    MessageBox.Show("Lỗi: Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for numeric characters in the name
                if (tbName.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Lỗi: Tên không được chứa số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if mã sinh viên is numeric
                string newMaduan = tbMaduan.Text;
                if (!int.TryParse(newMaduan, out _))
                {
                    MessageBox.Show("Lỗi: Mã Sinh Viên chỉ được chứa số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate mã sinh viên
                if (lstEmp.Any(emp => emp.Maduan.Equals(newMaduan, StringComparison.OrdinalIgnoreCase) && emp.Id != em.Id))
                {
                    MessageBox.Show("Lỗi: Mã Sinh Viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update employee
                em.Name = tbName.Text;
                em.Gender = rbMale.Checked;
                em.Address = tbAddress.Text;
                em.Maduan = newMaduan;
                em.Maphongban = cbMaphongban.Text;
                em.ImagePath = employeeImagePath;
                em.BirthDate = dateTimePicker1.Value.Date;
                bs.ResetBindings(false);
                ClearInputFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi: Vui lòng nhập đúng định dạng cho các trường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvEmployee.CurrentRow == null)
            {
                MessageBox.Show("Lỗi: Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idx = dgvEmployee.CurrentRow.Index;
            lstEmp.RemoveAt(idx);
            bs.ResetBindings(false);
        }


        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= bs.Count) return; // Use bs.Count to check bounds

            Employee em = (Employee)bs[e.RowIndex]; // Get the employee from the BindingSource

            tbId.Text = em.Id.ToString();
            tbName.Text = em.Name;
            rbMale.Checked = em.Gender;
            tbAddress.Text = em.Address;
            tbMaduan.Text = em.Maduan;
            cbMaphongban.Text = em.Maphongban;

            // Check if BirthDate is valid before assigning
            if (em.BirthDate < dateTimePicker1.MinDate || em.BirthDate > dateTimePicker1.MaxDate)
            {
                dateTimePicker1.Value = DateTime.Now; // Set to a sensible default
            }
            else
            {
                dateTimePicker1.Value = em.BirthDate;
            }

            // Load employee image if available
            if (!string.IsNullOrEmpty(em.ImagePath) && File.Exists(em.ImagePath))
            {
                pbEmployeeImage.Image = Image.FromFile(em.ImagePath);
            }
            else
            {
                pbEmployeeImage.Image = null;
            }
        }



        private void ClearInputFields()
        {
            tbName.Clear();
            tbAddress.Clear();
            tbMaduan.Clear();
            cbMaphongban.SelectedIndex = -1;
            rbMale.Checked = false;
            pbEmployeeImage.Image = null;
            dateTimePicker1.Value = DateTime.Now;

            // Hiển thị nextId vào tbId
            tbId.Text = nextId.ToString();
        }

        private void SetupImageList()
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(24, 24);

            try
            {
                imageList.Images.Add(Image.FromFile("Images/add.png"));
                imageList.Images.Add(Image.FromFile("Images/edit.png"));
                imageList.Images.Add(Image.FromFile("Images/delete.png"));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Không tìm thấy tệp hình ảnh. Vui lòng kiểm tra đường dẫn tệp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btAddNew.ImageList = imageList;
            btAddNew.ImageIndex = 0;

            btEdit.ImageList = imageList;
            btEdit.ImageIndex = 1;

            btDelete.ImageList = imageList;
            btDelete.ImageIndex = 2;
        }

        private void btSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.webp)|*.jpg;*.jpeg;*.png;*.webp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    employeeImagePath = ofd.FileName;
                    pbEmployeeImage.Image = Image.FromFile(employeeImagePath);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            this.Text = dateTimePicker1.Value.ToString("dd MMMM yyyy");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                bs.DataSource = lstEmp; // Reset to full list
            }
            else
            {
                var filteredList = lstEmp.Where(emp =>
                    (emp.Name != null && emp.Name.ToLower().Contains(searchTerm)) ||
                    (emp.Address != null && emp.Address.ToLower().Contains(searchTerm)) ||
                    (emp.Maduan != null && emp.Maduan.ToLower().Contains(searchTerm)) ||
                    (emp.Maphongban != null && emp.Maphongban.ToLower().Contains(searchTerm)) ||
                    emp.Id.ToString().Contains(searchTerm) ||
                    emp.BirthDate.ToString("dd/MM/yyyy").Contains(searchTerm) ||
                    (emp.Gender ? "Male" : "Female").ToLower().Contains(searchTerm)
                ).ToList();

                bs.DataSource = filteredList; // Update BindingSource with filtered results
            }

            // Reset selection if the current selection no longer exists
            if (dgvEmployee.Rows.Count > 0)
            {
                dgvEmployee.CurrentCell = dgvEmployee.Rows[0].Cells[0]; // Select first row
            }
        }


    }
}
