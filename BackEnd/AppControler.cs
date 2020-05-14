using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Gui;


namespace ToDoList.BackEnd
{

    class AppControler
    {
        ProgramWindow programWindow;
        HandleMenuPress handleMenuPress;
        bool continueProgram = true;
       public TodoDataStorage todoDataStorage;  ////////////////////// 
        private bool haveNotMadeAChoice = true;
        SortListWindow sortListWindow;
        FilterListWindow filterListWindow;
        List<ToDoTask> todolist;
        OperationsWithFiles operationsWithFiles;
       

        public AppControler()
        {
            programWindow = new ProgramWindow();
            handleMenuPress = new HandleMenuPress();
            
            todoDataStorage = new TodoDataStorage();  /////////////////////////////
            
            sortListWindow = new SortListWindow(todoDataStorage.ToDoList, 'S');
            filterListWindow = new FilterListWindow(todoDataStorage.ToDoList, 'F');
        }

        public void StartProgram()
        {
            LoadDataFromFile(todoDataStorage);
            
            // todoDataStorage.LoadDataFromFile();
            // LoadData();

            todolist = todoDataStorage.ToDoList;
           //   todolist.Add(new ToDoTask(2,"new 2")); ///////////////////////////////////////
           //   todolist.Add(new ToDoTask(3,"new 3")); ///////////////////////////////////////
           //   todolist.Add(new ToDoTask(4,"new 4")); ///////////////////////////////////////
           //   todolist[1].Status = "Done";

              do
              {

                  programWindow.Render();
                  programWindow.PrintTaksList(todolist);
                  ControlButtonPress(todolist);
              } while (continueProgram);
              
            //save to file;
        }

        public List<ToDoTask> ControlButtonPress(List<ToDoTask> toDoTaskList)
        {
            handleMenuPress.SetCursorsCordinates(1,toDoTaskList);

            do
            {

                ConsoleKeyInfo pressedChar = Console.ReadKey();
                switch (pressedChar.Key)
                {
                    case ConsoleKey.N:
                        haveNotMadeAChoice = false;
                        handleMenuPress.AddNewTask(toDoTaskList);
                        SaveDataToFile(todoDataStorage);
                        break;
                    case ConsoleKey.C:
                        haveNotMadeAChoice = false;
                        handleMenuPress.ChangeTaskPriority(toDoTaskList);
                        SaveDataToFile(todoDataStorage);
                        break;
                    case ConsoleKey.D:
                        haveNotMadeAChoice = false;
                        handleMenuPress.MarkTaskAsDone(toDoTaskList);
                        //   operationsWithFiles.SaveDataToFile(todoDataStorage);
                        SaveDataToFile(todoDataStorage);
                        break;
                    case ConsoleKey.S:
                        haveNotMadeAChoice = false;
                        sortListWindow.Render();
                        break;
                    case ConsoleKey.F:
                        haveNotMadeAChoice = false;
                        filterListWindow.Render();
                        break;
                    case ConsoleKey.R:
                        haveNotMadeAChoice = false;
                        handleMenuPress.RemoveTask(toDoTaskList);
                        break;
                    case ConsoleKey.Q:
                        haveNotMadeAChoice = false;
                        continueProgram = false;
                        break;
                }
            } while (haveNotMadeAChoice);

            return toDoTaskList;
        }

        public void LoadDataFromFile(TodoDataStorage data)
        {
            if (File.Exists(data.DataFilePath))
            {
                using (StreamReader file = File.OpenText(data.DataFilePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    data.ToDoList = (List<ToDoTask>)serializer.Deserialize(file, typeof(List<ToDoTask>));
                }
            }

        }

        public void SaveDataToFile(TodoDataStorage data)
        {
            using (StreamWriter file = File.CreateText(data.DataFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data.ToDoList);
            }
        }
    }
}
