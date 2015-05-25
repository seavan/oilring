
    msxsl ..\trunk\database\oilring.xml store.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\DataStore.cs
    msxsl ..\trunk\database\oilring.xml istore.xsl FILENAME=..\trunk\database\oilring.xml  > ..\trunk\admin.db\IDataStore.cs
    
    	

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ArticleService > stubs\ArticleService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ArticleController > stubs\ArticleController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin.db\Objects\Article.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin.db\Services\Article.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin.db\Interfaces\IArticle.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin.db\Meta\Article.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin.web.common\Controllers\Article.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin\Controllers\Article.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Controllers\Article.controller.cs

mkdir ..\trunk\admin\Views\\Article
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin\Views\Article\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\admin\Views\Article\ArticleGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Article
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Article > ..\trunk\oilring\Views\Article\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=CommentService > stubs\CommentService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=CommentController > stubs\CommentController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin.db\Objects\Comment.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin.db\Services\Comment.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin.db\Interfaces\IComment.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin.db\Meta\Comment.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin.web.common\Controllers\Comment.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin\Controllers\Comment.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Controllers\Comment.controller.cs

mkdir ..\trunk\admin\Views\\Comment
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin\Views\Comment\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\admin\Views\Comment\CommentGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Comment
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Comment > ..\trunk\oilring\Views\Comment\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ConferenceService > stubs\ConferenceService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ConferenceController > stubs\ConferenceController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin.db\Objects\Conference.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin.db\Services\Conference.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin.db\Interfaces\IConference.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin.db\Meta\Conference.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin.web.common\Controllers\Conference.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin\Controllers\Conference.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Controllers\Conference.controller.cs

mkdir ..\trunk\admin\Views\\Conference
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin\Views\Conference\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\admin\Views\Conference\ConferenceGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Conference
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Conference > ..\trunk\oilring\Views\Conference\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ContactService > stubs\ContactService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ContactController > stubs\ContactController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin.db\Objects\Contact.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin.db\Services\Contact.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin.db\Interfaces\IContact.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin.db\Meta\Contact.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin.web.common\Controllers\Contact.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin\Controllers\Contact.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Controllers\Contact.controller.cs

mkdir ..\trunk\admin\Views\\Contact
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin\Views\Contact\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\admin\Views\Contact\ContactGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Contact
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Contact > ..\trunk\oilring\Views\Contact\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=DiscussionService > stubs\DiscussionService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=DiscussionController > stubs\DiscussionController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin.db\Objects\Discussion.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin.db\Services\Discussion.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin.db\Interfaces\IDiscussion.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin.db\Meta\Discussion.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin.web.common\Controllers\Discussion.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin\Controllers\Discussion.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Controllers\Discussion.controller.cs

mkdir ..\trunk\admin\Views\\Discussion
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin\Views\Discussion\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\admin\Views\Discussion\DiscussionGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Discussion
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Discussion > ..\trunk\oilring\Views\Discussion\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=Dummy_SearchObjectService > stubs\Dummy_SearchObjectService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=Dummy_SearchObjectController > stubs\Dummy_SearchObjectController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin.db\Objects\Dummy_SearchObject.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin.db\Services\Dummy_SearchObject.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin.db\Interfaces\IDummy_SearchObject.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin.db\Meta\Dummy_SearchObject.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin.web.common\Controllers\Dummy_SearchObject.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin\Controllers\Dummy_SearchObject.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Controllers\Dummy_SearchObject.controller.cs

mkdir ..\trunk\admin\Views\\Dummy_SearchObject
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin\Views\Dummy_SearchObject\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\admin\Views\Dummy_SearchObject\Dummy_SearchObjectGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Dummy_SearchObject
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Dummy_SearchObject > ..\trunk\oilring\Views\Dummy_SearchObject\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=EventService > stubs\EventService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=EventController > stubs\EventController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin.db\Objects\Event.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin.db\Services\Event.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin.db\Interfaces\IEvent.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin.db\Meta\Event.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin.web.common\Controllers\Event.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin\Controllers\Event.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Controllers\Event.controller.cs

mkdir ..\trunk\admin\Views\\Event
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin\Views\Event\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\admin\Views\Event\EventGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Event
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Event > ..\trunk\oilring\Views\Event\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=FileAttachmentService > stubs\FileAttachmentService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=FileAttachmentController > stubs\FileAttachmentController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin.db\Objects\FileAttachment.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin.db\Services\FileAttachment.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin.db\Interfaces\IFileAttachment.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin.db\Meta\FileAttachment.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin.web.common\Controllers\FileAttachment.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin\Controllers\FileAttachment.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Controllers\FileAttachment.controller.cs

mkdir ..\trunk\admin\Views\\FileAttachment
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin\Views\FileAttachment\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\admin\Views\FileAttachment\FileAttachmentGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\FileAttachment
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=FileAttachment > ..\trunk\oilring\Views\FileAttachment\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=GrantService > stubs\GrantService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=GrantController > stubs\GrantController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin.db\Objects\Grant.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin.db\Services\Grant.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin.db\Interfaces\IGrant.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin.db\Meta\Grant.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin.web.common\Controllers\Grant.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin\Controllers\Grant.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Controllers\Grant.controller.cs

mkdir ..\trunk\admin\Views\\Grant
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin\Views\Grant\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\admin\Views\Grant\GrantGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Grant
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Grant > ..\trunk\oilring\Views\Grant\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=JournalService > stubs\JournalService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=JournalController > stubs\JournalController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin.db\Objects\Journal.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin.db\Services\Journal.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin.db\Interfaces\IJournal.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin.db\Meta\Journal.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin.web.common\Controllers\Journal.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin\Controllers\Journal.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Controllers\Journal.controller.cs

mkdir ..\trunk\admin\Views\\Journal
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin\Views\Journal\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\admin\Views\Journal\JournalGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Journal
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Journal > ..\trunk\oilring\Views\Journal\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=LanguageService > stubs\LanguageService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=LanguageController > stubs\LanguageController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin.db\Objects\Language.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin.db\Services\Language.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin.db\Interfaces\ILanguage.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin.db\Meta\Language.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin.web.common\Controllers\Language.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin\Controllers\Language.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Controllers\Language.controller.cs

mkdir ..\trunk\admin\Views\\Language
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin\Views\Language\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\admin\Views\Language\LanguageGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Language
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Language > ..\trunk\oilring\Views\Language\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=MessageTemplateService > stubs\MessageTemplateService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=MessageTemplateController > stubs\MessageTemplateController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin.db\Objects\MessageTemplate.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin.db\Services\MessageTemplate.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin.db\Interfaces\IMessageTemplate.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin.db\Meta\MessageTemplate.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin.web.common\Controllers\MessageTemplate.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin\Controllers\MessageTemplate.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Controllers\MessageTemplate.controller.cs

mkdir ..\trunk\admin\Views\\MessageTemplate
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin\Views\MessageTemplate\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\admin\Views\MessageTemplate\MessageTemplateGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\MessageTemplate
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=MessageTemplate > ..\trunk\oilring\Views\MessageTemplate\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=NotificationService > stubs\NotificationService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=NotificationController > stubs\NotificationController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin.db\Objects\Notification.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin.db\Services\Notification.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin.db\Interfaces\INotification.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin.db\Meta\Notification.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin.web.common\Controllers\Notification.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin\Controllers\Notification.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Controllers\Notification.controller.cs

mkdir ..\trunk\admin\Views\\Notification
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin\Views\Notification\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\admin\Views\Notification\NotificationGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Notification
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Notification > ..\trunk\oilring\Views\Notification\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=Organization_DeptService > stubs\Organization_DeptService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=Organization_DeptController > stubs\Organization_DeptController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin.db\Objects\Organization_Dept.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin.db\Services\Organization_Dept.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin.db\Interfaces\IOrganization_Dept.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin.db\Meta\Organization_Dept.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin.web.common\Controllers\Organization_Dept.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin\Controllers\Organization_Dept.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Controllers\Organization_Dept.controller.cs

mkdir ..\trunk\admin\Views\\Organization_Dept
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin\Views\Organization_Dept\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\admin\Views\Organization_Dept\Organization_DeptGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Organization_Dept
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_Dept > ..\trunk\oilring\Views\Organization_Dept\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=Organization_UserService > stubs\Organization_UserService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=Organization_UserController > stubs\Organization_UserController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin.db\Objects\Organization_User.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin.db\Services\Organization_User.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin.db\Interfaces\IOrganization_User.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin.db\Meta\Organization_User.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin.web.common\Controllers\Organization_User.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin\Controllers\Organization_User.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Controllers\Organization_User.controller.cs

mkdir ..\trunk\admin\Views\\Organization_User
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin\Views\Organization_User\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\admin\Views\Organization_User\Organization_UserGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Organization_User
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization_User > ..\trunk\oilring\Views\Organization_User\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=OrganizationService > stubs\OrganizationService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=OrganizationController > stubs\OrganizationController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin.db\Objects\Organization.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin.db\Services\Organization.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin.db\Interfaces\IOrganization.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin.db\Meta\Organization.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin.web.common\Controllers\Organization.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin\Controllers\Organization.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Controllers\Organization.controller.cs

mkdir ..\trunk\admin\Views\\Organization
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin\Views\Organization\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\admin\Views\Organization\OrganizationGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Organization
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Organization > ..\trunk\oilring\Views\Organization\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=OuterLinkService > stubs\OuterLinkService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=OuterLinkController > stubs\OuterLinkController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin.db\Objects\OuterLink.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin.db\Services\OuterLink.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin.db\Interfaces\IOuterLink.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin.db\Meta\OuterLink.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin.web.common\Controllers\OuterLink.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin\Controllers\OuterLink.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Controllers\OuterLink.controller.cs

mkdir ..\trunk\admin\Views\\OuterLink
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin\Views\OuterLink\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\admin\Views\OuterLink\OuterLinkGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\OuterLink
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=OuterLink > ..\trunk\oilring\Views\OuterLink\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ParagraphService > stubs\ParagraphService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ParagraphController > stubs\ParagraphController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin.db\Objects\Paragraph.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin.db\Services\Paragraph.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin.db\Interfaces\IParagraph.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin.db\Meta\Paragraph.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin.web.common\Controllers\Paragraph.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin\Controllers\Paragraph.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Controllers\Paragraph.controller.cs

mkdir ..\trunk\admin\Views\\Paragraph
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin\Views\Paragraph\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\admin\Views\Paragraph\ParagraphGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Paragraph
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Paragraph > ..\trunk\oilring\Views\Paragraph\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=PatentService > stubs\PatentService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=PatentController > stubs\PatentController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin.db\Objects\Patent.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin.db\Services\Patent.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin.db\Interfaces\IPatent.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin.db\Meta\Patent.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin.web.common\Controllers\Patent.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin\Controllers\Patent.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Controllers\Patent.controller.cs

mkdir ..\trunk\admin\Views\\Patent
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin\Views\Patent\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\admin\Views\Patent\PatentGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Patent
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Patent > ..\trunk\oilring\Views\Patent\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=PhotoService > stubs\PhotoService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=PhotoController > stubs\PhotoController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin.db\Objects\Photo.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin.db\Services\Photo.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin.db\Interfaces\IPhoto.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin.db\Meta\Photo.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin.web.common\Controllers\Photo.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin\Controllers\Photo.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Controllers\Photo.controller.cs

mkdir ..\trunk\admin\Views\\Photo
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin\Views\Photo\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\admin\Views\Photo\PhotoGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Photo
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Photo > ..\trunk\oilring\Views\Photo\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=PrivateMessageItemService > stubs\PrivateMessageItemService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=PrivateMessageItemController > stubs\PrivateMessageItemController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin.db\Objects\PrivateMessageItem.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin.db\Services\PrivateMessageItem.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin.db\Interfaces\IPrivateMessageItem.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin.db\Meta\PrivateMessageItem.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin.web.common\Controllers\PrivateMessageItem.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin\Controllers\PrivateMessageItem.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Controllers\PrivateMessageItem.controller.cs

mkdir ..\trunk\admin\Views\\PrivateMessageItem
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin\Views\PrivateMessageItem\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\admin\Views\PrivateMessageItem\PrivateMessageItemGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\PrivateMessageItem
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessageItem > ..\trunk\oilring\Views\PrivateMessageItem\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=PrivateMessageService > stubs\PrivateMessageService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=PrivateMessageController > stubs\PrivateMessageController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin.db\Objects\PrivateMessage.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin.db\Services\PrivateMessage.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin.db\Interfaces\IPrivateMessage.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin.db\Meta\PrivateMessage.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin.web.common\Controllers\PrivateMessage.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin\Controllers\PrivateMessage.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Controllers\PrivateMessage.controller.cs

mkdir ..\trunk\admin\Views\\PrivateMessage
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin\Views\PrivateMessage\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\admin\Views\PrivateMessage\PrivateMessageGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\PrivateMessage
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PrivateMessage > ..\trunk\oilring\Views\PrivateMessage\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=PublicationLinkService > stubs\PublicationLinkService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=PublicationLinkController > stubs\PublicationLinkController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin.db\Objects\PublicationLink.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin.db\Services\PublicationLink.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin.db\Interfaces\IPublicationLink.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin.db\Meta\PublicationLink.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin.web.common\Controllers\PublicationLink.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin\Controllers\PublicationLink.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Controllers\PublicationLink.controller.cs

mkdir ..\trunk\admin\Views\\PublicationLink
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin\Views\PublicationLink\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\admin\Views\PublicationLink\PublicationLinkGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\PublicationLink
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=PublicationLink > ..\trunk\oilring\Views\PublicationLink\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ReportService > stubs\ReportService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ReportController > stubs\ReportController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin.db\Objects\Report.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin.db\Services\Report.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin.db\Interfaces\IReport.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin.db\Meta\Report.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin.web.common\Controllers\Report.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin\Controllers\Report.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Controllers\Report.controller.cs

mkdir ..\trunk\admin\Views\\Report
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin\Views\Report\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\admin\Views\Report\ReportGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Report
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Report > ..\trunk\oilring\Views\Report\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=RubricService > stubs\RubricService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=RubricController > stubs\RubricController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin.db\Objects\Rubric.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin.db\Services\Rubric.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin.db\Interfaces\IRubric.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin.db\Meta\Rubric.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin.web.common\Controllers\Rubric.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin\Controllers\Rubric.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Controllers\Rubric.controller.cs

mkdir ..\trunk\admin\Views\\Rubric
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin\Views\Rubric\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\admin\Views\Rubric\RubricGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Rubric
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Rubric > ..\trunk\oilring\Views\Rubric\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=SeminarService > stubs\SeminarService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=SeminarController > stubs\SeminarController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin.db\Objects\Seminar.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin.db\Services\Seminar.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin.db\Interfaces\ISeminar.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin.db\Meta\Seminar.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin.web.common\Controllers\Seminar.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin\Controllers\Seminar.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Controllers\Seminar.controller.cs

mkdir ..\trunk\admin\Views\\Seminar
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin\Views\Seminar\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\admin\Views\Seminar\SeminarGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Seminar
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Seminar > ..\trunk\oilring\Views\Seminar\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=TagService > stubs\TagService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=TagController > stubs\TagController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin.db\Objects\Tag.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin.db\Services\Tag.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin.db\Interfaces\ITag.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin.db\Meta\Tag.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin.web.common\Controllers\Tag.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin\Controllers\Tag.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Controllers\Tag.controller.cs

mkdir ..\trunk\admin\Views\\Tag
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin\Views\Tag\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\admin\Views\Tag\TagGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Tag
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Tag > ..\trunk\oilring\Views\Tag\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=TechnoService > stubs\TechnoService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=TechnoController > stubs\TechnoController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin.db\Objects\Techno.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin.db\Services\Techno.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin.db\Interfaces\ITechno.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin.db\Meta\Techno.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin.web.common\Controllers\Techno.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin\Controllers\Techno.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Controllers\Techno.controller.cs

mkdir ..\trunk\admin\Views\\Techno
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin\Views\Techno\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\admin\Views\Techno\TechnoGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\Techno
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=Techno > ..\trunk\oilring\Views\Techno\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=User_DegreeService > stubs\User_DegreeService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=User_DegreeController > stubs\User_DegreeController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin.db\Objects\User_Degree.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin.db\Services\User_Degree.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin.db\Interfaces\IUser_Degree.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin.db\Meta\User_Degree.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin.web.common\Controllers\User_Degree.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin\Controllers\User_Degree.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Controllers\User_Degree.controller.cs

mkdir ..\trunk\admin\Views\\User_Degree
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin\Views\User_Degree\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\admin\Views\User_Degree\User_DegreeGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\User_Degree
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Degree > ..\trunk\oilring\Views\User_Degree\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=User_FriendRequestService > stubs\User_FriendRequestService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=User_FriendRequestController > stubs\User_FriendRequestController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin.db\Objects\User_FriendRequest.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin.db\Services\User_FriendRequest.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin.db\Interfaces\IUser_FriendRequest.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin.db\Meta\User_FriendRequest.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin.web.common\Controllers\User_FriendRequest.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin\Controllers\User_FriendRequest.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Controllers\User_FriendRequest.controller.cs

mkdir ..\trunk\admin\Views\\User_FriendRequest
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin\Views\User_FriendRequest\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\admin\Views\User_FriendRequest\User_FriendRequestGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\User_FriendRequest
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_FriendRequest > ..\trunk\oilring\Views\User_FriendRequest\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=User_GroupService > stubs\User_GroupService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=User_GroupController > stubs\User_GroupController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin.db\Objects\User_Group.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin.db\Services\User_Group.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin.db\Interfaces\IUser_Group.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin.db\Meta\User_Group.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin.web.common\Controllers\User_Group.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin\Controllers\User_Group.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Controllers\User_Group.controller.cs

mkdir ..\trunk\admin\Views\\User_Group
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin\Views\User_Group\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\admin\Views\User_Group\User_GroupGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\User_Group
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Group > ..\trunk\oilring\Views\User_Group\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=User_JobService > stubs\User_JobService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=User_JobController > stubs\User_JobController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin.db\Objects\User_Job.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin.db\Services\User_Job.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin.db\Interfaces\IUser_Job.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin.db\Meta\User_Job.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin.web.common\Controllers\User_Job.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin\Controllers\User_Job.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Controllers\User_Job.controller.cs

mkdir ..\trunk\admin\Views\\User_Job
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin\Views\User_Job\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\admin\Views\User_Job\User_JobGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\User_Job
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Job > ..\trunk\oilring\Views\User_Job\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=User_UniverService > stubs\User_UniverService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=User_UniverController > stubs\User_UniverController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin.db\Objects\User_Univer.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin.db\Services\User_Univer.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin.db\Interfaces\IUser_Univer.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin.db\Meta\User_Univer.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin.web.common\Controllers\User_Univer.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin\Controllers\User_Univer.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Controllers\User_Univer.controller.cs

mkdir ..\trunk\admin\Views\\User_Univer
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin\Views\User_Univer\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\admin\Views\User_Univer\User_UniverGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\User_Univer
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User_Univer > ..\trunk\oilring\Views\User_Univer\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=UserService > stubs\UserService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=UserController > stubs\UserController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin.db\Objects\User.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin.db\Services\User.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin.db\Interfaces\IUser.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin.db\Meta\User.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin.web.common\Controllers\User.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin\Controllers\User.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Controllers\User.controller.cs

mkdir ..\trunk\admin\Views\\User
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin\Views\User\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\admin\Views\User\UserGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\User
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=User > ..\trunk\oilring\Views\User\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ViewMaterialService > stubs\ViewMaterialService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ViewMaterialController > stubs\ViewMaterialController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin.db\Objects\ViewMaterial.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin.db\Services\ViewMaterial.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin.db\Interfaces\IViewMaterial.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin.db\Meta\ViewMaterial.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin.web.common\Controllers\ViewMaterial.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin\Controllers\ViewMaterial.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Controllers\ViewMaterial.controller.cs

mkdir ..\trunk\admin\Views\\ViewMaterial
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin\Views\ViewMaterial\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\admin\Views\ViewMaterial\ViewMaterialGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\ViewMaterial
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewMaterial > ..\trunk\oilring\Views\ViewMaterial\SearchResult.sample.ascx

		

REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin.common" CLASS=ViewUserMaterialService > stubs\ViewUserMaterialService.cs
REM msxsl ..\trunk\database\oilring.xml stub.xsl FILENAME=..\trunk\database\oilring.xml NAMESPACE="admin" CLASS=ViewUserMaterialController > stubs\ViewUserMaterialController.cs


msxsl ..\trunk\database\oilring.xml context.xsl FILENAME=..\trunk\database\oilring.xml > ..\trunk\admin.db\oilring.impl.cs



java -jar saxon\saxon9he.jar -s:..\trunk\database\oilring.xml -xsl:objects.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin.db\Objects\ViewUserMaterial.object.cs

msxsl ..\trunk\database\oilring.xml services.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin.db\Services\ViewUserMaterial.service.cs
msxsl ..\trunk\database\oilring.xml iservices.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin.db\Interfaces\IViewUserMaterial.service.cs

msxsl ..\trunk\database\oilring.xml meta.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin.db\Meta\ViewUserMaterial.meta.cs

msxsl ..\trunk\database\oilring.xml controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin.web.common\Controllers\ViewUserMaterial.controller.cs

msxsl ..\trunk\database\oilring.xml admin_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin\Controllers\ViewUserMaterial.controller.cs

msxsl ..\trunk\database\oilring.xml user_controller.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Controllers\ViewUserMaterial.controller.cs

mkdir ..\trunk\admin\Views\\ViewUserMaterial
msxsl ..\trunk\database\oilring.xml admin_view.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin\Views\ViewUserMaterial\Index.aspx
msxsl ..\trunk\database\oilring.xml admin_grid.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\admin\Views\ViewUserMaterial\ViewUserMaterialGrid.sample.ascx

mkdir ..\trunk\oilring\Views\\ViewUserMaterial
msxsl ..\trunk\database\oilring.xml user_view_list.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\List.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_single.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\Single.sample.aspx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\ListWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_list_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\ListItems.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\SingleWidget.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_single_widget.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\SingleItem.sample.ascx
msxsl ..\trunk\database\oilring.xml user_view_search_result.xsl FILENAME=..\trunk\database\oilring.xml TABLE=ViewUserMaterial > ..\trunk\oilring\Views\ViewUserMaterial\SearchResult.sample.ascx

	