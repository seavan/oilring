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
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	<xsl:value-of select="$TABLE"/>
	File name: 	<xsl:value-of select="$TABLE"/>.service.cs
*/
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
					<xsl:apply-templates select="linq:Table/linq:Type[@Name=$TABLE]"/>
	</xsl:template>
<xsl:template match="linq:Type">

  using System;
  using System.Linq;
  using System.Data.Linq;
  using System.ComponentModel.DataAnnotations;
  using System.Collections.Generic;
  using Database.Implementation;
  using Database.Entities;
  using <xsl:value-of select="$PROJECT_NAME"/>.Database.Interfaces;
  using <xsl:value-of select="$PROJECT_NAME"/>.Database.Entities;

  namespace <xsl:value-of select="$PROJECT_NAME"/>.Database.Implementation
  {
  public partial class <xsl:value-of select="$CLASS"/> : DataService&lt;<xsl:value-of select="$TABLE"/>, <xsl:value-of select="$OBJECT"/>, <xsl:value-of select="$OBJECT"/>.Converter&gt;, <xsl:value-of select="$INTERFACE"/>
    {
      public override IEnumerable&lt;IDatabaseEntity&gt; UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List&lt;IDatabaseEntity&gt;();
          var thisObj = s.GetTable&lt;<xsl:value-of select="$TABLE"/>&gt;().Single( obj => obj.Id.Equals(_id) );
        <xsl:if test="count(.//linq:Association[@IsForeignKey]) > 0">
          <xsl:for-each select=".//linq:Association[@IsForeignKey]">
            if( thisObj.<xsl:value-of select="@Member"/> != null )
              {
                //var conv<xsl:value-of select="@Type"/> = <xsl:value-of select="@Type"/>Object.Converter.FULL_CONVERT;
                //res.Add(conv<xsl:value-of select="@Type"/>(thisObj.<xsl:value-of select="@Member"/>));

                res.Add(thisObj.<xsl:value-of select="@Member"/>);
            }

          </xsl:for-each>
        </xsl:if>
        return res;
      }
    }
}	
</xsl:template>
</xsl:stylesheet>
