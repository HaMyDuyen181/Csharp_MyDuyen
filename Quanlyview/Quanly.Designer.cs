namespace Quanlyview
{
    partial class Quanly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quanly));
            btThoat = new Button();
            btDangXuat = new Button();
            dgvEmployee = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbId = new TextBox();
            tbName = new TextBox();
            rbMale = new CheckBox();
            btAddNew = new Button();
            btEdit = new Button();
            btDelete = new Button();
            label5 = new Label();
            tbAddress = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            cbMaphongban = new ComboBox();
            tbMaduan = new TextBox();
            pbEmployeeImage = new PictureBox();
            btSelectImage = new Button();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEmployeeImage).BeginInit();
            SuspendLayout();
            // 
            // btThoat
            // 
            btThoat.Location = new Point(578, 498);
            btThoat.Margin = new Padding(3, 4, 3, 4);
            btThoat.Name = "btThoat";
            btThoat.Size = new Size(74, 32);
            btThoat.TabIndex = 0;
            btThoat.Text = "Thoát";
            btThoat.UseVisualStyleBackColor = true;
            btThoat.Click += btThoat_Click;
            // 
            // btDangXuat
            // 
            btDangXuat.Location = new Point(481, 498);
            btDangXuat.Margin = new Padding(3, 4, 3, 4);
            btDangXuat.Name = "btDangXuat";
            btDangXuat.Size = new Size(91, 32);
            btDangXuat.TabIndex = 1;
            btDangXuat.Text = "Đăng xuất";
            btDangXuat.UseVisualStyleBackColor = true;
            btDangXuat.Click += btDangXuat_Click;
            // 
            // dgvEmployee
            // 
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(14, 318);
            dgvEmployee.Margin = new Padding(3, 4, 3, 4);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.Size = new Size(661, 172);
            dgvEmployee.TabIndex = 2;
            dgvEmployee.RowEnter += dgvEmployee_RowEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Location = new Point(61, 59);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 3;
            label1.Text = "STT :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDark;
            label2.Location = new Point(61, 97);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên :";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlDark;
            label3.Location = new Point(19, 137);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 5;
            label3.Text = "Ngày sinh :";
            // 
            // tbId
            // 
            tbId.Location = new Point(106, 55);
            tbId.Margin = new Padding(3, 4, 3, 4);
            tbId.Name = "tbId";
            tbId.Size = new Size(166, 27);
            tbId.TabIndex = 6;
            // 
            // tbName
            // 
            tbName.Location = new Point(106, 93);
            tbName.Margin = new Padding(3, 4, 3, 4);
            tbName.Name = "tbName";
            tbName.Size = new Size(166, 27);
            tbName.TabIndex = 8;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.BackColor = SystemColors.ButtonFace;
            rbMale.Checked = true;
            rbMale.CheckState = CheckState.Checked;
            rbMale.Location = new Point(125, 167);
            rbMale.Margin = new Padding(3, 4, 3, 4);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(63, 24);
            rbMale.TabIndex = 9;
            rbMale.Text = "Nam";
            rbMale.UseVisualStyleBackColor = false;
            // 
            // btAddNew
            // 
            btAddNew.Location = new Point(14, 226);
            btAddNew.Margin = new Padding(3, 4, 3, 4);
            btAddNew.Name = "btAddNew";
            btAddNew.Size = new Size(56, 40);
            btAddNew.TabIndex = 10;
            btAddNew.UseVisualStyleBackColor = true;
            btAddNew.Click += btAddNew_Click;
            // 
            // btEdit
            // 
            btEdit.Location = new Point(95, 226);
            btEdit.Margin = new Padding(3, 4, 3, 4);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(56, 40);
            btEdit.TabIndex = 11;
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(168, 226);
            btDelete.Margin = new Padding(3, 4, 3, 4);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(56, 40);
            btDelete.TabIndex = 12;
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonFace;
            label5.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(216, 9);
            label5.Name = "label5";
            label5.Size = new Size(267, 35);
            label5.TabIndex = 13;
            label5.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(406, 55);
            tbAddress.Margin = new Padding(3, 4, 3, 4);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(239, 27);
            tbAddress.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlDark;
            label6.Location = new Point(302, 137);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 17;
            label6.Text = "Mã sinh viên :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlDark;
            label7.Location = new Point(337, 97);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 18;
            label7.Text = "Mã lớp :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlDark;
            label8.Location = new Point(338, 59);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 19;
            label8.Text = "Địa chỉ :";
            // 
            // cbMaphongban
            // 
            cbMaphongban.FormattingEnabled = true;
            cbMaphongban.Items.AddRange(new object[] { "CCQ2211A", "CCQ2211B", "CCQ2211C", "CCQ2211D", "CCQ2211E", "CCQ2211F", "CCQ2211G", "CCQ2211H", "CCQ2211I", "CCQ2211K", "CCQ2211L", "CCQ2211M", "CCQ2211N" });
            cbMaphongban.Location = new Point(406, 93);
            cbMaphongban.Margin = new Padding(3, 4, 3, 4);
            cbMaphongban.Name = "cbMaphongban";
            cbMaphongban.Size = new Size(239, 28);
            cbMaphongban.TabIndex = 20;
            // 
            // tbMaduan
            // 
            tbMaduan.Location = new Point(406, 132);
            tbMaduan.Margin = new Padding(3, 4, 3, 4);
            tbMaduan.Name = "tbMaduan";
            tbMaduan.Size = new Size(239, 27);
            tbMaduan.TabIndex = 21;
            // 
            // pbEmployeeImage
            // 
            pbEmployeeImage.BackColor = SystemColors.ButtonFace;
            pbEmployeeImage.Location = new Point(531, 171);
            pbEmployeeImage.Margin = new Padding(3, 4, 3, 4);
            pbEmployeeImage.Name = "pbEmployeeImage";
            pbEmployeeImage.Size = new Size(114, 107);
            pbEmployeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEmployeeImage.TabIndex = 22;
            pbEmployeeImage.TabStop = false;
            // 
            // btSelectImage
            // 
            btSelectImage.Location = new Point(406, 171);
            btSelectImage.Margin = new Padding(3, 4, 3, 4);
            btSelectImage.Name = "btSelectImage";
            btSelectImage.Size = new Size(109, 33);
            btSelectImage.TabIndex = 23;
            btSelectImage.Text = "Choose file...";
            btSelectImage.UseVisualStyleBackColor = true;
            btSelectImage.Click += btSelectImage_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(106, 132);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(166, 27);
            dateTimePicker1.TabIndex = 24;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(14, 294);
            label4.Name = "label4";
            label4.Size = new Size(147, 20);
            label4.TabIndex = 25;
            label4.Text = "Danh sách sinh viên";
            // 
            // Quanly
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(688, 531);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(btSelectImage);
            Controls.Add(pbEmployeeImage);
            Controls.Add(tbMaduan);
            Controls.Add(cbMaphongban);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbAddress);
            Controls.Add(label5);
            Controls.Add(btDelete);
            Controls.Add(btEdit);
            Controls.Add(btAddNew);
            Controls.Add(rbMale);
            Controls.Add(tbName);
            Controls.Add(tbId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvEmployee);
            Controls.Add(btDangXuat);
            Controls.Add(btThoat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Quanly";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ SINH VIÊN";
            FormClosed += Quanly_FormClosed;
            Load += Quanly_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEmployeeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btThoat;
        private Button btDangXuat;
        private DataGridView dgvEmployee;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbId;
        private TextBox tbName;
        private CheckBox rbMale;
        private Button btAddNew;
        private Button btEdit;
        private Button btDelete;
        private Label label5;
        private TextBox tbAddress;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox cbMaphongban;
        private TextBox tbMaduan;
        private PictureBox pbEmployeeImage;
        private Button btSelectImage;
        private DateTimePicker dateTimePicker1;
        private Label label4;
    }
}