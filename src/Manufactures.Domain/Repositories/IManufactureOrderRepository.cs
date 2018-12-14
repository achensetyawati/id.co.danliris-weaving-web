﻿using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Manufactures.Domain;

namespace Manufactures.Domain.Repositories
{
    public interface IManufactureOrderRepository : IRepository
    {
        Task Insert(ManufactureOrder order);

        Task Update(ManufactureOrder order);

        IQueryable<ManufactureOrder> Query { get; }
    }
}
