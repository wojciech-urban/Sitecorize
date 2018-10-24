using Sitecore.Data;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetRenderingDatasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecorize.Foundation.Datasource.Pipelines.GetRenderingDatasource
{
    public class GetInheritingTemplatesFromBaseTemplate
    {
        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            if (args.Prototype == null)
                return;
            Template template = (Template)null;
            template = TemplateManager.GetTemplate(new ID("{76036F5E-CBCE-46D1-AF0A-4143F9B557AA}"), args.Prototype.Database);
            args.TemplatesForSelection.Add(template);

            template = TemplateManager.GetTemplate(new ID("{0CBF05ED-9263-4A3F-981C-4335B053D098}"), args.Prototype.Database);
            args.TemplatesForSelection.Add(template);
        }
    }
}