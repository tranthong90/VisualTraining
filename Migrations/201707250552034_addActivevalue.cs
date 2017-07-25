namespace VisualTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActivevalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConditionLine", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.ActivityLine", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.TherapyGoalLine", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TherapyGoalLine", "Active");
            DropColumn("dbo.ActivityLine", "Active");
            DropColumn("dbo.ConditionLine", "Active");
        }
    }
}
