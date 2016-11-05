using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public static class clsDatabase
    {
        private static SqlConnection _oDataBase = null;
        public static SqlConnection oDataBase
        {
            get
            {
                if (_oDataBase == null || _oDataBase.State != ConnectionState.Open)
                {
                    _oDataBase = new SqlConnection();
                    _oDataBase.ConnectionString = Globals.DefaultConnectionString;

                }
                return _oDataBase;
            }

            set
            { }
        }
        public static SqlTransaction _oTrans;
        public static void BeginTrans()
        {
            _oTrans = _oDataBase.BeginTransaction();
        }
        public static void RollBack()
        {
            _oTrans.Rollback();
        }
        public static void commit()
        {
            _oTrans.Commit();
        }
      
        public static SqlTransaction MyTansaction
        {
            get
            {
                
                return _oTrans;
            }

            set
            { }
        }

        public static TransactionScope CreateReadCommitted()
       {
            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
        public static TransactionScope CreateSeriazable()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.Serializable,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
        public static TransactionScope CreateReadUncommitted()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
        public static TransactionScope RepeatableRead()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
        public static TransactionScope Snapshot()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.Snapshot,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }
    }
}
