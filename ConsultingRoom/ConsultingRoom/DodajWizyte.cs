using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultingRoom
{
    public partial class DodajWizyte : Form
    {
        ConnectionClass connection;

        public int VisitId { get; set; }

        public TypyOsob TypOsoby { get; set; }

        public string ForPersonName { get; set; }

        public DodajWizyte()
        {
            InitializeComponent();

            connection = new ConnectionClass();
        }

        private void DodajWizyte_Shown(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(connection.GetPersons().Where(x => x.PersonType_Id == (int)TypyOsob.Pacjent).Select(x => x.Name + " " + x.Surname).ToArray());

            comboBox2.Items.AddRange(connection.GetPersons().Where(x => x.PersonType_Id == (int)TypyOsob.Lekarz).Select(x => x.Name + " " + x.Surname).ToArray());

            if(VisitId > 0)
            {
                var visit = connection.GetVisit(VisitId);

                var person = connection.GetPerson(visit.Person_Id);

                var doctor = connection.GetPerson(visit.Doctor_Id);

                comboBox1.SelectedItem = person.Name + " " + person.Surname;

                comboBox2.SelectedItem = doctor.Name + " " + doctor.Surname;

                dateTimePicker1.Value = visit.Date;

                richTextBox1.Text = visit.Comment;

                checkBox1.Checked = visit.VisitWasHeld;
            }

            //jezeli lekarz, nie moze zmienic osoby, lekarza, daty

            if(TypOsoby == TypyOsob.Lekarz && VisitId > 0)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
            }

            if(TypOsoby == TypyOsob.Sekretarka)
            {
                checkBox1.Enabled = false;
            }

            if(!string.IsNullOrEmpty(ForPersonName))
            {
                comboBox1.SelectedItem = ForPersonName;
                comboBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var person = connection.GetPersons().FirstOrDefault(x => x.Name + " " + x.Surname == comboBox1.SelectedItem.ToString());

            if (person == null)
            {
                MessageBox.Show("Wybierz osobę!");
                return;
            }

            var doctor = connection.GetPersons().FirstOrDefault(x => x.Name + " " + x.Surname == comboBox2.SelectedItem.ToString());

            if (doctor == null)
            {
                MessageBox.Show("Wybierz lekarza!");
                return;
            }

            int doctorId = doctor.Id;

            if (VisitId == 0)
            {
                bool checkDoctorFreeTime = connection.CheckDoctorVisitInTime(doctorId, dateTimePicker1.Value);

                if (checkDoctorFreeTime)
                {
                    MessageBox.Show("Wybrany lekarz ma umówioną wizytę w tym terminie!");
                    return;
                }
            }

            int personId = person.Id;

            Visit visit = new Visit();

            if (VisitId > 0)
                visit.Id = VisitId;

            visit.Doctor_Id = doctorId;
            visit.Person_Id = personId;
            visit.Comment = richTextBox1.Text;
            visit.Date = dateTimePicker1.Value;
            visit.VisitWasHeld = checkBox1.Checked;

            connection.AddVisit(visit);

            this.DialogResult = DialogResult.OK;
        }
    }
}
