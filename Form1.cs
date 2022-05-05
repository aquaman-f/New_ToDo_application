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
        int sort = 1;

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
            if (sort == 1)
                list = list.OrderByDescending(o => o.Priority).ToList();
            else if (sort == 2)
                list = list.OrderBy(o => o.Created).ToList();
            else if (sort == 3)
                list = list.OrderBy(o => o.Deadline).ToList();
            else if (sort == 4)
                list = list.OrderBy(o => o.Note).ToList();

            notes_data.DataSource = list;
            format_stuff();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sort = 1;
            GetNotes();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sort = 2;
            GetNotes();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sort = 3;
            GetNotes();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sort = 4;
            GetNotes();
        }
        public void format_stuff()
        {
            notes_data.Columns["Created"].ReadOnly = true;
            notes_data.Columns["Check"].DisplayIndex = 0;
            notes_data.Columns["Created"].DefaultCellStyle.Format = "d/M/yyyy";
            notes_data.Columns["Deadline"].DefaultCellStyle.Format = "d/M/yyyy";
            notes_data.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            notes_data.Columns["Created"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            notes_data.Columns["Deadline"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            notes_data.Columns["Priority"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            notes_data.Columns["Check"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            foreach (DataGridViewRow row in notes_data.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            show_complete();
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
            GetNotes();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedrowindex = notes_data.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = notes_data.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["Note"].Value);
         
            var list = new List<Todo>();
            using (StreamReader streamReader = new StreamReader("todo_json.json"))
            {
                var jsonMerkkijono = streamReader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Todo>>(jsonMerkkijono);
            }
            list.RemoveAll(o => o.Note == cellValue);

            using (StreamWriter streamwriter2 = new StreamWriter("todo_json.json"))
            {
                string jsonSave = JsonConvert.SerializeObject(list);
                streamwriter2.WriteLine(jsonSave);
            }
            GetNotes();
        }

        private void show_complete()
        {
            if (show.Checked)
            {
                foreach (DataGridViewRow dr in notes_data.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["Check"].Value) == true)
                        dr.Visible = true;
                }
            }
            else if (!show.Checked)
            {
                foreach (DataGridViewRow dr in notes_data.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["Check"].Value) == true)
                        dr.Visible = false;
                }
            }
        }

        private void show_CheckedChanged(object sender, EventArgs e)
        {
            show_complete();
        }

    }
}
