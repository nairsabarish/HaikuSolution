using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.Models
{
    //View model for Haiku
    public class ReviewHaikuViewModel
    {
        public HaikuModel HaikuText { get; set; }

        public List<HaikuModel> l_HaikusReviewed { get; set; }

        public bool IsSecondTabSelected { get; set; }
    }
}