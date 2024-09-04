
-- Uso de la base de datos
USE BG_Marjorie_Falcone;
GO

-- Creación de la tabla User
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL
);
GO

-- Creación de la tabla Post
CREATE TABLE Post (
    PostId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    DatePublished DATETIME NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
);
GO

-- Creación de la tabla Comment
CREATE TABLE Comment (
    CommentId INT PRIMARY KEY IDENTITY(1,1),
    Text NVARCHAR(MAX) NOT NULL,
    DatePosted DATETIME NOT NULL,
    UserId INT NOT NULL,
    PostId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (PostId) REFERENCES Post(PostId)
);
GO

-- Creación de la tabla Follower
CREATE TABLE Follower (
    FollowerId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    FollowedUserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (FollowedUserId) REFERENCES [User](UserId)
);
GO

-- Creación de la tabla Notification
CREATE TABLE Notification (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    Text NVARCHAR(MAX) NOT NULL,
    DateSent DATETIME NOT NULL,
    UserId INT NOT NULL,
    RelatedPostId INT NULL,
    RelatedCommentId INT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (RelatedPostId) REFERENCES Post(PostId),
    FOREIGN KEY (RelatedCommentId) REFERENCES Comment(CommentId)
);
GO

-- Inserción de registros en la tabla User
INSERT INTO [User] (Username, Email, PasswordHash) VALUES
('alice', 'alice@example.com', 'hash_password1'),
('bob', 'bob@example.com', 'hash_password2'),
('carol', 'carol@example.com', 'hash_password3'),
('dave', 'dave@example.com', 'hash_password4'),
('eve', 'eve@example.com', 'hash_password5');
GO

-- Inserción de registros en la tabla Post
INSERT INTO Post (Title, Content, DatePublished, UserId) VALUES
('Post 1', 'Content of post 1', '2024-09-01 10:00:00', 1),
('Post 2', 'Content of post 2', '2024-09-02 11:00:00', 2),
('Post 3', 'Content of post 3', '2024-09-03 12:00:00', 3),
('Post 4', 'Content of post 4', '2024-09-04 13:00:00', 4),
('Post 5', 'Content of post 5', '2024-09-05 14:00:00', 5);
GO

-- Inserción de registros en la tabla Comment
INSERT INTO Comment (Text, DatePosted, UserId, PostId) VALUES
('Comment 1 on Post 1', '2024-09-01 11:00:00', 2, 1),
('Comment 2 on Post 1', '2024-09-01 12:00:00', 3, 1),
('Comment 1 on Post 2', '2024-09-02 13:00:00', 1, 2),
('Comment 1 on Post 3', '2024-09-03 14:00:00', 4, 3),
('Comment 1 on Post 4', '2024-09-04 15:00:00', 5, 4);
GO

-- Inserción de registros en la tabla Follower
INSERT INTO Follower (UserId, FollowedUserId) VALUES
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 1);
GO

-- Inserción de registros en la tabla Notification
INSERT INTO Notification (Text, DateSent, UserId, RelatedPostId, RelatedCommentId) VALUES
('Notification 1 for Post 1', '2024-09-01 16:00:00', 1, 1, NULL),
('Notification 2 for Post 2', '2024-09-02 17:00:00', 2, 2, NULL),
('Notification 3 for Comment 1 on Post 1', '2024-09-01 18:00:00', 2, 1, 1),
('Notification 4 for Comment 2 on Post 1', '2024-09-01 19:00:00', 3, 1, 2),
('Notification 5 for Post 3', '2024-09-03 20:00:00', 3, 3, NULL);
GO
