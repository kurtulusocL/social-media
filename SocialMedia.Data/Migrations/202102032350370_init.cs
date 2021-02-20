namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        StartingDate = c.DateTime(nullable: false),
                        FinishingDate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        Hit = c.Int(),
                        ActivityKindId = c.Int(nullable: false),
                        MemberId = c.Int(),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityKinds", t => t.ActivityKindId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.ActivityKindId)
                .Index(t => t.MemberId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.ActivityKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        Photo = c.String(),
                        Hit = c.Int(),
                        GroupKindId = c.Int(nullable: false),
                        MemberId = c.Int(),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.GroupKinds", t => t.GroupKindId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.GroupKindId)
                .Index(t => t.MemberId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.GroupKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Joins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsBlocked = c.Boolean(nullable: false),
                        IsJoined = c.Boolean(nullable: false),
                        ActivityId = c.Int(),
                        GroupId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.ActivityId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortDesc = c.String(),
                        BioInfo = c.String(),
                        ProfilePhoto = c.String(),
                        Hit = c.Int(),
                        UserId = c.String(),
                        GenderId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        ProfileSettingId = c.Int(),
                        FriendRequestId = c.Int(),
                        JoinId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                        FriendRequest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.FriendRequests", t => t.FriendRequest_Id)
                .ForeignKey("dbo.FriendRequests", t => t.FriendRequestId)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Joins", t => t.JoinId)
                .ForeignKey("dbo.ProfileSettings", t => t.ProfileSettingId)
                .Index(t => t.GenderId)
                .Index(t => t.CityId)
                .Index(t => t.CountryId)
                .Index(t => t.ProfileSettingId)
                .Index(t => t.FriendRequestId)
                .Index(t => t.JoinId)
                .Index(t => t.FriendRequest_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Hit = c.Int(),
                        Like = c.Int(),
                        Dislike = c.Int(),
                        AskSomethingId = c.Int(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AskSometings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Hit = c.Int(),
                        Like = c.Int(),
                        Dislike = c.Int(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Photo = c.String(),
                        Hit = c.Int(),
                        Like = c.Int(),
                        Dislike = c.Int(),
                        PostSharedId = c.Int(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.PostShareds", t => t.PostSharedId)
                .Index(t => t.PostSharedId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.PostShareds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Subtitle = c.String(),
                        Desc = c.String(),
                        Url = c.String(),
                        Hit = c.Int(),
                        Like = c.Int(),
                        Dislike = c.Int(),
                        UserId = c.String(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        UserId = c.String(),
                        PostSharedId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostShareds", t => t.PostSharedId)
                .Index(t => t.PostSharedId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Problem = c.String(),
                        MemberId = c.Int(),
                        PostSharedId = c.Int(),
                        CommentId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.PostShareds", t => t.PostSharedId)
                .Index(t => t.MemberId)
                .Index(t => t.PostSharedId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.CuriousAbouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Departman = c.String(),
                        Univerity = c.String(),
                        StartingDate = c.DateTime(nullable: false),
                        FinishingDate = c.DateTime(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Fobies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAccepted = c.Boolean(nullable: false),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.MemberId)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        FriendRequestId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FriendRequests", t => t.FriendRequestId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.FriendRequestId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hobies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.ImportantEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MessageForUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Hit = c.Int(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.OldTrips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FromWhere = c.String(),
                        ToWhere = c.String(),
                        TripDate = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Pleasings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.ProfileSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSecret = c.Boolean(nullable: false),
                        IsSentFreiendship = c.Boolean(nullable: false),
                        IsTakeFriendship = c.Boolean(nullable: false),
                        IsTakeComment = c.Boolean(nullable: false),
                        IsTakeLike = c.Boolean(nullable: false),
                        IsTakeDislike = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FromWhere = c.String(),
                        ToWhere = c.String(),
                        PlanDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        CompanyName = c.String(),
                        StartingDate = c.DateTime(nullable: false),
                        FinishingDate = c.DateTime(),
                        MemberId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CompanyName = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        Hit = c.Int(),
                        Photo = c.String(nullable: false),
                        DeletedTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CancelRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Detail = c.String(nullable: false),
                        When = c.DateTime(nullable: false),
                        UserId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SendMails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(nullable: false),
                        Reciever = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Desc = c.String(nullable: false),
                        NameSurname = c.String(nullable: false),
                        TillWhen = c.DateTime(nullable: false),
                        IsFinished = c.Boolean(nullable: false),
                        UserId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        IPAddress = c.String(),
                        AreaAccessed = c.String(),
                        Date = c.DateTime(nullable: false),
                        Browser = c.String(),
                        Device = c.String(),
                        Language = c.String(),
                        BrowserVersion = c.String(),
                        IsMobile = c.Boolean(nullable: false),
                        DeviceModel = c.String(),
                        Platform = c.String(),
                        MacAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NameLastname = c.String(),
                        Gender = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Province = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        RespondTitle = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VideoAds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CompanyName = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        VideoLink = c.String(nullable: false),
                        Hit = c.Int(),
                        DeletedTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AskSometingAnswers",
                c => new
                    {
                        AskSometing_Id = c.Int(nullable: false),
                        Answer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AskSometing_Id, t.Answer_Id })
                .ForeignKey("dbo.AskSometings", t => t.AskSometing_Id, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: true)
                .Index(t => t.AskSometing_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.AnswerMembers",
                c => new
                    {
                        Answer_Id = c.Int(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Answer_Id, t.Member_Id })
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Answer_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Works", "MemberId", "dbo.Members");
            DropForeignKey("dbo.TripPlans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "ProfileSettingId", "dbo.ProfileSettings");
            DropForeignKey("dbo.Pleasings", "MemberId", "dbo.Members");
            DropForeignKey("dbo.OldTrips", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MessageForUsers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "JoinId", "dbo.Joins");
            DropForeignKey("dbo.ImportantEvents", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Hobies", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Groups", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.FriendRequests", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "FriendRequestId", "dbo.FriendRequests");
            DropForeignKey("dbo.Members", "FriendRequest_Id", "dbo.FriendRequests");
            DropForeignKey("dbo.FriendRequests", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Friends", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Friends", "FriendRequestId", "dbo.FriendRequests");
            DropForeignKey("dbo.Fobies", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Educations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.CuriousAbouts", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Contacts", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Reports", "PostSharedId", "dbo.PostShareds");
            DropForeignKey("dbo.Reports", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Reports", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Photos", "PostSharedId", "dbo.PostShareds");
            DropForeignKey("dbo.PostShareds", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Comments", "PostSharedId", "dbo.PostShareds");
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AnswerMembers", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.AnswerMembers", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.AskSometings", "MemberId", "dbo.Members");
            DropForeignKey("dbo.AskSometingAnswers", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.AskSometingAnswers", "AskSometing_Id", "dbo.AskSometings");
            DropForeignKey("dbo.Activities", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Joins", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Joins", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Groups", "GroupKindId", "dbo.GroupKinds");
            DropForeignKey("dbo.Groups", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Groups", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Activities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Activities", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Activities", "ActivityKindId", "dbo.ActivityKinds");
            DropIndex("dbo.AnswerMembers", new[] { "Member_Id" });
            DropIndex("dbo.AnswerMembers", new[] { "Answer_Id" });
            DropIndex("dbo.AskSometingAnswers", new[] { "Answer_Id" });
            DropIndex("dbo.AskSometingAnswers", new[] { "AskSometing_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Works", new[] { "MemberId" });
            DropIndex("dbo.TripPlans", new[] { "MemberId" });
            DropIndex("dbo.Pleasings", new[] { "MemberId" });
            DropIndex("dbo.OldTrips", new[] { "MemberId" });
            DropIndex("dbo.MessageForUsers", new[] { "MemberId" });
            DropIndex("dbo.ImportantEvents", new[] { "MemberId" });
            DropIndex("dbo.Hobies", new[] { "MemberId" });
            DropIndex("dbo.Friends", new[] { "FriendRequestId" });
            DropIndex("dbo.Friends", new[] { "MemberId" });
            DropIndex("dbo.FriendRequests", new[] { "Member_Id" });
            DropIndex("dbo.FriendRequests", new[] { "MemberId" });
            DropIndex("dbo.Fobies", new[] { "MemberId" });
            DropIndex("dbo.Educations", new[] { "MemberId" });
            DropIndex("dbo.CuriousAbouts", new[] { "MemberId" });
            DropIndex("dbo.Contacts", new[] { "MemberId" });
            DropIndex("dbo.Reports", new[] { "CommentId" });
            DropIndex("dbo.Reports", new[] { "PostSharedId" });
            DropIndex("dbo.Reports", new[] { "MemberId" });
            DropIndex("dbo.Photos", new[] { "PostSharedId" });
            DropIndex("dbo.PostShareds", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "MemberId" });
            DropIndex("dbo.Comments", new[] { "PostSharedId" });
            DropIndex("dbo.AskSometings", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "FriendRequest_Id" });
            DropIndex("dbo.Members", new[] { "JoinId" });
            DropIndex("dbo.Members", new[] { "FriendRequestId" });
            DropIndex("dbo.Members", new[] { "ProfileSettingId" });
            DropIndex("dbo.Members", new[] { "CountryId" });
            DropIndex("dbo.Members", new[] { "CityId" });
            DropIndex("dbo.Members", new[] { "GenderId" });
            DropIndex("dbo.Joins", new[] { "GroupId" });
            DropIndex("dbo.Joins", new[] { "ActivityId" });
            DropIndex("dbo.Groups", new[] { "CountryId" });
            DropIndex("dbo.Groups", new[] { "CityId" });
            DropIndex("dbo.Groups", new[] { "MemberId" });
            DropIndex("dbo.Groups", new[] { "GroupKindId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Activities", new[] { "CountryId" });
            DropIndex("dbo.Activities", new[] { "CityId" });
            DropIndex("dbo.Activities", new[] { "MemberId" });
            DropIndex("dbo.Activities", new[] { "ActivityKindId" });
            DropTable("dbo.AnswerMembers");
            DropTable("dbo.AskSometingAnswers");
            DropTable("dbo.VideoAds");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserLogs");
            DropTable("dbo.ToMakes");
            DropTable("dbo.SendMails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CancelRequests");
            DropTable("dbo.Ads");
            DropTable("dbo.Works");
            DropTable("dbo.TripPlans");
            DropTable("dbo.ProfileSettings");
            DropTable("dbo.Pleasings");
            DropTable("dbo.OldTrips");
            DropTable("dbo.MessageForUsers");
            DropTable("dbo.ImportantEvents");
            DropTable("dbo.Hobies");
            DropTable("dbo.Genders");
            DropTable("dbo.Friends");
            DropTable("dbo.FriendRequests");
            DropTable("dbo.Fobies");
            DropTable("dbo.Educations");
            DropTable("dbo.CuriousAbouts");
            DropTable("dbo.Contacts");
            DropTable("dbo.Reports");
            DropTable("dbo.Photos");
            DropTable("dbo.PostShareds");
            DropTable("dbo.Comments");
            DropTable("dbo.AskSometings");
            DropTable("dbo.Answers");
            DropTable("dbo.Members");
            DropTable("dbo.Joins");
            DropTable("dbo.GroupKinds");
            DropTable("dbo.Groups");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.ActivityKinds");
            DropTable("dbo.Activities");
        }
    }
}
