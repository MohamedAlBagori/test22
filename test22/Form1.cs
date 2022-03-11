using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test22
{
    public partial class Form1 : Form
    {
       


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cn;
            string cs = @"Data source=.\sqlexpress ;initial catalog =GMOM;user Id = sa;Password=123456";
            cn = new SqlConnection(cs);
            cn.Open();

            SqlCommand com = new SqlCommand("select id_cl,nom_cl from client", cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            guna2ComboBox1.DisplayMember = "nom_cl";
            guna2ComboBox1.ValueMember = "id_cl";
            guna2ComboBox1.DataSource = dt;

            dr.Close();
            dr =null;
            com = null;
            cn.Close();
            cn = null;







            //MessageBox.Show("ok");






            /*dt.Columns.Add("Nom utilisteur");
            dt.Columns.Add("Mot de passe");
            dt.Columns.Add("Nom");
            dt.Columns.Add("Prénom");
            dt.Columns.Add("Date de création");
            dt.Columns.Add("Date d'expiration");


            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns[0].HeaderText = "Nom utilisateur";
            guna2DataGridView1.Columns[1].HeaderText = "Mot de passe";
            guna2DataGridView1.Columns[2].HeaderText = "Nom";
            guna2DataGridView1.Columns[3].HeaderText = "Prenom";
            guna2DataGridView1.Columns[4].HeaderText = "Date de création";
            guna2DataGridView1.Columns[5].HeaderText = "Date d'expiration";*/

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn;
            string cs = @"Data source=.\sqlexpress ;initial catalog =GMOM;user Id = sa;Password=123456";

            if (guna2ComboBox1.SelectedIndex != -1)
            {


                cn = new SqlConnection(cs);
                cn.Open();

                SqlCommand com = new SqlCommand("select * from monture where id_cl = " + guna2ComboBox1.SelectedValue, cn);
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                guna2DataGridView1.DataSource = dt;
                guna2DataGridView1.Columns[0].HeaderText = "Code de monture";
                guna2DataGridView1.Columns[1].HeaderText = "Type";
                guna2DataGridView1.Columns[2].HeaderText = "Catégorie";
                guna2DataGridView1.Columns[3].HeaderText = "Quantité";
                guna2DataGridView1.Columns[4].HeaderText = "Prix";
                guna2DataGridView1.Columns[5].HeaderText = "Code de client";
                guna2DataGridView1.Columns[6].HeaderText = "Code de facture";
                //guna2ComboBox1.DataSource = dt;   << hadi mkhessaxi tkon hna !!!!!!.!!!!!>>

                dr.Close();
                dr = null;
                com = null;
                cn.Close();
                cn = null;

            }
            //else
            //{
            //    MessageBox.Show("k");
            //}
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
