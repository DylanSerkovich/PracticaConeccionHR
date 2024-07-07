using Oracle.ManagedDataAccess.Client;
using PracticaConeccionHR.Context;
using PracticaConeccionHR.Model;

namespace PracticaConeccionHR.Repository
{
    public class JobsRepository : IJobsRepository
    {
        private IHRMDBContext _hrmdbContext;

        public JobsRepository(IHRMDBContext hrmdbContext)
        {
            _hrmdbContext = hrmdbContext;
        }

        public void AddJob(Jobs job)
        {
            using (OracleConnection con = _hrmdbContext.GetConn())
            {
                using (OracleCommand cmd = _hrmdbContext.GetCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = "INSERT INTO JOBS (JOB_ID, JOB_TITLE, MIN_SALARY, MAX_SALARY) VALUES (:JobId, :JobTitle, :MinSalary, :MaxSalary)";

                        cmd.Parameters.Add(new OracleParameter("JobId", job.JobId));
                        cmd.Parameters.Add(new OracleParameter("JobTitle", job.JobTitle));
                        cmd.Parameters.Add(new OracleParameter("MinSalary", job.MinSalary));
                        cmd.Parameters.Add(new OracleParameter("MaxSalary", job.MaxSalary));

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public List<Jobs> GetAllBranches()
        {
            List<Jobs> jobs = new List<Jobs>();

            using (OracleConnection con = _hrmdbContext.GetConn())
            {
                using(OracleCommand cmd = _hrmdbContext.GetCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = "SELECT * FROM JOBS";

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            jobs.Add(new Jobs()
                            {
                                JobId = reader["JOB_ID"].ToString(),
                                JobTitle = reader["JOB_TITLE"].ToString(),
                                MinSalary = Convert.ToInt32(reader["MIN_SALARY"]),
                                MaxSalary = Convert.ToInt32(reader["MAX_SALARY"])
                            });
                        }
                        reader.Dispose();
                        return jobs;
                    }
                    catch(Exception ex) { throw (ex); }
                    finally 
                    { 
                        con.Close(); 
                    }
        }
            }
        }

        public Jobs GetById(string jobId)
        {
            Jobs job = null;

            using (OracleConnection con = _hrmdbContext.GetConn())
            {
                using (OracleCommand cmd = _hrmdbContext.GetCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        cmd.CommandText = "SELECT * FROM JOBS WHERE JOB_ID = :JobId";
                        cmd.Parameters.Add(new OracleParameter("JobId", jobId));

                        OracleDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            job = new Jobs()
                            {
                                JobId = reader["JOB_ID"].ToString(),
                                JobTitle = reader["JOB_TITLE"].ToString(),
                                MinSalary = Convert.ToInt32(reader["MIN_SALARY"]),
                                MaxSalary = Convert.ToInt32(reader["MAX_SALARY"])
                            };
                        }
                        reader.Dispose();
                        return job;
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
