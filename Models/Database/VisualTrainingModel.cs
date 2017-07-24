namespace VisualTraining.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VisualTrainingModel : DbContext
    {
        public VisualTrainingModel()
            : base("name=VisualTrainingModel")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityLine> ActivityLines { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<ConditionLine> ConditionLines { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<TherapyGoalLine> TherapyGoalLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ActivityLine>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Condition>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Condition>()
                .HasMany(e => e.Activities)
                .WithRequired(e => e.Condition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Condition>()
                .HasMany(e => e.ConditionLines)
                .WithRequired(e => e.Condition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConditionLine>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<ConditionLine>()
                .HasMany(e => e.ActivityLines)
                .WithRequired(e => e.ConditionLine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConditionLine>()
                .HasMany(e => e.TherapyGoalLines)
                .WithRequired(e => e.ConditionLine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diagnosis>()
                .Property(e => e.Optometrist)
                  .IsUnicode(false);

            modelBuilder.Entity<Diagnosis>()
                .HasMany(e => e.ConditionLines)
                .WithRequired(e => e.Diagnosi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diagnosis>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.Diagnosi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.SystemNo)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.ActivityLines)
                .WithRequired(e => e.Session)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TherapyGoalLine>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
