# KVPFlights

Database Scripts :

CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [varchar](60) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED
	(
		[UserId] ASC
	)
)

INSERT [dbo].[UserInfo] VALUES (N'Chandra', N'Admin', N'admin@abc.com', N'Edureka#2022', getdate())

CREATE TABLE [dbo].[AirlineInfo](
	[AirlineID] [int] NOT NULL,
	[AirlineName] [nvarchar](500)  NULL,
	[ContactNumber] [nvarchar](15)  NULL,
	[ContactAddress] [nvarchar](1000) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NULL
	CONSTRAINT [PK_AirlineInfo] PRIMARY KEY CLUSTERED
	(
		[AirlineID] ASC
	)
)


