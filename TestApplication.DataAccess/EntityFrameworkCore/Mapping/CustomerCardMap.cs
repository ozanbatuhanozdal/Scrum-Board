using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.Mapping
{
    //IEntityTypeConfigurationını kalıtım alıcak
    public class CustomerCardMap : IEntityTypeConfiguration<CustomerCard>
    {
        //customerCardMap
        public void Configure(EntityTypeBuilder<CustomerCard> builder)
        {
            //customerId kolon adı CustomerCardId
           
            builder.Property(x => x.CustomerCardId).HasColumnName("CustomerCardId");

            //CustomerCardName boş geçilemez
            //CustomerNAme uzunluğu maksimum uzunluğu 200
            builder.Property(x => x.CustomerCardName)
                .IsRequired()
                .HasColumnName("CustomerCardName")
                .HasMaxLength(200)
                .IsUnicode(false);

            //ProductManagerNAme boş geçilemez
            //max 200
            //kolon adı ProductManager Name
            builder.Property(x => x.ProductManagerName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("ProductManagerName")
                .IsUnicode(false);

            

        }
    }
}
