using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_app_new
{
    public partial class Form11 : Form
    {
        public string Note;
        public string Created;
        public string Deadline;

        public string passingvalue
        {
            get { return Note; }
            set { Note = value; }

        }

        public string passingvalue1
        {
            get { return Deadline; }
            set { Deadline = value; }

        }

        public string passingvalue2
        {
            get { return Created; }
            set { Created = value; }

        }
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

           
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Note;
            label5.Text = Deadline;
            label4.Text = Created;
        }
    }
}
