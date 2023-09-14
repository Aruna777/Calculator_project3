using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    [Table("Expressions")]
   
    public class HistoryCalculations
    {
        [MaxLength(250)]
        public string Calculation { get; set; }
    }
}
