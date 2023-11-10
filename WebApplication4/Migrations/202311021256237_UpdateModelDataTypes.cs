namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelDataTypes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Players", name: "Region_ID", newName: "NatID");
            RenameIndex(table: "dbo.Players", name: "IX_Region_ID", newName: "IX_NatID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Players", name: "IX_NatID", newName: "IX_Region_ID");
            RenameColumn(table: "dbo.Players", name: "NatID", newName: "Region_ID");
        }
    }
}
