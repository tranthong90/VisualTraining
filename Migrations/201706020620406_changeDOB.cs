namespace VisualTraining.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDOB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        ConditionID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Condition", t => t.ConditionID)
                .Index(t => t.ConditionID);
            
            CreateTable(
                "dbo.Condition",
                c => new
                    {
                        ConditionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.ConditionID);
            
            CreateTable(
                "dbo.ConditionLine",
                c => new
                    {
                        ConditionLineID = c.Int(nullable: false, identity: true),
                        ConditionID = c.Int(nullable: false),
                        DiagnosisID = c.Int(nullable: false),
                        Level = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ConditionLineID)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisID)
                .ForeignKey("dbo.Condition", t => t.ConditionID)
                .Index(t => t.ConditionID)
                .Index(t => t.DiagnosisID);
            
            CreateTable(
                "dbo.ActivityLine",
                c => new
                    {
                        ActivityLineID = c.Int(nullable: false, identity: true),
                        ConditionLineID = c.Int(nullable: false),
                        SessionID = c.Int(nullable: false),
                        Note = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.ActivityLineID)
                .ForeignKey("dbo.Session", t => t.SessionID)
                .ForeignKey("dbo.ConditionLine", t => t.ConditionLineID)
                .Index(t => t.ConditionLineID)
                .Index(t => t.SessionID);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        WeekNo = c.Int(nullable: false),
                        DiagnosisID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisID)
                .Index(t => t.DiagnosisID);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        Optometrist = c.Decimal(nullable: false, storeType: "money"),
                        StatusID = c.Int(nullable: false),
                        NoOfSession = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiagnosisID)
                .ForeignKey("dbo.Patient", t => t.PatientID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        DOB = c.DateTime(storeType: "date"),
                        SystemNo = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.TherapyGoalLine",
                c => new
                    {
                        TherapyGoalLineID = c.Int(nullable: false, identity: true),
                        ConditionLineID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.TherapyGoalLineID)
                .ForeignKey("dbo.ConditionLine", t => t.ConditionLineID)
                .Index(t => t.ConditionLineID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConditionLine", "ConditionID", "dbo.Condition");
            DropForeignKey("dbo.TherapyGoalLine", "ConditionLineID", "dbo.ConditionLine");
            DropForeignKey("dbo.ActivityLine", "ConditionLineID", "dbo.ConditionLine");
            DropForeignKey("dbo.Session", "DiagnosisID", "dbo.Diagnosis");
            DropForeignKey("dbo.Diagnosis", "PatientID", "dbo.Patient");
            DropForeignKey("dbo.ConditionLine", "DiagnosisID", "dbo.Diagnosis");
            DropForeignKey("dbo.ActivityLine", "SessionID", "dbo.Session");
            DropForeignKey("dbo.Activity", "ConditionID", "dbo.Condition");
            DropIndex("dbo.TherapyGoalLine", new[] { "ConditionLineID" });
            DropIndex("dbo.Diagnosis", new[] { "PatientID" });
            DropIndex("dbo.Session", new[] { "DiagnosisID" });
            DropIndex("dbo.ActivityLine", new[] { "SessionID" });
            DropIndex("dbo.ActivityLine", new[] { "ConditionLineID" });
            DropIndex("dbo.ConditionLine", new[] { "DiagnosisID" });
            DropIndex("dbo.ConditionLine", new[] { "ConditionID" });
            DropIndex("dbo.Activity", new[] { "ConditionID" });
            DropTable("dbo.TherapyGoalLine");
            DropTable("dbo.Patient");
            DropTable("dbo.Diagnosis");
            DropTable("dbo.Session");
            DropTable("dbo.ActivityLine");
            DropTable("dbo.ConditionLine");
            DropTable("dbo.Condition");
            DropTable("dbo.Activity");
        }
    }
}
