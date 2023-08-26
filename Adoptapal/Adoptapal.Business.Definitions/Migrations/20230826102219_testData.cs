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
