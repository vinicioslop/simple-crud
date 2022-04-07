drop database simplecrud;

create database simplecrud;

use simpleCrud;

create table tb_usuario(
	id_usuario int auto_increment,
    nm_usuario varchar(80) not null,
    nm_email varchar(60) not null,
    nr_cpf char(11) not null,
    nr_telefone char(11) not null,
    login varchar(20) unique not null,
    senha char(64) not null,
    primary key(id_usuario)
);

insert into tb_usuario values (null, "Carlos", "carlos@email.com", "71634047001", "13912345678", "carlos", "b7e94be513e96e8c45cd23d162275e5a12ebde9100a425c4ebcdd7fa4dcd897c");
insert into tb_usuario values (null, "Pedro", "pedro@email.com", "64605466061", "13912345678", "pedro", "b7e94be513e96e8c45cd23d162275e5a12ebde9100a425c4ebcdd7fa4dcd897c");
insert into tb_usuario values (null, "Júlia", "batata@email.com", "73350179045", "13912345678", "julia", "b7e94be513e96e8c45cd23d162275e5a12ebde9100a425c4ebcdd7fa4dcd897c");
insert into tb_usuario values (null, "Fernanda", "fernanda@email.com", "78910756039", "13912345678", "fernanda", "b7e94be513e96e8c45cd23d162275e5a12ebde9100a425c4ebcdd7fa4dcd897c");
insert into tb_usuario values (null, "Lucas", "lucas@email.com", "49770370061", "13912345678", "lucas", "b7e94be513e96e8c45cd23d162275e5a12ebde9100a425c4ebcdd7fa4dcd897c");