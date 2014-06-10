create database SalePoint

use SalePoint
go

create table postType(
 [id] int identity,
 [description] text,
 constraint pk_postId primary key (id)
)

insert into postType values ('Chofer');
insert into postType values ('Administrador');
insert into postType values ('Encargado');

select * from postType;
--drop table postType
--drop table EMPLOYEES

CREATE TABLE EMPLOYEE(
     [id] int  identity,
	 [identification] varchar (50) not null,
	 [name] varchar (50) not null,
	 [last_name] varchar (50) null,
	 [age] int null,
	 [license] varchar (50) null,
	[password] varchar (100) null,
	 [phone] varchar (50) null,
	 [postType] int null,
	 [salary] int null,
	 [address] varchar (50) null,
	 [email] varchar (50) null,
	 constraint pk_people primary key (id),
	 constraint fk_post foreign key (postType) references postType (id)
);

insert into EMPLOYEE values ('2710785','Juan','Quiros Gonzalez',20,'si','1234','88078162',1,240000,'600mts sur de la iglesia catolica','Juan_gonzalez93@hotmail.com');
select * from EMPLOYEE;

--DROP table 
--TABLA FAMILIA_PRODUCTO ya que cada producto se clasifica dentro de una familia, la cual define el tipo del producto
CREATE TABLE family_product
(
	 [id] int  identity,
	 [description] text,
	 constraint pk_family_product primary key (id)
);

insert into family_product values('Tuberculos');
insert into family_product values('Legumbres');



CREATE TABLE requisition_type
(
	 requisitionType_id int not null,
	 name_type varchar (100) null,
   	 id_person varchar (50) not null,
	 constraint pk_requisition_type primary key (requisitionType_id),
     constraint fk_person foreign key (id_person) references EMPLOYEES (identification)
);

--TABLA PROVEEDORES, INDENTIFICA AL PROVEEDOR 
CREATE TABLE supplier 
(
    [id] int identity,
  	 [legalIdentification_card] varchar (50) not null,
	 [company] varchar (50) null,
     [account] varchar (50) null,
      [phone] varchar (50) null,
      [address] varchar (50) null,
       [email] varchar (50) null,
	 constraint pk_supplier primary key (id)	
);
drop table supplier

DROP table product
--TABLE ARTICLES O PRODUCTS
CREATE TABLE product
(
	[id] int identity,
	[code]int not null,
	 [familyProduct] int not null,
	 [product_name] varchar (50) null,
     [unit_price] float null,
	 [expiration] date null,
	 [existence] float null,
	 [minimum] int not null,
	[supplier] int not null,--mayor proveedor
	 constraint pk_products primary key (id),
	 constraint fk_familyProduct foreign key (familyProduct) references family_product (id),
	 constraint fk_supplier foreign key (supplier) references supplier (id)
);


----------------------------------------------------------------------------------------------------------
--TABLE PEDIDOS
CREATE TABLE requisition
(
	 requisition_id int identity,
	 requisition_type int not null,--pedido de cliente/ a proveedor
	 product_code int not null, 	 
	 quantity_toBuy int null,
	 description varchar(1000) null,
	 order_priority varchar (10) null,
	 state varchar (10) null,	 
	 bill_code int,--codigo factura
	 constraint pk_requisition primary key (requisition_id),
	 constraint fk_product_requi foreign key (product_code) references products (product_id),
	 constraint fk_type foreign key (requisition_type) references requisition_type (requisitionType_id),
	 constraint fk_bill_requi foreign key (bill_code) references bills (bill_id)	
);

drop table clients

CREATE TABLE clients
(
	 client_id int identity,
	 id_person varchar (50) not null,
	 delivery_address varchar (50) null,--direccion de entrega
	 constraint pk_clients primary key (client_id),
	
);



CREATE TABLE route_s
(
	 route_id int identity,
	 nombre_bodega varchar(50) null,
	 origin varchar(100) null,
	 destination varchar(100) null,
	 description varchar(1000) null,
	 address varchar(1000) null,
	 load_download varchar (50) null,
	 state varchar (50) null,
	 employees_id varchar (50) not null,--Transportista
     order_cod int not null,--pedido
     client_id int not null,
	 constraint pk_routes primary key (route_id),
	 constraint fk_employees foreign key (employees_id) references EMPLOYEES(identification),
	 constraint fk_order foreign key (order_cod) references requisition(requisition_id),
	 constraint fk_client foreign key (client_id) references clients (client_id)
);



--TABLE FACTURAS
CREATE TABLE bills
(
	 bill_id int identity,
	 id_client int  not null,
	 person_name varchar (50) not null,
	 present_date date null,
 	 ddescription varchar(1000) null, --factura a cliente o compra provee
 	 payment_term varchar (50) null, --plazo para pagar
     payment_date date null, 
     product_code int not null,
     product_name varchar (50) null,
     amount int null, --cantidad
     price  int , 
     amount_total int , --monto
     total_taxes int , --impuestos
     total_withTaxes int ,	 
     sstate varchar (50) null,
	 constraint pk_bills primary key (bill_id),
	 constraint fk_client_bill foreign key (id_client) references clients(client_id),
	 constraint fk_product foreign key (product_code) references products (product_id)	
);



--TABLE CUENTAS POR PAGAR
CREATE TABLE accounts_payable
(
	 accountsPayable_code int identity,
	 purchase_code int not null, --codigo de compra
	 pay_supplier int not null, --proveedor a pagar
	 was_paid float null, --se pagó
     outstanding_balance float null, --saldo pendiente
	 credit_time varchar (50) null, 
	 present_date date null,
	 sstate varchar (50) null, 
	 pay_date date null,
	 made_by varchar (50) null, --hecha por
	 date_cancellation date null,
	 constraint pk_accounts_payable primary key (accountsPayable_code),
	 constraint fk_purchase foreign key (purchase_code) references bills (bill_id),
	 constraint fk_supplier_payable foreign key (pay_supplier) references suppliers (supplier_id)
);



--TABLE CUENTAS POR COBRAR
CREATE TABLE accounts_receivable
(
	 accountsReceivable_id int identity,
	 purchase_code int not null, --codigo de compra
	 client_debtor int not null, --cliente deudor
	 client_name varchar (50) not null,
	 paid float null, --pagó
     outstanding_balance float null, --saldo pendiente
	 credit_time varchar (50) null, 
	 present_date date null,
	 state varchar (50) null, 
	 pay_date date null,
	 made_by varchar (50) null, --hecha por
	 date_cancellation date null,
	 constraint pk_accounts_receivable primary key (accountsReceivable_id),
	 constraint fk_purchase_rece foreign key (purchase_code) references bills (bill_id),
	 constraint fk_client_rece foreign key (client_debtor) references clients (client_id)

);



--TABLE HISTORIAL DE VENTAS
CREATE TABLE sales_history
(
	 salesHistory_id varchar (50) not null,
	 client_id int not null, 
	 client_name varchar (50) not null,
	 bill_code int not null,
	 present_date date null,
 	 description varchar(1000) null,  	 
     payment_date date null, 
     product_code int not null,
     product_name varchar (50) null,
     total_withTaxes int ,	 
     constraint pk_sales_history primary key (salesHistory_id),
	 constraint fk_client_history foreign key (client_id) references clients (client_id),
	 constraint fk_bill_history foreign key (bill_code) references bills (bill_id),
	 constraint fk_product_history foreign key (product_code) references products (product_id)	
);








--INSERTS
----------------------------------------------------------------------------------------------------------------


-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------



--SELECTS
select * from people;
select * from administrator;
select * from seller;
select * from users;
select * from login;
select * from employees;
select * from post;
select * from drivers;
select * from requisition_type;
select * from family_product;
select * from suppliers;
select * from products;
select * from requisition;
select * from clients;
select * from routes;
select * from bills;
select * from accounts_payable;
select * from accounts_receivable;
select * from sales_history;