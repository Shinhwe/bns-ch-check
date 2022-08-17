

using System.Xml.Linq;

namespace bns_ch_check;


public class BNSXMLMerge
{

  public async Task Merge(string beforePath, string afterPath)
  {

    Dictionary<string, BNSXmlData> sourceDictionary = new();

    Dictionary<string, string> keyDictionary = new(); // key: nextKey


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

              if (sourceDictionary.ContainsKey(alias) == true)
              {

                if (keyDictionary.ContainsKey(alias))
                {
                  string mergeNextKey = keyDictionary[alias];

                  string[] mergeNextKeyArray = mergeNextKey.Split("_mergenextkey_");

                  int keyIndex = Convert.ToInt32(mergeNextKeyArray[1]);

                  keyDictionary[alias] = alias + "_mergenextkey_" + (keyIndex + 1);

                  alias = alias + mergeNextKey;
                }
                else
                {
                  keyDictionary.Add(alias, alias + "_mergenextkey_2");

                  alias = alias + "_mergenextkey_1";
                }
              }


              sourceDictionary.Add(alias, new BNSXmlData
              {
                originalValue = originalValue,
                replacementValue = replacementValue
              });

              alias = "";

              v = 0;

              originalValue = "";

              replacementValue = "";

            }

          }

        }
      }
    }

    // autoId = int.Parse(reader.GetAttribute("alias"));

    keyDictionary = new(); // key: nextKey

    XDocument doc = XDocument.Load(afterPath);

    XElement rootElement = doc.Element("table");

    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement replacementElement = textElement.Element("replacement");

      int autoId = int.Parse(textElement.Attribute("autoId").Value);

      string alias = textElement.Attribute("alias").Value;

      string originalAlias = alias;

      XElement originalElement = textElement.Element("original");

      XCData originalXCData = (XCData)originalElement.FirstNode;

      string originalValue = originalXCData.Value;

      if (keyDictionary.ContainsKey(alias))
      {
        string mergeNextKey = keyDictionary[alias];

        string[] mergeNextKeyArray = mergeNextKey.Split("_mergenextkey_");

        int keyIndex = Convert.ToInt32(mergeNextKeyArray[1]);

        alias = keyDictionary[alias];

        keyDictionary[alias] = alias + "_mergenextkey_" + (keyIndex + 1);
      }
      else
      {
        keyDictionary.Add(alias, alias + "_mergenextkey_1");
      }

      if (sourceDictionary.ContainsKey(alias))
      {
        if (sourceDictionary[alias].originalValue == originalValue)
        {
          replacementElement.ReplaceNodes(new XCData(sourceDictionary[alias].replacementValue));
        }
        else
        {
          replacementElement.ReplaceNodes(new XCData(originalValue));
          Console.WriteLine($"原文变更 {originalAlias}");
          Console.WriteLine($"變更前原文 {sourceDictionary[alias].originalValue}");
          Console.WriteLine($"變更前譯文 {sourceDictionary[alias].replacementValue}");
          Console.WriteLine($"變更後原文 {originalValue}");
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();
          Console.WriteLine();

        }
      }
      else
      {
        Console.WriteLine($"新增条目 {originalAlias}");
      }

    }

    doc.Save(afterPath);

  }

  public async Task MergeFromChineseFile(string sourcePath, string chineseFile, string incldueAlias)
  {

    Dictionary<string, string> sourceDictionary = new Dictionary<string, string>();


    using (Stream xmlFile = File.OpenRead(chineseFile))
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

              if (sourceDictionary.ContainsKey(alias) == false)
              {
                sourceDictionary.Add(alias, replacementValue);
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




    // autoId = int.Parse(reader.GetAttribute("alias"));

    XDocument doc = XDocument.Load(sourcePath);

    XElement rootElement = doc.Element("table");

    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement replacementElement = textElement.Element("replacement");

      int autoId = int.Parse(textElement.Attribute("autoId").Value);

      string alias = textElement.Attribute("alias").Value;

      if (alias.ToLower().IndexOf(incldueAlias) != -1 && sourceDictionary.ContainsKey(alias))
      {
        replacementElement.ReplaceNodes(new XCData(sourceDictionary[alias]));
      }

    }

    doc.Save(sourcePath);

  }


  public async Task MergeFromChineseFile(string sourcePath, string chineseFile, int startIndex, int endIndex)
  {

    Dictionary<string, string> sourceDictionary = new Dictionary<string, string>();


    using (Stream xmlFile = File.OpenRead(chineseFile))
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

              v += 1;
            }
            else if (reader.Name == "replacement")
            {
              await reader.ReadAsync();
              replacementValue = await reader.GetValueAsync();

              v += 1;
            }

            if (v == 1 && String.IsNullOrEmpty(reader.Name) == false && reader.Name != "replacement")
            {
              Console.WriteLine(alias);
              Console.WriteLine(v);
              Console.WriteLine(reader.Name);
            }

            if (v == 2)
            {

              if (sourceDictionary.ContainsKey(alias) == false)
              {

                sourceDictionary.Add(alias, replacementValue);
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




    // autoId = int.Parse(reader.GetAttribute("alias"));

    XDocument doc = XDocument.Load(sourcePath);

    XElement rootElement = doc.Element("table");



    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement replacementElement = textElement.Element("replacement");

      int autoId = int.Parse(textElement.Attribute("autoId").Value);

      string alias = textElement.Attribute("alias").Value;

      if (autoId >= startIndex && autoId <= endIndex && sourceDictionary.ContainsKey(alias))
      {
        replacementElement.ReplaceNodes(new XCData(sourceDictionary[alias]));
      }

    }

    doc.Save(sourcePath);

  }
}
