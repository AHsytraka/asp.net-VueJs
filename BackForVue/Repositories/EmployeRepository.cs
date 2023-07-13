using BackForVue.Data;
using BackForVue.Models;

namespace BackForVue.Repositories;
#nullable disable
public class EmployeRepository : IEmployeRepository
{
    private readonly AppDbContext _dbcontext;
    public EmployeRepository(AppDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public Employe CreateEmp(Employe employe)
    {
        _dbcontext.Employes.Add(employe);
        _dbcontext.SaveChanges();

        return employe;
    }

    public List<Employe> GetAllEmp()
    {
        var allEmp = _dbcontext.Employes.Select(row => row).ToList();
        return allEmp;
    }

    public Employe UpdateEmp(Employe oldEmp, Employe newEmp)
    {
        oldEmp.Nom = newEmp.Nom;
        oldEmp.Salaire = newEmp.Salaire;
        _dbcontext.SaveChanges();
        return newEmp;
    }

    public void DeleteEmp(int numEmp)
    {
        var empToRemove = _dbcontext.Employes.FirstOrDefault(e => e.NumEmp == numEmp);
        _dbcontext.Employes.Remove(empToRemove);
        _dbcontext.SaveChanges();
    }
}