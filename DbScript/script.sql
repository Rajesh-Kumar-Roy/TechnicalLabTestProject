USE [TechnicalTestDb]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Bangladesh')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'India')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (3, N'Pakistan')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (1, N'Dhaka', 1)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (2, N'Rangpur', 1)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (3, N'Rajshahi', 1)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (4, N'Mumbai', 2)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (5, N'Delhi', 2)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (6, N'Bangalore', 2)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (7, N'Karachi', 3)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (8, N'Lahore', 3)
INSERT [dbo].[Cities] ([Id], [Name], [CountryId]) VALUES (9, N'Rawalpindi', 3)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalInformations] ON 

INSERT [dbo].[PersonalInformations] ([Id], [Name], [CountryId], [CityId], [DateTime], [File]) VALUES (1, N'Rajesh', 1, 1, CAST(N'2021-03-22T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[PersonalInformations] ([Id], [Name], [CountryId], [CityId], [DateTime], [File]) VALUES (2, N'Rohim', 2, 5, CAST(N'2021-05-12T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[PersonalInformations] ([Id], [Name], [CountryId], [CityId], [DateTime], [File]) VALUES (3, N'TEst', 1, 2, CAST(N'2021-03-15T19:40:36.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[PersonalInformations] OFF
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [Name]) VALUES (1, N'C#')
INSERT [dbo].[Languages] ([Id], [Name]) VALUES (2, N'C++')
INSERT [dbo].[Languages] ([Id], [Name]) VALUES (3, N'Java')
INSERT [dbo].[Languages] ([Id], [Name]) VALUES (4, N'PHP')
INSERT [dbo].[Languages] ([Id], [Name]) VALUES (5, N'SQL')
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalInformationDetail] ON 

INSERT [dbo].[PersonalInformationDetail] ([Id], [PersonalInformationId], [LanguageId]) VALUES (2, 1, 1)
INSERT [dbo].[PersonalInformationDetail] ([Id], [PersonalInformationId], [LanguageId]) VALUES (5, 1, 2)
INSERT [dbo].[PersonalInformationDetail] ([Id], [PersonalInformationId], [LanguageId]) VALUES (6, 3, 1)
INSERT [dbo].[PersonalInformationDetail] ([Id], [PersonalInformationId], [LanguageId]) VALUES (7, 3, 5)
SET IDENTITY_INSERT [dbo].[PersonalInformationDetail] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210320185915_initial', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210320194812_SeedData', N'5.0.4')
GO
