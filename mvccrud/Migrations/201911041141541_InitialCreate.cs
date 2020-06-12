namespace mvccrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        City_id = c.Int(nullable: false, identity: true),
                        City_name = c.String(),
                    })
                .PrimaryKey(t => t.City_id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Country_id = c.Int(nullable: false, identity: true),
                        Country_name = c.String(),
                    })
                .PrimaryKey(t => t.Country_id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Empid = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Gender = c.String(),
                        Email = c.String(),
                        Marial_Status = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Hobbies = c.String(),
                        Photo = c.Binary(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(),
                        Country = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        Zipcode = c.String(),
                        Password = c.String(),
                        Create_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Empid);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        State_id = c.Int(nullable: false, identity: true),
                        State_name = c.String(),
                    })
                .PrimaryKey(t => t.State_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.State");
            DropTable("dbo.Employee");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
