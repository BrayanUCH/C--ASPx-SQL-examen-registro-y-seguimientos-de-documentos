using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CapaPresentacion
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

            
        }

        public void DeteccionDeReporte(string reporte)
        {
            Eleccion_de_reporte(reporte);
        }

        void Eleccion_de_reporte(string tabla)
        {
            ReportDocument reporte = new ReportDocument();
            reporte.Load(@"..\..\Reportes\R_ORGANIZACION_A.rpt");
            //reporte.Load(@"..\..\Reportes\"+ tabla + ".rpt");
            crvReporte.ReportSource = reporte;
        }
    }
}
