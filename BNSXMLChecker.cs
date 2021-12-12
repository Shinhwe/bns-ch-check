
using System.Text.RegularExpressions;


namespace bns_ch_check;


public class BNSXMLChecker
{
  private string path;

  public BNSXMLChecker(string path)
  {
    this.path = path;
  }
  public async Task CheckBrackets()
  {
    using (Stream xmlFile = File.OpenRead(this.path))
    {
      XmlReaderSettings settings = new XmlReaderSettings();

      settings.Async = true;

      using (XmlReader reader = XmlReader.Create(xmlFile, settings))
      {
        string alias = "";

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

            }
            else if (reader.Name == "replacement")
            {
              await reader.ReadAsync();

              string replacementValue = await reader.GetValueAsync();

              int bracketsCount = getNumber(replacementValue);

              if (bracketsCount % 2 != 0)
              {
                Console.WriteLine($"檢測到括號數量錯誤! 別名 {alias}");
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckAchieve()
  {
    using (Stream xmlFile = File.OpenRead(this.path))
    {
      XmlReaderSettings settings = new XmlReaderSettings();

      settings.Async = true;

      string hangulPattern = @"[가-힣]+";

      Regex hangulRegex = new Regex(hangulPattern);

      using (XmlReader reader = XmlReader.Create(xmlFile, settings))
      {
        string alias = "";

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

            }
            else if (reader.Name == "replacement")
            {
              await reader.ReadAsync();



              if (alias.IndexOf("Achieve.") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"成就译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  private int getNumber(string str)
  {
    int num = 0;
    for (int i = 0; i < str.Length; i++)
    {
      if (str[i].ToString() == "[" || str[i].ToString() == "]")
      {
        num += 1;
      }
    }
    return num;
  }
}
