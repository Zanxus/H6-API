using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Entites
{
    public class TrackedMedia
    {
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public TrackedState TrackedState { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public enum TrackedState
    {
        PlanToWatch,
        Watching,
        Completed,
        OnHold,
        Dropped
    }
}



