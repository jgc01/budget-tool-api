using BudgetToolAPI.DataLayer.Interfaces;
using BudgetToolAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetToolAPI.Controllers
{
    [ApiController]
    [Route("api/Income")]
    public class IncomeController : ControllerBase
    {
        private IIncomeRepository _repo;
        public IncomeController(IIncomeRepository repo) { _repo = repo; }
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetIncome());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(IncomeDTO dto)
        {
            try
            {
                return Ok(await _repo.Create(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(IncomeDTO dto)
        {
            try
            {
                return Ok(await _repo.Update(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                return Ok(await _repo.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
