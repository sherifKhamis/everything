using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensoCar_GUI
{
    public partial class Form1 : Form
    { 
        private Diagramm form2;
    
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1200, 800); //Setzt Fenstergröße auf 1200x800 Pixel
            StartPosition = FormStartPosition.CenterScreen; //Positioniert die Startposition des Fensters in der Mitte des Bildschirms
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Platziert die Fensterelemente an die gewünschte Position 
            Header_Label.Left = (this.ClientSize.Width - Header_Label.Width) / 2;
            Header_Label.Top = (this.ClientSize.Height / 10);
            label_geschwindigkeit.Left = label_uhrzeit.Left + 100;
            label_geschwindigkeit.Top = textBox_geschwindigkeit.Top - this.ClientSize.Height / 20;
            textBox_geschwindigkeit.Left = label_geschwindigkeit.Left + 25;
            textBox_geschwindigkeit.Top = this.ClientSize.Height / 3;
            comboBox_sensor.Left = (this.ClientSize.Width / 10);
            comboBox_sensor.Top = this.ClientSize.Height / 3;
            label_sensor.Left = comboBox_sensor.Left;
            label_sensor.Top = comboBox_sensor.Top - this.ClientSize.Height / 20;
            datum_picker.Left = label_sensor.Left;
            label_datum.Left = datum_picker.Left;
            label_datum.Top = datum_picker.Top - this.ClientSize.Height / 20;
            label_uhrzeit.Left = (this.ClientSize.Width / 2) + this.ClientSize.Width / 4;
            label_uhrzeit.Top = timePortionDateTimePicker.Top - this.ClientSize.Height / 20;
            textBox_abstand.Left = (this.ClientSize.Width / 2) - 125;
            textBox_abstand.Top = this.ClientSize.Height / 3;
            label_abstand.Left = textBox_abstand.Left;
            label_abstand.Top = textBox_abstand.Top - this.ClientSize.Height / 20;
            button_enter.Left = this.ClientSize.Width / 3;
            button_enter.Top = timePortionDateTimePicker.Top + this.ClientSize.Height / 5;
            button_Show.Left = (this.ClientSize.Width / 3) - 350;
            button_Show.Top = button_enter.Top;
            button_diagramm.Left = (this.ClientSize.Width / 3) + 350;
            button_diagramm.Top = button_enter.Top;

            timePortionDateTimePicker.Left = label_uhrzeit.Left - 75;
            timePortionDateTimePicker.Format = DateTimePickerFormat.Time;
            timePortionDateTimePicker.ShowUpDown = true;

            richTextBox1.Left = label_datum.Left + 280;
            richTextBox1.Top = label_datum.Top - 50;
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            // Speichert Benutzereingaben in Variablen 
            string sensor = comboBox_sensor.Text;
            string abstand = textBox_abstand.Text;
            string geschwindigkeit = textBox_geschwindigkeit.Text;
            string datum = datum_picker.Text;
            string uhrzeit = timePortionDateTimePicker.Text;

            // Setzt Benutzereingabefelder zurück 
            comboBox_sensor.SelectedIndex = -1;
            textBox_abstand.Clear();
            textBox_geschwindigkeit.Clear();
            datum_picker.Value = DateTime.Now.Date;
            timePortionDateTimePicker.Value = DateTime.Now.Date + DateTime.Now.TimeOfDay;

            // Überprüft ob Eingabefelder noch leer sind 
            if (sensor == "" || abstand == "" || geschwindigkeit == "")
            {
                MessageBox.Show("Eingabewerte ohne Inhalt!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Schreibt Benutzereinge in CSV Datei 
            List <string> ausgabe = new List <string>();
            ausgabe.Add($"{sensor};{datum};{uhrzeit};{geschwindigkeit};{abstand}");
            using (StreamWriter sw = new StreamWriter("Sensordaten.csv",true))
            {
                foreach (string s in ausgabe)
                {
                    sw.WriteLine(s);
                }
            }

            MessageBox.Show("Eingabe erfolgreich!");
        }

        private void button_Show_click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            // Liest die Inhalte der CSV Datei und speichert Sie in Sensordaten
            List<List<string>> Sensordaten = new List<List<string>>();
            string inhalt = "";
            using (StreamReader sr = new StreamReader("Sensordaten.csv"))
            {
                while (inhalt != null)
                {
                    inhalt = sr.ReadLine();
                    if (inhalt != ";;;;" && inhalt != null)
                        Sensordaten.Add(new List<string>(inhalt.Split(';')));
                }
            }

            // Schreibt die Inhalte von Sensordaten in die Textbox
            foreach (var s in Sensordaten)
            {
                double verhaeltnis = Convert.ToDouble(s[3]) / Convert.ToDouble(s[4]);
                if (verhaeltnis <= 2)
                    richTextBox1.SelectionColor = Color.Green;
                else
                    richTextBox1.SelectionColor = Color.Red;
  
                foreach (string s2 in s)
                    richTextBox1.AppendText(s2 + " | ");
                richTextBox1.AppendText(Environment.NewLine);
            }
        }

        private void button_diagramm_Click(object sender, EventArgs e)
        {
            Diagrammkonfigurator form3 = new Diagrammkonfigurator(this, form2);
            form3.Show();
            this.Hide();

        }


    }
}

