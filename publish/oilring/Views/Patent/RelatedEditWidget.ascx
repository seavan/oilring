<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PatentObject>>" %>
<div class="addPatentBlock">

	<%--<!--������ ���������-->
	<div class="filtrSelectBlock rubric2">
		<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
			<ul class="borderAll10">
				<li>��� ������ ���������������� �������������</li>
				<li><a href="#">111</a></li>
				<li><a href="#">222</a></li>
			</ul>
		</div>
	</div>
	<!--/������ ���������-->--%>

	<div class="selectFirm">
		<label for="fnumberPatent" class="name">������� ����� �������:</label>
		<div class="borderAll10 input"><input type="text" value="" id="fnumberPatent" /></div>
	</div>	

	<%--<!--������ ���������-->
	<div class="filtrSelectBlock language">
		<div class="border borderAll10"><!-- ��� ����� ��������� show � ul -->
			<ul class="borderAll10">
				<li>������ �������</li>
				<li><a href="#">111</a></li>
				<li><a href="#">222</a></li>
			</ul>
		</div>
	</div>
	<!--/������ ���������-->	--%>
                                    								
	<!---->
	<div class="selectFirm">
		<label for="fnamePatent">������� �������� �������:</label>
		<div class="searchWrap">											
			<div class="borderAll10 input">
				<input type="text" value="" id="fnamePatent" />				
			</div>											
		</div>
	</div>	
	<!--/-->
	<input type="button" class="ibutton _addNewPatent _ownAct" value="��������" />
</div>

<div class="userAddFirm">
	<dfn>����������� �������:</dfn>
    <% Html.RenderPartial("RelatedListWidgetForEdit", Model); %>	
</div>	
