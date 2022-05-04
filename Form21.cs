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
            Todo obj = new Todo()
            {
                Note = textBox1.Text,
                Created = DateTime.Now,
                Deadline = dateTimePicker1.Value,
                Priority = checkBox1.Checked,
                Check = false
            };

            var list = new List<Todo>();
            using (StreamReader streamReader = new StreamReader("todo_json.json"))
            {
                var jsonMerkkijono = streamReader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Todo>>(jsonMerkkijono);
            }

            list.Add(obj);

            using (StreamWriter streamwriter2 = new StreamWriter("todo_json.json"))
            {
                string jsonSave = JsonConvert.SerializeObject(list);
                streamwriter2.WriteLine(jsonSave);
            }

            this.Close();
        }


        private void Form21_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
