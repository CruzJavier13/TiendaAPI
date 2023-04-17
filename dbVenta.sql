create database dbVenta
go
use dbVenta
go

create table tbl_cliente 
(
clienteID int identity primary key not null,
estado bit not null,
nombres varchar(120) not null,
apellidos varchar(120) not null,
cedula varchar(20),
sexo char(1) not null,
direccion varchar(max),
telefono char(16) not null,
correo varchar(250),
fecharegistro date not null,
fechamodificacion date null
)
create table tbl_empleado
(
empleadoID int identity primary key not null,
estado bit not null,
cargo char(12) not null,
nombres varchar(120) not null,
apellidos varchar(120) not null,
cedula varchar(20) not null,
sexo char(1) not null,
inss char(10),
licensia bit not null,
categoria char(1),
direccion varchar(max),
telefono char(16) not null,
correo varchar(250),
fecharegistro date not null,
fechamodificacion date null
)
create table tbl_producto
(
productoID int identity primary key not null,
estado bit not null,
nombre varchar(30) not null,
marca varchar(20) not null,
modelo varchar(40) not null,
codigobarra varchar(120),
cantidad int,
presentacion varchar(20),
precio decimal(10,2),
fecharegistro date not null,
fechamodificacion date null
)
create table tbl_venta
(
ventaID int identity primary key,
codigoventa varchar(20) not null,
estado bit not null,
empleado int references tbl_empleado(empleadoID),
cliente int references tbl_cliente(clienteID),
producto int references tbl_producto(productoID),
fecha date not null,
formapago varchar(20) not null,
descuento float not null,
preciounidad decimal(10,2) not null,
cantidad int not null,
impuesto float not null,
total decimal(10,2) not null
)
-- alter table tbl_venta alter column formapago varchar(20)
go
insert into tbl_cliente values  (1,'oscar Antonio','Puerto','000-000000-0000X','M','Miami EEUU','+152598653','',GETDATE(),''),
								(1,'Dixon Antonio','Puerto Navarro','000-000000-0000X','M','San Jose CR','+152598643','',GETDATE(),''),
								(1,'Jennyfer','Puerto','000-000000-0000X','F','Miami EEUU','+152500053','',GETDATE(),''),
								(1,'Pedro Alberto','Garay','000-000000-0000X','M','Managua Nicaragua','+50589632100','',GETDATE(),''),
								(1,'Leda','Puerto','000-000000-0000X','F','Managua Nicaragua','+50574559645','',GETDATE(),'')
go
insert into tbl_empleado values (1,'vendedor','oscar Antonio','Puerto','000-000000-0000X','M','18645655',1,'1','Miami EEUU','+152598653','oscar@gmail.com',GETDATE(),''),
								(1,'vendedor','Dixon Antonio','Puerto Navarro','000-000000-0000X','M','67845655',1,'5','San Jose CR','+152598643','dixonp@gmail.com',GETDATE(),''),
								(1,'contador','Jennyfer','Puerto','000-000000-0000X','F','8645655',0,'','Miami EEUU','+152500053','',GETDATE(),''),
								(1,'cajero','Pedro Alberto','Garay','000-000000-0000X','M','45645655',1,'8','Managua Nicaragua','+50589632100','jenny@hotmail.com',GETDATE(),''),
								(1,'tecnico','Leda','Puerto','000-000000-0000X','F','',0,'','Managua Nicaragua','+50574559645','leda@gmail.com',GETDATE(),'')
go
insert into tbl_producto values (1,'motherboard','Asrock','A520','8696658585',16,'unidad',90.3,GETDATE(),''),
								(1,'ram','Kingstom','DRR4 3200 16gb','874556353',25,'par',85.3,GETDATE(),''),
								(1,'procesador','Intel','I7 13700K','785556699',6,'unidad',670,GETDATE(),''),
								(1,'Procesador','AMD','Rizen 9 7900X','896255444',12,'unidad',520,GETDATE(),''),
								(1,'Case','Corsair','Crystal Series 570X RGB ATX Mid','8006658585',10,'unidad',120,GETDATE(),''),
								(1,'motherboard','MSI','B550','8696058585',7,'unidad',350,GETDATE(),''),
								(1,'motherboard','ASUS','X570','8696658125',16,'unidad',450,GETDATE(),''),
								(1,'tarjeta grafica','MSI','RTX4070','145879665',3,'unidad',1050,GETDATE(),''),
								(1,'tarjeta grafica','MSI','RTX6700XT','145879665',3,'unidad',990,GETDATE(),''),
								(1,'disco duro m2','Samsung','SSD 970 EVO NVMe M.2 500GB','14500879665',45,'unidad',99,GETDATE(),'')
go
insert into tbl_venta values ('1',1,1,4,1,GETDATE(),'tarjeta de debito',0,93.30,2,0.15,(90.30 * 2) + ((90.30 * 2) * .15) + (90.30 * 2) * .25),
							 ('2',1,3,1,5,GETDATE(),'tarjeta de credito',0,120.00,1,0.15,(120.00 * 1) + ((120.00 * 1) * .15)+ 120.00 * .25),
							 ('3',1,2,5,10,GETDATE(),'contado',0,99.00,2,0.15,(99.00 * 2) + ((99.00 * 2) * .15)+ (99.00 * 2) * .25),
							 ('4',1,1,4,9,GETDATE(),'financiamiento bak',0,990.00,2,0.15,(990.00 * 2) + ((990.00 * 2) * .15)+ (990.00 * 2) * .25),
							 ('5',1,3,3,7,GETDATE(),'tarjeta de debito',0,450.00,3,0.15,(450.00 * 3) + ((450.00 * 3) * .15)+ (450.00 * 3) * .25),
							 ('6',1,2,2,3,GETDATE(),'contado',0,670.00,3,0.15,(670.00 * 3) + ((670.00 * 3) * .15) + (670.00 * 3) * .25)
-- select 93.30 * 2 + ((93.30 * 2) * .15)
select * from tbl_producto
select * from tbl_cliente
select * from tbl_empleado
select * from tbl_venta
--truncate table tbl_cliente
--select * from tbl_venta
--select * from tbl_producto

--update tbl_venta set impuesto = (select (preciounidad * 0.15))

--go
--create trigger tr_previo_venta
--on dbo.tbl_producto for insert, update
--as
--	begin
--		update tbl_producto set precio = (select (precio * .25))
--	end