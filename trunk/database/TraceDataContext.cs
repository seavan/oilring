using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Database
{
    public abstract class TraceDataContext
    {
        public TraceDataContext(string _connection)
        {
            m_Connection = _connection;
            ReadOnlyContext = new DataContext(_connection);
            ReadOnlyContext.ObjectTrackingEnabled = false;
            ReadOnlyContext.DeferredLoadingEnabled = false;
            ReadOnlyContext.LoadOptions = new DataLoadOptions();

            m_TextWriter = new StringWriter(m_StringBuilder);

            ReadOnlyContext.Log = m_TextWriter;
            m_StartTime = DateTime.Now;
            m_TextWriter.WriteLine("<b>{0}</b>: log started ", m_StartTime);

        }

        //        public bool SupressLog { get; set;  }

        public string Finalize()
        {
            m_TextWriter.WriteLine("<b>{0}</b>: log finished", m_StartTime);
            m_TextWriter.WriteLine("Total execution time {0}", DateTime.Now - m_StartTime);
            return m_StringBuilder.ToString();
        }

        public void Trace(string _msg)
        {
            m_TextWriter.WriteLine("<b>{0}</b>: {1}", DateTime.Now, _msg);
        }

        public void Transaction(Action<DataContext> _action)
        {
            // var mutex = new Mutex(false, "NetDB1");
            // mutex.WaitOne();
            using (var conn = new SqlConnection(m_Connection))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var context = new DataContext(conn))
                {
                    context.Log = m_TextWriter;

                    //var transaction = conn.BeginTransaction(IsolationLevel.Serializable);
                    //context.Transaction = transaction;

                    try
                    {
                        _action(context);
                        // transaction.Commit();
                        context.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (Exception _e)
                    {
                        Trace(_e.Message);
                        // transaction.Rollback();
                        throw _e;
                    }
                    finally
                    {
                        // mutex.ReleaseMutex();
                        conn.Close();
                    }

                }
            }
        }

        private StringBuilder m_StringBuilder = new StringBuilder();
        private TextWriter m_TextWriter;
        private DateTime m_StartTime;
        private string m_Connection;

        public DataContext ReadOnlyContext { get; private set; }
    }
}
