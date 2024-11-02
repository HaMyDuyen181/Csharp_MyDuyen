
namespace Quanlyview
{
    internal class SqlConnection
    {
        private string strCon;

        public SqlConnection(string strCon)
        {
            this.strCon = strCon;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}