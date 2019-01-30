namespace OnBoardingTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datefield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "Date", c => c.DateTime());
        }
    }
}
