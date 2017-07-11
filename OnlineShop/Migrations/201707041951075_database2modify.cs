namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database2modify : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        RegistroId = c.Int(nullable: false, identity: true),
                        CarritoId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RegistroId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.DetalleOrdens",
                c => new
                    {
                        DetalleOrdenId = c.Int(nullable: false, identity: true),
                        OrdenId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Orden_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleOrdenId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Ordens", t => t.Orden_OrderId)
                .Index(t => t.ItemId)
                .Index(t => t.Orden_OrderId);
            
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        PrimerNombre = c.String(),
                        SegundoNombre = c.String(),
                        Direccion = c.String(),
                        Ciudad = c.String(),
                        Estado = c.String(),
                        Pais = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiaOrden = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleOrdens", "Orden_OrderId", "dbo.Ordens");
            DropForeignKey("dbo.DetalleOrdens", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Carritoes", "ItemId", "dbo.Items");
            DropIndex("dbo.DetalleOrdens", new[] { "Orden_OrderId" });
            DropIndex("dbo.DetalleOrdens", new[] { "ItemId" });
            DropIndex("dbo.Carritoes", new[] { "ItemId" });
            DropTable("dbo.Ordens");
            DropTable("dbo.DetalleOrdens");
            DropTable("dbo.Carritoes");
        }
    }
}
