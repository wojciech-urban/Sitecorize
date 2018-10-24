using Sitecore.Diagnostics;
using Sitecore.Rules.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecorize.Foundation.DynamicSources.Rules.DynamicSources
{
    public class UseSource<T> : RuleAction<T> where T : DynamicSourcesRuleContext
    {
        public string Text { get; set; }

        public override void Apply(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");
            ruleContext.Source = Text;
        }
    }
}