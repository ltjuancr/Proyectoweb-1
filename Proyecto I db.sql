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
drop table clients

CREATE TABLE client
(
	 [id] int  identity,
	 [identification] varchar (50) not null,
	 [name] varchar (50) not null,
	 [last_name] varchar (50) null,
	 [phone] varchar (50) null,
	 [email] varchar (50) null,
	[address] varchar (50) null,--direccion de entrega
	 constraint pk_client primary key (id)	
);


--TABLE PEDIDO

CREATE TABLE requisition
(
	 [id] int identity,
	 [client] int not null,--pedido de cliente
	 [description] varchar(1000) null ,
	 [state] varchar (50) null ,
	 [date] varchar (50)null ,	
	 [amount_total] int null , --monto
     [total_taxes] int null, --impuestos
     [total_withTaxes] int null , 
     [EMPLOYEE] int null,
	 constraint pk_requisition primary key (id),
	 constraint fk_client1 foreign key (client) references client(id),
	 constraint fk_EMPLOYEE1 foreign key (EMPLOYEE) references EMPLOYEE(id)
);

CREATE TABLE detailRequisition
(
	 [id] int identity,
	 [product] int not null, 	 
	 [amount] int null, 
	 [price] int null ,
	 [requisition] int not null,	 
	 constraint pk_detailRequisition primary key (id),
	 constraint fk_requisition foreign key (requisition) references requisition (id),
	 constraint fk_product foreign key (product) references product(id)
);

CREATE TABLE [route]
(
	 [id] int identity,
	 [origin] varchar(100) null,
	 [destination]varchar(100) null,
	 [description] varchar(1000) null,
	 [address] varchar(1000) null,
	 [state] varchar (50) null,
	 [requisition] int null,
	 constraint pk_routes primary key (id),
	 constraint fk_requisition1 foreign key (requisition) references requisition(id)
);

CREATE TABLE purchaseOrder
(
	 [id] int identity,
	 [supplier] int not null,--pedido de proveedor
	 [description] varchar(1000) null,
	 [state] varchar (10) null,
	 [date] varchar (10)null,	 
	 constraint pk_purchaseOrder primary key (id),
	 constraint fk_supplier1 foreign key (supplier) references supplier(id)
);

CREATE TABLE detailPurchaseOrder
(
	 [id] int identity,
	 [product] int not null, 	 
	 [amount] int null, 
	 [price] int null ,
	 [purchaseOrder] int not null,	 
	 constraint pk_detailPurchaseOrder primary key (id),
	 constraint fk_purchaseOrder foreign key (purchaseOrder) references purchaseOrder(id),
	 constraint fk_product1 foreign key (product) references product(id)
);



--TABLE FACTURAS
CREATE TABLE bill
(
	 [id] int identity,
	 [client] int not null,
 	 [payment_term] varchar (50) null, --plazo para pagar
     [date] date null,  
     [amount_total] int , --monto
     [total_taxes] int , --impuestos
     [total_withTaxes] int ,	 
     [state] varchar (50) null,
	 constraint pk_bill primary key (id),
	 constraint fk_client_bill foreign key (client) references client(id),	
);

CREATE TABLE detailBill
(
	 [id] int identity,
	 [bill]int null,
	 [product] int not null, 	 
	 [amount] int null, 
	 [price] int null ,
	 constraint pk_datailBill primary key (id),
	 constraint fk_product2 foreign key (product) references product(id),
	  constraint fk_bill foreign key (bill) references bill(id)	
);



--TABLE CUENTAS POR PAGAR
CREATE TABLE accounts_payable
(
	 [id] int identity,
	 [purchaseOrder] int not null, --codigo de factura
	 [supplier] int not null, --proveedor a pagar
	 [date] date null,
	 [balance] float null,
     [outstanding_balance] float null, --saldo pendiente	 
	 [state] varchar (50) null, 
	 [made_by] varchar (50) null, --hecha por
	 constraint pk_accounts_payable primary key (id),
	 constraint fk_purchaseOrder1 foreign key (purchaseOrder) references purchaseOrder (id),
	 constraint fk_supplier_payable foreign key (supplier) references supplier(id)
);



--TABLE CUENTAS POR COBRAR
CREATE TABLE accounts_receivable
(
	 [id] int identity,
	 [bill] int not null, --codigo de factura
	 [client] int not null, --cliente deudor
	 [balance] float null,
     [outstanding_balance] float null, --saldo pendiente
	 [credit_time] varchar (50) null, 
	 [date] date null,
	 [state] varchar (50) null, 
	 [made_by] varchar (50) null, --hecha por
	 constraint pk_accounts_receivable primary key (id),
	 constraint fk_bill_rece foreign key (bill) references bill(id),
	 constraint fk_client_rece foreign key (client) references client(id)

);



