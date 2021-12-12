

using System.Xml.Linq;

namespace bns_ch_check;


public class BNSXMLMerge
{

  public async Task Merge(string sourcePath, string mergePath, int startIndex, int endIndex)
  {

    Dictionary<string, string> sourceDictionary = new Dictionary<string, string>();


    using (Stream xmlFile = File.OpenRead(sourcePath))
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

    XDocument doc = XDocument.Load(mergePath);

    XElement rootElement = doc.Element("table");

    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement replacementElement = textElement.Element("replacement");

      int autoId = int.Parse(textElement.Attribute("autoId").Value);

      string alias = textElement.Attribute("alias").Value;

      if (startIndex <= autoId && autoId <= endIndex)
      {
        replacementElement.ReplaceNodes(new XCData(sourceDictionary[alias]));
      }

    }

    doc.Save(mergePath);

  }
}
