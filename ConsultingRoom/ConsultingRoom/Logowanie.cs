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
    public partial class Logowanie : Form
    {
        ConnectionClass connection;
        public Logowanie()
        {
            InitializeComponent();
            connection = new ConnectionClass();
        }

        public int UserId { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = connection.CheckUserLoginAndPassword(textBox1.Text, textBox2.Text);

            if (result == -1)
                MessageBox.Show("Niepoprawne hasło!");
            else if (result == 0)
                MessageBox.Show("Brak takiego użytkownika!");
            else
            {
                UserId = result;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
