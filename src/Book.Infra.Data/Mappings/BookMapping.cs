using BackendTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTest.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder){
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.ToTable("Books");
        }
    }
}