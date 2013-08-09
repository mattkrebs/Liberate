using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Liberate.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }        
        public bool? HD { get; set; }
        public string ImdbUrl { get; set; }
        public string PosterUrl { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
