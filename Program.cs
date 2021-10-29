

using System;
using System.Threading.Tasks;

namespace bns_ch_check
{
  class Program
  {
    static async Task Main(string[] args)
    {


      // BNSXmlConvert bnsXmlConvert = new BNSXmlConvert();

      // await bnsXmlConvert.Convert("/Users/shinhwe/after.xml");

      // BNSXMLCompare bnsXmlCompare = new BNSXMLCompare();

      // await bnsXmlCompare.Compare("/Users/shinhwe/before.xml", "/Users/shinhwe/after.xml");

      // BNSXmlReader bnsXmlReader = new BNSXmlReader();

      // await bnsXmlReader.Read("/Users/shinhwe/bns-ch-text/Translation64.xml");

      BNSXMLNameChecker bnsXMLNameChecker = new BNSXMLNameChecker("/Users/shinhwe/bns-ch-text/Translation64.xml");

      await bnsXMLNameChecker.CheckName("영생의 사원 광장 교환상인 희소안", "영생의 사원 광장 교환상인 희소안");

    }
  }
}
