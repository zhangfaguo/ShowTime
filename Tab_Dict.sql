/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2015/10/17 16:31:28                          */
/*==============================================================*/


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

