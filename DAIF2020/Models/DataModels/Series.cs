using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRORegister.DAIF2020.Models.DataModels
{
    public class Series
    {
        public int Id { get; set; }


        [Display(Name = "Series")]
        public string SeriesName { get; set; }

        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Display(Name = "District")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        [Display(Name = "Status")]
        public int? SeriesStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("SeriesStatusId")]
        public SeriesStatus SeriesStatus { get; set; }

        
    }

    public class SeriesStatus
    {

        public int Id { get; set; }


        [Display(Name = "Status")]
        public string SeriesStatusName { get; set; }
    }
}
