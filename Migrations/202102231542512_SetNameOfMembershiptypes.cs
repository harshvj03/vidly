namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershiptypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name ='Pay as you go' Where Id = 1");
            Sql("UPDATE MemberShipTypes SET Name ='Monthly' Where Id = 2");
            Sql("UPDATE MemberShipTypes SET Name ='Quaterly' Where Id = 3");
            Sql("UPDATE MemberShipTypes SET Name ='Annual' Where Id = 4");
        }
        
        public override void Down()
        {
            
        }
    }
}
