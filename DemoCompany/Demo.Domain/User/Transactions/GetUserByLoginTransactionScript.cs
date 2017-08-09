using System.Linq;
using Demo.Domain.User.Entities;
using Demo.Domain.Transactions.BaseTransaction;
using Demo.Utility.Connections;
using System.Data;
using Dapper;

namespace Demo.Domain.User.Transactions
{
    public interface IGetUserByLoginTransactionScript
    {
        UserOutputData PerformTransaction(UserInputData operand);
    }

    public class GetUserByLoginTransactionScript : TransactionScript<UserInputData, UserOutputData>, IGetUserByLoginTransactionScript
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public GetUserByLoginTransactionScript(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected override UserOutputData ExecuteCalls(UserInputData operand)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return
                    connection.Query<UserOutputData>("[schema].[sp_dowork]",
                        new
                        {
                            Login = operand.Login
                        },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
