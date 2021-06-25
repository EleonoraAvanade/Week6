using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Esercitazione.Models
{
    class PolizzaRCAuto: Polizza
    {
        public string Targa { get; set; }
        public int Cilindrata { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"- {Targa} - {Cilindrata}";
        }
    }
}
