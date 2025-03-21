# Manantial
Aplicación de todos los conocimientos como portafolio en una WepApi con ASP.NET 8.0 integrando Api Resful de Angular con estructura en Bootstrap y almacenado en una base de datos en Sql Server

create database MANANTIAL
go
use MANANTIAL
go

create table CATEGORIA(
IdCategoria int primary key identity,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
create table MARCA(
IdMarca int primary key identity,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go

create table PRODUCTO(
IdProducto int primary key identity,
Nombre varchar(500),
Descripcion varchar(500),
Fk_IdMarca int references MARCA(IdMarca),
Fk_IdCategoria int references CATEGORIA(IdCategoria),
Precio decimal(10,2) default 0,
stock int,
RutaImagen varchar(100),
NombreImagen varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go

create table CLIENTE(
IdCliente int primary key identity,
Nombres varchar(100),
Apellidos varchar(100),
Correo varchar(100),
Clave varchar(150),
Restablecer bit default 0,
FechaRegistro datetime default getdate()
)
go

create table CARRITO(
IdCarrito int primary key identity,
Fk_IdCliente int references CLIENTE(IdCliente),
Fk_IdCategoria int references PRODUCTO(IdProducto),
Cantidad int
)
go
create table VENTA(
IdVenta int primary key identity,
FK_idCliente int references CLIENTE(idCliente),
TotalProducto int,
MontoTotal decimal(10,2),
Contacto varchar(50),
FK_IdBarrio varchar(10), --distrito /barrio /vereda
Telefono varchar(50),
Direccion varchar(500),
IdTransaccion varchar(50),
FechaVenta datetime default getdate()
)
go

create table DETALLE_VENTA(
IdDetalleVenta int primary key identity,
Fk_IdVenta int references VENTA(IdVenta),
Fk_IdProducto int references PRODUCTO(IdProducto),
Cantidad int,
Total decimal(10,2)
)
go

create table USUARIO(
IdUsuario int primary key identity,
Nombres varchar(100),
Apellidos varchar(100),
Correo varchar(100),
Clave varchar(150),
Restablecer bit default 1,
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go

create table DEPARTAMENTO(
IdDepartamento varchar(2) NOT NULL,
Descripcion varchar (45) NOT NULL
)
go

--provincia / ciudad/ municipio
create table CIUDAD(
IdCiudad varchar(4) NOT NULL,
Descripcion varchar (45) NOT NULL,
Fk_IdDepartamento varchar (2) NOT NULL
)
go

--distrito / barrio/ vereda
create table BARRIO(
IdBarrio varchar(6) NOT NULL,
Descripcion varchar (45) NOT NULL,
Fk_IdDepartamento varchar (2) NOT NULL,
Fk_IdCiudad varchar (4) NOT NULL
)
Go

ESTRUCTURA

Manantial
│
├── Api
│   ├── Controllers
│   │   ├── CategoriaController.cs
│   │   ├── MarcaController.cs
│   │   ├── ProductoController.cs
│   │   ├── ClienteController.cs
│   │   ├── CarritoController.cs
│   │   ├── VentaController.cs
│   │   ├── DetalleVentaController.cs
│   │   ├── UsuarioController.cs
│   │   ├── DepartamentoController.cs
│   │   ├── CiudadController.cs
│   │   └── BarrioController.cs
│   ├── Models
│   │   ├── Categoria.cs
│   │   ├── Marca.cs
│   │   ├── Producto.cs
│   │   ├── Cliente.cs
│   │   ├── Carrito.cs
│   │   ├── Venta.cs
│   │   ├── DetalleVenta.cs
│   │   ├── Usuario.cs
│   │   ├── Departamento.cs
│   │   ├── Ciudad.cs
│   │   └── Barrio.cs
│   ├── Dtos
│   │   ├── CategoriaDto.cs
│   │   ├── MarcaDto.cs
│   │   ├── ProductoDto.cs
│   │   ├── ClienteDto.cs
│   │   ├── CarritoDto.cs
│   │   ├── VentaDto.cs
│   │   ├── DetalleVentaDto.cs
│   │   ├── UsuarioDto.cs
│   │   ├── DepartamentoDto.cs
│   │   ├── CiudadDto.cs
│   │   └── BarrioDto.cs
│   ├── Repositories
│   │   ├── ICategoriaRepository.cs
│   │   ├── IMarcaRepository.cs
│   │   ├── IProductoRepository.cs
│   │   ├── IClienteRepository.cs
│   │   ├── ICarritoRepository.cs
│   │   ├── IVentaRepository.cs
│   │   ├── IDetalleVentaRepository.cs
│   │   ├── IUsuarioRepository.cs
│   │   ├── IDepartamentoRepository.cs
│   │   ├── ICiudadRepository.cs
│   │   └── IBarrioRepository.cs
│   ├── Services
│   │   ├── CategoriaService.cs
│   │   ├── MarcaService.cs
│   │   ├── ProductoService.cs
│   │   ├── ClienteService.cs
│   │   ├── CarritoService.cs
│   │   ├── VentaService.cs
│   │   ├── DetalleVentaService.cs
│   │   ├── UsuarioService.cs
│   │   ├── DepartamentoService.cs
│   │   ├── CiudadService.cs
│   │   └── BarrioService.cs
│   ├── AppSettings
│   │   └── appsettings.json
│   ├── Startup.cs
│   └── Program.cs
│
├── Admin
│   ├── Controllers
│   │   ├── CategoriaController.cs
│   │   ├── MarcaController.cs
│   │   ├── ProductoController.cs
│   │   ├── ClienteController.cs
│   │   ├── CarritoController.cs
│   │   ├── VentaController.cs
│   │   ├── DetalleVentaController.cs
│   │   ├── UsuarioController.cs
│   │   ├── DepartamentoController.cs
│   │   ├── CiudadController.cs
│   │   └── BarrioController.cs
│   ├── Views
│   │   ├── Categoria
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Marca
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Producto
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Cliente
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Carrito
│   │   │   ├── Index.cshtml
│   │   ├── Venta
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── DetalleVenta
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Usuario
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Departamento
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Ciudad
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   │   ├── Barrio
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   └── Edit.cshtml
│   ├── Layout.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
│
├── Client
│   ├── src
│   │   ├── app
│   │   │   ├── components
│   │   │   │   ├── categoria
│   │   │   │   ├── marca
│   │   │   │   ├── producto
│   │   │   │   ├── cliente
│   │   │   │   ├── carrito
│   │   │   │   ├── venta
│   │   │   │   ├── detalle-venta
│   │   │   │   ├── usuario
│   │   │   │   ├── departamento
│   │   │   │   ├── ciudad
│   │   │   │   └── barrio
│   │   │   ├── services
│   │   │   │   ├── categoria.service.ts
│   │   │   │   ├── marca.service.ts
│   │   │   │   ├── producto.service.ts
│   │   │   │   ├── cliente.service.ts
│   │   │   │   ├── carrito.service.ts
│   │   │   │   ├── venta.service.ts
│   │   │   │   ├── detalle-venta.service.ts
│   │   │   │   ├── usuario.service.ts
│   │   │   │   ├── departamento.service.ts
│   │   │   │   ├── ciudad.service.ts
│   │   │   │   └── barrio.service.ts
│   │   │   ├── models
│   │   │   │   ├── categoria.model.ts
│   │   │   │   ├── marca.model.ts
│   │   │   │   ├── producto.model.ts
│   │   │   │   ├── cliente.model.ts
│   │   │   │   ├── carrito.model.ts
│   │   │   │   ├── venta.model.ts
│   │   │   │   ├── detalle-venta.model.ts
│   │   │   │   ├── usuario.model.ts
│   │   │   │   ├── departamento.model.ts
│   │   │   │   ├── ciudad.model.ts
│   │   │   │   └── barrio.model.ts
│   │   │   └── app.module.ts
│   └── package.json
│
├── Core
│   ├── Entities
│   │   ├── BaseEntity.cs
│   │   ├── Categoria.cs
│   │   ├── Marca.cs
│   │   ├── Producto.cs
│   │   ├── Cliente.cs
│   │   ├── Carrito.cs
│   │   ├── Venta.cs
│   │   ├── DetalleVenta.cs
│   │   ├── Usuario.cs
│   │   ├── Departamento.cs
│   │   ├── Ciudad.cs
│   │   └── Barrio.cs
│   ├── Interfaces
│   │   ├── ICategoriaRepository.cs
│   │   ├── IMarcaRepository.cs
│   │   ├── IProductoRepository.cs
│   │   ├── IClienteRepository.cs
│   │   ├── ICarritoRepository.cs
│   │   ├── IVentaRepository.cs
│   │   ├── IDetalleVentaRepository.cs
│   │   ├── IUsuarioRepository.cs
│   │   ├── IDepartamentoRepository.cs
│   │   ├── ICiudadRepository.cs
│   │   └── IBarrioRepository.cs
│   └── Services
│       ├── CategoriaService.cs
│       ├── MarcaService.cs
│       ├── ProductoService.cs
│       ├── ClienteService.cs
│       ├── CarritoService.cs
│       ├── VentaService.cs
│       ├── DetalleVentaService.cs
│       ├── UsuarioService.cs
│       ├── DepartamentoService.cs
│       ├── CiudadService.cs
│       └── BarrioService.cs
│
├── Application
│   ├── Dtos
│   │   ├── CategoriaDto.cs
│   │   ├── MarcaDto.cs
│   │   ├── ProductoDto.cs
│   │   ├── ClienteDto.cs
│   │   ├── CarritoDto.cs
│   │   ├── VentaDto.cs
│   │   ├── DetalleVentaDto.cs
│   │   ├── UsuarioDto.cs
│   │   ├── DepartamentoDto.cs
│   │   ├── CiudadDto.cs
│   │   └── BarrioDto.cs
│   ├── Services
│   │   ├── CategoriaService.cs
│   │   ├── MarcaService.cs
│   │   ├── ProductoService.cs
│   │   ├── ClienteService.cs
│   │   ├── CarritoService.cs
│   │   ├── VentaService.cs
│   │   ├── DetalleVentaService.cs
│   │   ├── UsuarioService.cs
│   │   ├── DepartamentoService.cs
│   │   ├── CiudadService.cs
│   │   └── BarrioService.cs
│   └── Mappers
│       ├── CategoriaMapper.cs
│       ├── MarcaMapper.cs
│       ├── ProductoMapper.cs
│       ├── ClienteMapper.cs
│       ├── CarritoMapper.cs
│       ├── VentaMapper.cs
│       ├── DetalleVentaMapper.cs
│       ├── UsuarioMapper.cs
│       ├── DepartamentoMapper.cs
│       ├── CiudadMapper.cs
│       └── BarrioMapper.cs
│
├── Infrastructure
│   ├── Data
│   │   ├── ApplicationDbContext.cs
│   │   └── Migration
│   │       ├── 20250320010100_InitialMigration.cs
│   │       └── ApplicationDbContextModelSnapshot.cs
│   └── Repositories
│       ├── CategoriaRepository.cs
│       ├── MarcaRepository.cs
│       ├── ProductoRepository.cs
│       ├── ClienteRepository.cs
│       ├── CarritoRepository.cs
│       ├── VentaRepository.cs
│       ├── DetalleVentaRepository.cs
│       ├── UsuarioRepository.cs
│       ├── DepartamentoRepository.cs
│       ├── CiudadRepository.cs
│       └── BarrioRepository.cs
