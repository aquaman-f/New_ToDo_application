using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_app_new
{
    public partial class Form1 : Form
    {
        public List<Todo> Notes { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetNotes();
        }
        public void GetNotes()
        {
            var list = new List<Todo>();
            using (StreamReader streamReader = new StreamReader("todo_json.json"))
            {
                var jsonMerkkijono = streamReader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Todo>>(jsonMerkkijono);
            }
            notes_data.DataSource = list;
        }
        private void notes_complete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form21 addNew = new Form21();
            addNew.FormClosed += form2_closed;
            addNew.Show();
        }

        private void form2_closed(object sender, FormClosedEventArgs e)
        {
            GetNotes();
        }

        private void save_Click(object sender, EventArgs e)
        {
            var list = new List<Todo>();
            foreach (DataGridViewRow row in notes_data.Rows)
            {
                var obj = new Todo()
                {
                    Note = row.Cells["Note"].Value.ToString(),
                    Created = Convert.ToDateTime(row.Cells["Created"].Value),
                    Deadline = Convert.ToDateTime(row.Cells["Deadline"].Value),
                    Priority = Convert.ToBoolean(row.Cells["Priority"].Value),
                    Check = Convert.ToBoolean(row.Cells["Check"].Value)
                };
                list.Add(obj);
            }
            using (StreamWriter streamwriter2 = new StreamWriter("todo_json.json"))
            {
                string jsonSave = JsonConvert.SerializeObject(list);
                streamwriter2.WriteLine(jsonSave);
            }
        }
    }
}
