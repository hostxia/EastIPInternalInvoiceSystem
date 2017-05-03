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
            香港申请_手工提醒_其他类型香港申请
        }

        public enum CaseType
        {
            Internal,
            Hongkong,
            Foreign,
        }
    }
}