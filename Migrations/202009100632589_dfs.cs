namespace DemoWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IDDE", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IDDE");
        }
    }
}
