<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.ProductBase>" %>

<div class="product_demo">
    <div class="overview_title"><%:UiResources.UiTexts.product_demo %></div>
    <%
        DomainModel.Entities.ProductDemo local = Model.Demo[WebUi.Models.AppCulture.CurrentCulture.CultureId];
        DomainModel.Entities.ProductDemo common = Model.Demo.CommonVersion;
    
        if ( common == null && local == null)
        {
    %>
            <p><%:UiResources.UiTexts.no_demo_available%></p>
    <%
        }
        else
        {
            if (WebUi.Models.Security.CurrentUser != null)
            {
                if (common != null && !string.IsNullOrWhiteSpace(common.Url))
                {
    %>
                    <p><a href="<%:common.Url%>">
                        <%:UiResources.UiTexts.download_common_demo%> - <%:UiResources.UiTexts.file_size%><%:common.Size%>
                    </a></p>
    <%           
                }

                if (local != null && !string.IsNullOrWhiteSpace(local.Url))
                {
    %>
                    <p><a href="<%:local.Url%>">
                        <%:string.Format(
                            UiResources.UiTexts.download_local_demo,
                            WebUi.Models.AppCulture.CurrentCulture.Name)%> - <%:UiResources.UiTexts.file_size%><%:local.Size%>
                    </a></p>
    <%           
                }
            }
            else
            {
    %>
            <p><%:UiResources.UiTexts.login_to_download_demo%></p>
    <%
            }
        }

    %>
</div>