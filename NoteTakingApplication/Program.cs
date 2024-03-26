using NoteTakingApplication.Data;
using NoteTakingApplication.Views;
using NoteTakingApplication.OutputTexts;
using System;
using System.Text.Json;
using Newtonsoft.Json;
using NoteTakingApplication.Operations;

namespace NoteTakingApplication;


class Program
{
    static void Main(string[] args)
    {

        Users users = new Users();



        MainMenu();

        void UserNoteOperations(int userid, User NoteUser)
        {
            Console.WriteLine();

            
            Console.WriteLine(CommonOutputText.NoteInstructions());

            string NewNoteInstructionDecision = Console.ReadLine();

            int NoteToEdit = 0;

            if (!string.IsNullOrWhiteSpace(NewNoteInstructionDecision))
            {
                bool editAddDecision = int.TryParse(NewNoteInstructionDecision, out int editNoteDecision);

                switch (editAddDecision)
                {
                    case true:
                        //Console.WriteLine("Dear User,\nUpdate Note coming soon.\nClick Enter to proceed.");
                        NoteToEdit = editNoteDecision;

                        EditNote(userid, NoteToEdit);

                        Console.ReadKey();

                        Log log = new Log(userid, $"User Note({editNoteDecision}) Update");
                        LogAction(log);

                        UserMenu(userid, NoteUser);
                        break;

                    case false:

                        if (NewNoteInstructionDecision.ToUpper() == "A")
                        {
                            //AddNote(userid, NoteUser, notes);
                            Note notes = new Note();
                            NoteContents noteContents = NoteTakingGeneralOperation.NoteContentsView(notes);
                            RegisterNewNote(noteContents, userid); 

                            Log userLog = NoteTakingGeneralOperation.LogToHistory(userid, "User Note Creation");
                            LogAction(userLog);
                            Console.ReadKey();
                            //User desiredUser = users.GetUser(userid);
                            //noteContents.RunNoteContentsViews(userid);
                            UserMenu(userid, NoteUser);

                        }
                           
                        else if (NewNoteInstructionDecision.ToUpper() == "Y")
                        {
                            LogOut(userid, NoteUser);
                        }

                        else if (NewNoteInstructionDecision.ToUpper() == "D")
                        {
                            DeleteNote(userid);
                            Log userLog = NoteTakingGeneralOperation.LogToHistory(userid, "User Note Delete");
                            LogAction(userLog);
                            //Console.WriteLine("Note Deleted!! Click Enter to proceed.");
                            Console.ReadKey();
                            UserMenu(userid, NoteUser);
                        }
    
                        else 
                        {
                            Console.WriteLine("Invalid input!!");
                            Console.ReadKey(); Console.Clear();
                            UserMenu(userid, NoteUser);
                        }
                            
                        break;
                }
                
            }
            
            Console.WriteLine("Kindly enter a value."); Console.ReadKey();
        }

        void LogAction(Log log)
        {

            string LogFilePath = @"";

            List<Log> logs = new List<Log>();

            logs = JsonConvert.DeserializeObject<List<Log>>(File.ReadAllText(LogFilePath));



            if (logs.Count == 0)
            {
                string logString = JsonConvert.SerializeObject(log, Formatting.Indented);
                File.WriteAllText(LogFilePath, logString);
            }
            else if (logs.Count > 0)
            {

                logs.Add(log);

                string allLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);

                File.WriteAllText(LogFilePath, allLogs);
            }
        } 

        void GetUserNewNote(int NoteUserId)
        {
            NoteContents AllUserNote = new NoteContents();
            AllUserNote.RunNoteContentsViews(NoteUserId); 
        }

        void RegisterNewNote(NoteContents noteContents, int userid)
        {
            Note notes = new Note();
            CreateNewNote createNewNote = NoteTakingGeneralOperation.CreateNewNoteView(notes);
            Console.WriteLine();

            createNewNote.RunNoteCreationOperation(userid);
            noteContents.RunNoteContentsViews(userid);
        }

        void Register(UsersContent userscontent)
        {
            CreateNewUser userCreateView = NoteTakingGeneralOperation.CreateUserView(users);
            Console.WriteLine();

            User CreatedUser = userCreateView.RunCreateOperation();
            //userscontent.RunUsersContentView();

            string CreatedUserJson = JsonConvert.SerializeObject(CreatedUser);

            string dirPath = @$"";
            string filePath = Path.Combine(dirPath, $"{CreatedUser.userId}.json");

            //Console.WriteLine($"Your user will be created to {filePath}");

            Console.WriteLine(CreatedUser.GetBasicUserInformation());

            File.WriteAllText(filePath, CreatedUserJson);
            Log userLog = NoteTakingGeneralOperation.LogToHistory(CreatedUser.userId, "User Register");

            LogAction(userLog);

        }

        string RunEditing(string UserNote)
        {

            string editedNote = UserNote;
            Console.Write(editedNote);

            Console.SetCursorPosition(editedNote.Length, Console.CursorTop);

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                else if (consoleKeyInfo.Key == ConsoleKey.Backspace)
                {
                    if (editedNote.Length > 0)
                    {
                        editedNote = editedNote.Remove(editedNote.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    editedNote += consoleKeyInfo.KeyChar;
                    Console.Write(consoleKeyInfo.KeyChar);
                }
            }

            return editedNote;
        }

        void DeleteNote(int userid)
        {
            Note note = new Note();
            NoteContents AllNote = new NoteContents();
            List<Note> Notes = new List<Note>();

            Notes = AllNote.UserNotes(userid);

            Console.Write("Enter id of note you wish to delete: ");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Invalid Input!!");
                return;
            }

            if (!int.TryParse(id, out int Id))
            {
                Console.WriteLine("Kindly input a valid number.");
                return;
            }

            try
            {
                Note NoteToDelete = Notes[Id - 1];
                Console.WriteLine($"Please press the [Y] key to save the record to the system or any other key to cancel.\n");
                string SaveDecision = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(SaveDecision))
                {
                    Console.WriteLine("Input required");
                    return;
                }

                else
                {
                    if (SaveDecision == "Y")
                    {
                        Notes.Remove(NoteToDelete);

                        CreateNewNote createNewNote = NoteTakingGeneralOperation.CreateNewNoteView(note);

                        createNewNote.DeleteNote(userid, Notes);
                        Console.WriteLine();
                    }

                    else if (SaveDecision != "Y")
                    {
                        Console.WriteLine("Your note is not deleted.");
                        return;
                    }
                }



            }
            catch (Exception e)
            {
                Console.WriteLine($"Error deleting note: {e.Message}");
                return;
            }

        }

        void EditNote(int userid, int id)
        {
            Note note = new Note();
            NoteContents AllNote = new NoteContents();
            List<Note> Notes = new List<Note>();

            Notes = AllNote.UserNotes(userid);

            try
            {

                Note editNote = Notes[id - 1];

                string NewNote = RunEditing(editNote.usernotes.ToString());

                Console.WriteLine($"\n{CommonOutputText.SaveDetailsMessage()}");
                string SaveDecision = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(SaveDecision))
                {
                    Console.WriteLine("Input required");
                    return;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(SaveDecision) && SaveDecision.ToUpper() != "S")
                    {
                        Console.WriteLine("Your edit is not saved.");
                        return;
                    }

                    else if (!string.IsNullOrWhiteSpace(SaveDecision) && SaveDecision.ToUpper() == "S")
                    {
                        editNote.usernotes = NewNote;

                        Notes[id - 1] = editNote;

                        CreateNewNote createNewNote = NoteTakingGeneralOperation.CreateNewNoteView(note);

                        createNewNote.UpdateNote(userid, Notes);
                    }

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error Occurred: {ex.Message}");
                return;
            }
        }

        void LogOut(int userid, User user)
        {
            Console.Clear();
            Log userLog = NoteTakingGeneralOperation.LogToHistory(userid, "User Log Out");

            LogAction(userLog);

            
            Console.WriteLine($"User: {userid} is Logged out successfully.\nClick Enter to go back to Main Menu.");
            Console.ReadKey();
            MainMenu();

        }

        void LoginUser()
        {
            Console.WriteLine("Enter your Unique userid: ");
            int _userid = int.Parse(Console.ReadLine());

            string dirPath = @"";
            string filePath = Path.Combine(dirPath, $"{_userid.ToString()}.json");

            if (File.Exists(filePath))
            {
                User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(filePath));

                Log userLog = NoteTakingGeneralOperation.LogToHistory(_userid, "User Log In");
                LogAction(userLog);



                UserMenu(_userid, user);
               
            }
            else
            {
                Console.WriteLine(CommonOutputText.GetUserNotFoundMessage(_userid));
                Console.ReadKey();
                MainMenu();
            }
        }

        void UserMenu(int _userid, User user)
        {
            Console.Clear();
            Console.WriteLine(user.GetBasicUserInformation());
            Console.WriteLine();
            Console.WriteLine($"Below are notes created by {user.userName}:");

            GetUserNewNote(_userid);

            Console.WriteLine();
            UserNoteOperations(_userid, user);
            LogOut(_userid, user);
            
            
        }

        void MainMenu()
        {
            Console.Clear();
            
            UsersContent userscontent = NoteTakingGeneralOperation.GetUsersContentView();

            Console.WriteLine(CommonOutputText.GetApplicationHeading());
            Console.WriteLine();

            Console.WriteLine(CommonOutputText.GetInstructions());

            int instructionKey = int.Parse(Console.ReadLine());

            if (!string.IsNullOrWhiteSpace(instructionKey.ToString()))
            {
                switch (instructionKey)
                {

                    case 1:

                        Console.Clear();

                        LoginUser();

                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();

                        Register(userscontent);

                        Console.ReadKey();

                        MainMenu();
                        break;

                    default:
                        MainMenu();
                        break;
                }
            }

            else if (!string.IsNullOrWhiteSpace(instructionKey.ToString()))
                Console.WriteLine("Input required!!");
                return;
            //Environment.Exit();
                
        }

        Console.ReadKey();
    }

    
}
