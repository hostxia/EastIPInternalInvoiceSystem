using EastIPInternalInvoiceSystem.Module.DBUtility;

namespace EastIPInternalInvoiceSystem.Module.BusinessObjects
{
    public static class CommonFunction
    {
        public static string GetOurNo(string sCaseNo, ref EnumsAll.CaseType caseType)
        {
            var dtResult =
                DbHelperOra.Query($"select ourno from patentcase where ourno = '{sCaseNo.Replace("'", "''")}'").Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                caseType = EnumsAll.CaseType.Internal;
                return dtResult.Rows[0][0].ToString();
            }


            dtResult =
                DbHelperOra.Query($"select ourno from fcase where ourno = '{sCaseNo.Replace("'", "''")}'").Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                caseType = EnumsAll.CaseType.Foreign;
                return dtResult.Rows[0][0].ToString();
            }

            dtResult =
                DbHelperOra.Query($"select hk_app_ref from ex_hkcase where hk_app_ref = '{sCaseNo.Replace("'", "''")}'")
                    .Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                caseType = EnumsAll.CaseType.Hongkong;
                return dtResult.Rows[0][0].ToString();
            }

            return string.Empty;
        }
    }
}