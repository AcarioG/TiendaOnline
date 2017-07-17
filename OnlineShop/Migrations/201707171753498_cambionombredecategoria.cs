namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambionombredecategoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "Nombre", c => c.String());
            DropColumn("dbo.Categorias", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categorias", "Name", c => c.String());
            DropColumn("dbo.Categorias", "Nombre");
        }
    }
}
