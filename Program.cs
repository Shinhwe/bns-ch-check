

using System;
using System.Collections.Generic;
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

      // BNSXMLBracketsChecker bnsXMLBracketsChecker = new BNSXMLBracketsChecker();

      // await bnsXMLBracketsChecker.CheckBrackets("/Users/shinhwe/bns-ch-text/Translation64.xml");

      // BNSXMLNameChecker bnsXMLNameChecker = new BNSXMLNameChecker("/Users/shinhwe/bns-ch-text/Translation64.xml");

      // await bnsXMLNameChecker.CheckName("영생의 사원 광장 교환상인 희소안", "永生寺廣場交換商人 姬少安");

      Dictionary<string, string> replaceMap = new Dictionary<string, string>()
      {
        // ["설풍 원기석 [화룡연참/급소베기/창룡검결]"] = "雪風元氣石[火龍連斬/奪命劍/蒼龍劍訣]",
        // ["설풍 원기석 [화룡연참/만월베기/급소베기/창룡검결/어검비산]"] = "雪風元氣石[火龍連斬/滿月斬/奪命劍/蒼龍劍訣/御劍飛散]",
        // ["설풍 원기석 [화룡연참/발도/급소베기/십마령섬/창룡검결/무명검결]"] = "雪風元氣石[火龍連斬/拔劍/奪命劍/弒魔靈閃/蒼龍劍訣/無名劍訣]",
        // ["설풍 원기석 [화룡연참/번개베기/급소베기/발도/창룡검결/어검 연속베기]"] = "雪風元氣石[火龍連斬/雷斬/奪命劍/拔劍/蒼龍劍訣/御劍連斬]",




        // ["설풍 원기석 [적룡권/풍령각/광란]"] = "雪風元氣石[赤龍拳/風令腳/狂亂]",
        // ["설풍 원기석 [적룡권/산사태/풍령각/철산고/광란/살육]"] = "雪風元氣石[赤龍拳/山崩/風令腳/鐵山靠/狂亂/殺戮]",
        // ["설풍 원기석 [적룡권/용호포/풍령각/회천각/광란/쌍장]"] = "雪風元氣石[赤龍拳/龍虎步/風令腳/回天腳/狂亂/雙掌]",
        // ["설풍 원기석 [적룡권/붕권/풍령각/광란/도산봉추]"] = "雪風元氣石[赤龍拳/崩拳/風令腳/狂亂/刀山崩竹]",




        // ["설풍 원기석 [말벌/큰 해바라기/와장창]"] = "雪風元氣石[馬蜂/大向日葵/轟隆隆！]",
        // ["설풍 원기석 [말벌/가시덩굴/큰 해바라기/가시덩굴/와장창/빠직]"] = "雪風元氣石[馬蜂/荊棘籐/大向日葵/轟隆隆！/氣呼呼！]",
        // ["설풍 원기석 [말벌/투척밤송이/큰 해바라기/와장창/뻥이요]"] = "雪風元氣石[馬蜂/飛栗球/大向日葵/轟隆隆！/騙你的！]",
        // ["설풍 원기석 [말벌/꿀밤/큰 해바라기/해바라기/와장창/쏜다냥]"] = "雪風元氣石[馬蜂/爆栗/大向日葵/向日葵/轟隆隆！/發射喵]",




        // ["설풍 원기석 [폭열신장/빙백연혼경/폭뢰파]"] = "雪風元氣石[爆炎神掌/冰壁連魂鏡/暴雷波]",
        // ["설풍 원기석 [폭열신장/화염지옥/빙백연혼경/빙백한포/폭뢰파/섬뇌격]"] = "雪風元氣石[爆炎神掌/火炎地獄/冰壁連魂鏡/冰壁寒砲/暴雷波/閃雷擊]",
        // ["설풍 원기석 [폭열신장/유성지/빙백연혼경/설화장/폭뢰파/섬뇌장]"] = "雪風元氣石[爆炎神掌/流星指/冰壁連魂鏡/雪花掌/暴雷波/閃雷掌]",
        // ["설풍 원기석 [폭열신장/화련장/빙백연혼경/쌍룡파/폭뢰파/연쇄번개]"] = "雪風元氣石[爆炎神掌/火蓮掌/冰壁連魂鏡/雙龍掌/暴雷波/連鎖閃電]",




        // ["설풍 원기석 [파괴/섬멸/쌍월격]"] = "雪風元氣石[破壞/殆滅/雙月擊]",
        // ["설풍 원기석 [파괴/격노/섬멸/격풍/쌍월격/쇄도]"] = "雪風元氣石[破壞/激怒/殆滅/激風/雙月擊/突馳]",
        // ["설풍 원기석 [파괴/대파괴/섬멸/발구르기/쌍월격/금월참]"] = "雪風元氣石[破壞/破壞/殆滅/重踏/雙月擊/金月斬]",
        // ["설풍 원기석 [파괴/분쇄/섬멸/집행/쌍월격/무진]"] = "雪風元氣石[破壞/粉碎/殆滅/執刑/雙月擊/無盡]",




        // ["설풍 원기석 [심장찌르기/뇌절도:살/월영섬]"] = "雪風元氣石[刺心/雷絕刀：殺/月影閃]",
        // ["설풍 원기석 [심장찌르기/암흑살/뇌절도:살/뇌절도/월영섬/오월참]"] = "雪風元氣石[刺心/闇黑殺/雷絕刀：殺/雷絕刀/月影閃/烏月斬]",
        // ["설풍 원기석 [심장찌르기/독무투척/뇌절도:살/월영섬/월영격]"] = "雪風元氣石[刺心/擲毒霧/雷絕刀：殺/月影閃/月影擊]",
        // ["설풍 원기석 [심장찌르기/맹독베기/뇌절도:살/심장찌르기/월영섬/월영살]"] = "雪風元氣石[刺心/猛毒斬/雷絕刀：殺/月影閃/月影殺]",




        // ["설풍 원기석 [태풍참/뇌연섬/영혼가르기]"] = "雪風元氣石[颱風斬/雷炎閃/靈魂斬]",
        // ["설풍 원기석 [태풍참/가르기/뇌연섬/발도/영혼가르기]"] = "雪風元氣石[颱風斬/斷水斬/雷炎閃/拔劍/靈魂斬]",
        // ["설풍 원기석 [태풍참/질풍삼연섬/뇌연섬/절명참/영혼가르기/귀월격]"] = "雪風元氣石[颱風斬/疾風三連斬/雷炎閃/絕命斬/靈魂斬/鬼月擊]",
        // ["설풍 원기석 [태풍참/하늘베기/뇌연섬/천둥베기/영혼가르기/내려베기]"] = "雪風元氣石[颱風斬/天斬/雷炎閃/轟雷斬/靈魂斬/下斬]",




        // ["설풍 원기석 [폭마령/흑염룡/윤회]"] = "雪風元氣石[暴魔靈/黑炎龍/輪迴]",
        // ["설풍 원기석 [폭마령/차원탄/흑염룡/수라/윤회/참절]"] = "雪風元氣石[暴魔靈/次元彈/黑炎龍/夜叉/輪迴/斬絕]",
        // ["설풍 원기석 [폭마령/개문/흑염룡/귀령개문/윤회/검은파도]"] = "雪風元氣石[暴魔靈/開門/黑炎龍/鬼靈開門/輪迴/黑暗波動]",
        // ["설풍 원기석 [폭마령/사령쇄도/흑염룡/귀령쇄도/윤회/안개칼날]"] = "雪風元氣石[暴魔靈/死靈突馳/黑炎龍/鬼靈突馳/輪迴/迷霧刀鋒]",




        // ["설풍 원기석 [창천권/빙륜환/태진각]"] = "雪風元氣石[蒼穹拳/冰輪環/太震腳]",
        // ["설풍 원기석 [창천권/천룡열권/빙륜환/태진각/벽력장]"] = "雪風元氣石[蒼穹拳/天龍烈拳/冰輪環/太震腳/霹靂掌]",
        // ["설풍 원기석 [창천권/발경/빙륜환/한기폭풍/태진각/하염축]"] = "雪風元氣石[蒼穹拳/爪破/冰輪環/寒氣風暴/太震腳/下炎蹴]",
        // ["설풍 원기석 [창천권/패왕권/빙륜환/빙하탄/태진각/나선쌍장]"] = "雪風元氣石[蒼穹拳/霸王拳/冰輪環/冰河彈/太震腳/螺旋雙掌]",




        // ["설풍 원기석 [창천권/빙륜환/태진각]"] = "雪風元氣石[蒼穹拳/冰輪環/太震腳]",
        // ["설풍 원기석 [창천권/천룡열권/빙륜환/태진각/벽력장]"] = "雪風元氣石[蒼穹拳/天龍烈拳/冰輪環/太震腳/霹靂掌]",
        // ["설풍 원기석 [창천권/발경/빙륜환/한기폭풍/태진각/하염축]"] = "雪風元氣石[蒼穹拳/爪破/冰輪環/寒氣風暴/太震腳/下炎蹴]",
        // ["설풍 원기석 [창천권/패왕권/빙륜환/빙하탄/태진각/나선쌍장]"] = "雪風元氣石[蒼穹拳/霸王拳/冰輪環/冰河彈/太震腳/螺旋雙掌]",



        // ["설풍 원기석 [전탄난사]"] = "雪風元氣石[流彈亂射]",
        // ["설풍 원기석 [전탄난사/작렬]"] = "雪風元氣石[流彈亂射/炸裂]",
        // ["설풍 원기석 [전탄난사/연환/참격]"] = "雪風元氣石[流彈亂射/連環/斬擊]",
        // ["설풍 원기석 [전탄난사/참격/망상]"] = "雪風元氣石[流彈亂射/斬擊/妄想]",



        // ["설풍 원기석 [난도/광검]"] = "雪風元氣石[亂刀/狂劍]",
        // ["설풍 원기석 [난도/연참/광검/일월검기]"] = "雪風元氣石[亂刀/連斬/狂劍/日月劍氣]",
        // ["설풍 원기석 [난도/연격세/광검/선검술]"] = "雪風元氣石[亂刀/連擊勢/狂劍/仙劍術]",
        // ["설풍 원기석 [난도/일도양단/광검/달빛검기]"] = "雪風元氣石[亂刀/一刀兩斷/狂劍/月光劍氣]",




        // ["설풍 원기석 [공명/돌풍살]"] = "雪風元氣石[共鳴/突風殺]",
        // ["설풍 원기석 [공명/내력화살/돌풍살/삼중사격]"] = "雪風元氣石[共鳴/內力箭/突風殺/三重射擊]",
        // ["설풍 원기석 [공명/결집/돌풍살/태풍살]"] = "雪風元氣石[共鳴/集結/突風殺/颱風殺]",
        // ["설풍 원기석 [공명/산탄/돌풍살/강사]"] = "雪風元氣石[共鳴/散彈/突風殺/鋼殺]",




        // ["설풍 원기석 [광폭/번쩍]"] = "雪風元氣石[光幅/閃現]",
        // ["설풍 원기석 [광폭/별무리/번쩍/회전회오리]"] = "雪風元氣石[光幅/星群/閃現/迴轉旋風]",
        // ["설풍 원기석 [광폭/광휘/번쩍/번개구슬]"] = "雪風元氣石[光幅/光輝/閃現/雷珠]",
        // ["설풍 원기석 [광폭/광륜/번쩍/우레폭풍]"] = "雪風元氣石[光幅/光輪/閃現/雷鳴風暴]",




        // ["설풍 원기석 [광폭/번쩍]"] = "雪風元氣石[滅輪斬/花風連斬]",
        // ["설풍 원기석 [멸륜참/절멸/화풍연참/화선풍]"] = "雪風元氣石[滅輪斬/誅滅/花風連斬/花旋風]",
        // ["설풍 원기석 [멸륜참/환영살/화풍연참/화월]"] = "雪風元氣石[滅輪斬/幻影殺/花風連斬/花月]",
        // ["설풍 원기석 [멸륜참/연검: 난도/화풍연참/개화]"] = "雪風元氣石[滅輪斬/連劍：亂刀/花風連斬/開花]",




        // // 真氣石

        // ["흑월 진기석 [화룡연참/급소베기/창룡검결]"] = "黑月真氣石[火龍連斬/奪命劍/蒼龍劍訣]",
        // ["흑월 진기석 [화룡연참/만월베기/급소베기/창룡검결/어검비산]"] = "黑月真氣石[火龍連斬/滿月斬/奪命劍/蒼龍劍訣/御劍飛散]",
        // ["흑월 진기석 [화룡연참/발도/급소베기/십마령섬/창룡검결/무명검결]"] = "黑月真氣石[火龍連斬/拔劍/奪命劍/弒魔靈閃/蒼龍劍訣/無名劍訣]",
        // ["흑월 진기석 [화룡연참/번개베기/급소베기/발도/창룡검결/어검 연속베기]"] = "黑月真氣石[火龍連斬/雷斬/奪命劍/拔劍/蒼龍劍訣/御劍連斬]",




        // ["흑월 진기석 [적룡권/풍령각/광란]"] = "黑月真氣石[赤龍拳/風令腳/狂亂]",
        // ["흑월 진기석 [적룡권/산사태/풍령각/철산고/광란/살육]"] = "黑月真氣石[赤龍拳/山崩/風令腳/鐵山靠/狂亂/殺戮]",
        // ["흑월 진기석 [적룡권/용호포/풍령각/회천각/광란/쌍장]"] = "黑月真氣石[赤龍拳/龍虎步/風令腳/回天腳/狂亂/雙掌]",
        // ["흑월 진기석 [적룡권/붕권/풍령각/광란/도산봉추]"] = "黑月真氣石[赤龍拳/崩拳/風令腳/狂亂/刀山崩竹]",




        // ["흑월 진기석 [말벌/큰 해바라기/와장창]"] = "黑月真氣石[馬蜂/大向日葵/轟隆隆！]",
        // ["흑월 진기석 [말벌/가시덩굴/큰 해바라기/가시덩굴/와장창/빠직]"] = "黑月真氣石[馬蜂/荊棘籐/大向日葵/轟隆隆！/氣呼呼！]",
        // ["흑월 진기석 [말벌/투척밤송이/큰 해바라기/와장창/뻥이요]"] = "黑月真氣石[馬蜂/飛栗球/大向日葵/轟隆隆！/騙你的！]",
        // ["흑월 진기석 [말벌/꿀밤/큰 해바라기/해바라기/와장창/쏜다냥]"] = "黑月真氣石[馬蜂/爆栗/大向日葵/向日葵/轟隆隆！/發射喵]",




        // ["흑월 진기석 [폭열신장/빙백연혼경/폭뢰파]"] = "黑月真氣石[爆炎神掌/冰壁連魂鏡/暴雷波]",
        // ["흑월 진기석 [폭열신장/화염지옥/빙백연혼경/빙백한포/폭뢰파/섬뇌격]"] = "黑月真氣石[爆炎神掌/火炎地獄/冰壁連魂鏡/冰壁寒砲/暴雷波/閃雷擊]",
        // ["흑월 진기석 [폭열신장/유성지/빙백연혼경/설화장/폭뢰파/섬뇌장]"] = "黑月真氣石[爆炎神掌/流星指/冰壁連魂鏡/雪花掌/暴雷波/閃雷掌]",
        // ["흑월 진기석 [폭열신장/화련장/빙백연혼경/쌍룡파/폭뢰파/연쇄번개]"] = "黑月真氣石[爆炎神掌/火蓮掌/冰壁連魂鏡/雙龍掌/暴雷波/連鎖閃電]",




        // ["흑월 진기석 [파괴/섬멸/쌍월격]"] = "黑月真氣石[破壞/殆滅/雙月擊]",
        // ["흑월 진기석 [파괴/격노/섬멸/격풍/쌍월격/쇄도]"] = "黑月真氣石[破壞/激怒/殆滅/激風/雙月擊/突馳]",
        // ["흑월 진기석 [파괴/대파괴/섬멸/발구르기/쌍월격/금월참]"] = "黑月真氣石[破壞/破壞/殆滅/重踏/雙月擊/金月斬]",
        // ["흑월 진기석 [파괴/분쇄/섬멸/집행/쌍월격/무진]"] = "黑月真氣石[破壞/粉碎/殆滅/執刑/雙月擊/無盡]",




        // ["흑월 진기석 [심장찌르기/뇌절도:살/월영섬]"] = "黑月真氣石[刺心/雷絕刀：殺/月影閃]",
        // ["흑월 진기석 [심장찌르기/암흑살/뇌절도:살/뇌절도/월영섬/오월참]"] = "黑月真氣石[刺心/闇黑殺/雷絕刀：殺/雷絕刀/月影閃/烏月斬]",
        // ["흑월 진기석 [심장찌르기/독무투척/뇌절도:살/월영섬/월영격]"] = "黑月真氣石[刺心/擲毒霧/雷絕刀：殺/月影閃/月影擊]",
        // ["흑월 진기석 [심장찌르기/맹독베기/뇌절도:살/심장찌르기/월영섬/월영살]"] = "黑月真氣石[刺心/猛毒斬/雷絕刀：殺/月影閃/月影殺]",




        // ["흑월 진기석 [태풍참/뇌연섬/영혼가르기]"] = "黑月真氣石[颱風斬/雷炎閃/靈魂斬]",
        // ["흑월 진기석 [태풍참/가르기/뇌연섬/발도/영혼가르기]"] = "黑月真氣石[颱風斬/斷水斬/雷炎閃/拔劍/靈魂斬]",
        // ["흑월 진기석 [태풍참/질풍삼연섬/뇌연섬/절명참/영혼가르기/귀월격]"] = "黑月真氣石[颱風斬/疾風三連斬/雷炎閃/絕命斬/靈魂斬/鬼月擊]",
        // ["흑월 진기석 [태풍참/하늘베기/뇌연섬/천둥베기/영혼가르기/내려베기]"] = "黑月真氣石[颱風斬/天斬/雷炎閃/轟雷斬/靈魂斬/下斬]",




        // ["흑월 진기석 [폭마령/흑염룡/윤회]"] = "黑月真氣石[暴魔靈/黑炎龍/輪迴]",
        // ["흑월 진기석 [폭마령/차원탄/흑염룡/수라/윤회/참절]"] = "黑月真氣石[暴魔靈/次元彈/黑炎龍/夜叉/輪迴/斬絕]",
        // ["흑월 진기석 [폭마령/개문/흑염룡/귀령개문/윤회/검은파도]"] = "黑月真氣石[暴魔靈/開門/黑炎龍/鬼靈開門/輪迴/黑暗波動]",
        // ["흑월 진기석 [폭마령/사령쇄도/흑염룡/귀령쇄도/윤회/안개칼날]"] = "黑月真氣石[暴魔靈/死靈突馳/黑炎龍/鬼靈突馳/輪迴/迷霧刀鋒]",




        // ["흑월 진기석 [창천권/빙륜환/태진각]"] = "黑月真氣石[蒼穹拳/冰輪環/太震腳]",
        // ["흑월 진기석 [창천권/천룡열권/빙륜환/태진각/벽력장]"] = "黑月真氣石[蒼穹拳/天龍烈拳/冰輪環/太震腳/霹靂掌]",
        // ["흑월 진기석 [창천권/발경/빙륜환/한기폭풍/태진각/하염축]"] = "黑月真氣石[蒼穹拳/爪破/冰輪環/寒氣風暴/太震腳/下炎蹴]",
        // ["흑월 진기석 [창천권/패왕권/빙륜환/빙하탄/태진각/나선쌍장]"] = "黑月真氣石[蒼穹拳/霸王拳/冰輪環/冰河彈/太震腳/螺旋雙掌]",




        // ["흑월 진기석 [창천권/빙륜환/태진각]"] = "黑月真氣石[蒼穹拳/冰輪環/太震腳]",
        // ["흑월 진기석 [창천권/천룡열권/빙륜환/태진각/벽력장]"] = "黑月真氣石[蒼穹拳/天龍烈拳/冰輪環/太震腳/霹靂掌]",
        // ["흑월 진기석 [창천권/발경/빙륜환/한기폭풍/태진각/하염축]"] = "黑月真氣石[蒼穹拳/爪破/冰輪環/寒氣風暴/太震腳/下炎蹴]",
        // ["흑월 진기석 [창천권/패왕권/빙륜환/빙하탄/태진각/나선쌍장]"] = "黑月真氣石[蒼穹拳/霸王拳/冰輪環/冰河彈/太震腳/螺旋雙掌]",



        // ["흑월 진기석 [전탄난사]"] = "黑月真氣石[流彈亂射]",
        // ["흑월 진기석 [전탄난사/작렬]"] = "黑月真氣石[流彈亂射/炸裂]",
        // ["흑월 진기석 [전탄난사/연환/참격]"] = "黑月真氣石[流彈亂射/連環/斬擊]",
        // ["흑월 진기석 [전탄난사/참격/망상]"] = "黑月真氣石[流彈亂射/斬擊/妄想]",



        // ["흑월 진기석 [난도/광검]"] = "黑月真氣石[亂刀/狂劍]",
        // ["흑월 진기석 [난도/연참/광검/일월검기]"] = "黑月真氣石[亂刀/連斬/狂劍/日月劍氣]",
        // ["흑월 진기석 [난도/연격세/광검/선검술]"] = "黑月真氣石[亂刀/連擊勢/狂劍/仙劍術]",
        // ["흑월 진기석 [난도/일도양단/광검/달빛검기]"] = "黑月真氣石[亂刀/一刀兩斷/狂劍/月光劍氣]",




        // ["흑월 진기석 [공명/돌풍살]"] = "黑月真氣石[共鳴/突風殺]",
        // ["흑월 진기석 [공명/내력화살/돌풍살/삼중사격]"] = "黑月真氣石[共鳴/內力箭/突風殺/三重射擊]",
        // ["흑월 진기석 [공명/결집/돌풍살/태풍살]"] = "黑月真氣石[共鳴/集結/突風殺/颱風殺]",
        // ["흑월 진기석 [공명/산탄/돌풍살/강사]"] = "黑月真氣石[共鳴/散彈/突風殺/鋼殺]",




        // ["흑월 진기석 [광폭/번쩍]"] = "黑月真氣石[光幅/閃現]",
        // ["흑월 진기석 [광폭/별무리/번쩍/회전회오리]"] = "黑月真氣石[光幅/星群/閃現/迴轉旋風]",
        // ["흑월 진기석 [광폭/광휘/번쩍/번개구슬]"] = "黑月真氣石[光幅/光輝/閃現/雷珠]",
        // ["흑월 진기석 [광폭/광륜/번쩍/우레폭풍]"] = "黑月真氣石[光幅/光輪/閃現/雷鳴風暴]",




        // ["흑월 진기석 [광폭/번쩍]"] = "黑月真氣石[滅輪斬/花風連斬]",
        // ["흑월 진기석 [멸륜참/절멸/화풍연참/화선풍]"] = "黑月真氣石[滅輪斬/誅滅/花風連斬/花旋風]",
        // ["흑월 진기석 [멸륜참/환영살/화풍연참/화월]"] = "黑月真氣石[滅輪斬/幻影殺/花風連斬/花月]",
        // ["흑월 진기석 [멸륜참/연검: 난도/화풍연참/개화]"] = "黑月真氣石[滅輪斬/連劍：亂刀/花風連斬/開花]",




        ["기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화룡연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">급소베기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창룡검결</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">火龍連斬</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">奪命劍</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">蒼龍劍訣</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화룡연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">만월베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">급소베기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">만월베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창룡검결</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">어검비산</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">火龍連斬</font>招式和相關特性招式。<br/>強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">滿月斬</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">奪命劍</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">滿月斬</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">蒼龍劍訣</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">御劍飛散</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화룡연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">발도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">급소베기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">십마령섬</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창룡검결</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">무명검결</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">火龍連斬</font>招式和相關特性招式。<br/>強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">拔劍</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">奪命劍</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">弒魔靈閃</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">蒼龍劍訣</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">無名劍訣</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화룡연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>기검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">번개베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">급소베기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쾌검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">발도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창룡검결</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>어검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">어검 연속베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">火龍連斬</font>招式和相關特性招式。<br/>強化氣劍系的<font name=\"00008130.UI.Vital_LightBlue\">雷斬</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">奪命劍</font>招式和相關特性招式。<br/>強化快劍系的<font name=\"00008130.UI.Vital_LightBlue\">拔劍</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">蒼龍劍訣</font>招式和相關特性招式。<br/>強化御劍系的<font name=\"00008130.UI.Vital_LightBlue\">御劍連斬</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">적룡권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">풍령각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">광란</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">赤龍拳</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">風令腳</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">狂亂</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">적룡권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">산사태</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">풍령각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">철산고</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">광란</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">살육</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">赤龍拳</font>招式和相關特性招式。<br/>強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">山崩</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">風令腳</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">鐵山靠</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">狂亂</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">殺戮</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">적룡권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">용호포</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">풍령각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">회천각</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">광란</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍장</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">赤龍拳</font>招式和相關特性招式。<br/>強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">龍虎步</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">風令腳</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">回天腳</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">狂亂</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">雙掌</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">적룡권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>적호 계열의 <font name=\"00008130.UI.Vital_LightBlue\">붕권</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">풍령각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>청룡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">붕권</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">광란</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>흑랑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">도산붕추</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">赤龍拳</font>招式和相關特性招式。<br/>強化赤虎系的<font name=\"00008130.UI.Vital_LightBlue\">崩拳</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">風令腳</font>招式和相關特性招式。<br/>強化青龍系的<font name=\"00008130.UI.Vital_LightBlue\">崩拳</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">狂亂</font>招式和相關特性招式。<br/>強化黑狼系的<font name=\"00008130.UI.Vital_LightBlue\">刀山崩竹</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",





        ["조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">말벌</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">큰 해바라기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">와장창</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">馬蜂</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">大向日葵</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">轟隆隆！</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">말벌</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">가시덩굴</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">큰 해바라기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">가시덩굴</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">와장창</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빠직</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">馬蜂</font>招式和相關特性招式。<br/>強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">荊棘籐</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">大向日葵</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">荊棘籐</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">轟隆隆！</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">氣呼呼！</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">말벌</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">투척밤송이</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">큰 해바라기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">투척밤송이</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">와장창</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뻥이요</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">馬蜂</font>招式和相關特性招式。<br/>強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">飛栗球</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">大向日葵</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">飛栗球</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">轟隆隆！</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">騙你的！</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">말벌</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>조화 계열의 <font name=\"00008130.UI.Vital_LightBlue\">꿀밤</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">큰 해바라기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>자연 계열의 <font name=\"00008130.UI.Vital_LightBlue\">해바라기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">와장창</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>환상 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쏜다냥</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">馬蜂</font>招式和相關特性招式。<br/>強化調和系的<font name=\"00008130.UI.Vital_LightBlue\">爆栗</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">大向日葵</font>招式和相關特性招式。<br/>強化自然系的<font name=\"00008130.UI.Vital_LightBlue\">向日葵</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">轟隆隆！</font>招式和相關特性招式。<br/>強化幻想系的<font name=\"00008130.UI.Vital_LightBlue\">發射喵</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭열신장</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙백연혼경</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭뢰파</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">爆炎神掌</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">冰壁連魂鏡</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">暴雷波</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭열신장</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화염지옥</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙백연혼경</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙백한포</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭뢰파</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬뇌격</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">爆炎神掌</font>招式和相關特性招式。<br/>強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">火炎地獄</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">冰壁連魂鏡</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">冰壁寒砲</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">暴雷波</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">閃雷擊</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭열신장</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">유성지</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙백연혼경</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">설화장</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭뢰파</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬뇌장</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">爆炎神掌</font>招式和相關特性招式。<br/>強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">流星指</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">冰壁連魂鏡</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">雪花掌</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">暴雷波</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">閃雷掌</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭열신장</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>초열 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화련장</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙백연혼경</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>혹한 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍룡파</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭뢰파</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>음양 계열의 <font name=\"00008130.UI.Vital_LightBlue\">연쇄번개</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">爆炎神掌</font>招式和相關特性招式。<br/>強化灼熱系的<font name=\"00008130.UI.Vital_LightBlue\">火蓮掌</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">冰壁連魂鏡</font>招式和相關特性招式。<br/>強化酷寒系的<font name=\"00008130.UI.Vital_LightBlue\">雙龍掌</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">暴雷波</font>招式和相關特性招式。<br/>強化陰陽系的<font name=\"00008130.UI.Vital_LightBlue\">連鎖閃電</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">파괴</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬멸</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍월격</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">破壞</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">殆滅</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">雙月擊</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">파괴</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">격노</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬멸</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">격풍</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍월격</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쇄도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">破壞</font>招式和相關特性招式。<br/>強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">激怒</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">殆滅</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">激風</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">雙月擊</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">突馳</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">파괴</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">대파괴</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬멸</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">발구르기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍월격</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">금월참</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">破壞</font>招式和相關特性招式。<br/>強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">大破壞</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">殆滅</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">重踏</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">雙月擊</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">金月斬</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">파괴</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">분쇄</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬멸</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">집행</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍월격</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">무진</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">破壞</font>招式和相關特性招式。<br/>強化泰山系的<font name=\"00008130.UI.Vital_LightBlue\">粉碎</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">殆滅</font>招式和相關特性招式。<br/>強化漆黑系的<font name=\"00008130.UI.Vital_LightBlue\">執刑</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">雙月擊</font>招式和相關特性招式。<br/>強化雙月系的<font name=\"00008130.UI.Vital_LightBlue\">無盡</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["독영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">심장찌르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>무영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌절도:살</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>암영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">월영섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">刺心</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">雷絕刀：殺</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">月影閃</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">파괴</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>태산 계열의 <font name=\"00008130.UI.Vital_LightBlue\">격노</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">섬멸</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>칠흑 계열의 <font name=\"00008130.UI.Vital_LightBlue\">격풍</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쌍월격</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>쌍월 계열의 <font name=\"00008130.UI.Vital_LightBlue\">쇄도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">刺心</font>招式和相關特性招式。<br/>強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">闇黑殺</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">雷絕刀：殺</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">雷絕刀</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">月影閃</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">烏月斬</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["독영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">심장찌르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>독영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">독무투척</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>무영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌절도:살</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>무영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">독무투척</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>암영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">월영섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>암영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">월영격</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">刺心</font>招式和相關特性招式。<br/>強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">擲毒霧</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">雷絕刀：殺</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">擲毒霧</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">月影閃</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">月影擊</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["독영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">심장찌르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>독영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">맹독베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>무영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌절도:살</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>무영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">심장찌르기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>암영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">월영섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>암영 계열의 <font name=\"00008130.UI.Vital_LightBlue\">월영살</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">刺心</font>招式和相關特性招式。<br/>強化毒影系的<font name=\"00008130.UI.Vital_LightBlue\">猛毒斬</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">雷絕刀：殺</font>招式和相關特性招式。<br/>強化無影系的<font name=\"00008130.UI.Vital_LightBlue\">刺心</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">月影閃</font>招式和相關特性招式。<br/>強化暗影系的<font name=\"00008130.UI.Vital_LightBlue\">月影殺</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태풍참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌연섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">영혼가르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">颱風斬</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">雷炎閃</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">靈魂斬</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태풍참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">가르기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌연섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">발도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">영혼가르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">발도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">颱風斬</font>招式和相關特性招式。<br/>強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">斷水斬</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">雷炎閃</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">拔劍</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">靈魂斬</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">拔劍</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태풍참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">질풍삼연섬</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌연섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">절명참</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">영혼가르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">귀월격</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">颱風斬</font>招式和相關特性招式。<br/>強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">疾風三連斬</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">雷炎閃</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">絕命斬</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">靈魂斬</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">鬼月擊</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",



        ["풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태풍참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>풍운 계열의 <font name=\"00008130.UI.Vital_LightBlue\">하늘베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">뇌연섬</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>섬광 계열의 <font name=\"00008130.UI.Vital_LightBlue\">천둥베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">영혼가르기</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>귀검 계열의 <font name=\"00008130.UI.Vital_LightBlue\">내려베기</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">颱風斬</font>招式和相關特性招式。<br/>強化風雲系的<font name=\"00008130.UI.Vital_LightBlue\">天斬</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">雷炎閃</font>招式和相關特性招式。<br/>強化閃光系的<font name=\"00008130.UI.Vital_LightBlue\">轟雷斬</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">靈魂斬</font>招式和相關特性招式。<br/>強化鬼劍系的<font name=\"00008130.UI.Vital_LightBlue\">下斬</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭마령</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">흑염룡</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">윤회</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">暴魔靈</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">黑炎龍</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">輪迴</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭마령</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">차원탄</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">흑염룡</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">수라</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">윤회</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">참절</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">暴魔靈</font>招式和相關特性招式。<br/>強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">次元彈</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">黑炎龍</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">夜叉</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">輪迴</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">斬絕</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭마령</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">개문</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">흑염룡</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">귀령개문</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">윤회</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">검은파도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">暴魔靈</font>招式和相關特性招式。<br/>強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">開門</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">黑炎龍</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">鬼靈開門</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">輪迴</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">黑暗波動</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">폭마령</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>왜곡 계열의 <font name=\"00008130.UI.Vital_LightBlue\">사령쇄도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">흑염룡</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>저주 계열의 <font name=\"00008130.UI.Vital_LightBlue\">귀령쇄도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">윤회</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>사신 계열의 <font name=\"00008130.UI.Vital_LightBlue\">안개칼날</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">暴魔靈</font>招式和相關特性招式。<br/>強化扭曲系的<font name=\"00008130.UI.Vital_LightBlue\">死靈突馳</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">黑炎龍</font>招式和相關特性招式。<br/>強化詛咒系的<font name=\"00008130.UI.Vital_LightBlue\">鬼靈突馳</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">輪迴</font>招式和相關特性招式。<br/>強化死神系的<font name=\"00008130.UI.Vital_LightBlue\">迷霧刀鋒</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창천권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙륜환</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태진각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">蒼穹拳</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">冰輪環</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">太震腳</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창천권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">천룡열권</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙륜환</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">천룡열권</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태진각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">벽력장</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">蒼穹拳</font>招式和相關特性招式。<br/>強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">天龍烈拳</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">冰輪環</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">天龍烈拳</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">太震腳</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">霹靂掌</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창천권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">발경</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙륜환</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">한기폭풍</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태진각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">하염축</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">蒼穹拳</font>招式和相關特性招式。<br/>強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">爪破</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">冰輪環</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">寒氣風暴</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">太震腳</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">下炎蹴</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">창천권</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>금강 계열의 <font name=\"00008130.UI.Vital_LightBlue\">패왕권</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙륜환</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>순환 계열의 <font name=\"00008130.UI.Vital_LightBlue\">빙하탄</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">태진각</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>천수 계열의 <font name=\"00008130.UI.Vital_LightBlue\">나선쌍장</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">蒼穹拳</font>招式和相關特性招式。<br/>強化金刚系的<font name=\"00008130.UI.Vital_LightBlue\">霸王拳</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">冰輪環</font>招式和相關特性招式。<br/>強化循环系的<font name=\"00008130.UI.Vital_LightBlue\">冰河彈</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">太震腳</font>招式和相關特性招式。<br/>強化千手系的<font name=\"00008130.UI.Vital_LightBlue\">螺旋雙掌</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">멸륜참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화풍연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
        "強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">滅輪斬</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">花風連斬</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">멸륜참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">절멸</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화풍연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화선풍</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
       "強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">滅輪斬</font>招式和相關特性招式。<br/>強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">誅滅</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">花風連斬</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">花旋風</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">멸륜참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">환영살</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화풍연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화월</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다.]"]
        =
       "強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">滅輪斬</font>招式和相關特性招式。<br/>強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">幻影殺</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">花風連斬</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">花月</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",




        ["무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">멸륜참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>무극 계열의 <font name=\"00008130.UI.Vital_LightBlue\">연검: 난도</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">화풍연참</font> 무공 및 관련된 특성 무공이 강화됩니다<br/>화무 계열의 <font name=\"00008130.UI.Vital_LightBlue\">개화</font> 무공 및 관련된 특성 무공이 강화됩니다.<br/>원기석 홈이 확장된 무기에 장착할 수 있습니다."]
        =
       "強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">滅輪斬</font>招式和相關特性招式。<br/>強化無極系的<font name=\"00008130.UI.Vital_LightBlue\">連劍：亂刀</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">花風連斬</font>招式和相關特性招式。<br/>強化花舞系的<font name=\"00008130.UI.Vital_LightBlue\">開花</font>招式和相關特性招式。<br/>可以裝備在已添加元氣石凹槽的武器上。",
      };


      // 可以裝備在已添加真氣石凹槽的武器上。

      // 진기석 홈이 확장된 무기에 장착할 수 있습니다.

      BNSXMLReplacer bnsXMLReplacer = new BNSXMLReplacer("/Users/shinhwe/bns-ch-text/Translation64.xml");

      bnsXMLReplacer.Replace(replaceMap);

    }
  }
}
