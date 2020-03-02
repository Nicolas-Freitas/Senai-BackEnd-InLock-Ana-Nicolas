using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Domain
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        public string NomeJogo { get; set; }

        public string Descricao { get; set; }

        public float Preco { get; set; }

        public DateTime DataLanc { get; set; }

        public EstudioDomain Estudio { get; set; }
    }
}

