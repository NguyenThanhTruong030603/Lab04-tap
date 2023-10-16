using Lab04.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Form1 : Form
    {
    // Minh CUong da o day
       
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StudentcontextDB  context= new StudentcontextDB();
                List<Falculty> listFalcultys = context.Falculties.ToList();
                List<Student> listStudent = context.Students.ToList(); 
                FillFalcultyCombobox(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillFalcultyCombobox(List<Falculty> listFalcultys)
        {
            this.CbKhoa.DataSource = listFalcultys;
            this.CbKhoa.DisplayMember = "FalcultyName";
            this.CbKhoa.ValueMember = "FalcultyID";
        }
        //Hàm binding gridView từ list sinh viên
        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Falculty.FalcultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            StudentcontextDB context = new StudentcontextDB();
            //1. lấy tất cả các sinh viên từ bảng Student
            List<Student> listStudent = context.Students.ToList();

            Student s = new Student()
            {
                StudentID = txtMSSV.Text,
                FullName = txtHoten.Text,
                AverageScore = float.Parse(txtDTB.Text),
                FalcultyID =(int) CbKhoa.SelectedValue
               
            };
            context.Students.Add(s);
            context.SaveChanges();
            BindGrid(context.Students.ToList());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            StudentcontextDB context = new StudentcontextDB();
            //1. lấy tất cả các sinh viên từ bảng Student
            List<Student> listStudent = context.Students.ToList();
            //2. lấy sinh viên đầu tiên có StudentID = ID cho trước
            Student db = context.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            Student dbDelete = context.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            if (dbDelete != null)
            {
                context.Students.Remove(db);
                context.SaveChanges(); // lưu thay dổi
                BindGrid(context.Students.ToList());
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            StudentcontextDB context = new StudentcontextDB();
            //1. lấy tất cả các sinh viên từ bảng Student
            List<Student> listStudent = context.Students.ToList();
            //1. lấy tất cả các sinh viên từ bảng Student
            
            //2. lấy sinh viên đầu tiên có StudentID = ID cho trước
            Student db = context.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            Student dbUpdate = context.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            if (dbUpdate != null)
            {
                dbUpdate.FullName = txtHoten.Text; 
                dbUpdate.AverageScore = float.Parse(txtDTB.Text);
                dbUpdate.FalcultyID = (int)CbKhoa.SelectedValue;
                context.SaveChanges(); //lưu thay đổi
                BindGrid(context.Students.ToList());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
