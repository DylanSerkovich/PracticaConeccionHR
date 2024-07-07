using PracticaConeccionHR.Model;

namespace PracticaConeccionHR.Repository
{
    public interface IJobsRepository
    {
        List<Jobs> GetAllBranches();

        Jobs GetById(string jobId);

        void AddJob(Jobs job);

    }
}
