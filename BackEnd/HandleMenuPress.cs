using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.BackEnd
{
    class HandleMenuPress
    {

        public void ChangeTaskPriority(List<ToDoTask> toDoTaskList)
        {
            SetCursorsCordinates(1, toDoTaskList);
            int taskNr = getValidTaskNumber(toDoTaskList, "Enter task number which priority want to change: ");
            int priority = getValidPriorityNumber(toDoTaskList);
            toDoTaskList[taskNr].Priority = priority;
        }

        public void AddNewTask(List<ToDoTask> toDoTaskList)
        {

            SetCursorsCordinates(1, toDoTaskList);
            int priority = getValidPriorityNumber(toDoTaskList);

            Console.Write("Enter task description: ");
            string taskDescription = Console.ReadLine();
            toDoTaskList.Add(new ToDoTask(priority, taskDescription));
        }
        public void MarkTaskAsDone(List<ToDoTask> toDoTaskList)
        {
            SetCursorsCordinates(1, toDoTaskList);
            int taskNr = getValidTaskNumber(toDoTaskList, "Enter task number which should be set as Done: ");
            toDoTaskList[taskNr].Status = "Done";
        }
        public void RemoveTask(List<ToDoTask> toDoTaskList)
        {
            SetCursorsCordinates(1, toDoTaskList);
            int taskNr = getValidTaskNumber(toDoTaskList, "Enter task number which should be REMOVED: ");
            toDoTaskList.RemoveAt(taskNr);
        }


        public void SetCursorsCordinates(int y, List<ToDoTask> toDoTaskList, int x = 2)
        {
            int listLength = 1;
            if (toDoTaskList != null)
            {
                listLength = toDoTaskList.Count;
            }

            Console.SetCursorPosition(x, listLength + y);

        }

        private int getValidPriorityNumber(List<ToDoTask> toDoTaskList)
        {
            bool goodInput = false;
            int priority = 0;

            do
            {
               
                Console.Write("Enter task priority number: ");
                string priorityInput = Console.ReadLine();
                if (validatePriorityNumber(priorityInput))
                {
                    priority = Convert.ToInt32(priorityInput);
                    goodInput = true;
                };
            } while (goodInput == false);

            return priority;
        }



        private int getValidTaskNumber(List<ToDoTask> toDoTaskList, string msg)
        {
            bool goodInput = false;
            int taskNr = 0;

            do
            {
                Console.Write(msg);
                string Input = Console.ReadLine();
                if (validateTaskNumber(Input, toDoTaskList.Count - 1))
                {
                    taskNr = Convert.ToInt32(Input);
                    goodInput = true;
                };
            } while (goodInput == false);

            return taskNr;
        }

        private bool validateTaskNumber(string taskNumberInput, int max)
        {

            int InputInt;
            bool IsItAValidNumber = false;
            if (IsItANumber(taskNumberInput))
            {
                InputInt = Convert.ToInt32(taskNumberInput);
                IsItAValidNumber = IsANumberInArange(InputInt, 0, max);
            }
            return IsItAValidNumber;
        }

        private bool validatePriorityNumber(string priorityInput)
        {

            int InputInt;
            bool IsItAValidNumber = false;
            if (IsItANumber(priorityInput))
            {
                InputInt = Convert.ToInt32(priorityInput);
                IsItAValidNumber = IsANumberInArange(InputInt);
            }
            return IsItAValidNumber;
        }


        static bool IsANumberInArange(int IntNumber, int RangeMin = 1, int RangeMax = 5)
        {
            bool result = (IntNumber >= RangeMin && IntNumber <= RangeMax) ? true : false;
            if (result == false)
            {
                Console.WriteLine($"Input {IntNumber} is not a valid number, choose between {RangeMin} and {RangeMax} .");
            }
            return result;
        }

        static bool IsItANumber(string StrNumber)
        {
            bool ValidNumber = false;
            int StartingIndexNumber = 0;

            for (int i = StartingIndexNumber; i < StrNumber.Length; i++)
            {
                char c = StrNumber[i];
                for (int n = 0; n < 10; n++)
                {
                    char z = ConvertIntToProperChar(n);
                    if (c == z)
                    {
                        ValidNumber = true;
                        break;
                    }
                }
                if (ValidNumber == false)
                {
                    Console.WriteLine("Not a number: " + c);
                    break;
                }
            }
            return ValidNumber;
        }

        static char ConvertIntToProperChar(int symbol)
        {
            return Convert.ToChar(Convert.ToString(symbol));
        }

    }
}
