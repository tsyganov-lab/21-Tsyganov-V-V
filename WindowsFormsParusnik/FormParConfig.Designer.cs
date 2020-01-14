namespace WindowsFormsParusnik
{
    partial class FormParConfig
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
            this.pictureBoxParConfig = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelParusnik = new System.Windows.Forms.Label();
            this.labelLodka = new System.Windows.Forms.Label();
            this.panelParConfig = new System.Windows.Forms.Panel();
            this.labelDopCol = new System.Windows.Forms.Label();
            this.labelMainCol = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelOrange = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelBlue = new System.Windows.Forms.Panel();
            this.panelGrey = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.panelWhite = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.panelBlack = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParConfig)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelParConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParConfig
            // 
            this.pictureBoxParConfig.Location = new System.Drawing.Point(21, 17);
            this.pictureBoxParConfig.Name = "pictureBoxParConfig";
            this.pictureBoxParConfig.Size = new System.Drawing.Size(129, 96);
            this.pictureBoxParConfig.TabIndex = 0;
            this.pictureBoxParConfig.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelParusnik);
            this.groupBox1.Controls.Add(this.labelLodka);
            this.groupBox1.Location = new System.Drawing.Point(24, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип водного т/с";
            // 
            // labelParusnik
            // 
            this.labelParusnik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelParusnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParusnik.Location = new System.Drawing.Point(6, 99);
            this.labelParusnik.Name = "labelParusnik";
            this.labelParusnik.Size = new System.Drawing.Size(110, 28);
            this.labelParusnik.TabIndex = 1;
            this.labelParusnik.Text = "Парусник";
            this.labelParusnik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelParusnik.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelParusnik_MouseDown);
            // 
            // labelLodka
            // 
            this.labelLodka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLodka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLodka.Location = new System.Drawing.Point(6, 47);
            this.labelLodka.Name = "labelLodka";
            this.labelLodka.Size = new System.Drawing.Size(111, 29);
            this.labelLodka.TabIndex = 0;
            this.labelLodka.Text = "Лодка";
            this.labelLodka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLodka.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelLodka_MouseDown);
            // 
            // panelParConfig
            // 
            this.panelParConfig.AllowDrop = true;
            this.panelParConfig.Controls.Add(this.labelDopCol);
            this.panelParConfig.Controls.Add(this.labelMainCol);
            this.panelParConfig.Controls.Add(this.pictureBoxParConfig);
            this.panelParConfig.Location = new System.Drawing.Point(158, 37);
            this.panelParConfig.Name = "panelParConfig";
            this.panelParConfig.Size = new System.Drawing.Size(168, 218);
            this.panelParConfig.TabIndex = 2;
            this.panelParConfig.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelParConfig_DragDrop);
            this.panelParConfig.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelParConfig_DragEnter);
            // 
            // labelDopCol
            // 
            this.labelDopCol.AllowDrop = true;
            this.labelDopCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDopCol.Location = new System.Drawing.Point(33, 180);
            this.labelDopCol.Name = "labelDopCol";
            this.labelDopCol.Size = new System.Drawing.Size(106, 31);
            this.labelDopCol.TabIndex = 2;
            this.labelDopCol.Text = "Второстипенный цвет";
            this.labelDopCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDopCol.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDopCol_DragDrop);
            this.labelDopCol.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDopCol_DragEnter);
            // 
            // labelMainCol
            // 
            this.labelMainCol.AllowDrop = true;
            this.labelMainCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMainCol.Location = new System.Drawing.Point(33, 132);
            this.labelMainCol.Name = "labelMainCol";
            this.labelMainCol.Size = new System.Drawing.Size(106, 34);
            this.labelMainCol.TabIndex = 1;
            this.labelMainCol.Text = "Основной цвет";
            this.labelMainCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMainCol.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelMainCol_DragDrop);
            this.labelMainCol.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelMainCol_DragEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelOrange);
            this.groupBox2.Controls.Add(this.panelYellow);
            this.groupBox2.Controls.Add(this.panelBlue);
            this.groupBox2.Controls.Add(this.panelGrey);
            this.groupBox2.Controls.Add(this.panelRed);
            this.groupBox2.Controls.Add(this.panelWhite);
            this.groupBox2.Controls.Add(this.panelGreen);
            this.groupBox2.Controls.Add(this.panelBlack);
            this.groupBox2.Location = new System.Drawing.Point(348, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 225);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цвета";
            // 
            // panelOrange
            // 
            this.panelOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelOrange.Location = new System.Drawing.Point(82, 172);
            this.panelOrange.Name = "panelOrange";
            this.panelOrange.Size = new System.Drawing.Size(37, 35);
            this.panelOrange.TabIndex = 1;
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.Color.Yellow;
            this.panelYellow.Location = new System.Drawing.Point(82, 122);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(37, 35);
            this.panelYellow.TabIndex = 6;
            // 
            // panelBlue
            // 
            this.panelBlue.BackColor = System.Drawing.Color.Blue;
            this.panelBlue.Location = new System.Drawing.Point(82, 72);
            this.panelBlue.Name = "panelBlue";
            this.panelBlue.Size = new System.Drawing.Size(37, 35);
            this.panelBlue.TabIndex = 5;
            // 
            // panelGrey
            // 
            this.panelGrey.BackColor = System.Drawing.Color.Gray;
            this.panelGrey.Location = new System.Drawing.Point(11, 172);
            this.panelGrey.Name = "panelGrey";
            this.panelGrey.Size = new System.Drawing.Size(37, 35);
            this.panelGrey.TabIndex = 4;
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.Color.Red;
            this.panelRed.Location = new System.Drawing.Point(11, 122);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(37, 35);
            this.panelRed.TabIndex = 3;
            // 
            // panelWhite
            // 
            this.panelWhite.BackColor = System.Drawing.Color.White;
            this.panelWhite.Location = new System.Drawing.Point(82, 22);
            this.panelWhite.Name = "panelWhite";
            this.panelWhite.Size = new System.Drawing.Size(37, 35);
            this.panelWhite.TabIndex = 2;
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.Color.Green;
            this.panelGreen.Location = new System.Drawing.Point(11, 72);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(37, 35);
            this.panelGreen.TabIndex = 1;
            // 
            // panelBlack
            // 
            this.panelBlack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelBlack.Location = new System.Drawing.Point(11, 22);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(37, 35);
            this.panelBlack.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(41, 185);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(81, 25);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(41, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 25);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FormParConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 260);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelParConfig);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormParConfig";
            this.Text = "FormParConfig";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParConfig)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelParConfig.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelParusnik;
        private System.Windows.Forms.Label labelLodka;
        private System.Windows.Forms.Panel panelParConfig;
        private System.Windows.Forms.Label labelDopCol;
        private System.Windows.Forms.Label labelMainCol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelOrange;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.Panel panelBlue;
        private System.Windows.Forms.Panel panelGrey;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Panel panelWhite;
        private System.Windows.Forms.Panel panelGreen;
        private System.Windows.Forms.Panel panelBlack;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
    }
}