namespace PBL4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BANCO2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bilheterias",
                c => new
                    {
                        BilheteriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Local = c.String(),
                    })
                .PrimaryKey(t => t.BilheteriaId);
            
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.String(),
                        HoraInicio = c.String(),
                        HoraFim = c.String(),
                        Restricao = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.Ingressoes",
                c => new
                    {
                        IngressoId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        QuantidadeIngressos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngressoId)
                .ForeignKey("dbo.Eventoes", t => t.EventoId, cascadeDelete: true)
                .Index(t => t.EventoId);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.VendaIngressoes",
                c => new
                    {
                        VendaIngressoId = c.Int(nullable: false, identity: true),
                        IngressoId = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        BilheteriaId = c.Int(nullable: false),
                        VIP = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VendaIngressoId)
                .ForeignKey("dbo.Bilheterias", t => t.BilheteriaId, cascadeDelete: true)
                .ForeignKey("dbo.Ingressoes", t => t.IngressoId, cascadeDelete: true)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.IngressoId)
                .Index(t => t.PessoaId)
                .Index(t => t.BilheteriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaIngressoes", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.VendaIngressoes", "IngressoId", "dbo.Ingressoes");
            DropForeignKey("dbo.VendaIngressoes", "BilheteriaId", "dbo.Bilheterias");
            DropForeignKey("dbo.Ingressoes", "EventoId", "dbo.Eventoes");
            DropIndex("dbo.VendaIngressoes", new[] { "BilheteriaId" });
            DropIndex("dbo.VendaIngressoes", new[] { "PessoaId" });
            DropIndex("dbo.VendaIngressoes", new[] { "IngressoId" });
            DropIndex("dbo.Ingressoes", new[] { "EventoId" });
            DropTable("dbo.VendaIngressoes");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Ingressoes");
            DropTable("dbo.Eventoes");
            DropTable("dbo.Bilheterias");
        }
    }
}
