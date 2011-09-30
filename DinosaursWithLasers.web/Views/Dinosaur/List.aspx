<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DinosaursWithLasers.Model.Dinosaur>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Category: "<%=ViewBag.CategoryName %>"</h1>
<br /><br />
<div class="dinoList">
<table>
    <tr>
        <th>
            Box Image
        </th>
        <th>
            Dinosaur Name
        </th>
        <th>
            Description
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <a href="/Dinosaur/Details/<%=item.DinosaurId%>">
            <img src="<%=item.BoxImageUrl%>" style="width: 300px; border-width: 0px;"/>
            </a>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Name) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.ShortDescription) %>
        </td>
    </tr>
<% } %>

</table>
</div>

</asp:Content>
