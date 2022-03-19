using System.Data;
using System.Reflection;

public static class Database
{
#pragma warning disable CS8602
    public static void PrintMenu()
    {
        while (true)
        {
            Clear();
            Write($"\n\t\t\t\t\t\t* ((\tLabb4 - API\t)) * \n\n\n" +
                "  [1] Register new person\n\n" +
                "  [2] Add an interest / job\n\n" +
                "  [3] Add a link\n\n" +
                "  [4] Exit \n\n\n" +
                "   \t-Var god och välj:  ");
            int.TryParse(ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    Clear();
                    RegisterNewPersonInput();
                    Redirecting();
                    break;
                case 2:
                    Clear();
                    AddInterestInput();
                    Redirecting();
                    break;
                case 3:
                    Clear();
                    AddLinkInput();
                    Redirecting();
                    break;
                case 4:
                    Clear();
                    WriteLine("\n\n\n\n\t\tHave a wonderful day :-)");
                    Thread.Sleep(1800);
                    return;
                default:
                    WriteLine("\t\tInvalid input!   " +
                    "Please choose from 1 - 4\n");
                    ReadKey();
                    break;
            }
        }
    }

    private static void Redirecting()
    {
        Write("\n\n\n\t\tTryck 'Enter' för att återkomma till menyn igen");
        ReadLine();
    }

    private static void RegisterNewPersonInput()
    {
        Write("\n\n\t\tRegister a new person\n");
        string firstName = string.Empty;
        string lastName = string.Empty;
        int age = 0;
        int phone = 0;
        string city = string.Empty;
        string email = string.Empty;

        while (firstName == "" || firstName.Length < 2 || firstName.Any(char.IsDigit))
        {
            Write("\n\n\tType in the first name: ");
            firstName = ReadLine().Trim();
        }
        while (lastName == "" || lastName.Length < 2 || lastName.Any(char.IsDigit))
        {
            Write("\n\n\tType in the last name: ");
            lastName = ReadLine().Trim();
        }
        while (age <= 9 || age > 80 )
        {
            Write("\n\n\tType in the age: ");
            int.TryParse(ReadLine(), out age);
        }
        while (phone.ToString().Length > 19 || phone.ToString().Length < 9)
        {
            Write("\n\n\tType in the phone number (Min 10-digits):  ");
            int.TryParse(ReadLine(), out phone);
        }
        while (city == "" || city.Length < 1)
        {
            Write("\n\n\tType in the city:  ");
            city = ReadLine().Trim();
        }

        int num = Random.Shared.Next(0, 101);
        email = $"{firstName.ToLower()}{num}.{lastName.ToLower()}@{city}.com";
        AddPerson(firstName, lastName, age, phone, city, email);
    }

    private static void AddPerson(string firstName, string lastName, int age,
        int phone, string city, string email)
    {
        try
        {
            using PersonDbContext context = new PersonDbContext();
            Person person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Phone = phone.ToString(),
                City = city,
                Email = email
            };
            context.Persons.Add(person);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            WriteLine(e.Message);
        }
    }

    private static (int personIdCount, int interestIdCount) GetAvailablePersonId()
    {
        using PersonDbContext context = new PersonDbContext();
        int countPersonId = (from id in context.Persons select id).Count();
        int countInterestId = (from id in context.Interests select id).Count();
        return (countPersonId, countInterestId);
    }

    private static void AddInterestInput()
    {
        Write("\n\n\t\tAdd an interest\n");
        string title = string.Empty;
        string description = string.Empty;
        int personId = 0;
        (int personIdCount, _) = GetAvailablePersonId();


        while (title == "" || title.Length < 2)
        {
            Write("\n\n\tType in a title for the interest / job: ");
            title = ReadLine().Trim();
        }
        while (description == "" || description.Length < 4)
        {
            Write("\n\n\tType in a description: ");
            description = ReadLine().Trim();
        }
        while (personId > personIdCount || personId <= 0)
        {
            Write("\n\n\tEnter [PersonId] for the person you want to add the" +
                " interest for\n\n\t    Please double check the [PersonId] before you type in: ");
            int.TryParse(ReadLine(), out personId);
            Clear();
        }

        AddInterest(title, description, personId);
    }

    private async static void AddInterest(string title, string description, int personId)
    {
        try
        {
            using PersonDbContext context = new PersonDbContext();
            Interest interest = new Interest()
            {
                Title = title,
                Description = description,
                PersonId = personId
            };
            await context.Interests.AddAsync(interest);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            WriteLine(e.Message);
        }
    }

    private static void AddLinkInput()
    {
        Write("\n\n\t\tAdd a link\n");
        string url = string.Empty;
        int personId = 0;
        int interestId = 0;
        (int personIdCount, int interestIdCount) = GetAvailablePersonId();

        while (url == "" || url.Length < 4)
        {
            Write("\n\n\tType in a URL:  ");
            url = ReadLine().Trim();
        }
        while (personId > personIdCount || personId <= 0)
        {
            Write("\n\n\tEnter [PersonId] for the person you want to add the" +
                " interest for\n\n\t    Please double check the [PersonId] before you type in: ");
            int.TryParse(ReadLine(), out personId);
            Clear();
        }
        while (interestId > interestIdCount || interestId <= 0)
        {
            Write("\n\n\tEnter [InterestId] for the interest you want to add the" +
                " link for\n\n\t    Please double check the [InterestId] before you type in: ");
            int.TryParse(ReadLine(), out interestId);
            Clear();
        }

        AddLink(url, personId, interestId);
    }

    private async static void AddLink(string url, int personId, int interestId)
    {
        try
        {
            using PersonDbContext context = new PersonDbContext();
            Link interest = new Link()
            {
                Url = url,
                PersonId = personId,
                InterestId = interestId
            };
            await context.Links.AddAsync(interest);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            WriteLine(e.Message);
        }
    }

}


