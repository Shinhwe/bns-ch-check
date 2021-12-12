
using System.Text.RegularExpressions;
namespace bns_ch_check;

public class BNSXmlReader
{
  public async Task Read(string xmlPath)
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

              string hangulPattern = @"[가-힣]+";

              string numberPattern = @"(\d+,){0,1}\d+";

              Regex hangulRegex = new Regex(hangulPattern);

              Match hangulMatch = hangulRegex.Match(replacementValue);

              Regex numberRegex = new Regex(numberPattern);

              MatchCollection replacementNumberMatchCollection = numberRegex.Matches(replacementValue);

              MatchCollection originalNumberMatchCollection = numberRegex.Matches(originalValue);

              // if (replacementNumberMatchCollection.Count != originalNumberMatchCollection.Count)
              // {
              //   Console.WriteLine("译文数字数量和原文数字数量不符! 译文 = {0} 别名 = {1}", replacementValue, alias);
              // }
              // else if (originalNumberMatchCollection.Count > 0)
              // {
              //   for (int i = 0; i < originalNumberMatchCollection.Count; i++)
              //   {
              //     string originalNumberText = originalNumberMatchCollection[i].Value.Replace(",", "");

              //     string replacementNumberText = replacementNumberMatchCollection[i].Value.Replace(",", "");

              //     int originalNumber = Convert.ToInt32(originalNumberText);

              //     int replacementNumber = Convert.ToInt32(replacementNumberText);

              //     if (originalNumber != replacementNumber)
              //     {
              //       Console.WriteLine("译文数字和原文数字不符! 译文 = {0} 别名 = {1}", replacementValue, alias);
              //     }
              //   }
              // }

              if (hangulMatch.Success == true)
              {
                Console.WriteLine("译文有韩文! 译文 = {0} 别名 = {1}", replacementValue, alias);
              }

              alias = "";

              v = 0;

              originalValue = "";

              replacementValue = "";

            }

          }
          // switch (reader.NodeType)
          // {
          //   case XmlNodeType.Element:
          //     Console.WriteLine("Start Element {0}", reader.Name);
          //     break;
          //   case XmlNodeType.Text:
          //     Console.WriteLine("Text Node: {0}",
          //              await reader.GetValueAsync());
          //     break;
          //   case XmlNodeType.EndElement:
          //     Console.WriteLine("End Element {0}", reader.Name);
          //     break;
          //   default:
          //     Console.WriteLine("Other node {0} with value {1}",
          //                     reader.NodeType, reader.Value);
          //     break;
          // }
        }
      }
    }
  }
}
