namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmesaj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesajs",
                c => new
                    {
                        MesajId = c.Int(nullable: false, identity: true),
                        Gonderici = c.String(maxLength: 50, unicode: false),
                        Alici = c.String(maxLength: 50, unicode: false),
                        Konu = c.String(maxLength: 50, unicode: false),
                        Icerik = c.String(maxLength: 2000, unicode: false),
                        Tarih = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.MesajId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mesajs");
        }
    }
}
