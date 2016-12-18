namespace EmployeeRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblWAR_Accomplishments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblWAR_Accomplishments", "AccArchive", c => c.Boolean(nullable: false));
            DropColumn("dbo.tblWAR_Accomplishments", "AccArchieve");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblWAR_Accomplishments", "AccArchieve", c => c.Boolean(nullable: false));
            DropColumn("dbo.tblWAR_Accomplishments", "AccArchive");
        }
    }
}
