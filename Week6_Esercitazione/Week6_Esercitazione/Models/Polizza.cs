using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Esercitazione.Models
{
    class Polizza
    {
        public int Numero { get; set; }
        public DateTime DataStipula { get; set; }
        public float ImportoAssicurato { get; set; }
        public float RataMensile { get; set; }
        public String CodiceFiscale { get; set; }
        public Cliente Cliente { get; set; }
        public override string ToString()
        {
            return $"{Numero} - {DataStipula} - {ImportoAssicurato} - {RataMensile} - {CodiceFiscale}";
        }
    }
}
