using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensoCar_GUI
{
    public partial class Diagrammkonfigurator : Form
    {
        private Form1 _form1;
        private Diagramm _form2;

        public Diagrammkonfigurator(Form1 form1, Diagramm form2)
        {
            InitializeComponent();
            this.Size = new Size(500, 400); //Setzt Fenstergröße auf 500x400 Pixel
            StartPosition = FormStartPosition.CenterScreen; //Positioniert die Startposition des Fensters in der Mitte des Bildschirms
            _form1 = form1;
            _form2 = form2;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Platziert die Fensterelemente an die gewünschte Position 
            Header_Label.Left = (this.ClientSize.Width - Header_Label.Width) / 2;
            Header_Label.Top = (this.ClientSize.Height / 10);
            label_datum.Left = (this.ClientSize.Width / 8);
            label_datum.Top = (this.ClientSize.Height / 3);
            label_datum2.Left = (this.ClientSize.Width / 2);
            label_datum2.Top = (this.ClientSize.Height / 3);
            datum_picker.Left = (this.ClientSize.Width / 8);
            datum_picker.Top = (this.ClientSize.Height / 3 + 50);
            datum_picker_2.Left = (this.ClientSize.Width / 2);
            datum_picker_2.Top = (this.ClientSize.Height / 3 + 50);
            button_enter.Left = (this.ClientSize.Width / 3);
            button_enter.Top = (this.ClientSize.Height - 100);
        }


        private void button_enter_Click(object sender, EventArgs e)
        {
            // Sorgt dafür dass das 2.Fenster geöffnet wird und das 3.Fenster sich schließt
            Diagramm form2 = new Diagramm(_form1, datum_picker.Text, datum_picker_2.Text);
            form2.Show();
            this.Close();
        }
    }
}
