using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class ReviewModel
    {
        //Table product
        public string review_ProductId { set; get; }
        public string review_ProductName { set; get; }
        public string review_ProductIMG1 { set; get; }
        public string review_ProductDecription { set; get; }
        public int review_ProductPrice { set; get; }
        public int review_ProductRate { set; get; }


        //Table review
        public string review_id { set; get; }
        public string review_Comment { set; get; }
        public string review_UserId { set; get; }
        
        public string review_UserName { set; get; }
        public DateTime review_UploadTime { set; get; }
        public bool review_HideStatus{ set; get; }
        public List<SubreviewModel> review_SubreviewModelList { set; get; }


        

        //Option
        public int review_CountReview { set; get; }
        public int review_CountSubReview { set; get; }

        public string review_ReviewType { set; get; }
        
    }
}
