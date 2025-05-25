CREATE TABLE admin (
	id_admin 	SERIAL NOT NULL PRIMARY KEY,
	nama_admin 	VARCHAR(100) NOT NULL,
	username	VARCHAR(60) NOT NULL,
	password 	VARCHAR(60) NOT NULL,
	no_hp 		VARCHAR(14) NOT NULL
);

CREATE TABLE penjual (
    id_penjual        SERIAL NOT NULL PRIMARY KEY,
    nama_penjual      VARCHAR(100) NOT NULL,
    username          VARCHAR(60) NOT NULL,
    password          VARCHAR(60) NOT NULL,
    no_telepon_penjual VARCHAR(13) NOT NULL,
    email_penjual      VARCHAR(100) NOT NULL
);

CREATE TABLE pembeli (
    id_pembeli        SERIAL NOT NULL PRIMARY KEY,
    nama_pembeli       VARCHAR(100) NOT NULL,
    username          VARCHAR(60) NOT NULL,
    password          VARCHAR(60) NOT NULL,
    no_teleponpembeli VARCHAR(13) NOT NULL,
    email_pembeli      VARCHAR(100) NOT NULL
);

select * from penjual


CREATE SEQUENCE id_penjual_seq START WITH 1 INCREMENT BY 1;
ALTER TABLE penjual ALTER COLUMN id_penjual SET DEFAULT nextval('id_penjual_seq');

CREATE SEQUENCE id_pembeli_seq START WITH 1 INCREMENT BY 1;
ALTER TABLE pembeli ALTER COLUMN id_pembeli SET DEFAULT nextval('id_pembeli_seq');