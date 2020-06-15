using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PRORegister.Areas.Identity.Data;

namespace PRORegister.Data
{
    public class PRORegisterContext : IdentityDbContext<ApplicationUser>
    {      

        public PRORegisterContext(DbContextOptions<PRORegisterContext> options)
            : base(options)
        {
        }

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
        //public DbSet<DAIF2020.Models.DataModels.ReceiptCategory> ReceiptCategory { get; set; }
        //public DbSet<DAIF2020.Models.SettingModels.ReceiptStatus> ReceiptStatus { get; set; }
        //public DbSet<DAIF2020.Models.SettingModels.ReceiptType> ReceiptType { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Game> Game { get; set; }
        //public DbSet<DAIF2020.Models.SettingModels.Zone> Zone { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.ZoneGame> ZoneGame { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.PoolGame> PoolGame { get; set; }
        public DbSet<DAIF2020.Models.DataModels.SeriesStatus> SeriesStatus { get; set; }
        //public DbSet<DAIF2020.Models.SettingModels.TeamStatus> TeamStatus { get; set; }
        public DbSet<DAIF2020.Models.DataModels.Series> Series { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.Team> Team { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.TeamRoster> TeamRoster { get; set; }
        //public DbSet<DAIF2020.TheLab.Models.DataModels.Receipt> Receipt { get; set; }
        //public DbSet<DAIF2020.TheLab.Models.DataModels.PoolGameReceipt> PoolGameReceipt { get; set; }
        //public DbSet<DAIF2020.TheLab.Models.DataModels.ZoneGameReceipt> ZoneGameReceipt { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.Tornament> Tornament { get; set; }
        //public DbSet<DAIF2020.Models.SettingModels.TournamentType> TournamentType { get; set; }
        //public DbSet<DAIF2020.TheLab.Models.DataModels.WeeklyReceipt> WeeklyReciept { get; set; }
        //public DbSet<DAIF2020.TSM.Models.DataModels.TSMGameStatus> TSMGameStatus { get; set; }
        //public DbSet<DAIF2020.TSM.Models.DataModels.TSMGame> TSMGame { get; set; }
        //public DbSet<DAIF2020.Models.SettingModels.ActivityStatus> ActivityStatus { get; set; }
        //public DbSet<DAIF2020.Planner.Models.DataModels.Activity> Activity { get; set; }
        //public DbSet<DAIF2020.Planner.Models.DataModels.Meeting> Meeting { get; set; }
        //public DbSet<DAIF2020.Planner.Models.DataModels.Location> Location { get; set; }
        //public DbSet<DAIF2020.TSM.Models.DataModels.Game20192020> Game20192020 { get; set; }
        //public DbSet<DAIF2020.CleverServiceIX.DataModels.PZGame> PZGame { get; set; }
        //public DbSet<DAIF2020.CleverServiceIX.DataModels.PZGameReceipt> PZGameReceipt { get; set; }
        //public DbSet<DAIF2020.CleverServiceIX.DataModels.RefFees> RefFees { get; set; }
        //public DbSet<DAIF2020.CleverServiceIX.DataModels.CSMatch> CSMatch { get; set; }
        //public DbSet<DAIF2020.SRHLStats2020.Models.DataModels.Match> Match { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.ArchivedGame> ArchivedGame { get; set; }
        //public DbSet<DAIF2020.Models.DataModels.Hockey4LifeLog> Hockey4LifeLog { get; set; }
        //public DbSet<DAIF2020.SportsLogs.Models.DataModels.Sport> Sport { get; set; }
        //public DbSet<DAIF2020.SportsLogs.Models.DataModels.SportsLog> SportsLog { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
