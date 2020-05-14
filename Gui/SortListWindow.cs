using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BackEnd;
using System.Linq;

namespace ToDoList.Gui
{
    class SortListWindow : ProgramWindow
    {
       
        protected List<ToDoTask> listToModify = new List<ToDoTask>();
        protected List<ToDoTask> toDoTaskList;
        protected bool quitLoop = false;

        public SortListWindow(List<ToDoTask> toDoTaskList, char chr) : base(chr)
        {
            this.toDoTaskList = toDoTaskList;
            //char chr = 'S';
       }

        public override void ShowMenuTextBlock()
        {
            TextBlock titleTextBlock = new TextBlock(base.Width - 40, 2, 40, new List<String> {"** Welcome To SORT MENU ***", "P - sort by priority.", "S - sort by status.", "Q - Quit." });
            titleTextBlock.Render();
        }

        public override void Render()
        {
            toDoTaskList.ForEach(task => listToModify.Add(task));
            
            do
            {
                Console.Clear();
                base.Render();
                ShowMenuTextBlock();
                
                PrintTaksList(listToModify);
                readButtonPress();
            } while (quitLoop != true);
            quitLoop = false;
        }

        
        public virtual void readButtonPress()
        {
            bool haveNotMadeAChoice = false;
          
            do
            {

                ConsoleKeyInfo pressedChar = Console.ReadKey();
                switch (pressedChar.Key)
                {
            
                    case ConsoleKey.P:
                        haveNotMadeAChoice = true;
                        sortByPriority();
                        break;
                    case ConsoleKey.S:
                        haveNotMadeAChoice = true;
                        sortByStatus();
                        break;

                    case ConsoleKey.Q:
                        listToModify.Clear();
                        haveNotMadeAChoice = true;
                        quitLoop = true;
                        break;
                }
            } while (haveNotMadeAChoice != true);
          
        }

        private void sortByPriority()
        {
         
            var result = from el in toDoTaskList
                         orderby el.Priority
                         select el;

           listToModify = result.ToList();
        }

        private void sortByStatus()
        {

            var result = from el in toDoTaskList
                         orderby el.Status
                         select el;

            listToModify = result.ToList();
        }


        

      
    }
}
