using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecorize.Foundation.DynamicSources
{
    public struct Templates
    {
        public struct VirtualSource
        {
            public static readonly ID Id = new ID("{150D79AC-8B27-446B-8F9E-CEC61D3719DC}");

            public struct Fields
            {
                public static readonly ID Key = new ID("{BB314381-A47A-4A3A-8B6E-A3AB8108D25D}");
                public static readonly ID Template = new ID("{B243B235-1A94-4242-9DEF-623DEC3F85E1}");
                public static readonly ID Source = new ID("{B4738DF2-6CC6-41F1-AFCE-39E873D9EB4B}");
                public static readonly ID SourceRule = new ID("{FDA31362-471D-4B09-986A-26041A08CFEB}");
            }
        }

        public struct VirtualSourcesContainer
        {
            public static readonly ID Id = new ID("{C05F14E0-D132-401A-BCC1-BB5DF58658F7}");
        }
    }
}