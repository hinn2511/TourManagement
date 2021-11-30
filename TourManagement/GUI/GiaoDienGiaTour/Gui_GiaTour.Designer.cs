namespace TourManagement.GUI.GiaoDienGiaTour
{
    partial class Gui_GiaTour
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
            this.panelTen = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.giaTourGridView = new System.Windows.Forms.DataGridView();
            this.panelDuoiTimKiem = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.txtTenTour = new System.Windows.Forms.Label();
            this.btnApDung = new FontAwesome.Sharp.IconButton();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.panelTen.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.giaTourGridView)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTen
            // 
            this.panelTen.BackColor = System.Drawing.Color.LightSalmon;
            this.panelTen.Controls.Add(this.label1);
            this.panelTen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTen.Location = new System.Drawing.Point(0, 0);
            this.panelTen.Name = "panelTen";
            this.panelTen.Size = new System.Drawing.Size(1227, 70);
            this.panelTen.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GIÁ TOUR";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelTen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 672);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panelDuoiTimKiem);
            this.panel2.Controls.Add(this.panelMenu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1227, 602);
            this.panel2.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.giaTourGridView);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(10, 80);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1207, 512);
            this.panel8.TabIndex = 11;
            // 
            // giaTourGridView
            // 
            this.giaTourGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.giaTourGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.giaTourGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.giaTourGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.giaTourGridView.Location = new System.Drawing.Point(0, 0);
            this.giaTourGridView.Name = "giaTourGridView";
            this.giaTourGridView.ReadOnly = true;
            this.giaTourGridView.RowHeadersWidth = 51;
            this.giaTourGridView.RowTemplate.Height = 24;
            this.giaTourGridView.Size = new System.Drawing.Size(1207, 512);
            this.giaTourGridView.TabIndex = 1;
            this.giaTourGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.giaTourGridView_CellClick);
            // 
            // panelDuoiTimKiem
            // 
            this.panelDuoiTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDuoiTimKiem.Location = new System.Drawing.Point(10, 60);
            this.panelDuoiTimKiem.Name = "panelDuoiTimKiem";
            this.panelDuoiTimKiem.Size = new System.Drawing.Size(1207, 20);
            this.panelDuoiTimKiem.TabIndex = 10;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Controls.Add(this.txtTenTour);
            this.panelMenu.Controls.Add(this.btnApDung);
            this.panelMenu.Controls.Add(this.btnThem);
            this.panelMenu.Controls.Add(this.btnSua);
            this.panelMenu.Controls.Add(this.btnXoa);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(10, 10);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1207, 50);
            this.panelMenu.TabIndex = 7;
            // 
            // txtTenTour
            // 
            this.txtTenTour.AutoSize = true;
            this.txtTenTour.BackColor = System.Drawing.Color.Transparent;
            this.txtTenTour.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenTour.ForeColor = System.Drawing.Color.Black;
            this.txtTenTour.Location = new System.Drawing.Point(3, 16);
            this.txtTenTour.Name = "txtTenTour";
            this.txtTenTour.Size = new System.Drawing.Size(56, 19);
            this.txtTenTour.TabIndex = 4;
            this.txtTenTour.Text = "TOUR";
            // 
            // btnApDung
            // 
            this.btnApDung.BackColor = System.Drawing.Color.DarkOrange;
            this.btnApDung.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApDung.FlatAppearance.BorderSize = 0;
            this.btnApDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDung.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnApDung.ForeColor = System.Drawing.Color.White;
            this.btnApDung.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnApDung.IconColor = System.Drawing.Color.White;
            this.btnApDung.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnApDung.IconSize = 24;
            this.btnApDung.Location = new System.Drawing.Point(651, 0);
            this.btnApDung.Name = "btnApDung";
            this.btnApDung.Size = new System.Drawing.Size(166, 50);
            this.btnApDung.TabIndex = 3;
            this.btnApDung.Text = "ÁP DỤNG";
            this.btnApDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApDung.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApDung.UseVisualStyleBackColor = false;
            this.btnApDung.Click += new System.EventHandler(this.btnApDung_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThem.IconColor = System.Drawing.Color.White;
            this.btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem.IconSize = 24;
            this.btnThem.Location = new System.Drawing.Point(817, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 50);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "THÊM";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.btnSua.IconColor = System.Drawing.Color.White;
            this.btnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSua.IconSize = 24;
            this.btnSua.Location = new System.Drawing.Point(947, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 50);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "SỬA";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Crimson;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoa.IconColor = System.Drawing.Color.White;
            this.btnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoa.IconSize = 24;
            this.btnXoa.Location = new System.Drawing.Point(1077, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 50);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Gui_GiaTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 672);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gui_GiaTour";
            this.Text = "Giá Tour";
            this.panelTen.ResumeLayout(false);
            this.panelTen.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.giaTourGridView)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView giaTourGridView;
        private System.Windows.Forms.Panel panelDuoiTimKiem;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnXoa;
        private FontAwesome.Sharp.IconButton btnApDung;
        private System.Windows.Forms.Label txtTenTour;
    }
}