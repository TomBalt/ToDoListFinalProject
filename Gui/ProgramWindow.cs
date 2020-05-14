using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BackEnd;

namespace ToDoList.Gui
{
    class ProgramWindow : Window
    {
        //private TextBlock titleTextBlock;

        public ProgramWindow(char chr = 'Z') : base(0, 0, 120, 30, chr)
        {
            

        //  titleTextBlock = new TextBlock(base.Width - 40 , 2, 40, new List<String> { "N - add new task.", "C - change priority.", "D - task is done.", "S - sort by priority.", "F - filter by priority.", "Q - Quit." });

        }

        public override void Render() {
            Console.Clear();

            base.Render();

            ShowMenuTextBlock();
        }

        public virtual void ShowMenuTextBlock() {
            TextBlock titleTextBlock = new TextBlock(base.Width - 40, 2, 40, new List<String> { "** Welcome To MAIN MENU ***", "N - add new task.", "C - change priority.", "D - task is done.", "S - sort by priority.", "F - filter by priority.", "R - REMOVE TASK", "Q - Quit." });
            titleTextBlock.Render();
        }

        public void PrintTaksList(List<ToDoTask> toDoList) {
            if (toDoList != null)
            {
                int i = 0;
                int z = 0;
                foreach (ToDoTask toDoTask in toDoList)
                {
                    i++;
                    
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine("TaskNR: " + z + " TASK: " + Convert.ToString(toDoTask.Status) + " PR: " + Convert.ToString(toDoTask.Priority) + " Content:  " + toDoTask.TaskContent);
                    z++;
                }
            }
        }
    }
}
