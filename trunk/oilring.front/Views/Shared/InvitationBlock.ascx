<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<dl class="invitationBlock">
    <dt>Пригласить друзей</dt>
    <dd>
        <div class="searchFriends iForm">
            <div class="searchWrap">
                <div class="borderAll10 input">
                    <div class="bg">
                        <input type="text" value="" /></div>
                    <ul class="list">
                        <!--добавляем класс show-->
                        <li><a href="#">
                            <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                            Василий Милосердов</a></li>
                        <li><a href="#">
                            <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                            Василий Милосердов</a></li>
                    </ul>
                </div>
            </div>
            <input type="submit" value="Отправить приглашение" class="ibutton" />
        </div>
        <ul class="friendsList">
            <li><a href="#">
                <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                Василий Милосердов</a><span class="delete" title="Удалить">Удалить</span></li>
            <li><a href="#">
                <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                Ирина Коммерцева</a><span class="delete" title="Удалить">Удалить</span></li>
            <li><a href="#">
                <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                Константин Константинопольский</a><span class="delete" title="Удалить">Удалить</span></li>
            <li><a href="#">
                <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                Юля Бах</a><span class="delete" title="Удалить">Удалить</span></li>
            <li><a href="#">
                <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                Антон Орлов</a><span class="delete" title="Удалить">Удалить</span></li>
            <li><a href="#">
                <img src="<%= RES.IMAGE_CONTENT_URI %>pic9.jpg" alt=""/>
                Юля Бах</a><span class="delete" title="Удалить">Удалить</span></li>
        </ul>
    </dd>
</dl>
