namespace SqlCodefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Class = c.String(),
                        PupilId_PupilId = c.Int(),
                        TeacherId_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pupils", t => t.PupilId_PupilId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId_TeacherId)
                .Index(t => t.PupilId_PupilId)
                .Index(t => t.TeacherId_TeacherId);
            
            CreateTable(
                "dbo.Pupils",
                c => new
                    {
                        PupilId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Class = c.String(),
                    })
                .PrimaryKey(t => t.PupilId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Classes", "PupilId_PupilId", "dbo.Pupils");
            DropIndex("dbo.Classes", new[] { "TeacherId_TeacherId" });
            DropIndex("dbo.Classes", new[] { "PupilId_PupilId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Pupils");
            DropTable("dbo.Classes");
        }
    }
}
