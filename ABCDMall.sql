
create database ABCDMall
use ABCDMall

CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Photo] [varchar](250) NOT NULL,
	[Description] [text] NOT NULL,
	[TimeLast] [time](7) NOT NULL,
	[DateExpect] [date] NOT NULL,
	[Genre] [varchar](250) NOT NULL,
	[Language] [varchar](250) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/3/2023 7:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Row] [int] NOT NULL,
	[Col] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 9/3/2023 7:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Row] [int] NOT NULL,
	[Col] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Name] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeatStatus]    Script Date: 9/3/2023 7:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SeatStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [bit] NOT NULL,
	[SeatId] [int] NOT NULL,
	[ShowId] [int] NOT NULL,
 CONSTRAINT [PK_SeatStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Show]    Script Date: 9/3/2023 7:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateRelease] [date] NOT NULL,
	[Price] [float] NOT NULL,
	[Status] [bit] NOT NULL,
	[RoomId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[TimeSlotId] [int] NOT NULL,
 CONSTRAINT [PK_Show] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 9/3/2023 7:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameCustomer] [varchar](250) NOT NULL,
	[PhoneCustomer] [varchar](250) NOT NULL,
	[TimeBooked] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[SeatStatusId] [int] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 9/3/2023 7:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([Id], [Name], [Photo], [Description], [TimeLast], [DateExpect], [Genre], [Language], [Status]) VALUES (1, N'Coco', N'abc', N'Coco is an American 3D Animation, fantasy, musical and adventure film produced by Pixar Animation Studios and released by Walt Disney Pictures based on the fantasy of Lee Unkrich, directed by Unkrich and co-directed. and co-author Adrian Molina.', CAST(N'01:40:46' AS Time), CAST(N'2017-11-22' AS Date), N'cartoon', N'english', 1)
INSERT [dbo].[Movie] ([Id], [Name], [Photo], [Description], [TimeLast], [DateExpect], [Genre], [Language], [Status]) VALUES (2, N'Kung Fu Panda89898998', N'de43d97ed6884c5f8af71e94529b3972.jpg', N'Kung Fu Panda is a 3D animated film by DreamWorks, created by two founding directors, John Stevenson and Mark Osborne, and produced by Melissa Cobb. The film is about a panda who loves to learn Kung Fu martial arts, but his father''s consent is denied because he is forced to follow his father''s noodle business.', CAST(N'01:28:00' AS Time), CAST(N'2008-06-27' AS Date), N'cartoon', N'english', 1)
INSERT [dbo].[Movie] ([Id], [Name], [Photo], [Description], [TimeLast], [DateExpect], [Genre], [Language], [Status]) VALUES (4, N'Minions: The Rise of Gru', N'', N'Minions: The Rise of Gru is a 2022 American computer-animated comedy film produced by Illumination and distributed by Universal Pictures. It is the sequel to the Minions spin-off and the fifth installment overall in the Moon Thieves franchise.', CAST(N'02:55:00' AS Time), CAST(N'2022-07-01' AS Date), N'cartoon', N'english', 1)
INSERT [dbo].[Movie] ([Id], [Name], [Photo], [Description], [TimeLast], [DateExpect], [Genre], [Language], [Status]) VALUES (5, N'test', N'eb4edfb819f3427b880aa29525343435.jpg', N'asdfghjkl;wertyui sdfghjkl;', CAST(N'01:28:00' AS Time), CAST(N'2008-06-27' AS Date), N'cartoon', N'english', 0)
INSERT [dbo].[Movie] ([Id], [Name], [Photo], [Description], [TimeLast], [DateExpect], [Genre], [Language], [Status]) VALUES (6, N'asdfghjk', N'23cc6f07cd7c4d19aa8a8011099da004.jpg', N'jhgfdhjjhcvbnmiuyuh', CAST(N'02:55:23' AS Time), CAST(N'2018-06-29' AS Date), N'huhu', N'english', 1)

SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [Name], [Row], [Col], [Status]) VALUES (12, N'Room 1', 3, 2, 1)
INSERT [dbo].[Room] ([Id], [Name], [Row], [Col], [Status]) VALUES (14, N'Room 2', 2, 2, 1)
INSERT [dbo].[Room] ([Id], [Name], [Row], [Col], [Status]) VALUES (15, N'Room 3', 3, 3, 0)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Seat] ON 

INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (1, 1, 1, 1, 12, N'A1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (2, 1, 2, 1, 12, N'A2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (3, 2, 1, 1, 12, N'B1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (4, 2, 2, 1, 12, N'B2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (5, 3, 1, 1, 12, N'C1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (6, 3, 2, 1, 12, N'C2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (8, 1, 1, 1, 14, N'A1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (9, 1, 2, 0, 14, N'A2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (10, 2, 1, 1, 14, N'B1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (11, 2, 2, 1, 14, N'B2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (12, 1, 1, 0, 15, N'A1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (13, 1, 2, 0, 15, N'A2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (14, 1, 3, 0, 15, N'A3')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (15, 2, 1, 0, 15, N'B1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (16, 2, 2, 0, 15, N'B2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (17, 2, 3, 0, 15, N'B3')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (18, 3, 1, 0, 15, N'C1')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (19, 3, 2, 0, 15, N'C2')
INSERT [dbo].[Seat] ([Id], [Row], [Col], [Status], [RoomId], [Name]) VALUES (20, 3, 3, 0, 15, N'C3')
SET IDENTITY_INSERT [dbo].[Seat] OFF
GO
SET IDENTITY_INSERT [dbo].[SeatStatus] ON 

INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (1, 0, 8, 3)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (2, 0, 9, 3)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (3, 0, 10, 3)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (4, 0, 11, 3)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (5, 0, 12, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (6, 0, 13, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (7, 0, 14, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (8, 0, 15, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (9, 1, 16, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (10, 1, 17, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (11, 1, 18, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (12, 1, 19, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (13, 1, 20, 4)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (14, 1, 8, 5)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (15, 1, 9, 5)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (16, 1, 10, 5)
INSERT [dbo].[SeatStatus] ([Id], [Status], [SeatId], [ShowId]) VALUES (17, 1, 11, 5)
SET IDENTITY_INSERT [dbo].[SeatStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Show] ON 

INSERT [dbo].[Show] ([Id], [DateRelease], [Price], [Status], [RoomId], [MovieId], [TimeSlotId]) VALUES (3, CAST(N'2023-09-09' AS Date), 14, 0, 14, 2, 2)
INSERT [dbo].[Show] ([Id], [DateRelease], [Price], [Status], [RoomId], [MovieId], [TimeSlotId]) VALUES (4, CAST(N'2023-09-09' AS Date), 10, 1, 15, 1, 2)
INSERT [dbo].[Show] ([Id], [DateRelease], [Price], [Status], [RoomId], [MovieId], [TimeSlotId]) VALUES (5, CAST(N'2023-09-09' AS Date), 10, 1, 14, 2, 2)
SET IDENTITY_INSERT [dbo].[Show] OFF
GO
--insert into Show  VALUES (  CAST(N'2023-09-02T00:00:00.000' AS DateTime), 14, 1, 14, 4, 2)
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([Id], [NameCustomer], [PhoneCustomer], [TimeBooked], [Status], [SeatStatusId]) VALUES (1, N'Nguyen Van A', N'0913852369', CAST(N'2023-09-02T00:00:00.000' AS DateTime), 1, 5)
INSERT [dbo].[Ticket] ([Id], [NameCustomer], [PhoneCustomer], [TimeBooked], [Status], [SeatStatusId]) VALUES (2, N'Nguyen Van A', N'0913852369', CAST(N'2023-09-02T09:23:35.000' AS DateTime), 1, 6)
INSERT [dbo].[Ticket] ([Id], [NameCustomer], [PhoneCustomer], [TimeBooked], [Status], [SeatStatusId]) VALUES (3, N'Tran Van B', N'0816325478', CAST(N'2023-09-05T21:02:17.000' AS DateTime), 1, 7)
INSERT [dbo].[Ticket] ([Id], [NameCustomer], [PhoneCustomer], [TimeBooked], [Status], [SeatStatusId]) VALUES (4, N'Tran Van B', N'0816325478', CAST(N'2023-09-05T21:02:17.000' AS DateTime), 1, 8)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([Id], [Name], [StartTime], [EndTime], [Status]) VALUES (1, N'Morning 1', CAST(N'08:00:00' AS Time), CAST(N'11:00:00' AS Time), 0)
INSERT [dbo].[TimeSlot] ([Id], [Name], [StartTime], [EndTime], [Status]) VALUES (2, N'Morning 2', CAST(N'09:30:00' AS Time), CAST(N'12:00:00' AS Time), 1)
INSERT [dbo].[TimeSlot] ([Id], [Name], [StartTime], [EndTime], [Status]) VALUES (4, N'Night ', CAST(N'19:30:00' AS Time), CAST(N'21:00:00' AS Time), 1)
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK_Seat_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK_Seat_Room]
GO
ALTER TABLE [dbo].[SeatStatus]  WITH CHECK ADD  CONSTRAINT [FK_SeatStatus_Seat] FOREIGN KEY([SeatId])
REFERENCES [dbo].[Seat] ([Id])
GO
ALTER TABLE [dbo].[SeatStatus] CHECK CONSTRAINT [FK_SeatStatus_Seat]
GO
ALTER TABLE [dbo].[SeatStatus]  WITH CHECK ADD  CONSTRAINT [FK_SeatStatus_Show] FOREIGN KEY([ShowId])
REFERENCES [dbo].[Show] ([Id])
GO
ALTER TABLE [dbo].[SeatStatus] CHECK CONSTRAINT [FK_SeatStatus_Show]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Movie]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_Room]
GO
ALTER TABLE [dbo].[Show]  WITH CHECK ADD  CONSTRAINT [FK_Show_TimeSlot] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlot] ([Id])
GO
ALTER TABLE [dbo].[Show] CHECK CONSTRAINT [FK_Show_TimeSlot]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_SeatStatus] FOREIGN KEY([SeatStatusId])
REFERENCES [dbo].[SeatStatus] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_SeatStatus]

GO
select * from Movie
CREATE TABLE ACCOUNT
(
	id int identity(1,1) primary key,
	username varchar(50),
	password varchar(50),
	name Nvarchar(50),
	gender varchar(4),
	status bit,
	dob Date,
	created Date
)
create table CATEGORY
(
	id int identity(1,1) primary key,
	name Nvarchar(50),
	
)
Create table SHOP
(
	id int identity(1,1) primary key,
	name Nvarchar(50),
	description Nvarchar(1000),
	cover_img varchar(50),
	categoryId INT 
	FOREIGN KEY (categoryId) REFERENCES CATEGORY(id),
)
Create table SALE
(
id int identity(1,1) primary key,
saleNumber float,
startDate Date,
endDate Date,
description Nvarchar(1000)
)
Create table PRODUCT
(
id int identity(1,1) primary key,
name Nvarchar(50),
image varchar(200),
price float(50),
description Nvarchar(1000),
idsale int,
idcategory int
FOREIGN KEY (idsale) REFERENCES SALE(id),
FOREIGN KEY (idcategory) REFERENCES CATEGORY(id)
)

create table FEEDBACK
(
id int identity(1,1) primary key,
name Nvarchar(100),
title Nvarchar(100),
message Nvarchar(1000),
value int,
status bit,
created date
)
create table NEWSGALLERY(
id int identity(1,1) primary key,
cover_img varchar(50),
description Nvarchar(1000)
)
--Bảng FEEDBACK TEST
insert into FEEDBACK 
values('1@gmail.com','Tiêu đề ',N'Message ',2,1,'2022-11-29')
--BẢNG ACCOUNT
insert into ACCOUNT 
values('acc1','12345678',N'Lê Thanh Tú','male',1,'2003-05-06','2023-11-08')
insert into ACCOUNT 
values('acc2','12345678',N'Trần Tấn Lộc','male',1,'2003-11-29','2023-11-08')
--BẢNG CATEGORY
insert into CATEGORY
values(N'Food & Beverage')
insert into CATEGORY
values(N'Fashion & Accessories')
insert into CATEGORY
values(N'Learning & Entertainment')
insert into CATEGORY
values(N'Thực phẩm')
--BẢNG SHOP
insert into SHOP 
values('Highland Coffee',N'Food & Beverage','hinh1shophighland.jpg',1)
insert into SHOP 
values('CHUK',N'Food & Beverage','hinh2chuck.png',1)
insert into SHOP 
values('Starbucks Coffee',N'Food & Beverage','hinh3stabuck.jpg',1)
insert into SHOP 
values('Swensens',N'Food & Beverage','hinh4SWENSENS.jpg',1)
insert into SHOP 
values('Trung Nguyên Coffee',N'Food & Beverage','hinhTrung-nguyên-Coffee.jpg',1)
insert into SHOP 
values('ANKARAZ COFFEE',N'Food & Beverage','hinhANKARAZ.png',1)
insert into SHOP 
values('IGLOO',N'Food & Beverage','hinhIgloo.png',1)
insert into SHOP 
values('Baskin Robbins',N'Food & Beverage','hinhBaskin_Robbins.jpg',1)
insert into SHOP 
values('Mochi Sweet',N'Food & Beverage','hinhMochi-Sweet.jpg',1)
insert into SHOP 
values('Haidilao',N'Food & Beverage','hinhHaidilao2.png',1)
insert into SHOP 
values('Sumo BBQ',N'Food & Beverage','hinh5F-sumobbq.jpg',1)
insert into SHOP 
values('GoGi House',N'Food & Beverage','hinh5F-Gogi.jpg',1)
insert into SHOP 
values('Kichi Kichi',N'Food & Beverage','hinh5F-Kichi.jpg',1)
insert into SHOP 
values('Hutong',N'Food & Beverage','5F-Hutong.jpg',1)
insert into SHOP 
values('Sushi KEI',N'Food & Beverage','5F-SUSHI-KEI.jpg',1)
insert into SHOP 
values('UNIQLO',N'Fashion & Accessories','hinhUniqlo.png',2)
insert into SHOP 
values('Levi’s',N'Fashion & Accessories','1F-levis.jpg',2)
insert into SHOP 
values('MLB’s',N'Fashion & Accessories','MLB.png',2)
insert into SHOP 
values('ALDO',N'Fashion & Accessories','1F-ALDO.jpg',2)
insert into SHOP 
values('Charles & Keith',N'Fashion & Accessories','2F-CHARLES-KEITH.jpg',2)
insert into SHOP 
values('Ecco',N'Fashion & Accessories','1F-ECCO.jpg',2)
insert into SHOP 
values('Pedro',N'Fashion & Accessories','1F-PEDRO.jpg',2)
insert into SHOP 
values('MUJOSH',N'Fashion & Accessories','1F-MUJOSH.jpg',2)
insert into SHOP 
values('Phuong Nam Book City',N'Learning & Entertainment','phuong-nam-book-city.jpg',3)
insert into SHOP 
values('CLEVER BOX',N'Learning & Entertainment','LOGO-CLEVER-BOX-logo.png',3)
insert into SHOP 
values('BIGFUN',N'Learning & Entertainment','BIGFUN.png',3)
insert into SHOP 
values('ILA',N'Learning & Entertainment','logo-ila.png',3)
insert into SHOP 
values('PHOTO TIME',N'Learning & Entertainment','322198535_3499328856946061_4107266628560736765_n.png',3)
--BẢNG SALE
insert into SALE
values(0.1,'2023-09-01','2023-09-10', 'SALE ĐÓN LỄ QUỐC KHÁNH 2/9')
insert into SALE
values(0.2,'2023-08-07','2023-08-09', 'SALE SẬP SÀN 8/8')
insert into SALE
values(0.3,'2023-10-12','2023-10-20', 'SALE LỄ TRUNG THU')
--BẢNG PRODUCT
insert into PRODUCT 
values(N'Thùng 48 hộp sữa tươi có đường Vinamilk 180ml','thung-48-hop-sua-tuoi-co-duong-vinamilk-180ml-202306170849505866_300x300.jpg',340,N'HSD trên 45 ngày',1,4)
insert into PRODUCT 
values(N'2 gói bánh trứng tươi chà bông Richy 156g','2-goi-banh-trung-tuoi-cha-bong-richy-156g-202308031402320353_300x300.jpg',58,N'HSD trên 5 ngày',2,4)
insert into PRODUCT 
values(N'Gan heo NT Pearly Food 300g','gan-heo-300g-202306220840063850_300x300.jpg',21,N'HSD trên 3 ngày',3,4)
insert into PRODUCT 
values(N'Lá mía heo NT Pearly Food 300g','la-mia-heo-300g-202306220839469805_300x300.jpg',21,N'HSD trên 3 ngày',3,4)
insert into PRODUCT 
values(N'Kem socola mảnh vị vani Iberri hộp 250g','hachi-nhap-khau-0811202211150.png',62,
N'HSD trên 45 ngày',2,4)
insert into PRODUCT 
values(N'Kem dừa Iberri hộp 250g (Nhập khẩu từ Thái Lan)','kem-dua-iberri-hop-250g-202307040837369478_300x300.jpg',62,N'HSD trên 45 ngày',2,4)
insert into PRODUCT 
values(N'Kem cầu vồng Iberri hộp 250g','kem-cau-vong-iberri-hop-250g-202307100924049820_300x300.jpg',62,N'HSD trên 45 ngày',2,4)
insert into PRODUCT 
values(N'Kem socola Iberri hộp 250g (Nhập khẩu Thái Lan)','kem-socola-iberri-hop-250g-nhap-khau-thai-lan-202307040838199780_300x300.jpg',62,N'HSD trên 45 ngày',2,4)
insert into PRODUCT 
values(N'Trà ướp hoa hồng Kim Anh Green Cup gói 50g','tra-uop-hoa-hong-kim-anh-green-cup-goi-50g-202307151802329165_300x300.jpg',40,N'HSD 1 năm',3,4)
insert into PRODUCT 
values(N'Viên thả lẩu La Cusina gói 300g','vien-tha-lau-bep-5-sao-goi-300g-202308051521547202_300x300.jpg',26,N'HSD trên 45 ngày',2,4)
insert into PRODUCT 
values(N'Cá ngừ ồ nướng 300g (đặc sản Phú Yên)','ca-ngu-o-nuong-300g-202305150814239386_300x300.jpg',30,N'HSD trên 7 ngày',2,4)
insert into PRODUCT 
values(N'Cánh gà đông lạnh C.P 1kg (6 - 10 cánh)','canh-ga-dong-lanh-cp-1kg-6-10-canh-202308171346027180_300x300.jpg',75,N'HSD trên 7 ngày',3,4)
insert into PRODUCT 
values(N'Tinh bột nghệ vàng Xuân Nguyên hũ 160g','tinh-bot-nghe-vang-xuan-nguyen-hu-160g-202306271443362752_300x300.jpg',99,N'HSD trên 2 năm',3,4)
insert into PRODUCT 
values(N'Dầu hào đậm đặc Maggi chai 530g','dau-hao-dam-dac-maggi-chai-530g-202305221133384939_300x300.jpg',38,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Nước mắm cao cấp Đầu Bếp Tôm chai 720ml','nuoc-mam-cao-cap-dau-bep-tom-chai-720ml-202306121433213306_300x300.jpg',34,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Hộp 6 hũ tổ yến 70ml','hop-6-hu-to-yen-chung-san-sai-gon-anpha-huong-sam-70ml-202306211707181167_300x300.jpg',159,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Thùng 12 hộp sữa tươi nguyên kem Bỉ','thung-12-hop-sua-tuoi-nguyen-kem-khong-duong-inex-1-lit-san-xuat-tu-bi-202304262227243897_300x300.jpg',444,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Thùng 12 hộp sữa tươi tiệt trùng  Meadow Fresh  ','thung-12-hop-sua-tuoi-tiet-trung-nguyen-kem-meadow-fresh-1-lit-san-xuat-tu-new-zealand-202306170857584177_300x300.jpg',456,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Gạo đặc sản Trạng Nguyên Vinh Hiển ST25 túi 5kg','gao-dac-san-trang-nguyen-vinh-hien-st25-tui-5kg-202308171039458280_300x300.jpg',179,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Mỳ gạo chũ Mỳ Vương gói 500g','my-gao-chu-my-vuong-goi-500g-202305100842555667_300x300.jpg',20,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Mì sợi 6 trứng Bartolini gói 250g','mi-soi-6-trung-bartolini-goi-250g-202205231316082216_300x300.jpg',20,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Mì Spaghetti số 4 Biondi gói 500g','mi-spaghetti-so-4-biondi-goi-500g-202207260900121669_300x300.jpg',23,N'HSD trên 60 ngày',3,4)
insert into PRODUCT 
values(N'Kem que trân châu dâu phô mai Celano Passion 65g','kem-que-tran-chau-dau-pho-mai-celano-passion-65g-202306291503190104_300x300.jpg',22,N'HSD trên 30 ngày',NULL,4)
insert into PRODUCT 
values(N'Kem que phô mai trân châu hoàng kim Celano 65g','kem-que-pho-mai-tran-chau-hoang-kim-celano-65g-202306291501116302_300x300.jpg',20,N'HSD trên 30 ngày',NULL,4)
insert into PRODUCT 
values(N'Đùi bò nhập khẩu đông lạnh 500gr','dui-bo-nhap-khau-dong-lanh-500gr-202308171356157488_300x300.jpg',99,N'HSD trên 30 ngày',NULL,4)
insert into PRODUCT 
values(N'Đường vàng An Khê gói 1kg (Chính hãng)','duong-vang-an-khe-goi-1kg-202205161519521082_300x300.png',25,N'HSD trên 1 năm',NULL,4)
select * from NEWSGALLERY
--BẢNG NEWSGALLERY
insert into NEWSGALLERY
values('80c4f7e387cc05ce50f2906a59f621d5.jpg',N'ABCD MALL')
insert into NEWSGALLERY
values('5e03a3c0501f44cd425558b4f772b918.jpg',N'BALENCIAGA')
insert into NEWSGALLERY
values('b9ebe0ffb5b6477048cdcbc7860a1927.jpg',N'VERSACE')
insert into NEWSGALLERY
values('8972dea2f371a38a07ea7986cacaa31b.jpg',N'DELICIOUS')
insert into NEWSGALLERY
values('e72e563af271aa8c5de9651d31511931.jpg',N'SHOPPING CENTRE FOOD COURT ')
insert into NEWSGALLERY
values('20d0f9fe0e5277a0d692452aaf92265a.jpg',N'SUPERMARKET')
insert into NEWSGALLERY
values('3d3dc0dcdf24bf5c80c0a807cd768cfa.jpg',N'SUSHI')
insert into NEWSGALLERY
values('162213c365177acb05bb01da9c49c9e5.jpg',N'SALAD')
insert into NEWSGALLERY
values('dd14b33c30caadbd9c975b8aff79efd5.jpg',N'KARAOKE')
insert into NEWSGALLERY
values('f4e81c3b6ef7f91b0401c0608ad9a559.jpg',N'GAME AREA')
insert into NEWSGALLERY
values('c7d979e032a4b5fc867db647eace09cd.jpg',N'STARBUCKS COFFEE')
insert into NEWSGALLERY
values('a1b8753abc75bfbf209396828152fe7f.jpg',N'SNACKS')
insert into Movie 
 VALUES ( N'Teenage Mutant Ninja Turtles: Mutant Mayhem ', N'largeposter.jpg', N'
In Teenage Mutant Ninja Turtles: Mutant Mayhem , after years of being sheltered from the human world, the Turtle brothers set out to win the hearts of New Yorkers and be accepted as normal teenagers through heroic acts
Their new friend April O Neil helps them take on a mysterious crime syndicate,but they soon get in over their heads when an army of mutants is unleashed upon them
', CAST(N'02:55:23' AS Time), CAST(N'2018-06-28' AS Date), N'
funny, active', N'english', 1)
insert into Movie 
 VALUES ( N'The Equalizer 3 ', N'largeposter1.jpg', N'
Since giving up his life as a government assassin, Robert McCall (Denzel Washington) has struggled to reconcile the horrific things he s done in the past and finds a strange solace in serving justice on behalf of the oppressed. Finding himself surprisingly at home in Southern Italy, he discovers his new friends are under the control of local crime bosses. As events turn deadly, McCall knows what he has to do: become his friends protector by taking on the mafia
', CAST(N'03:55:23' AS Time), CAST(N'2018-06-28' AS Date), N'
act, active', N'english', 1)
insert into Movie 
 VALUES ( N'Oppenheimer', N'largeposter2.jpg', N'
Written and directed by Christopher Nolan, Oppenheimer is an IMAX®-shot epic thriller that thrusts audiences into the pulse-pounding paradox of the enigmatic man who must risk destroying the world in order to save it. The film stars Cillian Murphy as J. Robert Oppenheimer and Emily Blunt as his wife, biologist and botanist Katherine "Kitty" Oppenheimer. Oscar® winner Matt Damon portrays General Leslie Groves Jr., director of the Manhattan Project, and Robert Downey, Jr. plays Lewis Strauss, a founding commissioner of the U.S. Atomic Energy Commission. Academy Award® nominee Florence Pugh plays psychiatrist Jean Tatlock, Benny Safdie plays theoretical physicist Edward Teller, Michael Angarano plays Robert Serber and Josh Hartnett plays pioneering American nuclear scientist Ernest Lawrence. Oppenheimer also stars Oscar® winner Rami Malek and reunites Nolan with eight-time Oscar® nominated actor, writer and filmmaker Kenneth Branagh
', CAST(N'05:55:23' AS Time), CAST(N'2018-06-24' AS Date), N'
mentality, active', N'english', 1)
insert into Movie 
 VALUES ( N'Sound of Freedom', N'largeposter (2).jpg', N'
Based on the incredible true story, SOUND OF FREEDOM shines a light on even the darkest of places. After rescuing a young boy from ruthless child traffickers, a federal agent learns the boy s sister is still captive and decides to embark on a dangerous mission to save her. With time running out, he quits his job and journeys deep into the Colombian jungle, putting his life on the line to free her from a fate worse than death.'
, CAST(N'07:55:23' AS Time), CAST(N'2018-06-26' AS Date),N'mind, emotions, active', N'english', 1)
insert into Movie 
 VALUES ( N'Meg 2: The Trench', N'largeposter (3).jpg', N'
Get ready for the ultimate adrenaline rush this summer in "Meg 2: The Trench," a literally larger-than-life thrill ride that supersizes the 2018 blockbuster and takes the action to higher heights and even greater depths with multiple massive Megs and so much more! Dive into uncharted waters with Jason Statham and global action icon Wu Jing as they lead a daring research team on an exploratory dive into the deepest depths of the ocean. Their voyage spirals into chaos when a malevolent mining operation threatens their mission and forces them into a high-stakes battle for survival. Pitted against colossal Megs and relentless environmental plunderers, our heroes must outrun, outsmart, and outswim their merciless predators in a pulse-pounding race against time. Immerse yourself in the most electrifying cinematic experience of the year with "Meg 2: The Trench" - where the depths of the ocean are matched only by the heights of sheer, unstoppable excitement!'
, CAST(N'10:55:23' AS Time), CAST(N'2018-06-29' AS Date),N'mind, emotions, active', N'english', 1)
insert into Movie 
 VALUES ( N'No More Bets', N'largeposter (4).jpg', N'
The film is based on tens of thousands of real fraud cases, and the horrifying inside story of the entire industry chain of overseas cyber fraud. Programmer Pan Sheng and model Anna were attracted by an overseas recruitment ad and went abroad to seek wealth, but they were scammed and ended up working in a factory. In order to leave, the two are going to attack the gambler Ah Tian and his girlfriend Xiao Yu, take their money, and complete their business... Can Pan Sheng and Anna escape from the cruel leaders of the fraud group, Manager Lu and Ah Cai? Facing cross-border investigations and pursuit of the police, where can they escape to?'
, CAST(N'12:55:23' AS Time), CAST(N'2018-06-30' AS Date),N'mind, act, active', N'china', 1)
insert into Movie 
 VALUES ( N'Strays', N'largeposter (5).jpg', N'
They say a dog is a mans best friend, but what if the man is a total dirtbag? In that case, it might be time for some sweet revenge, doggy style. When Reggie (Will Ferrell), a naïve, relentlessly optimistic Border Terrier, is abandoned on the mean city streets by his lowlife owner, Doug (Will Forte; The Last Man on Earth, Nebraska), Reggie is certain that his beloved owner would never leave him on purpose. But once Reggie falls in with a fast-talking, foul-mouthed Boston Terrier named Bug (Oscar® winner Jamie Foxx), a stray who loves his freedom and believes that owners are for suckers, Reggie finally realizes he was in a toxic relationship and begins to see Doug for the heartless sleazeball that he is. Determined to seek revenge, Reggie, Bug and Bugs pals—Maggie (Isla Fisher; Now You See Me, Wedding Crashers), a smart Australian Shepherd who has been sidelined by her owners new puppy, and Hunter (Randall Park; Always Be My Maybe, Aquaman), an anxious Great Dane whos stressed out by his work as an emotional support animal—together hatch a plan and embark on an epic adventure to help Reggie find his way home … and make Doug pay by biting off the appendage he loves the most. (Hint: Its not his foot). A subversion of the dog movies we know and love, Strays, directed by Josh Greenbaum (Barb and Star Go to Vista Del Mar) and written by Dan Perrault (Players, American Vandal), is a hilarious, R-rated, live-action comedy about the complications of love, the importance of great friendships, and the unexpected virtues of couch humping. Featuring a powerhouse comedic supporting cast—including Grammy winner Josh Gad (Beauty and the Beast), Harvey Guillén (Puss in Boots: The Last Wish), Emmy nominee Rob Riggle (The Hangover), Brett Gelman (Stranger Things), Jamie Demetriou (The Afterparty), and Emmy nominee Sofia Vergara (Modern Family)—Strays is produced by Picturestart founder and CEO Erik Feig (Luckiest Girl Alive, Cha Cha Real Smooth), by Louis Leterrier (director Fast X, The Clash of the Titans), by Dan Perrault (Players, American Vandal) and by Lord Miller partners Phil Lord and Chris Miller (Spider-Man: Into The Spider-Verse, The Lego Movie 2: The Second Part) and Lord Miller President of Film Aditya Sood (The Martian, Cocaine Bear).'
, CAST(N'12:55:23' AS Time), CAST(N'2018-06-30' AS Date),N'mind, act, active', N'china', 1)
insert into Movie 
 VALUES ( N'Strays', N'largeposter (6).jpg', N'
They say a dog is a mans best friend, but what if the man is a total dirtbag? In that case, it might be time for some sweet revenge, doggy style. When Reggie (Will Ferrell), a naïve, relentlessly optimistic Border Terrier, is abandoned on the mean city streets by his lowlife owner, Doug (Will Forte; The Last Man on Earth, Nebraska), Reggie is certain that his beloved owner would never leave him on purpose. But once Reggie falls in with a fast-talking, foul-mouthed Boston Terrier named Bug (Oscar® winner Jamie Foxx), a stray who loves his freedom and believes that owners are for suckers, Reggie finally realizes he was in a toxic relationship and begins to see Doug for the heartless sleazeball that he is. Determined to seek revenge, Reggie, Bug and Bugs pals—Maggie (Isla Fisher; Now You See Me, Wedding Crashers), a smart Australian Shepherd who has been sidelined by her owners new puppy, and Hunter (Randall Park; Always Be My Maybe, Aquaman), an anxious Great Dane whos stressed out by his work as an emotional support animal—together hatch a plan and embark on an epic adventure to help Reggie find his way home … and make Doug pay by biting off the appendage he loves the most. (Hint: Its not his foot). A subversion of the dog movies we know and love, Strays, directed by Josh Greenbaum (Barb and Star Go to Vista Del Mar) and written by Dan Perrault (Players, American Vandal), is a hilarious, R-rated, live-action comedy about the complications of love, the importance of great friendships, and the unexpected virtues of couch humping. Featuring a powerhouse comedic supporting cast—including Grammy winner Josh Gad (Beauty and the Beast), Harvey Guillén (Puss in Boots: The Last Wish), Emmy nominee Rob Riggle (The Hangover), Brett Gelman (Stranger Things), Jamie Demetriou (The Afterparty), and Emmy nominee Sofia Vergara (Modern Family)—Strays is produced by Picturestart founder and CEO Erik Feig (Luckiest Girl Alive, Cha Cha Real Smooth), by Louis Leterrier (director Fast X, The Clash of the Titans), by Dan Perrault (Players, American Vandal) and by Lord Miller partners Phil Lord and Chris Miller (Spider-Man: Into The Spider-Verse, The Lego Movie 2: The Second Part) and Lord Miller President of Film Aditya Sood (The Martian, Cocaine Bear).'
, CAST(N'12:55:23' AS Time), CAST(N'2018-06-30' AS Date),N'mind, fiction, active', N'english', 1)
insert into Movie 
 VALUES ( N'	
Ego - The Michael Gudinski Story', N'largeposter (7).jpg', N'
This feature documentary follows the wild ride of Michael Gudinski over five decades as he forges his own maverick path consumed by his ambition and enduring passion for Australian music. Michael Gudinski was a music man, impresario, and natural born hustler. He repeatedly risked everything for his one obsession: Australian music. At age 19 he launched Mushroom Records and went on to sign and nurture iconic artists including Skyhooks, Split Enz, Jimmy Barnes, Paul Kelly, Hunters & Collectors, Kylie Minogue, Archie Roach and Yothu Yindi. Not content with just a label, his hunger extended to being on the road promoting legendary international acts such as Foo Fighters, Ed Sheeran, Bruce Springsteen, and Sting. Theres barely a living Australian whose life hasnt been touched by the music he was behind. This shy son of immigrant Jewish parents from Melbourne became an audacious international player and Australian household name. Famed for his eccentricities and boldness, the film dives into the psyche and unorthodox tactics of Michael as he became the frontman of a cultural movement and built a music empire whose artists helped create the soundtrack of a nation. It goes to show a little confidence can go a long way. Helmed by acclaimed feature film, documentary and music video director Paul Goldman and produced by Bethany Jones for Mushroom Studios, the film features personal accounts from Gudinski himself, exclusive interviews with the some of the worlds most influential artists, rare archival footage and an electrifying soundtrack.'
, CAST(N'12:55:23' AS Time), CAST(N'2018-06-30' AS Date),N'mind, fiction, active', N'english', 1)
select * from Movie