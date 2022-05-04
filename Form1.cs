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
            notes_data.Columns["Note"].ReadOnly = true;
            notes_data.Columns["Created"].ReadOnly = true;
            notes_data.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            notes_data.Columns["Created"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            notes_data.Columns["Check"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

    }
}
