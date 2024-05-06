using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DB_L3_MySQL_Connect
{
    public partial class Form1 : Form
    {
        private string selDB = "world";
        private string[] colList;
        MySqlConnection curConn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Вітаємо у нашій утиліті!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            curConn = MyDBConfig.GetDBConnection(selDB);
            try
            {
                curConn.Open();
                MessageBox.Show("З'єднання з сервером встановлено успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("На жаль, сталася помилка." +
                                "\nПомилка: " + ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selDB = "world";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selDB = "gas-fees";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (selDB)
            {
                case "world":
                    Tasks.Example(curConn, ref displayBox);
                    break;
                case "gas-fees":
                    Tasks.GasFees(curConn, ref displayBox);
                    break;
                default:
                    MessageBox.Show("Не вдалося знайти зазначеної " +
                        "бази даних на сервері.");
                    break;
            }
        }
    }
}
