<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DinosaursWithLasers.Model.Dinosaur>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dinoInfo">
        <div>
            <img src="<%=Model.FigImageUrl%>" style="float:left; padding-right: 15px; width: 400px;"/>
        </div>        
        <div>
            <h2><%=Model.Name %></h2>
            <p>
                <%=Model.Description%>
            </p>
        </div>        
    </div>

    <div class="figlist" >
        <div class="weaponList">
            <h2>Weapons:</h2>
            <ul>
                <% foreach (var w in Model.Weapons) {%>
                    <li><%=w%></li>
                <% } %>
            </ul>
        </div>

    <% foreach (var r in Model.Riders)
       {%>
    <div class="darkBox">
        <%=r.Name%><br />
        <img src="<%=r.FigImageUrl%>" style="height: 150px;"/>
    </div>
    <% } %>
    </div>
   
</asp:Content>
