using System.Collections.Generic;

namespace EastIPSystem.Module.Win.OfficialFileImport
{
    public enum DeadlineFiledType
    {
        OA,
        Deadline,
        Case,
        FCaseDeadline
    }
    public class CPCOfficialFileConfig
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Rename { get; set; }

        public DeadlineFiledType? DeadlineFiledType { get; set; }

        public string DeadlineFiled { get; set; }

        public string DeadlineFiledNote { get; set; }

        public int AddDays { get; set; }

        public int AddMonths { get; set; }

        public string Dealer { get; set; }

        public bool CreateDeadline => DeadlineFiledType.HasValue;

        public CPCOfficialFileConfig(string code, string name, string rename, string sDealer = "")
        {
            Code = code;
            Name = name;
            Rename = rename;
            Dealer = sDealer;
        }

        public CPCOfficialFileConfig(string code, string name, string rename, DeadlineFiledType deadlineFiledType, string deadlineFiled, string deadlineFiledNote, int addDays, int addMonths, string sDealer = "")
        {
            Code = code;
            Name = name;
            Rename = rename;
            DeadlineFiledType = deadlineFiledType;
            DeadlineFiled = deadlineFiled;
            DeadlineFiledNote = deadlineFiledNote;
            AddDays = addDays;
            AddMonths = addMonths;
            Dealer = sDealer;
        }
    }

    public class CPCOfficialFileConfigCollection : List<CPCOfficialFileConfig>
    {
        public CPCOfficialFileConfigCollection()
        {
            Add(new CPCOfficialFileConfig("200001", "中止程序请求审批通知书", "dec-discon"));
            Add(new CPCOfficialFileConfig("200002", "中止程序结束通知书", "end-discon"));
            Add(new CPCOfficialFileConfig("200003", "收到人民法院判决书的通知书", "memo"));
            Add(new CPCOfficialFileConfig("200004", "保全程序开始通知书", "memo"));
            Add(new CPCOfficialFileConfig("200005", "轮候保全通知书", "memo"));
            Add(new CPCOfficialFileConfig("200006", "不予执行财产保全通知书", "memo"));
            Add(new CPCOfficialFileConfig("200007", "视为放弃取得专利申请权或专利权的权利通知书", "memo", DeadlineFiledType.Deadline, "deemwithdraw", string.Empty, 15, 2));
            Add(new CPCOfficialFileConfig("200020", "审查业务专用函", "memo"));
            Add(new CPCOfficialFileConfig("200021", "费用减缓审批通知书", "dec-cost red", "DXD"));
            Add(new CPCOfficialFileConfig("200022", "视为撤回通知书", "deem-withdrawn", DeadlineFiledType.Deadline, "deemwithdraw", string.Empty, 15, 2));
            Add(new CPCOfficialFileConfig("200023", "视为未提出通知书", "deem-no-req", DeadlineFiledType.Deadline, "correction", "重新递交", 15, 2));
            Add(new CPCOfficialFileConfig("200024", "延长期限审批通知书", "dec-ext"));
            Add(new CPCOfficialFileConfig("200025", "修改更正通知书", "dec-amendment"));
            Add(new CPCOfficialFileConfig("200026", "恢复权利请求审批通知书", "dec-res"));
            Add(new CPCOfficialFileConfig("200027", "退款审批通知书", "dec-refund"));
            Add(new CPCOfficialFileConfig("200028", "手续合格通知书", "proc-accept"));
            Add(new CPCOfficialFileConfig("200029", "办理手续补正通知书", "corr", DeadlineFiledType.Deadline, "correction", string.Empty, 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("200031", "补缴费用通知书", "supplementary payment", DeadlineFiledType.Deadline, "correction", string.Empty, 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("200032", "办理恢复权利手续补正通知书", "corr-res", DeadlineFiledType.Deadline, "deemwithdraw", "恢复补正", 15, 1));
            Add(new CPCOfficialFileConfig("200101", "专利申请受理通知书", "fil-receipt", "DXD"));
            Add(new CPCOfficialFileConfig("200102", "文件不受理通知书", "memo"));
            Add(new CPCOfficialFileConfig("200103", "缴纳申请费通知书", "filling fee", "DXD"));
            Add(new CPCOfficialFileConfig("200105", "电子申请回执", "elec receipt"));
            Add(new CPCOfficialFileConfig("200106", "窗口递交文件回执", "sub receipt"));
            Add(new CPCOfficialFileConfig("200107", "电子申请注册请求审批通知书", "memo"));
            Add(new CPCOfficialFileConfig("200108", "电子申请注册事务专用函", "memo"));
            Add(new CPCOfficialFileConfig("200109", "复审、无效宣告程序中电子文件提交回执", "memo"));
            Add(new CPCOfficialFileConfig("200110", "向外国申请专利保密审查请求文件接收回执", "secrecy-receipt", "DXD"));
            Add(new CPCOfficialFileConfig("200301", "重新确定申请日通知书", "memo", "DXD"));
            Add(new CPCOfficialFileConfig("200302", "视为未要求优先权通知书", "deem-no-pri", DeadlineFiledType.Deadline, "deemwithdraw", "优先权", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("200303", "视为未委托专利代理机构通知书", "memo", DeadlineFiledType.Deadline, "correction", string.Empty, 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("200304", "视为未要求不丧失新颖性宽限期通知书", "deem-no-loss of novelty", DeadlineFiledType.Deadline, "deemwithdraw", "不丧失新颖性", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("200305", "驳回决定", "reje", DeadlineFiledType.OA, "rejected", string.Empty, 15, 3, "XN"));
            Add(new CPCOfficialFileConfig("200306", "分案申请视为未提出通知书", "div-deem-no-req", "DXD"));
            Add(new CPCOfficialFileConfig("200601", "视为放弃取得专利权通知书", "deem-aband", DeadlineFiledType.Deadline, "deemwithdraw", "视为放弃取得专利权", 15, 2, "SP"));
            Add(new CPCOfficialFileConfig("200602", "办理登记手续通知书", "reg", DeadlineFiledType.Case, "GRANTNOTIC_DATE", string.Empty, 15, 2, "SP"));
            Add(new CPCOfficialFileConfig("200701", "缴费通知书", "feenotice", "SP"));
            Add(new CPCOfficialFileConfig("200702", "专利权终止通知书", "cessation", DeadlineFiledType.Deadline, "deemwithdraw", "专利权终止", 15, 2, "SP"));
            Add(new CPCOfficialFileConfig("200703", "专利权评价报告复核意见通知书", "memo"));
            Add(new CPCOfficialFileConfig("200901", "复审请求视为未提出通知书", "reexam-deem-no-req", "XN"));
            Add(new CPCOfficialFileConfig("200902", "复审请求不予受理通知书", "reexam-inadmissibility", "XN"));
            Add(new CPCOfficialFileConfig("200903", "恢复权利请求补正通知书", "memo", DeadlineFiledType.Deadline, "correction", string.Empty, 15, 1));
            Add(new CPCOfficialFileConfig("200904", "恢复权利请求审批通知书", "dec-res"));
            Add(new CPCOfficialFileConfig("200905", "复审请求受理通知书", "reexam-receipt", "XN"));
            Add(new CPCOfficialFileConfig("200906", "委托专利代理机构审批通知书", "memo"));
            Add(new CPCOfficialFileConfig("200907", "复审请求补正通知书", "reexam-corr", DeadlineFiledType.OA, "reexam_correction", string.Empty, 30, 0, "XN"));
            Add(new CPCOfficialFileConfig("200908", "复审通知书", "ren", DeadlineFiledType.OA, "re_examination", string.Empty, 15, 1, "XN"));
            Add(new CPCOfficialFileConfig("200909", "复审请求口头审理通知书", "memo"));
            Add(new CPCOfficialFileConfig("200910", "专利复审委员会复审请求口头审理公告", "memo"));
            Add(new CPCOfficialFileConfig("200911", "复审请求审查决定", "memo", "XN"));
            Add(new CPCOfficialFileConfig("200912", "复审决定书", "reexam-dec", DeadlineFiledType.OA, "appl", string.Empty, 0, 3, "XN"));
            Add(new CPCOfficialFileConfig("200913", "复审案件结案通知书", "reexam-close", DeadlineFiledType.Deadline, "deemwithdraw", "复审结案", 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("200914", "关于样品、实物、证据原件处理的通知", "memo"));
            Add(new CPCOfficialFileConfig("200915", "更正通知书", "correction"));
            Add(new CPCOfficialFileConfig("200916", "延长期限审批通知书", "dec-ext", "XN"));
            Add(new CPCOfficialFileConfig("200917", "复审请求审查决定", "memo", "XN"));
            Add(new CPCOfficialFileConfig("200918", "合议组成员变更通知书", "collegial panel change"));
            Add(new CPCOfficialFileConfig("200919", "复审案件审查状态通知书", "memo"));
            Add(new CPCOfficialFileConfig("200920", "关于回避请求的处理决定", "memo"));
            Add(new CPCOfficialFileConfig("201001", "无效宣告请求视为未提出通知书", "inva-deem-no-req"));
            Add(new CPCOfficialFileConfig("201002", "无效宣告请求不予受理通知书", "inva-inadmissibility"));
            Add(new CPCOfficialFileConfig("201003", "无效宣告受理通知书", "inva-receipt"));
            Add(new CPCOfficialFileConfig("201004", "无效宣告受理通知书", "inva-receipt"));
            Add(new CPCOfficialFileConfig("201005", "无效宣告请求补正通知书", "inva-corr"));
            Add(new CPCOfficialFileConfig("201006", "无效宣告请求补正通知书", "inva-corr"));
            Add(new CPCOfficialFileConfig("201007", "无效宣告案件审查状态通知书", "memo"));
            Add(new CPCOfficialFileConfig("201008", "委托专利代理机构审批通知书", "memo"));
            Add(new CPCOfficialFileConfig("201009", "委托专利代理机构审批通知书", "memo"));
            Add(new CPCOfficialFileConfig("201010", "关于样品、实物、证据原件处理的通知", "memo"));
            Add(new CPCOfficialFileConfig("201011", "关于样品、实物、证据原件处理的通知", "memo"));
            Add(new CPCOfficialFileConfig("201012", "转送文件通知书", "document transfer"));
            Add(new CPCOfficialFileConfig("201013", "转送文件通知书", "document transfer"));
            Add(new CPCOfficialFileConfig("201014", "无效宣告请求口头审理通知书", "inva-hear"));
            Add(new CPCOfficialFileConfig("201015", "专利复审委员会无效宣告请求口头审理公告", "memo"));
            Add(new CPCOfficialFileConfig("201016", "无效宣告请求审查通知书", "memo"));
            Add(new CPCOfficialFileConfig("201017", "无效宣告请求审查决定", "memo"));
            Add(new CPCOfficialFileConfig("201018", "无效宣告请求审查决定", "memo"));
            Add(new CPCOfficialFileConfig("201019", "无效宣告请求审查决定书", "inva-dec"));
            Add(new CPCOfficialFileConfig("201020", "无效宣告案件结案通知书", "inva-close"));
            Add(new CPCOfficialFileConfig("201021", "更正通知书", "correction"));
            Add(new CPCOfficialFileConfig("201022", "合议组成员告知通知书", "memo"));
            Add(new CPCOfficialFileConfig("201023", "关于回避请求的处理决定", "memo"));
            Add(new CPCOfficialFileConfig("201024", "外文证据委托翻译通知书", "memo"));
            Add(new CPCOfficialFileConfig("201025", "外文证据翻译委托书", "memo"));
            Add(new CPCOfficialFileConfig("201101", "复议申请受理通知书", "recon-receipt"));
            Add(new CPCOfficialFileConfig("201102", "复议申请不予受理通知书", "recon-inadmissibility"));
            Add(new CPCOfficialFileConfig("201103", "行政复议决定书", "memo"));
            Add(new CPCOfficialFileConfig("201104", "复议决定延期通知书", "memo"));
            Add(new CPCOfficialFileConfig("201105", "复议案件终止通知书", "memo"));
            Add(new CPCOfficialFileConfig("201106", "复议案件停止执行通知书", "memo"));
            Add(new CPCOfficialFileConfig("201107", "复议案件恢复程序通知书", "memo"));
            Add(new CPCOfficialFileConfig("201108", "复议申请视为未提出通知书", "recon-deem-no-req"));
            Add(new CPCOfficialFileConfig("201109", "复议申请补正通知书", "memo"));
            Add(new CPCOfficialFileConfig("201110", "赔偿案件决定书", "memo"));
            Add(new CPCOfficialFileConfig("201111", "赔偿请求不予受理通知书", "memo"));
            Add(new CPCOfficialFileConfig("201112", "赔偿请求受理通知书", "memo"));
            Add(new CPCOfficialFileConfig("210301", "审查意见通知书", "oa", DeadlineFiledType.OA, "oa2", string.Empty, 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("210302", "补正通知书", "corr", DeadlineFiledType.Deadline, "correction", string.Empty, 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("210303", "生物材料样品视为未保藏通知书", "deem-no-bio", DeadlineFiledType.Deadline, "deemwithdraw", "生物材料", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("210304", "发明专利申请初步审查合格通知书", "pe-pass", DeadlineFiledType.Case, "PRE_EXAM_PASSED", string.Empty, 0, 0, "ON"));
            Add(new CPCOfficialFileConfig("210305", "发明专利申请公布通知书", "pub", "DXD"));
            Add(new CPCOfficialFileConfig("210306", "发明专利申请实质审查请求期限届满前通知书", "timedue", "DXD"));
            Add(new CPCOfficialFileConfig("210307", "发明专利申请进入实质审查阶段通知书", "enter-se", "DXD"));
            Add(new CPCOfficialFileConfig("210308", "发明专利申请公布及进入实质审查阶段通知书", "pub-se-enter", "DXD"));
            Add(new CPCOfficialFileConfig("210320", "不予保密通知书（保密）", "memo"));
            Add(new CPCOfficialFileConfig("210321", "专利申请保密审查报批书（保密）", "memo"));
            Add(new CPCOfficialFileConfig("210322", "专利申请移交国防专利局通知书（保密）", "memo"));
            Add(new CPCOfficialFileConfig("210323", "保密审批通知书（保密）", "memo"));
            Add(new CPCOfficialFileConfig("210324", "解密审批通知书（保密）", "memo"));
            Add(new CPCOfficialFileConfig("210325", "受理专利申请移交国防专利局审查转接书（保密）", "memo"));
            Add(new CPCOfficialFileConfig("210326", "向外国申请专利保密审查意见通知书（保密）", "secrecy", "DXD"));
            Add(new CPCOfficialFileConfig("210327", "向外国申请专利保密审查决定（保密）", "secrecy-dec", "DXD"));
            Add(new CPCOfficialFileConfig("210401", "第一次审查意见通知书", "oa", DeadlineFiledType.OA, "oa1", string.Empty, 15, 4, "XN"));
            Add(new CPCOfficialFileConfig("210402", "第一次审查意见通知书", "oa", DeadlineFiledType.OA, "oa1", string.Empty, 15, 4, "XN"));
            Add(new CPCOfficialFileConfig("210403", "第N次审查意见通知书", "oan", DeadlineFiledType.OA, "oa2", string.Empty, 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("210404", "提交资料通知书", "ref", DeadlineFiledType.Deadline, "correction", "提交资料", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("210405", "分案通知书", "div", DeadlineFiledType.OA, "oa2", "分案通知", 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("210406", "会晤通知书", "memo"));
            Add(new CPCOfficialFileConfig("210407", "驳回决定", "reje", DeadlineFiledType.OA, "rejected", string.Empty, 15, 3, "XN"));
            Add(new CPCOfficialFileConfig("210408", "驳回决定", "reje", DeadlineFiledType.OA, "rejected", string.Empty, 15, 3, "XN"));
            Add(new CPCOfficialFileConfig("210409", "改正译文错误通知书", "tran-err", DeadlineFiledType.Deadline, "correction", "译文错误", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("210411", "专利代理机构失误补救通知书", "memo"));
            Add(new CPCOfficialFileConfig("210412", "缴纳单一性恢复费通知书", "unity-res", DeadlineFiledType.Deadline, "deemwithdraw", "单一性恢复", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("210413", "授予发明专利权通知书", "grant", "SP"));
            Add(new CPCOfficialFileConfig("210414", "授予发明专利权通知书", "grant", "SP"));
            Add(new CPCOfficialFileConfig("210415", "避免重复授予专利权的通知书", "memo", "SP"));
            Add(new CPCOfficialFileConfig("210416", "授予发明专利权通知书更正通知书", "correction-grant", "SP"));
            Add(new CPCOfficialFileConfig("210417", "授予发明专利权通知书更正通知书", "correction-grant", "SP"));
            Add(new CPCOfficialFileConfig("210418", "PPH请求补正通知书", "pph-correction", DeadlineFiledType.Deadline, "correction", "PPH补交", 30, 0, "DXD"));
            Add(new CPCOfficialFileConfig("210419", "PPH请求审批决定通知书", "pph-dec", DeadlineFiledType.Deadline, "correction", "PPH重新递交", 30, 0, "DXD"));
            Add(new CPCOfficialFileConfig("220301", "第N次审查意见通知书", "oan", DeadlineFiledType.OA, "oa2", "", 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("220302", "第N次补正通知书", "oa corr", DeadlineFiledType.OA, "correction", "", 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("220601", "授予实用新型专利权通知书", "grant", "SP"));
            Add(new CPCOfficialFileConfig("220701", "实用新型专利权评价报告", "patent assessment report", "SP"));
            Add(new CPCOfficialFileConfig("220107A", "实用新型专利权评价报告（更正）", "memo", "SP"));
            Add(new CPCOfficialFileConfig("220702", "实用新型专利检索报告", "memo", "SP"));
            Add(new CPCOfficialFileConfig("220703", "授予实用新型专利权通知书更正通知书", "correction-grant", "SP"));
            Add(new CPCOfficialFileConfig("220704", "实用新型专利检索报告复核意见通知书", "memo", "SP"));
            Add(new CPCOfficialFileConfig("230201", "补正通知书", "oa corr", DeadlineFiledType.Deadline, "correction", "", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("230301", "第N次补正通知书", "oa corr", DeadlineFiledType.OA, "correction", "", 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("230302", "审查意见通知书", "oa", DeadlineFiledType.OA, "oa2", "", 15, 2, "XN"));
            Add(new CPCOfficialFileConfig("230601", "授予外观设计专利权通知书", "grant", "SP"));
            Add(new CPCOfficialFileConfig("230701", "外观设计专利权评价报告", "patent assessment report", "SP"));
            Add(new CPCOfficialFileConfig("230703", "授予外观设计专利权通知书更正通知书", "correction-grant", "SP"));
            Add(new CPCOfficialFileConfig("250301", "国际申请不能进入中国国家阶段通知书", "memo", "DXD"));
            Add(new CPCOfficialFileConfig("250302", "国际申请进入中国国家阶段通知书", "enter into national phase", "DXD"));
            Add(new CPCOfficialFileConfig("250303", "修改文件缺陷通知书", "memo", DeadlineFiledType.Deadline, "correction", "", 15, 2, "DXD"));
            Add(new CPCOfficialFileConfig("250304", "国际申请进入中国国家阶段初步审查合格通知书", "pe-pass", DeadlineFiledType.Case, "PRE_EXAM_PASSED", string.Empty, 0, 0, "ON"));
            Add(new CPCOfficialFileConfig("250306", "未收到专利性国际初步报告通知书", "memo", "DXD"));
            Add(new CPCOfficialFileConfig("250309", "修改不予考虑通知书", "memo", "DXD"));
            Add(new CPCOfficialFileConfig("250311", "递交邮寄文件回执", "memo"));
        }

        public static CPCOfficialFileConfigCollection Instance => new CPCOfficialFileConfigCollection();
    }
}