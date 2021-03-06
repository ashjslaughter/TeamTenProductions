//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace miVacationSurfer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class LocationReview
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public int LocationRating { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime LocationDate { get; set; }

        [Required]
        [Display(Name = "Pros")]
        public string LocationPro { get; set; }

        [Required]
        [Display(Name = "Cons")]
        public string LocationCon { get; set; }

        [Display(Name = "Details")]
        public string LocationReviewDetails { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }
    
        public virtual Location Location { get; set; }
    }
}
