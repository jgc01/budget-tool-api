using BudgetToolAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetToolAPI.DataLayer.Interfaces
{
    public interface IIncomeRepository
    {
        Task<IncomeDTO[]> GetIncome();
        Task<Boolean> Create(IncomeDTO dto);
        Task<Boolean> Update(IncomeDTO dto);
        Task<Boolean> Delete(int id);
    }
}
