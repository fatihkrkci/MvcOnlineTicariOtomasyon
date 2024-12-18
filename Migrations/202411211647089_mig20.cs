﻿namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoTakips",
                c => new
                {
                    KargoTakipId = c.Int(nullable: false, identity: true),
                    TakipKodu = c.String(maxLength: 10, unicode: false),
                    Aciklama = c.String(maxLength: 100, unicode: false),
                    TarihZaman = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.KargoTakipId);

            CreateTable(
                "dbo.KargoDetays",
                c => new
                {
                    KargoDetayId = c.Int(nullable: false, identity: true),
                    Aciklama = c.String(maxLength: 300, unicode: false),
                    TakipKodu = c.String(maxLength: 10, unicode: false),
                    Personel = c.String(maxLength: 25, unicode: false),
                    Alici = c.String(maxLength: 25, unicode: false),
                    Tarih = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.KargoDetayId);
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoDetays");
            DropTable("dbo.KargoTakips");
        }
    }
}
