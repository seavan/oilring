<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:fn="http://www.w3.org/2005/xpath-functions" >
  <xsl:include href="_vars.xsl"/>
  <xsl:param name="RELCHILD">
    <xsl:value-of select="$TABLE"></xsl:value-of>_
  </xsl:param>
  <xsl:param name="META">
    <xsl:value-of select="$TABLE"></xsl:value-of>Meta
  </xsl:param>
  <xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
  <xsl:strip-space elements="*"/>

  <xsl:template match="/">
    /*
    Business Objects code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	<xsl:value-of select="$TABLE"/>
    File name: 	<xsl:value-of select="$TABLE"/>.object.cs
    */
    <xsl:apply-templates/>
  </xsl:template>
  <xsl:template match="linq:Database">
    <xsl:apply-templates select="linq:Table/linq:Type[@Name=$TABLE]"/>
  </xsl:template>
  <xsl:template match="linq:Association">
    <xsl:param name="CHILDCLASS">
      <xsl:value-of select="@Type"/>Object
    </xsl:param>
    <xsl:param name="CHILDFIELD">
      <xsl:value-of select="@Type"/>s
    </xsl:param>
    <xsl:param name="CHILDCLASSLIST">
      IEnumerable&lt;<xsl:value-of select="@Type"/>Object&gt;
    </xsl:param>
    [ScaffoldColumn(false)]
    public<xsl:text> </xsl:text><xsl:value-of select="$CHILDCLASSLIST"/><xsl:text> </xsl:text><xsl:value-of select="$CHILDFIELD"></xsl:value-of> { get; set; }
  </xsl:template>
  <xsl:template match="linq:Type">

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Linq;
    using Database.Entities;
    using Database.Interfaces;
    using <xsl:value-of select="$PROJECT_NAME"/>.Database.Metadata;

  namespace <xsl:value-of select="$PROJECT_NAME"/>.Database.Entities
  {


  [MetadataTypeAttribute(typeof(<xsl:value-of select="$META"/>))]
    public partial class <xsl:value-of select="$CLASS"/> : DatabaseEntity, IDatabaseEntity
    {
    public <xsl:value-of select="$CLASS"/>()
    {
      ObjectType = "<xsl:value-of select="fn:lower-case($TABLE)"/>";
      <xsl:for-each select="linq:Column[not(@Name='ObjectType') and not (@Name='Lang') and not (@CanBeNull='true') and not(fn:matches(@Name, '_'))]">
        <xsl:if test="@Type='System.String'">
          <xsl:value-of select="@Name"/> = "";
        </xsl:if>
        <xsl:if test="@Type='System.DateTime'">
          <xsl:value-of select="@Name"/> = DateTime.Now;
        </xsl:if>
      </xsl:for-each>
    }



    <xsl:apply-templates select=".//linq:Association[not(@IsForeignKey)]"/>
    <xsl:for-each select=".//linq:Association[@IsForeignKey and fn:matches(@ThisKey, 'REF_')]">
      public <xsl:value-of select="@Type"/>Object <xsl:text> </xsl:text> <xsl:value-of select="fn:replace(@ThisKey, 'REF_|_Id', '')"/> { get; set; }
    </xsl:for-each>


    <xsl:for-each select="linq:Column">
      <xsl:if test="@IsPrimaryKey">
        [Editable(false)]
      </xsl:if>
      public <xsl:value-of select="@Type"/><xsl:if test="@CanBeNull='true' and not(@Type='System.String')">?</xsl:if><xsl:text> </xsl:text><xsl:value-of select="@Name"/> { get; set; }
    </xsl:for-each>

    public class Converter : IConvertibleFactory&lt;<xsl:value-of select="$TABLE"/>, <xsl:value-of select="$CLASS"/>&gt;
    {
    public Converter()
    {
    CONVERT = this.GetConverter().Compile();
    MODEL_CONVERT = this.GetModelConverter();
    }

    #region IConvertibleFactory&lt;<xsl:value-of select="$TABLE"/>, <xsl:value-of select="$CLASS"/>&gt; Members

    public DataLoadOptions GetOptions()
    {
      var dlo = new DataLoadOptions();
    <xsl:for-each select=".//linq:Association[not(@IsForeignKey)]">
      dlo.LoadWith&lt;<xsl:value-of select="$TABLE"/>&gt;( s => s.<xsl:value-of select="@Type"/>s );
    </xsl:for-each>
    return dlo;
    }


    public System.Linq.Expressions.Expression&lt;Func&lt;<xsl:value-of select="$TABLE"/>, <xsl:value-of select="$CLASS"/>&gt;&gt; GetConverter()
    {
    return (db) =&gt; new <xsl:value-of select="$CLASS"/>()
    {
    <xsl:for-each select="linq:Column">
      <xsl:value-of select="@Name"/> = db.<xsl:value-of select="@Name"/>,
    </xsl:for-each>

    };
    }

    public Action&lt;<xsl:value-of select="$CLASS"/>, <xsl:value-of select="$TABLE"/>&gt; GetModelConverter()
    {
    return (param, target) =&gt;
    {
    <xsl:for-each select="linq:Column">
      <xsl:if test="not(@IsPrimaryKey)">
        target.<xsl:value-of select="@Name"/> = param.<xsl:value-of select="@Name"/>;
      </xsl:if>
      <xsl:if test="@Name='ObjectType'">
        if (String.IsNullOrWhiteSpace(target.ObjectType))
        {
        target.<xsl:value-of select="@Name"/> = "<xsl:value-of select="fn:lower-case($TABLE)"/>"; }
      </xsl:if>

    </xsl:for-each>
    };
    }

    #endregion

    public static Converter INST = new Converter();
    public static Func&lt;<xsl:value-of select="$TABLE"/>, <xsl:value-of select="$CLASS"/>&gt; CONVERT;
    public static Action&lt;<xsl:value-of select="$CLASS"/>, <xsl:value-of select="$TABLE"/>&gt; MODEL_CONVERT;

    }
    }
    }
  </xsl:template>
</xsl:stylesheet>
