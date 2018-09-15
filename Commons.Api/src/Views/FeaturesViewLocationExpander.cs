using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Commons.Api.Views
{
    public class FeaturesViewLocationExpander : IViewLocationExpander
    {
        private readonly string[] _viewLocationPahts;

        public FeaturesViewLocationExpander()
        {}

        public FeaturesViewLocationExpander(string[] viewLocationPaths)
        {
            _viewLocationPahts = viewLocationPaths;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(FeaturesViewLocationExpander);
        }

        /// <summary>Additionla view location paths</summary>
        /// <example>
        /// var viewLocationFormats = new[] {
        ///     "~/Features/{1}/{0}.cshtml",
        ///     "~/Features/Shared/{0}.cshtml"
        /// };
        /// </example>
        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            List<string> changedViewLocations = new List<string>(viewLocations);
            changedViewLocations.AddRange(_viewLocationPahts);
            return changedViewLocations;
        }
    }
}
