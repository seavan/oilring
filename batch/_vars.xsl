<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
	<xsl:param name="TABLE" select="TABLE"/>
  <xsl:param name="PROJECT_NAME" select="PROJECT_NAME"/>
	<xsl:param name="CLASS"><xsl:value-of select="$TABLE"></xsl:value-of>Object</xsl:param>		
	<xsl:param name="OBJECT"><xsl:value-of select="$TABLE"></xsl:value-of>Object</xsl:param>			
	<xsl:param name="ENUMERABLE">IEnumerable&lt;<xsl:value-of select="$TABLE"></xsl:value-of>Object&gt;</xsl:param>				
	<xsl:param name="SERVICE"><xsl:value-of select="$TABLE"></xsl:value-of>Service</xsl:param>		
	<xsl:param name="GRID"><xsl:value-of select="$TABLE"></xsl:value-of>Grid</xsl:param>			
	<xsl:param name="CONTROLLER"><xsl:value-of select="$TABLE"></xsl:value-of>Controller</xsl:param>	
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
    <msxsl:script language="JScript" implements-prefix="msxsl_fun">
    <![CDATA[
       function today()
       {
          return (new Date()).toString(); 
       } 
       
       function replace(src, a, b)
		{
			return src;
			var s = '' + src;
			return s.replace('a', 'b');
		}
]]>		
    </msxsl:script> 	
 
</xsl:stylesheet>
