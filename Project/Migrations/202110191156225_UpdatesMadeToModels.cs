namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesMadeToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Components", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Components", "Name", c => c.String());
        }
    }
}
