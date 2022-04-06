drop database simpleCrud;

create database simpleCrud;

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

insert into tb_usuario values (null, "Carlos", "carlos@email.com", "71634047001", "13912345678", "carlos", "f9fae8edc4c43f2bdf83b5f3c37a80d8f3c73f559785889e606387be23558867");
insert into tb_usuario values (null, "Pedro", "pedro@email.com", "64605466061", "13912345678", "pedro", "f9fae8edc4c43f2bdf83b5f3c37a80d8f3c73f559785889e606387be23558867");
insert into tb_usuario values (null, "Júlia", "batata@email.com", "73350179045", "13912345678", "julia", "f9fae8edc4c43f2bdf83b5f3c37a80d8f3c73f559785889e606387be23558867");
insert into tb_usuario values (null, "Fernanda", "fernanda@email.com", "78910756039", "13912345678", "fernanda", "f9fae8edc4c43f2bdf83b5f3c37a80d8f3c73f559785889e606387be23558867");
insert into tb_usuario values (null, "Lucas", "lucas@email.com", "49770370061", "13912345678", "lucas", "f9fae8edc4c43f2bdf83b5f3c37a80d8f3c73f559785889e606387be23558867");