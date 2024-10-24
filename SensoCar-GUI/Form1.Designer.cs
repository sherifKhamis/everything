namespace SensoCar_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Header_Label = new System.Windows.Forms.Label();
            this.label_sensor = new System.Windows.Forms.Label();
            this.comboBox_sensor = new System.Windows.Forms.ComboBox();
            this.label_datum = new System.Windows.Forms.Label();
            this.datum_picker = new System.Windows.Forms.DateTimePicker();
            this.timePortionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label_uhrzeit = new System.Windows.Forms.Label();
            this.textBox_abstand = new System.Windows.Forms.TextBox();
            this.label_abstand = new System.Windows.Forms.Label();
            this.label_geschwindigkeit = new System.Windows.Forms.Label();
            this.textBox_geschwindigkeit = new System.Windows.Forms.TextBox();
            this.button_enter = new System.Windows.Forms.Button();
            this.button_Show = new System.Windows.Forms.Button();
            this.button_diagramm = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Header_Label
            // 
            this.Header_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Header_Label.AutoSize = true;
            this.Header_Label.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Header_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header_Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Header_Label.Location = new System.Drawing.Point(1122, 75);
            this.Header_Label.Name = "Header_Label";
            this.Header_Label.Size = new System.Drawing.Size(521, 113);
            this.Header_Label.TabIndex = 0;
            this.Header_Label.Text = "SensoCar ";
            this.Header_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_sensor
            // 
            this.label_sensor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_sensor.AutoSize = true;
            this.label_sensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sensor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_sensor.Location = new System.Drawing.Point(501, 681);
            this.label_sensor.Name = "label_sensor";
            this.label_sensor.Size = new System.Drawing.Size(147, 46);
            this.label_sensor.TabIndex = 1;
            this.label_sensor.Text = "Sensor";
            this.label_sensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_sensor
            // 
            this.comboBox_sensor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_sensor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox_sensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sensor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_sensor.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comboBox_sensor.FormattingEnabled = true;
            this.comboBox_sensor.Items.AddRange(new object[] {
            "SR",
            "SM",
            "SL"});
            this.comboBox_sensor.Location = new System.Drawing.Point(46, 780);
            this.comboBox_sensor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_sensor.Name = "comboBox_sensor";
            this.comboBox_sensor.Size = new System.Drawing.Size(149, 54);
            this.comboBox_sensor.TabIndex = 2;
            // 
            // label_datum
            // 
            this.label_datum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_datum.AutoSize = true;
            this.label_datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_datum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_datum.Location = new System.Drawing.Point(1200, 839);
            this.label_datum.Name = "label_datum";
            this.label_datum.Size = new System.Drawing.Size(137, 46);
            this.label_datum.TabIndex = 3;
            this.label_datum.Text = "Datum";
            this.label_datum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datum_picker
            // 
            this.datum_picker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.datum_picker.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.datum_picker.CustomFormat = "dd.MM.yyyy";
            this.datum_picker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datum_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datum_picker.Location = new System.Drawing.Point(806, 706);
            this.datum_picker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datum_picker.Name = "datum_picker";
            this.datum_picker.Size = new System.Drawing.Size(235, 44);
            this.datum_picker.TabIndex = 4;
            // 
            // timePortionDateTimePicker
            // 
            this.timePortionDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.timePortionDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePortionDateTimePicker.Location = new System.Drawing.Point(1801, 706);
            this.timePortionDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timePortionDateTimePicker.Name = "timePortionDateTimePicker";
            this.timePortionDateTimePicker.Size = new System.Drawing.Size(391, 44);
            this.timePortionDateTimePicker.TabIndex = 5;
            // 
            // label_uhrzeit
            // 
            this.label_uhrzeit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_uhrzeit.AutoSize = true;
            this.label_uhrzeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_uhrzeit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_uhrzeit.Location = new System.Drawing.Point(1170, 708);
            this.label_uhrzeit.Name = "label_uhrzeit";
            this.label_uhrzeit.Size = new System.Drawing.Size(146, 46);
            this.label_uhrzeit.TabIndex = 6;
            this.label_uhrzeit.Text = "Uhrzeit";
            this.label_uhrzeit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_abstand
            // 
            this.textBox_abstand.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_abstand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_abstand.Location = new System.Drawing.Point(806, 391);
            this.textBox_abstand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_abstand.Name = "textBox_abstand";
            this.textBox_abstand.Size = new System.Drawing.Size(235, 44);
            this.textBox_abstand.TabIndex = 7;
            // 
            // label_abstand
            // 
            this.label_abstand.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_abstand.AutoSize = true;
            this.label_abstand.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_abstand.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_abstand.Location = new System.Drawing.Point(793, 291);
            this.label_abstand.Name = "label_abstand";
            this.label_abstand.Size = new System.Drawing.Size(166, 46);
            this.label_abstand.TabIndex = 8;
            this.label_abstand.Text = "Abstand";
            this.label_abstand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_geschwindigkeit
            // 
            this.label_geschwindigkeit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_geschwindigkeit.AutoSize = true;
            this.label_geschwindigkeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_geschwindigkeit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_geschwindigkeit.Location = new System.Drawing.Point(1611, 291);
            this.label_geschwindigkeit.Name = "label_geschwindigkeit";
            this.label_geschwindigkeit.Size = new System.Drawing.Size(311, 46);
            this.label_geschwindigkeit.TabIndex = 9;
            this.label_geschwindigkeit.Text = "Geschwindigkeit";
            this.label_geschwindigkeit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_geschwindigkeit
            // 
            this.textBox_geschwindigkeit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_geschwindigkeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_geschwindigkeit.Location = new System.Drawing.Point(1623, 391);
            this.textBox_geschwindigkeit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_geschwindigkeit.Name = "textBox_geschwindigkeit";
            this.textBox_geschwindigkeit.Size = new System.Drawing.Size(235, 44);
            this.textBox_geschwindigkeit.TabIndex = 10;
            // 
            // button_enter
            // 
            this.button_enter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_enter.Location = new System.Drawing.Point(1693, 928);
            this.button_enter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(450, 168);
            this.button_enter.TabIndex = 11;
            this.button_enter.Text = "Eingabe";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click);
            // 
            // button_Show
            // 
            this.button_Show.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Show.Location = new System.Drawing.Point(1143, 928);
            this.button_Show.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(450, 168);
            this.button_Show.TabIndex = 13;
            this.button_Show.Text = "Daten anzeigen";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button_Show_click);
            // 
            // button_diagramm
            // 
            this.button_diagramm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_diagramm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_diagramm.Location = new System.Drawing.Point(591, 928);
            this.button_diagramm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_diagramm.Name = "button_diagramm";
            this.button_diagramm.Size = new System.Drawing.Size(450, 168);
            this.button_diagramm.TabIndex = 14;
            this.button_diagramm.Text = "Diagramm";
            this.button_diagramm.UseVisualStyleBackColor = true;
            this.button_diagramm.Click += new System.EventHandler(this.button_diagramm_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(82, 250);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(479, 324);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(2500, 1486);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_diagramm);
            this.Controls.Add(this.button_Show);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_geschwindigkeit);
            this.Controls.Add(this.label_geschwindigkeit);
            this.Controls.Add(this.label_abstand);
            this.Controls.Add(this.textBox_abstand);
            this.Controls.Add(this.label_uhrzeit);
            this.Controls.Add(this.timePortionDateTimePicker);
            this.Controls.Add(this.datum_picker);
            this.Controls.Add(this.label_datum);
            this.Controls.Add(this.comboBox_sensor);
            this.Controls.Add(this.label_sensor);
            this.Controls.Add(this.Header_Label);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "SensoCar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header_Label;
        private System.Windows.Forms.Label label_sensor;
        private System.Windows.Forms.ComboBox comboBox_sensor;
        private System.Windows.Forms.Label label_datum;
        private System.Windows.Forms.DateTimePicker datum_picker;
        private System.Windows.Forms.DateTimePicker timePortionDateTimePicker;
        private System.Windows.Forms.Label label_uhrzeit;
        private System.Windows.Forms.TextBox textBox_abstand;
        private System.Windows.Forms.Label label_abstand;
        private System.Windows.Forms.Label label_geschwindigkeit;
        private System.Windows.Forms.TextBox textBox_geschwindigkeit;
        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.Button button_diagramm;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

