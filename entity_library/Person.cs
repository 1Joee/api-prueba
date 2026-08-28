using System.ComponentModel.DataAnnotations;
public class Person
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre es demasiado largo.")]
    public string Name { get; set; } 

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El apellido es demasiado largo.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [RegularExpression(@"^\d{7,8}$", ErrorMessage = "El DNI debe tener entre 7 y 8 números válidos.")]
    public string Dni { get; set; }
}
public abstract class Person
{
    public string Name {get; set;}
    public int Age {get; set;}
    public string Dni {get; set;}
    public Person () {}
    protected Person (string name, int age, string dni)
    {
        Name = name;
        Age = age;
        Dni = dni;
    }
    public override string ToString () => $"Nombre: {Name}, Edad: {Age}, Dni: {Dni}"; 
}