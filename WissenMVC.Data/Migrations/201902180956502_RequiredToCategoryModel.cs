namespace WissenMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredToCategoryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Descripton", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Descripton", c => c.String(maxLength: 50));
        }
    }
}
