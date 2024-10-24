using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LINQtoCSV;


namespace SensoCar_GUI
{
    public partial class Diagramm : Form
    {
        private Form1 _form1;

        public int[] s_datum = new int[3];
        public int[] e_datum = new int[3];

        public Diagramm(Form1 form1, string startDatum, string endDatum)
        {
            InitializeComponent();
            this.Size = new Size(1200, 800); // Setzt die Größe des Fensters auf 1200x800 Pixel 
            StartPosition = FormStartPosition.CenterScreen; // Sorgt dafür dass die Startposition des Fenster in der Mitte des Bildschirms ist
            _form1 = form1;

            // Da das format von start- und endDatum = dd-mm-yyyy ist, wird nach "-" gefiltert und die jeweiligen Zahlen werden 
            // in einem string array einzeln gespeichert 
            string[] sdatum = startDatum.Split('-'); 
            string[] edatum = endDatum.Split('-');

            // Die Inhalte des String arrays werden dann in integer konvertiert und im integer array s_datum bzw. e_datum gespeichert
            for (int i = 0; i < 3; i++)
            {
                s_datum[i] = Convert.ToInt32(sdatum[i]);
                e_datum[i] = Convert.ToInt32(edatum[i]);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Setze Größe und Position von Chart1
            chart1.Size = new Size(1200, 267);
            chart1.Left = 0;
            chart1.Top = 0;

            // Speichere die Inhalte der CSV Datei in Sensordaten 
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

            // Konfiguriere Chart1 
            var Abstand_graph = chart1.Series.Add("Abstand");
            Abstand_graph.ChartType = SeriesChartType.Line;
            Abstand_graph.Color = Color.DarkRed;
            Abstand_graph.BorderWidth = 3;

            // Platziere die Punkte in Chart1 wenn das Datum stimmt
            for (int i = 0; i < Sensordaten.Count(); i++)
            {
                int[] iDatum = new int[3];
                string[] datum = Sensordaten[i][1].Split('.');
                for (int j = 0; j < 3; j++)
                {
                    
                    iDatum[j] = Convert.ToInt32(datum[j]);
                }

                if ((iDatum[0] >= s_datum[0] && iDatum[0] <= e_datum[0]) && (iDatum[1] >= s_datum[1] && iDatum[1] <= e_datum[1]) && (iDatum[2] >= s_datum[2] && iDatum[2] <= e_datum[2]))
                {
                    string s = Sensordaten[i][4];
                    Abstand_graph.Points.AddXY(i, s);
                }
            }

            // Setze Größe und Position von Chart2
            chart2.Size = new Size(1200, 267);
            chart2.Left = 0;
            chart2.Top = 260;

            // Konfiguriere Chart2
            var Geschwindigkeit_graph = chart2.Series.Add("Geschwindigkeit");
            Geschwindigkeit_graph.ChartType = SeriesChartType.Line;
            Geschwindigkeit_graph.Color = Color.DarkBlue;
            Geschwindigkeit_graph.BorderWidth = 3;

            // Platziere die Punkte in Chart2 wenn das Datum stimmt
            for (int i = 0; i < Sensordaten.Count(); i++)
            {
                int[] iDatum = new int[3];
                string[] datum = Sensordaten[i][1].Split('.');
                for (int j = 0; j < 3; j++)
                {

                    iDatum[j] = Convert.ToInt32(datum[j]);
                }

                if ((iDatum[0] >= s_datum[0] && iDatum[0] <= e_datum[0]) && (iDatum[1] >= s_datum[1] && iDatum[1] <= e_datum[1]) && (iDatum[2] >= s_datum[2] && iDatum[2] <= e_datum[2]))
                {
                    string s = Sensordaten[i][3];
                    Geschwindigkeit_graph.Points.AddXY(i, s);
                }
            }

            // Setze Größe und Position von Chart3
            chart3.Size = new Size(1200, 267);
            chart3.Left = 0;
            chart3.Top = 510;

            // Konfiguriere Chart3
            var Verhaeltnis_Graph = chart3.Series.Add("Verhaeltnis");
            Verhaeltnis_Graph.ChartType = SeriesChartType.Line;
            Verhaeltnis_Graph.Color = Color.DarkGreen;
            Verhaeltnis_Graph.BorderWidth = 3;

            // Platziere die Punkte in Chart3 wenn das Datum stimmt
            List<double> Verhaeltnis = new List<double>();
            for (int i = 0; i < Sensordaten.Count(); i++)
            {
                
                int[] iDatum = new int[3];
                string[] datum = Sensordaten[i][1].Split('.');
                for (int j = 0; j < 3; j++)
                {

                    iDatum[j] = Convert.ToInt32(datum[j]);
                }

                if ((iDatum[0] >= s_datum[0] && iDatum[0] <= e_datum[0]) && (iDatum[1] >= s_datum[1] && iDatum[1] <= e_datum[1]) && (iDatum[2] >= s_datum[2] && iDatum[2] <= e_datum[2]))
                {
                    Verhaeltnis.Add(Convert.ToDouble(Sensordaten[i][3]) / Convert.ToDouble(Sensordaten[i][4]));
                }
            }
            double counter3 = 0;
            foreach (double d in Verhaeltnis)
            {
                Verhaeltnis_Graph.Points.AddXY(counter3, d);
                counter3++;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Zeigt 1. Fenster an, wenn 2. Fenster schließt 
            _form1.Show();
        }
    }
}
