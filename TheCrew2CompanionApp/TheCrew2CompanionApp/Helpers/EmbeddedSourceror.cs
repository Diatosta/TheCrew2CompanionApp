using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace TheCrew2CompanionApp.Helpers
{
    public class EmbeddedSourceror
    {
        public static ImageSource SourceFor(string pclFilePathInResourceFormat)
        {
            var resources = typeof(EmbeddedSourceror).GetTypeInfo().Assembly.GetManifestResourceNames();
            var resourceName = resources.Single(r => r.EndsWith(pclFilePathInResourceFormat, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("EmbeddedSourceror: resourceName string is " + resourceName);

            return ImageSource.FromResource(resourceName);
        }
    }
}
