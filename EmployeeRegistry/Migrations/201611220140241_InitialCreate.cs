namespace EmployeeRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.lutER_Branch",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.lutER_Directorate",
                c => new
                    {
                        DirectorateId = c.Int(nullable: false, identity: true),
                        DirectorateName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorateId);
            
            CreateTable(
                "dbo.lutER_Division",
                c => new
                    {
                        DivisionId = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                    })
                .PrimaryKey(t => t.DivisionId);
            
            CreateTable(
                "dbo.lutER_Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.lutER_Organization",
                c => new
                    {
                        OrganizationalId = c.Int(nullable: false, identity: true),
                        OrganizationalName = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationalId);
            
            CreateTable(
                "dbo.lutER_Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleType = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.lutWAR_AccStatus",
                c => new
                    {
                        AccStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.AccStatusId);
            
            CreateTable(
                "dbo.lutWAR_Projects",
                c => new
                    {
                        ProjId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.ProjId);
            
            CreateTable(
                "dbo.tblER_Employee",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        DirectorateId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        OrganizationalId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ProjId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        EmpArchive = c.Boolean(nullable: false),
                        Matrixed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId)
                .ForeignKey("dbo.lutER_Branch", t => t.BranchId)
                .ForeignKey("dbo.lutER_Directorate", t => t.DirectorateId)
                .ForeignKey("dbo.lutER_Division", t => t.DivisionId)
                .ForeignKey("dbo.lutER_Location", t => t.LocationId)
                .ForeignKey("dbo.lutER_Organization", t => t.OrganizationalId)
                .ForeignKey("dbo.lutER_Role", t => t.RoleId)
                .ForeignKey("dbo.lutWAR_Projects", t => t.ProjId)
                .Index(t => t.RoleId)
                .Index(t => t.DirectorateId)
                .Index(t => t.DivisionId)
                .Index(t => t.LocationId)
                .Index(t => t.OrganizationalId)
                .Index(t => t.BranchId)
                .Index(t => t.ProjId);
            
            CreateTable(
                "dbo.tblWAR_Accomplishments",
                c => new
                    {
                        AccomoplishmentId = c.Int(nullable: false, identity: true),
                        ProjId = c.Int(nullable: false),
                        AccStatusId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                        Accomplishment = c.String(),
                        WeekEndingDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AccArchieve = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccomoplishmentId)
                .ForeignKey("dbo.lutWAR_AccStatus", t => t.AccStatusId)
                .ForeignKey("dbo.lutWAR_Projects", t => t.ProjId)
                .ForeignKey("dbo.tblER_Employee", t => t.EmpId)
                .Index(t => t.ProjId)
                .Index(t => t.AccStatusId)
                .Index(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblWAR_Accomplishments", "EmpId", "dbo.tblER_Employee");
            DropForeignKey("dbo.tblWAR_Accomplishments", "ProjId", "dbo.lutWAR_Projects");
            DropForeignKey("dbo.tblWAR_Accomplishments", "AccStatusId", "dbo.lutWAR_AccStatus");
            DropForeignKey("dbo.tblER_Employee", "ProjId", "dbo.lutWAR_Projects");
            DropForeignKey("dbo.tblER_Employee", "RoleId", "dbo.lutER_Role");
            DropForeignKey("dbo.tblER_Employee", "OrganizationalId", "dbo.lutER_Organization");
            DropForeignKey("dbo.tblER_Employee", "LocationId", "dbo.lutER_Location");
            DropForeignKey("dbo.tblER_Employee", "DivisionId", "dbo.lutER_Division");
            DropForeignKey("dbo.tblER_Employee", "DirectorateId", "dbo.lutER_Directorate");
            DropForeignKey("dbo.tblER_Employee", "BranchId", "dbo.lutER_Branch");
            DropIndex("dbo.tblWAR_Accomplishments", new[] { "EmpId" });
            DropIndex("dbo.tblWAR_Accomplishments", new[] { "AccStatusId" });
            DropIndex("dbo.tblWAR_Accomplishments", new[] { "ProjId" });
            DropIndex("dbo.tblER_Employee", new[] { "ProjId" });
            DropIndex("dbo.tblER_Employee", new[] { "BranchId" });
            DropIndex("dbo.tblER_Employee", new[] { "OrganizationalId" });
            DropIndex("dbo.tblER_Employee", new[] { "LocationId" });
            DropIndex("dbo.tblER_Employee", new[] { "DivisionId" });
            DropIndex("dbo.tblER_Employee", new[] { "DirectorateId" });
            DropIndex("dbo.tblER_Employee", new[] { "RoleId" });
            DropTable("dbo.tblWAR_Accomplishments");
            DropTable("dbo.tblER_Employee");
            DropTable("dbo.lutWAR_Projects");
            DropTable("dbo.lutWAR_AccStatus");
            DropTable("dbo.lutER_Role");
            DropTable("dbo.lutER_Organization");
            DropTable("dbo.lutER_Location");
            DropTable("dbo.lutER_Division");
            DropTable("dbo.lutER_Directorate");
            DropTable("dbo.lutER_Branch");
        }
    }
}
