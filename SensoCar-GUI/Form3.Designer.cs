namespace SensoCar_GUI
{
    partial class Diagrammkonfigurator
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
            this.Header_Label = new System.Windows.Forms.Label();
            this.datum_picker = new System.Windows.Forms.DateTimePicker();
            this.datum_picker_2 = new System.Windows.Forms.DateTimePicker();
            this.label_datum = new System.Windows.Forms.Label();
            this.label_datum2 = new System.Windows.Forms.Label();
            this.button_enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Header_Label
            // 
            this.Header_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Header_Label.AutoSize = true;
            this.Header_Label.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Header_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header_Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Header_Label.Location = new System.Drawing.Point(160, 38);
            this.Header_Label.Name = "Header_Label";
            this.Header_Label.Size = new System.Drawing.Size(482, 64);
            this.Header_Label.TabIndex = 1;
            this.Header_Label.Text = "Diagrammanzeige";
            this.Header_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datum_picker
            // 
            this.datum_picker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.datum_picker.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.datum_picker.CustomFormat = "dd-MM-yyyy";
            this.datum_picker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datum_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datum_picker.Location = new System.Drawing.Point(99, 265);
            this.datum_picker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datum_picker.Name = "datum_picker";
            this.datum_picker.Size = new System.Drawing.Size(235, 44);
            this.datum_picker.TabIndex = 5;
            // 
            // datum_picker_2
            // 
            this.datum_picker_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.datum_picker_2.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.datum_picker_2.CustomFormat = "dd-MM-yyyy";
            this.datum_picker_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datum_picker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datum_picker_2.Location = new System.Drawing.Point(577, 265);
            this.datum_picker_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datum_picker_2.Name = "datum_picker_2";
            this.datum_picker_2.Size = new System.Drawing.Size(235, 44);
            this.datum_picker_2.TabIndex = 6;
            // 
            // label_datum
            // 
            this.label_datum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_datum.AutoSize = true;
            this.label_datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_datum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_datum.Location = new System.Drawing.Point(137, 176);
            this.label_datum.Name = "label_datum";
            this.label_datum.Size = new System.Drawing.Size(214, 46);
            this.label_datum.TabIndex = 7;
            this.label_datum.Text = "Startdatum";
            this.label_datum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_datum2
            // 
            this.label_datum2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_datum2.AutoSize = true;
            this.label_datum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_datum2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_datum2.Location = new System.Drawing.Point(610, 176);
            this.label_datum2.Name = "label_datum2";
            this.label_datum2.Size = new System.Drawing.Size(201, 46);
            this.label_datum2.TabIndex = 8;
            this.label_datum2.Text = "Enddatum";
            this.label_datum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_enter
            // 
            this.button_enter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_enter.Location = new System.Drawing.Point(307, 394);
            this.button_enter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(273, 110);
            this.button_enter.TabIndex = 12;
            this.button_enter.Text = "Eingabe";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click);
            // 
            // Diagrammkonfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.label_datum2);
            this.Controls.Add(this.label_datum);
            this.Controls.Add(this.datum_picker_2);
            this.Controls.Add(this.datum_picker);
            this.Controls.Add(this.Header_Label);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Diagrammkonfigurator";
            this.Text = "Diagrammkonfigurator";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header_Label;
        private System.Windows.Forms.DateTimePicker datum_picker;
        private System.Windows.Forms.DateTimePicker datum_picker_2;
        private System.Windows.Forms.Label label_datum;
        private System.Windows.Forms.Label label_datum2;
        private System.Windows.Forms.Button button_enter;
    }
}