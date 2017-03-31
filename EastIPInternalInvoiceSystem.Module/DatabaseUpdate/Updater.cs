using System;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using EastIPInternalInvoiceSystem.Module.BusinessObjects;

namespace EastIPInternalInvoiceSystem.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }

        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
            var sampleUser = ObjectSpace.FindObject<PermissionPolicyUser>(new BinaryOperator("UserName", "User"));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<PermissionPolicyUser>();
                sampleUser.UserName = "User";
                sampleUser.SetPassword("");
            }
            var defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            var userAdmin = ObjectSpace.FindObject<PermissionPolicyUser>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<PermissionPolicyUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            var adminRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
            userAdmin.Roles.Add(adminRole);

            #region 增加成员

            CreateAgent("YCJ", "叶朝君");
            CreateAgent("LIL", "李丽");
            CreateAgent("TYY", "谭营营");
            CreateAgent("ZHJ", "周永佳");
            CreateAgent("DEC", "邓超");
            CreateAgent("TYN", "田云");
            CreateAgent("LRO", "刘熔");
            CreateAgent("ZZW", "周振巍");
            CreateAgent("CAY", "曹晔");
            CreateAgent("AUS", "张震宇(Austin)");
            CreateAgent("QBZ", "曲宝壮");
            CreateAgent("LCC", "林程程");
            CreateAgent("DSM", "邓素敏");
            CreateAgent("FUL", "付乐");
            CreateAgent("WXL", "王晓琳");
            CreateAgent("HAY", "郝玥");
            CreateAgent("JIL", "金兰");
            CreateAgent("ZME", "赵萌");
            CreateAgent("YJR", "苑军茹");
            CreateAgent("IYU", "李宇");
            CreateAgent("LYG", "刘阳");
            CreateAgent("ZLL", "张琳琳");
            CreateAgent("XJA", "谢佳");
            CreateAgent("ZJJ", "张俊杰");
            CreateAgent("HML", "何明伦");
            CreateAgent("YJJ", "杨佳静");
            CreateAgent("ZYT", "赵雨桐");
            CreateAgent("ZHY", "张妍(PA)");
            CreateAgent("LNJ", "林军");
            CreateAgent("CME", "陈蒙");
            CreateAgent("JML", "金美莲");
            CreateAgent("ZHM", "张敏");
            CreateAgent("WDA", "王冬华");
            CreateAgent("DJF", "杜晋芳");
            CreateAgent("HAX", "韩雪");
            CreateAgent("ZJM", "张健铭");
            CreateAgent("HHW", "郝赫为");
            CreateAgent("ZHA", "张妍（法律）");
            CreateAgent("WYN", "王颖");
            CreateAgent("SOV", "宋炜");
            CreateAgent("LDS", "林东姝");
            CreateAgent("DUQ", "段琼");
            CreateAgent("WXY", "王小玚");
            CreateAgent("YUK", "布上由贵");
            CreateAgent("WUF", "武飞");
            CreateAgent("KAY", "康颖");
            CreateAgent("LXF", "刘晓飞");
            CreateAgent("YMI", "可儿由美");
            CreateAgent("ZUL", "朱琳");
            CreateAgent("ZYL", "朱亦林");
            CreateAgent("WCH", "吴崇");
            CreateAgent("WCY", "王春艳");
            CreateAgent("HHY", "黄涵玥");
            CreateAgent("DOY", "董源");
            CreateAgent("LIH", "刘欢");
            CreateAgent("LGX", "李国祥");
            CreateAgent("JYH", "金英花");
            CreateAgent("GYA", "郭妍");
            CreateAgent("ZHP", "周梅萍");
            CreateAgent("DYU", "董越");
            CreateAgent("ZCX", "张春晓");
            CreateAgent("HEL", "贺琳");
            CreateAgent("NAL", "娜拉");
            CreateAgent("ZFB", "朱芳斌");
            CreateAgent("CXF", "陈雪飞");
            CreateAgent("GCY", "勾昌羽");
            CreateAgent("LRZ", "刘瑞珍");
            CreateAgent("YTQ", "于天奇");
            CreateAgent("LOD", "龙丹");
            CreateAgent("YZB", "杨志博");
            CreateAgent("ZAJ", "臧静");

            #endregion

            ObjectSpace.CommitChanges(); //This line persists created object(s).
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
            if (ObjectSpace.FindObject<InternalAgent>(new BinaryOperator("Code", sCode)) != null) return;
            var agent = ObjectSpace.CreateObject<InternalAgent>();
            agent.Code = sCode;
            agent.Name = sName;
        }
    }
}