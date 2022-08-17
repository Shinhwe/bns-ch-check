


namespace bns_ch_check;

public class BNSXMLItemNameToJSON
{
  private string path;
  public BNSXMLItemNameToJSON(string path)
  {
    this.path = path;
  }

  public async Task ToJSON()
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

        List<string> keyList = new List<string>();

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

              if (alias.IndexOf("Item.Name2.") != -1 && alias.ToLower().IndexOf("test") == -1 && replacementValue.StartsWith("+") == false)
              {
                if (keyList.Contains(replacementValue) == false)
                {
                  Console.WriteLine($"\t\"{replacementValue}\": \"{originalValue}\",");

                  keyList.Add(replacementValue);
                }
              }


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
