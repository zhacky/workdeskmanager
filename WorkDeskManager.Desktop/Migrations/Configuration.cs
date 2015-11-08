namespace WorkDeskManager.Desktop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WorkDeskManager.Desktop.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkDeskManager.Desktop.Data.WorkdeskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WorkDeskManager.Desktop.Data.WorkdeskContext context)
        {
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Projects.AddOrUpdate(
                p => p.Name,
                new Project
                {
                    Name = "Certica"
                },
                new Project
                {
                    Name = "i-Framer"
                },
                new Project
                {
                    Name = "ZeroCommission"
                },
                new Project
                {
                    Name = "HTR"
                }
                );
            context.Workweeks.AddOrUpdate(
                w => w.Description,
                new Workweek
                {
                    Description = "Nov. 6 - 12, 2015",
                    StartDate = DateTime.Parse("November 6, 2015"),
                    EndDate = DateTime.Parse("November 12, 2015")
                }
                );
            context.Tasks.AddOrUpdate(
                t => t.Name,
                new Task
                {
                    Name = @"Investigate why FYI task is showing all teams and display 'me and my team' instead",
                    WorksheetUrl = @"http://i-possible.com.au/workflow/worksheet/3635",
                    Activities = new System.Collections.Generic.List<Activity> { 
                        new Activity() {  Description = "Analysis on implementing permission on View team member tasks",
                                          TimeSpent = 1.25 },
                        new Activity() {  Description = "Edit Tasks Page to use permissions i.e. View Other Team Tasks",
                                          TimeSpent = 1.5  }
                    }
                }
                );
            context.SaveChanges();
        }
    }
}
