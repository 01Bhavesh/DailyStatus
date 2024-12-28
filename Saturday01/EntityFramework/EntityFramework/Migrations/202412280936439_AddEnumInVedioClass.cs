namespace EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnumInVedioClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "types", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "types");
        }
    }
}
