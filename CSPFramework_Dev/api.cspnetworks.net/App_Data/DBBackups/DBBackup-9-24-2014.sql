USE [CSPFRAMEWORK]
GO
/****** Object:  Table [dbo].[Agreements]    Script Date: 9/24/2014 7:25:45 PM ******/
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
/****** Object:  Table [dbo].[Client_Site]    Script Date: 9/24/2014 7:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client_Site](
	[client_site_id] [int] IDENTITY(1,1) NOT NULL,
	[client_id] [int] NOT NULL,
	[address] [varchar](100) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[zip] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[site_name] [varchar](50) NULL,
 CONSTRAINT [PK_Client_Site] PRIMARY KEY CLUSTERED 
(
	[client_site_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 9/24/2014 7:25:45 PM ******/
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
	[executive_incharge] [int] NULL,
	[program_manager] [int] NULL,
	[account_manager] [int] NULL,
	[PAM_manager] [int] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer_Vendors]    Script Date: 9/24/2014 7:25:45 PM ******/
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
	[site] [int] NULL,
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
/****** Object:  Table [dbo].[Enum_Type_Values]    Script Date: 9/24/2014 7:25:45 PM ******/
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
/****** Object:  Table [dbo].[Enum_Types]    Script Date: 9/24/2014 7:25:45 PM ******/
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
/****** Object:  Table [dbo].[Function_Notes]    Script Date: 9/24/2014 7:25:45 PM ******/
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
/****** Object:  Table [dbo].[Hardware]    Script Date: 9/24/2014 7:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hardware](
	[CSPNAssetTag] [int] IDENTITY(1,1) NOT NULL,
	[vendor_id] [int] NOT NULL,
	[serial_number] [varchar](60) NULL,
	[make] [int] NULL,
	[model] [varchar](50) NULL,
	[item] [int] NOT NULL,
	[software_id] [int] NULL,
	[warrenty_start_date] [datetime] NULL,
	[warrenty_end_date] [datetime] NULL,
	[purchased_by] [int] NOT NULL,
	[client_id] [int] NOT NULL,
	[location] [int] NOT NULL,
	[associated_hardware_id] [int] NULL,
	[hardware_status] [int] NULL,
 CONSTRAINT [PK_Hardware] PRIMARY KEY CLUSTERED 
(
	[CSPNAssetTag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Software]    Script Date: 9/24/2014 7:25:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Software](
	[CSPNAssetTag] [int] IDENTITY(1,1) NOT NULL,
	[make] [int] NOT NULL,
	[model] [int] NOT NULL,
	[box_product_key] [varchar](50) NULL,
	[digital_product_key] [varchar](50) NULL,
	[license_type] [int] NOT NULL,
	[media_type] [int] NOT NULL,
	[purchased_by] [int] NOT NULL,
	[client_id] [int] NOT NULL,
	[location] [int] NOT NULL,
 CONSTRAINT [PK_Software] PRIMARY KEY CLUSTERED 
(
	[CSPNAssetTag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Groups]    Script Date: 9/24/2014 7:25:45 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 9/24/2014 7:25:45 PM ******/
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
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 9/24/2014 7:25:45 PM ******/
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
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (1051, N'E:\CSPNetworks\CSP Framework Repo\CSPFramework_Dev\framework.cspnetworks.net\App_Data\uploads\8c249924-fb75-47f4-9ab7-19f127168492.pdf', CAST(0x0000A3A800000000 AS DateTime), CAST(0x0000A3B600000000 AS DateTime))
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (1052, NULL, CAST(0x0000A3AF00000000 AS DateTime), CAST(0x0000A3B100000000 AS DateTime))
INSERT [dbo].[Agreements] ([agreement_id], [filepath], [start_date], [end_date]) VALUES (1054, N'E:\CSPNetworks\CSP Framework Repo\CSPFramework_Dev\framework.cspnetworks.net\App_Data\uploads\5a8cff10-0866-4d84-a935-fdf857c914b1.pdf', CAST(0x0000A3AF00000000 AS DateTime), CAST(0x0000A3B600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Agreements] OFF
SET IDENTITY_INSERT [dbo].[Client_Site] ON 

INSERT [dbo].[Client_Site] ([client_site_id], [client_id], [address], [city], [state], [zip], [phone], [fax], [site_name]) VALUES (5, 1, N'Pune', N'Pune', N'Maharastra', N'2323', N'598.989.8988', N'456.465.4564', N'India Location')
INSERT [dbo].[Client_Site] ([client_site_id], [client_id], [address], [city], [state], [zip], [phone], [fax], [site_name]) VALUES (1006, 1, N'LA', N'LA', N'LA', N'45645', N'654.564.5645', N'654.654.6545', N'USA Location')
INSERT [dbo].[Client_Site] ([client_site_id], [client_id], [address], [city], [state], [zip], [phone], [fax], [site_name]) VALUES (1008, 1, N'CHIN CHON', N'CHIN CHON', N'CHIN CHON', N'4545', N'444.555.656', N'888.999.666', N'CHINA')
INSERT [dbo].[Client_Site] ([client_site_id], [client_id], [address], [city], [state], [zip], [phone], [fax], [site_name]) VALUES (1009, 1012, N'Delhi', N'Delhi', N'California', N'4444', N'444.444.4444', N'444.444.4444', N'Indain My Location ')
SET IDENTITY_INSERT [dbo].[Client_Site] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([client_id], [client_code], [company_name], [address], [city], [state], [zip], [phone], [mobile], [website], [service_type], [agreement_id], [team], [status], [sites], [executive_incharge], [program_manager], [account_manager], [PAM_manager]) VALUES (1, N'CSP', N'CSP Networks', N'Carlsbad, CA', N'CA', N'Alabama', N'456123', N'555.555.5555', N'555.555.5555', N'http://www.cspnetworks.net', 14, 17, 3, 1, N'USA', 1, 1, 1, 1)
INSERT [dbo].[Clients] ([client_id], [client_code], [company_name], [address], [city], [state], [zip], [phone], [mobile], [website], [service_type], [agreement_id], [team], [status], [sites], [executive_incharge], [program_manager], [account_manager], [PAM_manager]) VALUES (1012, N'CSS', N'CSS Corp', NULL, NULL, NULL, NULL, NULL, NULL, N'http://css.com', 12, 1051, NULL, 1, NULL, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[Customer_Vendors] ON 

INSERT [dbo].[Customer_Vendors] ([customer_vendor_id], [vendor_id], [account_number], [function_name], [FunctionNotes_Id], [username_L1], [password_L1], [agreement_id], [status], [client_id], [site], [username_L2], [password_L2]) VALUES (26, 1, N'HHJJJL90', 18, 22, N'uname1', N'pass1', 1052, 2, 1012, 1009, N'uname2', N'pass2')
INSERT [dbo].[Customer_Vendors] ([customer_vendor_id], [vendor_id], [account_number], [function_name], [FunctionNotes_Id], [username_L1], [password_L1], [agreement_id], [status], [client_id], [site], [username_L2], [password_L2]) VALUES (28, 1, N'11111111', 16, 24, N'fdsfdsf', N'fdgdfg', 1054, 1, 1, 1006, N'dfgfg', N'dfgdfg')
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
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (16, 4, N'Application')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (17, 4, N'Fax')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (18, 4, N'Phone System')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (19, 4, N'Connectivity - Phone')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (20, 4, N'Cloud')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (21, 4, N'Connectivity - Internet')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (22, 4, N'Printer')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (26, 5, N'AOC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (27, 5, N'APPLE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (28, 6, N'DESKTOP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (29, 6, N'LAPTOP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (30, 7, N'CSP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (31, 7, N'Client')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (32, 6, N'ACCESSORY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (33, 8, N'NEW')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (34, 8, N'USED')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (35, 8, N'EXISTING')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (36, 8, N'REFURBISHED')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (37, 5, N'APC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (38, 5, N'CISCO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (39, 5, N'CROWN')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (40, 5, N'CRUCIAL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (41, 5, N'CYBER POWER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (42, 5, N'DATTO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (43, 5, N'DELL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (44, 5, N'D-LINK')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (45, 5, N'EPSON')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (46, 5, N'FONALITY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (47, 5, N'GATEWAY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (48, 5, N'HITACHI')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (49, 5, N'HONEYWELL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (50, 5, N'HP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (51, 5, N'IBM')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (52, 5, N'INGENICO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (53, 5, N'KINGSTON')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (54, 5, N'LENOVO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (55, 5, N'LG')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (56, 5, N'LINKSYS')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (57, 5, N'MEDIA PLUS')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (58, 5, N'MOTOROLA')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (59, 5, N'NEC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (60, 5, N'NEWER TECHNOLOGY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (61, 5, N'OWC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (62, 5, N'PANASONIC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (63, 5, N'PANTECH')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (64, 5, N'POLYCOM')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (65, 5, N'PROMISE TECHNOLOGY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (66, 5, N'SAMSUNG')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (67, 5, N'SAMSON')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (68, 5, N'SEAGATE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (69, 5, N'SONICWALL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (70, 5, N'SOUND TUBE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (71, 5, N'TRIPP-LITE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (72, 5, N'VIZIO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (73, 5, N'WACOM')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (74, 5, N'WESTERN DIGITAL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (75, 5, N'XEROX')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (76, 5, N'ZEBRA TECHNOLOGY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (77, 6, N'HARD DRIVE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (78, 6, N'MEMORY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (79, 6, N'MONITOR')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (80, 6, N'PHONE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (81, 6, N'PRINTER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (82, 6, N'ROUTER/FIREWALL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (83, 6, N'SWITCH')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (84, 6, N'SERVER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (85, 6, N'UPS')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (86, 9, N'ADOBE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (87, 9, N'ALTERITY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (88, 10, N'ADOBE ACROBAT')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (89, 10, N'ADOBE DREAMWEAVER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (90, 11, N'OEM')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (91, 11, N'Retail')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (92, 11, N'Open License')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (93, 12, N'N/A')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (94, 12, N'Disc')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (95, 12, N'Digital Delivery')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (97, 9, N'APPLE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (98, 9, N'ATTO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (99, 9, N'CYBERLINK')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (100, 9, N'DELL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (101, 9, N'FONALITY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (102, 9, N'FUJITSU')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (103, 9, N'INTUIT')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (104, 9, N'MICROSOFT')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (105, 9, N'NERO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (106, 9, N'NUANCE')
GO
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (107, 9, N'PHILIPS')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (108, 9, N'QUANTUM')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (109, 9, N'ROXIO')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (110, 9, N'SAP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (111, 9, N'SEAGATE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (112, 10, N'ADOBE FLASH')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (113, 10, N'ADOBE INDESIGN')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (114, 10, N'ADOBE ILLUSTRATOR')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (115, 10, N'ADOBE PHOTOSHOP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (116, 10, N'APPLE CARE PROTECTION')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (117, 10, N'CRYSTAL SOLUTIONS')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (118, 10, N'DRIVERS-DELL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (119, 10, N'DRIVERS-HP')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (120, 10, N'FONALITY')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (121, 10, N'OFFICE XP PROFESSIONAL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (122, 10, N'OFFICE BASIC EDITION 2003')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (123, 10, N'OFFICE PROFESSIONAL 2007')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (124, 10, N'OFFICE SMALL BUSINESS 2007')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (125, 10, N'OFFICE HOME AND BUSINESS 2010')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (126, 10, N'OFFICE HOME AND BUSINESS 2013')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (127, 10, N'OFFICE STANDARD 2010')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (128, 10, N'OFFICE PROFESSIONAL 2010')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (129, 10, N'OFFICE 2008 FOR MAC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (130, 10, N'OFFICE 2011 FOR MAC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (131, 10, N'PUBLISHER 2010')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (132, 10, N'POWERDVD')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (133, 10, N'RECOVERY DISC')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (134, 10, N'ROXIO CREATOR')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (135, 10, N'QUICKBOOKS STANDARD')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (136, 10, N'QUICKBOOKS PROFESSIONAL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (137, 10, N'QUICKBOOKS PREMIER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (138, 10, N'SQL SERVER 2005')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (139, 10, N'SQL SERVER 2008')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (140, 10, N'WINDOWS HOME')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (141, 10, N'WINDOWS XP PROFESSIONAL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (142, 10, N'WINDOWS 7 PROFESSIONAL')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (143, 10, N'WINDOWS 7 ULTIMATE')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (144, 10, N'WINDOWS 2003 SERVER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (145, 10, N'WINDOWS 2008 SERVER')
INSERT [dbo].[Enum_Type_Values] ([enum_type_value_id], [enum_type_id], [enum_type_value]) VALUES (146, 12, N'Recovery')
SET IDENTITY_INSERT [dbo].[Enum_Type_Values] OFF
SET IDENTITY_INSERT [dbo].[Enum_Types] ON 

INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (1, N'Status_Types')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (2, N'CSP_Teams')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (3, N'CSP_Services')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (4, N'Functions')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (5, N'Hardware_Makes')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (6, N'Hardware_Items')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (7, N'PurchasedBy')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (8, N'Hardware_Status')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (9, N'Software_Makes')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (10, N'Software_Models')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (11, N'Software_Licenses')
INSERT [dbo].[Enum_Types] ([enum_type_id], [enum_type_name]) VALUES (12, N'Software_Media')
SET IDENTITY_INSERT [dbo].[Enum_Types] OFF
SET IDENTITY_INSERT [dbo].[Function_Notes] ON 

INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (22, N'SIP', NULL, N'444.444.444.444', NULL, N'http://www.abc.com', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Function_Notes] ([FunctionNotes_Id], [solution], [connectivity], [ip_address], [login_url], [management_url], [fax_number], [phone_number], [subnet_mask], [DNS1], [DNS2], [WAN_IPs]) VALUES (24, N'Cloud', NULL, N'', N'', N'', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Function_Notes] OFF
SET IDENTITY_INSERT [dbo].[Hardware] ON 

INSERT [dbo].[Hardware] ([CSPNAssetTag], [vendor_id], [serial_number], [make], [model], [item], [software_id], [warrenty_start_date], [warrenty_end_date], [purchased_by], [client_id], [location], [associated_hardware_id], [hardware_status]) VALUES (1, 1, N'JKDGJGJ', 54, N'JKKKK', 28, 1, CAST(0x0000A3B600000000 AS DateTime), CAST(0x0000A3B600000000 AS DateTime), 30, 1, 1006, NULL, 36)
SET IDENTITY_INSERT [dbo].[Hardware] OFF
SET IDENTITY_INSERT [dbo].[Software] ON 

INSERT [dbo].[Software] ([CSPNAssetTag], [make], [model], [box_product_key], [digital_product_key], [license_type], [media_type], [purchased_by], [client_id], [location]) VALUES (1, 86, 89, N'KKK', N'LLP8', 90, 94, 31, 1, 1008)
INSERT [dbo].[Software] ([CSPNAssetTag], [make], [model], [box_product_key], [digital_product_key], [license_type], [media_type], [purchased_by], [client_id], [location]) VALUES (2, 86, 88, NULL, NULL, 90, 93, 30, 1, 5)
SET IDENTITY_INSERT [dbo].[Software] OFF
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Admin', NULL)
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Help Desk', NULL)
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Super Admin', N'ALL')
INSERT [dbo].[User_Groups] ([user_group], [rights]) VALUES (N'Technician', NULL)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [email], [password], [phone], [address], [mobile], [user_group], [client_id], [security_question_one], [security_question_two], [security_answer_one], [security_answer_two], [status], [creation_date], [firstname], [lastname]) VALUES (1, N'admin@csp.com', N'0192023a7bbd73250516f069df18b500', N'555.555.5555', N'Carlsbad, CA', N'555.489.5655', N'Super Admin', 1, NULL, NULL, NULL, NULL, 1, NULL, N'CSP', N'Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (1, N'CSP', N'444.444.4444', N'csp@csp.com', N'http://www.csp.com')
INSERT [dbo].[Vendors] ([vendor_id], [name], [support_number], [support_email], [website]) VALUES (6, N'cBeyond', N'456.456.4654', N'support@cbeyondonline.net', N'http://www.cbeyondonline.net')
SET IDENTITY_INSERT [dbo].[Vendors] OFF
ALTER TABLE [dbo].[Client_Site]  WITH CHECK ADD  CONSTRAINT [FK_Client_Sites_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[Client_Site] CHECK CONSTRAINT [FK_Client_Sites_Clients]
GO
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
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_Account_Manager] FOREIGN KEY([account_manager])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Users_Account_Manager]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_Executive_Incharge] FOREIGN KEY([executive_incharge])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Users_Executive_Incharge]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_PAM_Manager] FOREIGN KEY([PAM_manager])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Users_PAM_Manager]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Users_Program_Manager] FOREIGN KEY([program_manager])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Users_Program_Manager]
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
ALTER TABLE [dbo].[Customer_Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendors_Sites] FOREIGN KEY([site])
REFERENCES [dbo].[Client_Site] ([client_site_id])
GO
ALTER TABLE [dbo].[Customer_Vendors] CHECK CONSTRAINT [FK_Customer_Vendors_Sites]
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
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_AssociatedHardware] FOREIGN KEY([CSPNAssetTag])
REFERENCES [dbo].[Hardware] ([CSPNAssetTag])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_AssociatedHardware]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Clients]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Item] FOREIGN KEY([item])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Item]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Location] FOREIGN KEY([location])
REFERENCES [dbo].[Client_Site] ([client_site_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Location]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Make] FOREIGN KEY([make])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Make]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_PurchasedBy] FOREIGN KEY([purchased_by])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_PurchasedBy]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Software] FOREIGN KEY([software_id])
REFERENCES [dbo].[Software] ([CSPNAssetTag])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Software]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Status] FOREIGN KEY([hardware_status])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Status]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Vendors] FOREIGN KEY([vendor_id])
REFERENCES [dbo].[Vendors] ([vendor_id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Vendors]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_Clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[Clients] ([client_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_Clients]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_License] FOREIGN KEY([license_type])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_License]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_Location] FOREIGN KEY([location])
REFERENCES [dbo].[Client_Site] ([client_site_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_Location]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_Make] FOREIGN KEY([make])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_Make]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_Media] FOREIGN KEY([media_type])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_Media]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_Model] FOREIGN KEY([model])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_Model]
GO
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_PurchasedBy] FOREIGN KEY([purchased_by])
REFERENCES [dbo].[Enum_Type_Values] ([enum_type_value_id])
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_PurchasedBy]
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
