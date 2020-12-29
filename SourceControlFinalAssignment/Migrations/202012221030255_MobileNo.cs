using System.Data.Entity.Migrations;

namespace Source_Control_Final_Assignment.Migrations
{
    public partial class MobileNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobileNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MobileNo");
        }
    }
}
