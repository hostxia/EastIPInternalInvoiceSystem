using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EastIPSystem.Module.BusinessObjects
{
    public class PatentPaymentCode
    {
        public EnumsAll.PayCaseType PayCaseType { get; set; }

        public EnumsAll.PatentType? PatentType { get; set; }

        public string FeeName { get; set; }

        public decimal Amount { get; set; }

        public PatentPaymentCode(EnumsAll.PayCaseType payCaseType, EnumsAll.PatentType? patentType, string sFeeName, decimal nAmount)
        {
            PayCaseType = payCaseType;
            PatentType = patentType;
            FeeName = sFeeName;
            Amount = nAmount;
        }
    }

    public static class PatentPaymentCodeCollection
    {
        private static List<PatentPaymentCode> listPatentPaymentCodes = new List<PatentPaymentCode>();

        static PatentPaymentCodeCollection()
        {
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利申请费", 500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型检索费", 2400));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利权评价报告请求费", 2400));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利复审费", 300));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利权无效宣告请求费", 1500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利强制许可请求费", 200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利登记印刷费", 200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第1年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第2年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第3年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第4年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第5年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第6年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第7年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第8年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第9年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利第10年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.实用新型, "实用新型专利年费滞纳金", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "印花税", 5));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利申请费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利文印费", 50));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "宽限费", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "译文改正费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "单一性恢复费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利申请审查费", 2500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利复审费", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "变更费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "优先权要求费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "恢复权利请求费", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利权无效宣告请求费", 3000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利登记印刷费", 250));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "权利要求附加费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利强制许可请求费", 300));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, null, "说明书附加费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利维持费", 300));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第1年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第2年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第3年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第4年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第5年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第6年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第7年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第8年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第9年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第10年年费", 4000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第11年年费", 4000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第12年年费", 4000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第13年年费", 6000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第14年年费", 6000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第15年年费", 6000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第16年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第17年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第18年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第19年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利第20年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国家, EnumsAll.PatentType.发明, "发明专利年费滞纳金", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第1年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第2年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第3年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第4年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第5年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第6年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第7年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第8年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第9年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第10年年费", 4000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第11年年费", 4000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第12年年费", 4000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第13年年费", 6000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第14年年费", 6000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第15年年费", 6000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第16年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第17年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第18年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第19年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利第20年年费", 8000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利年费滞纳金", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利申请费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利文印费", 50));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利申请审查费", 2500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利登记印刷费", 250));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利权无效宣告请求费", 3000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.发明, "发明专利复审费", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第1年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第2年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第3年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第4年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第5年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第6年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第7年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第8年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第9年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利第10年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利年费滞纳金", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利申请费", 500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利登记印刷费", 200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型检索费", 2400));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利权评价报告请求费", 2400));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利复审费", 300));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.实用新型, "实用新型专利权无效宣告请求费", 1500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第1年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第2年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第3年年费", 600));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第4年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第5年年费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第6年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第7年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第8年年费", 1200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第9年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利第10年年费", 2000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利年费滞纳金", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利申请费", 500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利登记印刷费", 200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利权评价报告请求费", 2400));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利复审费", 300));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.外观, "外观设计专利权无效宣告请求费", 1500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "印花税", 5));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "权利要求附加费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "说明书附加费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "优先权要求费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "变更费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "译文改正费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "单一性恢复费", 900));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "恢复权利请求费", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "延长费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, null, "宽限费", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "布图设计登记费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "延长费(集成电路)", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "复审请求费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "著录事项变更手续费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "非自愿许可请求费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "恢复请求费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.国内, EnumsAll.PatentType.集成电路, "非自愿许可请求的裁决请求费", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "申请费-PCT", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "附加费-PCT", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "手续费-PCT", 0));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "传送费-PCT", 500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "检索费-PCT", 2100));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "附加检索费-PCT", 1500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "优先权文件传送费-PCT", 150));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "初步审查费-PCT", 1500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "初步审查附加费-PCT", 1500));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "单一性异议费", 200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "副本复制费-PCT", 2));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "后提交费-PCT", 200));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "优先权恢复费-PCT", 1000));
            listPatentPaymentCodes.Add(new PatentPaymentCode(EnumsAll.PayCaseType.PCT国际, null, "滞纳金-PCT", 0));
        }
        public static List<PatentPaymentCode> GetPatentPaymentCodes(EnumsAll.PayCaseType payCaseType, EnumsAll.PatentType patentType)
        {
            return
                listPatentPaymentCodes.Where(
                    p =>
                        p.PayCaseType == payCaseType &&
                        ((p.PatentType.HasValue && p.PatentType == patentType) || !p.PatentType.HasValue)).ToList();
        }
    }
}
