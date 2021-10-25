using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IBaseService<TModel> where TModel : BaseModel
    {
        int AddOrUpdate(TModel model);
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        void AddRange(IEnumerable<TModel> models);
        bool Delete(int id);
        void DeleteRange(params int[] modelIds);
        void DeleteRange(IEnumerable<TModel> models);
    }
}
