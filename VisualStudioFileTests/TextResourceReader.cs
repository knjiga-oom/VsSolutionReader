using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioFileTests
{
    class TextResourceReader : TextReader
    {
        public TextResourceReader(string resourceName)
        {
            this.resourceName = resourceName;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            reader = new StreamReader(stream);
        }

        public override int Read()
        {
            return reader.Read();
        }

        public override int Peek()
        {
            return reader.Peek();
        }

        public override string ReadToEnd()
        {
            return reader.ReadToEnd();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                reader.Dispose();
            base.Dispose(disposing);
        }

        private string resourceName;
        StreamReader reader;
    }
}
