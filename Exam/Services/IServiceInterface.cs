using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public interface IServiceInterface<TModel> where TModel : BaseModel
    {
        int AddOrUpdate(TModel model);
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        void AddRange(IEnumerable<TModel> models);
        bool Delete(int id);
    }
}
