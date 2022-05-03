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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Form2 closeWindow = new Form2();
            //closeWindow.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
