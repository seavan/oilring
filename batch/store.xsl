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
    using Microsoft.Practices.Unity;
    using Common.IoC;
    using <xsl:value-of select="$PROJECT_NAME"/>.Database.Interfaces;
    using <xsl:value-of select="$PROJECT_NAME"/>.Database.Implementation;

    namespace <xsl:value-of select="$PROJECT_NAME"/>.Database
  {
  public class DataServiceLocator : IDataServiceLocator
  {
  private readonly IUnityContainer _container;
  <xsl:for-each select="//linq:Table[not(starts-with(linq:Type/@Name, '_'))]">
    private I<xsl:value-of select="linq:Type/@Name"/>Service m_<xsl:value-of select="linq:Type/@Name"/>Service;
    </xsl:for-each>

    public DataServiceLocator()
    {
    _container = MvcUnityContainer.Container;
    <xsl:for-each select="//linq:Table[not(starts-with(linq:Type/@Name, '_'))]">
        m_<xsl:value-of select="linq:Type/@Name"/>Service = _container.Resolve&lt;<xsl:value-of select="linq:Type/@Name"/>Service&gt;();
    </xsl:for-each>
    }
    <xsl:for-each select="//linq:Table[not(starts-with(linq:Type/@Name, '_'))]">
      public I<xsl:value-of select="linq:Type/@Name"/>Service <xsl:value-of select="linq:Type/@Name"/>Service
      {
      get { return m_<xsl:value-of select="linq:Type/@Name"/>Service; }
      }
    </xsl:for-each>
    }
    }

  </xsl:template>
</xsl:stylesheet>

