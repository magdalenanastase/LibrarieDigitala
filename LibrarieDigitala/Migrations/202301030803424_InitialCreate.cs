namespace LibrarieDigitala.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Book_id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Publishing_house = c.String(),
                        Publishing_date = c.DateTime(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        No_pages = c.Int(nullable: false),
                        Image = c.Binary(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Book_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
