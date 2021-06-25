using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Esercitazione.Models
{
    class PolizzaVita:Polizza
    {
        public int AnniAssicurato { get; set; } // quanti anni ha il cliente
        public override string ToString()
        {
            return base.ToString() + $"- {AnniAssicurato}";
        }
    }
}
