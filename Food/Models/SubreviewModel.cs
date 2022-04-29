using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class SubreviewModel
    {
        //Table Sub Review
        public string subReview_ReviewId { set; get; }
        public string subReview_Subid { set; get; }
        public string subReview_SubComment { set; get; }
        public string subReview_SubUserId { set; get; }
        public DateTime subReview_SubUploadTime { set; get; }

        public string subReview_UserName { set; get; }
        public bool subReview_HideStatus { set; get; }
        public string subReview_SubReviewType { set; get; }
    }
}
