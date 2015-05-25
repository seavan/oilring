<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"  xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
  <xsl:param name="PROJECT_NAME" select="PROJECT_NAME"/>
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
	<xsl:template match="/">	
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
    using System;
    using <xsl:value-of select="$PROJECT_NAME"/>.Database.Interfaces;

    namespace <xsl:value-of select="$PROJECT_NAME"/>.Database
{
    public interface IDataServiceLocator
    {
				<xsl:apply-templates/>
    }
}
				
	</xsl:template>
	<xsl:template match="linq:Table[not(starts-with(linq:Type/@Name, '_'))]">
        I<xsl:value-of select="linq:Type/@Name"/>Service <xsl:value-of select="linq:Type/@Name"/>Service { get; }
	</xsl:template>
</xsl:stylesheet>

