create table Author
(
    id   int identity
        constraint Author_pk
        primary key nonclustered,
    name nvarchar(50)
)
    go

INSERT INTO Library.dbo.Author (id, name) VALUES (1, N'Author One');
INSERT INTO Library.dbo.Author (id, name) VALUES (2, N'Author Two');
INSERT INTO Library.dbo.Author (id, name) VALUES (1002, N'A Three');
INSERT INTO Library.dbo.Author (id, name) VALUES (1003, N'A Four');
INSERT INTO Library.dbo.Author (id, name) VALUES (1004, N'June Four');
INSERT INTO Library.dbo.Author (id, name) VALUES (1005, N'Лев Толстой');
INSERT INTO Library.dbo.Author (id, name) VALUES (1006, N'Тарас Шевченко');
INSERT INTO Library.dbo.Author (id, name) VALUES (1007, N'Уильям Шекспир');
INSERT INTO Library.dbo.Author (id, name) VALUES (1008, N'Александр Пушкин');

go

create table Books
(
    id        int identity
        constraint Book_pk
        primary key nonclustered,
    title     nvarchar(150),
    author_id int
        constraint Book_Author_id_fk
            references Author
)
    go

INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1, N'Book One-1', 1);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (2, N'Book Two', 2);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (3, N'Book One-2', 1);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1003, N'B Three-1', 1002);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1004, N'B Four-1', 1003);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1005, N'B Four-2', 1003);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1006, N'B Four-3', 1003);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1007, N'B4', 1004);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1016, N'Война и мир', 1005);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1017, N'Анна Каренина', 1005);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1018, N'Кобзарь', 1006);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1019, N'Ромео и Джульетта', 1007);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1020, N'Король Лир', 1007);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1021, N'Гамлет', 1007);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1022, N'Капитанская дочка', 1008);
INSERT INTO Library.dbo.Books (id, title, author_id) VALUES (1023, N'Сказки', 1008);