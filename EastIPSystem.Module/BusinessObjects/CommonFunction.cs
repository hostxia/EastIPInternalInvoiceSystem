using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    public static class CommonFunction
    {
        public static string GetOurNo(string sCaseNo, ref EnumsAll.CaseType caseType)
        {
            var dtResult =
                DbHelperOra.Query($"select ourno from patentcase where ourno like '{sCaseNo.Replace("'", "''")}%'").Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                caseType = EnumsAll.CaseType.Internal;
                return dtResult.Rows[0][0].ToString();
            }


            dtResult =
                DbHelperOra.Query($"select ourno from fcase where ourno like '{sCaseNo.Replace("'", "''")}%'").Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                caseType = EnumsAll.CaseType.Foreign;
                return dtResult.Rows[0][0].ToString();
            }

            dtResult =
                DbHelperOra.Query($"select hk_app_ref from ex_hkcase where hk_app_ref like '{sCaseNo.Replace("'", "''")}%'")
                    .Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                caseType = EnumsAll.CaseType.Hongkong;
                return dtResult.Rows[0][0].ToString();
            }

            return string.Empty;
        }

        public static string GetOurNo(string sCaseNo)
        {
            if (string.IsNullOrWhiteSpace(sCaseNo)) return string.Empty;
            var dtResult =
                DbHelperOra.Query($"select ourno from patentcase where ourno like '%{sCaseNo.Trim().Replace("'", "''").ToUpper()}%'").Tables[0];
            if (dtResult.Rows.Count > 0)
                return dtResult.Rows[0][0].ToString();

            dtResult =
                DbHelperOra.Query($"select ourno from fcase where ourno like '%{sCaseNo.Trim().Replace("'", "''").ToUpper()}%'").Tables[0];
            if (dtResult.Rows.Count > 0)
                return dtResult.Rows[0][0].ToString();

            dtResult =
                DbHelperOra.Query($"select hk_app_ref from ex_hkcase where hk_app_ref like '%{sCaseNo.Trim().Replace("'", "''").ToUpper()}%'")
                    .Tables[0];
            if (dtResult.Rows.Count > 0)
                return dtResult.Rows[0][0].ToString();
            return string.Empty;
        }

        public static void GetCaseInfo(ref string sOurNo, ref string sClientNo, ref string sClient, ref string sApplicantNo, ref string sApplicant)
        {
            var dtResult =
    DbHelperOra.Query(
            $"select ourno,client,client_name,appl_code1,applicant_ch1 from patentcase where ourno like '%{sOurNo.ToUpper().Replace("'", "''")}%'")
        .Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                sOurNo = dtResult.Rows[0]["ourno"].ToString();
                sClientNo = dtResult.Rows[0]["client"].ToString();
                sClient = dtResult.Rows[0]["client_name"].ToString();
                sApplicant = dtResult.Rows[0]["applicant_ch1"].ToString();
                sApplicantNo = dtResult.Rows[0]["appl_code1"].ToString();
                return;
            }
            var dtFResult =
                DbHelperOra.Query(
                        $"select eid,role,orig_name,tran_name,ourno from fcase_ent_rel where ourno like '%{sOurNo.ToUpper().Replace("'", "''")}%' order by ent_order asc")
                    .Tables[0];
            if (dtFResult.Rows.Count > 0)
            {
                sOurNo = dtFResult.Rows[0]["ourno"].ToString();
                var drsClient = dtFResult.Select("role = 'CLI' or role = 'APPCLI'");
                var drsApp = dtFResult.Select("role = 'APP' or role = 'APPCLI'");
                if (drsClient.Length > 0)
                {
                    sClientNo = drsClient[0]["eid"]?.ToString();
                    sClient = drsClient[0]["orig_name"]?.ToString();
                    if (string.IsNullOrWhiteSpace(sClient))
                        sClient = drsClient[0]["tran_name"]?.ToString();
                }
                if (drsApp.Length > 0)
                {
                    sApplicantNo = drsApp[0]["eid"]?.ToString();
                    sApplicant = drsApp[0]["orig_name"]?.ToString();
                    if (string.IsNullOrWhiteSpace(sApplicant))
                        sApplicant = drsApp[0]["tran_name"]?.ToString();
                }
            }
            var dtHResult =
    DbHelperOra.Query(
            $"select p.client,p.client_name,p.appl_code1,p.applicant_ch1,h.hk_app_ref from ex_hkcase h,patentcase p where p.ourno(+) = h.cn_app_ref and h.hk_app_ref like '{sOurNo.ToUpper().Replace("'", "''")}'")
        .Tables[0];
            if (dtHResult.Rows.Count > 0)
            {
                sOurNo = dtResult.Rows[0]["hk_app_ref"].ToString();
                sClientNo = dtHResult.Rows[0]["client"].ToString();
                sClient = dtHResult.Rows[0]["client_name"].ToString();
                sApplicant = dtHResult.Rows[0]["applicant_ch1"].ToString();
                sApplicantNo = dtHResult.Rows[0]["appl_code1"].ToString();
            }
        }
    }
}