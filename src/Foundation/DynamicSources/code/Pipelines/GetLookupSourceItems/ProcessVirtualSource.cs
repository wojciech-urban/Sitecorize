using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetLookupSourceItems;
using Sitecore.Rules;
using Sitecorize.Foundation.DynamicSources.Rules.DynamicSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Sitecorize.Foundation.DynamicSources.Pipelines.GetLookupSourceItems
{
    public class ProcessVirtualSource
    {
        private const string VirtualSourcePrefix = "vs:";
        private readonly ID _containerId = new ID("{FB085A59-ABDE-4C3D-AB6F-560D26F485DF}");

        public void Process(GetLookupSourceItemsArgs args)
        {         
            Assert.ArgumentNotNull((object)args, "args");
            if (!args.Source.StartsWith(VirtualSourcePrefix, StringComparison.InvariantCulture))
                return;

            var key = args.Source.Substring(VirtualSourcePrefix.Length);
            var container = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(_containerId);
            var virtualSourceItem = container.Children.FirstOrDefault(x => x.TemplateID.Equals(Templates.VirtualSource.Id) 
                    && x.Fields[Templates.VirtualSource.Fields.Key].Value.Equals(key, StringComparison.InvariantCultureIgnoreCase));



            if(virtualSourceItem == null) 
            {
                args.AbortPipeline();
                args.AddMessage("hello it is me");
                return;
                //throw new Exception("There is no definition for: " + key, null);
            }

            var source = RunRule(args.Item, virtualSourceItem.Fields[Templates.VirtualSource.Fields.SourceRule].Value);
            args.Source = source;
        }

        private string RunRule(Item item, string rule)
        {
            var rules = RuleFactory.ParseRules<DynamicSourcesRuleContext>(item.Database, XElement.Parse(rule));

            var ruleContext = new DynamicSourcesRuleContext()
            {
                Item = item
            };

            foreach (var r in rules.Rules)
            {
                if (r.Evaluate(ruleContext))
                {
                    r.Actions.ForEach(x => x.Apply(ruleContext));
                    return ruleContext.Source;
                }                
            }

            return string.Empty;
        }
    }

   
}