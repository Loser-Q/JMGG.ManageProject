USE [JMGGProject]
GO
/****** Object:  Table [dbo].[SchedulerConfig]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchedulerConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobGroup] [varchar](50) NOT NULL,
	[JobName] [varchar](50) NOT NULL,
	[RequestType] [tinyint] NOT NULL,
	[RequestUrl] [varchar](500) NOT NULL,
	[CronTab] [varchar](50) NOT NULL,
	[JobRemark] [varchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
	[LastUpdateUser] [varchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[IsEnable] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_SchedulerConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchedulerLog]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchedulerLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobGroup] [varchar](50) NOT NULL,
	[JobName] [varchar](50) NOT NULL,
	[RequestType] [int] NOT NULL,
	[RequestUrl] [varchar](200) NOT NULL,
	[ReturnMsg] [varchar](5000) NOT NULL,
	[Status] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SchedulerLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAccountBalance]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAccountBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[BusinessId] [varchar](50) NOT NULL,
	[AccountTotalBalance] [varchar](50) NOT NULL,
	[AccountConsumeBalance] [varchar](50) NOT NULL,
	[NewAccountTotalBalance] [varchar](50) NOT NULL,
	[NewAccountConsumeBalance] [varchar](50) NOT NULL,
	[FinanceTotalBanalceAmount] [varchar](50) NOT NULL,
	[NewFinanceTotalBanalceAmount] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tblAccountBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAdPlanyLog]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdPlanyLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserMangeId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[BusinessId] [varchar](50) NOT NULL,
	[BusinessPlanID] [varchar](50) NOT NULL,
	[ADPlanID] [varchar](50) NOT NULL,
	[ADName] [varchar](200) NOT NULL,
	[BillingMethod] [varchar](50) NOT NULL,
	[OperationType] [varchar](50) NOT NULL,
	[OldJson] [varchar](800) NOT NULL,
	[NewJson] [varchar](800) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_tblAdPlanyLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAdvertisingPlan]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdvertisingPlan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Switch] [int] NOT NULL,
	[NewAdPlanID] [varchar](50) NOT NULL,
	[ADPlanID] [varchar](50) NOT NULL,
	[BusinessPlanID] [varchar](50) NOT NULL,
	[ADName] [varchar](50) NOT NULL,
	[DeliveryPoint] [varchar](100) NOT NULL,
	[BillingMethod] [varchar](50) NOT NULL,
	[UnitPrice] [varchar](50) NOT NULL,
	[DayBudget] [varchar](50) NOT NULL,
	[CTRPV] [varchar](50) NOT NULL,
	[CRUUV] [varchar](50) NOT NULL,
	[ECPMCPC] [varchar](50) NOT NULL,
	[ECPMCPM] [varchar](50) NOT NULL,
	[LaunchSchedule] [varchar](50) NOT NULL,
	[LaunchTime] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[ApprovalReason] [varchar](200) NOT NULL,
	[SourceType] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
	[IsDelete] [int] NOT NULL,
	[DraftId] [varchar](50) NOT NULL,
	[DraftStatus] [varchar](50) NOT NULL,
	[UserManageId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[BusinessID] [varchar](50) NOT NULL,
	[NewUnitPrice] [varchar](50) NOT NULL,
	[NewDayBudget] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblAdvertisingPlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFinanceInfo]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFinanceInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayDate] [datetime] NULL,
	[DepositMoney] [varchar](50) NOT NULL,
	[DayBalance] [varchar](50) NOT NULL,
	[NewDepositMoney] [varchar](50) NOT NULL,
	[NewDayBalance] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[BusinessID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblFinanceInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPlanReport]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPlanReport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewAdPlanId] [varchar](50) NOT NULL,
	[AdPlanId] [varchar](50) NOT NULL,
	[LaunchDate] [datetime] NULL,
	[AdName] [varchar](50) NOT NULL,
	[LaunchStatus] [varchar](50) NOT NULL,
	[PV] [varchar](50) NOT NULL,
	[CPV] [varchar](50) NOT NULL,
	[CTRPV] [varchar](50) NOT NULL,
	[UV] [varchar](50) NOT NULL,
	[CUV] [varchar](50) NOT NULL,
	[CTRUV] [varchar](50) NOT NULL,
	[DPV] [varchar](50) NOT NULL,
	[InstallCount] [varchar](50) NOT NULL,
	[ActualAmount] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UserManageId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[BussinessId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblPlanReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSourceMaterial]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSourceMaterial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceID] [varchar](50) NOT NULL,
	[VideoUrl] [varchar](200) NOT NULL,
	[Introduce] [nvarchar](500) NOT NULL,
	[LastUpdateTime] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[DataType] [int] NOT NULL,
	[UserManageId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[BusinessID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblSourceMaterial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserInfo]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BussinessID] [varchar](50) NOT NULL,
	[AgentId] [varchar](50) NOT NULL,
	[CompanyName] [varchar](200) NOT NULL,
	[Address] [varchar](300) NOT NULL,
	[WebSite] [varchar](200) NOT NULL,
	[ProductId] [varchar](100) NOT NULL,
	[Contacts] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[AccountStatus] [varchar](50) NOT NULL,
	[UserManageId] [int] NOT NULL,
	[BizInfoJson] [varchar](5000) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblUserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserManage]    Script Date: 2021/1/3 1:56:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserManage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BussinessID] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[CompanyName] [varchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
	[IsDelete] [int] NOT NULL,
 CONSTRAINT [PK_tblUserManage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_JobGroup]  DEFAULT ('') FOR [JobGroup]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_JobName]  DEFAULT ('') FOR [JobName]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_RequestType]  DEFAULT ('') FOR [RequestType]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_RequestUrl]  DEFAULT ('') FOR [RequestUrl]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_CronTab]  DEFAULT ('') FOR [CronTab]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_JobRemark]  DEFAULT ('') FOR [JobRemark]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_LastUpdateTime]  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_LastUpdateUser]  DEFAULT ('') FOR [LastUpdateUser]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_StartTime]  DEFAULT (getdate()) FOR [StartTime]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[SchedulerConfig] ADD  CONSTRAINT [DF_SchedulerConfig_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_JobGroup]  DEFAULT ('') FOR [JobGroup]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_JobName]  DEFAULT ('') FOR [JobName]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_RequestType]  DEFAULT ((0)) FOR [RequestType]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_RequestUrl]  DEFAULT ('') FOR [RequestUrl]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_ReturnMsg]  DEFAULT ('') FOR [ReturnMsg]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[SchedulerLog] ADD  CONSTRAINT [DF_SchedulerLog_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_UserId]  DEFAULT ('') FOR [UserId]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_BusinessId]  DEFAULT ('') FOR [BusinessId]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_Table_1_AccountBalance]  DEFAULT ('') FOR [AccountTotalBalance]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_Table_1_Consume]  DEFAULT ('') FOR [AccountConsumeBalance]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_NewAccountTotalBalance]  DEFAULT ('') FOR [NewAccountTotalBalance]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_NewAccountConsumeBalance]  DEFAULT ('') FOR [NewAccountConsumeBalance]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_FinanceTotalBanalceAmount]  DEFAULT ('') FOR [FinanceTotalBanalceAmount]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_NewFinanceTotalBanalceAmount]  DEFAULT ('') FOR [NewFinanceTotalBanalceAmount]
GO
ALTER TABLE [dbo].[tblAccountBalance] ADD  CONSTRAINT [DF_tblAccountBalance_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_UserMangeId]  DEFAULT ((0)) FOR [UserMangeId]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_BusinessId]  DEFAULT ('') FOR [BusinessId]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_BusinessPlanID]  DEFAULT ('') FOR [BusinessPlanID]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_ADPlanID]  DEFAULT ('') FOR [ADPlanID]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_ADName]  DEFAULT ('') FOR [ADName]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_BillingMethod]  DEFAULT ('') FOR [BillingMethod]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_OperationType]  DEFAULT ('') FOR [OperationType]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_OldJson]  DEFAULT ('') FOR [OldJson]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_NewJson]  DEFAULT ('') FOR [NewJson]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblAdPlanyLog] ADD  CONSTRAINT [DF_tblAdPlanyLog_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_Switch]  DEFAULT ((0)) FOR [Switch]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_NewAdPlanID]  DEFAULT ('') FOR [NewAdPlanID]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_Table_1_PlanID]  DEFAULT ('') FOR [ADPlanID]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_BusinessPlanID]  DEFAULT ('') FOR [BusinessPlanID]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_ADName]  DEFAULT ('') FOR [ADName]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_DeliveryPoint]  DEFAULT ('') FOR [DeliveryPoint]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_BillingMethod]  DEFAULT ('') FOR [BillingMethod]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_UnitPrice]  DEFAULT ('') FOR [UnitPrice]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_DayBudget]  DEFAULT ('') FOR [DayBudget]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_Table_1_CTR]  DEFAULT ('') FOR [CTRPV]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_Table_1_CRUV]  DEFAULT ('') FOR [CRUUV]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_ECPMCPC]  DEFAULT ('') FOR [ECPMCPC]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_ECPMCPM]  DEFAULT ('') FOR [ECPMCPM]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_LaunchSchedule]  DEFAULT ('') FOR [LaunchSchedule]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_LaunchTime]  DEFAULT ('') FOR [LaunchTime]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_Status]  DEFAULT ('') FOR [Status]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_ApprovalReason]  DEFAULT ('') FOR [ApprovalReason]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_draft_id]  DEFAULT ('') FOR [DraftId]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_DraftStatus]  DEFAULT ('') FOR [DraftStatus]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_UserManageId]  DEFAULT ((0)) FOR [UserManageId]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_BusinessID]  DEFAULT ('') FOR [BusinessID]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_NewUnitPrice]  DEFAULT ('') FOR [NewUnitPrice]
GO
ALTER TABLE [dbo].[tblAdvertisingPlan] ADD  CONSTRAINT [DF_tblAdvertisingPlan_NewDayBudget]  DEFAULT ('') FOR [NewDayBudget]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_DepositMoney]  DEFAULT ('') FOR [DepositMoney]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_DayBalance]  DEFAULT ('') FOR [DayBalance]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_NewDepositMoney]  DEFAULT ('') FOR [NewDepositMoney]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_NewDayBalance]  DEFAULT ('') FOR [NewDayBalance]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_UserId]  DEFAULT ('') FOR [UserId]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblFinanceInfo] ADD  CONSTRAINT [DF_tblFinanceInfo_BusinessID]  DEFAULT ('') FOR [BusinessID]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_NewAdPlanId]  DEFAULT ('') FOR [NewAdPlanId]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_Table_1_AdId]  DEFAULT ('') FOR [AdPlanId]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_AdName]  DEFAULT ('') FOR [AdName]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_LaunchStatus]  DEFAULT ('') FOR [LaunchStatus]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_PV]  DEFAULT ('') FOR [PV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_CPV]  DEFAULT ('') FOR [CPV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_CTRPV]  DEFAULT ('') FOR [CTRPV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_UV]  DEFAULT ('') FOR [UV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_CUV]  DEFAULT ('') FOR [CUV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_CTRUV]  DEFAULT ('') FOR [CTRUV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_DPV]  DEFAULT ('') FOR [DPV]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_InstallCount]  DEFAULT ('') FOR [InstallCount]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_ActualAmount]  DEFAULT ('') FOR [ActualAmount]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_UserManageId]  DEFAULT ((0)) FOR [UserManageId]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblPlanReport] ADD  CONSTRAINT [DF_tblPlanReport_BussinessId]  DEFAULT ('') FOR [BussinessId]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_SourceID]  DEFAULT ('') FOR [SourceID]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_VideoUrl]  DEFAULT ('') FOR [VideoUrl]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_Introduce]  DEFAULT ('') FOR [Introduce]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_LastUpdateTime]  DEFAULT ('') FOR [LastUpdateTime]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_CreateTime]  DEFAULT ('') FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_DataType]  DEFAULT ((0)) FOR [DataType]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_UserManageId]  DEFAULT ((0)) FOR [UserManageId]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblSourceMaterial] ADD  CONSTRAINT [DF_tblSourceMaterial_BusinessID]  DEFAULT ('') FOR [BusinessID]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_BussinessID]  DEFAULT ('') FOR [BussinessID]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_AgentId]  DEFAULT ('') FOR [AgentId]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_Table_1_BussinessName]  DEFAULT ('') FOR [CompanyName]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_WebSite]  DEFAULT ('') FOR [WebSite]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_ProductId]  DEFAULT ('') FOR [ProductId]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Contacts]  DEFAULT ('') FOR [Contacts]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Mobile]  DEFAULT ('') FOR [Mobile]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Email]  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_AccountStatus]  DEFAULT ('') FOR [AccountStatus]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_UserManageId]  DEFAULT ((0)) FOR [UserManageId]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_BizInfoJson]  DEFAULT ('') FOR [BizInfoJson]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_CreateTime]  DEFAULT ('') FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_BussinessID]  DEFAULT ('') FOR [BussinessID]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_UserName]  DEFAULT ('') FOR [UserName]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_PassWord]  DEFAULT ('') FOR [PassWord]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_CompanyName]  DEFAULT ('') FOR [CompanyName]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[tblUserManage] ADD  CONSTRAINT [DF_tblUserManage_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserManage表中对应的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'BusinessId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户总余额（抓取的原数据）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'AccountTotalBalance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今日账户消耗余额（抓取的消耗余额）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'AccountConsumeBalance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户总余额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'NewAccountTotalBalance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'今日账户消耗余额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'NewAccountConsumeBalance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总余额 财务页面使用 抓取的数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'FinanceTotalBanalceAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理过的总余额 财务页面使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAccountBalance', @level2type=N'COLUMN',@level2name=N'NewFinanceTotalBanalceAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家计划ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdPlanyLog', @level2type=N'COLUMN',@level2name=N'BusinessPlanID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告计划ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdPlanyLog', @level2type=N'COLUMN',@level2name=N'ADPlanID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdPlanyLog', @level2type=N'COLUMN',@level2name=N'ADName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计费方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdPlanyLog', @level2type=N'COLUMN',@level2name=N'BillingMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdPlanyLog', @level2type=N'COLUMN',@level2name=N'OperationType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关 1：开  2：关' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'Switch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本系统生成的唯一广告计划ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'NewAdPlanID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告计划ID（抓取的原系统ID）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'ADPlanID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家计划ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'BusinessPlanID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'ADName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投放点位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'DeliveryPoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计费方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'BillingMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'UnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'DayBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CTRPV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'CTRPV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CRUUV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'CRUUV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投放排期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'LaunchSchedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投放时段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'LaunchTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'ApprovalReason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1;抓取数据 2：用户新增数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'SourceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关操作传值使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'DraftId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开关操作传值使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'DraftStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价（管理员修改后的数据）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'NewUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单日预算（管理员修改后的数据）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblAdvertisingPlan', @level2type=N'COLUMN',@level2name=N'NewDayBudget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'DayDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存入多少元（抓取的原数据）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'DepositMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日终结余（抓取的原数据）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'DayBalance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存入多少元' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'NewDepositMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日终结余' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'NewDayBalance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserManage表关联的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFinanceInfo', @level2type=N'COLUMN',@level2name=N'BusinessID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新系统生成的广告ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'NewAdPlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告计划ID（原系统的）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'AdPlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投放时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'LaunchDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'AdName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投放状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'LaunchStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'曝光' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'PV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'CPV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下载量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'DPV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安装量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'InstallCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际消耗量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'ActualAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserMange表关联的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'UserManageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPlanReport', @level2type=N'COLUMN',@level2name=N'BussinessId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'素才ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'SourceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'VideoUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'Introduce'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最新更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：使用 0：未使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：抓取数据 1：用户新增数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSourceMaterial', @level2type=N'COLUMN',@level2name=N'DataType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'BussinessID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理商ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'AgentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网站地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'WebSite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'ProductId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'AccountStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserManage关联的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'UserManageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资质信息Json' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'BizInfoJson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserManage', @level2type=N'COLUMN',@level2name=N'BussinessID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserManage', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserManage', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserManage', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除 1:是 0:否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserManage', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
