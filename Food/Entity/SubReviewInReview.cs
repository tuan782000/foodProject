using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class SubReviewInReview
    {
        public Reviews Reviews { get; set; }

        public string SRiR_ReviewId { get; set; }
        public SubReview SubReview { get; set; }

        public string SRiR_SubReviewId { get; set; }
    }
}
