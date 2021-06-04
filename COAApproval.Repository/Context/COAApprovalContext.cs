using System.Data.Entity;
using COAApproval.Repository.Model;

namespace COAApproval.Repository.Context
{
    public partial class COAApprovalContext : DbContext
    {
        public COAApprovalContext()
            : base("name=COAApprovalContext")
        {
        }

        public virtual DbSet<user_accounts> user_accountss { get; set; }
        public virtual DbSet<COA_Approval> COA_Approvals { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<COA_Approval>().ToTable("COA_Approval", "public");
            //modelBuilder.Entity<user_accounts>().ToTable("user_accounts", "public");

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}