using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_app_new
{
    public class Todo
    {
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public bool Priority { get; set; }
        public bool Check { get; set; }

    }
}
