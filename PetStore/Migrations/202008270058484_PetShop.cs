namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetShop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Igrackas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(nullable: false),
                        Cijena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KorpaIgrackaKupovinas",
                c => new
                    {
                        KorpaIgrackaId = c.Int(nullable: false),
                        KupovinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KorpaIgrackaId, t.KupovinaId })
                .ForeignKey("dbo.KorpaIgrackas", t => t.KorpaIgrackaId, cascadeDelete: true)
                .ForeignKey("dbo.Kupovinas", t => t.KupovinaId, cascadeDelete: true)
                .Index(t => t.KorpaIgrackaId)
                .Index(t => t.KupovinaId);
            
            CreateTable(
                "dbo.KorpaIgrackas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrojKomada = c.Int(nullable: false),
                        IgrackaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Igrackas", t => t.IgrackaId, cascadeDelete: true)
                .Index(t => t.IgrackaId);
            
            CreateTable(
                "dbo.Kupovinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KupacIme = c.String(nullable: false),
                        KupacPrezime = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        BrojKreditneKartice = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.KorpaIgrackaKupovinas", "KupovinaId", "dbo.Kupovinas");
            DropForeignKey("dbo.KorpaIgrackaKupovinas", "KorpaIgrackaId", "dbo.KorpaIgrackas");
            DropForeignKey("dbo.KorpaIgrackas", "IgrackaId", "dbo.Igrackas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.KorpaIgrackas", new[] { "IgrackaId" });
            DropIndex("dbo.KorpaIgrackaKupovinas", new[] { "KupovinaId" });
            DropIndex("dbo.KorpaIgrackaKupovinas", new[] { "KorpaIgrackaId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Kupovinas");
            DropTable("dbo.KorpaIgrackas");
            DropTable("dbo.KorpaIgrackaKupovinas");
            DropTable("dbo.Igrackas");
        }
    }
}
