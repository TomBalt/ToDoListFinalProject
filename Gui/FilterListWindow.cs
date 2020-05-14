using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BackEnd;
using System.Linq;

namespace ToDoList.Gui
{
    class FilterListWindow : SortListWindow
    {
        int priorityValue = 0;
        TaskStatus statusValue = TaskStatus.Active;
        public FilterListWindow(List<ToDoTask> toDoTaskList, char ch) : base(toDoTaskList, ch)
        {
            

            //  titleTextBlock = new TextBlock(base.Width - 40 , 2, 40, new List<String> { "N - add new task.", "C - change priority.", "D - task is done.", "S - sort by priority.", "F - filter by priority.", "Q - Quit." });

        }
        public override void ShowMenuTextBlock()
        {
            TextBlock titleTextBlock = new TextBlock(base.Width - 40, 2, 40, new List<String> { "** Welcome To FILTER MENU ***", "P - filter by priority.", "S - filter by status.", "R - Reset filters.", "Q - Quit.","======================", $"Priority Value: {priorityValue}", $"Status Value: {statusValue}" });
            titleTextBlock.Render();
        }
        public override void readButtonPress()
        {
            bool haveNotMadeAChoice = false;

            do
            {

                ConsoleKeyInfo pressedChar = Console.ReadKey();
                switch (pressedChar.Key)
                {

                    case ConsoleKey.P:
                        haveNotMadeAChoice = true;
                        priorityFilterValueBuilder();
                        filterByPriority(priorityValue);
                        break;
                    case ConsoleKey.S:
                        haveNotMadeAChoice = true;
                        statusFilterValueBuilder();
                        filterByStatus(statusValue);
                        break;
                    case ConsoleKey.R:
                        haveNotMadeAChoice = true;
                        listToModify.Clear();
                        toDoTaskList.ForEach(task => listToModify.Add(task));
                        break;

                    case ConsoleKey.Q:
                        listToModify.Clear();
                        priorityValue = 0;
                        haveNotMadeAChoice = true;
                        quitLoop = true;
                        break;
                }
            } while (haveNotMadeAChoice != true);
        }

        private void priorityFilterValueBuilder() {
            priorityValue++;
            if (priorityValue > 5) {
                priorityValue = 1;
            }
            
        }

        private void statusFilterValueBuilder()
        {
            int i = (int)statusValue;
            i++;
            if (i > 2)
            {
                statusValue = (TaskStatus)0;
            }
            else {
                statusValue = (TaskStatus)i;
            }

        }

        private void filterByPriority(int priorityValue)
        {

            var result = from el in toDoTaskList
                         where el.Priority == priorityValue
                         select el;

            listToModify = result.ToList();
        }

        private void filterByStatus(TaskStatus statusValue)
        {

            var result = from el in toDoTaskList
                         where el.Status == statusValue
                         select el;

            listToModify = result.ToList();
        }
    }
}
