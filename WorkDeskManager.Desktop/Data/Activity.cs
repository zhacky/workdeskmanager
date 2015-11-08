using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDeskManager.Desktop.Data
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double TimeSpent { get; set; }
        public Task Task { get; set; }
    }
}
