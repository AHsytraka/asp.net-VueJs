using BackForVue.Models;

namespace BackForVue.Repositories;

public interface IEmployeRepository
{
    Employe CreateEmp(Employe employe);
    List<Employe> GetAllEmp();
    Employe UpdateEmp(Employe oldEmp, Employe newEmp);
    public void DeleteEmp(int numEmp);
}