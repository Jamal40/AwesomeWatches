using AwesomeWatches.Models;
using Microsoft.EntityFrameworkCore;
namespace AwesomeWatches.Data;

public class WatchesContext : DbContext
{
    public WatchesContext(DbContextOptions<WatchesContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new List<Category>{
                new Category {
                    Id = 1,
                    Name = "Analog Watch",
                    Description = "Analog watches have displays with a miniature clock-face with 12 hours, an hour hand, and a minute hand."
                },
                new Category {
                    Id = 2,
                    Name = "Digital Watch",
                    Description = "Digital Watch is a watch in which the hours, minutes, and sometimes seconds are indicated by digits, rather than by hands on a dial."
                },
                new Category {
                    Id = 3,
                    Name = "Automatic Watch",
                    Description = "An automatic watch is a watch that continues to operate due to the regular motion of the wearer’s wrist."
                },
                new Category {
                    Id = 4,
                    Name = "Chronograph Watch",
                    Description = "“Chronograph” is just a fancy word for “stopwatch.” Using a chronograph is easy. You just press the start/stop button on the side of the watch to start or stop the stopwatch;"
                },
                new Category {
                    Id = 5,
                    Name = "Diving Watch",
                    Description = "Diving Watch is a watch designed for underwater diving that features, water resistance greater upto 100 m (330 ft)."
                },
                new Category {
                    Id = 6,
                    Name = "Dress Watch",
                    Description = "A dress watch is the most elegant of watches. It has one purpose and that’s to tell time. It need not have complications."
                },
                new Category {
                    Id = 7,
                    Name = "Quartz Watch",
                    Description = "A quartz watch is powered by an electronic oscillator synchronized by quartz crystal."
                },
                new Category {
                    Id = 8,
                    Name = "Mechanical Watch",
                    Description = "A mechanical watch is a watch that uses a mechanism to measure the passage of time, as opposed to modern quartz watches which function electronically."
                },
                new Category {
                    Id = 9,
                    Name = "Pilot Watch",
                    Description = "Gracing the wrist of pilots, these aviation timepieces have reached the apex of the ideal fusion of style and durability."
                },
                new Category {
                    Id = 10,
                    Name = "Field Watch",
                    Description = "Field Watch were designed for officers who needed to coordinate attacks, tell time at night, and sport a wristwatch that could withstand the rigors of battle, all while still looking good. "
                },
                new Category {
                    Id = 11,
                    Name = "Smart Watch",
                    Description = "A smartwatch is a portable device that’s designed to be worn on the wrist, just like a traditional watch."
                },
                new Category {
                    Id = 12,
                    Name = "Luxury Watch",
                    Description = "These watches are great for watch collectors or watch connoisseurs and the ones who appreciate great precision and handcrafted complications in a watch. Such watches are often encased in precious gemstones and other expensive materials."
                },
        });
    }
}

