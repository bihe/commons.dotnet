using System;
using System.Collections.Generic;
using Commons.Api.Views;
using Microsoft.AspNetCore.Mvc.Razor;
using Moq;
using Xunit;

namespace Commons.Api.XTests.Views
{
    public class TestFeaturesViewLocationExpander
    {
        [Fact]
        public void TestFeatureViewExpander()
        {
            var featureViewLocations = new[] {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/Shared/{0}.cshtml"
            };

            var featureViewExpander = new FeaturesViewLocationExpander(featureViewLocations);

            // unfortunately not mockable with Moq
            var mockContext = new ViewLocationExpanderContext(new Microsoft.AspNetCore.Mvc.ActionContext(), "test", null,  null, null, false);
            mockContext.Values = new Dictionary<string,string>();
            featureViewExpander.PopulateValues(mockContext);
            Assert.Equal(nameof(FeaturesViewLocationExpander), mockContext.Values["customviewlocation"]);

            var viewLocations = featureViewExpander.ExpandViewLocations(mockContext, new string[]{});
            Assert.Equal(featureViewLocations, viewLocations);
        }
    }
}
