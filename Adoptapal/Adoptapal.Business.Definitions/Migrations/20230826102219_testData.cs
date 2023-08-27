using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class testData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Lat", "Long", "Street", "StreetNumber", "Zip" },
                values: new object[] { new Guid("44674b8f-3fdb-46a4-840e-5415feb68b1d"), "Sample City", 37.774900000000002, -122.4194, "Main St", "1", "12345" });

            migrationBuilder.InsertData(
                table: "Nutzer",
                columns: new[] { "Id", "AddressId", "Email", "Name", "Password", "PhoneNumber", "PhotoPath", "ResetToken" },
                values: new object[,]
                {
                    { new Guid("844bb58e-a70f-4345-ad95-f08e82cdb2ee"), "44674b8f-3fdb-46a4-840e-5415feb68b1d", "hans.meyer@fakemail.io", "Hans Meyer", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", "+1234567890", "test_user_2.jpg", null },
                    { new Guid("89ca65f5-787f-4b92-ab9e-2c86f6d426a9"), "44674b8f-3fdb-46a4-840e-5415feb68b1d", "gabi.schnitzler@tierheim.de", "Gabi Schnitzler", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", "+9876543210", "test_user_1.jpg", null },
                    { new Guid("e6e7158d-6a4b-48b3-9760-3e3a8b0b9c12"), "44674b8f-3fdb-46a4-840e-5415feb68b1d", "richard.kloese@mail.de", "Richard Klöse", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", "+9876543210", null, null },
                    { new Guid("6d4eaf81-aa75-4e2e-9c7e-1f29060d7c7f"), "44674b8f-3fdb-46a4-840e-5415feb68b1d", "katzentempel@tierheim.de", "Tierheim Katzentempel", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", null, null, null },
                    { new Guid("f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61"), "44674b8f-3fdb-46a4-840e-5415feb68b1d", "felix.richter@email.com", "Felix Richter", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tiere",
                columns: new[] { "Id", "AnimalCategory", "Birthday", "Color", "Description", "ImageFilePath", "IsMale", "Name", "UserId", "Weight" },
                values: new object[,]
                {
                    { new Guid("0500293e-bb8a-4c1d-b1a8-2edddf992f3c"), "Cat", new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "White", "A cute and friendly cat", "test_cat_1.jpg", true, "Fluffy", "844bb58e-a70f-4345-ad95-f08e82cdb2ee", 15.5f },
                    { new Guid("e0597683-c3f2-41e8-95e6-19f052c2bb83"), "Cat", new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gray", "A playful and curious cat", "test_cat_2.jpg", false, "Whiskers", "844bb58e-a70f-4345-ad95-f08e82cdb2ee", 8.2f },
                    { new Guid("7a865b0f-3e5e-4b28-b75f-81e5d6e2aae1"), "Cat", new DateTime(2018, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black", "A mysterious black cat", "test_cat_3.jpg", true, "Midnight", "89ca65f5-787f-4b92-ab9e-2c86f6d426a9", 10.0f },
                    { new Guid("3f7e15e2-ee44-43d0-bd34-73ff1a1a84e2"), "Cat", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange", "A playful orange cat", "test_cat_4.jpg", false, "Tiger", "89ca65f5-787f-4b92-ab9e-2c86f6d426a9", 9.5f },
                    { new Guid("7d16a685-0b67-45d9-8c4f-7e1f7c931a37"), "Dog", new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "An energetic and friendly dog", "test_dog_1.jpg", true, "Buddy", "f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61", 22.0f },
                    { new Guid("3e52f74e-4333-4c5a-9aa8-b2d348077222"), "Dog", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spotted", "A spotted dog with a playful personality", "test_dog_2.jpg", true, "Spot", "f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61", 18.5f }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Title", "Text", "PostTime", "UserId" },
                values: new object[,]
                {
                    { new Guid("4e6af6e2-cba4-491c-8224-09d126883156"), "missing dog", "My dog Danny has gone missing. He is a short dog with black and white fur and wears a blue collar. Has anyone seen him?", new DateTime(2022, 12, 1, 13, 45, 32, 5, DateTimeKind.Unspecified), "844bb58e-a70f-4345-ad95-f08e82cdb2ee" },
                    { new Guid("cf7f8dd5-1b0a-4758-a8e0-90fc00918f4a"), "parrot on my balcony", "A parrot has landed on my balcony and he seems to be very friendly and not afraid of humans. Is someone missing their pet parrot? I took him in so he doesn't fly away anymore.", new DateTime(2023, 4, 20, 13, 2, 55, 21, DateTimeKind.Unspecified), "f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61" },
                    { new Guid("9fd57ff2-d6c9-48d2-bb33-d137c5b49a9f"), "got another cat", "I recently brought home another cat to keep my cat Albert company when i'm away. Is there anything to keep in mind when i introduce him to my new cat, Pippa?", new DateTime(2021, 7, 8, 14, 52, 6, 27, DateTimeKind.Unspecified), "e6e7158d-6a4b-48b3-9760-3e3a8b0b9c12" },
                    { new Guid("1f16a465-4503-4fba-99ef-868103bb44c7"), "cat ate salami", "Albert, my cat, just snatched a slice of salami from my sandwich. Will he be okay? Is it harmful for cats to eat something like salami?", new DateTime(2021, 10, 19, 18, 24, 32, 9, DateTimeKind.Unspecified), "e6e7158d-6a4b-48b3-9760-3e3a8b0b9c12" },
                    { new Guid("3f040519-5d77-416c-8983-a12a3778902f"), "kittens up for adoption", "My cat Pippa has recently given birth to three little kittens, one white and two black. As i don't have the space to care for more kittens, i would love for them to be adopted into new loving homes. The kittens are now 2 months old and have already been to the vet to recieve everything necessary.", new DateTime(2022, 8, 26, 9, 39, 2, 40, DateTimeKind.Unspecified), "e6e7158d-6a4b-48b3-9760-3e3a8b0b9c12" }
                });

            migrationBuilder.InsertData(
                table: "Kommentare",
                columns: new[] { "Id", "Text", "PostTime", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e87bb46e-e2a4-4560-b660-02d9ab74c86b"), "he should be fine, i think", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1f16a465-4503-4fba-99ef-868103bb44c7", "f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61" },
                    { new Guid("213c5355-96cf-4ced-8caa-a23be72e06ac"), "cats can have a little bit of salami", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1f16a465-4503-4fba-99ef-868103bb44c7", "6d4eaf81-aa75-4e2e-9c7e-1f29060d7c7f" },
                    { new Guid("7e9fa2e4-5c4a-4620-a3fe-d8e46ac3cb54"), "Oh, i think this is my parrot Joseph. I'll write you an email", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf7f8dd5-1b0a-4758-a8e0-90fc00918f4a", "89ca65f5-787f-4b92-ab9e-2c86f6d426a9" },
                    { new Guid("43ea84ba-73ae-445a-8ce9-dfe87f55311e"), "alright, he'll have a good time here for the time being :)", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf7f8dd5-1b0a-4758-a8e0-90fc00918f4a", "f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61" },
                    { new Guid("9edfb82c-8c7c-4bb1-868f-521b5e1cb514"), "congratulations!", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f040519-5d77-416c-8983-a12a3778902f", "f6a84c6e-e0da-4c3b-b9ef-6fcb50f5cf61" },
                    { new Guid("2739e0c3-819c-4c6e-9980-9dac842aea17"), "oh i hope they find a new home", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f040519-5d77-416c-8983-a12a3778902f", "6d4eaf81-aa75-4e2e-9c7e-1f29060d7c7f" },
                    { new Guid("4585720c-ebb9-45dd-aacb-64209690140e"), "you should post some pictures of them", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f040519-5d77-416c-8983-a12a3778902f", "6d4eaf81-aa75-4e2e-9c7e-1f29060d7c7f" },
                    { new Guid("a2d55ba8-4af3-4511-b5c2-0426ee693ad7"), "three little kittens? How lovely", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f040519-5d77-416c-8983-a12a3778902f", "844bb58e-a70f-4345-ad95-f08e82cdb2ee" },
                    { new Guid("14cbaa30-37ec-4754-8fbf-bf31deab3375"), "nevermind, guess who just showed up on my front porch again", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "4e6af6e2-cba4-491c-8224-09d126883156", "844bb58e-a70f-4345-ad95-f08e82cdb2ee" },
                    { new Guid("8da02c2e-b180-4749-8d0b-4538a71b1d02"), "You can write us an email if you want. We would gladly help you further in this matter.", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "9fd57ff2-d6c9-48d2-bb33-d137c5b49a9f", "6d4eaf81-aa75-4e2e-9c7e-1f29060d7c7f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: new Guid("44674b8f-3fdb-46a4-840e-5415feb68b1d"));

            migrationBuilder.DeleteData(
                table: "Nutzer",
                keyColumn: "Id",
                keyValue: new Guid("844bb58e-a70f-4345-ad95-f08e82cdb2ee"));

            migrationBuilder.DeleteData(
                table: "Nutzer",
                keyColumn: "Id",
                keyValue: new Guid("89ca65f5-787f-4b92-ab9e-2c86f6d426a9"));

            migrationBuilder.DeleteData(
                table: "Tiere",
                keyColumn: "Id",
                keyValue: new Guid("0500293e-bb8a-4c1d-b1a8-2edddf992f3c"));

            migrationBuilder.DeleteData(
                table: "Tiere",
                keyColumn: "Id",
                keyValue: new Guid("e0597683-c3f2-41e8-95e6-19f052c2bb83"));
        }
    }
}
