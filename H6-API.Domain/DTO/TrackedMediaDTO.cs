using H6_API.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.DTO
{
    public class TrackedMediaDTO
    {
            public int Id { get; set; }
            public string ImdbId { get; set; }
            public TrackedState TrackedState { get; set; }
            public string UserId { get; set; }
    }
}
