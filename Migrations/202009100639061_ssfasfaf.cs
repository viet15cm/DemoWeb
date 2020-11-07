namespace DemoWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssfasfaf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        IDDE = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IDDE);
            
            CreateIndex("dbo.Employees", "IDDE");
            AddForeignKey("dbo.Employees", "IDDE", "dbo.Departments", "IDDE", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "IDDE", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "IDDE" });
            DropTable("dbo.Departments");
        }
    }
}
