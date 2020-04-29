CREATE TABLE [dbo].[tblWeatherForecast](
	[IdWeatherForecast] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[TemperatureC] [int] NULL,
	[Summary] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblWeather] PRIMARY KEY CLUSTERED 
(
	[IdWeatherForecast] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[tblWeatherForecast] ON 
GO
INSERT [dbo].[tblWeatherForecast] ([IdWeatherForecast], [Date], [TemperatureC], [Summary]) VALUES (1, CAST(N'2020-04-06T10:00:00.000' AS DateTime), 17, N'Brescia')
GO
INSERT [dbo].[tblWeatherForecast] ([IdWeatherForecast], [Date], [TemperatureC], [Summary]) VALUES (2, CAST(N'2020-04-07T12:30:00.000' AS DateTime), 22, N'Palermo')
GO
INSERT [dbo].[tblWeatherForecast] ([IdWeatherForecast], [Date], [TemperatureC], [Summary]) VALUES (3, CAST(N'2020-04-08T19:45:00.000' AS DateTime), 15, N'Milano')
GO
SET IDENTITY_INSERT [dbo].[tblWeatherForecast] OFF
GO
