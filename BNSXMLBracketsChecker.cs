using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace bns_ch_check
{

  public class BNSXMLBracketsChecker
  {
    public async Task CheckBrackets(string path)
    {
      using (Stream xmlFile = File.OpenRead(path))
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
}