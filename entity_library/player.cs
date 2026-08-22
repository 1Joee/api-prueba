using System.Collections.Generic;
public class Player : Person
{
   public int Numero {get; set;}
   public List<Team> Teams {get; set;} = new List<Team>();

   public Player (string name, int age, string dni, int numero) : base(name, age, dni)
   {
      Numero = numero;
   }
}   