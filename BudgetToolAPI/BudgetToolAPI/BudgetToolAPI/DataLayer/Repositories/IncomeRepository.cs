using BudgetToolAPI.Data;
using BudgetToolAPI.DataLayer.Interfaces;
using BudgetToolAPI.Models.DTO;
using BudgetToolAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetToolAPI.DataLayer.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private ApplicationContext _db;
        public IncomeRepository(ApplicationContext context) { _db = context; }
        public async Task<IncomeDTO[]> GetIncome()
        {
            try
            {
                return await _db.Income.Select(i => new IncomeDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Amount = i.Amount
                }).ToArrayAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Error in IncomeRepository.GetIncome - " + ex.Message);
            }
        }
        public async Task<Boolean> Create(IncomeDTO dto)
        {
            try
            {
                Income income = new Income(dto);               
                _db.Income.Add(income);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in IncomeRepository.Create - " + ex.Message);
            }
        }
        public async Task<Boolean> Update(IncomeDTO dto)
        {
            try
            {
                var income = await _db.Income.FirstOrDefaultAsync(i => i.Id == dto.Id);
                income.Name = dto.Name;
                income.Amount = dto.Amount;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in IncomeRepository.Update - " + ex.Message);
            }
        }
        public async Task<Boolean> Delete(int id)
        {
            try
            {
                var income = await _db.Income.FirstOrDefaultAsync(i => i.Id == id);
                _db.Income.Remove(income);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in IncomeRepository.Delete - " + ex.Message);
            }
        }
    }
}
