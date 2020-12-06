using BudgetToolAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetToolAPI.Models.Entities
{
    public class Income
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Income() { }
        public Income(IncomeDTO dto)
        {
            Name = dto.Name;
            Amount = dto.Amount;
        }
    }
}
