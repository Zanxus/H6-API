using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.DTO
{
    public class OMDBSearchMedia
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string ImdbID { get; set; }

        public string Type { get; set; }

        public string Poster { get; set; }
    }
}
