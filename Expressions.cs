using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Calculator.Model
{
  [Table("Expressions")]
    public class Expressions
    {
       [MaxLength(250)]
        public string Expression { get; set; }
       
       
    }
}
