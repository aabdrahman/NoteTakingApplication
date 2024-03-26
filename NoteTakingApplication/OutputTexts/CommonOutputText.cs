using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTakingApplication.OutputTexts;

public class CommonOutputText
{
    public static string GetColumnHeading()
    {
        string ID = "ID";
        string CreatedDate = "Created Date";
        string Content = "Content";

        string heading = $"{ID.PadRight(4)}\t{CreatedDate.PadRight(20)}\t{Content.PadRight(30)}\n";
        heading += $"{new string('_', 4)}\t{new string('_', 20)}\t{new string('_', 30)}\n";

        return heading;

    }

    private static string GetUnderlineForHeading(string heading)
    {
        return new string('_', heading.Length - 1);
    }

    public static string GetCreateNewUserHeading()
    {
        string baseHeading = "Register a new user: \n";
        string underline = GetUnderlineForHeading(baseHeading);

        return $"{baseHeading}{underline}\n\n";
    }

    public static string GetUserNotFoundMessage(int id)
    {
        return $"Could not find User with Id({id}). Please press any key to return to the main view...";
    }

    public static string GetEditNote() 
    {
        string message = "Kindly enter the Id of the Note you wish to edit and press enter to proceed";
        return message;
    }

    public static string GetInstructions()
    {
        return "What would you like to do?\n1. Login\n2. Register\nPlease press any key to return to the main view...";

    }

    public static string GetApplicationHeading()
    {
        string heading = "Welcome to Note Taking App\n";

        string underline = GetUnderlineForHeading(heading);

        return $"{heading}{underline}\n\n";
    }

    public static string NoteInstructions()
    {

        string logoutText = "Enter [Y] to log out your profile.";
        string heading = $"Enter [A] to add a new note.\n{logoutText.ToString().PadRight(20)}\nEnter [D] to delete Note.\nTo edit an existing note, enter the Id of the note. ";
        return heading;
    }

    public static string AddEmptyNoteMessage()
    {
        string heading = "Are you sure you want to create an empty note? Click enter to proceed.";
        return heading;

    }
    public static string SaveDetailsMessage()
    {
        string heading = "Please press the [S] key to save the record to the system or any other key to cancel.\n";
        return heading;
    }
}

