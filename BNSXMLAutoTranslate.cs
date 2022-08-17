
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace bns_ch_check;

public class BNSXMLAutoTranslate
{
  private string path;

  private Dictionary<string, string> translateDictionary;

  public BNSXMLAutoTranslate(string path, Dictionary<string, string> translateDictionary)
  {
    this.path = path;
    this.translateDictionary = translateDictionary;
  }

  public void translateEnchantStone()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");

    string namePattern = @"(\+\d+ ){0,1}(.{1,}) \[(.{1,})\]";

    string descPattern = "(.*? 계열의 )(<font name=\"00008130.UI.Vital_LightBlue\">)(.*?)(</font>)( 무공 및 관련된 특성 무공이 강화됩니다\\.{0,1})(<br/>)([원,진]기석 홈이 확장된 무기에 장착할 수 있습니다\\.{0,1}){0,1}";


    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;


      XCData originalXCData = (XCData)originalElement.FirstNode;


      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("name2.general_enchantstone") != -1 && alias.ToLower().IndexOf("test") == -1)
      {


        Match match = Regex.Match(originalXCData.Value, namePattern);

        if (match.Success)
        {


          string newValue = "";

          if (string.IsNullOrEmpty(match.Groups[1].Value) == false)
          {
            newValue += match.Groups[1].Value;

          }

          string enchantStoneName = "";

          this.translateDictionary.TryGetValue(match.Groups[2].Value, out enchantStoneName);

          if (String.IsNullOrEmpty(enchantStoneName) == false)
          {

            newValue += enchantStoneName;

            newValue += "[";

            string skillString = match.Groups[3].Value;

            string[] skillArray = skillString.Split("/");

            for (int i = 0; i < skillArray.Length; i++)
            {
              string skillName = skillArray[i];

              if (this.translateDictionary.ContainsKey(skillArray[i]))
              {
                skillName = this.translateDictionary[skillArray[i]];
              }

              newValue += skillName;

              if (i < skillArray.Length - 1)
              {
                newValue += "/";
              }
            }

            newValue += "]";

            if (String.IsNullOrEmpty(newValue) == false)
            {
              replacementElement.ReplaceNodes(new XCData(newValue));
            }



          }
        }
      }

      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("desc4.general_enchantstone") != -1 && alias.ToLower().IndexOf("test") == -1)
      {

        Match match = Regex.Match(originalXCData.Value, descPattern);

        string newValue = "";

        while (match.Success)
        {

          for (int i = 1; i < match.Groups.Count; i++)
          {
            if (this.translateDictionary.ContainsKey(match.Groups[i].Value))
            {
              newValue += this.translateDictionary[match.Groups[i].Value];
            }
            else
            {
              newValue += match.Groups[i].Value;
            }
          }

          match = match.NextMatch();
        }

        if (String.IsNullOrEmpty(newValue) == false)
        {
          replacementElement.ReplaceNodes(new XCData(newValue));
        }

      }
    }


    doc.Save(this.path);

  }


  public void translateGroceryBadge()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");

    string namePattern = @"(\+\d+ ){0,1}(.{1,}) \[(.{1,})\]";

    string descPattern = "(.*? 계열의 )(<font name=\"00008130.UI.Vital_LightBlue\">)(.*?)(</font>)( 무공 및 관련된 특성 무공이 강화됩니다\\.{0,1})(<br/>){0,1}";


    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;


      XCData originalXCData = (XCData)originalElement.FirstNode;


      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("name2.general_grocery") != -1 && alias.ToLower().IndexOf("test") == -1)
      {


        Match match = Regex.Match(originalXCData.Value, namePattern);

        if (match.Success)
        {


          string newValue = "";

          if (string.IsNullOrEmpty(match.Groups[1].Value) == false)
          {
            newValue += match.Groups[1].Value;

          }

          string enchantStoneName = "";

          this.translateDictionary.TryGetValue(match.Groups[2].Value, out enchantStoneName);

          if (String.IsNullOrEmpty(enchantStoneName) == false)
          {

            newValue += enchantStoneName;

            newValue += "[";

            string skillString = match.Groups[3].Value;

            string[] skillArray = skillString.Split("/");

            for (int i = 0; i < skillArray.Length; i++)
            {
              string skillName = skillArray[i];

              if (this.translateDictionary.ContainsKey(skillArray[i]))
              {
                skillName = this.translateDictionary[skillArray[i]];
              }

              newValue += skillName;

              if (i < skillArray.Length - 1)
              {
                newValue += "/";
              }
            }

            newValue += "]";

            if (String.IsNullOrEmpty(newValue) == false)
            {
              replacementElement.ReplaceNodes(new XCData(newValue));
            }



          }
        }
      }

      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("desc4.general_groceryl") != -1 && alias.ToLower().IndexOf("test") == -1)
      {

        Match match = Regex.Match(originalXCData.Value, descPattern);

        string newValue = "";

        while (match.Success)
        {

          for (int i = 1; i < match.Groups.Count; i++)
          {
            if (this.translateDictionary.ContainsKey(match.Groups[i].Value))
            {
              newValue += this.translateDictionary[match.Groups[i].Value];
            }
            else
            {
              newValue += match.Groups[i].Value;
            }
          }

          match = match.NextMatch();
        }


        if (String.IsNullOrEmpty(newValue) == false)
        {
          replacementElement.ReplaceNodes(new XCData(newValue));
        }

      }
    }


    doc.Save(this.path);

  }

  public void translateAccessoryDesc()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");


    //10단계 이상 성장 시 분해를 통해 <arg id="item:General_Grocery_Coin_0197" p="id:item.front-icon.scale.120"/> <font name="00008130.Program.Fontset_ItemGrade_7">청룡성</font>을 획득할 수 있습니다.여명 계열의 

    string descPattern = "(능력치가 최대로 성장된 각성 백야반지는 잠재된 기운을 해방시킬 수 있습니다.<br/>){0,1}(분해 시 불라국의 석판에 사용할 수 있는 장비를 획득할 수 있습니다.<br/>){0,1}(능력치가 최대로 성장된 각성 백야귀걸이는 잠재된 기운을 해방시킬 수 있습니다.<br/>){0,1}(능력치가 최대로 성장된 각성 설풍반지는 잠재된 기운을 해방시킬 수 있습니다.<br/>){0,1}(능력치가 최대로 성장된 각성 파천목걸이는 잠재된 기운을 해방시킬 수 있습니다.<br/>){0,1}(10단계 이상 성장 시 분해를 통해 <arg id=\"item:General_Grocery_Coin_0197\" p=\"id:item\\.front-icon\\.scale\\.120\"/> <font name=\"00008130\\.Program\\.Fontset_ItemGrade_7\">청룡성</font>을 획득할 수 있습니다\\.<br/>){0,1}(.*? 계열의 )(<font name=\"00008130.UI.Vital_LightBlue\">)(.*?)(</font>)( 무공 및 관련된 특성 무공이 강화됩니다[ ,\\.]{1,})(<br/>){0,1}";


    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;


      XCData originalXCData = (XCData)originalElement.FirstNode;



      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("item.desc4.general_accessory") != -1 && alias.ToLower().IndexOf("test") == -1)
      {

        Match match1 = Regex.Match(originalXCData.Value, descPattern);

        string newValue = "";

        Console.WriteLine(match1.Success);


        while (match1.Success)
        {

          for (int i = 1; i < match1.Groups.Count; i++)
          {
            string groupValue = match1.Groups[i].Value;

            // Console.WriteLine("i = " + i + " || groupValue = " + groupValue);

            if (i != 2 && groupValue.IndexOf(", ") != -1)
            {
              string[] groupValueSplit = groupValue.Split(", ");

              string multiSkillName = "";

              for (int j = 0; j < groupValueSplit.Length; j++)
              {
                string skillName = groupValueSplit[j];

                if (this.translateDictionary.ContainsKey(skillName))
                {
                  multiSkillName += this.translateDictionary[skillName];
                }
                else
                {
                  Console.WriteLine("技能名未找到" + skillName);
                  multiSkillName += skillName;
                }

                if (j != groupValueSplit.Length - 1)
                {
                  multiSkillName += "、";
                }
              }

              newValue += multiSkillName;
            }
            else if (this.translateDictionary.ContainsKey(groupValue))
            {
              newValue += this.translateDictionary[groupValue];
            }
            else
            {
              if (String.IsNullOrWhiteSpace(groupValue) == false && groupValue.StartsWith("<font") == false && groupValue.StartsWith("</font") == false && groupValue.StartsWith("<br") == false)
              {
                Console.WriteLine("翻譯未找到    ||    " + groupValue);
              }
              newValue += groupValue;
            }
          }

          match1 = match1.NextMatch();
        }

        if (String.IsNullOrEmpty(newValue) == false)
        {
          replacementElement.ReplaceNodes(new XCData(newValue));
        }

        // Console.WriteLine(alias);

        // Console.WriteLine(alias + "    ||    " + newValue);
      }



    }




    doc.Save(this.path);

  }



  public void translateGroceryBox()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");


    string descPattern = "(.*?)<br/>자신의 직업에 맞는 (.*?)을 획득할 수 있습니다.<br/>획득할 수 있는 (.*?)의 능력치는 아래와 같습니다. ";

    string skillPattern = "<br/><image enablescale=\"true\" imagesetpath=\"(.*?)\" scalerate=\"1\\.2\"/> (.*?) <font name=\"00008130\\.UI\\.Vital_LightBlue\">(.*?)</font>";


    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;


      XCData originalXCData = (XCData)originalElement.FirstNode;



      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("grocery_box") != -1 && alias.ToLower().IndexOf("test") == -1)
      {

        string newValue = "";

        Match match1 = Regex.Match(originalXCData.Value, descPattern);

        while (match1.Success)
        {

          for (int i = 1; i < match1.Groups.Count; i++)
          {
            string groupValue = match1.Groups[i].Value;
            if (i is 1)
            {
              newValue += groupValue;
            }
            if (i == 2)
            {
              newValue += "<br/>可以獲得符合自身職業的";
              newValue += this.translateDictionary[groupValue];
              newValue += "。<br/>";
            }
            else if (i == 3)
            {
              newValue += "可獲得的";
              newValue += this.translateDictionary[groupValue];
              newValue += "能力值如下。";
            }
          }

          match1 = match1.NextMatch();
        }

        Match match2 = Regex.Match(originalXCData.Value, skillPattern);



        while (match2.Success)
        {

          for (int i = 1; i < match2.Groups.Count; i++)
          {
            string groupValue = match2.Groups[i].Value;

            // Console.WriteLine("i = " + i + " || groupValue = " + groupValue);

            if (i == 1)
            {
              newValue += "<br/><image enablescale=\"true\" imagesetpath=\"" + groupValue + "\" scalerate=\"1.2\"/>";
            }
            else if (i == 2)
            {
              if (this.translateDictionary.ContainsKey(groupValue))
              {
                newValue += " " + this.translateDictionary[groupValue];
              }
              else
              {
                newValue += " " + groupValue;
              }

              newValue += "<font name=\"00008130.UI.Vital_LightBlue\">";
            }
            else if (i == 3)
            {

              string[] groupValueSplit = groupValue.Split(", ");



              for (int j = 0; j < groupValueSplit.Length; j++)
              {

                string multiSkillName = "";

                string skillName = groupValueSplit[j];


                if (skillName.IndexOf("/") != -1)
                {

                  string[] skillNameSplit = skillName.Split("/");

                  for (int k = 0; k < skillNameSplit.Length; k++)
                  {
                    skillName = skillNameSplit[k];


                    if (this.translateDictionary.ContainsKey(skillName))
                    {
                      multiSkillName += this.translateDictionary[skillName];
                    }
                    else
                    {
                      Console.WriteLine("技能名未找到" + skillName);
                      multiSkillName += skillName;
                    }



                    if (k != skillNameSplit.Length - 1)
                    {
                      multiSkillName += "/";
                    }
                  }
                }
                else
                {

                  if (this.translateDictionary.ContainsKey(skillName))
                  {
                    multiSkillName += this.translateDictionary[skillName];
                  }
                  else
                  {
                    Console.WriteLine("技能名未找到" + skillName);
                    multiSkillName += skillName;
                  }
                }

                if (j != groupValueSplit.Length - 1)
                {
                  multiSkillName += "、";
                }



                newValue += multiSkillName;
              }
            }
          }

          newValue += "</font>";

          match2 = match2.NextMatch();
        }


        if (String.IsNullOrEmpty(newValue) == false)
        {

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font>, <font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 천광석 중 하나를 획득할 수 있습니다. <br/><font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 각성 천광석을 획득할 수도 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">覺醒傳說級</font>天光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font>, <font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 지광석 중 하나를 획득할 수 있습니다. <br/><font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 각성 천광석을 획득할 수도 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">覺醒傳說級</font>地光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font>, <font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 인광석 중 하나를 획득할 수 있습니다. <br/><font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 각성 천광석을 획득할 수도 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">覺醒傳說級</font>人光石。");


          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_4\">최상급</font>, <font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font> 등급의 천광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_4\">最上級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>天光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_4\">최상급</font>, <font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font> 등급의 지광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_4\">最上級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>地光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_4\">최상급</font>, <font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font> 등급의 인광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_4\">最上級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>人光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font>, <font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 천광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>天光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font>, <font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 지광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>地光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_5\">영웅</font>, <font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font> 등급의 인광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_5\">英雄級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>人光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font>, <font name=\"00008130.Program.Fontset_ItemGrade_8\">고대</font> 등급의 천광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_8\">古代級</font>天光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font>, <font name=\"00008130.Program.Fontset_ItemGrade_8\">고대</font> 등급의 지광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_8\">古代級</font>地光石。");

          newValue = newValue.Replace("<font name=\"00008130.Program.Fontset_ItemGrade_7\">전설</font>, <font name=\"00008130.Program.Fontset_ItemGrade_8\">고대</font> 등급의 인광석 중 하나를 획득할 수 있습니다. ", "<replacement><![CDATA[可以獲得<font Name=\"00008130.Program.Fontset_ItemGrade_7\">傳說級</font>或<font Name=\"00008130.Program.Fontset_ItemGrade_8\">古代級</font>人光石。");

          replacementElement.ReplaceNodes(new XCData(newValue));
        }

        // Console.WriteLine(alias);

        // Console.WriteLine(alias + "    ||    " + newValue);
      }



    }




    doc.Save(this.path);

  }



  public void translateItemNameAndDesc()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");


    Dictionary<string, string> translateDictionary = new();


    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;

      XCData originalXCData = (XCData)originalElement.FirstNode;

      XCData replacementXCData = (XCData)replacementElement.FirstNode;

      string replacementValue = replacementXCData.Value;

      string originalValue = originalXCData.Value;

      string hangulPattern = @"[가-힣]+";

      Regex hangulRegex = new Regex(hangulPattern);

      if (string.IsNullOrEmpty(alias) == false && (alias.ToLower().IndexOf("item.name2") != -1 || alias.ToLower().IndexOf("item.desc") != -1) && alias.ToLower().IndexOf("test") == -1)
      {




        if (translateDictionary.ContainsKey(originalValue) == true)
        {
          replacementElement.ReplaceNodes(new XCData(translateDictionary[originalValue]));
        }
        else
        {
          Console.WriteLine(originalValue + " = " + replacementValue);
          translateDictionary.Add(originalValue, replacementValue);
        }

      }

    }




    doc.Save(this.path);

  }



  public void translateAchieve()
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");


    Dictionary<string, string> translateDictionary = new();


    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;

      XCData originalXCData = (XCData)originalElement.FirstNode;

      XCData replacementXCData = (XCData)replacementElement.FirstNode;

      string replacementValue = replacementXCData.Value;

      string originalValue = originalXCData.Value;

      string hangulPattern = @"[가-힣]+";

      Regex hangulRegex = new Regex(hangulPattern);

      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("achieve") != -1 && alias.ToLower().IndexOf("test") == -1)
      {

        Match hangulMatch = hangulRegex.Match(replacementValue);

        if (hangulMatch.Success == true)
        {
          if (translateDictionary.ContainsKey(originalValue) == true)
          {
            replacementElement.ReplaceNodes(new XCData(translateDictionary[originalValue]));
          }
          else
          {
            Console.WriteLine("没有相同的成就名字! 别名" + alias);
          }
        }
        else if (translateDictionary.ContainsKey(originalValue) == false)
        {
          Console.WriteLine(originalValue + " = " + replacementValue);
          translateDictionary.Add(originalValue, replacementValue);
        }

      }

    }




    doc.Save(this.path);

  }


  public void translateWeaponName(Dictionary<string, string> weaponTypeTranslateDictionary)
  {

    XDocument doc = XDocument.Load(this.path);

    XElement rootElement = doc.Element("table");


    Dictionary<string, string> weaponNameDictionary = new();

    foreach (string key in this.translateDictionary.Keys)
    {
      foreach (string key2 in weaponTypeTranslateDictionary.Keys)
      {
        string weaponKRName = key + key2;

        string weaponCNName = this.translateDictionary[key] + weaponTypeTranslateDictionary[key2];

        weaponNameDictionary.Add(weaponKRName, weaponCNName);
      }
    }

    foreach (XElement textElement in rootElement.Elements("text"))
    {
      XElement originalElement = textElement.Element("original");

      XElement replacementElement = textElement.Element("replacement");

      string alias = textElement.Attribute("alias").Value;

      XCData originalXCData = (XCData)originalElement.FirstNode;

      XCData replacementXCData = (XCData)replacementElement.FirstNode;

      string replacementValue = replacementXCData.Value;

      string originalValue = originalXCData.Value;


      if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("item.name2") != -1 && alias.ToLower().IndexOf("weapon") != -1 && alias.ToLower().IndexOf("test") == -1)
      {

        if (weaponNameDictionary.ContainsKey(originalValue))
        {
          replacementElement.ReplaceNodes(new XCData(weaponNameDictionary[originalValue]));
        }
      }

    }

    doc.Save(this.path);

  }



  // public void translateWeaponName()
  // {

  //   XDocument doc = XDocument.Load(this.path);

  //   XElement rootElement = doc.Element("table");

  //   Dictionary<string, string> weaponNameDictionary = new();


  //   foreach (XElement textElement in rootElement.Elements("text"))
  //   {
  //     XElement originalElement = textElement.Element("original");

  //     XElement replacementElement = textElement.Element("replacement");

  //     string alias = textElement.Attribute("alias").Value;

  //     XCData originalXCData = (XCData)originalElement.FirstNode;

  //     XCData replacementXCData = (XCData)replacementElement.FirstNode;

  //     string replacementValue = replacementXCData.Value;

  //     string originalValue = originalXCData.Value;


  //     if (string.IsNullOrEmpty(alias) == false && alias.ToLower().IndexOf("item.name2") != -1 && (alias.ToLower().IndexOf("_weapon_sword_") != -1 || alias.ToLower().IndexOf("general_grocery_sealed") != -1 || alias.ToLower().IndexOf("_weapon_greatsword_") != -1) && alias.ToLower().IndexOf("test") == -1)
  //     {

  //       if (originalValue.IndexOf("옛") != -1)
  //       {
  //         continue;
  //       }

  //       if (weaponNameDictionary.ContainsKey(originalValue))
  //       {
  //         replacementElement.ReplaceNodes(new XCData(weaponNameDictionary[originalValue]));
  //       }
  //       else if (originalValue.IndexOf("검") != -1)
  //       {
  //         if (weaponNameDictionary.ContainsKey(originalValue.Replace("검", "대검")) == false && replacementValue.IndexOf("劍") != -1)
  //         {
  //           weaponNameDictionary.Add(originalValue.Replace("검", "대검"), replacementValue.Replace("劍", "巨劍"));
  //         }
  //       }
  //       else
  //       {
  //         Console.WriteLine("沒有處理" + alias);
  //       }
  //     }

  //   }

  //   doc.Save(this.path);

  // }


}
