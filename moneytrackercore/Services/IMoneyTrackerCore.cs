using moneytrackercore.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneytrackercore.Services
{
    public interface IMoneyTrackerCore
    {
        IQueryable<Incomes> GetAll();
    }
}
