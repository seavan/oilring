<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
	<xsl:include href="_vars.xsl"/>
	<xsl:template match="/">&lt;&#37;&#64; Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" UICulture="ru-RU" %&gt;
&lt;asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"&gt;
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
					<xsl:apply-templates select="linq:Table/linq:Type[@Name=$TABLE]"/>
	</xsl:template>
<xsl:template match="linq:Type">	
    &lt;%=
        Html.Partial("<xsl:value-of select="$GRID"/>", ViewData)%&gt;
&lt;/asp:Content&gt;
</xsl:template>
</xsl:stylesheet>