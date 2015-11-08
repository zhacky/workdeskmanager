using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDeskManager.Desktop.Data
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SpentHours { get; set; }
        public string WorksheetUrl { get; set; }
        public List<Activity> Activities { get; set; }
        public Workweek Workweek { get; set; }
        public Project Project { get; set; }

    }
}
