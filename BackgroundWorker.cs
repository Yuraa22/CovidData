using CovidData.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CovidData
{
    public class BackgroundWorker
    {
        private CovidDbContext _covidDbContext;
        public BackgroundWorker(CovidDbContext covidDbContext)
        {
            _covidDbContext = covidDbContext;
        }
        public async void DoWork()
        {
            //_covidDbContext.CasesDaily.RemoveRange(_covidDbContext.CasesDaily);
            //_covidDbContext.CasesTotal.RemoveRange(_covidDbContext.CasesTotal);
            //_covidDbContext.SaveChanges();

            List<CovidCase> covidCases = new List<CovidCase>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync("https://api.covid19api.com/dayone/country/croatia"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        covidCases = JsonConvert.DeserializeObject<List<CovidCase>>(apiResponse);
                    }
                    catch (Exception)
                    {
                        //pokušaj ponovno
                    }
                }
            }

            CaseTotal caseTotalPrevious = null;
            foreach (CovidCase covidCase in covidCases)
            {
                CaseTotal caseTotal = new CaseTotal
                {
                    Confirmed = covidCase.Confirmed,
                    Deaths = covidCase.Deaths,
                    Recovered = covidCase.Recovered,
                    Date = covidCase.Date
                };

                if (_covidDbContext.CasesDaily.Where(c => c.Date == covidCase.Date).FirstOrDefault() != null)
                {
                    caseTotalPrevious = caseTotal;
                    continue; //MJ zapis već postoji
                }
                if (covidCase.Date == DateTime.Today)
                {
                    if (caseTotalPrevious.Confirmed == covidCase.Confirmed && caseTotalPrevious.Deaths == covidCase.Deaths && caseTotalPrevious.Recovered == covidCase.Recovered)
                    {
                        caseTotalPrevious = caseTotal;
                        continue; //MJ postoji greška u ulaznim podacima za zadnje navedeni datum
                    }
                }

                _covidDbContext.CasesTotal.Add(caseTotal);

                if (caseTotalPrevious == null)
                    caseTotalPrevious = caseTotal;

                CaseDaily caseDaily;
                if (caseTotalPrevious != caseTotal)
                {
                    caseDaily = new CaseDaily
                    {
                        Confirmed = caseTotal.Confirmed - caseTotalPrevious.Confirmed,
                        Deaths = caseTotal.Deaths - caseTotalPrevious.Deaths,
                        Recovered = caseTotal.Recovered - caseTotalPrevious.Recovered,
                        Date = covidCase.Date
                    };
                }
                else
                {
                    caseDaily = new CaseDaily
                    {
                        Confirmed = covidCase.Confirmed,
                        Deaths = covidCase.Deaths,
                        Recovered = covidCase.Recovered,
                        Date = covidCase.Date
                    };
                }

                _covidDbContext.CasesDaily.Add(caseDaily);
                _covidDbContext.SaveChanges();

                caseTotalPrevious = caseTotal;
            }
        }
    }
}
