using PA.Server.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Repositories
{
    public class PayoutTypeRepository : IRepository<PayoutType, int>
    {
        private PaDbContext _db;

        public PayoutTypeRepository(PaDbContext db)
        {
            _db = db;
        }

        public PayoutType Create(PayoutType item)
        {
            var result = _db.PayoutTypes.Add(item);
            _db.SaveChanges();

            return result;
        }

        public PayoutType Delete(PayoutType item)
        {
            var result = _db.PayoutTypes.Remove(item);
            _db.SaveChanges();

            return result;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public PayoutType Get(int id)
        {
            return _db.PayoutTypes
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<PayoutType> GetAll()
        {
            return _db.PayoutTypes.Select(x => x);
        }

        public void Update(PayoutType item)
        {
            _db.Entry(item).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
