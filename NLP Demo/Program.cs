using edu.stanford.nlp.ie.crf;
using NLP_Demo.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace NLP_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var classifiersDirecrory = Environment.CurrentDirectory + @"\stanford-ner-2016-10-31\classifiers";

            // Loading 7 class classifier model
            var classifier = CRFClassifier.getClassifierNoExceptions(Path.Combine(classifiersDirecrory, "english.muc.7class.distsim.crf.ser.gz"));

            //Load the document that needs to be recognized with Named Entities contained in it.
            var document = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "demo.txt"));

            //Use the classifyToString method with the document loaded as the 1st argument and 
            //give "xml" as 2nd argument for output format with preserveSpacing set to true as 3rd argument
            string xmlContent = classifier.classifyToString(document, "xml", true);

            //Wrap the reslutant xmlContent with parent and WiCollection tag.
            //This is just for XML Deserialization that eases to perform LINQ operations
            var xml = $"<WiCollection><parent>{xmlContent}</parent></WiCollection>";

            //POCO to hold DeSerialized XML
            WiCollection wiCollection = null;

            //Deserialize XML
            XmlSerializer serializer = new XmlSerializer(typeof(WiCollection));
            using (TextReader reader = new StringReader(xml))
            {
                wiCollection = (WiCollection)serializer.Deserialize(reader);
            }

            //Iterate and print standard Entity types
            var entities = Enum.GetValues(typeof(Entity)).Cast<Entity>();
            foreach (var entity in entities)
            {
                Console.WriteLine($"-----------{entity}-----------");
                var tags = wiCollection.Wi.Where(x => x.Entity.ToLowerInvariant() == entity.ToString().ToLowerInvariant());

                Console.WriteLine(string.Join(Environment.NewLine, tags.Select(w=>w.Text)));
            }
            Console.Read();
        }
    }
}
