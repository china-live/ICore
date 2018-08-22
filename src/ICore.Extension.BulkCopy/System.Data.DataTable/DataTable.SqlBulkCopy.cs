using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ICore.Extension.BulkCopy
{

    public static partial class Extensions
    {
        public static void BulkWriteToServer(this System.Data.DataTable @this, string connectionString, int bulkCopyTimeout = 60)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                using (SqlBulkCopy sqlbulk = new SqlBulkCopy(sqlConnection))
                {
                    sqlbulk.DestinationTableName = @this.TableName;
                    sqlbulk.BatchSize = @this.Rows.Count;
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

        public static async Task BulkWriteToServerAsync(this System.Data.DataTable @this, string connectionString, int bulkCopyTimeout = 60)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                using (SqlBulkCopy sqlbulk = new SqlBulkCopy(sqlConnection))
                {
                    sqlbulk.DestinationTableName = @this.TableName;
                    sqlbulk.BatchSize = @this.Rows.Count;
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