namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdenReajustar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ordens", "PrimerNombre", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Ordens", "SegundoNombre", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Ordens", "Direccion", c => c.String(nullable: false));
            AlterColumn("dbo.Ordens", "Ciudad", c => c.String(nullable: false));
            AlterColumn("dbo.Ordens", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.Ordens", "Pais", c => c.String(nullable: false));
            AlterColumn("dbo.Ordens", "Telefono", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Ordens", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ordens", "Email", c => c.String());
            AlterColumn("dbo.Ordens", "Telefono", c => c.String());
            AlterColumn("dbo.Ordens", "Pais", c => c.String());
            AlterColumn("dbo.Ordens", "Estado", c => c.String());
            AlterColumn("dbo.Ordens", "Ciudad", c => c.String());
            AlterColumn("dbo.Ordens", "Direccion", c => c.String());
            AlterColumn("dbo.Ordens", "SegundoNombre", c => c.String());
            AlterColumn("dbo.Ordens", "PrimerNombre", c => c.String());
        }
    }
}
