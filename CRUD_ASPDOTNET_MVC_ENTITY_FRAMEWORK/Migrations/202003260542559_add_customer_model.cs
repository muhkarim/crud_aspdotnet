namespace CRUD_ASPDOTNET_MVC_ENTITY_FRAMEWORK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_customer_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_M_Supplier");
        }
    }
}
