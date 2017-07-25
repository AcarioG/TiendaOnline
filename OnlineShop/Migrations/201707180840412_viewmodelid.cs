namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodelid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carritoes", "CarritoComprasModel_CarritoTotal", "dbo.CarritoComprasModels");
            DropIndex("dbo.Carritoes", new[] { "CarritoComprasModel_CarritoTotal" });
            RenameColumn(table: "dbo.Carritoes", name: "CarritoComprasModel_CarritoTotal", newName: "CarritoComprasModel_ID");
            DropPrimaryKey("dbo.CarritoComprasModels");
            AddColumn("dbo.CarritoComprasModels", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Carritoes", "CarritoComprasModel_ID", c => c.Int());
            AddPrimaryKey("dbo.CarritoComprasModels", "ID");
            CreateIndex("dbo.Carritoes", "CarritoComprasModel_ID");
            AddForeignKey("dbo.Carritoes", "CarritoComprasModel_ID", "dbo.CarritoComprasModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carritoes", "CarritoComprasModel_ID", "dbo.CarritoComprasModels");
            DropIndex("dbo.Carritoes", new[] { "CarritoComprasModel_ID" });
            DropPrimaryKey("dbo.CarritoComprasModels");
            AlterColumn("dbo.Carritoes", "CarritoComprasModel_ID", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.CarritoComprasModels", "ID");
            AddPrimaryKey("dbo.CarritoComprasModels", "CarritoTotal");
            RenameColumn(table: "dbo.Carritoes", name: "CarritoComprasModel_ID", newName: "CarritoComprasModel_CarritoTotal");
            CreateIndex("dbo.Carritoes", "CarritoComprasModel_CarritoTotal");
            AddForeignKey("dbo.Carritoes", "CarritoComprasModel_CarritoTotal", "dbo.CarritoComprasModels", "CarritoTotal");
        }
    }
}
