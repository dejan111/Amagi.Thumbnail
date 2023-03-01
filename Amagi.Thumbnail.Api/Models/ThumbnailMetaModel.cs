using FluentValidation;
using System.Text.RegularExpressions;

namespace Amagi.Thumbnail.Api;

public class ThumbnailMetaModel
{
    public int? Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Url { get; set; }

    public class ThumbnailMetaValidator : AbstractValidator<ThumbnailMetaModel>
    {
        public ThumbnailMetaValidator()
        {
            RuleFor(m => m.Url).Custom((url, context) =>
            {
                string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
                Regex Rgx = new(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (!Rgx.IsMatch(url))
                    context.AddFailure("Url is not valid");
            });
        }
    }
}
