using layers.Models;

namespace layers.Reposiotries
{
    public interface IemployeeRepo
    {
        int Add(employee emp);
        int Delete(int id);
        int Edit(employee emp);
        List<employee> getAll();
        employee getById(int id);
    }
}