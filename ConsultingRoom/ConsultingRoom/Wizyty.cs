using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultingRoom
{
    public partial class Wizyty : Form
    {
        public TypyOsob TypOsoby { get; set; }

        public int PersonId { get; set; }

        ConnectionClass connection;
        public Wizyty()
        {
            InitializeComponent();

            connection = new ConnectionClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Wizyty_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataBindingComplete += (o, _) => //po zakonczeniu ladowania
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.Columns["Id"].Visible = false;

                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };

            using (Model1 db = new Model1())
            {
                db.Visit.Load();
                if (TypOsoby == TypyOsob.Lekarz)
                {
                    this.dataGridView1.DataSource = db.Visit.Local.ToBindingList().Where(x => x.Doctor_Id == PersonId).Select(x =>
                        new
                        {
                            x.Id,
                            Osoba = connection.GetPerson(x.Person_Id).Name + " " + connection.GetPerson(x.Person_Id).Surname,
                            Data = x.Date,
                            Zrealizowana = x.VisitWasHeld
                        }
                    ).ToList();
                }
                else //jezeli sekretarka, wyswietl wszystkie
                {
                    this.dataGridView1.DataSource = db.Visit.Local.ToBindingList().Select(x =>
                        new
                        {
                            x.Id,
                            Osoba = connection.GetPerson(x.Person_Id).Name + " " + connection.GetPerson(x.Person_Id).Surname,
                            Lekarz = connection.GetPerson(x.Doctor_Id).Name + " " + connection.GetPerson(x.Doctor_Id).Surname,
                            Data = x.Date,
                            Zrealizowana = x.VisitWasHeld
                        }
                    ).ToList();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DodajWizyte wizyta = new DodajWizyte();
            wizyta.VisitId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            wizyta.TypOsoby = TypOsoby;
            var dr = wizyta.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                Wizyty_Load(null, null);
            }
        }
    }
}
