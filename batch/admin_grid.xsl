<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
	<xsl:include href="_vars.xsl"/>
	<xsl:template match="/">&lt;&#37;&#64; Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %&gt;	
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
					<xsl:apply-templates select="linq:Table/linq:Type[@Name=$TABLE]"/>
	</xsl:template>
<xsl:template match="linq:Type">	
&lt;%
    Html.Telerik().Grid&lt;admin.db.<xsl:value-of select="$OBJECT"/>&gt;()
        .Name("t_<xsl:value-of select="$TABLE"/>")
        .DataBinding(dataBinding =&gt; dataBinding.Ajax().
                                        Select("_Select", "<xsl:value-of select="$TABLE"/>").
                                        Update("_Update", "<xsl:value-of select="$TABLE"/>").
                                        Insert("_Insert", "<xsl:value-of select="$TABLE"/>").
                                        Delete("_Delete", "<xsl:value-of select="$TABLE"/>")
        )
        .DataKeys(keys =&gt; keys.Add("id"))
        .Columns(
            c =&gt;
                {
					<xsl:for-each select="linq:Column">
						c.Bound(col =&gt; col.<xsl:value-of select="@Name"/>).Width(80);
					</xsl:for-each>                                 
					c.Bound( col => col.Id ).Width(100).Edit("<xsl:value-of select="@Name"/>");
                    c.Command(cmd =&gt;
                                  {
                                      cmd.Delete();
                                  }
                        ).Width(100);
                }
        )
        .Editable( s =&gt; s.Mode(GridEditMode.PopUp))
        .Resizable( rs =&gt; rs.Columns(true))
        .Sortable()
        .Filterable()
        .Pageable(
            pager =&gt; pager.PageSize(20)
        )
        .ClientEvents(events =&gt; events.OnEdit("gridEdit"))
        .Render();
%&gt;
&lt;/asp:Content&gt;
</xsl:template>
</xsl:stylesheet>