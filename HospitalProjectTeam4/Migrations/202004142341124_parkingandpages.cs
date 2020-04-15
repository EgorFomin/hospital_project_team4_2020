namespace HospitalProjectTeam4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkingandpages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.String(nullable: false, maxLength: 128),
                        DoctorID = c.String(nullable: false, maxLength: 128),
                        PageTitle = c.String(nullable: false),
                        PageBody = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        PageStyle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .Index(t => t.DoctorID);
            
            CreateTable(
                "dbo.ParkingSpots",
                c => new
                    {
                        ParkingSpotID = c.String(nullable: false, maxLength: 128),
                        StaffID = c.String(maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ParkingSpotID)
                .ForeignKey("dbo.HospitalStaffs", t => t.StaffID)
                .Index(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkingSpots", "StaffID", "dbo.HospitalStaffs");
            DropForeignKey("dbo.Pages", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.ParkingSpots", new[] { "StaffID" });
            DropIndex("dbo.Pages", new[] { "DoctorID" });
            DropTable("dbo.ParkingSpots");
            DropTable("dbo.Pages");
        }
    }
}
