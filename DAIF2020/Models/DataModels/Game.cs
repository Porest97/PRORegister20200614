﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRORegister.DAIF2020.Models.DataModels
{
    public class Game
    {
        public int Id { get; set; }

        //Game DateTime Prop !
        [Display(Name = "Date&Time")]
        [DisplayFormat(DataFormatString = "{0:ddd yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime? GameDateTime { get; set; }

        // Game Identification Prop!
        [Display(Name = "Game #")]
        public string GameNumber { get; set; }

        // Game TSM Idenfication Prop !
        [Display(Name = "TSM #")]
        public string TSMNumber { get; set; }

        // Game settings props !
        [Display(Name = "Category")]
        public int? GameCategoryId { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("GameCategoryId")]
        public GameCategory GameCategory { get; set; }

        [Display(Name = "Status")]
        public int? GameStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("GameStatusId")]
        public GameStatus GameStatus { get; set; }

        [Display(Name = "Game Type")]
        public int? GameTypeId { get; set; }
        [Display(Name = "GameType")]
        [ForeignKey("GameTypeId")]
        public GameType GameType { get; set; }

        [Display(Name = "Series")]
        public int? SeriesId { get; set; }
        [Display(Name = "Series")]
        [ForeignKey("SeriesId")]
        public Series Series { get; set; }

        // Game location prop !
        [Display(Name = "Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        // Game Teams Props !
        [Display(Name = "Home")]
        public int? ClubId { get; set; }
        [Display(Name = "Home")]
        [ForeignKey("ClubId")]
        public Club HomeTeam { get; set; }

        [Display(Name = "Away")]
        public int? ClubId1 { get; set; }
        [Display(Name = "Away")]
        [ForeignKey("ClubId1")]
        public Club AwayTeam { get; set; }

        // Game Result Props !
        [Display(Name = "Score Home Team")]
        public int? HomeTeamScore { get; set; }

        [Display(Name = "Score Away Team")]
        public int? AwayTeamScore { get; set; }

        [Display(Name = "Score")]
        public string Result { get { return string.Format("{0} {1} {2}", HomeTeamScore, "-", AwayTeamScore); } }

        // Game Ref props !
        [Display(Name = "HD")]
        public int? RefId { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("RefId")]
        public Ref HD1 { get; set; }

        [Display(Name = "HD")]
        public int? RefId1 { get; set; }
        [Display(Name = "HD")]
        [ForeignKey("RefId1")]
        public Ref HD2 { get; set; }

        [Display(Name = "LD")]
        public int? RefId2 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("RefId2")]
        public Ref LD1 { get; set; }

        [Display(Name = "LD")]
        public int? RefId3 { get; set; }
        [Display(Name = "LD")]
        [ForeignKey("RefId3")]
        public Ref LD2 { get; set; }
    }

    public class GameType
    {
        public int Id { get; set; }

        
        [Display(Name = "Game Type")]
        public string GameTypeName { get; set; }
    }

    public class GameStatus
    {
        public int Id { get; set; }

        
        [Display(Name = "Status")]
        public string GameStatusName { get; set; }
    }

    public class GameCategory
    {
        public int Id { get; set; }

        // Game Identification Prop!
        [Display(Name = "Category")]
        public string GameCategoryName { get; set; }
    }
}
