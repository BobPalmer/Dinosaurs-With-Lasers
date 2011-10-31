<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DinosaursWithLasers.Model.Dinosaur>" %>
<%@ Import Namespace="DinosaursWithLasers.Utilities" %>

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
            <%=Html.QuickList(Model.Weapons)%>
        </div>

        <% Html.RenderPartial("RiderImageList",Model.Riders); %>

    </div>
    <div>
        <button id="btnDino">Find Similar Dinosaurs</button>
    </div>
    <div id="dinoList"></div>

    <script type="text/javascript">
        $(function() {
            $('#btnDino').click(function () {
                $.getJSON("/Dinosaur/GetSimilarDinosaurs/<%=Model.DinosaurId %>", null, function (data) {
                    $("#dinoList").html(data);
                });
             });
        });
    </script>
</asp:Content>
