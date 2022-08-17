
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace bns_ch_check;

public class BNSXMLRecover
{
  private string path;

  public BNSXMLRecover(string path)
  {
    this.path = path;
  }

  public void Recover()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");

    string hangulPattern = @"[가-힣]+";

    Regex hangulRegex = new Regex(hangulPattern);

    foreach (XElement textElement in rootElement.Elements("text"))
    {
      string alias = textElement.Attribute("alias").Value;

      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      XCData originalXCData = (XCData)originalElement.FirstNode;

      XCData replacementXCData = (XCData)replacementElement.FirstNode;

      string replacementValue = replacementXCData.Value;

      Match hangulMatch = hangulRegex.Match(replacementValue);

      if (hangulMatch.Success == true)
      {
        replacementElement.ReplaceNodes(originalXCData);
      }
    }

    doc.Save(this.path);
  }
}
