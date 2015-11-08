namespace WorkDeskManager.Desktop.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkdeskContext : DbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Workweek> Workweeks { get; set; }


        public WorkdeskContext()
            : base("name=WorkdeskContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
