namespace PetVertApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        drugname = c.String(),
                        descriptions = c.String(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        gender = c.String(),
                        age = c.String(),
                        type = c.String(),
                        breed = c.String(),
                        color = c.String(),
                        clientsid = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.clientsid, cascadeDelete: true)
                .Index(t => t.clientsid);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fullname = c.String(),
                        address = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        symptoms = c.String(),
                        Diagnosis = c.String(),
                        DrugsAdministered = c.String(),
                        Amount = c.Double(nullable: false),
                        Temperature = c.String(),
                        treatmenttype = c.String(),
                        petid = c.Int(nullable: false),
                        userid = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(nullable: false),
                        Users_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pets", t => t.petid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Users_id)
                .Index(t => t.petid)
                .Index(t => t.Users_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        username = c.String(),
                        password = c.String(),
                        usertype = c.String(),
                        fullname = c.String(),
                        phonenumber = c.String(),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        vaccinename = c.String(),
                        Type = c.String(),
                        amount = c.Double(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedBy = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "Users_id", "dbo.Users");
            DropForeignKey("dbo.Treatments", "petid", "dbo.Pets");
            DropForeignKey("dbo.Pets", "clientsid", "dbo.Clients");
            DropIndex("dbo.Treatments", new[] { "Users_id" });
            DropIndex("dbo.Treatments", new[] { "petid" });
            DropIndex("dbo.Pets", new[] { "clientsid" });
            DropTable("dbo.Vaccinations");
            DropTable("dbo.Users");
            DropTable("dbo.Treatments");
            DropTable("dbo.Clients");
            DropTable("dbo.Pets");
            DropTable("dbo.Drugs");
        }
    }
}
