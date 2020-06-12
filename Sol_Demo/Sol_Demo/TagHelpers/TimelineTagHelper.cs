using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Sol_Demo.TagHelpers.Models;

namespace Sol_Demo.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("timeline")]
    public class TimelineTagHelper : TagHelper
    {
        private readonly IHtmlHelper htmlHelper = null;

        private const String ItemSourceAttributeName = "item-source";

        public TimelineTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        [HtmlAttributeName(ItemSourceAttributeName)]
        public List<TimelineTagHelperModel> ItemSource { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var content = await htmlHelper?.PartialAsync("~/TagHelpers/_TimelinePartialView.cshtml", ItemSource);

            output.Content.SetHtmlContent(content);
        }
    }
}