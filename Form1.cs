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
            Notes = GetNotes();
            InitializeComponent();
        }

        private List<Todo> GetNotes()
        {
            var list = new List<Todo>();
            using (StreamReader streamReader = new StreamReader("todo.json"))
            {
                var jsonMerkkijono = streamReader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Todo>>(jsonMerkkijono);
            }
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var notes = Notes;
            notes_data.DataSource = notes;
        }

        private void save_click(object sender, EventArgs e)
        {
            var list = new List<Todo>();
            foreach (DataGridViewRow row in notes_data.Rows)
            {
                var obj = new Todo()
                {
                    Note = row.Cells["Note"].Value.ToString(),
                    Created = Convert.ToDateTime(row.Cells["Created"].Value.ToString()),
                    Check = (bool)row.Cells["Check"].Value
                };
                list.Add(obj);
            }
            using (StreamWriter streamwriter = new StreamWriter("todo.json"))
            {
                string jsonString = JsonConvert.SerializeObject(list);
                streamwriter.Write(jsonString);
            }
        }

        private void notes_complete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //notes_data.Columns["Note"].ReadOnly = true;
            notes_data.Columns["Created"].ReadOnly = true;
            notes_data.RowHeadersWidth = 30;
            notes_data.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            notes_data.Columns["Created"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            notes_data.Columns["Check"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 showForm = new Form2();
            showForm.Show();
        }
    }
}
