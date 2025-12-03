namespace PMS.Const
{
    public static class PMSConst
    {
        public const string FDT_GetByPrio =$"{PMSSchem.SName}sp_Show_Project";
        public const string ENQ_AddEmp =$"{PMSSchem.SName}sp_registerEmployee";
        public const string ENQ_LoginEmo =$"{PMSSchem.SName}sp_loginEmployee";
        public const string ENQ_UpsertProj = $"{PMSSchem.SName}sp_Upsert_Project";
        public const string USP_USER_LOGIN = $"{PMSSchem.INSTA}usp_get_user_data";
        public const string USP_USER_REGISTER = $"{PMSSchem.INSTA}usp_upsert_user";
        public const string USP_UPSERT_POST = $"{PMSSchem.INSTA}usp_upsert_posts";
        public const string USP_GET_POSTS_LIST = $"{PMSSchem.INSTA}usp_get_post_list";
    }
    public static class PMSSchem
    {
        public const string SName = "dbo.";
        public const string INSTA = "insta.";
    }
}