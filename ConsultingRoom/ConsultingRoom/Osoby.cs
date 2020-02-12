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
    public partial class Osoby : Form
    {
        public TypyOsob TypOsoby { get; set; }

        ConnectionClass connection;
        public Osoby()
        {
            InitializeComponent();

            connection = new ConnectionClass();
        }

        private void Osoby_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataBindingComplete += (o, _) => //po zakonczeniu ladowania
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    DataGridViewButtonColumn wizyta = new DataGridViewButtonColumn();
                    wizyta.Name = "Wizyta";
                    wizyta.HeaderText = "Planuj wizytę";
                    wizyta.Text = "Planuj wizytę";
                    wizyta.UseColumnTextForButtonValue = true;
                    int columnIndex = dataGridView.ColumnCount;
                    if (dataGridView.Columns["wizyta"] == null)
                    {
                        dataGridView.Columns.Insert(columnIndex, wizyta);
                    }

                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["PersonType_Id"].Visible = false;

                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            };

            using (Model1 db = new Model1())
            {
                db.Person.Load();
                this.dataGridView1.DataSource = db.Person.Local.ToBindingList().Where(x => x.PersonType_Id == (int)TypOsoby).ToList();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["wizyta"].Index)
            {
                DodajWizyte dodawanie = new DodajWizyte();
                dodawanie.ForPersonName = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value + " " + dataGridView1.Rows[e.RowIndex].Cells["Surname"].Value;
                dodawanie.ShowDialog();
                //MessageBox.Show("Możliwość planowania wizyty z tego widoku! - " + dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
            }
            else
            {
                DodajOsobe osoba = new DodajOsobe();
                osoba.PersonId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                var dr = osoba.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    Osoby_Load(null, null);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
