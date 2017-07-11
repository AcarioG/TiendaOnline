namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Procductor_ProductorId", "dbo.Productors");
            DropIndex("dbo.Items", new[] { "Procductor_ProductorId" });
            RenameColumn(table: "dbo.Items", name: "Procductor_ProductorId", newName: "ProductorId");
            AlterColumn("dbo.Items", "ProductorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ProductorId");
            AddForeignKey("dbo.Items", "ProductorId", "dbo.Productors", "ProductorId", cascadeDelete: true);
            DropColumn("dbo.Items", "ProveedorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ProveedorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "ProductorId", "dbo.Productors");
            DropIndex("dbo.Items", new[] { "ProductorId" });
            AlterColumn("dbo.Items", "ProductorId", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "ProductorId", newName: "Procductor_ProductorId");
            CreateIndex("dbo.Items", "Procductor_ProductorId");
            AddForeignKey("dbo.Items", "Procductor_ProductorId", "dbo.Productors", "ProductorId");
        }
    }
}
