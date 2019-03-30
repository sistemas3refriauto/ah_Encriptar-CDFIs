using MySql.Data.MySqlClient;

namespace refriauto
{
    internal class SQLiteDataAdapter : SqlLiteDataReader
    {
        private MySqlCommand query;

        public SQLiteDataAdapter(MySqlCommand query)
        {
            this.query = query;
        }
    }
}