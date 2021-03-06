USE [CSPFRAMEWORK]
GO
/****** Object:  Table [dbo].[Agreements]    Script Date: 9/4/2014 6:51:11 PM ******/
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
/****** Object:  Table [dbo].[Clients]    Script Date: 9/4/2014 6:51:13 PM ******/
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
	[fax] [varchar](50) NULL,
	[website] [varchar](50) NULL,
	[service_type] [varchar](50) NULL,
	[agreement_id] [int] NULL,
	[team] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[sites] [varchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSP_Services]    Script Date: 9/4/2014 6:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSP_Services](
	[service_type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CSP_Services] PRIMARY KEY CLUSTERED 
(
	[service_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CSP_Teams]    Script Date: 9/4/2014 6:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSP_Teams](
	[team] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CSP_Teams] PRIMARY KEY CLUSTERED 
(
	[team] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer_Vendors]    Script Date: 9/4/2014 6:51:13 PM ******/
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
	[function_name] [varchar](50) NULL,
	[function_notes] [varchar](400) NULL,
	[username_L1] [varchar](100) NULL,
	[password_L1] [varchar](100) NULL,
	[agreement_id] [int] NULL,
	[status] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[Functions]    Script Date: 9/4/2014 6:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Functions](
	[function_name] [varchar](50) NOT NULL,
	[function_notes_format] [varchar](300) NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[function_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Status_Types]    Script Date: 9/4/2014 6:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Status_Types](
	[status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status_Types] PRIMARY KEY CLUSTERED 
(
	[status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 9/4/2014 6:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroups](
	[user_group] [varchar](50) NOT NULL,
	[rights] [varchar](50) NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[user_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/4/2014 6:51:13 PM ******/
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
	[fax] [varchar](50) NULL,
	[user_group] [varchar](50) NULL,
	[client_id] [int] NULL,
	[security_question_one] [varchar](100) NULL,
	[security_question_two] [varchar](100) NULL,
	[security_answer_one] [varchar](100) NULL,
	[security_answer_two] [varchar](100) NULL,
	[status] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[Vendors]    Script Date: 9/4/2014 6:51:13 PM ******/
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

INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (1, N'E:\CSPNetworks\CSPFramework_Dev\admin.cspportal.com\App_Data\uploads\b6b680f0-6690-43f5-917d-f2432a46e688.pdf', CAST(0x0000A3A000000000 AS DateTime), NULL)
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (2, N'E:\CSPNetworks\CSPFramework_Dev\admin.cspportal.com\App_Data\uploads\b6727449-9241-4051-be9e-3e003642f26f.pdf', CAST(0x0000A3A700000000 AS DateTime), CAST(0x0000A3B000000000 AS DateTime))
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (3, N'E:\CSPNetworks\CSPFramework_Dev\admin.cspportal.com\App_Data\uploads\6d47cee6-a8a3-4816-adba-4d47a2259c6b.pdf', CAST(0x0000A3A400000000 AS DateTime), CAST(0x0000A7FD00000000 AS DateTime))
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (4, N'E:\CSPNetworks\CSPFramework_Dev\admin.cspportal.com\App_Data\uploads\3944f192-88b5-438f-b02d-27ae820669a3.pdf', CAST(0x0000A3A100000000 AS DateTime), CAST(0x0000A52200000000 AS DateTime))
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (5, N'E:\CSPNetworks\CSPFramework_Dev\admin.cspportal.com\App_Data\uploads\57530146-78f4-442e-97d1-d019aa10d7f0.pdf', CAST(0x00009E5E00000000 AS DateTime), CAST(0x0000A41200000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Agreements] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([client_id], [client_code], [company_name], [address], [city], [state], [zip], [phone], [fax], [website], [service_type], [agreement_id], [team], [status], [sites]) VALUES (1, N'CSP', N'CSP Networks', N'Carlsbad, CA', N'CA', N'CA', N'123456', N'123456', N'123456', N'www.csp.com', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
INSERT [dbo].[CSP_Services] ([service_type]) VALUES (N'BACKUP')
INSERT [dbo].[CSP_Services] ([service_type]) VALUES (N'CLOUD')
INSERT [dbo].[CSP_Services] ([service_type]) VALUES (N'MSP1')
INSERT [dbo].[CSP_Services] ([service_type]) VALUES (N'MSP2')
INSERT [dbo].[CSP_Services] ([service_type]) VALUES (N'MSP3')
INSERT [dbo].[CSP_Services] ([service_type]) VALUES (N'MSP4')
SET IDENTITY_INSERT [dbo].[Customer_Vendors] ON 

INSERT [dbo].[Customer_Vendors] ([customer_vendor_id], [vendor_id], [account_number], [function_name], [function_notes], [username_L1], [password_L1], [agreement_id], [status], [client_id], [site], [username_L2], [password_L2]) VALUES (7, 6, N'112222', N'ISP', N'{"IP":"173.200.69.100","SubnetMask":"255.255.255.252","DNS1":"4.2.2.2","DNS2":"4.2.2.3"}', N'administrator', N'password', 5, N'Current', 1, N'Garden Grove B', N'L2administrator', N'L2password')
SET IDENTITY_INSERT [dbo].[Customer_Vendors] OFF
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Cloud', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'CRM/ERP', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Fax', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Hosting-Email', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Hosting-Web', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'ISP', N'IP;SubnetMask;DNS1;DNS2')
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'ISP/Phone', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Phone', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Printer', NULL)
INSERT [dbo].[Functions] ([function_name], [function_notes_format]) VALUES (N'Software', NULL)
INSERT [dbo].[Status_Types] ([status]) VALUES (N'Cancelled')
INSERT [dbo].[Status_Types] ([status]) VALUES (N'Current')
INSERT [dbo].[UserGroups] ([user_group], [rights]) VALUES (N'Admin', NULL)
INSERT [dbo].[UserGroups] ([user_group], [rights]) VALUES (N'HelpDesk', NULL)
INSERT [dbo].[UserGroups] ([user_group], [rights]) VALUES (N'SuperAdmin', N'ALL')
INSERT [dbo].[UserGroups] ([user_group], [rights]) VALUES (N'Technician', NULL)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [email], [password], [phone], [address], [fax], [user_group], [client_id], [security_question_one], [security_question_two], [security_answer_one], [security_answer_two], [status], [creation_date], [name]) VALUES (1, N'admin@csp.com', N'admin123', N'12345', N'Carlsbad, CA', N'123456', N'Admin', 1, NULL, NULL, NULL, NULL, N'Current', NULL, N'CSP Admin')
INSERT [dbo].[Users] ([user_id], [email], [password], [phone], [address], [fax], [user_group], [client_id], [security_question_one], [security_question_two], [security_answer_one], [security_answer_two], [status], [creation_date], [name]) VALUES (2, N'john@cspnetwork.com', N'admin123', N'145891', N'CA', N'12546', N'HelpDesk', 1, NULL, NULL, NULL, NULL, N'Current', NULL, N'John Ross')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (1, N'CSP', N'123456', N'csp@csp.com', N'csp.com')
INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (6, N'cBeyond', N'866.424.5100', N'support@cbeyondonline.net', N'www.cbeyondonline.net')
SET IDENTITY_INSERT [dbo].[Vendors] OFF
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Services] FOREIGN KEY([service_type])
REFERENCES [dbo].[CSP_Services] ([service_type])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Services]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Teams] FOREIGN KEY([team])
REFERENCES [dbo].[CSP_Teams] ([team])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Teams]
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
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Functions] FOREIGN KEY([function_name])
REFERENCES [dbo].[Functions] ([function_name])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Functions]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_StatusTypes] FOREIGN KEY([status])
REFERENCES [dbo].[Status_Types] ([status])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_StatusTypes]
GO
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Vendor] FOREIGN KEY([vendor_id])
REFERENCES [dbo].[Vendors] ([vendor_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Vendor]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Clients]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_StatusTypes] FOREIGN KEY([status])
REFERENCES [dbo].[Status_Types] ([status])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_StatusTypes]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserGroups] FOREIGN KEY([user_group])
REFERENCES [dbo].[UserGroups] ([user_group])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserGroups]
GO
