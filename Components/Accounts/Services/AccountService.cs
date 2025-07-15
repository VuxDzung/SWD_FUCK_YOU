using WebMVC_SWD.Components.Accounts.Models;

namespace WebMVC_SWD.Components.Accounts.Services
{
    public class AccountService
    {
        private readonly AccountDBContext _context;

        public AccountService(AccountDBContext context)
        {
            _context = context;
        }

        public Account? GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(a => a.UserId == id);
        }

        public bool UpdateAccount(int id, Account updated)
        {
            var existing = _context.Accounts.FirstOrDefault(a => a.UserId == id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Email = updated.Email;
            existing.Password = updated.Password;
            existing.Address = updated.Address;
            existing.PhoneNumber = updated.PhoneNumber;
            existing.Age = updated.Age;

            _context.SaveChanges();
            return true;
        }

        public bool TryToggleAccountStatus(int accountId)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.UserId == accountId);
            if (account == null) return false;

            account.IsDisabled = !account.IsDisabled;
            _context.SaveChanges();
            return true;
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

    }
}
