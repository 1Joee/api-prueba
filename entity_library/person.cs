public abstract class Person
{
    public string Name {get; set;}
    public int Age {get; set;}
    public string Dni {get; set;}

    protected Person (string name, int age, string dni)
    {
        Name = name;
        Age = age;
        Dni = dni;
    }
    public override string ToString () => $"Nombre: {Name}, Edad: {Age}, Dni: {Dni}"; 
}