using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace podbor_odejdi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id, min, max,pop;
            string nazv, kart;
            Int32.TryParse(textBox1.Text, out id);
            Int32.TryParse(textBox3.Text, out min);
            Int32.TryParse(textBox4.Text, out max);
            Int32.TryParse(textBox6.Text, out pop);
            nazv = textBox2.Text;
            kart = textBox5.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            Properties.Settings.Default.bd_odejdaConnectionString1;
            conn.Open();

            // Создание класса, отвечающего за выполнение команд
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            // Формирование транзакции с нужным уровнем изоляции
            SqlTransaction transaction = conn.BeginTransaction(
            System.Data.IsolationLevel.ReadCommitted);
            comm.Transaction = transaction;

            // Выполнение транзакции
            try
            {
                // Выполнение команды вставки строки в таблицу tbStudents
                comm.CommandText = String.Format("INSERT INTO tb_"+comboBox1.SelectedItem.ToString()+" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", id, nazv,pop, min,max,kart);
                comm.ExecuteNonQuery();

                //// Выполнение команды изменения значения количества
                //comm.CommandText = "UPDATE tbGroups SET Count_stud=Count_stud + 1 WHERE ID = " + Tag;
                //comm.ExecuteNonQuery();

                // Фиксация транзакции если команды успешны
                transaction.Commit();
            }

            // Обработка и откат транзакции в случае ошибки
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить изменения " +
                ex.Message, "Ошибка");
                transaction.Rollback();
            }

            Close();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Хотя нет, лучше все|*.*|Только BMP|*.bmp|А лучше только JPG|*.jpg;*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
            }
        }
    }
}
