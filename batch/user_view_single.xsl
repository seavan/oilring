<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" >
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
	<xsl:include href="_vars.xsl"/>
	<xsl:template match="/">&lt;&#37;&#64; Page Language="C#" Inherits="System.Web.Mvc.ViewPage&lt;<xsl:value-of select="$OBJECT"/>&gt;"  MasterPageFile="~/Views/Shared/MainInner.master" %&gt;	
		<xsl:apply-templates/>
	</xsl:template>	
</xsl:stylesheet>
