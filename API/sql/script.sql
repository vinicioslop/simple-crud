drop database simple_crud;

create database simple_crud;

use simple_crud;

create table usuario(
	id_usuario int auto_increment,
    nm_usuario varchar(80) not null,
    nr_cpf char(11) not null,
    nr_telefone char(11) not null,
    primary key(id_usuario)
);

insert into usuario values (null, "Carlos", "71634047001", "13912345678");
insert into usuario values (null, "Pedro", "64605466061", "13912345678");
insert into usuario values (null, "Júlia", "73350179045", "13912345678");
insert into usuario values (null, "Fernanda", "78910756039", "13912345678");
insert into usuario values (null, "Lucas", "49770370061", "13912345678");