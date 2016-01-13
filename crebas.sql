/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2015/10/17 17:07:37                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tab_EexpertCert') and o.name = 'FK_TAB_EEXP_REFERENCE_TAB_USER')
alter table dbo.Tab_EexpertCert
   drop constraint FK_TAB_EEXP_REFERENCE_TAB_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tab_TrainterCert') and o.name = 'FK_TAB_TRAI_REFERENCE_TAB_USER')
alter table dbo.Tab_TrainterCert
   drop constraint FK_TAB_TRAI_REFERENCE_TAB_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.tab_TestItem') and o.name = 'FK_TAB_TEST_REFERENCE_TAB_USER')
alter table dbo.tab_TestItem
   drop constraint FK_TAB_TEST_REFERENCE_TAB_USER
go

alter table dbo.Tab_Dict
   drop constraint PK_TAB_DICT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Tab_Dict')
            and   type = 'U')
   drop table dbo.Tab_Dict
go

alter table dbo.Tab_EexpertCert
   drop constraint PK_TAB_EEXPERTCERT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Tab_EexpertCert')
            and   type = 'U')
   drop table dbo.Tab_EexpertCert
go

alter table dbo.Tab_ExpertCertTemp1
   drop constraint PK_TAB_EXPERTCERTTEMP1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Tab_ExpertCertTemp1')
            and   type = 'U')
   drop table dbo.Tab_ExpertCertTemp1
go

alter table dbo.Tab_TrainterCert
   drop constraint PK_TAB_TRAINTERCERT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Tab_TrainterCert')
            and   type = 'U')
   drop table dbo.Tab_TrainterCert
go

alter table dbo.Tab_User
   drop constraint PK_TAB_USER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Tab_User')
            and   type = 'U')
   drop table dbo.Tab_User
go

alter table dbo.tab_InfoRight
   drop constraint PK_TAB_INFORIGHT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_InfoRight')
            and   type = 'U')
   drop table dbo.tab_InfoRight
go

alter table dbo.tab_ResourceFile
   drop constraint PK_TAB_RESOURCEFILE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_ResourceFile')
            and   type = 'U')
   drop table dbo.tab_ResourceFile
go

alter table dbo.tab_SeedLibrary
   drop constraint PK_TAB_SEEDLIBRARY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_SeedLibrary')
            and   type = 'U')
   drop table dbo.tab_SeedLibrary
go

alter table dbo.tab_TestItem
   drop constraint PK_TAB_TESTITEM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_TestItem')
            and   type = 'U')
   drop table dbo.tab_TestItem
go

alter table dbo.tab_TrainerCertTemp
   drop constraint PK_TAB_TRAINERCERTTEMP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_TrainerCertTemp')
            and   type = 'U')
   drop table dbo.tab_TrainerCertTemp
go

alter table dbo.tab_consult
   drop constraint PK_TAB_CONSULT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_consult')
            and   type = 'U')
   drop table dbo.tab_consult
go

alter table dbo.tab_expression
   drop constraint PK_TAB_EXPRESSION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_expression')
            and   type = 'U')
   drop table dbo.tab_expression
go

alter table dbo.tab_order_TrainExpert
   drop constraint PK_TAB_ORDER_TRAINEXPERT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_order_TrainExpert')
            and   type = 'U')
   drop table dbo.tab_order_TrainExpert
go

alter table dbo.tab_result
   drop constraint PK_TAB_RESULT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_result')
            and   type = 'U')
   drop table dbo.tab_result
go

alter table dbo.tab_user_expert
   drop constraint PK_TAB_USER_EXPERT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_user_expert')
            and   type = 'U')
   drop table dbo.tab_user_expert
go

alter table dbo.tab_user_trainer
   drop constraint PK_TAB_USER_TRAINER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.tab_user_trainer')
            and   type = 'U')
   drop table dbo.tab_user_trainer
go

/*==============================================================*/
/* Table: Tab_Dict                                              */
/*==============================================================*/
create table Tab_Dict (
   ID                   int                  identity,
   Type                 int                  null,
   Code                 varchar(200)         null,
   Parent               int                  null,
   Name                 varchar(300)         null,
   Mark                 varchar(300)         null,
   Sort                 int                  null,
   constraint PK_TAB_DICT primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '基础字典表',
   'user', @CurrentUser, 'table', 'Tab_Dict'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键ID',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类型',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'Type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编码',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'Code'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父级',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'Parent'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名称',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'Mark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序',
   'user', @CurrentUser, 'table', 'Tab_Dict', 'column', 'Sort'
go

/*==============================================================*/
/* Table: Tab_EexpertCert                                       */
/*==============================================================*/
create table Tab_EexpertCert (
   Id                   int                  not null,
   UserId               int                  null,
   AcceptState          int                  null,
   AcceptUserId         int                  null,
   AcceptTime           datetime             null,
   AcceptMessage        varchar(1000)        null,
   ExpertSort           int                  null,
   IDNumber             varchar(50)          null,
   School               varchar(200)         null,
   Education            varchar(200)         null,
   Qualification        varchar(300)         null,
   zyProject            varchar(200)         null,
   yjProject            varchar(300)         null,
   yjResult             varchar(300)         null,
   ServiceArea          varchar(200)         null,
   SelfResume           varchar(1000)        null,
   constraint PK_TAB_EEXPERTCERT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专家认证表',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证状态',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'AcceptState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证操作员',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'AcceptUserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证时间',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'AcceptTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证理由说明',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'AcceptMessage'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专家分类',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'ExpertSort'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'IDNumber'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '毕业学校',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'School'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学历',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'Education'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资质',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'Qualification'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专业领域',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'zyProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '研究方向',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'yjProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '研究成果',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'yjResult'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '服务地区',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'ServiceArea'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '个人简历',
   'user', @CurrentUser, 'table', 'Tab_EexpertCert', 'column', 'SelfResume'
go

/*==============================================================*/
/* Index: index_un_tab_expertcert_userid                        */
/*==============================================================*/
create unique index index_un_tab_expertcert_userid on Tab_EexpertCert (
UserId ASC
)
go

/*==============================================================*/
/* Table: Tab_ExpertCertTemp1                                   */
/*==============================================================*/
create table Tab_ExpertCertTemp1 (
   Id                   int                  identity,
   UserId               int                  null,
   AcceptState          int                  null,
   AcceptUserId         int                  null,
   AcceptTime           datetime             null,
   AcceptMessage        varchar(1000)        null,
   ExpertSort           int                  null,
   IDNumber             varchar(50)          null,
   School               varchar(200)         null,
   Education            varchar(200)         null,
   Qualification        varchar(300)         null,
   zyProject            varchar(200)         null,
   yjProject            varchar(300)         null,
   yjResult             varchar(300)         null,
   ServiceArea          varchar(200)         null,
   SelfResume           varchar(1000)        null,
   constraint PK_TAB_EXPERTCERTTEMP1 primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专家认证信息修改临时表',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证状态',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'AcceptState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证操作员',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'AcceptUserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证时间',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'AcceptTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证理由说明',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'AcceptMessage'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专家分类',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'ExpertSort'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'IDNumber'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '毕业学校',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'School'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学历',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'Education'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资质',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'Qualification'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专业领域',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'zyProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '研究方向',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'yjProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '研究成果',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'yjResult'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '服务地区',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'ServiceArea'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '个人简历',
   'user', @CurrentUser, 'table', 'Tab_ExpertCertTemp1', 'column', 'SelfResume'
go

/*==============================================================*/
/* Index: index_un_tab_expertcert_userid                        */
/*==============================================================*/
create unique index index_un_tab_expertcert_userid on Tab_ExpertCertTemp1 (
UserId ASC
)
go

/*==============================================================*/
/* Table: Tab_TrainterCert                                      */
/*==============================================================*/
create table Tab_TrainterCert (
   Id                   int                  not null,
   UserId               int                  null,
   AcceptState          int                  null,
   AcceptUserId         int                  null,
   AcceptTime           datetime             null,
   AcceptMessage        varchar(1000)        null,
   IDNumber             varchar(50)          null,
   School               varchar(200)         null,
   Education            varchar(200)         null,
   Qualification        varchar(200)         null,
   zyProject            varchar(300)         null,
   ksProject            varchar(300)         null,
   ServiceArea          varchar(200)         null,
   SelfResume           varchar(1000)        null,
   constraint PK_TAB_TRAINTERCERT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '教练认证表',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证状态',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'AcceptState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证操作员',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'AcceptUserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证时间',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'AcceptTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证理由说明',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'AcceptMessage'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'IDNumber'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '毕业学校',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'School'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学历',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'Education'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资质',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'Qualification'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '职业项目',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'zyProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '可授项目',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'ksProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '服务地区',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'ServiceArea'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '个人简历',
   'user', @CurrentUser, 'table', 'Tab_TrainterCert', 'column', 'SelfResume'
go

/*==============================================================*/
/* Index: index_un_tab_trainercert_userid                       */
/*==============================================================*/
create unique index index_un_tab_trainercert_userid on Tab_TrainterCert (
UserId ASC
)
go

/*==============================================================*/
/* Table: Tab_User                                              */
/*==============================================================*/
create table Tab_User (
   Id                   int                  identity,
   Name                 varchar(100)         not null,
   PassWord             varchar(64)          null,
   RealName             varchar(100)         null,
   Photo                varchar(100)         null,
   Six                  int                  null,
   Type                 int                  null,
   Grade                int                  null,
   Phone                varchar(12)          null,
   WeiXin               varchar(101)         null,
   QQ                   varchar(14)          null,
   TowCode              varchar(1000)        null,
   Province             varchar(30)          null,
   Area                 varchar(30)          null,
   Adress               varchar(1000)        null,
   School               varchar(300)         null,
   State                int                  null,
   Mark                 varchar(1000)        null,
   Token                varchar(64)          null,
   CreateTime           datetime             null,
   constraint PK_TAB_USER primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站点用户表',
   'user', @CurrentUser, 'table', 'Tab_User'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户账号',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户密码',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'PassWord'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '真实姓名',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'RealName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户头像',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Photo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Six'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户类别（用户、教练、专家）',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Type'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户等级',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Grade'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '电话',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Phone'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '微信',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'WeiXin'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'QQ'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '二维码',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'TowCode'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属省',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Province'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '区域',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Area'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地址',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Adress'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学校名称',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'School'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'State'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Mark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '建权码',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'Token'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '注册时间',
   'user', @CurrentUser, 'table', 'Tab_User', 'column', 'CreateTime'
go

/*==============================================================*/
/* Index: Index_tab_user_un_name                                */
/*==============================================================*/
create unique index Index_tab_user_un_name on Tab_User (
Name ASC
)
go

/*==============================================================*/
/* Table: tab_InfoRight                                         */
/*==============================================================*/
create table tab_InfoRight (
   RightUId             int                  not null,
   CoverRightUId        int                  not null,
   RightType            int                  not null,
   RightState           int                  null,
   RightTime            datetime             null,
   constraint PK_TAB_INFORIGHT primary key (RightUId, CoverRightUId, RightType)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户数据授权表',
   'user', @CurrentUser, 'table', 'tab_InfoRight'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '授权人id',
   'user', @CurrentUser, 'table', 'tab_InfoRight', 'column', 'RightUId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '被授权人id',
   'user', @CurrentUser, 'table', 'tab_InfoRight', 'column', 'CoverRightUId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型(个人数据、自测数据)',
   'user', @CurrentUser, 'table', 'tab_InfoRight', 'column', 'RightType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限状态',
   'user', @CurrentUser, 'table', 'tab_InfoRight', 'column', 'RightState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '授权时间',
   'user', @CurrentUser, 'table', 'tab_InfoRight', 'column', 'RightTime'
go

/*==============================================================*/
/* Table: tab_ResourceFile                                      */
/*==============================================================*/
create table tab_ResourceFile (
   ID                   int                  identity,
   UId                  int                  null,
   ResourceName         varchar(500)         null,
   ResourceType         varchar(1000)        null,
   ResourceState        int                  null,
   ResourceTime         datetime             null,
   constraint PK_TAB_RESOURCEFILE primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户资源文件表',
   'user', @CurrentUser, 'table', 'tab_ResourceFile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键ID',
   'user', @CurrentUser, 'table', 'tab_ResourceFile', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '关联用户ID',
   'user', @CurrentUser, 'table', 'tab_ResourceFile', 'column', 'UId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资源文件名称',
   'user', @CurrentUser, 'table', 'tab_ResourceFile', 'column', 'ResourceName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资源文件地址',
   'user', @CurrentUser, 'table', 'tab_ResourceFile', 'column', 'ResourceType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资源文件状态',
   'user', @CurrentUser, 'table', 'tab_ResourceFile', 'column', 'ResourceState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资源文件时间',
   'user', @CurrentUser, 'table', 'tab_ResourceFile', 'column', 'ResourceTime'
go

/*==============================================================*/
/* Table: tab_SeedLibrary                                       */
/*==============================================================*/
create table tab_SeedLibrary (
   ID                   int                  identity,
   UseedId              int                  not null,
   AcceptId             int                  null,
   SeedState            int                  null,
   SeedTime             datetime             null,
   SeedContent          varchar(1000)        null,
   constraint PK_TAB_SEEDLIBRARY primary key (ID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学员苗子库表',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键ID',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary', 'column', 'ID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户学员ID',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary', 'column', 'UseedId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '选苗专家ID',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary', 'column', 'AcceptId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '苗子状态',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary', 'column', 'SeedState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '选苗时间',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary', 'column', 'SeedTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '选苗评价说明',
   'user', @CurrentUser, 'table', 'tab_SeedLibrary', 'column', 'SeedContent'
go

/*==============================================================*/
/* Index: index_uni_seed                                        */
/*==============================================================*/
create unique index index_uni_seed on tab_SeedLibrary (
UseedId ASC
)
go

/*==============================================================*/
/* Table: tab_TestItem                                          */
/*==============================================================*/
create table tab_TestItem (
   Id                   int                  not null,
   UserId               int                  null,
   TstBatchId           varchar(100)         null,
   TstSix               int                  null,
   Age                  int                  null,
   Height               int                  null,
   Weight               float                null,
   FatherHeight         int                  null,
   MatherHeight         int                  null,
   "Create"             datetime             null,
   constraint PK_TAB_TESTITEM primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户测试项表',
   'user', @CurrentUser, 'table', 'tab_TestItem'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测试批次号',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'TstBatchId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'TstSix'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '当前年龄',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'Age'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '当前身高',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'Height'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '当前体重',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'Weight'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父亲身高',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'FatherHeight'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '母亲身高',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'MatherHeight'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测试时间',
   'user', @CurrentUser, 'table', 'tab_TestItem', 'column', 'Create'
go

/*==============================================================*/
/* Table: tab_TrainerCertTemp                                   */
/*==============================================================*/
create table tab_TrainerCertTemp (
   Id                   int                  identity,
   UserId               int                  null,
   AcceptState          int                  null,
   AcceptUserId         int                  null,
   AcceptTime           datetime             null,
   AcceptMessage        varchar(1000)        null,
   IDNumber             varchar(50)          null,
   School               varchar(200)         null,
   Education            varchar(200)         null,
   Qualification        varchar(200)         null,
   zyProject            varchar(300)         null,
   ksProject            varchar(300)         null,
   ServiceArea          varchar(200)         null,
   SelfResume           varchar(1000)        null,
   constraint PK_TAB_TRAINERCERTTEMP primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '教练认证信息修改临时表',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Id',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'UserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证状态',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'AcceptState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证操作员',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'AcceptUserId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证时间',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'AcceptTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '认证理由说明',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'AcceptMessage'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'IDNumber'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '毕业学校',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'School'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学历',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'Education'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资质',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'Qualification'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '职业项目',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'zyProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '可授项目',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'ksProject'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '服务地区',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'ServiceArea'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '个人简历',
   'user', @CurrentUser, 'table', 'tab_TrainerCertTemp', 'column', 'SelfResume'
go

/*==============================================================*/
/* Index: index_un_tab_trainercert_userid                       */
/*==============================================================*/
create unique index index_un_tab_trainercert_userid on tab_TrainerCertTemp (
UserId ASC
)
go

/*==============================================================*/
/* Table: tab_consult                                           */
/*==============================================================*/
create table tab_consult (
   ConsultId            int                  not null,
   SpeakerID            int                  null,
   AudienceID           int                  null,
   OccureTime           datetime             null,
   ConsultContent       text                 null,
   ConsultState         int                  null,
   ConsultMark          text                 null,
   constraint PK_TAB_CONSULT primary key (ConsultId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '咨询信息表',
   'user', @CurrentUser, 'table', 'tab_consult'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '咨询表主键ID',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'ConsultId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发信人',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'SpeakerID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '收信人',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'AudienceID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发信时间',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'OccureTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '消息内容',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'ConsultContent'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '消息状态（是否阅读）',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'ConsultState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tab_consult', 'column', 'ConsultMark'
go

/*==============================================================*/
/* Table: tab_expression                                        */
/*==============================================================*/
create table tab_expression (
   ExpressionId         int                  not null,
   ExpressionCN         varchar(500)         null,
   ExpressionEN         varchar(500)         null,
   Expressioncxj        varchar(500)         null,
   Expressionlm         varchar(500)         null,
   ExpressionVersion    varchar(20)          null,
   ExpressionState      int                  null,
   constraint PK_TAB_EXPRESSION primary key (ExpressionId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评公式表',
   'user', @CurrentUser, 'table', 'tab_expression'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评公式主键ID',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'ExpressionId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '中文名称',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'ExpressionCN'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '英文名',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'ExpressionEN'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '程序集文件名称',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'Expressioncxj'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '全类名',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'Expressionlm'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'ExpressionVersion'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', @CurrentUser, 'table', 'tab_expression', 'column', 'ExpressionState'
go

/*==============================================================*/
/* Table: tab_order_TrainExpert                                 */
/*==============================================================*/
create table tab_order_TrainExpert (
   OrderId              int                  not null,
   OrderUid             int                  null,
   CoverOrderUid        int                  null,
   OrderTime            datetime             null,
   OrderContent         varchar(1000)        null,
   OrderType            int                  null,
   OrderState           int                  null,
   OrderMark            varchar(2000)        null,
   constraint PK_TAB_ORDER_TRAINEXPERT primary key (OrderId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邀请预约表',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邀请预约主键ID',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邀请预约人',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderUid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '被邀请预约人',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'CoverOrderUid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邀请预约时间',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邀请预约内容',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderContent'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类型（预约、邀请）',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邀请预约状态',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderState'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tab_order_TrainExpert', 'column', 'OrderMark'
go

/*==============================================================*/
/* Table: tab_result                                            */
/*==============================================================*/
create table tab_result (
   ResultId             int                  not null,
   TstBatchId           varchar(200)         null,
   ExpressionId         int                  null,
   TstResult            decimal              null,
   ResultTime           datetime             null,
   constraint PK_TAB_RESULT primary key (ResultId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评结果表',
   'user', @CurrentUser, 'table', 'tab_result'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评结果主键ID',
   'user', @CurrentUser, 'table', 'tab_result', 'column', 'ResultId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测试批次号',
   'user', @CurrentUser, 'table', 'tab_result', 'column', 'TstBatchId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评公式编号',
   'user', @CurrentUser, 'table', 'tab_result', 'column', 'ExpressionId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评结果',
   'user', @CurrentUser, 'table', 'tab_result', 'column', 'TstResult'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '测评时间',
   'user', @CurrentUser, 'table', 'tab_result', 'column', 'ResultTime'
go

/*==============================================================*/
/* Table: tab_user_expert                                       */
/*==============================================================*/
create table tab_user_expert (
   UexpertId            int                  not null,
   UId                  int                  null,
   ExpertId             int                  null,
   Ustate               int                  null,
   Umark                varchar(200)         null,
   constraint PK_TAB_USER_EXPERT primary key (UexpertId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户的专家表',
   'user', @CurrentUser, 'table', 'tab_user_expert'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户专家主键ID',
   'user', @CurrentUser, 'table', 'tab_user_expert', 'column', 'UexpertId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '关联用户id',
   'user', @CurrentUser, 'table', 'tab_user_expert', 'column', 'UId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '关联专家id',
   'user', @CurrentUser, 'table', 'tab_user_expert', 'column', 'ExpertId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态(正式专家、关注、收藏)',
   'user', @CurrentUser, 'table', 'tab_user_expert', 'column', 'Ustate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tab_user_expert', 'column', 'Umark'
go

/*==============================================================*/
/* Table: tab_user_trainer                                      */
/*==============================================================*/
create table tab_user_trainer (
   UtrainerId           int                  not null,
   UId                  int                  null,
   TrainerId            int                  null,
   Ustate               int                  null,
   Umark                varchar(200)         null,
   constraint PK_TAB_USER_TRAINER primary key (UtrainerId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户的教练表',
   'user', @CurrentUser, 'table', 'tab_user_trainer'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户教练主键ID',
   'user', @CurrentUser, 'table', 'tab_user_trainer', 'column', 'UtrainerId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '关联用户ID',
   'user', @CurrentUser, 'table', 'tab_user_trainer', 'column', 'UId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '关联教练ID',
   'user', @CurrentUser, 'table', 'tab_user_trainer', 'column', 'TrainerId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态(正式教练、关注、收藏)',
   'user', @CurrentUser, 'table', 'tab_user_trainer', 'column', 'Ustate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tab_user_trainer', 'column', 'Umark'
go

alter table Tab_EexpertCert
   add constraint FK_TAB_EEXP_REFERENCE_TAB_USER foreign key (UserId)
      references Tab_User (Id)
go

alter table Tab_TrainterCert
   add constraint FK_TAB_TRAI_REFERENCE_TAB_USER foreign key (UserId)
      references Tab_User (Id)
go

alter table tab_TestItem
   add constraint FK_TAB_TEST_REFERENCE_TAB_USER foreign key (UserId)
      references Tab_User (Id)
go

