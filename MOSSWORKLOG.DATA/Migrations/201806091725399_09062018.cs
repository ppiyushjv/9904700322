namespace MOSSWORKLOG.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09062018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CCTVLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogDate = c.DateTime(nullable: false),
                        CCTVNo = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeManagementAttachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChangeManagementId = c.Int(nullable: false),
                        AttachmentPath = c.String(),
                        OriginalName = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeManagementDetail", t => t.ChangeManagementId, cascadeDelete: false)
                .ForeignKey("dbo.tblUsers", t => t.CreatedBy, cascadeDelete: false)
                .Index(t => t.ChangeManagementId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.ChangeManagementDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ClientId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ChangeTypeId = c.Int(nullable: false),
                        ChangeSubTypeId = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        DueDate = c.DateTime(),
                        AssignTo = c.Int(),
                        Description = c.String(),
                        StepToReproduce = c.String(),
                        CloseDate = c.DateTime(),
                        CreateDate = c.DateTime(),
                        ResolveDate = c.DateTime(),
                        CloseBy = c.Int(),
                        CreateBy = c.Int(),
                        ResolveBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.AssignTo)
                .ForeignKey("dbo.ChangeManagementSubType", t => t.ChangeSubTypeId, cascadeDelete: false)
                .ForeignKey("dbo.ChangeManagementType", t => t.ChangeTypeId, cascadeDelete: false)
                .ForeignKey("dbo.tblClient", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.CloseBy)
                .ForeignKey("dbo.tblUsers", t => t.CreateBy)
                .ForeignKey("dbo.tblProject", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.ResolveBy)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectId)
                .Index(t => t.ChangeTypeId)
                .Index(t => t.ChangeSubTypeId)
                .Index(t => t.AssignTo)
                .Index(t => t.CloseBy)
                .Index(t => t.CreateBy)
                .Index(t => t.ResolveBy);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(maxLength: 100),
                        Mobile = c.String(maxLength: 20),
                        email = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        SupervisorId = c.Int(),
                        ManagerId = c.Int(),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.tblRole", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tblRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.ChangeManagementSubType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeManagementType", t => t.TypeId, cascadeDelete: false)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.ChangeManagementType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblClient",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ShortName = c.String(maxLength: 10),
                        ClientName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 1000),
                        Contact = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.ChangeManagementComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChangeManagementId = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeManagementDetail", t => t.ChangeManagementId, cascadeDelete: false)
                .ForeignKey("dbo.tblUsers", t => t.CreatedBy, cascadeDelete: true)
                .Index(t => t.ChangeManagementId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.tblProject",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.tblClient", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ComplianceCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComplianceCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Compliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplianceDate = c.DateTime(nullable: false),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        Descriptions = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComplianceCategories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.ComplianceCategories", t => t.SubCategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.ComplianceTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActoinDatetime = c.DateTime(nullable: false),
                        ComplianceId = c.Int(nullable: false),
                        Remarks = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compliances", t => t.ComplianceId, cascadeDelete: true)
                .Index(t => t.ComplianceId);
            
            CreateTable(
                "dbo.PasswordResetRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.String(),
                        UserId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 1, fixedLength: true),
                        CatId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.CatId)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.tblContracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        VenderId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Asset = c.String(),
                        Remarks = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.tblVenders", t => t.VenderId, cascadeDelete: true)
                .Index(t => t.VenderId);
            
            CreateTable(
                "dbo.tblVenders",
                c => new
                    {
                        VenderId = c.Int(nullable: false, identity: true),
                        VenderShortName = c.String(),
                        VenderName = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.VenderId);
            
            CreateTable(
                "dbo.tblDocumentKeyWordMap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentId = c.Int(nullable: false),
                        KeyWordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblDocuments", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("dbo.tblDocumentKeyWord", t => t.KeyWordId, cascadeDelete: true)
                .Index(t => t.DocumentId)
                .Index(t => t.KeyWordId);
            
            CreateTable(
                "dbo.tblDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        DocumentPath = c.String(maxLength: 50),
                        Descriptions = c.String(maxLength: 200),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.tblCategory", t => t.SubCategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.tblDocumentKeyWord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KeyWordName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainId = c.String(maxLength: 3),
                        SubId = c.String(maxLength: 3),
                        Lable = c.String(maxLength: 50),
                        Action = c.String(maxLength: 50),
                        Controller = c.String(maxLength: 50),
                        Area = c.String(maxLength: 50),
                        IconClass = c.String(maxLength: 50),
                        UserRole = c.String(maxLength: 50),
                        SerialNo = c.Int(),
                        IsSub = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblTask",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(),
                        TaskName = c.String(maxLength: 100),
                        TaskDescription = c.String(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        ClientId = c.Int(),
                        TaskFrequency = c.String(maxLength: 10),
                        TaskTick = c.String(maxLength: 10),
                        TaskStartDate = c.DateTime(),
                        TaskEndDate = c.DateTime(),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.tblClient", t => t.ClientId)
                .ForeignKey("dbo.tblProject", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.tblTaskTick",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(),
                        TaskTick = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblTask", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.tblTrainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainingDate = c.DateTime(nullable: false),
                        TrainingById = c.Int(nullable: false),
                        TrainingAttendId = c.Int(nullable: false),
                        TrainingSubject = c.String(),
                        TrainingDescription = c.String(),
                        TrainingDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.TrainingAttendId, cascadeDelete: false)
                .ForeignKey("dbo.tblUsers", t => t.TrainingById, cascadeDelete: false)
                .Index(t => t.TrainingById)
                .Index(t => t.TrainingAttendId);
            
            CreateTable(
                "dbo.tblUserLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TimeLog = c.DateTime(),
                        Type = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUserRoleAssign",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        ClientId = c.Int(),
                        ProjectId = c.Int(),
                        TaskId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblClient", t => t.ClientId)
                .ForeignKey("dbo.tblProject", t => t.ProjectId)
                .ForeignKey("dbo.tblTask", t => t.TaskId)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.tblWorkLog",
                c => new
                    {
                        WorkLogId = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(),
                        CreatedById = c.Int(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Duration = c.Decimal(precision: 18, scale: 2),
                        Unit = c.Int(),
                        AverageTime = c.Decimal(precision: 18, scale: 2),
                        SupApproval = c.Int(),
                        SupReviewBy = c.Int(),
                        SupRemark = c.String(),
                        SupSatisfaction = c.Int(),
                        ManApproval = c.Int(),
                        ManReviewBy = c.Int(),
                        ManRemark = c.String(),
                        ManSatisfaction = c.Int(),
                        ClientApproval = c.Int(),
                        ClientReviewBy = c.Int(),
                        ClientRemark = c.String(),
                        ClientSatisfaction = c.Int(),
                    })
                .PrimaryKey(t => t.WorkLogId)
                .ForeignKey("dbo.tblTask", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.TrakMeRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.String(),
                        RequestedUserId = c.Int(),
                        RequestedUserEmaiId = c.String(),
                        Type = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrakMeCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoutryCode = c.String(),
                        CountryName = c.String(),
                        StateCode = c.String(),
                        State = c.String(),
                        City = c.String(),
                        TimeZone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrakMeCountries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        ISDCode = c.String(),
                        ShortCode = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.TrakMeEvents",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ShortName = c.String(),
                        ImageData = c.String(),
                        EventMessage = c.String(),
                        EventType = c.Int(nullable: false),
                        EventState = c.Int(nullable: false),
                        IsPublic = c.Int(nullable: false),
                        IsPermanent = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        EventSubType = c.Int(nullable: false),
                        SubType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.TrakMeEventSubTypes", t => t.SubType_Id)
                .Index(t => t.SubType_Id);
            
            CreateTable(
                "dbo.TrakMeEventParticipates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Message = c.String(),
                        IsTrackable = c.Boolean(nullable: false),
                        IsAlert = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrakMeEvents", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.TrakMeUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TrakMeUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Mobile = c.String(),
                        BirthYear = c.String(),
                        Gender = c.String(),
                        Occupation = c.String(),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        State = c.String(),
                        StateCode = c.String(),
                        ZipCode = c.String(),
                        IsVerified = c.Boolean(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        AccessCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.TrakMeCities", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.TrakMeCountries", t => t.CountryId, cascadeDelete: false)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.TrakMeEventViewers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Message = c.String(),
                        IsTrackable = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrakMeEvents", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.TrakMeUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TrakMeEventSubTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        RefreshRate = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrakMeMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Message = c.String(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrakMeRouteLocations",
                c => new
                    {
                        RouteLocationId = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        SequenceNo = c.Int(nullable: false),
                        LocationMessage = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        ScheduleTime = c.String(),
                        TravelTime = c.Int(nullable: false),
                        HoldTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteLocationId)
                .ForeignKey("dbo.TrakMeRoutes", t => t.RouteId, cascadeDelete: false)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.TrakMeRoutes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        RouteSortName = c.String(),
                        Description = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                        days = c.String(),
                    })
                .PrimaryKey(t => t.RouteId)
                .ForeignKey("dbo.TrakMeEvents", t => t.EventId, cascadeDelete: false)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.TrakMeSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SettingPara = c.String(),
                        SettingValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrakMeUserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        AreaName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrakMeRouteLocations", "RouteId", "dbo.TrakMeRoutes");
            DropForeignKey("dbo.TrakMeRoutes", "EventId", "dbo.TrakMeEvents");
            DropForeignKey("dbo.TrakMeEvents", "SubType_Id", "dbo.TrakMeEventSubTypes");
            DropForeignKey("dbo.TrakMeEventViewers", "UserId", "dbo.TrakMeUsers");
            DropForeignKey("dbo.TrakMeEventViewers", "EventId", "dbo.TrakMeEvents");
            DropForeignKey("dbo.TrakMeEventParticipates", "UserId", "dbo.TrakMeUsers");
            DropForeignKey("dbo.TrakMeUsers", "CountryId", "dbo.TrakMeCountries");
            DropForeignKey("dbo.TrakMeUsers", "CityId", "dbo.TrakMeCities");
            DropForeignKey("dbo.TrakMeEventParticipates", "EventId", "dbo.TrakMeEvents");
            DropForeignKey("dbo.tblWorkLog", "TaskId", "dbo.tblTask");
            DropForeignKey("dbo.tblUserRoleAssign", "TaskId", "dbo.tblTask");
            DropForeignKey("dbo.tblUserRoleAssign", "ProjectId", "dbo.tblProject");
            DropForeignKey("dbo.tblUserRoleAssign", "ClientId", "dbo.tblClient");
            DropForeignKey("dbo.tblTrainings", "TrainingById", "dbo.tblUsers");
            DropForeignKey("dbo.tblTrainings", "TrainingAttendId", "dbo.tblUsers");
            DropForeignKey("dbo.tblTaskTick", "TaskId", "dbo.tblTask");
            DropForeignKey("dbo.tblTask", "ProjectId", "dbo.tblProject");
            DropForeignKey("dbo.tblTask", "ClientId", "dbo.tblClient");
            DropForeignKey("dbo.tblDocumentKeyWordMap", "KeyWordId", "dbo.tblDocumentKeyWord");
            DropForeignKey("dbo.tblDocuments", "SubCategoryId", "dbo.tblCategory");
            DropForeignKey("dbo.tblDocuments", "CategoryId", "dbo.tblCategory");
            DropForeignKey("dbo.tblDocumentKeyWordMap", "DocumentId", "dbo.tblDocuments");
            DropForeignKey("dbo.tblContracts", "VenderId", "dbo.tblVenders");
            DropForeignKey("dbo.tblCategory", "CatId", "dbo.tblCategory");
            DropForeignKey("dbo.ComplianceTasks", "ComplianceId", "dbo.Compliances");
            DropForeignKey("dbo.Compliances", "SubCategoryId", "dbo.ComplianceCategories");
            DropForeignKey("dbo.Compliances", "CategoryId", "dbo.ComplianceCategories");
            DropForeignKey("dbo.ComplianceCategories", "CategoryId", "dbo.ComplianceCategories");
            DropForeignKey("dbo.ChangeManagementAttachment", "CreatedBy", "dbo.tblUsers");
            DropForeignKey("dbo.ChangeManagementDetail", "ResolveBy", "dbo.tblUsers");
            DropForeignKey("dbo.ChangeManagementDetail", "ProjectId", "dbo.tblProject");
            DropForeignKey("dbo.tblProject", "ClientId", "dbo.tblClient");
            DropForeignKey("dbo.ChangeManagementDetail", "CreateBy", "dbo.tblUsers");
            DropForeignKey("dbo.ChangeManagementComment", "CreatedBy", "dbo.tblUsers");
            DropForeignKey("dbo.ChangeManagementComment", "ChangeManagementId", "dbo.ChangeManagementDetail");
            DropForeignKey("dbo.ChangeManagementDetail", "CloseBy", "dbo.tblUsers");
            DropForeignKey("dbo.ChangeManagementDetail", "ClientId", "dbo.tblClient");
            DropForeignKey("dbo.ChangeManagementDetail", "ChangeTypeId", "dbo.ChangeManagementType");
            DropForeignKey("dbo.ChangeManagementDetail", "ChangeSubTypeId", "dbo.ChangeManagementSubType");
            DropForeignKey("dbo.ChangeManagementSubType", "TypeId", "dbo.ChangeManagementType");
            DropForeignKey("dbo.ChangeManagementAttachment", "ChangeManagementId", "dbo.ChangeManagementDetail");
            DropForeignKey("dbo.ChangeManagementDetail", "AssignTo", "dbo.tblUsers");
            DropForeignKey("dbo.tblUsers", "RoleId", "dbo.tblRole");
            DropIndex("dbo.TrakMeRoutes", new[] { "EventId" });
            DropIndex("dbo.TrakMeRouteLocations", new[] { "RouteId" });
            DropIndex("dbo.TrakMeEventViewers", new[] { "UserId" });
            DropIndex("dbo.TrakMeEventViewers", new[] { "EventId" });
            DropIndex("dbo.TrakMeUsers", new[] { "CityId" });
            DropIndex("dbo.TrakMeUsers", new[] { "CountryId" });
            DropIndex("dbo.TrakMeEventParticipates", new[] { "UserId" });
            DropIndex("dbo.TrakMeEventParticipates", new[] { "EventId" });
            DropIndex("dbo.TrakMeEvents", new[] { "SubType_Id" });
            DropIndex("dbo.tblWorkLog", new[] { "TaskId" });
            DropIndex("dbo.tblUserRoleAssign", new[] { "TaskId" });
            DropIndex("dbo.tblUserRoleAssign", new[] { "ProjectId" });
            DropIndex("dbo.tblUserRoleAssign", new[] { "ClientId" });
            DropIndex("dbo.tblTrainings", new[] { "TrainingAttendId" });
            DropIndex("dbo.tblTrainings", new[] { "TrainingById" });
            DropIndex("dbo.tblTaskTick", new[] { "TaskId" });
            DropIndex("dbo.tblTask", new[] { "ClientId" });
            DropIndex("dbo.tblTask", new[] { "ProjectId" });
            DropIndex("dbo.tblDocuments", new[] { "SubCategoryId" });
            DropIndex("dbo.tblDocuments", new[] { "CategoryId" });
            DropIndex("dbo.tblDocumentKeyWordMap", new[] { "KeyWordId" });
            DropIndex("dbo.tblDocumentKeyWordMap", new[] { "DocumentId" });
            DropIndex("dbo.tblContracts", new[] { "VenderId" });
            DropIndex("dbo.tblCategory", new[] { "CatId" });
            DropIndex("dbo.ComplianceTasks", new[] { "ComplianceId" });
            DropIndex("dbo.Compliances", new[] { "SubCategoryId" });
            DropIndex("dbo.Compliances", new[] { "CategoryId" });
            DropIndex("dbo.ComplianceCategories", new[] { "CategoryId" });
            DropIndex("dbo.tblProject", new[] { "ClientId" });
            DropIndex("dbo.ChangeManagementComment", new[] { "CreatedBy" });
            DropIndex("dbo.ChangeManagementComment", new[] { "ChangeManagementId" });
            DropIndex("dbo.ChangeManagementSubType", new[] { "TypeId" });
            DropIndex("dbo.tblUsers", new[] { "RoleId" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "ResolveBy" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "CreateBy" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "CloseBy" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "AssignTo" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "ChangeSubTypeId" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "ChangeTypeId" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "ProjectId" });
            DropIndex("dbo.ChangeManagementDetail", new[] { "ClientId" });
            DropIndex("dbo.ChangeManagementAttachment", new[] { "CreatedBy" });
            DropIndex("dbo.ChangeManagementAttachment", new[] { "ChangeManagementId" });
            DropTable("dbo.TrakMeUserLogs");
            DropTable("dbo.TrakMeSettings");
            DropTable("dbo.TrakMeRoutes");
            DropTable("dbo.TrakMeRouteLocations");
            DropTable("dbo.TrakMeMessages");
            DropTable("dbo.TrakMeEventSubTypes");
            DropTable("dbo.TrakMeEventViewers");
            DropTable("dbo.TrakMeUsers");
            DropTable("dbo.TrakMeEventParticipates");
            DropTable("dbo.TrakMeEvents");
            DropTable("dbo.TrakMeCountries");
            DropTable("dbo.TrakMeCities");
            DropTable("dbo.TrakMeRequests");
            DropTable("dbo.tblWorkLog");
            DropTable("dbo.tblUserRoleAssign");
            DropTable("dbo.tblUserLog");
            DropTable("dbo.tblTrainings");
            DropTable("dbo.tblTaskTick");
            DropTable("dbo.tblTask");
            DropTable("dbo.tblMenu");
            DropTable("dbo.tblDocumentKeyWord");
            DropTable("dbo.tblDocuments");
            DropTable("dbo.tblDocumentKeyWordMap");
            DropTable("dbo.tblVenders");
            DropTable("dbo.tblContracts");
            DropTable("dbo.tblCategory");
            DropTable("dbo.PasswordResetRequests");
            DropTable("dbo.ComplianceTasks");
            DropTable("dbo.Compliances");
            DropTable("dbo.ComplianceCategories");
            DropTable("dbo.tblProject");
            DropTable("dbo.ChangeManagementComment");
            DropTable("dbo.tblClient");
            DropTable("dbo.ChangeManagementType");
            DropTable("dbo.ChangeManagementSubType");
            DropTable("dbo.tblRole");
            DropTable("dbo.tblUsers");
            DropTable("dbo.ChangeManagementDetail");
            DropTable("dbo.ChangeManagementAttachment");
            DropTable("dbo.CCTVLogs");
        }
    }
}
