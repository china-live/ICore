using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ICore.Extension.BulkCopy
{
    public static partial class Extensions
    {
        public static void BulkWriteToServer(this System.Data.DataRow[] @this, string tableName, string connectionString, int bulkCopyTimeout = 60)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                using (SqlBulkCopy sqlbulk = new SqlBulkCopy(sqlConnection))
                {
                    sqlbulk.DestinationTableName = tableName;
                    sqlbulk.BatchSize = @this.Length;
                    sqlbulk.BulkCopyTimeout = bulkCopyTimeout;
                    sqlbulk.WriteToServer(@this);
                    sqlbulk.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public static async Task BulkWriteToServerAsync(this System.Data.DataRow[] @this, string tableName, string connectionString, int bulkCopyTimeout = 60)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                using (SqlBulkCopy sqlbulk = new SqlBulkCopy(sqlConnection))
                {
                    sqlbulk.DestinationTableName = tableName;
                    sqlbulk.BatchSize = @this.Length;
                    sqlbulk.BulkCopyTimeout = bulkCopyTimeout;
                    await sqlbulk.WriteToServerAsync(@this);
                    sqlbulk.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }
}
