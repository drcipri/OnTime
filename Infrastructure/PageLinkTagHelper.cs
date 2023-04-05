using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Tokens;
using OnTime.ViewModels;

namespace OnTime.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "pagination-model")]
    public class PageLinkTagHelper: TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory; 
        public PageLinkTagHelper(IUrlHelperFactory helperFactory) 
        {
            _urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound] //indicate that this property cannot be set with html attributes
        public ViewContext? ViewContext { get; set; }
        public PaginationInfo? PaginationModel { get; set; }  
        public string? PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        //style properties
        public string StyleA { get; set; }  = string.Empty;
        public string PageSelected { get; set; } = string.Empty;

        

        //this method generate the pagination links
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && PaginationModel != null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                
                for(int i = 1; i <= PaginationModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    PageUrlValues["appointmentsPage"] = i;
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                    tag.AddCssClass(StyleA);
                    tag.AddCssClass(i == PaginationModel.CurrentPage ? PageSelected : "");
                   
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
               
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
