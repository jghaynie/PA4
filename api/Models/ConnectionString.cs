namespace api.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString(){
            string server = "pxukqohrckdfo4ty.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "v1t2f1th86nwmiqm";
            string port = "3306";
            string username = "aqsm8gezkfntcqa4";
            string password = "aop9667vrijh64hm";

            cs = $@"server={server};user={username};database={database};port={port};password={password};";
        }
    }
}