using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace bns_ch_check
{

  public class BNSXMLNameChecker
  {

    private string path;
    public BNSXMLNameChecker(string path)
    {
      this.path = path;
    }

    public async Task CheckName(string name, string translatedName)
    {


      using (Stream xmlFile = File.OpenRead(this.path))
      {
        XmlReaderSettings settings = new XmlReaderSettings();

        settings.Async = true;

        using (XmlReader reader = XmlReader.Create(xmlFile, settings))
        {
          string originalValue = "";

          string replacementValue = "";

          string alias = "";

          int v = 0;

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
                // Console.WriteLine("originalValue {0}", originalValue);
                v += 1;
              }
              else if (reader.Name == "replacement")
              {
                await reader.ReadAsync();
                replacementValue = await reader.GetValueAsync();
                // Console.WriteLine("replacementlValue {0}", replacementlValue);
                v += 1;
              }

              if (v == 2)
              {


                if (originalValue.IndexOf(name) != -1 && replacementValue.IndexOf(translatedName) == -1)
                {
                  Console.WriteLine($"检测到名字翻译错误 别名: {alias}");
                }


                alias = "";

                v = 0;

                originalValue = "";

                replacementValue = "";

              }
            }
          }
        }
      }

    }
  }
}