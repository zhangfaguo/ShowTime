<?xml version="1.0" encoding="utf-8"?>
<columns>
#foreach($column in $Table.Columns)
<add name="$column.Name" property="$Helper.StringToPascal($column.Name)"/>
#end
</columns>