using CourseApp.Domain.Entities;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class CourseSeeder
{
    public static List<Course> SeedCourses()
    {
        List<Course> courses =
        [
            new Course
            {
                Id = Guid.Parse("7f16ad2a-473f-47a9-b26d-523e9f9cf805"),
                Name = "Introduction to C# Programming",
                Title = "Learn the basics of C# programming",
                Description = "This course covers the fundamentals of C# programming, including syntax, classes, and objects.",
                Price = 99.99m,
                ImageUrl = "https://code.visualstudio.com/assets/docs/languages/csharp/csharp-hero.png",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"),
                Name = "UI/UX Design Principles",
                Title = "Master UI/UX design fundamentals",
                Description = "Learn the key principles of UI/UX design to create user-friendly and visually appealing designs.",
                Price = 149.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1733306548826-95daff988ae6?q=80&w=1824&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("a82c256f-6027-4c22-87ca-22fb85c2daf6")
            },
            new Course
            {
                Id = Guid.Parse("cb89ad2a-473f-47a9-b26d-523e9f9cf807"),
                Name = "Digital Marketing 101",
                Title = "Learn digital marketing strategies",
                Description = "This course provides an introduction to digital marketing, covering SEO, social media, and email marketing.",
                Price = 199.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661425715124-310ec1b49b8a?q=80&w=1882&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"), 
                CategoryId = Guid.Parse("a2308a61-470a-46e9-ba82-87c3090046fb") 
            },
            new Course
            {
                Id = Guid.Parse("a29eac2a-473f-47a9-b26d-523e9f9cf808"),
                Name = "Project Management Essentials",
                Title = "Learn to manage projects effectively",
                Description = "This course covers essential project management techniques and tools for successful project execution.",
                Price = 119.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1726743809701-67e8600f7670?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), 
                CategoryId = Guid.Parse("80853207-5355-434f-8cab-80e3269d54c4") 
            },
            new Course
            {
                Id = Guid.Parse("f45bda6a-473f-47a9-b26d-523e9f9cf809"),
                Name = "Personal Finance Basics",
                Title = "Manage your finances effectively",
                Description = "Learn the basics of personal finance, including budgeting, saving, and investing.",
                Price = 79.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1663100794696-6b7afa02016c?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                CategoryId = Guid.Parse("551963a2-879e-45a6-99a6-5eb512b775c0")
            },
            new Course
            {
                Id = Guid.Parse("d32f93ae-13f3-452f-97c1-0f9dc7c09300"),
                Name = "Advanced Python Programming",
                Title = "Master advanced Python concepts",
                Description = "This course dives into advanced Python topics, including data structures, algorithms, and performance optimization.",
                Price = 129.99m,
                ImageUrl = "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"),
                Name = "Illustrator Essentials",
                Title = "Learn Adobe Illustrator from scratch",
                Description = "Discover the tools and techniques to create stunning vector designs using Adobe Illustrator.",
                Price = 99.99m,
                ImageUrl = "https://images.unsplash.com/photo-1526485797145-514b2fe83749?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                CategoryId = Guid.Parse("a82c256f-6027-4c22-87ca-22fb85c2daf6")
            },
            new Course
            {
                Id = Guid.Parse("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"),
                Name = "SEO Mastery",
                Title = "Boost your website's SEO",
                Description = "Learn the best SEO practices to rank higher in search engine results and attract more traffic.",
                Price = 179.99m,
                ImageUrl = "https://images.unsplash.com/photo-1562577309-2592ab84b1bc?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                CategoryId = Guid.Parse("a2308a61-470a-46e9-ba82-87c3090046fb")
            },
            new Course
            {
                Id = Guid.Parse("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"),
                Name = "Agile Project Management",
                Title = "Master Agile methodologies",
                Description = "Explore Agile project management techniques to deliver successful projects on time.",
                Price = 149.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("80853207-5355-434f-8cab-80e3269d54c4")
            },
            new Course
            {
                Id = Guid.Parse("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"),
                Name = "Investing for Beginners",
                Title = "Learn the basics of investing",
                Description = "Understand the principles of investing and learn how to grow your wealth over time.",
                Price = 89.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661765276951-68739fdcb8ea?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"),
                CategoryId = Guid.Parse("551963a2-879e-45a6-99a6-5eb512b775c0")
            },

            new Course
            {
                Id = Guid.Parse("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"),
                Name = "Photography Basics",
                Title = "Capture stunning photos",
                Description = "Learn the art of photography, including composition, lighting, and camera settings.",
                Price = 79.99m,
                ImageUrl = "https://images.unsplash.com/photo-1524037992922-3a0937719e1d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("a93961af-166d-461c-a6db-263c4d48a55d")
            },
            new Course
            {
                Id = Guid.Parse("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"),
                Name = "Personal Branding",
                Title = "Build your personal brand",
                Description = "Learn how to create and promote your personal brand to stand out in your industry.",
                Price = 99.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1683543124615-fb42e42c6201?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("a2308a61-470a-46e9-ba82-87c3090046fb")
            },
            new Course
            {
                Id = Guid.Parse("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"),
                Name = "Graphic Design Fundamentals",
                Title = "Learn the basics of graphic design",
                Description = "Discover the principles of graphic design and how to create eye-catching visuals.",
                Price = 119.99m,
                ImageUrl = "https://images.unsplash.com/photo-1432888498266-38ffec3eaf0a?q=80&w=2074&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("a82c256f-6027-4c22-87ca-22fb85c2daf6")
            },
            new Course
            {
                Id = Guid.Parse("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"),
                Name = "Introduction to Data Science",
                Title = "Explore the world of data science",
                Description = "Learn data analysis, visualization, and machine learning basics with Python.",
                Price = 199.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1714618831065-8e8dadd8d3df?q=80&w=1800&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"),
                Name = "Financial Analysis Basics",
                Title = "Learn financial analysis techniques",
                Description = "Master the tools and techniques needed to analyze financial statements and make better decisions.",
                Price = 149.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661418553375-5ea448f11f34?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("551963a2-879e-45a6-99a6-5eb512b775c0")
            },
            new Course
            {
                Id = Guid.Parse("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"),
                Name = "Public Speaking Confidence",
                Title = "Speak confidently in public",
                Description = "Learn the skills needed to speak confidently and effectively in front of an audience.",
                Price = 89.99m,
                ImageUrl = "https://plus.unsplash.com/premium_photo-1661780400751-e8e9a09ba7b1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("8b48bba4-8acd-4ff2-b669-f4095c885e90")
            },
            new Course
            {
                Id = Guid.Parse("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"),
                Name = "Creative Writing",
                Title = "Master the art of storytelling",
                Description = "Learn how to craft compelling stories and improve your writing skills.",
                Price = 109.99m,
                ImageUrl = "https://images.unsplash.com/photo-1617575521317-d2974f3b56d2?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("8b48bba4-8acd-4ff2-b669-f4095c885e90")
            },
            new Course
            {
                Id = Guid.Parse("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"),
                Name = "Frontend Development Essentials",
                Title = "Master HTML, CSS, and JavaScript",
                Description = "Learn to build responsive and interactive web pages using modern frontend technologies.",
                Price = 129.99m,
                ImageUrl = "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"), 
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044") 
            },
            new Course
            {
                Id = Guid.Parse("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"),
                Name = "Unity Game Development",
                Title = "Build games with Unity",
                Description = "Learn to create 2D and 3D games using the Unity engine and C# scripting.",
                Price = 149.99m,
                ImageUrl = "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"), 
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044") 
            },
            new Course
            {
                Id = Guid.Parse("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"),
                Name = ".NET Core Development",
                Title = "Master .NET Core and build robust APIs",
                Description = "Learn to create high-performance web APIs and applications using .NET Core.",
                Price = 159.99m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
                {
                    Id = Guid.Parse("1d9a5bcd-2390-4f8e-92c3-d23a5bcd2391"),
                    Name = "Advanced Frontend Development",
                    Title = "Master advanced frontend technologies",
                    Description = "Learn React, Angular, and Vue.js to build complex and interactive web applications.",
                    Price = 149.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                    CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044") 
                },
            new Course
            {
                Id = Guid.Parse("2d8b5cfa-3441-4b9a-832b-d23a6c9d1342"),
                Name = "Unity Advanced Game Mechanics",
                Title = "Master advanced Unity game development",
                Description = "Learn advanced techniques for 3D game development, including physics and AI integration in Unity.",
                Price = 199.99m,
                ImageUrl = "https://cdn.prod.website-files.com/618d852d383de946ce0e3fa5/621675c05eb08a490b32f9f1_image%2B(1)%20(1).webp",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("3e7c5dfb-7892-4c9a-913b-e45b8c9d1343"),
                Name = "Responsive Web Design",
                Title = "Create beautiful responsive websites",
                Description = "Learn how to design and build responsive websites using CSS, Flexbox, and Grid Layout.",
                Price = 129.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1508317469940-e3de49ba902e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("4f6d7cfb-6783-4d9a-91b4-f56d8c9d1344"),
                Name = "JavaScript for Beginners",
                Title = "Master the fundamentals of JavaScript",
                Description = "Learn JavaScript from scratch, including variables, functions, and DOM manipulation.",
                Price = 89.99m,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a4/JavaScript_code.png",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044") 
            },
            new Course
            {
                Id = Guid.Parse("5f7e8cfb-8914-4e9a-92c5-167e9d9d1345"),
                Name = "CSS Mastery",
                Title = "Advanced CSS techniques",
                Description = "Master complex CSS concepts like animations, transitions, and preprocessors like SASS and LESS.",
                Price = 109.99m,
                ImageUrl = "https://cdn.prod.website-files.com/6097e0eca1e875de53031ff6/66b344b75c2572d16bb65242_66b343c191fd4cea42793a3a_image%2520-%25202024-08-07T125129.064.png",
                TeacherId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044") 
            },

            new Course
            {
                Id = Guid.Parse("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"),
                Name = "Advanced .NET Backend Development",
                Title = "Build enterprise-level backend systems",
                Description = "Master advanced .NET Core features to develop scalable and secure backend applications.",
                Price = 159.99m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("4bced12f-c5b0-484d-8fd6-a9557329b1e0"),
                Name = "Building APIs with .NET Core",
                Title = "Create robust and efficient APIs",
                Description = "Learn how to build, secure, and optimize APIs using .NET Core.",
                Price = 139.99m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("b71f2993-7de5-4175-8421-875eb7323b5a"),
                Name = "Entity Framework Core Mastery",
                Title = "Master data access with EF Core",
                Description = "Learn advanced techniques for working with databases using Entity Framework Core.",
                Price = 149.99m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044") 
            },
            new Course
            {
                Id = Guid.Parse("2dea5bce-36b6-457a-9a31-4626f9b213ec"),
                Name = "ASP.NET Core Security",
                Title = "Secure your web applications",
                Description = "Learn to implement robust security practices in ASP.NET Core applications.",
                Price = 169.99m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            },
            new Course
            {
                Id = Guid.Parse("24eb5fb1-e5cb-4318-8612-ef01d60a09ef"),
                Name = "Microservices with .NET",
                Title = "Develop microservices architecture",
                Description = "Master microservices development and deployment with .NET and Docker.",
                Price = 189.99m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5rxZLdUPpgRio9Nt-sqVL7hjxmk0xoGU0dQ&s",
                TeacherId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"),
                CategoryId = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044")
            }
                    ];
        return courses;
    }
}
