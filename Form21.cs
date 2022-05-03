using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace ToDo_app_new
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string teksti = textBox1.Text;
            string now = label2.Text.ToString();
            string deadline = dateTimePicker1.ToString();
            bool priority = Convert.ToBoolean(checkBox1);
            bool priority2 = false;

            
            add()

            using (StreamWriter streamwriter2 = new StreamWriter())
            {
                string jsonSave = JsonConvert.SerializeObject(teksti, Formatting.Indented);
                streamwriter2.WriteLine(jsonSave);
            }


            this.Close();
        }
    }
}
