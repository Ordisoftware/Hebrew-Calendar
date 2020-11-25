//using System.Collections.Specialized;
//using MarkdownSharp;
//using NUnit.Framework;

//namespace MarkdownSharpTests
//{
//    [TestFixture]
//    public class ConfigTests
//    {
//        [Test]
//        public void TestConfigurationValues()
//        {
//            var options = new MarkdownOptions(true, new[] {CreateAppSettings()});
//            Assert.AreEqual(true, options.AutoHyperlink);
//            Assert.AreEqual(true, options.AutoHyperlink);
//            Assert.AreEqual(true, options.AutoNewlines);
//            Assert.AreEqual(">", options.EmptyElementSuffix);
//            Assert.AreEqual(true, options.EncodeProblemUrlCharacters);
//            Assert.AreEqual(false, options.LinkEmails);
//            Assert.AreEqual(8, options.NestDepth);
//            Assert.AreEqual(true, options.StrictBoldItalic);
//            Assert.AreEqual(3, options.TabWidth);
//        }

//        [Test]
//        public void TestNoLoadFromConfigFile()
//        {
//            var options = new MarkdownOptions(false, new[] { CreateAppSettings() });
//            Assert.AreEqual(false, options.AutoHyperlink);
//            Assert.AreEqual(false, options.AutoNewlines);
//            Assert.AreEqual(" />", options.EmptyElementSuffix);
//            Assert.AreEqual(false, options.EncodeProblemUrlCharacters);
//            Assert.AreEqual(true, options.LinkEmails);
//            Assert.AreEqual(6, options.NestDepth);
//            Assert.AreEqual(false, options.StrictBoldItalic);
//            Assert.AreEqual(4, options.TabWidth);
//        }

//        public NameValueCollection CreateAppSettings()
//        {
//            var settings = new NameValueCollection();
//            settings.Set("Markdown.AutoHyperlink", "true");
//            settings.Set("Markdown.AutoNewlines", "true");
//            settings.Set("Markdown.EmptyElementSuffix", ">");
//            settings.Set("Markdown.EncodeProblemUrlCharacters", "true");
//            settings.Set("Markdown.LinkEmails", "false");
//            settings.Set("Markdown.NestDepth", "8");
//            settings.Set("Markdown.StrictBoldItalic", "true");
//            settings.Set("Markdown.TabWidth", "3");
//            return settings;
//        }
//    }
//}
