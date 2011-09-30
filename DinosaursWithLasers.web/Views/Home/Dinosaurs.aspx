<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dinosaurs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Check out these sweet dinosaurs!</h2>

<h3>
    By Category...
</h3>
    <div class="boxlink">
        <a href="/Dinosaur/List/VAL">
        <img src="../../Content/images/Deinonychus-Front-Small.jpg" style="height: 225px;"/>
        <br />Valorians
        </a>
    </div>
    <div class="boxlink">
        <a href="/Dinosaur/List/RUL">
        <img src="../../Content/images/DeinonychusRulon-Front-Small.jpg" style="height: 225px;" />
        <br />Rulons
        </a>
    </div>
    <div style="clear:both;" />
    <br />
    <br />
<h3>
    By Series...
</h3>
    <div class="boxlink">
        <a href="/Dinosaur/List/S1">
        <img src="../../Content/images/series1.jpg" style="height: 120px;" />
        <br />Series 1
        </a>
    </div>
    <div class="boxlink">
        <a href="/Dinosaur/List/S2">
        <img src="../../Content/images/series2.jpg" style="height: 120px;"  />
        <br />Series 2
        </a>
    </div>
    <div class="boxlink">
        <a href="/Dinosaur/List/S3">
        <img src="../../Content/images/series3.jpg" style="height: 120px;"  />
        <br />Series 3
        </a>
    </div>
    <div class="boxlink">
        <a href="/Dinosaur/List/ICE">
        <img src="../../Content/images/iceage.jpg" style="height: 120px;"  />
        <br />Ice Age
        </a>
    </div>
        <div style="clear:both;" />
    <br />
    <br />
</asp:Content>
