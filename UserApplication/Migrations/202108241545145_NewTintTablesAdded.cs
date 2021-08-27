namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTintTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantId = c.Int(nullable: false, identity: true),
                        FormNumber = c.String(),
                        IsApplicantFirstApplication = c.Boolean(nullable: false),
                        DateOfFirstApplication = c.DateTime(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicantId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Ethicinity = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        TelNo = c.String(),
                        CellNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        NationalIDNo = c.String(),
                        PassportNumber = c.String(nullable: false),
                        TIN = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Birth = c.Boolean(nullable: false),
                        Naturalization = c.Boolean(nullable: false),
                        Registration = c.Boolean(nullable: false),
                        Marriage = c.Boolean(nullable: false),
                        DualCitizenship = c.Boolean(nullable: false),
                        DualCitizenSpecification = c.String(),
                        Other = c.Boolean(nullable: false),
                        OtherSpecification = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        TelNo = c.String(),
                        FaxNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        NationalIDNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.ImmigrationStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PermanentResident = c.Boolean(nullable: false),
                        VoluntaryRemigrant = c.Boolean(nullable: false),
                        InvoluntaryRemigrant = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.MartialStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Single = c.Boolean(nullable: false),
                        Married = c.Boolean(nullable: false),
                        Divorced = c.Boolean(nullable: false),
                        Separated = c.Boolean(nullable: false),
                        Widowed = c.Boolean(nullable: false),
                        CommonLaw = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.SelfEmployeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        TypeOfBusiness = c.String(nullable: false),
                        NameOfBusiness = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        TelNo = c.String(),
                        FaxNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        NameofRegisteredOwner = c.String(nullable: false),
                        TypeofVehicle = c.String(nullable: false),
                        RegistrationNo = c.String(nullable: false),
                        Colour = c.String(),
                        SeatingCapacity = c.Int(nullable: false),
                        IdentificationMark = c.String(nullable: false),
                        ChassisNo = c.String(),
                        EngineNo = c.Int(nullable: false),
                        DrivingLicenceNo = c.String(nullable: false),
                        DLDateOfExpiry = c.DateTime(nullable: false),
                        MotorVehicleLicenceNo = c.String(nullable: false),
                        MVLDateOfExpiry = c.DateTime(nullable: false),
                        CertificateOfFitnessNo = c.String(nullable: false),
                        CertificateOfFitnessDateOfExpiry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "PersonId", "dbo.People");
            DropForeignKey("dbo.SelfEmployeds", "PersonId", "dbo.People");
            DropForeignKey("dbo.MartialStatus", "PersonId", "dbo.People");
            DropForeignKey("dbo.ImmigrationStatus", "PersonId", "dbo.People");
            DropForeignKey("dbo.Employers", "PersonId", "dbo.People");
            DropForeignKey("dbo.Citizens", "PersonId", "dbo.People");
            DropForeignKey("dbo.Applicants", "PersonId", "dbo.People");
            DropIndex("dbo.Vehicles", new[] { "PersonId" });
            DropIndex("dbo.SelfEmployeds", new[] { "PersonId" });
            DropIndex("dbo.MartialStatus", new[] { "PersonId" });
            DropIndex("dbo.ImmigrationStatus", new[] { "PersonId" });
            DropIndex("dbo.Employers", new[] { "PersonId" });
            DropIndex("dbo.Citizens", new[] { "PersonId" });
            DropIndex("dbo.Applicants", new[] { "PersonId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.SelfEmployeds");
            DropTable("dbo.MartialStatus");
            DropTable("dbo.ImmigrationStatus");
            DropTable("dbo.Employers");
            DropTable("dbo.Citizens");
            DropTable("dbo.People");
            DropTable("dbo.Applicants");
        }
    }
}
