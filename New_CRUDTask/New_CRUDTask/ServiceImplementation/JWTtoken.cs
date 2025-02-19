using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class JWTtoken
    {
        private readonly DbContextServer _db;
        private readonly IConfiguration _con;
        public JWTtoken(DbContextServer db , IConfiguration con)
        {
            _db = db;
            _con = con;
        }

    }
}
