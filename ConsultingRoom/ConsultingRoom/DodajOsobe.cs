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
    public partial class DodajOsobe : Form
    {
        ConnectionClass connection;

        public int PersonId { get; set; }

        public TypyOsob TypOsoby { get; set; }

        private Person Osoba { get; set; }

        public DodajOsobe()
        {
            InitializeComponent();

            connection = new ConnectionClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Pola: Imię, Nazwisko, Adres, Pesel muszą być uzupełnione!");
                return;
            }

            if (textBox1.Text.Length > 50)
            {
                MessageBox.Show("Pole Imię jest za długie!");
                return;
            }

            if (textBox2.Text.Length > 50)
            {
                MessageBox.Show("Pole Nazwisko jest za długie!");
                return;
            }

            if (textBox3.Text.Length > 200)
            {
                MessageBox.Show("Pole Adres jest za długie!");
                return;
            }

            if (textBox4.Text.Length > 10)
            {
                MessageBox.Show("Pole Telefon jest za długie!");
                return;
            }

            if (textBox5.Text.Length > 25)
            {
                MessageBox.Show("Pole Email jest za długie!");
                return;
            }

            long i;
            if (textBox6.Text.Length != 11 || !long.TryParse(textBox6.Text.ToString(), out i))
            {
                MessageBox.Show("Pole Pesel jest niepoprawnie uzupełnione (długość PESEL to 11 cyfr)!");
                return;
            }

            if (TypOsoby != TypyOsob.Pacjent)
            {
                if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
                {
                    MessageBox.Show("Pola: Login i Hasło musza byc uzupełnione!");
                    return;
                }

                if (textBox7.Text.Length > 50)
                {
                    MessageBox.Show("Pole Login jest za długie!");
                    return;
                }

                if (textBox8.Text.Length > 50)
                {
                    MessageBox.Show("Pole Hasło jest za długie!");
                    return;
                }
            }

            Person p = new Person();

            if (PersonId > 0)
                p.Id = PersonId;

            p.Name = textBox1.Text;
            p.Surname = textBox2.Text;
            p.Address = textBox3.Text;
            p.Phone = textBox4.Text;
            p.Email = textBox5.Text;
            p.Pesel = textBox6.Text;

            p.PersonType_Id = (int)TypOsoby;

            int id = connection.AddPerson(p);

            if(TypOsoby != TypyOsob.Pacjent)
            {
                User u = new User();
                u.Person_Id = id;
                u.Login = textBox7.Text;
                u.Password = textBox8.Text;

                connection.AddUser(u);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void DodajOsobe_Shown(object sender, EventArgs e)
        {
            if (PersonId > 0)
            {
                Osoba = connection.GetPerson(PersonId);

                TypOsoby = (TypyOsob)Osoba.PersonType_Id;

                textBox1.Text = Osoba.Name;
                textBox2.Text = Osoba.Surname;
                textBox3.Text = Osoba.Address;
                textBox4.Text = Osoba.Phone;
                textBox5.Text = Osoba.Email;
                textBox6.Text = Osoba.Pesel;
            }

            if (TypOsoby == 0) //domyslnie rejestracja pacjenta
                TypOsoby = TypyOsob.Pacjent;

            if (TypOsoby != TypyOsob.Pacjent) //jezeli nie pacjent, tworz konto
            {
                label7.Visible = true;
                label8.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;

                if (PersonId > 0)
                {
                    var user = connection.GetUserByPersonId(PersonId);
                    textBox7.Text = user.Login;
                    textBox8.Text = user.Password;
                }
            }

            switch(TypOsoby)
            {
                case TypyOsob.Lekarz:
                    this.Text = "Dodaj lekarza";
                    break;

                case TypyOsob.Sekretarka:
                    this.Text = "Dodaj sekretarke";
                    break;

                case TypyOsob.Pacjent:
                    this.Text = "Dodaj pacjenta";
                    break;
            }
        }
    }
}
