namespace ConnectLegal.Constants;

public static class AuthorizationConstants
{
    public const string AdminRole = "Admin";
    public const string UserRole = "User";
    public const string LawyerRole = "Lawyer";

    public static class Policies
    {
        public const string RequireAdmin = "RequireAdmin";
        public const string RequireLawyer = "RequireLawyer";
        public const string RequireAdminOrLawyer = "RequireAdminOrLawyer";
    }
}