using System.ComponentModel.DataAnnotations;

public abstract class Person
{
    [Key] 
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre es demasiado largo.")]
    public string Name { get; set; }
    public int Age { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [RegularExpression(@"^\d{7,8}$", ErrorMessage = "El DNI debe tener entre 7 y 8 números válidos.")]
    public string Dni { get; set; }

    public Person() { }

    protected Person(string name, int age, string dni)
    {
        Name = name;
        Age = age;
        Dni = dni;
    }
}