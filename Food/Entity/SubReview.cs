using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class SubReview
    {
        public string subReview_Id { get; set; }
        public string subReview_Commnet { get; set; }
        
        public AppUser AppUserSR { get; set; }
        public string subReview_UserId { get; set; }
        public bool subReview_HideStatus { get; set; }
        public string subreview_SubReviewType { get; set; }

        public DateTime subReview_DateCommnet { get; set; }

        public List<SubReviewInReview> SubReviewInReview { get; set; }

        
    }
}
