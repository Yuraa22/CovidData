using CovidData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesTotalController : ControllerBase
    {
        private readonly CovidDbContext _covidDbContext;

        public CasesTotalController(CovidDbContext covidDbContext)
        {
            _covidDbContext = covidDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseDaily>>> Get(DateTime? from, DateTime? to, int? min, int? max)
        {
            if (min == null)
                min = 0;
            if (max == null)
                max = int.MaxValue;
            if (from == null)
                from = DateTime.MinValue;
            if (to == null)
                to = DateTime.Today;
            return Ok(await _covidDbContext.CasesTotal.Where(c => c.Confirmed >= min && c.Confirmed <= max && c.Date >= from && c.Date <= to).ToListAsync());
        }
    }
}
