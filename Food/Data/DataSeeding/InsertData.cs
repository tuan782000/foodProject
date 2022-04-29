using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Entity;

namespace Food.Data.DataSeeding
{
    public static class InsertData
    {
        public static void Seed(this ModelBuilder builder)
        {


            //Id for product id
            var product1 = Guid.NewGuid().ToString();
            var product2 = Guid.NewGuid().ToString();
            var product3 = Guid.NewGuid().ToString();
            var product4 = Guid.NewGuid().ToString();
            var product5 = Guid.NewGuid().ToString();
            var product6 = Guid.NewGuid().ToString();
            var product7 = Guid.NewGuid().ToString();
            var product8 = Guid.NewGuid().ToString();
            var product9 = Guid.NewGuid().ToString();
            var product10 = Guid.NewGuid().ToString();
            var product11 = Guid.NewGuid().ToString();
            var product12 = Guid.NewGuid().ToString();
            var product13 = Guid.NewGuid().ToString();
            var product14 = Guid.NewGuid().ToString();
            var product15 = Guid.NewGuid().ToString();
            var product16 = Guid.NewGuid().ToString();
            var product17 = Guid.NewGuid().ToString();
            var product18 = Guid.NewGuid().ToString();
            var product19 = Guid.NewGuid().ToString();
            var product20 = Guid.NewGuid().ToString();
            var product21 = Guid.NewGuid().ToString();
            var product22 = Guid.NewGuid().ToString();
            var product23 = Guid.NewGuid().ToString();
            var product24 = Guid.NewGuid().ToString();
            var product25 = Guid.NewGuid().ToString();
            var product26 = Guid.NewGuid().ToString();
            var product27 = Guid.NewGuid().ToString();
            var product28 = Guid.NewGuid().ToString();


            //Table Products
            builder.Entity<Products>().HasData(
                new Products()
                {
                    pd_Id = product1,
                    pd_Name = "BanhCanhCua",
                    pd_Description = "BanhCanhCua",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/BanhCanhCua.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product2,
                    pd_Name = "BanhMi",
                    pd_Description = "BanhMi",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/BanhMi.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                }
                ,
                new Products()
                {
                    pd_Id = product3,
                    pd_Name = "banhtrangtron",
                    pd_Description = "banhtrangtron",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/banhtrangtron.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product4,
                    pd_Name = "banhuotlongdalat",
                    pd_Description = "banhuotlongdalat",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/banhuotlongdalat.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product5,
                    pd_Name = "BoKho",
                    pd_Description = "BoKho",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/BoKho.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product6,
                    pd_Name = "bunbo",
                    pd_Description = "bunbo",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/bunbo.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product7,
                    pd_Name = "bundaumamtom",
                    pd_Description = "bundaumamtom",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/bundaumamtom.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product8,
                    pd_Name = "Bunxaochay",
                    pd_Description = "Bunxaochay",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/Bunxaochay.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product9,
                    pd_Name = "cocosummer",
                    pd_Description = "cocosummer",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/cocosummer.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product10,
                    pd_Name = "comboxao",
                    pd_Description = "comboxao",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/comboxao.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product11,
                    pd_Name = "comga",
                    pd_Description = "comga",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/comga.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product12,
                    pd_Name = "comgadenhat",
                    pd_Description = "comgadenhat",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/comgadenhat.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product13,
                    pd_Name = "denhatthitnuong",
                    pd_Description = "denhatthitnuong",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/denhatthitnuong.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product14,
                    pd_Name = "goicuon",
                    pd_Description = "goicuon",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/goicuon.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product15,
                    pd_Name = "kfc",
                    pd_Description = "kfc",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/kfc.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product16,
                    pd_Name = "KimBap",
                    pd_Description = "KimBap",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/KimBap.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product17,
                    pd_Name = "loteria",
                    pd_Description = "loteria",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/loteria.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product18,
                    pd_Name = "mitronanvat",
                    pd_Description = "mitronanvat",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/mitronanvat.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product19,
                    pd_Name = "monngontrangbang",
                    pd_Description = "monngontrangbang",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/monngontrangbang.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product20,
                    pd_Name = "ParisBaguete",
                    pd_Description = "ParisBaguete",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/ParisBaguete.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product21,
                    pd_Name = "pizza",
                    pd_Description = "pizza",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/pizza.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product22,
                    pd_Name = "quanngontrangbang",
                    pd_Description = "quanngontrangbang",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/quanngontrangbang.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product23,
                    pd_Name = "RauMaMix",
                    pd_Description = "RauMaMix",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/RauMaMix.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product24,
                    pd_Name = "Royaltea",
                    pd_Description = "Royaltea",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/Royaltea.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product25,
                    pd_Name = "Sanfulou",
                    pd_Description = "Sanfulou",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/Sanfulou.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product26,
                    pd_Name = "stacbuk-cf",
                    pd_Description = "stacbuk-cf",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/stacbuk-cf.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product27,
                    pd_Name = "trasuanhalam",
                    pd_Description = "trasuanhalam",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/trasuanhalam.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                },
                new Products()
                {
                    pd_Id = product28,
                    pd_Name = "Xoixeoba3beo",
                    pd_Description = "Xoixeoba3beo",
                    pd_Price = 1,
                    pd_ReducePrice = 0,
                    pd_Img1 = "/images/item250x300/Xoixeoba3beo.png",
                    pd_Img2 = "",
                    pd_Img3 = "",
                    pd_Img4 = "",
                    pd_Rate = 5,
                    pd_ShortDescription = "Short Description",
                    pd_NameImg1 = "1",
                    pd_NameImg2 = "2",
                    pd_NameImg3 = "3",
                    pd_NameImg4 = "4"
                });


        //Table About
        builder.Entity<About>().HasData(
                new About()
                {
                    about_id=1,
                    about_Url= "https://www.youtube.com/watch?v=F1vcruph8JA",
                    about_Title = "Footwear the leading eCommerce Store around the Globe",
                    about_Description = "The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. \n \n When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove,the headline of Alphabet Village and the subline of her own road,the Line Lane.Pityful a rethoric question ran over her cheek,then she continued her way."
                });

            var IdRoleStaff = "f49e4348-718f-43e3-b1f6-6dc89c5Bb4fd";
            var IdRoleAdmin = "360E601E-92F2-4F08-832B-604A21293258";



            //Table AppRole 2222222222222222222222222222222222222222222222222222222222222222222
            builder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = IdRoleStaff,
                    Name ="Staff",
                    Description = "Staff",
                    NormalizedName = "staff"
                },
                new AppRole()
                {
                    Id = IdRoleAdmin,
                    Name = "Admin",
                    Description = "Admin",
                    NormalizedName = "admin"

                });


            var IdStaff = "f49e4348-718f-43e3-b1f6-6dc89c5Bb5ff";
            var IdAdmin = "DE544998-A3CC-4E12-ABB4-0642E57BD222";

            //Table AppUser 2222222222222222222222222222222222222222222222222222222222222222222
            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = IdAdmin,
                UserName = "Admin",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456Aa@"),
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "admin",
                LastName = "admin",
                DoB = new DateTime(2020, 01, 02)
            },
            new AppUser
            {
                Id = IdStaff,
                UserName = "Staff",
                NormalizedUserName = "STAFF@GMAIL.COM",
                NormalizedEmail = "STAFF@GMAIL.COM",
                Email = "staff@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456Aa@"),
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "staff",
                LastName = "staff",
                DoB = new DateTime(2020, 03, 02)
            });


            //Table AppUser - role 2222222222222222222222222222222222222222222222222222222222222222222
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = IdRoleStaff,
                UserId = IdStaff
            },
            new IdentityUserRole<string>
            {
                RoleId = IdRoleAdmin,
                UserId = IdAdmin
            });





            var IdCart1 = "72309286-ECBB-4D20-AD95-2819D31E3400";
            var IdCart2 = "D355458F-1DD3-4834-AA28-6DA34B6357FF";


            //Table Cart

            builder.Entity<Cart>().HasData(
                new Cart()
                {
                    cart_Id = IdCart1,
                    cart_UserID = IdStaff

                },
                new Cart()
                {
                    cart_Id = IdCart2,
                    cart_UserID = IdAdmin

                });


            //Table Product In Cart


            // Set id for Categories
            var idCategories1 = Guid.NewGuid().ToString();
            var idCategories2 = Guid.NewGuid().ToString();
            var idCategories3 = Guid.NewGuid().ToString();
            var idCategories4 = Guid.NewGuid().ToString();
            var idCategories5 = Guid.NewGuid().ToString();


            //Table Categories
            builder.Entity<Categories>().HasData(
                new Categories()
                {
                    cg_Id = idCategories1,
                    cg_Name = "Dry food",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = idCategories2,
                    cg_Name = "Food",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = idCategories3,
                    cg_Name = "Drink",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = idCategories4,
                    cg_Name = "Banhmi",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = idCategories5,
                    cg_Name = "Snack",
                    cg_Type = "",
                    cg_Sale = ""

                });








            //Table ContactUsers
            var contactUser = Guid.NewGuid().ToString();

            builder.Entity<ContactUsers>().HasData(
                new ContactUsers()
                {
                    cu_Id = contactUser.ToString(),
                    cu_FirstName = "FirstName",
                    cu_LastName = "LastName",
                    cu_Email = "Email",
                    cu_Subject = "Subject",
                    cu_Description = "Description"
                });


            var ReviewId1 = "EEBA6608-AB75-4E83-909F-604B1A06F16C";
            var ReviewId2 = "9EED8607-D2BB-45EE-AEE3-C59D858A7F97";
            var ReviewId3 = "C2A543C2-B1E2-4DC5-A131-9137E4673FA6";




            //Table Reviews new DateTime(2020, 01, 02)


            builder.Entity<Reviews>().HasData(
                new Reviews()
                {
                    review_id = ReviewId1,
                    review_Comment = "Good1",
                    review_UserId = IdAdmin,
                    review_UploadTime = new DateTime(2020, 01, 02),
                    review_HideStatus = false,
                    review_ReviewType = "Review"

                },
                new Reviews()
                {
                    review_id = ReviewId2,
                    review_Comment = "Good2",
                    review_UserId = IdStaff,
                    review_UploadTime = new DateTime(2020, 01, 02),
                    review_HideStatus = false,
                    review_ReviewType = "Review"

                },
                new Reviews()
                {
                    review_id = ReviewId3,
                    review_Comment = "Good3",
                    review_UserId = IdAdmin,
                    review_UploadTime = new DateTime(2020, 01, 02),
                    review_HideStatus = false,
                    review_ReviewType = "Review"

                });

            var SubReviewId1 = Guid.NewGuid().ToString(); 
            var SubReviewId2 = Guid.NewGuid().ToString();
            var SubReviewId3 = Guid.NewGuid().ToString();


            // Table SubReview 

            builder.Entity<SubReview>().HasData(
                new SubReview()
                {
                    subReview_Id = SubReviewId1,
                    subReview_UserId = IdAdmin,
                    subReview_Commnet = "subreview 1",
                    subReview_DateCommnet = new DateTime(2020, 01, 02),
                    subReview_HideStatus = false,
                    subreview_SubReviewType = "SubReview"
                },
                new SubReview()
                {
                    subReview_Id = SubReviewId2,
                    subReview_UserId = IdStaff,
                    subReview_Commnet = "subreview 3",
                    subReview_DateCommnet = new DateTime(2020, 01, 03),
                    subReview_HideStatus = false,
                    subreview_SubReviewType = "SubReview"
                },
                new SubReview()
                {
                    subReview_Id = SubReviewId3,
                    subReview_UserId = IdAdmin,
                    subReview_Commnet = "subreview 3",
                    subReview_DateCommnet = new DateTime(2020, 01, 03),
                    subReview_HideStatus = false,
                    subreview_SubReviewType = "SubReview"
                }
                );

            builder.Entity<SubReviewInReview>().HasData(
                new SubReviewInReview()
                {
                    SRiR_ReviewId = ReviewId1,
                    SRiR_SubReviewId = SubReviewId1
                },
                new SubReviewInReview()
                {
                    SRiR_ReviewId = ReviewId1,
                    SRiR_SubReviewId = SubReviewId2
                },
                new SubReviewInReview()
                {
                    SRiR_ReviewId = ReviewId2,
                    SRiR_SubReviewId = SubReviewId3
                }
                );

            //Table ProductInCategories
            builder.Entity<ProductsInCategories>().HasData(
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product7
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product8
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product10
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product11
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product12
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product13
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product14
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories1,
                    pic_productId = product16
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories2,
                    pic_productId = product1
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories2,
                    pic_productId = product4
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories2,
                    pic_productId = product5
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories2,
                    pic_productId = product6
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories2,
                    pic_productId = product19
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories3,
                    pic_productId = product23
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories3,
                    pic_productId = product24
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories3,
                    pic_productId = product26
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories3,
                    pic_productId = product27
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories4,
                    pic_productId = product2
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories4,
                    pic_productId = product18
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product3
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product9
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product15
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product17
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product20
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product21
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product22
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product25
                },
                new ProductsInCategories()
                {
                    pic_CategoriesId = idCategories5,
                    pic_productId = product28
                });


            //Table ReviewInproduct



            builder.Entity<ReviewInproduct>().HasData(
                new ReviewInproduct()
                {
                    rip_ProductId = product1,
                    rip_ReviewId = ReviewId1,
                },
                new ReviewInproduct()
                {
                    rip_ProductId = product1,
                    rip_ReviewId = ReviewId2,
                },
                new ReviewInproduct()
                {
                    rip_ProductId = product1,
                    rip_ReviewId = ReviewId3,
                });


            builder.Entity<Coupons>().HasData(
                new Coupons()
                {
                    couponId = Guid.NewGuid().ToString(),
                    couponCode ="code10",
                    couponPrice = 10
                },
                new Coupons()
                {
                    couponId = Guid.NewGuid().ToString(),
                    couponCode = "code50",
                    couponPrice = 50
                });



            string billId1 = "D269BF93-A5E2-4C4A-8146-9967DDE80D30";

            //Table Bills

            builder.Entity<Bills>().HasData(
                new Bills()
                {
                    bill_Id = billId1,
                    bill_UserId = IdStaff,
                    bill_PaidTotal = 2000,
                    bill_ProductIdlist = "1|2|3|4",
                    bill_ProductNamelist = "product 1|product 2| product 3| product 4|",
                    bill_ProductPricelist = "550|450|350|640|",
                    bill_Shipping = 10,
                    bill_Discount = 0,
                    bill_Confirmation = true,
                    bill_DatetimeOrder = DateTime.Now,
                    bill_PaymentMethod = "Check Payment",
                    bill_Note = "",
                    bill_Quantity = "1|1|2|1|",
                    bill_HideStatus = false,
                    bill_WaitForConfirmation = false,
                    bill_WaitPickup = false,
                    bill_Delivering = false,
                    bill_Delivered =  false,
                    bill_Cancelled = false
                }); ;

            //Table Shiping

            string shipId = "7CF94A7D-9239-446E-A404-086518F84652";

            builder.Entity<Shipping>().HasData(
                new Shipping()
                {
                    ship_Id = shipId,
                    ship_Name ="Ship",
                    ship_Price = 5
                });

            //Table Contact System

            var ContactSystemId = Guid.NewGuid().ToString();

            builder.Entity<ContactSystem>().HasData(
                new ContactSystem()
                {
                    Contact_Id = ContactSystemId,
                    Contact_Address = "Huntsville, AL 35813, USA",
                    Contact_Description = "Prof Lord John Krebs provides a brief history of human food, from our remote ancestors 3 million years ago to the present day. By looking at the four great transitions in human food - cooking, agriculture, processing, and preservation - he considers a variety of questions, including why people like some kinds of foods and not others; how your senses contribute to flavor; the role of genetics in our likes and dislikes; and the differences in learning and culture around the world.",
                    Contact_Email = "support@foodshop.com ",
                    Contact_Phone = "021.343.7575"
                });


        }    
                
               
    }   
}
