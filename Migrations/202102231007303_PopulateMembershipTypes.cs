namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes(Id,signUpFee,durationInMonth,discountRate) values (1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes(Id,signUpFee,durationInMonth,discountRate) values (2,30,1,10)");
            Sql("INSERT INTO MemberShipTypes(Id,signUpFee,durationInMonth,discountRate) values (3,90,3,15)");
            Sql("INSERT INTO MemberShipTypes(Id,signUpFee,durationInMonth,discountRate) values (4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
