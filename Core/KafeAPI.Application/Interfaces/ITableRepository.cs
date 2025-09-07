using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAPI.Domain.Entities;

namespace KafeAPI.Application.Interfaces
{
    public interface ITableRepository
    {
        Task<Table> GetByTableNumberAsync(int tableNumber);
        Task<List<Table>> GetAllActiveTablesAsync();
    }
}
