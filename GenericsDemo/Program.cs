
Console.WriteLine($"Tests: {FizzBuzz("Tests")}");
Console.WriteLine($"123: {FizzBuzz(123)}");
Console.WriteLine($"True: {FizzBuzz(true)}");
Console.WriteLine($"PersonModel Héctor Sandoval: {FizzBuzz(new PersonModel { FirstName="Héctor",LastName="Sandoval"})}");
GenericHelper<PersonModel> peopleHelper=new GenericHelper<PersonModel>();
peopleHelper.CheckItemAndAdd(new PersonModel { FirstName = "Héctor", LastName = "Sandoval",HasError=true });
foreach (var item in peopleHelper.RejectedItems)
{
    Console.WriteLine($"{item.FirstName} {item.LastName} was Rejected");
}
static string FizzBuzz<T>(T item)
{
    string output = "";
    int itemLenght = item.ToString().Length;
    if (itemLenght % 3==0)
    {
        output += "Fizz";
    }
    if (itemLenght % 5 == 0)
    {
        output += "Buzz";
    }
    return output;
}

public class GenericHelper<T> where T:IErrorCheck
{
    public List<T> Items { get; set; }=new List<T>();
    public List<T> RejectedItems { get; set; } = new List<T>();

    public void CheckItemAndAdd(T item)
    {
        if (item.HasError==false)
        {
            Items.Add(item);
        }else
        {
            RejectedItems.Add(item);
        }
    }
}

public interface IErrorCheck
{
    public bool HasError { get; set; }
}

public class CarModel : IErrorCheck
{
    public string Manufacturer { get; set; }
    public int YearManufactured { get; set; }
    public bool HasError { get; set; }
}
public class PersonModel:IErrorCheck
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool HasError { get; set; }
}