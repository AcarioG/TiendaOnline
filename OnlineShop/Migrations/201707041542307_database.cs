namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 120),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemArtUrl = c.String(),
                        Procductor_ProductorId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Productors", t => t.Procductor_ProductorId)
                .Index(t => t.CategoriaId)
                .Index(t => t.Procductor_ProductorId);
            
            CreateTable(
                "dbo.Productors",
                c => new
                    {
                        ProductorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Procductor_ProductorId", "dbo.Productors");
            DropForeignKey("dbo.Items", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Items", new[] { "Procductor_ProductorId" });
            DropIndex("dbo.Items", new[] { "CategoriaId" });
            DropTable("dbo.Productors");
            DropTable("dbo.Items");
            DropTable("dbo.Categorias");
        }
    }
}
