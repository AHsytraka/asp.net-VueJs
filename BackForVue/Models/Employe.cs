using System.ComponentModel.DataAnnotations;

namespace BackForVue.Models;

#nullable disable

public class Employe
{
    [Key]
    public int NumEmp {get; set;}

    [MaxLength(250)]
    [MinLength(2)]
    [Required]
    public string Nom {get; set;}
    public int Salaire {get; set; }
}