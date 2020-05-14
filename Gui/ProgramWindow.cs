using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BackEnd;
using ConsoleTables;

namespace ToDoList.Gui
{
    class ProgramWindow : Window
    {

        public ProgramWindow(char chr = 'Z') : base(0, 0, 120, 30, chr)
        {
           
        }

        public override void Render() {
            Console.Clear();

            base.Render();

            ShowMenuTextBlock();
        }

        public virtual void ShowMenuTextBlock() {
            TextBlock titleTextBlock = new TextBlock(base.Width - 40, 2, 40, new List<String> { 
                "** Welcome To MAIN MENU ***",
                "N - add new task.", 
                "C - change priority.", 
                "D - task is done.", 
                "S - sort tasks.", 
                "F - filter tasks.", 
                "R - REMOVE TASK!", 
                "Q - Quit." });
            titleTextBlock.Render();
        }

        public void PrintTaksList(List<ToDoTask> toDoList) {
            if (toDoList != null)
            {

                var table = new ConsoleTable("NR", "Deadline", "Status", "Priority", "Content");
                int taskIndex = 0;
                foreach (ToDoTask toDoTask in toDoList)
                {
                    string deadline = toDoTask.DeadlineDate.ToString("yyyy-MM-dd");
                    string status = Convert.ToString(toDoTask.Status);
                    string pr = Convert.ToString(toDoTask.Priority);
                    string ct = toDoTask.TaskContent;
                    table.AddRow(taskIndex, deadline, status, pr,ct);
                    taskIndex++;
                }
                Console.SetCursorPosition(1, 1);
                table.Write(Format.Alternative);
                
            }
        }
    }
}
