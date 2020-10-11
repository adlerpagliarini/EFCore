using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace EFCore.Infrastructure.Interceptors
{
    public class CommandInterceptor : DbCommandInterceptor, IDbCommandInterceptor
    {
        public override Task<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"*** \n *** Interceptor Reader ExecutionTime {eventData.Duration.TotalMilliseconds} ms. | {eventData.Duration.TotalSeconds} seconds.");
            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }
    }
}
