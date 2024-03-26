using System;
using NoteTakingApplication.Data;
using NoteTakingApplication.Views;
using NoteTakingApplication.OutputTexts;
using System.Text;

namespace NoteTakingApplication.Operations;

public class CreateNewUser
{
    private Users _Users;

    public CreateNewUser(Users _users)
    {
        _Users = _users;
    }

    public User RunCreateOperation()
    {
                
        Console.WriteLine(CommonOutputText.GetCreateNewUserHeading());

        Console.WriteLine();

        Console.Write("Enter the desired Username: ");

        string username = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine();
            Console.WriteLine(CommonOutputText.SaveDetailsMessage());


            string userDecision = Console.ReadLine().ToUpper();

            if (userDecision == "S")
            {
                //_Users.AddUser(NoteTakingGeneralOperation.CreateUser(username));

                User regUser = NoteTakingGeneralOperation.CreateUser(username);
                //_Users.AddUser(regUser);

                return regUser;

            }

            return RunCreateOperation();
        }
        return RunCreateOperation();

    }


}