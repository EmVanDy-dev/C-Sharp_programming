
namespace SystemParking
{
    partial class FormCustomer
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textDriver = new System.Windows.Forms.TextBox();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPlatNo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.textPype = new System.Windows.Forms.TextBox();
            this.textPlateNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ComboSection = new System.Windows.Forms.ComboBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlatNo)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textDriver, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textPhone, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textPype, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textPlateNo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.ComboSection, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textAddress, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textAmount, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 379F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(941, 654);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textDriver
            // 
            this.textDriver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDriver.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.textDriver.ForeColor = System.Drawing.Color.DarkGray;
            this.textDriver.Location = new System.Drawing.Point(223, 426);
            this.textDriver.Multiline = true;
            this.textDriver.Name = "textDriver";
            this.textDriver.Size = new System.Drawing.Size(244, 29);
            this.textDriver.TabIndex = 2;
            this.textDriver.Text = "Driver";
            this.textDriver.Enter += new System.EventHandler(this.textDriver_Enter);
            this.textDriver.Leave += new System.EventHandler(this.textDriver_Leave);
            // 
            // textPhone
            // 
            this.textPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPhone.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.textPhone.ForeColor = System.Drawing.Color.DarkGray;
            this.textPhone.Location = new System.Drawing.Point(223, 495);
            this.textPhone.Multiline = true;
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(244, 29);
            this.textPhone.TabIndex = 7;
            this.textPhone.Text = "Phone";
            this.textPhone.Enter += new System.EventHandler(this.textBox7_Enter);
            this.textPhone.Leave += new System.EventHandler(this.textPhone_Leave);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.pictureBoxPlatNo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(223, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 373);
            this.panel1.TabIndex = 10;
            // 
            // pictureBoxPlatNo
            // 
            this.pictureBoxPlatNo.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxPlatNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPlatNo.Image = global::SystemParking.Properties.Resources.database_administrator_40px;
            this.pictureBoxPlatNo.Location = new System.Drawing.Point(0, 40);
            this.pictureBoxPlatNo.Name = "pictureBoxPlatNo";
            this.pictureBoxPlatNo.Size = new System.Drawing.Size(494, 333);
            this.pictureBoxPlatNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPlatNo.TabIndex = 1;
            this.pictureBoxPlatNo.TabStop = false;
            this.pictureBoxPlatNo.Click += new System.EventHandler(this.pictureBoxPlatNo_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.labelTime);
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 40);
            this.panel2.TabIndex = 0;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelTime.Location = new System.Drawing.Point(4, 17);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(40, 23);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "time";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDate.Location = new System.Drawing.Point(3, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(41, 23);
            this.labelDate.TabIndex = 3;
            this.labelDate.Text = "Date";
            // 
            // textPype
            // 
            this.textPype.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPype.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.textPype.ForeColor = System.Drawing.Color.DarkGray;
            this.textPype.Location = new System.Drawing.Point(223, 531);
            this.textPype.Multiline = true;
            this.textPype.Name = "textPype";
            this.textPype.Size = new System.Drawing.Size(244, 29);
            this.textPype.TabIndex = 1;
            this.textPype.Text = "Type";
            this.textPype.Enter += new System.EventHandler(this.textPype_Enter);
            this.textPype.Leave += new System.EventHandler(this.textPype_Leave);
            // 
            // textPlateNo
            // 
            this.textPlateNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPlateNo.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPlateNo.ForeColor = System.Drawing.Color.DarkGray;
            this.textPlateNo.Location = new System.Drawing.Point(473, 426);
            this.textPlateNo.Multiline = true;
            this.textPlateNo.Name = "textPlateNo";
            this.textPlateNo.Size = new System.Drawing.Size(244, 29);
            this.textPlateNo.TabIndex = 5;
            this.textPlateNo.Text = "Plate No";
            this.textPlateNo.Enter += new System.EventHandler(this.textPlateNo_Enter);
            this.textPlateNo.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnExit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLogin, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(473, 566);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 40);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(116, 34);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(125, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 34);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ComboSection
            // 
            this.ComboSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboSection.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSection.ForeColor = System.Drawing.Color.DarkGray;
            this.ComboSection.FormattingEnabled = true;
            this.ComboSection.Location = new System.Drawing.Point(223, 461);
            this.ComboSection.Name = "ComboSection";
            this.ComboSection.Size = new System.Drawing.Size(244, 31);
            this.ComboSection.TabIndex = 9;
            this.ComboSection.Text = "Section";
            this.ComboSection.Click += new System.EventHandler(this.comboBox1_Enter);
            this.ComboSection.Enter += new System.EventHandler(this.comboBox1_Enter);
            this.ComboSection.Leave += new System.EventHandler(this.textSection_Leave);
            this.ComboSection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboSection_MouseClick);
            // 
            // textAddress
            // 
            this.textAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textAddress.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.textAddress.ForeColor = System.Drawing.Color.DarkGray;
            this.textAddress.Location = new System.Drawing.Point(473, 461);
            this.textAddress.Multiline = true;
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(244, 28);
            this.textAddress.TabIndex = 3;
            this.textAddress.Text = "Home Adress";
            this.textAddress.Enter += new System.EventHandler(this.textPassword_Enter);
            this.textAddress.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // textAmount
            // 
            this.textAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textAmount.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.textAmount.ForeColor = System.Drawing.Color.DarkGray;
            this.textAmount.Location = new System.Drawing.Point(473, 495);
            this.textAmount.Multiline = true;
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(244, 29);
            this.textAmount.TabIndex = 8;
            this.textAmount.Text = "Price";
            this.textAmount.Enter += new System.EventHandler(this.textBox8_Enter);
            this.textAmount.Leave += new System.EventHandler(this.textAmount_Leave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(106)))), ((int)(((byte)(93)))));
            this.ClientSize = new System.Drawing.Size(941, 654);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCustomer";
            this.Text = "FormCustomer";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlatNo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textPype;
        private System.Windows.Forms.TextBox textDriver;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textPlateNo;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.TextBox textAmount;
        private System.Windows.Forms.ComboBox ComboSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxPlatNo;
    }
}