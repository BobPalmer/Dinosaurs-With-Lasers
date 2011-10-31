<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<DinosaursWithLasers.Model.Rider>>" %>

<% foreach (var r in Model)
    {%>
<div class="darkBox">
    <%=r.Name%><br />
    <img src="<%=r.FigImageUrl%>" style="height: 150px;"/>
</div>
<% } %>