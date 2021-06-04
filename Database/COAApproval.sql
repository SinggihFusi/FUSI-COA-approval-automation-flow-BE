-- Table: public.user_accounts

DROP TABLE public.user_accounts;

CREATE TABLE IF NOT EXISTS public.user_accounts
(
    user_id serial not NULL,
    username  VARCHAR(250) NOT NULL,
    password  varchar(250) ,
    email  varchar(250) ,
    role  varchar(250) ,
    id_atasan integer,
    CONSTRAINT user_accounts_pkey PRIMARY KEY (user_id),
    CONSTRAINT user_accounts_username_key UNIQUE (username)
);


	-- Table: public.coa_approval

DROP TABLE public.coa_approval;

CREATE TABLE IF NOT EXISTS public.coa_approval
(
    id serial NOT NULL,
    surveyor_id integer NOT NULL,
    date timestamp without time zone,
    coa_file bytea,
    note  varchar(1000) ,
    status  varchar(50) ,
    pic1_id integer,
    pic1_approval_status  varchar(50) ,
    pic1_note  varchar(1000) ,
    pic2_id integer,
    pic2_approval_status  varchar(50) ,
    pic2_note  varchar(1000) ,
	next_approver integer NULL,
    CONSTRAINT coa_approval_pkey PRIMARY KEY (id)
);

	
INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'admin', 'admin', 'admin@admin.admin', 'admin', null);

INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'user', 'user', 'user@user.user', 'user', 1);

INSERT INTO public.user_accounts(
 username, password, email, role,id_atasan)
VALUES ( 'userAdmin', 'userAdmin', 'userAdmin@userAdmin.userAdmin', 'userAdmin',2);

INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'adminadmin', 'adminadmin', 'adminadmin@admin.admin', 'admin', 2);






INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'PIC_1', 'pic', 'PIC1@PIC.PIC', 'PIC', null);

INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'PIC_2', 'pic', 'PIC1@PIC.PIC', 'PIC', 5);



INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'Surveyor_1', 'surveyor', 'surveyor1@surveyor.surveyor', 'surveyor', 6);

INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'Surveyor_2', 'surveyor', 'surveyor1@surveyor.surveyor', 'surveyor', 7);

INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'Surveyor_3', 'surveyor', 'surveyor1@surveyor.surveyor', 'surveyor', 7);

INSERT INTO public.user_accounts(
 username, password, email, role, id_atasan)
VALUES ( 'Surveyor_4', 'surveyor', 'surveyor1@surveyor.surveyor', 'surveyor', 7);