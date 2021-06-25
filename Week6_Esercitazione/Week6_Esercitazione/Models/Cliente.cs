using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Esercitazione.Models
{
    class Cliente
    {
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public ICollection<Polizza> Polizze { get; set; }
        public override string ToString()
        {
            return $"{CodiceFiscale} - {Nome} - {Cognome} - {Indirizzo} \n";
        }
    }
}
