namespace SqlCodefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "PupilId_PupilId", "dbo.Pupils");
            DropForeignKey("dbo.Classes", "TeacherId_TeacherId", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "PupilId_PupilId" });
            DropIndex("dbo.Classes", new[] { "TeacherId_TeacherId" });
            AddColumn("dbo.Classes", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "PupilId", c => c.Int(nullable: false));
            DropColumn("dbo.Classes", "PupilId_PupilId");
            DropColumn("dbo.Classes", "TeacherId_TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "TeacherId_TeacherId", c => c.Int());
            AddColumn("dbo.Classes", "PupilId_PupilId", c => c.Int());
            DropColumn("dbo.Classes", "PupilId");
            DropColumn("dbo.Classes", "TeacherId");
            CreateIndex("dbo.Classes", "TeacherId_TeacherId");
            CreateIndex("dbo.Classes", "PupilId_PupilId");
            AddForeignKey("dbo.Classes", "TeacherId_TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.Classes", "PupilId_PupilId", "dbo.Pupils", "PupilId");
        }
    }
}
