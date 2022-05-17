using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace ExamSystem.WpfNetCore.CustomControls
{
    public class RichTextBoxHelper : DependencyObject
    {
        private static List<Guid> _recursionProtection = new List<Guid>();

        public static string GetDocumentXaml(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentXamlProperty);
        }

        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            string b = SaveXamlPackage((RichTextBox)obj, "qwkewqk");

            var fw1 = (FrameworkElement)obj;
            if (fw1.Tag == null || (Guid)fw1.Tag == Guid.Empty)
                fw1.Tag = Guid.NewGuid();
            _recursionProtection.Add((Guid)fw1.Tag);
            obj.SetValue(DocumentXamlProperty, b);
            _recursionProtection.Remove((Guid)fw1.Tag);
            
        }
        public static string SaveXamlPackage(RichTextBox richTB,string _fileName)
        {
            TextRange range;
            MemoryStream fStream;
            range = new TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd);
            fStream = new MemoryStream();
            range.Save(fStream, DataFormats.XamlPackage);
            string a = Convert.ToBase64String(fStream.ToArray());



            fStream.Close();

            return a;
        }

        public static readonly DependencyProperty DocumentXamlProperty = DependencyProperty.RegisterAttached(
            "DocumentXaml",
            typeof(string),
            typeof(RichTextBoxHelper),
            new FrameworkPropertyMetadata(
                "",
                FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (obj, e) =>
                {
                    var richTextBox = (RichTextBox)obj;
                    if (richTextBox.Tag != null && _recursionProtection.Contains((Guid)richTextBox.Tag))
                        return;


                    // Parse the XAML to a document (or use XamlReader.Parse())

                   

                    try
                    {
                        

                        string docXaml = GetDocumentXaml(richTextBox);
                        var stream = new MemoryStream(Convert.FromBase64String(docXaml));
                        FlowDocument doc = new FlowDocument();
                        if (!string.IsNullOrEmpty(docXaml))
                        {
                            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
                            range.Load(stream, DataFormats.XamlPackage);
                            /*doc = (FlowDocument)XamlReader.Load(stream);*/
                        }
                        else
                        {
                            doc = new FlowDocument();
                        }
                                                                    
                        // Set the document
                        richTextBox.Document = doc;
                    }
                    catch (Exception ex)
                    {

                        richTextBox.Document = new FlowDocument();
                    }

                    // When the document changes update the source
                    richTextBox.TextChanged += (obj2, e2) =>
                    {
                        RichTextBox richTextBox2 = obj2 as RichTextBox;
                        if (richTextBox2 != null)
                        {
                            SetDocumentXaml(richTextBox, XamlWriter.Save(richTextBox2.Document));
                        }
                    };
                }
            )
        );
    }
}
