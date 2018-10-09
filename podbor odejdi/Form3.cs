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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            Footbolka[] fb = new Footbolka[20];
            int kolvo_footb = 0,kolvo_shtanov=0,kolvo_obuv=0;
            Shtani[] sh = new Shtani[20];
            Obuv[] ob = new Obuv[20];
            for (int i = 0; i < 20; i++)
            {
                sh[i] = new Shtani();

                fb[i] = new Footbolka();

                ob[i] = new Obuv();

            }
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = Properties.Settings.Default.bd_odejdaConnectionString1;
            myConnection.Open();
            string query = "SELECT * FROM tb_footbolki ORDER BY st_id";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fb[kolvo_footb].id = (int)reader["st_id"];
                fb[kolvo_footb].nazvanie = (string)reader["st_nazvanie"];
                fb[kolvo_footb].pop = (int)reader["st_pop"];
                fb[kolvo_footb].min_t = (int)reader["st_min_temp"];
                fb[kolvo_footb].max_t = (int)reader["st_max_temp"];
                fb[kolvo_footb].kartinka = reader["st_kart"].ToString();
                kolvo_footb++;
            }
            reader.Close();
            myConnection.Close();
            for (int i = 0; i < kolvo_footb; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = fb[i].id;
                dataGridView1[1, i].Value = fb[i].nazvanie;
                dataGridView1[2, i].Value = fb[i].pop;
                dataGridView1[3, i].Value = fb[i].min_t;
                dataGridView1[4, i].Value = fb[i].max_t;
                dataGridView1[5, i].Value = fb[i].kartinka;
            }

            for (int i = 0; i < kolvo_footb; i++)
            {
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                dataGridView1[6, i].Value = Image.FromFile(dataGridView1[5, i].Value.ToString());
                
            }

            query = "SELECT * FROM tb_shtani";
            myConnection.Open();
            SqlCommand command2 = new SqlCommand(query, myConnection);
            reader = command2.ExecuteReader();

            while (reader.Read())
            {
                sh[kolvo_shtanov].id = (int)reader["st_id"];
                sh[kolvo_shtanov].nazvanie = (string)reader["st_nazvanie"];
                sh[kolvo_shtanov].pop = (int)reader["st_pop"];
                sh[kolvo_shtanov].min_t = (int)reader["st_min_temp"];
                sh[kolvo_shtanov].max_t = (int)reader["st_max_temp"];
                sh[kolvo_shtanov].kartinka = reader["st_kart"].ToString();
                kolvo_shtanov++;
            }
            reader.Close();
            myConnection.Close();

            for (int i = 0; i < kolvo_shtanov; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2[0, i].Value = sh[i].id;
                dataGridView2[1, i].Value = sh[i].nazvanie;
                dataGridView2[2, i].Value = sh[i].pop;
                dataGridView2[3, i].Value = sh[i].min_t;
                dataGridView2[4, i].Value = sh[i].max_t;
                dataGridView2[5, i].Value = sh[i].kartinka;

            }

            for (int i = 0; i < kolvo_shtanov; i++)
            {
                dataGridView2[6, i].Value = Image.FromFile(dataGridView2[5, i].Value.ToString());
            }

            query = "SELECT * FROM tb_obuv";
            myConnection.Open();
            SqlCommand command3 = new SqlCommand(query, myConnection);
            reader = command3.ExecuteReader();

            while (reader.Read())
            {
                ob[kolvo_obuv].id = (int)reader["st_id"];
                ob[kolvo_obuv].nazvanie = (string)reader["st_nazvanie"];
                ob[kolvo_obuv].pop = (int)reader["st_pop"];
                ob[kolvo_obuv].min_t = (int)reader["st_min_temp"];
                ob[kolvo_obuv].max_t = (int)reader["st_max_temp"];
                ob[kolvo_obuv].kartinka = reader["st_kart"].ToString();
                kolvo_obuv++;
            }
            reader.Close();
            myConnection.Close();

            for (int i = 0; i < kolvo_obuv; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3[0, i].Value = ob[i].id;
                dataGridView3[1, i].Value = ob[i].nazvanie;
                dataGridView3[2, i].Value = ob[i].pop;
                dataGridView3[3, i].Value = ob[i].min_t;
                dataGridView3[4, i].Value = ob[i].max_t;
                dataGridView3[5, i].Value = ob[i].kartinka;

            }

            for (int i = 0; i < kolvo_obuv; i++)
            {
                dataGridView3[6, i].Value = Image.FromFile(dataGridView3[5, i].Value.ToString());
            }
        }
    }
}
