<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DinosaursWithLasers.Model.Dinosaur>" %>

<fieldset>
    <legend>Dinosaur</legend>

    <div class="display-label">Name</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Name) %>
    </div>

    <div class="display-label">FigImageUrl</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FigImageUrl) %>
    </div>

    <div class="display-label">BoxImageUrl</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.BoxImageUrl) %>
    </div>

    <div class="display-label">ThumbImageUrl</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ThumbImageUrl) %>
    </div>

    <div class="display-label">Description</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Description) %>
    </div>

    <div class="display-label">ShortDescription</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ShortDescription) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.DinosaurId }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>
