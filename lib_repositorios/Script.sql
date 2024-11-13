CREATE DATABASE TiendaDeMascotas;
USE TiendaDeMascotas;


CREATE TABLE Clientes (
[ID_Persona] INT NOT NULL IDENTITY (1,1),
[Cedula] NVARCHAR (11) NOT NULL UNIQUE,
[Nombre] NVARCHAR (150) NOT NULL,
CONSTRAINT [PK_idpersona] PRIMARY KEY CLUSTERED ([ID_Persona])
);

CREATE TABLE Mascotas (
[ID_Mascota] INT NOT NULL IDENTITY (1,1),
[Cod_Mascota] NVARCHAR (12) NOT NULL UNIQUE,
[Due�o] INT NOT NULL,
CONSTRAINT [PK_idmascota] PRIMARY KEY CLUSTERED ([ID_Mascota]),
CONSTRAINT [FK_Macotas_Clientes] FOREIGN KEY ([Due�o]) REFERENCES Clientes ([ID_Persona])
);

CREATE TABLE Tipo_Mascotas (
[ID_TipoMascota] INT NOT NULL IDENTITY (1,1),
[TipoDeMascota] VARCHAR (120) NOT NULL,
[Nombre] NVARCHAR (25),
[Genero] VARCHAR (2),
[Edad] VARCHAR (4),
[Mascota] INT NOT NULL,
CONSTRAINT [PK_idtipomascota] PRIMARY KEY CLUSTERED ([ID_TipoMascota]),
CONSTRAINT [FK_TipoMas_Mascotas] FOREIGN KEY ([Mascota]) REFERENCES Mascotas ([ID_Mascota])
);

CREATE TABLE Servicios (
[ID_Servicio] INT NOT NULL IDENTITY (1,1),
[Nombre_Servicio] VARCHAR (300),
[Precio] MONEY,
[Estado] BIT NOT NULL,
[Mascota] INT  NOT NULL,
CONSTRAINT [PK_idservicio] PRIMARY KEY CLUSTERED ([ID_Servicio]),
CONSTRAINT [FK_Servicio_Mascota] FOREIGN KEY ([Mascota]) REFERENCES Mascotas ([ID_Mascota])
);

CREATE TABLE Tipo_Servicios (
[ID_TipoServicio] INT NOT NULL IDENTITY (1,1),
[Servicio] INT NOT NULL,
CONSTRAINT [PK_idtiposervicio] PRIMARY KEY CLUSTERED ([ID_TipoServicio]),
CONSTRAINT [FK_TipoServicio_Servicio] FOREIGN KEY ([Servicio]) REFERENCES Servicios ([ID_Servicio])
);


CREATE TABLE Metodo_Pago (
[ID_Pago] INT NOT NULL IDENTITY (1,1),
[Tipo_Pago] NVARCHAR (10),
CONSTRAINT [PK_idtpago] PRIMARY KEY CLUSTERED ([ID_Pago])
);

CREATE TABLE Facturas (
[ID_Factura] INT NOT NULL IDENTITY (1,1),
[Codigo_Factura] VARCHAR (15) NOT NULL,
[IVA] MONEY,
[TOTAL] MONEY,
[Cliente] INT NOT NULL,
[Mascota] INT NOT NULL,
[Servicio] INT NOT NULL,
[Pago] INT NOT NULL,
CONSTRAINT [PK_idfactura] PRIMARY KEY CLUSTERED ([ID_Factura]),
CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY ([Cliente]) REFERENCES Clientes ([ID_Persona]),
CONSTRAINT [FK_Factura_Mascota] FOREIGN KEY ([Mascota]) REFERENCES Mascotas ([ID_Mascota]),
CONSTRAINT [FK_Factura_Servicio] FOREIGN KEY ([Servicio]) REFERENCES Servicios ([ID_Servicio]),
CONSTRAINT [FK_Factura_Pago] FOREIGN KEY ([Pago]) REFERENCES Metodo_Pago ([ID_Pago])
);




