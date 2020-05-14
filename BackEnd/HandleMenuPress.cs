using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace ToDoList.BackEnd
{
    class HandleMenuPress
    {

        public void ChangeTaskPriority(List<ToDoTask> toDoTaskList)
        {
            SetCursorsCordinates(1, toDoTaskList.Count);
            int taskNr = getValidTaskNumber(toDoTaskList, "Enter task number which priority want to change: ");
            int priority = getValidPriorityNumber(toDoTaskList);
            toDoTaskList[taskNr].Priority = priority;
        }

        public void AddNewTask(List<ToDoTask> toDoTaskList)
        {
            DateTime deadlineDate;
            SetCursorsCordinates(1, toDoTaskList.Count);
            int priority = getValidPriorityNumber(toDoTaskList);

            Console.Write("Enter task description: ");
            string taskDescription = Console.ReadLine();

            ToDoTask newTask = new ToDoTask(priority, taskDescription);

            Console.Write("Set date for Deadline: Y/N ");
            if (getValidDeadlineChoiseAnswere())
            {

                deadlineDate = getDeadlineDate();
            }
            else
            {
                deadlineDate = Convert.ToDateTime("9999/01/01");
            }
            newTask.DeadlineDate = deadlineDate;
            toDoTaskList.Add(newTask);

        }
        public void MarkTaskAsDone(List<ToDoTask> toDoTaskList)
        {
            SetCursorsCordinates(1, toDoTaskList.Count);
            int taskNr = getValidTaskNumber(toDoTaskList, "Enter task number which should be set as Done: ");
            toDoTaskList[taskNr].Status = TaskStatus.Done;
        }
        public void RemoveTask(List<ToDoTask> toDoTaskList)
        {
            SetCursorsCordinates(1, toDoTaskList.Count);
            int taskNr = getValidTaskNumber(toDoTaskList, "Enter task number which should be REMOVED: ");
            toDoTaskList.RemoveAt(taskNr);
        }


        public void SetCursorsCordinates(int y,int listLength, int x = 2)
        {
          
            Console.SetCursorPosition(x, listLength * 2 + 4 + y);

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

        private DateTime getDeadlineDate()
        {
            bool goodInput = false;
            string input;
            CultureInfo culture = new CultureInfo("lt-LT");
            DateTime date = Convert.ToDateTime("9999.01.01", culture); 
            DateTime localDate = DateTime.Now;


            do
            {
                Console.WriteLine("Type deadline date in a format YYYY.MM.DD: ");
                input = Console.ReadLine();

                try
                {
                    date = Convert.ToDateTime(input, culture);

                    if (date > localDate)
                    {
                        goodInput = true;
                    }
                    else {
                        Console.WriteLine("You can't set date today or in a past....");
                    }
                }
                catch
                {
                    
                    Console.WriteLine($"Not valid input ${input}.");
                    
                }

            } while (goodInput == false);

            return date;
        }

        private bool getValidDeadlineChoiseAnswere()
        {
            bool goodInput = false;
            string input;
            do
            {
                input = Console.ReadLine().ToLower();
                if (input == "y" || input == "n")
                {
                    goodInput = true;
                };
            } while (goodInput == false);

            return input == "y" ? true : false;
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
