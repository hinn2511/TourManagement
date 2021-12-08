namespace TourManagement.GUI.GiaoDienThongKe
{
    partial class Gui_ThongKe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.childThongKePanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThongKeNhanVien = new FontAwesome.Sharp.IconButton();
            this.btnThongKeDoan = new FontAwesome.Sharp.IconButton();
            this.btnThongKeTour = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.childThongKePanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1257, 755);
            this.panel1.TabIndex = 0;
            // 
            // childThongKePanel
            // 
            this.childThongKePanel.BackColor = System.Drawing.Color.Transparent;
            this.childThongKePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childThongKePanel.Location = new System.Drawing.Point(10, 60);
            this.childThongKePanel.Name = "childThongKePanel";
            this.childThongKePanel.Size = new System.Drawing.Size(1237, 685);
            this.childThongKePanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnThongKeNhanVien);
            this.panel2.Controls.Add(this.btnThongKeDoan);
            this.panel2.Controls.Add(this.btnThongKeTour);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1237, 50);
            this.panel2.TabIndex = 0;
            // 
            // btnThongKeNhanVien
            // 
            this.btnThongKeNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKeNhanVien.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThongKeNhanVien.FlatAppearance.BorderSize = 0;
            this.btnThongKeNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeNhanVien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKeNhanVien.ForeColor = System.Drawing.Color.Black;
            this.btnThongKeNhanVien.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnThongKeNhanVien.IconColor = System.Drawing.Color.Black;
            this.btnThongKeNhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKeNhanVien.IconSize = 24;
            this.btnThongKeNhanVien.Location = new System.Drawing.Point(403, 0);
            this.btnThongKeNhanVien.Name = "btnThongKeNhanVien";
            this.btnThongKeNhanVien.Size = new System.Drawing.Size(160, 50);
            this.btnThongKeNhanVien.TabIndex = 17;
            this.btnThongKeNhanVien.Text = "NHÂN VIÊN";
            this.btnThongKeNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKeNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKeNhanVien.UseVisualStyleBackColor = false;
            this.btnThongKeNhanVien.Click += new System.EventHandler(this.btnThongKeNhanVien_Click);
            // 
            // btnThongKeDoan
            // 
            this.btnThongKeDoan.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKeDoan.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThongKeDoan.FlatAppearance.BorderSize = 0;
            this.btnThongKeDoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeDoan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKeDoan.ForeColor = System.Drawing.Color.Black;
            this.btnThongKeDoan.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.btnThongKeDoan.IconColor = System.Drawing.Color.Black;
            this.btnThongKeDoan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKeDoan.IconSize = 24;
            this.btnThongKeDoan.Location = new System.Drawing.Point(201, 0);
            this.btnThongKeDoan.Name = "btnThongKeDoan";
            this.btnThongKeDoan.Size = new System.Drawing.Size(202, 50);
            this.btnThongKeDoan.TabIndex = 16;
            this.btnThongKeDoan.Text = "CHI PHÍ TOUR";
            this.btnThongKeDoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKeDoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKeDoan.UseVisualStyleBackColor = false;
            this.btnThongKeDoan.Click += new System.EventHandler(this.btnThongKeDoan_Click);
            // 
            // btnThongKeTour
            // 
            this.btnThongKeTour.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKeTour.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThongKeTour.FlatAppearance.BorderSize = 0;
            this.btnThongKeTour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeTour.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKeTour.ForeColor = System.Drawing.Color.White;
            this.btnThongKeTour.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            this.btnThongKeTour.IconColor = System.Drawing.Color.White;
            this.btnThongKeTour.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKeTour.IconSize = 24;
            this.btnThongKeTour.Location = new System.Drawing.Point(0, 0);
            this.btnThongKeTour.Name = "btnThongKeTour";
            this.btnThongKeTour.Size = new System.Drawing.Size(201, 50);
            this.btnThongKeTour.TabIndex = 15;
            this.btnThongKeTour.Text = "LỢI NHUẬN TOUR";
            this.btnThongKeTour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKeTour.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKeTour.UseVisualStyleBackColor = false;
            this.btnThongKeTour.Click += new System.EventHandler(this.btnThongKeTour_Click);
            // 
            // Gui_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 755);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gui_ThongKe";
            this.Text = "Đoàn Du Lịch";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel childThongKePanel;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnThongKeTour;
        private FontAwesome.Sharp.IconButton btnThongKeDoan;
        private FontAwesome.Sharp.IconButton btnThongKeNhanVien;
    }
}