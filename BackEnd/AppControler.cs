using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public TodoDataStorage todoDataStorage;
        private bool haveNotMadeAChoice = true;
        SortListWindow sortListWindow;
        FilterListWindow filterListWindow;
        List<ToDoTask> todolist;



        public AppControler()
        {
            programWindow = new ProgramWindow();
            handleMenuPress = new HandleMenuPress();
            todoDataStorage = new TodoDataStorage();
        }

        public void StartProgram()
        {
            LoadDataFromFile(todoDataStorage);
            todolist = todoDataStorage.ToDoList;
            sortListWindow = new SortListWindow(todolist, 'S');
            filterListWindow = new FilterListWindow(todolist, 'F');
            checkIfTaskNotExpired(todolist);
            do
            {

                programWindow.Render();
                programWindow.PrintTaksList(todolist);
                ControlButtonPress(todolist);
            } while (continueProgram);

        }

        public List<ToDoTask> ControlButtonPress(List<ToDoTask> toDoTaskList)
        {
            handleMenuPress.SetCursorsCordinates(1, toDoTaskList.Count);

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

        private void LoadDataFromFile(TodoDataStorage data)
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

        private void SaveDataToFile(TodoDataStorage data)
        {
            using (StreamWriter file = File.CreateText(data.DataFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data.ToDoList);
            }
        }

        private void checkIfTaskNotExpired(List<ToDoTask> toDoTasks)
        {

            DateTime localDate = DateTime.Now;

            foreach (ToDoTask task in toDoTasks)
            {

                if (task.DeadlineDate < localDate)
                {
                    task.Status = TaskStatus.Expired;
                }
            }
        }
    }
}
