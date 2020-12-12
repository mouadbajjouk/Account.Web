using Accounts.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accounts.Web.Repository
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(AccountModel model);
        Task<AccountModel> GetAccountByIdAsync(int id);
        Task<IEnumerable<AccountModel>> GetAccountsAsync();
        Task<int> EditAccountAsync(int id, AccountModel model);
        Task<int> DeleteAccountAsync(int id);
    }
}