using LoyaltyApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoyaltyApplication.Core
{
    public class TransferCore
    {
        LoyaltyContext context;
        UserCore userCore;

        public TransferCore(LoyaltyContext context, UserCore userCore) {
            this.context = context;
            this.userCore = userCore;
        }

        public IEnumerable<Transfer> GetAll(string userId) {
            long userIdLong;
            if (userId != null && long.TryParse(userId, out userIdLong)) {
                return context.Transfers.Where(t => t.UserId == userIdLong);
            }
            return context.Transfers.ToList();
        }

        public Transfer GetById(long id) {
            var transfer = context.Transfers.FirstOrDefault(t => t.Id == id);
            if (transfer == null) {
                throw new ArgumentException("Transfer not found");
            }
            return transfer;
        }

        public Transfer Create(Transfer transfer) {
            try {
                userCore.UpdatePoints(transfer.UserId, transfer.Amount, false);
                transfer.CreateTime = DateTime.Now;
                context.Transfers.Add(transfer);
                context.SaveChanges();
                return transfer;
            } catch (DbUpdateConcurrencyException _) {
                return Create(transfer);
            }
}
    }
}
