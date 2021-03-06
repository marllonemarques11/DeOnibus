USE [DeOnibusDB]
GO
/****** Object:  Table [dbo].[tbLogTravel]    Script Date: 02/02/2020 07:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbLogTravel](
	[ObjectId] [varchar](20) NULL,
	[Company] [varchar](20) NULL,
	[Origin] [varchar](max) NULL,
	[Destination] [varchar](max) NULL,
	[DepartureDate] [datetime] NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[BussClass] [varchar](20) NULL,
	[LogDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTravel]    Script Date: 02/02/2020 07:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTravel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ObjectId] [varchar](20) NULL,
	[Company] [varchar](20) NULL,
	[Origin] [varchar](max) NULL,
	[Destination] [varchar](max) NULL,
	[DepartureDate] [datetime] NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[Price] [money] NOT NULL,
	[BussClass] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE OR ALTER TRIGGER [dbo].[Trg_tbLogTravel] ON [dbo].[tbTravel] AFTER INSERT, UPDATE
AS
IF EXISTS ( SELECT * FROM Inserted)
	INSERT INTO [tbLogTravel] (
			ObjectId
			,Company
			,Origin
			,Destination
			,DepartureDate
			,ArrivalDate
			,CreatedAt
			,UpdatedAt
			,Price
			,BussClass
			,Company
			,LogDate
	)
	SELECT
			ObjectId
			,Origin
			,Destination
			,DepartureDate
			,ArrivalDate
			,CreatedAt
			,UpdatedAt
			,Price
			,BussClass
			,Company
			,GETDATE()
	FROM Inserted
go