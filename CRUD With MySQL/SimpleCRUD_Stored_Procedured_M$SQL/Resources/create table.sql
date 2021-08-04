USE DB_Pegawai

IF OBJECT_ID('T_Pegawai', 'U') IS NOT NULL
  DROP TABLE "dbo".T_Pegawai

CREATE TABLE "T_Pegawai"
(
  "NIP" varchar(30) NOT NULL ,
  "Nama_Pegawai" varchar(30),
  "Pangkat" varchar(30),
  "Golongan" varchar(30),
  "Jabatan" varchar(30),
  "Unit_Kerja" varchar(30),
  CONSTRAINT "PK_NIP" PRIMARY KEY (NIP)
)
