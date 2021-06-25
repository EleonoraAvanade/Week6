using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Esercitazione.Models
{
    class PolizzaFurto:Polizza
    {
        public int PercentualeCoperta { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"- {PercentualeCoperta}";
        }
    }
}
