using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gernale_03LabExercise01
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[] {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }
        /////return methods 
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{10,11}$"))
            {
                _StudentNo = long.Parse(studNum);
            }

            else
            {

                throw new FormatException("Error! Student Number must only contain numerical values.");

            }


            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            else
            {

                throw new FormatException("Error! Contact Number must only contain numerical values.");

            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-z A-Z]+$") && Regex.IsMatch(FirstName, @"^[a-z A-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-z A-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {

                throw new FormatException("Error! Name must only contain alphabetical values.");

            }
            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {

                throw new FormatException("Error! Age must only contain numerical values.");

            }

            return _Age;

            {

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text,
                txtFirstName.Text, txtMiddleInitial.Text);

                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);

                StudentInformationClass.SetProgram = cbPrograms.Text;

                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();

            }

            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load_1(object sender, EventArgs e)
        {

        }

        private void cbGender_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }

 }
