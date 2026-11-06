using System.ComponentModel.DataAnnotations;

public abstract class Person
{
    private int id = 0;
    private string name = "";
    private int age = 0;
    private string dni = "";

    [Key]
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre es demasiado largo.")]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [Range(1, 100, ErrorMessage = "La edad debe estar entre 1 y 100.")]
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [RegularExpression(@"^\d{7,8}$", ErrorMessage = "El DNI debe tener entre 7 y 8 números válidos.")]
    public string Dni
    {
        get { return dni; }
        set { dni = value; }
    }
}
