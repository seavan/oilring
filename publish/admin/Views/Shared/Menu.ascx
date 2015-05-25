<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>	
		
<%
Html.Telerik().Menu()
            .Name("PanelBar")
            .Items(item =>
            {
						

                item.Add()
                    .Text("Article").Visible("Article".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Article/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Article");
                               
                    });

                item.Add()
                    .Text("Comment").Visible("Comment".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Comment/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Comment");

                    });                
	
                item.Add()
                    .Text("Conference").Visible("Conference".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Conference/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Conference");
                               
                    });
	
                item.Add()
                    .Text("Discussion").Visible("Discussion".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Discussion/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Discussion");
                               
                    });
	
                item.Add()
                    .Text("Event").Visible("Event".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Event/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Event");
                               
                    });
	
                item.Add()
                    .Text("Grant").Visible("Grant".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Grant/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Grant");
                               
                    });
	
                item.Add()
                    .Text("Journal").Visible("Journal".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Journal/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Journal");
                               
                    });
 
                item.Add()
                    .Text("Organization").Visible("Organization".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Organization/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Organization");
                               
                    });
	
                item.Add()
                    .Text("Paragraph").Visible("Paragraph".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Paragraph/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Paragraph");
                               
                    });
	
                item.Add()
                    .Text("Rubric").Visible("Rubric".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Rubric/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Rubric");
                               
                    });
	
                item.Add()
                    .Text("Seminar").Visible("Seminar".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Seminar/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Seminar");
                               
                    });
	
                item.Add()
                    .Text("Techno").Visible("Techno".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/Techno/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/Techno");
                               
                    });
	
                item.Add()
                    .Text("User").Visible("User".IndexOf("_") == -1)
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/User/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/User");
                               
                    });

                item.Add()
                    .Text("MessageTemplate")
                    .Items(subItem =>
                    {
                        subItem.Add()
                               .Text("Создать")
                               .Url("/MessageTemplate/AdminCreateDraft");
                        subItem.Add()
                               .Text("Список")
                               .Url("/MessageTemplate");

                    });
                
			})
        .Render();
%>

	