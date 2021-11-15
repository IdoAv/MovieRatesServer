create Database MovieRatesDB
go
use MovieRatesDB
go
Create Table Users(
UserId int not null identity(10000,1),
UserName nvarchar(255) not null ,
Email nvarchar(255) not null ,
Pass nvarchar(255) not null,
FavGenreId int not null,
PhoneNumber nvarchar(255) not null,
BirthDate DateTime not null,
IsAdmin bit not null,
SignUpDate DATETIME NOT NULL DEFAULT GETDATE()
);
Alter Table
Users Add Constraint PK_Users Primary Key(UserId);
Alter Table
Users Add Constraint Uniqe_Users_Email Unique(Email);
Create Table Entries(
EntryId int not null  IDENTITY(10000, 1),
UserId int not null,
EntryTime DATETIME NOT NULL DEFAULT GETDATE()
);
Alter Table
Entries Add Constraint PK_Entries Primary key(EntryId);
Alter Table
Entries Add Constraint FK_Entries_Users Foreign Key(UserId) References Users(UserId);
Create Table FollowingUsers(
FollowerUserId int not null,
FollowingUserId int not null
);
Alter Table
FollowingUsers Add Constraint PK_FollowingUsers Primary Key(FollowerUserId,FollowingUserId);
Alter Table
FollowingUsers Add Constraint FK_FollowingUsers_Users_Follower Foreign Key(FollowerUserId) References Users(UserId);
Alter Table
FollowingUsers Add Constraint FK_FollowingUsers_Users_Following Foreign Key(FollowingUserId) References Users(UserId);
Create Table Ratings(
UserId int not null,
MovieId int not null,
Rating float not null Check (Rating >= 1 AND Rating <= 5)
);
Alter Table
Ratings Add Constraint PK_Ratings Primary Key(UserId,MovieId);
Alter Table
Ratings Add Constraint FK_Ratings_Users Foreign Key(UserId) References Users(UserId);
Create Table LikedMovies(
UserId int not null,
MovieId int not null,
IsLiked bit not null
);
Alter Table
LikedMovies Add Constraint PK_LikedMovies Primary Key(UserId,MovieId);
Alter Table
LikedMovies Add Constraint FK_LikedMovies_Users Foreign Key(UserId) References Users(UserId);
Create Table Reviews(
ReviewId int not null identity(10000,1),
UserId int not null,
MovieId int not null,
ReviewContent nvarchar(255) not null,
ReviewTime DateTime not null default GetDate()
);
Alter Table
Reviews Add Constraint PK_Reviews Primary Key(ReviewId);
Alter Table
Reviews Add Constraint FK_Reviews_Users Foreign Key(UserId) References Users(UserId);
Create Table ReviewComments(
CommentId int not null identity(10000,1),
UserId int not null,
ReviewId int not null,
CommentContent nvarchar(255) not null,
CommentTime DateTime not null default GetDate()
);
Alter Table
ReviewComments Add Constraint PK_ReviewComments Primary Key(CommentId);
Alter Table
ReviewComments Add Constraint FK_ReviewComments_Users Foreign Key(UserId) References Users(UserId);
Alter Table
ReviewComments Add Constraint FK_ReviewComments_Reviews Foreign Key(ReviewId) References Reviews(ReviewId);
Create Table UsersReviews(
UserId int not null,
ReviewId int not null,
IsLiked bit not null
);
Alter Table
UsersReviews Add Constraint PK_UsersReviews Primary Key(UserId,ReviewId);
Alter Table
UsersReviews Add Constraint FK_UsersReviews_Users Foreign Key(UserId) References Users(UserId);
Alter Table
UsersReviews Add Constraint FK_UsersReviews_Reviews Foreign Key(ReviewId) References Reviews(ReviewId);