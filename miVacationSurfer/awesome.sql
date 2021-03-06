USE [miVacationSurfer]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityName] [nvarchar](50) NOT NULL,
	[ActivityDesc] [text] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityReview]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityReview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityRating] [int] NOT NULL,
	[ActivityDate] [date] NOT NULL,
	[ActivityPro] [text] NULL,
	[ActivityCon] [text] NULL,
	[ActivityReviewDetails] [text] NULL,
	[ActivityId] [int] NOT NULL,
 CONSTRAINT [PK_ActivityReview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityType]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityTypeName] [nvarchar](50) NOT NULL,
	[ActivityTypeDesc] [text] NOT NULL,
 CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityTypeSeason]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityTypeSeason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeasonId] [int] NOT NULL,
	[ActivityTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ActivityTypeSeason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](50) NOT NULL,
	[LocationDesc] [text] NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocationActivityType]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationActivityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityTypeId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_LocationActivityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocationReview]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationReview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationRating] [int] NOT NULL,
	[LocationDate] [date] NOT NULL,
	[LocationPro] [text] NULL,
	[LocationCon] [text] NULL,
	[LocationReviewDetails] [text] NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_LocationReview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Region]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [nvarchar](50) NOT NULL,
	[RegionDesc] [text] NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Season]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Season](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeasonName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Season] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SeasonActivity]    Script Date: 8/4/2014 2:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeasonActivity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[SeasonId] [int] NOT NULL,
 CONSTRAINT [PK_SeasonActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ActivityReview]  WITH CHECK ADD  CONSTRAINT [FK_ActivityReview_Activity] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
GO
ALTER TABLE [dbo].[ActivityReview] CHECK CONSTRAINT [FK_ActivityReview_Activity]
GO
ALTER TABLE [dbo].[ActivityTypeSeason]  WITH CHECK ADD  CONSTRAINT [FK_ActivityTypeSeason_ActivityType] FOREIGN KEY([ActivityTypeId])
REFERENCES [dbo].[ActivityType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActivityTypeSeason] CHECK CONSTRAINT [FK_ActivityTypeSeason_ActivityType]
GO
ALTER TABLE [dbo].[ActivityTypeSeason]  WITH CHECK ADD  CONSTRAINT [FK_ActivityTypeSeason_Season] FOREIGN KEY([SeasonId])
REFERENCES [dbo].[Season] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActivityTypeSeason] CHECK CONSTRAINT [FK_ActivityTypeSeason_Season]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Region]
GO
ALTER TABLE [dbo].[LocationActivityType]  WITH CHECK ADD  CONSTRAINT [FK_LocationActivityType_ActivityType] FOREIGN KEY([ActivityTypeId])
REFERENCES [dbo].[ActivityType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocationActivityType] CHECK CONSTRAINT [FK_LocationActivityType_ActivityType]
GO
ALTER TABLE [dbo].[LocationActivityType]  WITH CHECK ADD  CONSTRAINT [FK_LocationActivityType_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocationActivityType] CHECK CONSTRAINT [FK_LocationActivityType_Location]
GO
ALTER TABLE [dbo].[LocationReview]  WITH CHECK ADD  CONSTRAINT [FK_LocationReview_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[LocationReview] CHECK CONSTRAINT [FK_LocationReview_Location]
GO
ALTER TABLE [dbo].[SeasonActivity]  WITH CHECK ADD  CONSTRAINT [FK_SeasonActivity_Activity] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SeasonActivity] CHECK CONSTRAINT [FK_SeasonActivity_Activity]
GO
ALTER TABLE [dbo].[SeasonActivity]  WITH CHECK ADD  CONSTRAINT [FK_SeasonActivity_Season] FOREIGN KEY([SeasonId])
REFERENCES [dbo].[Season] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SeasonActivity] CHECK CONSTRAINT [FK_SeasonActivity_Season]
GO
