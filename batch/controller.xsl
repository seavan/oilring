<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:msxsl_fun="urn:ms-xslt-ex">
  <xsl:include href="_vars.xsl"/>
  <xsl:template match="/">
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	<xsl:value-of select="$TABLE"/>
    File name: 	<xsl:value-of select="$TABLE"/>.controller.cs
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
    using <xsl:value-of select="$PROJECT_NAME"/>.Database.Interfaces;

    namespace <xsl:value-of select="$PROJECT_NAME"/>.Web.Common.Controllers
    {
    public partial class <xsl:value-of select="$CONTROLLER"/> : <xsl:value-of select="$PROJECT_NAME"/>BaseUniversalController&lt;<xsl:value-of select="$CLASS"/>&gt;
    {
    protected I<xsl:value-of select="$TABLE"/>Service m_<xsl:value-of select="$TABLE"/>Service;

    protected I<xsl:value-of select="$TABLE"/>Service <xsl:value-of select="$TABLE"/>Service
    {
    get
    {
    if (m_<xsl:value-of select="$TABLE"/>Service == null)
    {
    m_<xsl:value-of select="$TABLE"/>Service = GetService() as I<xsl:value-of select="$TABLE"/>Service;
    }

    return m_<xsl:value-of select="$TABLE"/>Service;
    }
    }
    protected override IDataService&lt;<xsl:value-of select="$CLASS"/>&gt; GetService()
    {
    return DataServiceLocator.<xsl:value-of select="$SERVICE"/>;
    }
    }
    }
  </xsl:template>
</xsl:stylesheet>
