using System.Data;

namespace exe1.Repositories
{
    internal class SqlParameter
    {
        private string v;
        private string? name;
        private int id;

        public SqlParameter(string v, string? name)
        {
            this.v = v;
            this.name = name;
        }

        public SqlParameter(string v, int id)
        {
            this.v = v;
            this.id = id;
        }

        public string ParameterName { get; set; }
        public SqlDbType SqlDbType { get; set; }
        public ParameterDirection Direction { get; set; }
        public int Value { get; internal set; }
    }
}