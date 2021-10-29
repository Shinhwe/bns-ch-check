using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace bns_ch_check
{
  public class BNSXmlConvert
  {
    public async Task Convert(string xmlPath)
    {
      using (Stream xmlFile = File.OpenRead(xmlPath))
      {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Async = true;

        using (XmlReader reader = XmlReader.Create(xmlFile, settings))
        {
          string originalValue = "";

          string replacementValue = "";

          string alias = "";

          int v = 0;

          Console.WriteLine("{\n");

          while (await reader.ReadAsync())
          {
            if (reader.NodeType == XmlNodeType.Element)
            {
              if (reader.Name == "text")
              {
                alias = reader.GetAttribute("alias");
              }
              else if (reader.Name == "original")
              {
                await reader.ReadAsync();
                originalValue = await reader.GetValueAsync();

                v += 1;
              }
              else if (reader.Name == "replacement")
              {
                await reader.ReadAsync();
                replacementValue = await reader.GetValueAsync();

                v += 1;
              }

              if (v == 2)
              {
                Console.WriteLine($"\t\"{alias}\": {{\n\t\t\"original\": \"{originalValue}\",\n\t\t\"replacement\": \"{replacementValue}\"\n\t}},");


                alias = "";

                v = 0;

                originalValue = "";

                replacementValue = "";
              }
            }
          }
        }

        Console.WriteLine("}\n");
      }
    }
  }
}