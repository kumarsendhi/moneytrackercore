using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using moneytrackercore.data.Entities;
using moneytrackercore.Data;

namespace moneytrackercore.Services
{
    public class SqlMoneyTrackerCore : IMoneyTrackerCore
    {
        private moneytrackercoreDbContext _context;

        public SqlMoneyTrackerCore(moneytrackercoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Incomes> GetAll()
        {
            return _context.Incomes.OrderBy(r => r.UserId);
        }
    }
}
