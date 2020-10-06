using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interface
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        IDatabaseContext DataContext { get; }
        SqlTransaction BeginTransaction();

        /// <summary>
        /// The Commit.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        void Commit();

    }
}
