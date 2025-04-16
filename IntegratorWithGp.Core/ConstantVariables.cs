namespace IntegratorWithGp.Core
{
    public class ConstantVariables
    {
        public const string connectionStringGPWithIntegrated = @"Data Source=.;Initial Catalog=TEST;User ID=sa;Password=GP@dminSAadmin@123;Integrated Security=SSPI;persist security info=False;packet size = 4096"; //test
        public const string connectionStringGPWithOUTIntegrated = @"Data Source=.;Persist Security Info=True;Initial Catalog=TEST;Integrated Security=false;User Id=sa;Password=SAadmin@123;packet size = 4096"; //test

        // public const string connectionStringGPWithIntegrated = @"Data Source=.;Initial Catalog=LATTL;User ID=sa;Password=GP@dminSAadmin@123;Integrated Security=SSPI;persist security info=False;packet size = 4096"; //live
        //public const string connectionStringGPWithOUTIntegrated = @"Data Source=.;Persist Security Info=True;Initial Catalog=LATTL;Integrated Security=false;User Id=sa;Password=SAadmin@123;packet size = 4096";     //live

    }
}
