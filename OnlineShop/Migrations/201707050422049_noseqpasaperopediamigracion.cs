namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noseqpasaperopediamigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarritoComprasModels",
                c => new
                    {
                        CarritoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CarritoTotal);
            
            AddColumn("dbo.Carritoes", "CarritoComprasModel_CarritoTotal", c => c.Decimal(precision: 18, scale: 2));
            CreateIndex("dbo.Carritoes", "CarritoComprasModel_CarritoTotal");
            AddForeignKey("dbo.Carritoes", "CarritoComprasModel_CarritoTotal", "dbo.CarritoComprasModels", "CarritoTotal");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carritoes", "CarritoComprasModel_CarritoTotal", "dbo.CarritoComprasModels");
            DropIndex("dbo.Carritoes", new[] { "CarritoComprasModel_CarritoTotal" });
            DropColumn("dbo.Carritoes", "CarritoComprasModel_CarritoTotal");
            DropTable("dbo.CarritoComprasModels");
        }
    }
}
