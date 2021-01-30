using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidData.Model
{
    public class CaseTotal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
    }
}
