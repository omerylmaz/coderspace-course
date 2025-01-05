using CourseApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class UserSeeder
{
    public static List<AppUser> SeedUsers()
    {
        var passwordHasher = new PasswordHasher<AppUser>();

        var users = new List<AppUser>
        {
            new AppUser
            {
                Id = Guid.Parse(input: "9beb751f-f3b8-4e45-a938-622ebc1dd038"),
                UserName = "omeryilmaz",
                NormalizedUserName = "OMERYILMAZ",
                Email = "user1@gmail.com",
                NormalizedEmail = "USER1@GMAIL.COM",
                FullName = "Ömer Yılmaz",
                PhoneNumber = "5551112233",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "user123")
            },
            new AppUser
            {
                Id = Guid.Parse("54039b1c-f914-4171-97a8-f78a9c107935"),
                UserName = "okanburuk",
                NormalizedUserName = "OKANBURUK",
                Email = "user2@gmail.com",
                NormalizedEmail = "USER2@GMAIL.COM",
                FullName = "Okan Buruk",
                PhoneNumber = "5552223344",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "user123")
            },
            new AppUser
            {
                Id = Guid.Parse("4f1d809c-9ccf-4479-b1ab-273f6193679b"),
                UserName = "kivanctatli",
                NormalizedUserName = "KIVANCTATLI",
                Email = "user3@gmail.com",
                NormalizedEmail = "USER3@GMAIL.COM",
                FullName = "Kıvanç Tatlıtuğ",
                PhoneNumber = "5553334455",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "user123")
            },
            new AppUser
            {
                Id = Guid.Parse("2d8651fd-3800-48da-a85c-f294282b5180"),
                UserName = "keremturk",
                NormalizedUserName = "KEREMTURK",
                Email = "user4@gmail.com",
                NormalizedEmail = "USER4@GMAIL.COM",
                FullName = "Kerem Aktürkoğlu",
                PhoneNumber = "5554445566",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "user123")
            },
            new AppUser
            {
                Id = Guid.Parse("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"),
                UserName = "osimhen",
                NormalizedUserName = "OSIMHEN",
                Email = "user5@gmail.com",
                NormalizedEmail = "USER5@GMAIL.COM",
                FullName = "Victor Osimhen",
                PhoneNumber = "5555556677",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "user123")
            },
        };

        var teachers = new List<AppUser>
        {
            new AppUser
            {
                Id = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                UserName = "ahmetkaya",
                NormalizedUserName = "AHMETKAYA",
                Email = "teacher1@gmail.com",
                NormalizedEmail = "TEACHER1@GMAIL.COM",
                FullName = "Ahmet Kaya",
                PhoneNumber = "5556667788",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "teacher123")
            },
            new AppUser
            {
                Id = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                UserName = "fatihcakiroglu",
                NormalizedUserName = "FATIHCAMIR",
                Email = "teacher2@gmail.com",
                NormalizedEmail = "TEACHER2@GMAIL.COM",
                FullName = "Fatih Çakıroğlu",
                PhoneNumber = "5557778899",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "teacher123")
            },
            new AppUser
            {
                Id = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                UserName = "sadievrenseker",
                NormalizedUserName = "SADIEVRENSEKER",
                Email = "teacher3@gmail.com",
                NormalizedEmail = "TEACHER3@GMAIL.COM",
                FullName = "Şadi Evren Şeker",
                PhoneNumber = "5558889900",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "teacher123")
            }
        };

        users.AddRange(teachers);
        return users;
    }
}
