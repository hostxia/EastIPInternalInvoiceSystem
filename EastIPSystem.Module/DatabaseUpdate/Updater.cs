﻿using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
            //        ((XPObjectSpace)objectSpace).Session.ExecuteQuery(
            //"select 账单号,记账日期,指定请款日,卷号,币种,官费,服务费,代理费,小时数,翻译,杂费,总计,债方,核准日 from 2017").ResultSet[0].Rows.ForEach(r =>
            //{
            //    if (
            //        ((XPObjectSpace) objectSpace).Session.ExecuteScalar(
            //            $"select 1 from internalInvoice where OurNo = '{r.Values[3]}' And FirmNo = '{r.Values[0]}'") == null)
            //    {
            //        var str = new Hashtable();
            //        str.Add("OurNo", r.Values[3]?.ToString());
            //        str.Add("FirmNo", r.Values[0]?.ToString());
            //        if (r.Values[4] != null)
            //            str.Add("s_Currency", r.Values[4]?.ToString());
            //        if (r.Values[1] != null)
            //            str.Add("dt_DateForeignInvoice", r.Values[1]?.ToString());
            //        if (r.Values[2] != null)
            //            str.Add("dt_DateApplication", r.Values[2]?.ToString());
            //        if (r.Values[13] != null)
            //            str.Add("dt_DateApproval", r.Values[13]?.ToString());
            //        if (r.Values[5] != null)
            //            str.Add("n_FeeOfficial", r.Values[5]?.ToString());
            //        if (r.Values[6] != null)
            //            str.Add("n_FeeService", r.Values[6]?.ToString());
            //        if (r.Values[7] != null)
            //            str.Add("n_FeeAgent", r.Values[7]?.ToString());
            //        if (r.Values[8] != null)
            //            str.Add("n_Hour", r.Values[8]?.ToString());
            //        if (r.Values[9] != null)
            //            str.Add("n_FeeTranslation", r.Values[9]?.ToString());
            //        if (r.Values[10] != null)
            //            str.Add("n_FeeDistribution", r.Values[10]?.ToString());
            //        if (r.Values[11] != null)
            //            str.Add("n_FeeTotal", r.Values[11]?.ToString());
            //        if (r.Values[12] != null)
            //            str.Add("s_ForeignAgency", r.Values[12]?.ToString());
            //        var scondition = $"insert into internalInvoice ({string.Join(",", str.Keys.Cast<string>().ToList())}) values ({string.Join(",", str.Values.Cast<string>().Select(s => "'" + s + "'"))})";
            //        var b = ((XPObjectSpace)objectSpace).Session.ExecuteNonQuery(scondition);
            //    }



            //var str = new List<string>();
            //if (r.Values[4] != null)
            //    str.Add(string.Format("s_Currency = '{0}'", r.Values[4]?.ToString()));
            //if (r.Values[1] != null)
            //    str.Add(string.Format("dt_DateForeignInvoice = '{0}'", r.Values[1]?.ToString()));
            //if (r.Values[2] != null)
            //    str.Add(string.Format("dt_DateApplication = '{0}'", r.Values[2]?.ToString()));
            //if (r.Values[13] != null)
            //    str.Add(string.Format("dt_DateApproval = '{0}'", r.Values[13]?.ToString()));
            //if (r.Values[5] != null)
            //    str.Add(string.Format("n_FeeOfficial = '{0}'", r.Values[5]?.ToString()));
            //if (r.Values[6] != null)
            //    str.Add(string.Format("n_FeeService = '{0}'", r.Values[6]?.ToString()));
            //if (r.Values[7] != null)
            //    str.Add(string.Format("n_FeeAgent = '{0}'", r.Values[7]?.ToString()));
            //if (r.Values[8] != null)
            //    str.Add(string.Format("n_Hour = '{0}'", r.Values[8]?.ToString()));
            //if (r.Values[9] != null)
            //    str.Add(string.Format("n_FeeTranslation = '{0}'", r.Values[9]?.ToString()));
            //if (r.Values[10] != null)
            //    str.Add(string.Format("n_FeeDistribution = '{0}'", r.Values[10]?.ToString()));
            //if (r.Values[11] != null)
            //    str.Add(string.Format("n_FeeTotal = '{0}'", r.Values[11]?.ToString()));
            //if (r.Values[12] != null)
            //    str.Add(string.Format("s_ForeignAgency = '{0}'", r.Values[12]?.ToString()));

            //var scondition = $"update internalInvoice set {string.Join(",", str)} where OurNo = '{r.Values[3]}' And FirmNo = '{r.Values[0]}'";
            //var b = ((XPObjectSpace)objectSpace).Session.ExecuteNonQuery(scondition);
            //});
            //var a = ObjectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse($"OurNo = '{r.Values[3]}' And FirmNo = '{r.Values[0]}'"));
            //if (a == null) return;
            //a.s_Currency = r.Values[4]?.ToString();
            //a.dt_DateForeignInvoice = Convert.ToDateTime(r.Values[1]);
            //a.dt_DateApplication = Convert.ToDateTime(r.Values[2]);
            //a.dt_DateApproval = Convert.ToDateTime(r.Values[13]);
            //a.n_FeeOfficial = Convert.ToDecimal(r.Values[5]);
            //a.n_FeeService = Convert.ToDecimal(r.Values[6]);
            //a.n_FeeAgent = Convert.ToDecimal(r.Values[7]);
            //a.n_Hour = Convert.ToSingle(r.Values[8]);
            //a.n_FeeTranslation = Convert.ToDecimal(r.Values[9]);
            //a.n_FeeDistribution = Convert.ToDecimal(r.Values[10]);
            //a.n_FeeTotal = Convert.ToDecimal(r.Values[11]);
            //a.s_ForeignAgency = r.Values[12]?.ToString();
            //a.Save();
            //ObjectSpace.CommitChanges();


        }

        //private void CreateCase(string sOurNo)
        //{
        //    var caseBase = ObjectSpace.CreateObject<CaseBase>();
        //    caseBase.OurNo = sOurNo;
        //}

        private void CreateRightByRoleName(string sTargetRoleName, string sSourceRoleName)
        {
            var sourceRole = ObjectSpace.FindObject<PermissionPolicyRole>(CriteriaOperator.Parse("Name = ?", sSourceRoleName));
            var targetRole = ObjectSpace.FindObject<PermissionPolicyRole>(CriteriaOperator.Parse("Name = ?", sTargetRoleName));
            sourceRole.NavigationPermissions.ToList().ForEach(n =>
            {
                var targetNew = ObjectSpace.CreateObject<PermissionPolicyNavigationPermissionObject>();
                targetNew.Role = targetRole;
                targetNew.ItemPath = n.ItemPath;
                targetNew.NavigateState = n.NavigateState;
            });
            sourceRole.TypePermissions.ToList().ForEach(t =>
            {
                var targetTypeNew = ObjectSpace.CreateObject<PermissionPolicyTypePermissionObject>();
                targetTypeNew.Role = targetRole;
                targetTypeNew.CreateState = t.CreateState;
                targetTypeNew.DeleteState = t.DeleteState;
                targetTypeNew.NavigateState = t.NavigateState;
                targetTypeNew.ReadState = t.ReadState;
                targetTypeNew.WriteState = t.ReadState;
                targetTypeNew.TargetType = t.TargetType;
                t.ObjectPermissions.ToList().ForEach(o =>
                {
                    var targetObjectNew = ObjectSpace.CreateObject<PermissionPolicyObjectPermissionsObject>();
                    targetObjectNew.TypePermissionObject = targetTypeNew;
                    targetObjectNew.Criteria = o.Criteria;
                    targetObjectNew.DeleteState = o.DeleteState;
                    targetObjectNew.NavigateState = o.NavigateState;
                    targetObjectNew.ReadState = o.ReadState;
                    targetObjectNew.WriteState = o.WriteState;
                });
                t.MemberPermissions.ToList().ForEach(m =>
                {
                    var targetMemberNew = ObjectSpace.CreateObject<PermissionPolicyMemberPermissionsObject>();
                    targetMemberNew.TypePermissionObject = targetTypeNew;
                    targetMemberNew.Criteria = m.Criteria;
                    targetMemberNew.Members = m.Members;
                    targetMemberNew.ReadState = m.ReadState;
                    targetMemberNew.WriteState = m.WriteState;
                });

            });
            ObjectSpace.CommitChanges();
        }

        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            //CreateRightByRoleName("管理部-OA组", "草单登记人");
            //CreateRightByRoleName("管理部-OA组", "缴费登记人");
            //CreateRightByRoleName("管理部-OA组", "延期请求人");

            //CreateRightByRoleName("管理部-案卷组", "缴费收据核对");

            //CreateRightByRoleName("管理部-国外组", "草单登记人");
            //CreateRightByRoleName("管理部-国外组", "缴费登记人");
            //CreateRightByRoleName("管理部-国外组", "延期请求人");

            //CreateRightByRoleName("管理部-立案组", "草单登记人");
            //CreateRightByRoleName("管理部-立案组", "缴费登记人");
            //CreateRightByRoleName("管理部-立案组", "延期请求人");

            //CreateRightByRoleName("管理部-收文组", "草单登记人");

            //CreateRightByRoleName("管理部-授权年费组", "草单登记人");
            //CreateRightByRoleName("管理部-授权年费组", "缴费登记人");

            //CreateRightByRoleName("管理部-新申请组", "草单登记人");
            //CreateRightByRoleName("管理部-新申请组", "缴费登记人");
            //CreateRightByRoleName("管理部-新申请组", "延期请求人");

            //CreateRightByRoleName("管理部-账单组", "账单管理员");

            //CreateRightByRoleName("管理部-质检组", "草单登记人");
            //CreateRightByRoleName("管理部-质检组", "草单管理员");
            //CreateRightByRoleName("管理部-质检组", "缴费登记人");
            //CreateRightByRoleName("管理部-质检组", "缴费收据核对");
            //CreateRightByRoleName("管理部-质检组", "缴费提交人");
            //CreateRightByRoleName("管理部-质检组", "延期批准人");
            //CreateRightByRoleName("管理部-质检组", "延期请求人");
            //CreateRightByRoleName("管理部-质检组", "延期审核人");



            ////string name = "MyName";
            ////DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            ////if (theObject == null)
            ////{
            ////    theObject = ObjectSpace.CreateObject<DomainObject1>();
            ////    theObject.Name = name;
            ////}
            //var sampleUser = ObjectSpace.FindObject<SysUser>(new BinaryOperator("UserName", "User"));
            //if (sampleUser == null)
            //{
            //    sampleUser = ObjectSpace.CreateObject<SysUser>();
            //    sampleUser.UserName = "User";
            //    sampleUser.SetPassword("");
            //}
            //var defaultRole = CreateDefaultRole();
            //sampleUser.Roles.Add(defaultRole);

            //var userAdmin = ObjectSpace.FindObject<SysUser>(new BinaryOperator("UserName", "Admin"));
            //if (userAdmin == null)
            //{
            //    userAdmin = ObjectSpace.CreateObject<SysUser>();
            //    userAdmin.UserName = "Admin";
            //    // Set a password if the standard authentication type is used
            //    userAdmin.SetPassword("");
            //}
            //// If a role with the Administrators name doesn't exist in the database, create this role
            //var adminRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "Administrators"));
            //if (adminRole == null)
            //{
            //    adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
            //    adminRole.Name = "Administrators";
            //}
            //adminRole.IsAdministrative = true;
            //userAdmin.Roles.Add(adminRole);

            //#region 增加成员

            //CreateAgent("YCJ", "叶朝君");
            //CreateAgent("LIL", "李丽");
            //CreateAgent("TYY", "谭营营");
            //CreateAgent("ZHJ", "周永佳");
            //CreateAgent("DEC", "邓超");
            //CreateAgent("TYN", "田云");
            //CreateAgent("LRO", "刘熔");
            //CreateAgent("ZZW", "周振巍");
            //CreateAgent("CAY", "曹晔");
            //CreateAgent("AUS", "张震宇(Austin)");
            //CreateAgent("QBZ", "曲宝壮");
            //CreateAgent("LCC", "林程程");
            //CreateAgent("DSM", "邓素敏");
            //CreateAgent("FUL", "付乐");
            //CreateAgent("WXL", "王晓琳");
            //CreateAgent("HAY", "郝玥");
            //CreateAgent("JIL", "金兰");
            //CreateAgent("ZME", "赵萌");
            //CreateAgent("YJR", "苑军茹");
            //CreateAgent("IYU", "李宇");
            //CreateAgent("LYG", "刘阳");
            //CreateAgent("ZLL", "张琳琳");
            //CreateAgent("XJA", "谢佳");
            //CreateAgent("ZJJ", "张俊杰");
            //CreateAgent("HML", "何明伦");
            //CreateAgent("YJJ", "杨佳静");
            //CreateAgent("ZYT", "赵雨桐");
            //CreateAgent("ZHY", "张妍(PA)");
            //CreateAgent("LNJ", "林军");
            //CreateAgent("CME", "陈蒙");
            //CreateAgent("JML", "金美莲");
            //CreateAgent("ZHM", "张敏");
            //CreateAgent("WDA", "王冬华");
            //CreateAgent("DJF", "杜晋芳");
            //CreateAgent("HAX", "韩雪");
            //CreateAgent("ZJM", "张健铭");
            //CreateAgent("HHW", "郝赫为");
            //CreateAgent("ZHA", "张妍（法律）");
            //CreateAgent("WYN", "王颖");
            //CreateAgent("SOV", "宋炜");
            //CreateAgent("LDS", "林东姝");
            //CreateAgent("DUQ", "段琼");
            //CreateAgent("WXY", "王小玚");
            //CreateAgent("YUK", "布上由贵");
            //CreateAgent("WUF", "武飞");
            //CreateAgent("KAY", "康颖");
            //CreateAgent("LXF", "刘晓飞");
            //CreateAgent("YMI", "可儿由美");
            //CreateAgent("ZUL", "朱琳");
            //CreateAgent("ZYL", "朱亦林");
            //CreateAgent("WCH", "吴崇");
            //CreateAgent("WCY", "王春艳");
            //CreateAgent("HHY", "黄涵玥");
            //CreateAgent("DOY", "董源");
            //CreateAgent("LIH", "刘欢");
            //CreateAgent("LGX", "李国祥");
            //CreateAgent("JYH", "金英花");
            //CreateAgent("GYA", "郭妍");
            //CreateAgent("ZHP", "周梅萍");
            //CreateAgent("DYU", "董越");
            //CreateAgent("ZCX", "张春晓");
            //CreateAgent("HEL", "贺琳");
            //CreateAgent("NAL", "娜拉");
            //CreateAgent("ZFB", "朱芳斌");
            //CreateAgent("CXF", "陈雪飞");
            //CreateAgent("GCY", "勾昌羽");
            //CreateAgent("LRZ", "刘瑞珍");
            //CreateAgent("YTQ", "于天奇");
            //CreateAgent("LOD", "龙丹");
            //CreateAgent("YZB", "杨志博");
            //CreateAgent("ZAJ", "臧静");
            //CreateAgent("CGS", "曹广生");
            //CreateAgent("CHH", "陈　红");
            //CreateAgent("CHM", "程　淼");
            //CreateAgent("DFY", "董方源");
            //CreateAgent("DLJ", "杜立健");
            //CreateAgent("DUJ", "杜　娟");
            //CreateAgent("GJF", "皋吉甫");
            //CreateAgent("GLG", "甘　玲");
            //CreateAgent("HDZ", "黄大正");
            //CreateAgent("HFY", "皇甫悦");
            //CreateAgent("HLS", "黄大正、李渤、宋鹤");
            //CreateAgent("HRL", "何瑞莲");
            //CreateAgent("HXC", "洪秀川");
            //CreateAgent("JFE", "姜　飞");
            //CreateAgent("JGY", "纪关源");
            //CreateAgent("JYA", "金　杨");
            //CreateAgent("JZQ", "经志强");
            //CreateAgent("LBI", "吕　冰");
            //CreateAgent("LBO", "李　渤");
            //CreateAgent("LCL", "柳春雷");
            //CreateAgent("LEJ", "雷　娟");
            //CreateAgent("LGR", "刘桂荣");
            //CreateAgent("LIJ", "李　剑");
            //CreateAgent("LJF", "刘佳斐");
            //CreateAgent("LJU", "刘　军");
            //CreateAgent("LLG", "高卢麟");
            //CreateAgent("LMH", "刘名华");
            //CreateAgent("LQG", "林　强");
            //CreateAgent("LQH", "李其华");
            //CreateAgent("LRH", "李瑞海");
            //CreateAgent("LUJ", "陆锦华");
            //CreateAgent("LUY", "鲁　异");
            //CreateAgent("LXD", "李晓冬");
            //CreateAgent("LYJ", "吕雁葭");
            //CreateAgent("LYL", "李亚临");
            //CreateAgent("LYN", "李　雁");
            //CreateAgent("LYU", "刘　耘");
            //CreateAgent("NIB", "倪　斌");
            //CreateAgent("NWR", "牛蔚然");
            //CreateAgent("OUT", "个人外翻");
            //CreateAgent("PJY", "彭久云");
            //CreateAgent("PSL", "潘士霖");
            //CreateAgent("PWU", "彭　武");
            //CreateAgent("REN", "任　兵");
            //CreateAgent("SHE", "宋　鹤");
            //CreateAgent("SJH", "黄绅嘉");
            //CreateAgent("SKY", "宋开元");
            //CreateAgent("SLI", "孙　莉");
            //CreateAgent("SMI", "桑　敏");
            //CreateAgent("SMY", "孙明岩");
            //CreateAgent("SXY", "宋新月");
            //CreateAgent("SYA", "孙　洋");
            //CreateAgent("SYN", "宋　岩");
            //CreateAgent("WAW", "王安武");
            //CreateAgent("WDH", "王东辉");
            //CreateAgent("WHG", "吴海静");
            //CreateAgent("WHO", "王　昊");
            //CreateAgent("WQR", "吴其瑞");
            //CreateAgent("WUY", "吴　艳");
            //CreateAgent("WXW", "吴湘文");
            //CreateAgent("WYI", "王　怡");
            //CreateAgent("WYY", "王媛媛");
            //CreateAgent("XHU", "向　虎");
            //CreateAgent("XSQ", "肖善强");
            //CreateAgent("YQI", "杨　谦");
            //CreateAgent("YSS", "严　慎");
            //CreateAgent("YUM", "余　明");
            //CreateAgent("YZC", "应志超");
            //CreateAgent("ZBR", "张宝荣");
            //CreateAgent("ZHF ", "赵　飞");
            //CreateAgent("ZHL", "张　雷");
            //CreateAgent("ZHT", "张　涛");
            //CreateAgent("ZLX", "张丽新");
            //CreateAgent("ZSP", "赵淑萍");
            //CreateAgent("ZWY", "邹伟艳");
            //CreateAgent("ZXB", "宗晓斌");
            //CreateAgent("ZYA", "赵　艳");
            //CreateAgent("ZYF", "周友福");
            //CreateAgent("ZYH", "张耀宏");
            //CreateAgent("ZYY", "张永玉");
            //CreateAgent("PEQ", "彭琼");
            //CreateAgent("OTH", "公司外翻");
            //CreateAgent("WHG", "吴海静");
            //CreateAgent("SKY", "宋开元");
            //CreateAgent("DLJ", "杜立健");
            //CreateAgent("HFY", "皇甫悦");
            //CreateAgent("LEJ", "雷娟");
            //CreateAgent("SMI", "桑敏");
            //CreateAgent("JGY", "纪关源");
            //CreateAgent("ZHL", "张雷");
            //CreateAgent("YCF", "玉昌峰");
            //CreateAgent("TIN", "南霆");
            //CreateAgent("SPF", "孙鹏飞");
            //CreateAgent("WXB", "王学兵");
            //CreateAgent("WZH", "汪正");
            //CreateAgent("ZYJ", "张元俊");
            //CreateAgent("TLJ", "田琳婧");
            //CreateAgent("LYA", "罗亚男");
            //CreateAgent("DWS", "杜文树");
            //CreateAgent("ZWJ", "张万杰");
            //CreateAgent("LIY", "刘媛");
            //CreateAgent("BSJ", "白少俊");
            //CreateAgent("ZHN", "赵楠");
            //CreateAgent("LQZ", "李庆泽");
            //CreateAgent("TLL", "谭玲玲");
            //CreateAgent("FLY", "付凌云");
            //CreateAgent("LXJ", "李喜娟");
            //CreateAgent("SUM", "孙敏");
            //CreateAgent("GZC", "郭子氚");
            //CreateAgent("ZHW", "赵红伟");
            //CreateAgent("LGJ", "李永军");
            //CreateAgent("DOJ", "董佳");
            //CreateAgent("WEH", "魏宏");
            //CreateAgent("OTH", "翻译公司");
            //CreateAgent("ZHB", "张斌");
            //CreateAgent("ZBB", "张兵兵");
            //CreateAgent("BRY", "白若昱");
            //CreateAgent("PJC", "朴今春");
            //CreateAgent("LBY", "林伯颖");
            //CreateAgent("WUB", "武兵");
            //CreateAgent("YCJ", "叶朝君");
            //CreateAgent("LIL", "李丽");
            //CreateAgent("TYY", "谭营营");
            //CreateAgent("ZHJ", "周永佳");
            //CreateAgent("DEC", "邓超");
            //CreateAgent("TYN", "田云");
            //CreateAgent("LRO", "刘熔");
            //CreateAgent("ZZW", "周振巍");
            //CreateAgent("CAY", "曹晔");
            //CreateAgent("AUS", "张震宇(Austin)");
            //CreateAgent("QBZ", "曲宝壮");
            //CreateAgent("LCC", "林程程");
            //CreateAgent("DSM", "邓素敏");
            //CreateAgent("FUL", "付乐");
            //CreateAgent("WXL", "王晓琳");
            //CreateAgent("HAY", "郝玥");
            //CreateAgent("JIL", "金兰");
            //CreateAgent("ZME", "赵萌");
            //CreateAgent("YJR", "苑军茹");
            //CreateAgent("IYU", "李宇");
            //CreateAgent("LYG", "刘阳");
            //CreateAgent("ZLL", "张琳琳");
            //CreateAgent("XJA", "谢佳");
            //CreateAgent("ZJJ", "张俊杰");
            //CreateAgent("HML", "何明伦");
            //CreateAgent("YJJ", "杨佳静");
            //CreateAgent("ZYT", "赵雨桐");
            //CreateAgent("ZHY", "张妍(PA)");
            //CreateAgent("LNJ", "林军");
            //CreateAgent("CME", "陈蒙");
            //CreateAgent("JML", "金美莲");
            //CreateAgent("ZHM", "张敏");
            //CreateAgent("WDA", "王冬华");
            //CreateAgent("DJF", "杜晋芳");
            //CreateAgent("HAX", "韩雪");
            //CreateAgent("ZJM", "张健铭");
            //CreateAgent("HHW", "郝赫为");
            //CreateAgent("ZHA", "张妍（法律）");
            //CreateAgent("WYN", "王颖");
            //CreateAgent("SOV", "宋炜");
            //CreateAgent("LDS", "林东姝");
            //CreateAgent("DUQ", "段琼");
            //CreateAgent("WXY", "王小玚");
            //CreateAgent("YUK", "布上由贵");
            //CreateAgent("WUF", "武飞");
            //CreateAgent("KAY", "康颖");
            //CreateAgent("LXF", "刘晓飞");
            //CreateAgent("YMI", "可儿由美");
            //CreateAgent("ZUL", "朱琳");
            //CreateAgent("ZYL", "朱亦林");
            //CreateAgent("WCH", "吴崇");
            //CreateAgent("WCY", "王春艳");
            //CreateAgent("HHY", "黄涵玥");
            //CreateAgent("DOY", "董源");
            //CreateAgent("LIH", "刘欢");
            //CreateAgent("LGX", "李国祥");
            //CreateAgent("JYH", "金英花");
            //CreateAgent("GYA", "郭妍");
            //CreateAgent("ZHP", "周梅萍");
            //CreateAgent("DYU", "董越");
            //CreateAgent("ZCX", "张春晓");
            //CreateAgent("HEL", "贺琳");
            //CreateAgent("NAL", "娜拉");
            //CreateAgent("ZFB", "朱芳斌");
            //CreateAgent("CXF", "陈雪飞");
            //CreateAgent("GCY", "勾昌羽");
            //CreateAgent("LRZ", "刘瑞珍");
            //CreateAgent("YTQ", "于天奇");
            //CreateAgent("LOD", "龙丹");
            //CreateAgent("YZB", "杨志博");
            //CreateAgent("ZAJ", "臧静");

            //#endregion

            //ObjectSpace.CommitChanges(); //This line persists created object(s).
        }

        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }

        private PermissionPolicyRole CreateDefaultRole()
        {
            var defaultRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "Default"));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectPermission<PermissionPolicyUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()",
                    SecurityPermissionState.Allow);
                defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails",
                    SecurityPermissionState.Allow);
                defaultRole.AddMemberPermission<PermissionPolicyUser>(SecurityOperations.Write,
                    "ChangePasswordOnFirstLogon", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermission<PermissionPolicyUser>(SecurityOperations.Write, "StoredPassword",
                    "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read,
                    SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess,
                    SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess,
                    SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create,
                    SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create,
                    SecurityPermissionState.Allow);
            }
            return defaultRole;
        }

        private void CreateAgent(string sCode, string sName)
        {
            if (ObjectSpace.FindObject<SysUser>(new BinaryOperator("Code", sCode)) != null) return;
            var agent = ObjectSpace.CreateObject<SysUser>();
            agent.Code = sCode;
            agent.Name = sName;
        }
    }
}