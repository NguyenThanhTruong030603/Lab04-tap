using Lab04.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab04
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            StudentcontextDB context = new StudentcontextDB();
            List<Student> listStudent = context.Students.ToList(); //l y t t c sv
            List<ReportClass> listReport = new List<ReportClass>();
            foreach (Student i in listStudent)
            {
                ReportClass temp = new ReportClass();
                temp.StudentID = i.StudentID;
                temp.FullName = i.FullName;
                temp.AverageScore = i.AverageScore;
                temp.FalcultyName = i.Falculty.FalcultyName;
                listReport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "Report2.rdlc";
            var reportDataSource = new ReportDataSource("StudentDataSet", listReport);
            
            this.reportViewer1.LocalReport.DataSources.Clear(); 
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport(); 
            
            
        }
    }
}
