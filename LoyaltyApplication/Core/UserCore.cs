using LoyaltyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoyaltyApplication.Core
{
    public class UserCore
    {

        private readonly LoyaltyContext context;

        public UserCore (LoyaltyContext context) {
            this.context = context;
        }

        public IEnumerable<User> GetAll() {
            return context.Users.ToList();
        }

        public User GetById(long id) {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Create(User user) {
            user.CreateTime = DateTime.Now;
            user.LastModifiedTime = DateTime.Now;
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User UpdatePoints(long userId, long amount, bool shouldPersist) {
            User user = GetById(userId);
            if (user == null) {
                throw new ArgumentException("User doesn't exist");
            }
            if (amount < 0 && user.Points + amount < 0) {
                throw new ArgumentException("The user doesn't have enough points to complete");
            }
            user.LastModifiedTime = DateTime.Now;
            user.Points += amount;
            if (shouldPersist) {
                context.SaveChanges();
            }
            return user;
        }
    }
}
