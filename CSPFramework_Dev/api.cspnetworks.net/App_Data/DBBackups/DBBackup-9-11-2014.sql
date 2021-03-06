USE [CSPFRAMEWORK]
GO
/****** Object:  Table [dbo].[Agreements]    Script Date: 9/11/2014 8:49:14 PM ******/
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
/****** Object:  Table [dbo].[Clients]    Script Date: 9/11/2014 8:49:14 PM ******/
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
/****** Object:  Table [dbo].[Customer_Vendors]    Script Date: 9/11/2014 8:49:14 PM ******/
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
	[FunctionNotes_Id] [int] NULL,
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
/****** Object:  Table [dbo].[Enum_Type_Values]    Script Date: 9/11/2014 8:49:14 PM ******/
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
/****** Object:  Table [dbo].[Enum_Types]    Script Date: 9/11/2014 8:49:14 PM ******/
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
/****** Object:  Table [dbo].[Function_Notes]    Script Date: 9/11/2014 8:49:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Function_Notes](
	[FunctionNotes_Id] [int] IDENTITY(1,1) NOT NULL,
	[solution] [varchar](50) NULL,
	[connectivity] [varchar](50) NULL,
	[ip_address] [varchar](50) NULL,
	[login_url] [varchar](200) NULL,
	[management_url] [varchar](200) NULL,
	[fax_number] [varchar](50) NULL,
	[phone_number] [varchar](50) NULL,
	[subnet_mask] [varchar](50) NULL,
	[DNS1] [varchar](50) NULL,
	[DNS2] [varchar](50) NULL,
	[WAN_IPs] [varchar](50) NULL,
 CONSTRAINT [PK_Function_Notes] PRIMARY KEY CLUSTERED 
(
	[FunctionNotes_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Groups]    Script Date: 9/11/2014 8:49:14 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 9/11/2014 8:49:14 PM ******/
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
/****** Object:  Table [dbo].[Vendors]    Script Date: 9/11/2014 8:49:14 PM ******/
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

INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (17, NULL, CAST(0x0000A3A800000000 AS DateTime), CAST(0x0000A3AE00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Agreements] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([client_id], [client_code], [company_name], [address], [city], [state], [zip], [phone], [mobile], [website], [service_type], [agreement_id], [team], [status], [sites]) VALUES (1, N'CSP', N'CSP Networks', N'Carlsbad, CA', N'CA', N'Alabama', N'456123', N'555.555.5555', N'555.555.5555', N'cspnetworks.net', 14, 17, 3, 1, N'USA')
SET IDENTITY_INSERT [dbo].[Clients] OFF
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
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (16, 4, N'Application')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (17, 4, N'Fax')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (18, 4, N'Phone System')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (19, 4, N'Connectivity - Phone')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (20, 4, N'Cloud')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (21, 4, N'Connectivity - Internet')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (22, 4, N'Printer')
SET IDENTITY_INSERT [dbo].[Enum_Type_Values] OFF
SET IDENTITY_INSERT [dbo].[Enum_Types] ON 

INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (1, N'Status_Types')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (2, N'CSP_Teams')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (3, N'CSP_Services')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (4, N'Functions')
SET IDENTITY_INSERT [dbo].[Enum_Types] OFF
SET IDENTITY_INSERT [dbo].[Function_Notes] ON 

INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (1, N'SIP', NULL, NULL, NULL, N'http://www.management.com', N'555-569-889', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (2, N'DSL', N'Secondary', N'12.26.33.66', NULL, N'http://www.co.com', NULL, NULL, N'25.33.66.99', N'56.22.33.66', N'55.22.11.33', N'55.22.22.33/100')
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (3, NULL, NULL, N'SIP,45.66.99.89', NULL, N'http://www.abnckln.vom', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (4, NULL, NULL, N'SIP,45.66.99.89', NULL, N'http://www.abnckln.vom', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (5, N'SIP', NULL, N'45.66.99.89', NULL, N'http://www.abnckln.vom', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (6, N'Local', NULL, N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (7, N'Shared Cloud Server', NULL, N'96.33.66.99', NULL, N'http://abc.com', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (8, N'Dedicated Physical Server', NULL, N'96.33.66.99', NULL, N'http://abc.com', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (9, N'Analog', NULL, N'45.66.99.89', NULL, N'http://www.abnckln.vom', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (10, N'Analog', NULL, N'45.66.99.89', NULL, N'http://www.abnckln.vom', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (11, N'Shared Cloud Server', NULL, N'96.33.66.99', NULL, N'http://abc.com', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Function_Notes] OFF
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Admin', NULL)
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Help Desk', NULL)
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Super Admin', N'ALL')
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Technician', NULL)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [email], [password], [phone], [address], [mobile], [user_group], [client_id], [security_question_one], [security_question_two], [security_answer_one], [security_answer_two], [status], [creation_date], [name]) VALUES (1, N'admin@csp.com', N'admin123', N'555.555.5555', N'Carlsbad, CA', N'555.489.5655', N'Super Admin', 1, NULL, NULL, NULL, NULL, 1, NULL, N'CSP Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (1, N'CSP', N'123456', N'csp@csp.com', N'csp.com')
INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (6, N'cBeyond', N'866.424.5100', N'support@cbeyondonline.net', N'www.cbeyondonline.net')
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
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_FunctionNotes] FOREIGN KEY([FunctionNotes_Id])
REFERENCES [dbo].[Function_Notes] ([FunctionNotes_Id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_FunctionNotes]
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
