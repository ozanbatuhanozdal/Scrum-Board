using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        //CustomerMap
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
           
            //kolon adı CustomerId
            builder.Property(x => x.CustomerId).HasColumnName("CustomerId");

            //CustomerName boş geçilemez
            //kolon adı Customer Name 
            //maksimum uzunluğu 200
            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasColumnName("CustomerName")
                .HasMaxLength(200)
                .IsUnicode(false);

            //CustomerPhone boş geçilemez
            //kolon adı Customer Name 
            //maksimum uzunluğu 200
            builder.Property(x => x.CustomerPhone)
                .IsRequired()
                .HasColumnName("CustomerPhone")
                .HasMaxLength(11).IsUnicode(false);


            //CustomerAddress boş geçilemez
            //kolon adı Customer Address
            //maksimum uzunluğu 200
            builder.Property(x => x.CustomerAddress)
                .IsRequired()
                .HasColumnName("CustomerAddress")
                .HasMaxLength(200);


           
        }
    }
}
