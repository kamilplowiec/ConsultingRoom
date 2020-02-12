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
    public partial class Form1 : Form
    {
        ConnectionClass connection;

        public int UserId { get; set; }
        public int PersonId { get; set; }
        public TypyOsob UserType { get; set; }

        public Form1()
        {
            InitializeComponent();

            connection = new ConnectionClass();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            Logowanie logowanie = new Logowanie();
            logowanie.ShowDialog(this);

            if (logowanie.DialogResult == DialogResult.OK)
            {
                UserId = logowanie.UserId;

                MessageBox.Show("Zalogowano!");

                SuccessLogin();
            }
            else
            {
                this.Close();
            }
        }

        private void SuccessLogin()
        {
            var person = connection.GetPerson(connection.GetUser(UserId).Person_Id);

            PersonId = person.Id;
            UserType = (TypyOsob)person.PersonType_Id;

            label2.Text = person.Name + " " + person.Surname + " (" + ((TypyOsob)person.PersonType_Id).ToString() + ")";

            button7.Enabled = (UserType != TypyOsob.Lekarz);
        }


        //dodaj sekretarke
        private void button3_Click(object sender, EventArgs e)
        {
            DodajOsobe dodawanie = new DodajOsobe();
            dodawanie.TypOsoby = TypyOsob.Sekretarka; //sektretarka
            dodawanie.ShowDialog();
        }

        //wyloguj
        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            UserId = 0;
            PersonId = 0;

            UserType = 0;

            ShowLogin();
        }

        //dodaj lekarza
        private void button4_Click(object sender, EventArgs e)
        {
            DodajOsobe dodawanie = new DodajOsobe();
            dodawanie.TypOsoby = TypyOsob.Lekarz; //lekarz
            dodawanie.ShowDialog();
        }

        //rejestracja pacjenta
        private void button7_Click(object sender, EventArgs e)
        {
            DodajOsobe dodawanie = new DodajOsobe();
            dodawanie.TypOsoby = TypyOsob.Pacjent; //lekarz
            dodawanie.ShowDialog();
        }

        //rejestracja pacjenta
        private void button1_Click(object sender, EventArgs e)
        {
            Osoby osoby = new Osoby();
            osoby.TypOsoby = TypyOsob.Pacjent;
            osoby.ShowDialog();
        }

        //planowanie wizyty
        private void button3_Click_1(object sender, EventArgs e)
        {
            DodajWizyte dodawanie = new DodajWizyte();
            dodawanie.TypOsoby = UserType;
            dodawanie.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wizyty wizyty = new Wizyty();
            wizyty.PersonId = PersonId;
            wizyty.TypOsoby = UserType;
            wizyty.ShowDialog();
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum TypyOsob
    {
        Lekarz = 1,
        Sekretarka = 2,
        Pacjent = 3
    }
}
