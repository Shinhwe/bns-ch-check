

using System.Xml.Linq;

namespace bns_ch_check;




public class BNSXMLCompare
{

  public async Task Compare(string beforePath, string afterPath)
  {
    await this.Compare(beforePath, afterPath, false);
  }

  public async Task Compare(string beforePath, string afterPath, bool showDiff)
  {

    Dictionary<string, BNSXmlData> beforeDictionary = new Dictionary<string, BNSXmlData>();

    Dictionary<string, BNSXmlData> afterDictionary = new Dictionary<string, BNSXmlData>();

    using (Stream xmlFile = File.OpenRead(beforePath))
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


              if (beforeDictionary.ContainsKey(alias))
              {
                // Console.WriteLine($"别名重复 {alias}");
              }
              else
              {
                beforeDictionary.Add(alias, new BNSXmlData
                {
                  originalValue = originalValue,
                  replacementValue = replacementValue
                });
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

    using (Stream xmlFile = File.OpenRead(afterPath))
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

              if (afterDictionary.ContainsKey(alias))
              {
                // Console.WriteLine($"别名重复 {alias}");
              }
              else
              {
                afterDictionary.Add(alias, new BNSXmlData
                {
                  originalValue = originalValue,
                  replacementValue = replacementValue
                });
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


    foreach (string alias in afterDictionary.Keys)
    {
      if (beforeDictionary.ContainsKey(alias) == false)
      {
        Console.WriteLine($"新增条目 {alias}");
      }
      else if (afterDictionary[alias].originalValue != beforeDictionary[alias].originalValue)
      {
        Console.WriteLine($"原文变更 {alias}");

        if (showDiff == true)
        {
          Console.WriteLine($"變更前原文 {beforeDictionary[alias].originalValue}");
          Console.WriteLine($"變更後原文 {afterDictionary[alias].originalValue}");
        }
      }
    }
  }

}
