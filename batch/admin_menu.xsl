<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
	<xsl:template match="/">&lt;&#37;&#64; Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" &#37;&gt;	
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
&lt;%
Html.Telerik().Menu()
            .Name("PanelBar")
            .Items(item =>
            {
					<xsl:apply-templates select="linq:Table/linq:Type"/>
			})
        .Render();
%&gt;

	</xsl:template>
<xsl:template match="linq:Type">	
                item.Add()
                    .Text("<xsl:value-of select="@Name"/>").Visible("<xsl:value-of select="@Name"/>".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/<xsl:value-of select="@Name"/>/Single");
                        subItem.Add()
                               .Text("Список")
                               .Url("/<xsl:value-of select="@Name"/>");
                               
                    });
</xsl:template>
</xsl:stylesheet>