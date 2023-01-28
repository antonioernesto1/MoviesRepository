using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Domain
{
    public class Temporada
    {
        public int Id { get; set; }
        public Serie Serie { get; set; }
        public int SerieId { get; set; }
        public List<Episodio> Episodios{ get; set; }
    }
}
