namespace VisualTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTableName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diagnosis", "Optometrist", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diagnosis", "Optometrist", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
