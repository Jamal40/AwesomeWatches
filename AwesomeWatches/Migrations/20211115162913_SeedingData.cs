using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeWatches.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Analog watches have displays with a miniature clock-face with 12 hours, an hour hand, and a minute hand.", "Analog Watch" },
                    { 2, "Digital Watch is a watch in which the hours, minutes, and sometimes seconds are indicated by digits, rather than by hands on a dial.", "Digital Watch" },
                    { 3, "An automatic watch is a watch that continues to operate due to the regular motion of the wearer’s wrist.", "Automatic Watch" },
                    { 4, "“Chronograph” is just a fancy word for “stopwatch.” Using a chronograph is easy. You just press the start/stop button on the side of the watch to start or stop the stopwatch;", "Chronograph Watch" },
                    { 5, "Diving Watch is a watch designed for underwater diving that features, water resistance greater upto 100 m (330 ft).", "Diving Watch" },
                    { 6, "A dress watch is the most elegant of watches. It has one purpose and that’s to tell time. It need not have complications.", "Dress Watch" },
                    { 7, "A quartz watch is powered by an electronic oscillator synchronized by quartz crystal.", "Quartz Watch" },
                    { 8, "A mechanical watch is a watch that uses a mechanism to measure the passage of time, as opposed to modern quartz watches which function electronically.", "Mechanical Watch" },
                    { 9, "Gracing the wrist of pilots, these aviation timepieces have reached the apex of the ideal fusion of style and durability.", "Pilot Watch" },
                    { 10, "Field Watch were designed for officers who needed to coordinate attacks, tell time at night, and sport a wristwatch that could withstand the rigors of battle, all while still looking good. ", "Field Watch" },
                    { 11, "A smartwatch is a portable device that’s designed to be worn on the wrist, just like a traditional watch.", "Smart Watch" },
                    { 12, "These watches are great for watch collectors or watch connoisseurs and the ones who appreciate great precision and handcrafted complications in a watch. Such watches are often encased in precious gemstones and other expensive materials.", "Luxury Watch" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
