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
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Collections;
using System.Web;


namespace podbor_odejdi
{
    public partial class Form1 : Form
    {
        Shtani[] sh = new Shtani[20];
        Shtani[] sh_pod = new Shtani[20];
        int kolvo_shtanov = 0,kolvo_pod_shtan,perviy_vibor=2,vtoroy_vibor=7,temp_min=0,temp_max=0;
        Footbolka[] fb = new Footbolka[20];
        Footbolka[] fb_pod = new Footbolka[20];
        int kolvo_footb = 0,kolvo_pod_footb, temp_00=0,temp_03=0,temp_06=0,temp_09=0,temp_12=0,temp_15=0,temp_18=0,temp_21=0;
        Obuv[] ob = new Obuv[20];
        Obuv[] ob_pod = new Obuv[20];
        string[] pogoda_na_den = new string[8];
        int kolvo_obuv = 0, kolvo_pod_obuv;
        int[] vremya_vibrano = new int[8];
        int[] temperatura = new int[8];
        bool est_foot=false, est_shtan=false, est_obuv=false;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                sh[i] = new Shtani();
                sh_pod[i] = new Shtani();
                fb[i] = new Footbolka();
                fb_pod[i] = new Footbolka();
                ob[i] = new Obuv();
                ob_pod[i] = new Obuv();
            }
            LoadData();
            UznatPogodu();
            VremyaVibrano(2, 7);


        }
        public Footbolka get_max_pop_footb(Footbolka[] f,int kolvo)
        {
            int max_pop = f[0].pop, max_num = 0;
            for(int i=0;i<kolvo;i++)
            {
                if (max_pop < f[i].pop)
                    max_num = i;
            }
            return f[max_num];
        }
        public Shtani get_max_pop_shtan(Shtani[] f, int kolvo)
        {
            int max_pop = f[0].pop, max_num = 0;
            for (int i = 0; i < kolvo; i++)
            {
                if (max_pop < f[i].pop)
                    max_num = i;
            }
            return f[max_num];
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if(perviy_vibor<0)
            {
                perviy_vibor = 0;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 0)
                {
                    vtoroy_vibor = 0;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 1;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 1)
                {
                    vtoroy_vibor = 1;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 2;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 2)
                {
                    vtoroy_vibor = 2;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 3;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 3)
                {
                    vtoroy_vibor = 3;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 4;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 4)
                {
                    vtoroy_vibor = 4;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 5;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 5)
                {
                    vtoroy_vibor = 5;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 6;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 6)
                {
                    vtoroy_vibor = 6;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (perviy_vibor < 0)
            {
                perviy_vibor = 7;
                VremyaVibrano(perviy_vibor);
            }
            else
            {
                if (perviy_vibor != 7)
                {
                    vtoroy_vibor = 7;
                    VremyaVibrano(perviy_vibor, vtoroy_vibor);
                }
                else
                    label1.Text = "Выберите другое время";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 fm = new Form3();
            fm.ShowDialog();
        }

        public Obuv get_max_pop_obuv(Obuv[] f, int kolvo)
        {
            int max_pop = f[0].pop, max_num = 0;
            for (int i = 0; i < kolvo; i++)
            {
                if (max_pop < f[i].pop)
                    max_num = i;
            }
            return f[max_num];
        }
        public string GetHtmlPage(string url)
        {
            string HtmlText = string.Empty;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();
            return HtmlText;
        }
        private void LoadData()
        {
            vremya_vibrano[0] = 0;
            vremya_vibrano[1] = 0;
            vremya_vibrano[2] = 1;
            vremya_vibrano[3] = 0;
            vremya_vibrano[4] = 0;
            vremya_vibrano[5] = 0;
            vremya_vibrano[6] = 0;
            vremya_vibrano[7] = 1;

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
                sh[kolvo_shtanov].kartinka =reader["st_kart"].ToString();
                kolvo_shtanov++;
            }  
            reader.Close();
            myConnection.Close();

            

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

            

        }

        public void UznatPogodu()
        {
            string url = "https://www.gismeteo.ru/weather-simferopol-4995/";
            string html = GetHtmlPage(url);
            System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"C:\textfile.html");
            textFile.WriteLine(html);
            textFile.Close();
            int start = html.IndexOf("height: 79px");

            //int start = html.IndexOf("top: 4");
            //////int finish = html.IndexOf(@"</span><span class=""temp__unit i - font i - f");
            //pogoda_na_den[0] = html.Substring(start + 26, 3);
            //////61
            //pogoda_na_den[1] = html.Substring(start + 87, 3);
            //pogoda_na_den[2] = html.Substring(start + 148, 3);
            //pogoda_na_den[3] = html.Substring(start + 209, 3);
            //pogoda_na_den[4] = html.Substring(start + 269, 3);
            //pogoda_na_den[5] = html.Substring(start + 329, 3);
            //pogoda_na_den[6] = html.Substring(start + 389, 3);
            //pogoda_na_den[7] = html.Substring(start + 450, 3);

            //temperatura[0] = Int32.Parse(pogoda_na_den[0]);
            //temperatura[1] = Int32.Parse(pogoda_na_den[1]);
            //temperatura[2] = Int32.Parse(pogoda_na_den[2]);
            //temperatura[3] = Int32.Parse(pogoda_na_den[3]);
            //temperatura[4] = Int32.Parse(pogoda_na_den[4]);
            //temperatura[5] = Int32.Parse(pogoda_na_den[5]);
            //temperatura[6] = Int32.Parse(pogoda_na_den[6]);
            //temperatura[7] = Int32.Parse(pogoda_na_den[7]);

            //label5.Text += pogoda_na_den[0];
            //label6.Text += pogoda_na_den[1];
            //label7.Text += pogoda_na_den[2];
            //label8.Text += pogoda_na_den[3];
            //label9.Text += pogoda_na_den[4];
            //label10.Text += pogoda_na_den[5];
            //label11.Text += pogoda_na_den[6];
            //label12.Text += pogoda_na_den[7];

            //label5.Text += pogoda_na_den[0];
            //label6.Text += temperatura[1];
            //label7.Text += temperatura[2];
            //label8.Text += temperatura[3];
            //label9.Text += temperatura[4];
            //label10.Text += temperatura[5];
            //label11.Text += temperatura[6];
            //label12.Text += temperatura[7];


            ////int finish = html.IndexOf(@"</span><span class=""temp__unit i - font i - f");
            pogoda_na_den[0] = html.Substring(start + 120 , 3);
            ////61
            pogoda_na_den[1] = html.Substring(start + 181, 3);
            pogoda_na_den[2] = html.Substring(start + 242, 3);
            pogoda_na_den[3] = html.Substring(start + 303, 3);
            //60
            pogoda_na_den[4] = html.Substring(start + 363, 3);

            pogoda_na_den[5] = html.Substring(start + 423, 3);
            //57
            pogoda_na_den[6] = html.Substring(start + 483, 3);
            pogoda_na_den[7] = html.Substring(start + 544, 3);

            temperatura[0] = Int32.Parse(pogoda_na_den[0]);
            temperatura[1] = Int32.Parse(pogoda_na_den[1]);
            temperatura[2] = Int32.Parse(pogoda_na_den[2]);
            temperatura[3] = Int32.Parse(pogoda_na_den[3]);
            temperatura[4] = Int32.Parse(pogoda_na_den[4]);
            temperatura[5] = Int32.Parse(pogoda_na_den[5]);
            temperatura[6] = Int32.Parse(pogoda_na_den[6]);
            temperatura[7] = Int32.Parse(pogoda_na_den[7]);

            label5.Text += pogoda_na_den[0];
            label6.Text += pogoda_na_den[1];
            label7.Text += pogoda_na_den[2];
            label8.Text += pogoda_na_den[3];
            label9.Text += pogoda_na_den[4];
            label10.Text += pogoda_na_den[5];
            label11.Text += pogoda_na_den[6];
            label12.Text += pogoda_na_den[7];
        }

        public void IzmenitVremya(int chislo1)
        {
            vremya_vibrano[0] = 0;
            vremya_vibrano[1] = 0;
            vremya_vibrano[2] = 0;
            vremya_vibrano[3] = 0;
            vremya_vibrano[4] = 0;
            vremya_vibrano[5] = 0;
            vremya_vibrano[6] = 0;
            vremya_vibrano[7] = 0;
            vremya_vibrano[chislo1] = 1;

        }
        public void IzmenitVremya(int chislo1,int chislo2)
        {
            vremya_vibrano[0] = 0;
            vremya_vibrano[1] = 0;
            vremya_vibrano[2] = 0;
            vremya_vibrano[3] = 0;
            vremya_vibrano[4] = 0;
            vremya_vibrano[5] = 0;
            vremya_vibrano[6] = 0;
            vremya_vibrano[7] = 0;
            vremya_vibrano[chislo1] = 1;
            vremya_vibrano[chislo2] = 1;
        }

        public void VremyaVibrano(int chislo1)
        {
            IzmenitVremya(chislo1);

            if (vremya_vibrano[0] == 0)
                label5.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label5.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[1] == 0)
                label6.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label6.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[2] == 0)
                label7.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label7.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[3] == 0)
                label8.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label8.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[4] == 0)
                label9.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label9.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[5] == 0)
                label10.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label10.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[6] == 0)
                label11.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label11.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[7] == 0)
                label12.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label12.Font = new Font(label5.Font, FontStyle.Bold);
            label1.Text = "Выберите второе время";
        }

        public void VremyaVibrano(int chislo1,int chislo2)
        {
            IzmenitVremya(chislo1,chislo2);

            if(vremya_vibrano[0]==0)
                label5.Font = new Font(label5.Font,  FontStyle.Regular);
            else
                label5.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[1] == 0)
                label6.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label6.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[2] == 0)
                label7.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label7.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[3] == 0)
                label8.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label8.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[4] == 0)
                label9.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label9.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[5] == 0)
                label10.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label10.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[6] == 0)
                label11.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label11.Font = new Font(label5.Font, FontStyle.Bold);
            if (vremya_vibrano[7] == 0)
                label12.Font = new Font(label5.Font, FontStyle.Regular);
            else
                label12.Font = new Font(label5.Font, FontStyle.Bold);

            
            PodobratOdejdu();
            label1.Text = "Комплект собран";
            perviy_vibor = -1;
            vtoroy_vibor = -1;

            //label6.Font = new Font(label6.Font,  FontStyle.Regular);
            //label7.Font = new Font(label7.Font,  FontStyle.Regular);
            //label8.Font = new Font(label8.Font,  FontStyle.Regular);
            //label9.Font = new Font(label9.Font,  FontStyle.Regular);
            //label10.Font = new Font(label10.Font,  FontStyle.Regular);
            //label11.Font = new Font(label11.Font,  FontStyle.Regular);
            //label12.Font = new Font(label12.Font,  FontStyle.Regular);

            //switch (min)
            //{
            //    case 1:
            //        label5.Font = new Font(label5.Font,  FontStyle.Bold);
            //        break;
            //    case 2:
            //        label6.Font = new Font(label6.Font,  FontStyle.Bold);
            //        break;
            //    case 3:
            //        label7.Font = new Font(label7.Font,  FontStyle.Bold);
            //        break;
            //    case 4:
            //        label8.Font = new Font(label8.Font,  FontStyle.Bold);
            //        break;
            //    case 5:
            //        label9.Font = new Font(label9.Font,  FontStyle.Bold);
            //        break;
            //    case 6:
            //        label10.Font = new Font(label10.Font,  FontStyle.Bold);
            //        break;
            //    case 7:
            //        label11.Font = new Font(label11.Font,  FontStyle.Bold);
            //        break;
            //    case 8:
            //        label12.Font = new Font(label12.Font,  FontStyle.Bold);
            //        break;
            //    default:
            //        break;
            //}

            //switch (min)
            //{
            //    case 1:
            //        label5.Font = new Font(label5.Font, FontStyle.Bold);
            //        break;
            //    case 2:
            //        label6.Font = new Font(label6.Font, FontStyle.Bold);
            //        break;
            //    case 3:
            //        label7.Font = new Font(label7.Font, FontStyle.Bold);
            //        break;
            //    case 4:
            //        label8.Font = new Font(label8.Font, FontStyle.Bold);
            //        break;
            //    case 5:
            //        label9.Font = new Font(label9.Font, FontStyle.Bold);
            //        break;
            //    case 6:
            //        label10.Font = new Font(label10.Font, FontStyle.Bold);
            //        break;
            //    case 7:
            //        label11.Font = new Font(label11.Font, FontStyle.Bold);
            //        break;
            //    case 8:
            //        label12.Font = new Font(label12.Font, FontStyle.Bold);
            //        break;
            //    default:
            //        break;
            //}
        }

        public void VibratMaxMinTemp()
        {
            if (perviy_vibor < vtoroy_vibor)
            {
                temp_min = temperatura[perviy_vibor];
                temp_max = temperatura[perviy_vibor];
                for(int i=perviy_vibor;i<vtoroy_vibor+1;i++)
                {
                    if (temperatura[i] < temp_min)
                        temp_min = temperatura[i];

                    if (temperatura[i] > temp_max)
                        temp_max = temperatura[i];
                }
            }
            else
            {
                temp_min = temperatura[vtoroy_vibor];
                temp_max = temperatura[vtoroy_vibor];
                for (int i = vtoroy_vibor; i < vtoroy_vibor + 1; i++)
                {
                    if (temperatura[i] < temp_min)
                        temp_min = temperatura[i];

                    if (temperatura[i] > temp_max)
                        temp_max = temperatura[i];
                }
            }


            label2.Text = "Мин " + temp_min.ToString();
            label3.Text = "Макс " + temp_max.ToString();
        }

        public void PodobratOdejdu()
        {
            kolvo_pod_shtan = 0;
            kolvo_pod_footb = 0;
            kolvo_pod_footb = 0;
            
            VibratMaxMinTemp();

            for (int i = 0; i < kolvo_footb; i++)
            {
                if (fb[i].get_min_temp() < temp_min)
                {
                    if (fb[i].max_t > temp_max)
                    {
                        fb_pod[kolvo_pod_footb] = fb[i];
                        kolvo_pod_footb++;
                    }
                }
            }
            if (kolvo_pod_footb > 0)
            {
                est_foot = true;
            }
            Footbolka f_ok = get_max_pop_footb(fb_pod, kolvo_pod_footb);
            for (int i = 0; i < kolvo_shtanov; i++)
            {
                if (fb[i].get_min_temp() < temp_min)
                {
                    if (fb[i].max_t > temp_max)
                    {
                        sh_pod[kolvo_pod_shtan] = sh[i];
                        kolvo_pod_shtan++;
                    }
                }
            }
            Shtani sh_ok = get_max_pop_shtan(sh_pod, kolvo_pod_shtan);
            if (kolvo_pod_shtan > 0)
            {
                est_shtan = true;
            }
            for (int i = 0; i < kolvo_obuv; i++)
            {
                if (ob[i].min_t < temp_min)
                {
                    if (ob[i].max_t > temp_max)
                    {
                        ob_pod[kolvo_pod_obuv] = ob[i];
                        kolvo_pod_obuv++;
                    }
                }
            }
            Obuv ob_ok = get_max_pop_obuv(ob_pod, kolvo_pod_obuv);
            if (kolvo_pod_obuv > 0)
            {
                est_obuv = true;
            }
            if (est_foot & est_obuv & est_shtan)
            {


                
                pictureBox1.Image = Image.FromFile(f_ok.kartinka);
                pictureBox2.Image = Image.FromFile(sh_ok.kartinka);
                pictureBox3.Image = Image.FromFile(ob_ok.kartinka);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.ShowDialog();
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
