using SimpleCRUD.Presentation.WinSite.StudentRemoteServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRUD.Presentation.WinSite
{
    public partial class StudentsForm : Form
    {
        public StudentsForm()
        {
            InitializeComponent();
        }

        private StudentDTO ParseStudent()
        {
            return new StudentDTO()
            {
                Id = int.Parse(textId.Text),
                Name = textName.Text,
                Surname = textSurname.Text,
                Birthday = DateTime.Parse(textBirthday.Text)
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDTO student = ParseStudent();
                var service = new StudentRemoteServiceClient();
                service.Add(student);
                StudentDTO addedStudent = service.Get(student.Id);
                MessageBox.Show($"Student added:\nName: {addedStudent.Name}\nSurname: {addedStudent.Surname}\nBirthday: {addedStudent.Birthday:dd-MM-yyyy}\nAge: {addedStudent.Age}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new StudentRemoteServiceClient();
                StudentDTO retrievedStudent = service.Get(int.Parse(textId.Text));
                MessageBox.Show($"Retrieved Student:\n\tName: {retrievedStudent.Name}\n\tSurname: {retrievedStudent.Surname}\n\tBirthday: {retrievedStudent.Birthday:dd-MM-yyyy}\n\tAge: {retrievedStudent.Age}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDTO student = ParseStudent();
                var service = new StudentRemoteServiceClient();
                service.Update(student);
                StudentDTO updatedStudent = service.Get(student.Id);
                MessageBox.Show($"Student added:\nName: {updatedStudent.Name}\nSurname: {updatedStudent.Surname}\nBirthday: {updatedStudent.Birthday:dd-MM-yyyy}\nAge: {updatedStudent.Age}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDTO student = ParseStudent();
                var service = new StudentRemoteServiceClient();
                service.Remove(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
