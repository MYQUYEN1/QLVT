
using QLVT.Models;
using System.Data.Entity;

namespace QLVT.ApplicationDbContext
{
    public class MasterDbCotext:DbContext
    {
        public MasterDbCotext(string connectionString) : base(connectionString) { }
        public DbSet<Login> accounts { get; set; }
        //public DbSet<ChiNhanh> branchs { get; set; }
        //public  DbSet<Nhom> groups { get; set; }
        //public DbSet<VatTu> products { get; set; }
        public DbSet<NhanVien> employees { get;set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasKey(u => u.MaLogin);

            modelBuilder.Entity<NhanVien>()
                .HasKey(u => u.MaNV);
        }
    }
}