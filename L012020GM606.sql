create database restauranteDB;
create table clientes (
clienteId int primary key identity,
nombreCliente varchar(200),
direccion varchar(500)
)

create table pedidos (
pedidoId int primary key identity,
motoristaId int,
clienteId int,
platoId int,
cantidad int,
precio numeric(18,4)
)

create table platos (
platoId int primary key identity,
nombrePlato varchar(200),
precio numeric(18,4)
)

create table motoristas (
motoristaId int primary key identity,
nombreMotorista varchar(200)
)


insert into pedidos(motoristaId,clienteId,platoId,cantidad,precio)
	values (1,1,1,1,44.56);
insert into pedidos(motoristaId,clienteId,platoId,cantidad,precio)
	values (2,2,2,2,80.56);
insert into pedidos(motoristaId,clienteId,platoId,cantidad,precio)
	values (3,3,1,1,40.56);
	select * from pedidos;
insert into platos (nombrePlato,precio)
	values('desayuno tipico',8.99);
insert into platos (nombrePlato,precio)
	values('almuerzo tipico',12.99);
insert into platos (nombrePlato,precio)
	values('pupusa FQ',1.50);
	select * from platos;
insert into clientes (nombreCliente,direccion)
	values('Gerson Gomez','metapan');
insert into clientes (nombreCliente,direccion)
	values('Daniel martinez','santa ana');
insert into clientes (nombreCliente,direccion)
	values('pc components','parque libertad');
	select * from clientes;
insert into motoristas(nombreMotorista)
values('karlos')
insert into motoristas(nombreMotorista)
values('alex')
insert into motoristas(nombreMotorista)
values('carrillos')
insert into motoristas(nombreMotorista)
values('gomez')
select * from motoristas;
