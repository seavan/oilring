<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PublicationLinkObject>>" %>
<div class="note">��������� ��� ������ ���������� � �������� ������� � �������� ��������� ��������. �������� ����������� ����������, ������ ������� �������� ��������.</div>
<div class="wrap">

	<!---->
	<div class="userAddEdition">
        <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>		
	</div>
	<!--/-->

	<!---->
	<div class="addEditionBlock">
		<div class="column">
            <input type="hidden" id="fserverLangCode" value="<%: Html.LC().LANG_CODE %>"/>
			<%--<!--������ ���������-->
			<div class="filtrSelectBlock language">
				<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
					<ul class="borderAll10">
						<li>���� ����������</li>
						<li><a href="#">�������</a></li>
						<li><a href="#">����������</a></li>
					</ul>
				</div>
			</div>
			<!--/������ ���������-->--%>            
            			
            <div class="field">				
				<div class="borderAll10 input">
                    <label for="ftypePublic" class="_autohide">��� �������</label>
                    <input type="text" value="" id="ftypePublic" class="inp" />                    
                </div>
			</div>

			<div class="field">				
				<div class="borderAll10 input">
                    <label for="fISBNPublic" class="_autohide">ISBN</label>
                    <input type="text" value="" id="fISBNPublic" />
                </div>
			</div>

            <div class="field">				
				<div class="borderAll10 input">
                    <label for="fISSNPublic" class="_autohide">ISSN</label>
                    <input type="text" value="" id="fISSNPublic" />
                </div>
			</div>

			<input type="button" value="��������" class="ibutton _addNewPublication _ownAct" />
		</div>

		<div class="column">
			<div class="field">												
				
				<div class="searchWrap">											
					<div class="borderAll10 input">
						<div class="bg">
                            <label for="fnameEditionPublic" class="_autohide">�������� �������</label>
                            <input type="text" value="" id="fnameEditionPublic"  class="_autocompletename" rel="/<%:Html.LC().LANG_CODE %>/Journal/AutoCompleteSearch"/>
                        </div>						
					</div>											
				</div>												
			</div>
			<div class="dateInput field">
				<span>���� ����������</span>                
				<div class="borderAll10 input">
                    <label for="fDatePublic" class="_autohide">��.����</label>
					<input type="text" value="" id="fDatePublic" maxlength="7" />					
				</div>
			</div>
		</div>

	</div>
	<!--/-->
</div>