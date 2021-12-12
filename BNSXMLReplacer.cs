
using System.Xml.Linq;

namespace bns_ch_check;

public class BNSXMLReplacer
{
  private string path;

  public BNSXMLReplacer(string path)
  {
    this.path = path;
  }

  public void Replace(Dictionary<string, string> replaceMap)
  {



    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");

    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      XCData originalXCData = (XCData)originalElement.FirstNode;



      if (replaceMap.ContainsKey(originalXCData.Value))
      {
        replacementElement.ReplaceNodes(new XCData(replaceMap[originalXCData.Value]));
      }
    }

    doc.Save(this.path);
  }
}
