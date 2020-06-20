using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PRORegister.DAIF2020.Models.DataModels;
using PRORegister.PRONBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace PRORegister.PROLifeLog.Models.DataModels
{
    
    public class LifeLog
    {
        
        public int Id { get; set; }
        
        [Display(Name ="DateTime")]
        public DateTime? DateTime { get; set; }

        [Display(Name = "Owner")]
        public int? PersonId { get; set; }
        [Display(Name = "Owner")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        //LifeLog Display Image !
        [Display(Name = "Image")]
        public int? ImageId { get; set; }
        
        //LifeLog Status !
        [Display(Name = "Status")]
        public int? LifeLogStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("AssetStatusId")]
        public LifeLogStatus LifeLogStatus { get; set; }

        //Game ?
        [Display(Name = "Game")]
        public int? GameId { get; set; }
        [Display(Name = "Game")]
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        //FoodLogs !

        public List<FoodLog> FoodLogs { get; internal set; }

        //ActivityLogs !

        public List<Activity> Activities { get; internal set; }

        //PhysicalLogs !

        public List<PhysicalLog> PhysicalLogs { get; internal set; }
    }

    public class PhysicalLog
    {

        public int Id { get; set; }


        [Display(Name = "DateTime")]
        public DateTime? DateTime { get; set; }
        

        [Display(Name = "Tested person")]
        public int? PersonId { get; set; }
        [Display(Name = "Tested person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

       
        [Display(Name = "Body weight (Kg)")]
        public double BodyWeight { get; set; }
       
        [Display(Name = "Waist (cm)")]
        public double Waist { get; set; }

        [Display(Name = "Body fat (%)")]
        public double BodyFat { get; set; }
        
    }

    public class Activity
    {
        public int Id { get; set; }
        [Display(Name = "Activity")]
        public string ActivityName { get; set; }

        public int KCal { get; set; }


    }

    public class FoodLog
    {
        public int Id { get; set; }
        [Display(Name = "Food")]
        public string FoodLogName { get; set; }

        public int KCal { get; set; }


    }

    public class LifeLogStatus
    {
        public int Id { get; set; }
        [Display(Name = "Status")]
        public string LifLogStatusName { get; set; }
    }
}

