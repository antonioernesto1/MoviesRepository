using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Domain
{
    public class AtorFilme
    {
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public int AtorId { get; set; }
        public Ator Ator { get; set; }
    }
}
