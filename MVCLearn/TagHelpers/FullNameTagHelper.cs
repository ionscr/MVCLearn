using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCLearn.TagHelpers
{
    public class FullNameTagHelper : TagHelper
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h5";
            output.Content.SetContent("Name = " + FirstName + " " + LastName);
        }
    }
}
