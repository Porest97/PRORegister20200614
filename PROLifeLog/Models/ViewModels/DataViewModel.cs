using Microsoft.AspNetCore.Identity;
using PRORegister.PROLifeLog.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRORegister.PORLifeLog.Models.ViewModels
{
    public class DataViewModel
    {
        public List<Activity> Activities { get; internal set; }

        public List<FoodLog> FoodLogs { get; internal set; }

        public List<LifeLog> LifeLogs { get; internal set; }

        public List<LifeLogStatus> LifeLogStatuses { get; internal set; }

        public List<PhysicalLog> PhysicalLogs { get; internal set; }

       


    }
}
