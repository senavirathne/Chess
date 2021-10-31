create table Logs
(
    log_id            INTEGER not null
        primary key autoincrement,
    log_level         TEXT,
    event_name        TEXT,
    source            TEXT,
    exception_message TEXT,
    stack_trace       TEXT,
    created_date      TEXT
);

create table User
(
    user_id             INTEGER
        primary key autoincrement,
    email_address       TEXT not null,
    password            TEXT not null,
    source              TEXT not null,
    first_name          TEXT,
    last_name           TEXT,
    profile_picture_url TEXT,
    date_of_birth       DATETIME,
    about_me            TEXT,
    notifications       BIT,
    dark_theme          BIT,
    created_date        DATE
);

create table ChatHistory
(
    chat_history_id INTEGER
        primary key autoincrement,
    from_user_id    INT  not null
        references User,
    to_user_id      INT  not null
        references User,
    message         TEXT not null,
    created_date    DATE not null
);

create table sqlite_master
(
    type     text,
    name     text,
    tbl_name text,
    rootpage int,
    sql      text
);

create table sqlite_sequence
(
    name,
    seq
);


