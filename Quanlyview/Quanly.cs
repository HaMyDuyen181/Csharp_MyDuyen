using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Quanlyview
{
    public partial class Quanly : Form
    {
        public List<Employee> lstEmp = new List<Employee>();
        private BindingSource bs = new BindingSource();
        public bool isThoat = true;
        public event EventHandler DangXuat;

        private string employeeImagePath = string.Empty;
        private int nextId = 1; // Biến lưu trữ ID tiếp theo

        public Quanly()
        {
            InitializeComponent();
            SetupImageList();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void Quanly_Load(object sender, EventArgs e)
        {
            lstEmp = GetData();
            bs.DataSource = lstEmp;
            dgvEmployee.DataSource = bs;
            SetupDataGridView();
            dateTimePicker1.Value = DateTime.Now;

            // Cập nhật nextId dựa trên ID lớn nhất hiện tại
            if (lstEmp.Count > 0)
            {
                nextId = lstEmp.Max(emp => emp.Id) + 1;
            }

            // Hiển thị nextId vào tbId
            tbId.Text = nextId.ToString();
            tbId.ReadOnly = true; // Chỉ hiển thị ID chứ không cho sửa
        }

        public List<Employee> GetData()
        {
            // Dữ liệu mẫu nếu cần thiết
            return lstEmp;
        }

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
                // Kiểm tra các trường đầu vào (ngoại trừ ID)
                if (string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbAddress.Text) ||
                    string.IsNullOrWhiteSpace(tbMaduan.Text) ||
                    string.IsNullOrWhiteSpace(cbMaphongban.Text))
                {
                    MessageBox.Show("Lỗi: Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng mã sinh viên
                string newMaduan = tbMaduan.Text;
                if (lstEmp.Any(emp => emp.Maduan.Equals(newMaduan, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Lỗi: Mã Sinh Viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo nhân viên mới với nextId và tăng nextId
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

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow == null) return;

            int idx = dgvEmployee.CurrentRow.Index;
            Employee em = lstEmp[idx];

            try
            {
                if (string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbAddress.Text) ||
                    string.IsNullOrWhiteSpace(tbMaduan.Text) ||
                    string.IsNullOrWhiteSpace(cbMaphongban.Text))
                {
                    MessageBox.Show("Lỗi: Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newMaduan = tbMaduan.Text;
                if (lstEmp.Any(emp => emp.Maduan.Equals(newMaduan, StringComparison.OrdinalIgnoreCase) && emp.Id != em.Id))
                {
                    MessageBox.Show("Lỗi: Mã Sinh Viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
            if (dgvEmployee.CurrentRow == null) return;

            int idx = dgvEmployee.CurrentRow.Index;
            lstEmp.RemoveAt(idx);
            bs.ResetBindings(false);
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= lstEmp.Count) return;

            Employee em = lstEmp[e.RowIndex];

            tbId.Text = em.Id.ToString();
            tbName.Text = em.Name;
            rbMale.Checked = em.Gender;
            tbAddress.Text = em.Address;
            tbMaduan.Text = em.Maduan;
            cbMaphongban.Text = em.Maphongban;

            // Đặt giá trị ngày sinh mặc định nếu `BirthDate` không hợp lệ
            if (em.BirthDate < dateTimePicker1.MinDate || em.BirthDate > dateTimePicker1.MaxDate)
            {
                dateTimePicker1.Value = DateTime.Now; // hoặc một ngày hợp lệ khác
            }
            else
            {
                dateTimePicker1.Value = em.BirthDate;
            }

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

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
