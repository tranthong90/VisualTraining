namespace VisualTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateInDiagnosis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diagnosis", "Created", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.Diagnosis", "Modified", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diagnosis", "Modified");
            DropColumn("dbo.Diagnosis", "Created");
        }
    }
}
