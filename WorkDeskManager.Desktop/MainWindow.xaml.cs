using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkDeskManager.Desktop.Data;

namespace WorkDeskManager.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.Icon = Properties.Resources.favicon;
                notifyIcon.Text = "i-Possible Workdesk Manager";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
                Hide();
            }
        }

        void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TaskList.items
            using (var context = new WorkDeskManager.Desktop.Data.WorkdeskContext())
            {
                var taskList = context.Tasks.ToList();
                if (taskList != null)
                {
                TaskList.ItemsSource = taskList;
                TaskList.DisplayMemberPath = "Name";
                }
                
            }
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new WorkdeskContext())
            {
                WorkDeskManager.Desktop.Data.Task taskSelected = context.Tasks.Find(((WorkDeskManager.Desktop.Data.Task)TaskList.SelectedItem).Id);
                if (taskSelected != null)
                {
                    txtWorksheetUrl.Text = taskSelected.WorksheetUrl;
                    var activities = context.Activities.Where(t => t.Task.Id == taskSelected.Id).ToList();
                    if (activities != null)
                    {
                        ActivityList.ItemsSource = activities;
                        ActivityList.DisplayMemberPath = "Description";
                        ActivityList.Items.Refresh();
                    }
                    
                    
                }

            }
        }

        private void btnAddNewTask_Click(object sender, RoutedEventArgs e)
        {
            var addNewWindow = new Grids.AddNewTaskWindow();
            addNewWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addNewWindow.ShowDialog();
        }

        private void txtWorksheetUrl_GotFocus(object sender, RoutedEventArgs e)
        {
            txtWorksheetUrl.SelectAll();
            txtWorksheetUrl.Copy();
        }

        private void txtWorksheetUrl_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            txtWorksheetUrl.SelectAll();
        }

       
    }
}
