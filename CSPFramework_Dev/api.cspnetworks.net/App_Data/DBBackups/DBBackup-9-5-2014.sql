USE [CSPFRAMEWORK]
GO
/****** Object:  Table [dbo].[Agreements]    Script Date: 9/5/2014 7:46:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agreements](
	[agreement_id] [int] IDENTITY(1,1) NOT NULL,
	[filepath] [varchar](400) NULL,
	[start_date] [datetime] NULL,
	[end_date] [datetime] NULL,
 CONSTRAINT [PK_Agreements] PRIMARY KEY CLUSTERED 
(
	[agreement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[client_id] [int] IDENTITY(1,1) NOT NULL,
	[client_code] [varchar](50) NOT NULL,
	[company_name] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[zip] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[mobile] [varchar](50) NULL,
	[website] [varchar](50) NULL,
	[service_type] [int] NULL,
	[agreement_id] [int] NULL,
	[team] [int] NULL,
	[status] [int] NULL,
	[sites] [varchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer_Vendors]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer_Vendors](
	[customer_vendor_id] [int] IDENTITY(1,1) NOT NULL,
	[vendor_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[function_name] [int] NULL,
	[function_notes] [varchar](400) NULL,
	[username_L1] [varchar](100) NULL,
	[password_L1] [varchar](100) NULL,
	[agreement_id] [int] NULL,
	[status] [int] NULL,
	[client_id] [int] NULL,
	[site] [varchar](50) NULL,
	[username_L2] [varchar](100) NULL,
	[password_L2] [varchar](100) NULL,
 CONSTRAINT [PK_Customer_Vendors] PRIMARY KEY CLUSTERED 
(
	[customer_vendor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_Type_Values]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_Type_Values](
	[enum_type_value_id] [int] IDENTITY(1,1) NOT NULL,
	[enum_type_id] [int] NOT NULL,
	[enum_type_value] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Enum_Type_Values] PRIMARY KEY CLUSTERED 
(
	[enum_type_value_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Enum_Types]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enum_Types](
	[enum_type_id] [int] IDENTITY(1,1) NOT NULL,
	[enum_type_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Enum_Types] PRIMARY KEY CLUSTERED 
(
	[enum_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Groups]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Groups](
	[user_group] [varchar](100) NOT NULL,
	[rights] [varchar](200) NULL,
 CONSTRAINT [PK_User_Groups] PRIMARY KEY CLUSTERED 
(
	[user_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[address] [varchar](200) NULL,
	[mobile] [varchar](50) NULL,
	[user_group] [varchar](100) NULL,
	[client_id] [int] NULL,
	[security_question_one] [varchar](100) NULL,
	[security_question_two] [varchar](100) NULL,
	[security_answer_one] [varchar](100) NULL,
	[security_answer_two] [varchar](100) NULL,
	[status] [int] NULL,
	[creation_date] [datetime] NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 9/5/2014 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendors](
	[vendor_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[support_number] [varchar](50) NULL,
	[support_email] [varchar](50) NULL,
	[website] [varchar](50) NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[vendor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Agreements] ON 

INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (11, N'E:\CSPNetworks\CSP Framework Repo\CSPFramework_Dev\framework.cspnetworks.net\App_Data\uploads\809f2a08-da43-442f-aa47-0d0b332c2fee.pdf', CAST(0x0000A3A000000000 AS DateTime), CAST(0x0000AF1D00000000 AS DateTime))
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (12, NULL, CAST(0x0000A3A700000000 AS DateTime), NULL)
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (13, NULL, NULL, CAST(0x0000A3B500000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Agreements] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([client_id], [client_code], [company_name], [address], [city], [state], [zip], [phone], [mobile], [website], [service_type], [agreement_id], [team], [status], [sites]) VALUES (1, N'CSP', N'CSP Networks', N'Carlsbad, CA', N'CA', N'CA', N'456123', N'55555555', N'325555666', N'cspnetworks.net', 14, NULL, 3, 1, N'USA')
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[Customer_Vendors] ON 

INSERT [dbo].[Customer_Vendors] ([customer_vendor_id], [vendor_id], [account_number], [function_name], [function_notes], [username_L1], [password_L1], [agreement_id], [status], [client_id], [site], [username_L2], [password_L2]) VALUES (1, 8, N'455666', 21, N'{"IP":"12.33.66.99","SubnetMask":"45.66.336.898","DNS1":"445.22.66.99","DNS2":"89.55.44.77"}', N'dummy', N'dummy', 11, 1, 1, N'USA', N'dummy', N'dummy')
INSERT [dbo].[Customer_Vendors] ([customer_vendor_id], [vendor_id], [account_number], [function_name], [function_notes], [username_L1], [password_L1], [agreement_id], [status], [client_id], [site], [username_L2], [password_L2]) VALUES (2, 6, N'458999', 21, N'{"IP":"45.66.99.66","SubnetMask":"45.66.336.898","DNS1":"445.22.66.99","DNS2":"89.55.44.77"}', N'dummy', N'dummy', 12, 2, 1, N'INDIA', N'dummy', N'dummy')
INSERT [dbo].[Customer_Vendors] ([customer_vendor_id], [vendor_id], [account_number], [function_name], [function_notes], [username_L1], [password_L1], [agreement_id], [status], [client_id], [site], [username_L2], [password_L2]) VALUES (3, 1, N'48855', 16, N'', N'dummy', N'dummy', 13, 2, 1, N'USA', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer_Vendors] OFF
SET IDENTITY_INSERT [dbo].[Enum_Type_Values] ON 

INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (1, 1, N'Current')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (2, 1, N'Cancelled')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (3, 2, N'Executive In Charge')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (7, 2, N'Program Lead')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (8, 2, N'Account Manager')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (9, 2, N'PAM/Overflow Manager')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (10, 3, N'MSP4')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (11, 3, N'MSP3')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (12, 3, N'MSP2')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (13, 3, N'MSP1')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (14, 3, N'CLOUD')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (15, 3, N'BACKUP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (16, 4, N'Cloud')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (17, 4, N'CRM/ERP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (18, 4, N'Fax')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (19, 4, N'Hosting-Email')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (20, 4, N'Hosting-Web')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (21, 4, N'ISP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (22, 4, N'ISP/Phone')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (23, 4, N'Phone')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (24, 4, N'Printer')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (25, 4, N'Software')
SET IDENTITY_INSERT [dbo].[Enum_Type_Values] OFF
SET IDENTITY_INSERT [dbo].[Enum_Types] ON 

INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (1, N'Status_Types')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (2, N'CSP_Teams')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (3, N'CSP_Services')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (4, N'Functions')
SET IDENTITY_INSERT [dbo].[Enum_Types] OFF
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Admin', NULL)
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Help Desk', NULL)
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Super Admin', N'ALL')
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Technician', NULL)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [email], [password], [phone], [address], [mobile], [user_group], [client_id], [security_question_one], [security_question_two], [security_answer_one], [security_answer_two], [status], [creation_date], [name]) VALUES (1, N'admin@csp.com', N'admin123', N'55546599', N'Carlsbad, CA', N'5554895655', N'Super Admin', 1, NULL, NULL, NULL, NULL, 1, NULL, N'CSP Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (1, N'CSP', N'123456', N'csp@csp.com', N'csp.com')
INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (6, N'cBeyond', N'866.424.5100', N'support@cbeyondonline.net', N'www.cbeyondonline.net')
INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (7, N'Anirudha', N'45896336', N'support@anirudha.com', N'India A')
INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (8, N'Myvendor', N'45668', N'support@support.com', N'USA')
SET IDENTITY_INSERT [dbo].[Vendors] OFF
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Agreement] FOREIGN KEY([agreement_id])
REFERENCES [dbo].[Agreements] ([agreement_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Agreement]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_ServiceType] FOREIGN KEY([service_type])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_ServiceType]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Status]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Team] FOREIGN KEY([team])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Team]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Agreements] FOREIGN KEY([agreement_id])
REFERENCES [dbo].[Agreements] ([agreement_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Agreements]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Clients]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_FunctionName] FOREIGN KEY([function_name])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_FunctionName]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Status]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Vendors] FOREIGN KEY([vendor_id])
REFERENCES [dbo].[Vendors] ([vendor_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Vendors]
GO
ALTER TABLE [dbo].[Enum_Type_Values]  WITH CHECK ADD  CONSTRAINT [FK_Enum_Type_Values_Enum_Types] FOREIGN KEY([enum_type_id])
REFERENCES [dbo].[Enum_Types] ([enum_type_id])
GO
ALTER TABLE [dbo].[Enum_Type_Values] CHECK CONSTRAINT [FK_Enum_Type_Values_Enum_Types]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Clients]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Status]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserGroups] FOREIGN KEY([user_group])
REFERENCES [dbo].[User_Groups] ([user_group])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserGroups]
GO
