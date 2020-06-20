using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRORegister.PRONBS.Models.DataModels;

namespace PRORegister.Data
{
    public class PRORegisterContext : IdentityDbContext<ApplicationUser>
    {      

        public PRORegisterContext(DbContextOptions<PRORegisterContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// DAIF2020 !
        /// </summary>
        public DbSet<DAIF2020.Models.DataModels.Arena> Arena { get; set; }
        public DbSet<DAIF2020.Models.DataModels.ArenaStatus> ArenaStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Club> Club { get; set; }
        public DbSet<DAIF2020.Models.DataModels.ClubStatus> ClubStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.District> District { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Ref> Ref { get; set; }
        public DbSet<DAIF2020.Models.DataModels.RefRole> RefRole { get; set; }
        public DbSet<DAIF2020.Models.DataModels.RefStatus> RefStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.RefType> RefType { get; set; }
        public DbSet<DAIF2020.Models.DataModels.GameType> GameType { get; set; }
        public DbSet<DAIF2020.Models.DataModels.GameStatus> GameStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.GameCategory> GameCategory { get; set; }        
        public DbSet<DAIF2020.Models.DataModels.Game> Game { get; set; }         
        public DbSet<DAIF2020.Models.DataModels.SeriesStatus> SeriesStatus { get; set; }        
        public DbSet<DAIF2020.Models.DataModels.Series> Series { get; set; }
        DbSet<SportsContacts.Models.SportsContact> SportsContact { get; set; }

        /// <summary>
        /// PRONBS !
        /// </summary>
        /// <param name="builder"></param>
        //Assets !
        public DbSet<PRONBS.Models.DataModels.Asset> Asset { get; set; }
        public DbSet<PRONBS.Models.DataModels.AssetBrand> AssetBrand { get; set; }
        public DbSet<PRONBS.Models.DataModels.AssetStatus> AssetStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.AssetType> AssetType { get; set; }
        //Bills !
        public DbSet<PRONBS.Models.DataModels.Bill> Bill { get; set; }
        public DbSet<PRONBS.Models.DataModels.BillStatus> BillStatus { get; set; }
        //Companies !
        public DbSet<PRONBS.Models.DataModels.Company> Company { get; set; }
        public DbSet<PRONBS.Models.DataModels.CompanyRole> CompanyRole { get; set; }
        public DbSet<PRONBS.Models.DataModels.CompanyStatus> CompanyStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.CompanyType> CompanyType { get; set; }
        //Incidents !
        public DbSet<PRONBS.Models.DataModels.Incident> Incident { get; set; }
        public DbSet<PRONBS.Models.DataModels.IncidentPriority> IncidentPriority { get; set; }
        public DbSet<PRONBS.Models.DataModels.IncidentStatus> IncidentStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.IncidentType> IncidentType { get; set; }
        public DbSet<PRONBS.Models.DataModels.MtrlList> MtrlList { get; set; }       

        //Images !
        public DbSet<ImageModel> Images { get; set; }
        //NABLogs !
        public DbSet<PRONBS.Models.DataModels.NABLog> NABLog { get; set; }
        public DbSet<PRONBS.Models.DataModels.NABLogStatus> NABLogStatus { get; set; }       
        //Offers !
        public DbSet<PRONBS.Models.DataModels.Offer> Offer { get; set; }
        public DbSet<PRONBS.Models.DataModels.OfferStatus> OfferStatus { get; set; }        
        //People !
        public DbSet<PRONBS.Models.DataModels.Person> Person { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonAccounts> PersonAccounts { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonRole> PersonRole { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonStatus> PersonStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.PersonType> PersonType { get; set; }
        //Plans !
        public DbSet<PRONBS.Models.DataModels.Plan> Plan { get; set; }
        public DbSet<PRONBS.Models.DataModels.PlanStatus> PlanStatus { get; set; }        
        public DbSet<PRONBS.Models.DataModels.Stage> Stage { get; set; }
        public DbSet<PRONBS.Models.DataModels.StageStatus> StageStatus { get; set; }
        //Projects !
        public DbSet<PRONBS.Models.DataModels.Project> Project { get; set; }        
        public DbSet<PRONBS.Models.DataModels.ProjectStatus> ProjectStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.ProjectType> ProjectType { get; set; }
        //Reports !
        public DbSet<PRONBS.Models.DataModels.Report> Report { get; set; }
        public DbSet<PRONBS.Models.DataModels.ReportStatus> ReportStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.ReportType> ReportType { get; set; }
        public DbSet<PRONBS.Models.DataModels.ProjectReport> ProjectReport { get; set; }
        //PurchaseOrders!
        public DbSet<PRONBS.Models.DataModels.PurchaseOrder> PurchaseOrder { get; set; }
        //Sites !
        public DbSet<PRONBS.Models.DataModels.Site> Site { get; set; }
        public DbSet<PRONBS.Models.DataModels.SiteRole> SiteRole { get; set; }
        public DbSet<PRONBS.Models.DataModels.SiteStatus> SiteStatus { get; set; }
        public DbSet<PRONBS.Models.DataModels.SiteType> SiteType { get; set; }
        //WLogs !
        public DbSet<PRONBS.Models.DataModels.WLog> WLog { get; set; }
        public DbSet<PRONBS.Models.DataModels.WLogStatus> WLogStatus { get; set; }
        ////
        /// <summary>
        /// //LifeLog
        /// </summary>
        ///  
        public DbSet<PROLifeLog.Models.DataModels.Activity> Activity { get; set; }
        public DbSet<PROLifeLog.Models.DataModels.FoodLog> FoodLog { get; set; }
        public DbSet<PROLifeLog.Models.DataModels.LifeLog> LifeLog { get; set; }
        public DbSet<PROLifeLog.Models.DataModels.LifeLogStatus> LifeLogStatus { get; set; }
        public DbSet<PROLifeLog.Models.DataModels.PhysicalLog> PhysicalLog { get; set; }     





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
