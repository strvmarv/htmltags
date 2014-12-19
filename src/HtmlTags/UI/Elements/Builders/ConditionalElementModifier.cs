using System;

namespace HtmlTags.UI.Elements.Builders
{
    // Tested through HtmlConventionRegistry
    public class ConditionalElementModifier : IElementModifier
    {
        private readonly Func<ElementRequest, bool> _filter;
        private readonly IElementModifier _inner;

        public ConditionalElementModifier(Func<ElementRequest, bool> filter, IElementModifier inner)
        {
            _filter = filter;
            _inner = inner;
        }

        public string ConditionDescription { get; set; }



        public bool Matches(ElementRequest token)
        {
            return _filter(token);
        }

        public void Modify(ElementRequest request)
        {
            _inner.Modify(request);
        }
    }
}