using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkDeskManager.Desktop.Grids
{
    /// <summary>
    /// Interaction logic for AddNewTaskWindow.xaml
    /// </summary>
    public partial class AddNewTaskWindow : Window
    {
        public AddNewTaskWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTaskName.Text) || String.IsNullOrEmpty(txtWorksheetUrl.Text)) 
            {
                MessageBox.Show("Task Name or Worksheet URL cannot be empty");
                return;
            }
            using (var context = new WorkDeskManager.Desktop.Data.WorkdeskContext())
            {
                
                try
                {
                    var task = new Data.Task { Name = txtTaskName.Text.Trim(), WorksheetUrl = txtWorksheetUrl.Text.Trim() };
                    context.Tasks.Add(task);
                    context.SaveChanges();
                    MessageBox.Show(String.Format("Task -{0}- Added",txtTaskName.Text));
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(String.Format("Error adding new task: {0}",ex.Message));
                }
            }
            
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new WorkDeskManager.Desktop.Data.WorkdeskContext())
            {
                var projectList = context.Projects.ToList();
                var workweekList = context.Workweeks.ToList();
                if (null != projectList && null != workweekList) 
                {
                    cboProject.ItemsSource = projectList;
                    cboProject.DisplayMemberPath = "Name";

                    cboWorkweek.ItemsSource = workweekList;
                    cboWorkweek.DisplayMemberPath = "Description";
                }
                
            }
        }

    
        
    }
}
