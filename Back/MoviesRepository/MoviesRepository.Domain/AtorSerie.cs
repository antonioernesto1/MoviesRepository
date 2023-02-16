using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Domain
{
    public class AtorSerie
    {
        public int AtorId { get; set; }
        public Ator Ator { get; set; }
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}
