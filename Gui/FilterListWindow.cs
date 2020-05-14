using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BackEnd;
using System.Linq;

namespace ToDoList.Gui
{
    class FilterListWindow : SortListWindow
    {
        public FilterListWindow(List<ToDoTask> toDoTaskList, char ch) : base(toDoTaskList, ch)
        {
            

            //  titleTextBlock = new TextBlock(base.Width - 40 , 2, 40, new List<String> { "N - add new task.", "C - change priority.", "D - task is done.", "S - sort by priority.", "F - filter by priority.", "Q - Quit." });

        }
        public override void ShowMenuTextBlock()
        {
            TextBlock titleTextBlock = new TextBlock(base.Width - 40, 2, 40, new List<String> { "** Welcome To FILTER MENU ***", "P - filter by priority.", "S - filter by status.", "R - Reset filters.", "Q - Quit." });
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
                        filterByPriority();
                        break;
                    case ConsoleKey.S:
                        haveNotMadeAChoice = true;
                        filterByStatus();
                        break;
                    case ConsoleKey.R:
                        haveNotMadeAChoice = true;
                        listToModify.Clear();
                        toDoTaskList.ForEach(task => listToModify.Add(task));
                        break;

                    case ConsoleKey.Q:
                        listToModify.Clear();
                        haveNotMadeAChoice = true;
                        quitLoop = true;
                        break;
                }
            } while (haveNotMadeAChoice != true);
        }


        private void filterByPriority()
        {

            var result = from el in toDoTaskList
                         where el.Priority == 5
                         select el;

            listToModify = result.ToList();
        }

        private void filterByStatus()
        {

            var result = from el in toDoTaskList
                         where el.Status == "Done"
                         select el;

            listToModify = result.ToList();
        }
    }
}
