<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    (with apologies to dino-rider fans everywhere)
    <img src="../../Content/images/dinoworld.png" style="float:left; padding-right: 20px;"/>
    <h3>About Dino-Riders (from wikipedia)</h3>
    <p>
    The Valorians were a peaceful race that had lived in harmony until the evil Rulons came and attacked them. The Valorians tried to escape from the Rulon assault and attempted to use their "Space Time Energy Projector" (S.T.E.P.) to do so, however something went wrong and they ended up being sent back through time to the age of the dinosaurs. Unbeknownst to them the Rulons in the spaceship Dreadlock were also sent back through time when the S.T.E.P. was activated.
    </p>
    <p>
    The Valorians, led by Questar, after making planet-fall use their AMP necklaces to telepathically communicate with the dinosaurs they come across and befriend them. The Rulons, led by their leader Krulos, on the other hand used brainwashing devices known as brain-boxes to control dinosaurs for their own ends. The Rulons then launched an attack on the Valorians, who call upon their dinosaur friends to assist them in fighting back. After successfully defeating the Rulons, the Valorians declare themselves to be the Dino-Riders.
    </p>
 </asp:Content>
