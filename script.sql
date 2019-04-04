/* sqlite schema */

CREATE TABLE cms_app (
    id INTEGER PRIMARY KEY,
    app_id INTEGER,
    app_type_id INTEGER,
    app_ename VARCHAR,
    app_name VARCHAR,
    data_status INTEGER,
    description VARCHAR
);

CREATE TABLE cms_repository (
    id INTEGER PRIMARY KEY,
    repository_name VARCHAR,
    repository_type_id INTEGER,
    gitlab_project_fullname VARCHAR,
    description VARCHAR,
    data_status INTEGER
);

CREATE TABLE meta_app_type (
    id INTEGER PRIMARY KEY,
    app_type_id INTEGER,
    app_type_name VARCHAR
);

CREATE TABLE meta_repository_type (
    id INTEGER PRIMARY KEY,
    repository_type_id INTEGER,
    repository_type_name VARCHAR
);

