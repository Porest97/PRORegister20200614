﻿using PRORegister.PRONBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRORegister.PRONBS.Models.ViewModels
{
    public class DataViewModel
    {
        //DATA Entities ! 

        public List<Company> Companies { get; internal set; }

        public List<Incident> Incidents { get; internal set; }

        public List<NABLog> NABLogs { get; internal set; }

        public List<Person> People { get; internal set; }

        public List<Project> Projects { get; internal set; }

        public List<PurchaseOrder> PurchaseOrders { get; internal set; }

        public List<Offer> Quotations { get; internal set; }

        public List<Site> Sites { get; internal set; }

        public List<DataModels.WLog> WLogs { get; internal set; }

        public List<MtrlList> MtrlLists { get; internal set; }

        public List<Bill> Bills { get; internal set; }

        public List<Asset> Assets { get; internal set; }

        public List<Plan> Plans { get; internal set; }

        public List<Stage> Stages { get; internal set; }
    }
}
