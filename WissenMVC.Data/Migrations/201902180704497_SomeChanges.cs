namespace WissenMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UpdatedBy", c => c.String());
            AddColumn("dbo.Posts", "UpdatedBy", c => c.String());
            DropColumn("dbo.Categories", "UpdateBy");
            DropColumn("dbo.Posts", "UpdateBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UpdateBy", c => c.String());
            AddColumn("dbo.Categories", "UpdateBy", c => c.String());
            DropColumn("dbo.Posts", "UpdatedBy");
            DropColumn("dbo.Categories", "UpdatedBy");
        }
    }
}
