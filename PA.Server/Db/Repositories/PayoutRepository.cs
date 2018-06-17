using PA.Server.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Repositories
{
    public class PayoutRepository : IRepository<Payout, int>
    {
        private PaDbContext _db;

        public PayoutRepository(PaDbContext db)
        {
            _db = db;
        }

        public Payout Create(Payout item)
        {
            var result = _db.Payouts.Add(item);
            _db.SaveChanges();

            return result;
        }

        public Payout Delete(Payout item)
        {
            var result = _db.Payouts.Remove(item);
            _db.SaveChanges();

            return result;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Payout Get(int id)
        {
            return _db.Payouts
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Payout> GetAll()
        {
            return _db.Payouts.Select(x => x);
        }

        public void Update(Payout item)
        {
            _db.Entry(item).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
