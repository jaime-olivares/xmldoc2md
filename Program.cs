using System.Diagnostics;
using System.IO;
using System.Xml.Xsl;
using System.Text;

namespace XmlDocToMD
{
    /// <summary>
    /// The unique class of the application
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the application
        /// </summary>
        /// <remarks>This is the unique functional method. All others are dummies</remarks>
        /// <param name="args">The argument list. Not used</param>
        static void Main(string[] args)
        {
            var sourceFile = "xmldoc2md.xml";
            var stylesheet = "xmldoc2md.xsl";
            var outputMD = "sample.md";

            // Load stylesheet
            var xslt = new XslCompiledTransform(true);
            xslt.Load(stylesheet);

            // Creates the output buffer
            var sb = new StringBuilder();

            // Performs the transformation
            using (var sw = new StringWriter(sb))
            {
                xslt.Transform(sourceFile, null, sw);
            }

            var md = sb.ToString();
            File.WriteAllText(outputMD, md);
            Process.Start(outputMD);
        }

        /// <summary>
        /// A dummy method
        /// </summary>
        /// <param name="arg1">An integer argument</param>
        /// <returns>A string representation of the argument</returns>
        /// <exception cref="IOException">Whenever a file error occurs</exception>
        /// <example>
        /// <code>
        /// int x = 1;
        /// string s = DummyMethod(x);
        /// </code> 
        /// </example>
        public string DummyMethod(int arg1)
        {
            this.DummyProperty = arg1.ToString();
            return this.DummyProperty;
        }

        /// <summary>
        /// A private method
        /// </summary>
        private void PrivateMethod() { }

        /// <summary>
        /// A dummy property
        /// </summary>
        /// <seealso cref="DummyField"/>
        /// <value>A string value</value>
        public string DummyProperty
        {
            get { return this.DummyField; }
            set { this.DummyField = value; }
        }

        /// <summary>
        /// A dummy field
        /// </summary>
        /// <remarks>Backend for <see cref="DummyProperty"/>.</remarks>
        public string DummyField;
    }
}
