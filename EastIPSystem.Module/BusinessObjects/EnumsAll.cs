namespace EastIPSystem.Module.BusinessObjects
{
    public class EnumsAll
    {
        public enum InternalType
        {
            新申请,
            中间,
            OA,
            年费,
            国外申请,
            特殊案件,
            其他,
            结案
        }

        public enum CaseExtensionState
        {
            未提交,
            部门审核,
            部门审核未通过,
            修改延期,
            修改延期未通过,
            确认延期,
            确认延期通过
        }

        public enum ApprovalState
        {
            待审批,
            通过,
            未通过
        }

        public enum InvoiceState
        {
            未提交,
            未开账单,
            已开账单,
        }

        public enum FeeType
        {
            官费,
            杂费
        }

        public enum WorkType
        {
            诉讼,
            无效,
            客户咨询,
            客户扩展,
            办公,
            培训,
            出差,
            其他
        }

        public enum WorkItemState
        {
            未提交,
            待审批,
            已审批,
            已核发
        }

        public enum CaseExtensionItem
        {
            递交前待做_返稿时限,
            计划日或绝限日,
            补正,
            答OA时限,
            国外库_递交日,
            国外库_返稿日,
            特殊案件账单时限,
            香港申请_手工提醒_其他类型香港申请,
            转OA时限,
            其他
        }

        public enum CaseType
        {
            Internal,
            Hongkong,
            Foreign,
        }

        public enum PayCaseType
        {
            国内,
            PCT国家,
            PCT国际
        }

        public enum PaidBy
        {
            网上缴费,
            现金缴费
        }

        public enum PatentType
        {
            发明,
            实用新型,
            外观设计,
            集成电路,
            软件著作权
        }

        public enum PatentProgressItem
        {
            未处理,
            正在撰写,
            内部审核,
            已返发明人,
            提醒发明人反馈,
            修改发明人稿,
            已返IPR,
            提醒IPR反馈,
            修改IPR稿,
            已定稿等递交指示,
            已递交
        }

        public enum PatentDirection
        {
            内到内,
            外到内,
            内到外,
            外到外
        }

        public enum PatentCaseType
        {
            中国申请_撰写_发明,
            中国申请_撰写_实用新型,
            中国申请_撰写_外观设计,

            中国申请_巴黎公约_发明,
            中国申请_巴黎公约_实用新型,
            中国申请_巴黎公约_外观设计,

            中国申请_PCT进国家_发明,
            中国申请_PCT进国家_实用新型,

            国外申请_国际申请,

            国外申请_巴黎公约_发明,
            国外申请_巴黎公约_实用新型,
            国外申请_巴黎公约_外观设计,

            国外申请_PCT国家_发明,
            国外申请_PCT国家_实用新型,

            国外申请_香港_标准,
            国外申请_香港_短期,
            国外申请_香港_外观,

            国外申请_澳门_延伸,
            国外申请_澳门_外观,

            其他注册申请_保密审查,
            其他注册申请_集成电路,
            其他注册申请_版权登记,

            杂务类_检索案,
            杂务类_专利分析,
            杂务类_咨询案,
            杂务类_许可备案,
            杂务类_交公众意见,
            杂务类_翻译案,
            杂务类_行政复议案,

            冲突类_无效_无效案,
            冲突类_无效_答辩案,

            冲突类_行政诉讼_请求案,
            冲突类_行政诉讼_答辩案,

            冲突类_侵权诉讼_请求案,
            冲突类_侵权诉讼_答辩案,
        }

        public enum PatentProcess
        {
            新申请,
            中间,
            OA,
            年费
        }
    }
}