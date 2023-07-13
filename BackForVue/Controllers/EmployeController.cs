using Microsoft.AspNetCore.Mvc;
using BackForVue.Data;
using BackForVue.Models;
using BackForVue.Repositories;

#nullable disable

namespace BackForVue.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeController: ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IEmployeRepository _empRepository;

    public EmployeController(AppDbContext dbContext, IEmployeRepository empRepository)
    {
        _dbContext = dbContext;
        _empRepository = empRepository; 
    }

    [HttpPost("CreateEmploye")]
    public IActionResult CreateEmploye(Employe employeDto)
    {
        try {
            Employe emp = employeDto;
            var createEmploye = _empRepository.CreateEmp(emp);
            return Created("employe cree",createEmploye);
        } catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("GetAllEmploye")]
    public IActionResult GetAllEmploye()
    {
        try {
            var allEmp = _empRepository.GetAllEmp();
            return Ok(allEmp);
        } catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut("UpdateEmploye")]
    public IActionResult UpdateEmploye(int numEmp, Employe newEmploye)
    {
        try {
        //Get the one to update
        var empToUpdate = _dbContext.Employes.FirstOrDefault(r => r.NumEmp == numEmp);
        if(empToUpdate == null)
        {
            return NoContent();
        }
        //Update it
        var update = _empRepository.UpdateEmp(empToUpdate, newEmploye);
        return Ok(update);
        } catch(Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpDelete("DeleteEmploye")]
    public IActionResult DeleteEmploye(int numEmp)
    {
        var empToDelete = _dbContext.Employes.FirstOrDefault(r => r.NumEmp == numEmp);
        if(empToDelete == null)
        {
            return NoContent();
        }
        try {
            _empRepository.DeleteEmp(numEmp);
            return Ok("L'employé a été supprimer");
        } catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
}
