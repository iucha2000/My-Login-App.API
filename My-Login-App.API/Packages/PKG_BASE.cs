namespace My_Login_App.API.Packages
{
    public class PKG_BASE
    {
        private IConfiguration _configuration;

        public PKG_BASE(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected string ConnStr
        {
            get { return this._configuration.GetConnectionString("OracleConnection"); }
        }
    }
}
