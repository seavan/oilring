<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
  <xsl:param name="PROJECT_NAME" select="PROJECT_NAME"/>
	<xsl:param name="TABLE" select="TABLE"/>
	<xsl:param name="OBJECT"><xsl:value-of select="$TABLE"></xsl:value-of>Object</xsl:param>		
	<xsl:param name="CLASS"><xsl:value-of select="$TABLE"></xsl:value-of>Service</xsl:param>	
	<xsl:param name="INTERFACE">I<xsl:value-of select="$TABLE"></xsl:value-of>Service</xsl:param>		
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
    <msxsl:script language="JScript" implements-prefix="msxsl_fun">
       function today()
       {
          return (new Date()).toString(); 
       } 
    </msxsl:script> 	
	<xsl:template match="/">	
/*
	Services interface code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	<xsl:value-of select="$TABLE"/>
	File name: 	<xsl:value-of select="$INTERFACE"/>.interface.cs
*/
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
					<xsl:apply-templates select="linq:Table/linq:Type[@Name=$TABLE]"/>
	</xsl:template>
<xsl:template match="linq:Type">

  using System;
  using System.ComponentModel.DataAnnotations;
  using Database.Interfaces;
  using <xsl:value-of select="$PROJECT_NAME"/>.Database.Entities;

  namespace <xsl:value-of select="$PROJECT_NAME"/>.Database.Interfaces
{
    public partial interface <xsl:value-of select="$INTERFACE"/> : IDataService&lt;<xsl:value-of select="$OBJECT"/>&gt;
    {
    }
}	
</xsl:template>
</xsl:stylesheet>
