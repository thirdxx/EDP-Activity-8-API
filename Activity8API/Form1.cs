using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Activity8API
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //GET Data
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                HttpResponseMessage response = await client.GetAsync("http://localhost/myapi/api.php");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var jsonObjects = responseBody.Split('\n');
                StringBuilder displayText = new StringBuilder();
                foreach (var jsonObject in jsonObjects)
                {
                    displayText.AppendLine(jsonObject);
                    displayText.AppendLine();
                }
                textBox1.Text = displayText.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //POST Data
        private async void btnPOST_Click(object sender, EventArgs e)
        {
            var userData = new
            {
                username = textBox7.Text,
                pass = textBox5.Text,
                email = textBox6.Text,
                full_name = textBox2.Text,
                phone_number = textBox3.Text,
                address = textBox4.Text
            };

            string json = JsonConvert.SerializeObject(userData);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("http://localhost/myapi/api.php", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                textBox1.Text = responseBody;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
