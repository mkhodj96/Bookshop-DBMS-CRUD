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


namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=CASPIANPC\\YANI;Initial Catalog=bookshop;Integrated Security=True");

        SqlCommand cmd = new SqlCommand();
   
        public Form1()
        {
            InitializeComponent();
        }
      
        #region Add book

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked&&!checkBox2.Checked)
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("INSERT INTO Publishers(publisher_id,publisherfullname) VALUES('" + textBox5.Text + "','" + textBox10.Text + "')", con);
                SDA1.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter SDA2 = new SqlDataAdapter("INSERT INTO Authors(author_id,firstName,lastName,email) VALUES('" + textBox11.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", con);
                SDA2.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter SDA3 = new SqlDataAdapter("INSERT INTO Title(isbn,title,editionNumber,copyright,publisher_id,price) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                SDA3.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("saved just fine");
            }
            else if (checkBox1.Checked && !checkBox2.Checked)
            {
 
             textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;

            textBox11.Visible = false;
            con.Open();
            SqlDataAdapter SDA1 = new SqlDataAdapter("INSERT INTO Publishers(publisher_id,publisherfullname) VALUES('" + textBox5.Text + "','" + textBox10.Text + "')", con);
            SDA1.SelectCommand.ExecuteNonQuery();

            SqlDataAdapter SDA3 = new SqlDataAdapter("INSERT INTO Title(isbn,title,editionNumber,copyright,publisher_id,price) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
            SDA3.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("saved just fine");

            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                con.Open();
                SqlDataAdapter SDA2 = new SqlDataAdapter("INSERT INTO Authors(author_id,firstName,lastName,email) VALUES('" + textBox11.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", con);
                SDA2.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter SDA3 = new SqlDataAdapter("INSERT INTO Title(isbn,title,editionNumber,copyright,publisher_id,price) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                SDA3.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("saved just fine");
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                con.Open();
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;

                textBox11.Visible = false;
              
                SqlDataAdapter SDA3 = new SqlDataAdapter("INSERT INTO Title(isbn,title,editionNumber,copyright,publisher_id,price) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                SDA3.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("saved just fine");
            }

           }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            string t = "Title";
            string a = "Authors";
            string p = "Publishers";
          

            comboBox1.Items.Add(t);
            comboBox1.Items.Add(p);
            comboBox1.Items.Add(a);
            comboBox2.Items.Add(t);
            comboBox2.Items.Add(p);
            comboBox2.Items.Add(a);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        #region View
        private void button3_Click(object sender, EventArgs e)
        {
         
            con.Open();
           SqlDataAdapter SDA1 = new SqlDataAdapter("SELECT * from " + comboBox1.SelectedItem.ToString()+" ", con);
     
            DataTable data = new DataTable();
            SDA1.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
            
        }

        #endregion

        #region Update
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Title")
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("UPDATE Title SET title='" + textBox14.Text + "', editionNumber='" + textBox15.Text + "', copyright='" + textBox16.Text + "', publisher_id='" + textBox17.Text + "', price='" + Int32.Parse(textBox18.Text) + " ' WHERE isbn="+textBox13.Text + "", con);
                SDA1.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated just fine");
                
            }
            else if (comboBox1.SelectedItem.ToString() == "Publishers")
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("UPDATE Publishers SET publisherfullName='" + textBox14.Text + "' WHERE publisher_id=" + textBox13.Text + "", con);
                SDA1.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated just fine");
            }
            else if (comboBox1.SelectedItem.ToString() == "Authors")
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("UPDATE Authors SET firstName='" + textBox14.Text + "', lastName='" + textBox15.Text + "', email='" + textBox16.Text + "' WHERE author_id=" + textBox13.Text + "", con);
                SDA1.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated just fine");
            }
        }

        #endregion

        #region Search
        private void button4_Click(object sender, EventArgs e)
        {
           
            

                DataTable data = new DataTable();
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("SELECT * FROM " + comboBox2.SelectedItem.ToString() + " WHERE (" + comboBox3.SelectedItem.ToString() + " LIKE '" + textBox12.Text.ToString() + "%' )", con);


                SDA1.Fill(data);
                dataGridView1.DataSource = data;
                con.Close();




            
            
           
        }

        #endregion

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Title")
            {
                string b1 = "isbn";
                string b2 = "title";
                string b3 = "editionNumber";
                string b4 = "publisher_id";
                string b5 = "price";
                comboBox3.Items.Add(b1);
                comboBox3.Items.Add(b2);
                comboBox3.Items.Add(b3);
                comboBox3.Items.Add(b4);
                comboBox3.Items.Add(b5);





            }
            else if (comboBox2.SelectedItem.ToString() == "Publishers")
            {
                string b1 = "publisher_id";
                string b2 = "publisherfullName";
                comboBox3.Items.Add(b1);
                comboBox3.Items.Add(b2);


            }
            else if (comboBox2.SelectedItem.ToString() == "Authors")
            {
                string b1 = "author_id";
                string b2 = "firstName";
                string b3 = "lastName";
                string b4 = "email";
                comboBox3.Items.Add(b1);
                comboBox3.Items.Add(b2);
                comboBox3.Items.Add(b3);
                comboBox3.Items.Add(b4);

              


            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int t=dataGridView1.ColumnCount;
            if(t==6)
            {
                textBox13.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox14.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox15.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox16.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox17.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox18.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            }
            else if(t==2)
            {
                textBox13.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox14.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            else if(t==4)
            {
                textBox13.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox14.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox15.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox16.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            }



        
        }

        #region Delete
        private void button5_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Title")
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("DELETE FROM Title WHERE isbn=" + textBox13.Text + "", con);
                SDA1.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted just fine");

            }
            else if (comboBox1.SelectedItem.ToString() == "Publishers")
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("DELETE FROM Publishers WHERE publisher_id=" + textBox13.Text + "", con);
                SDA1.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted just fine");
            }
            else if (comboBox1.SelectedItem.ToString() == "Authors")
            {
                con.Open();
                SqlDataAdapter SDA1 = new SqlDataAdapter("DELETE FROM Authors WHERE author_id=" + textBox13.Text + "", con);
                SDA1.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted just fine");
            }




        }


        #endregion

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
