
namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    partial class OrderCart
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ilosc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userAddressCity = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.userAddressStreetNumber = new System.Windows.Forms.TextBox();
            this.userAddressPostalCode = new System.Windows.Forms.TextBox();
            this.userAddressApartmentNumber = new System.Windows.Forms.TextBox();
            this.userAddressStreet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userFamilyName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericuserPhoneNumber = new System.Windows.Forms.NumericUpDown();
            this.userEmail = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userComments = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericuserPhoneNumber)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(171, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "SFINALIZUJ ZAMÓWIENIE";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(663, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 317);
            this.panel1.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(128, 257);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.Cena,
            this.Ilosc});
            this.dataGridView1.Location = new System.Drawing.Point(10, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(216, 210);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // Nazwa
            // 
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            // 
            // Cena
            // 
            this.Cena.HeaderText = "Cena za szt";
            this.Cena.Name = "Cena";
            // 
            // Ilosc
            // 
            this.Ilosc.HeaderText = "Ilość";
            this.Ilosc.Name = "Ilosc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kwota całkowita:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "TWOJE ZAMÓWIENIE";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(663, 370);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(244, 58);
            this.button5.TabIndex = 8;
            this.button5.Text = "KONTYNUUJ ZAMÓWIENIE";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userAddressCity);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.userAddressStreetNumber);
            this.panel2.Controls.Add(this.userAddressPostalCode);
            this.panel2.Controls.Add(this.userAddressApartmentNumber);
            this.panel2.Controls.Add(this.userAddressStreet);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(4, 41);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(653, 170);
            this.panel2.TabIndex = 14;
            // 
            // userAddressCity
            // 
            this.userAddressCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userAddressCity.FormattingEnabled = true;
            this.userAddressCity.Items.AddRange(new object[] {
            "Łódź"});
            this.userAddressCity.Location = new System.Drawing.Point(285, 136);
            this.userAddressCity.Name = "userAddressCity";
            this.userAddressCity.Size = new System.Drawing.Size(278, 23);
            this.userAddressCity.TabIndex = 13;
            this.userAddressCity.SelectedIndexChanged += new System.EventHandler(this.userAddressCity_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "Numer ulicy:";
            // 
            // userAddressStreetNumber
            // 
            this.userAddressStreetNumber.Location = new System.Drawing.Point(7, 98);
            this.userAddressStreetNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userAddressStreetNumber.Name = "userAddressStreetNumber";
            this.userAddressStreetNumber.Size = new System.Drawing.Size(264, 23);
            this.userAddressStreetNumber.TabIndex = 11;
            // 
            // userAddressPostalCode
            // 
            this.userAddressPostalCode.Location = new System.Drawing.Point(7, 136);
            this.userAddressPostalCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userAddressPostalCode.Name = "userAddressPostalCode";
            this.userAddressPostalCode.Size = new System.Drawing.Size(264, 23);
            this.userAddressPostalCode.TabIndex = 9;
            this.userAddressPostalCode.TextChanged += new System.EventHandler(this.userAddressPostalCode_TextChanged);
            // 
            // userAddressApartmentNumber
            // 
            this.userAddressApartmentNumber.Location = new System.Drawing.Point(285, 99);
            this.userAddressApartmentNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userAddressApartmentNumber.Name = "userAddressApartmentNumber";
            this.userAddressApartmentNumber.Size = new System.Drawing.Size(279, 23);
            this.userAddressApartmentNumber.TabIndex = 7;
            this.userAddressApartmentNumber.TextChanged += new System.EventHandler(this.userAddressApartmentNumber_TextChanged);
            // 
            // userAddressStreet
            // 
            this.userAddressStreet.Location = new System.Drawing.Point(5, 55);
            this.userAddressStreet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userAddressStreet.MaxLength = 50;
            this.userAddressStreet.Name = "userAddressStreet";
            this.userAddressStreet.Size = new System.Drawing.Size(559, 23);
            this.userAddressStreet.TabIndex = 6;
            this.userAddressStreet.TextChanged += new System.EventHandler(this.userAddressStreet_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(284, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Miasto:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Kod pocztowy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Numer mieszkania:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Adres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "ADRES DOSTAWY ZAMÓWIENIA:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.userFamilyName);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.numericuserPhoneNumber);
            this.panel3.Controls.Add(this.userEmail);
            this.panel3.Controls.Add(this.userName);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(4, 215);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(640, 133);
            this.panel3.TabIndex = 15;
            // 
            // userFamilyName
            // 
            this.userFamilyName.Location = new System.Drawing.Point(285, 56);
            this.userFamilyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userFamilyName.Name = "userFamilyName";
            this.userFamilyName.Size = new System.Drawing.Size(279, 23);
            this.userFamilyName.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nazwisko:";
            // 
            // numericuserPhoneNumber
            // 
            this.numericuserPhoneNumber.Location = new System.Drawing.Point(284, 95);
            this.numericuserPhoneNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericuserPhoneNumber.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericuserPhoneNumber.Name = "numericuserPhoneNumber";
            this.numericuserPhoneNumber.Size = new System.Drawing.Size(279, 23);
            this.numericuserPhoneNumber.TabIndex = 10;
            // 
            // userEmail
            // 
            this.userEmail.Location = new System.Drawing.Point(7, 95);
            this.userEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(264, 23);
            this.userEmail.TabIndex = 8;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(7, 56);
            this.userName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(264, 23);
            this.userName.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Numer telefonu:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "E-mail:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Imię:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(1, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 28);
            this.label14.TabIndex = 0;
            this.label14.Text = "DANE KONTAKTOWE:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.userComments);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Location = new System.Drawing.Point(4, 352);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(640, 206);
            this.panel4.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(263, 156);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proszę, wybierz czas dostawy:";
            // 
            // userComments
            // 
            this.userComments.Location = new System.Drawing.Point(284, 56);
            this.userComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userComments.Name = "userComments";
            this.userComments.Size = new System.Drawing.Size(280, 23);
            this.userComments.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(284, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Uwagi:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(1, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(249, 28);
            this.label16.TabIndex = 0;
            this.label16.Text = "SZCZEGÓŁY ZAMÓWIENIA:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(758, 514);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 17;
            this.button1.Text = "Zrezygnuj";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 556);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderCart";
            this.Text = "OrderCart";
            this.Load += new System.EventHandler(this.OrderCart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericuserPhoneNumber)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox userAddressPostalCode;
        private System.Windows.Forms.TextBox userAddressApartmentNumber;
        private System.Windows.Forms.TextBox userAddressStreet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox userEmail;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox userComments;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox userAddressStreetNumber;
        private System.Windows.Forms.NumericUpDown numericuserPhoneNumber;
        private System.Windows.Forms.TextBox userFamilyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ilosc;
        private System.Windows.Forms.ComboBox userAddressCity;
    }
}