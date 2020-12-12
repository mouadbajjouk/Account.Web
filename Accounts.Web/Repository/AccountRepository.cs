using Accounts.Web.Data;
using Accounts.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Accounts.Web.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountsDbContext _context;

        public AccountRepository(AccountsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountModel>> GetAccountsAsync()
        {
            var accountsList = await _context.Accounts.Select(x => new AccountModel()
            {
                Id = x.Id,
                AccountNumber = x.AccountNumber,
                AccountHolder = x.AccountHolder,
                CurrentBalance = x.CurrentBalance,
                BankName = x.BankName,
                OpeningDate = x.OpeningDate,
                IsActive = x.IsActive
            }).ToListAsync();

            return accountsList;
        }

        public async Task<AccountModel> GetAccountByIdAsync(int id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id); 
            return account;
        }

        public async Task CreateAccountAsync(AccountModel model)
        {
            await _context.Accounts.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditAccountAsync(int id, AccountModel model)
        {
            var account = await _context.Set<AccountModel>().SingleOrDefaultAsync(x => x.Id == id);
            account.AccountNumber = model.AccountNumber;
            account.AccountHolder = model.AccountHolder;
            account.CurrentBalance = model.CurrentBalance;
            account.BankName = model.BankName;
            account.OpeningDate = model.OpeningDate;
            account.IsActive = model.IsActive;

            return await _context.SaveChangesAsync(); // return >0 if the modification is successful
        }

        public async Task<int> DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(account);

            return await _context.SaveChangesAsync(); // return >0 if the detetion is successful
        }
    }
}
