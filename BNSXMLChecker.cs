
using System.Text.RegularExpressions;


namespace bns_ch_check;


public class BNSXMLChecker
{
  private string path;

  public BNSXMLChecker(string path)
  {
    this.path = path;
  }
  public async Task CheckXML()
  {
    using (Stream xmlFile = File.OpenRead(this.path))
    {
      XmlReaderSettings settings = new XmlReaderSettings();

      settings.Async = true;

      using (XmlReader reader = XmlReader.Create(xmlFile, settings))
      {
        string alias = "";

        int v = 0;

        while (await reader.ReadAsync())
        {
          if (reader.NodeType == XmlNodeType.Element)
          {
            if (reader.Name == "text")
            {
              alias = reader.GetAttribute("alias");
              if (v == 1)
              {
                Console.WriteLine($"检测到缺少replacement! 別名 {alias}");
                v = 0;
              }
            }
            else if (reader.Name == "original")
            {
              if (v == 1)
              {
                Console.WriteLine($"检测到缺少replacement! 別名 {alias}");
                v = 0;
              }
              else
              {
                v += 1;
              }
            }
            else if (reader.Name == "replacement")
            {
              await reader.ReadAsync();

              string replacementValue = await reader.GetValueAsync();

              int bracketsCount = getNumber(replacementValue, "[", "]");

              int quoteCount = getNumber(replacementValue, "「", "」");

              int innerHTMLhasError = checkInnerHTML(replacementValue);

              if (bracketsCount % 2 != 0)
              {
                Console.WriteLine($"檢測到括號數量錯誤! 別名 {alias}");
              }
              if (quoteCount % 2 != 0)
              {
                Console.WriteLine($"檢測到引用符號數量錯誤! 別名 {alias}");
              }

              if (innerHTMLhasError != 0)
              {
                Console.WriteLine($"檢測到內置HTML標籤錯誤! 別名 {alias}");
              }

              v += 1;
            }

            if (v == 2)
            {
              v = 0;
            }
          }
        }
      }
    }
  }

  private int checkInnerHTML(string replacementValue)
  {
    // if (replacementValue.IndexOf("<arg") != -1)
    // {
    //   return 1;
    // }
    // if (replacementValue.IndexOf("<image") != -1)
    // {
    //   return 2;
    // }
    if (Regex.Matches(replacementValue, "<font").Count != Regex.Matches(replacementValue, "</font>").Count)
    {
      return 3;
    }
    return 0;
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



              if (alias.ToLower().IndexOf("achieve.") != -1 && alias.ToLower().IndexOf("test") == -1)
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

  public async Task CheckEffect()
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



              if (alias.ToLower().IndexOf("effect.") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"EFFECT译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckSkillTooltipAttr()
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



              if ((alias.IndexOf("SkillTooltipAttr.") != -1 || alias.IndexOf("SS.") != -1 || alias.IndexOf("SSG.") != -1) && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"SkillTooltipAttr译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckSkin()
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



              if ((alias.ToLower().IndexOf("skin.") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"SKIN译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckSkill()
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



              if (((alias.ToLower().IndexOf("skill.name") != -1 || alias.ToLower().IndexOf("itemskill") != -1 || alias.ToLower().IndexOf("text.skill.") != -1 || alias.ToLower().IndexOf("skill.mainInfo") != -1 || alias.ToLower().IndexOf("skill.subinfo") != -1) && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"skillName译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckUI()
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



              if ((alias.ToLower().IndexOf("ui.") != -1 || alias.ToLower().IndexOf("uicommand.") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"UI译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckStore()
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



              if ((alias.ToLower().IndexOf("store2.") != -1 & alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"Store译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }



  public async Task CheckNPC()
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



              if ((alias.ToLower().IndexOf("npc.name2.") != -1 || alias.ToLower().IndexOf("_indi_") != -1 || alias.ToLower().IndexOf("npc.title2.") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"NPC译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckAcquirePlace()
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



              if (alias.ToLower().IndexOf(".acquireplace.") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"AcquirePlace译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckMSG()
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



              if (alias.ToLower().IndexOf("msg.") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"MSG译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckCH()
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



              if ((alias.ToLower().IndexOf("ch_") != -1 || alias.ToLower().IndexOf("action-") != -1 || alias.ToLower().StartsWith("gm_") || alias.ToLower().StartsWith("e_") || alias.ToLower().IndexOf("_voice") != -1 || alias.ToLower().StartsWith("me_") || alias.ToLower().StartsWith("ep11") || alias.ToLower().StartsWith("indi") || alias.ToLower().StartsWith("changeclass")) && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"CH译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckFieldItem()
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



              if ((alias.ToLower().IndexOf("fielditem.") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"Fielditem译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckAction()
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



              if ((alias.ToLower().IndexOf(".action") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"Action译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckEnv()
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



              if ((alias.ToLower().IndexOf("_env") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"Env译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckItem()
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



              if (((alias.ToLower().IndexOf("item.name") != -1 || alias.ToLower().IndexOf("item.desc") != -1) && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"Item译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckSetAttr()
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



              if ((alias.ToLower().IndexOf("set_attr") != -1 && alias.ToLower().IndexOf("test") == -1))
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"SetAttr译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckTrainAndEffectDesc()
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



              if ((alias.ToLower().IndexOf("effect_desc") != -1 || alias.ToLower().IndexOf("train_desc") != -1) && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"EffectDesc译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  public async Task CheckNickName()
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



              if (alias.ToLower().IndexOf("item.nick.") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"NickName译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckSkillTrainingRoom()
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



              if (alias.ToLower().IndexOf("text.skilltrainingroomgroup") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"SkillTrainingRoom译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckSealed()
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



              if (alias.ToLower().IndexOf("general_grocery_sealed") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"Sealed译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }


  public async Task CheckItemBrand()
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



              if (alias.ToLower().IndexOf("itembrand") != -1 && alias.ToLower().IndexOf("test") == -1)
              {
                string replacementValue = await reader.GetValueAsync();

                Match hangulMatch = hangulRegex.Match(replacementValue);

                if (hangulMatch.Success == true)
                {

                  Console.WriteLine($"ItemBrand译文有韩文! 別名 {alias}");
                }
              }
            }
          }
        }
      }
    }
  }

  private int getNumber(string str, string leftChar, string rightChar)
  {
    int num = 0;
    for (int i = 0; i < str.Length; i++)
    {
      if (str[i].ToString() == leftChar || str[i].ToString() == rightChar)
      {
        num += 1;
      }
    }
    return num;
  }
}
