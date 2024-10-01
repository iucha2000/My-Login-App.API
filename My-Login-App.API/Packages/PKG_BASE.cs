namespace My_Login_App.API.Packages
{
    internal class PKG_BASE
    {
        string connString;

        public PKG_BASE()
        {
            connString = @"Data Source=(DESCRIPTION =  (ADDRESS = (PROTOCOL = TCP)(HOST = 172.20.0.188)(PORT = 1521)) (CONNECT_DATA =   (SERVER = DEDICATED) (SID = orcl)));User Id=olerning;Password=olerning";
        }

        protected string ConnStr
        {
            get { return connString; }
        }
    }
}
