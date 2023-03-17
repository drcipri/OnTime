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
        [HtmlAttributeNotBound] 
        public ViewContext? ViewContext { get; set; }
        public PaginationInfo? PaginationModel { get; set; }
        public string? PageAction { get; set; }
        public string? PageClassification { get; set; }

        //style properties
        public string StyleA { get; set; }  = string.Empty;
        public string PageSelected { get; set; } = string.Empty;

        


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && PaginationModel != null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                
                for(int i = 1; i <= PaginationModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new {appointmentsPage = i, classification = PageClassification});

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
