using Xunit;
using LoyaltyApplication.Models;
using LoyaltyApplication.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoyaltyTest
{
    public class UserCoreTest
    {
        UserCore core;

        public UserCoreTest() {
            LoyaltyContext context = new LoyaltyContext(new DbContextOptionsBuilder<LoyaltyContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options);
            core = new UserCore(context);
        }

        public UserCore SetupUser (int userId, int points) {
            User user = new User();
            user.Id = userId;
            user.Points = points;
            user.Email = "danapeele@gmail.com";
            user.FirstName = "Dana";
            user.LastName = "Peele";
            core.Create(user);
            return core;
        }

        [Fact]
        public void Update_Add_Points_Success_Test() {
            SetupUser(1,1);
            User user = core.UpdatePoints(1, 1, false);
            Assert.Equal(2, user.Points);
        }

        [Fact]
        public void Update_Subtract_Points_Success_Test() {
            UserCore core = SetupUser(2,1);
            User user = core.UpdatePoints(1, -1, false);
            Assert.Equal(0, user.Points);
        }

        [Fact]
        public void Update_Subtract_Points_Fail_Test() {
            UserCore core = SetupUser(3,1);
            Assert.Throws<ArgumentException>(() => core.UpdatePoints(1, -2, false));
        }
    }
}
