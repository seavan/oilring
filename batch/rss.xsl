<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
	<xsl:include href="_vars.xsl"/>
	<xsl:template match="/">
		USE oilring;
      DELETE FROM Events;
		<xsl:apply-templates select="//item"/>

	</xsl:template>
	<xsl:template match="newses">
	
					
	</xsl:template>
	<xsl:template match="item">
INSERT INTO Events(Title, ShortDescription, Text) VALUES('<xsl:value-of select="title"></xsl:value-of>', '<xsl:value-of select="subtitle"></xsl:value-of>', '<xsl:value-of select="description"></xsl:value-of>');

	</xsl:template>	

</xsl:stylesheet>