namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddProductDescriptionManCodePriceFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.catalogue_products", "product_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("dbo.catalogue_products", "product_price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
