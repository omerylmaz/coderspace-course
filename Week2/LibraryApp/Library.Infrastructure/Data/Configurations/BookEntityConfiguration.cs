using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Configurations;

public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Author)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.AvailableCopies)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasData
        (
            new Book() { Author = "Ömer Yılmaz", AvailableCopies = 5, Genre = "bilim kurgu", Id = Guid.NewGuid(), ISBN = "1234", Language = "ingilizce", PageCount = 305, PublicationYear = 2015, Publisher = "Bilim Yayınları", Summary = "bilim kitabı", Title = "Zamanın Ötesinde" },
            new Book() { Author = "Ebru Kaya", AvailableCopies = 2, Genre = "romantik", Id = Guid.NewGuid(), ISBN = "9876", Language = "fransızca", PageCount = 192, PublicationYear = 2000, Publisher = "Bilim Yayınları", Summary = "unutulmaz bir hikaye", Title = "Bir Yaz Günü" },
            new Book() { Author = "Mehmet Takın", AvailableCopies = 12, Genre = "macera", Id = Guid.NewGuid(), ISBN = "5678", Language = "türkçe", PageCount = 467, PublicationYear = 2010, Publisher = "Bilim Yayınları", Summary = "Zirve Yolunda kitabı", Title = "Zirve Yolunda" },
            new Book() { Author = "Elif Aksu", AvailableCopies = 8, Genre = "felsefe", Id = Guid.NewGuid(), ISBN = "3456", Language = "almanca", PageCount = 210, PublicationYear = 1998, Publisher = "Bilim Yayınları", Summary = "Hayatın anlamına dair derin bir sorgulama", Title = "Sefiller" },
            new Book() { Author = "Berk Can", AvailableCopies = 7, Genre = "korku", Id = Guid.NewGuid(), ISBN = "1111", Language = "italyanca", PageCount = 333, PublicationYear = 2022, Publisher = "Bilim Yayınları", Summary = "Clean architecture kitabı", Title = "Clean Architecture" },
            new Book() { Author = "Zeynep Yılmaz", AvailableCopies = 0, Genre = "biyografi", Id = Guid.NewGuid(), ISBN = "2222", Language = "ispanyolca", PageCount = 654, PublicationYear = 1995, Publisher = "Hayat Yayınları", Summary = "YAzılımcıya çok güzel şeyler katan bir kitap", Title = "Pragmatic Programmer" },
            new Book() { Author = "Ali Deniz", AvailableCopies = 15, Genre = "fantastik", Id = Guid.NewGuid(), ISBN = "4444", Language = "japonca", PageCount = 532, PublicationYear = 2018, Publisher = "Bilim Yayınları", Summary = "DDD prensibinin genel anlatımı", Title = "Learning DDD" },
            new Book() { Author = "Merve Koç", AvailableCopies = 6, Genre = "tarih", Id = Guid.NewGuid(), ISBN = "3333", Language = "arapça", PageCount = 423, PublicationYear = 2011, Publisher = "Bilim Yayınları", Summary = "Billim kurgu çok güzel bir kitap", Title = "Dune" },
            new Book() { Author = "Burak Efe", AvailableCopies = 3, Genre = "dedektif", Id = Guid.NewGuid(), ISBN = "8888", Language = "rusça", PageCount = 280, PublicationYear = 2020, Publisher = "Bilim Yayınları", Summary = "Hababam Sınıfı hikayeleri", Title = "Hababam Sınıfı" }
        );

    }
}
