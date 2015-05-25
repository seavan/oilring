<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"  xmlns:linq="http://schemas.microsoft.com/linqtosql/dbml/2007"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
	<xsl:param name="FILENAME" select="FILENAME"/>
  <xsl:param name="PROJECT_NAME" select="PROJECT_NAME"/>
	<xsl:param name="STUBS_DIR">stubs\</xsl:param>	
	<xsl:param name="STORE_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.database\</xsl:param>		
	<xsl:param name="OBJECTS_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.database\Entities\</xsl:param>
	<xsl:param name="INTERFACES_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.database\Interfaces\</xsl:param>	
	<xsl:param name="SERVICES_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.database\Implementation\</xsl:param>
	<xsl:param name="META_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.database\Metadata\</xsl:param>
	<xsl:param name="CONTROLLER_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.web.common\Controllers\</xsl:param>
	<xsl:param name="ADMIN_CONTROLLER_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.admin\Controllers\</xsl:param>
	<xsl:param name="USER_CONTROLLER_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.front\Controllers\</xsl:param>			
	<xsl:param name="ADMIN_VIEW_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.admin\Views\</xsl:param>
	<xsl:param name="ADMIN_GRID_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.admin\Views\Shared\</xsl:param>		
	<xsl:param name="USER_VIEW_DIR">..\trunk\<xsl:value-of select="translate($PROJECT_NAME, $uppercase, $smallcase)" />.front\Views\</xsl:param>	
	<xsl:output method="text" version="1.0" encoding="UTF-8" indent="no"/>
	<xsl:strip-space elements="*"/>
  <xsl:variable name="smallcase" select="'abcdefghijklmnopqrstuvwxyz'" />
  <xsl:variable name="uppercase" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'" />
	<xsl:template match="/">	
		<xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Database">
    <!-- del <xsl:value-of select="$OBJECTS_DIR"/>*.object.cs	
del <xsl:value-of select="$SERVICES_DIR"/>*.service.cs
del <xsl:value-of select="$META_DIR"/>*.meta.cs
del <xsl:value-of select="$CONTROLLER_DIR"/>*.controller.cs
del <xsl:value-of select="$ADMIN_CONTROLLER_DIR"/>*.controller.cs
del <xsl:value-of select="$USER_CONTROLLER_DIR"/>*.controller.cs -->

<!-- msxsl <xsl:value-of select="$FILENAME"/> admin_menu.xsl FILENAME=<xsl:value-of select="$FILENAME"/> &gt; <xsl:value-of select="$ADMIN_GRID_DIR"/>Menu.ascx -->
    msxsl <xsl:value-of select="$FILENAME"/> store.xsl FILENAME=<xsl:value-of select="$FILENAME"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$STORE_DIR"/>DataServiceLocator.cs
    msxsl <xsl:value-of select="$FILENAME"/> istore.xsl FILENAME=<xsl:value-of select="$FILENAME"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$STORE_DIR"/>IDataServiceLocator.cs

    msxsl <xsl:value-of select="$FILENAME"/> context.xsl FILENAME=<xsl:value-of select="$FILENAME"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$STORE_DIR"/><xsl:value-of select="$PROJECT_NAME"/>.impl.cs

    <xsl:apply-templates/>
	</xsl:template>
	<xsl:template match="linq:Table[not(starts-with(linq:Type/@Name, '_'))]">
<!-- stubs -->	

REM msxsl <xsl:value-of select="$FILENAME"/> stub.xsl FILENAME=<xsl:value-of select="$FILENAME"/> NAMESPACE="admin.common" CLASS=<xsl:value-of select="linq:Type/@Name"/>Service &gt; <xsl:value-of select="$STUBS_DIR"/><xsl:value-of select="linq:Type/@Name"/>Service.cs
REM msxsl <xsl:value-of select="$FILENAME"/> stub.xsl FILENAME=<xsl:value-of select="$FILENAME"/> NAMESPACE="admin" CLASS=<xsl:value-of select="linq:Type/@Name"/>Controller &gt; <xsl:value-of select="$STUBS_DIR"/><xsl:value-of select="linq:Type/@Name"/>Controller.cs
<!-- end stub -->

java -jar saxon\saxon9he.jar -s:<xsl:value-of select="$FILENAME"/> -xsl:objects.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$OBJECTS_DIR"/><xsl:value-of select="linq:Type/@Name"/>.object.cs

msxsl <xsl:value-of select="$FILENAME"/> services.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$SERVICES_DIR"/><xsl:value-of select="linq:Type/@Name"/>.service.cs
msxsl <xsl:value-of select="$FILENAME"/> iservices.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$INTERFACES_DIR"/>I<xsl:value-of select="linq:Type/@Name"/>.service.cs

msxsl <xsl:value-of select="$FILENAME"/> meta.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$META_DIR"/><xsl:value-of select="linq:Type/@Name"/>.meta.cs

msxsl <xsl:value-of select="$FILENAME"/> controller.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$CONTROLLER_DIR"/><xsl:value-of select="linq:Type/@Name"/>.controller.cs

msxsl <xsl:value-of select="$FILENAME"/> admin_controller.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$ADMIN_CONTROLLER_DIR"/><xsl:value-of select="linq:Type/@Name"/>.controller.cs

msxsl <xsl:value-of select="$FILENAME"/> user_controller.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> PROJECT_NAME=<xsl:value-of select="$PROJECT_NAME"/> &gt; <xsl:value-of select="$USER_CONTROLLER_DIR"/><xsl:value-of select="linq:Type/@Name"/>.controller.cs

mkdir <xsl:value-of select="$ADMIN_VIEW_DIR"/>\<xsl:value-of select="linq:Type/@Name"/>
msxsl <xsl:value-of select="$FILENAME"/> admin_view.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$ADMIN_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\Index.aspx
msxsl <xsl:value-of select="$FILENAME"/> admin_grid.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$ADMIN_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\<xsl:value-of select="linq:Type/@Name"/>Grid.sample.ascx

mkdir <xsl:value-of select="$USER_VIEW_DIR"/>\<xsl:value-of select="linq:Type/@Name"/>
msxsl <xsl:value-of select="$FILENAME"/> user_view_list.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\List.sample.aspx
msxsl <xsl:value-of select="$FILENAME"/> user_view_single.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\Single.sample.aspx
msxsl <xsl:value-of select="$FILENAME"/> user_view_list_widget.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\ListWidget.sample.ascx
msxsl <xsl:value-of select="$FILENAME"/> user_view_list_widget.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\ListItems.sample.ascx
msxsl <xsl:value-of select="$FILENAME"/> user_view_single_widget.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\SingleWidget.sample.ascx
msxsl <xsl:value-of select="$FILENAME"/> user_view_single_widget.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\SingleItem.sample.ascx
msxsl <xsl:value-of select="$FILENAME"/> user_view_search_result.xsl FILENAME=<xsl:value-of select="$FILENAME"/> TABLE=<xsl:value-of select="linq:Type/@Name"/> &gt; <xsl:value-of select="$USER_VIEW_DIR"/><xsl:value-of select="linq:Type/@Name"/>\SearchResult.sample.ascx

	</xsl:template>
</xsl:stylesheet>

