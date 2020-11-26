namespace BookStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        Person = c.String(),
                        Phone = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchases");
            DropTable("dbo.Books");
        }
    }
}
