using PA.Server.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db.Repositories
{
    public class PositionRepository : IRepository<Position, int>
    {
        private PaDbContext _db;

        public PositionRepository(PaDbContext db)
        {
            _db = db;
        }

        public Position Create(Position item)
        {
            var result = _db.Positions.Add(item);
            _db.SaveChanges();

            return result;
        }

        public Position Delete(Position item)
        {
            var result = _db.Positions.Remove(item);
            _db.SaveChanges();

            return result;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Position Get(int id)
        {
            return _db.Positions
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Position> GetAll()
        {
            return _db.Positions.Select(x => x);
        }

        public void Update(Position item)
        {
            _db.Entry(item).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
