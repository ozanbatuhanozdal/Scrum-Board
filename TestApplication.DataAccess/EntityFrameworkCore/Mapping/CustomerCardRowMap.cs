using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Entities;

namespace TestApplication.DataAccess.Mapping
{
    //CustomerCardRowMap
    public class CustomerCardRowMap : IEntityTypeConfiguration<CustomerCardRow>
    {
        public void Configure(EntityTypeBuilder<CustomerCardRow> builder)
        {
            //CustomerCardId kolon adı değiştirildi.
            builder.Property(x => x.CustomerCardId).HasColumnName("CustomerCardId");

            //developer name boş geçilemez
            //maksimum uzunluk 200
            //Kolon adı Developer Name
            builder.Property(x => x.DeveloperName)
                .IsRequired()
                .HasColumnName("DeveloperName")
                .HasMaxLength(200)
                .IsUnicode(false);

            //Explanation alanı boş geçilemez
            //boş geçilemez
            //kolon adı Explanation
            //max 200

            builder.Property(x => x.Explanation)
                .IsRequired()
                .HasColumnName("Explanation")
                .HasMaxLength(200)
                .IsUnicode(false);

            //Priorty boş geçilemez
            //kolon adı Priorty
            //max 200
            builder.Property(x => x.Priorty)
                .IsRequired()
                .HasColumnName("Priorty")
                .HasMaxLength(200)
                .IsUnicode(false);




            


        }
    }
}
