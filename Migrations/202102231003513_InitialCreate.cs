﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                        memberShipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberShipTypes", t => t.memberShipTypeId, cascadeDelete: true)
                .Index(t => t.memberShipTypeId);
            
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        signUpFee = c.Short(nullable: false),
                        durationInMonth = c.Byte(nullable: false),
                        discountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "memberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "memberShipTypeId" });
            DropTable("dbo.Movies");
            DropTable("dbo.MemberShipTypes");
            DropTable("dbo.Customers");
        }
    }
}
