using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class VistaFactura : Form
    {
        public VistaFactura()
        {
            InitializeComponent();
        }

        public void AsignarReporte(ReportDocument report)
        {
            crystalReportViewer3.ReportSource = report;
            crystalReportViewer3.Refresh();
        }

    }
}
