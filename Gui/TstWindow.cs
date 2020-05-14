using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Gui
{
    class TstWindow : ProgramWindow
    {

        public TstWindow(char chr):base(chr) { 
            
        }

        public override void Render() {
            Console.Clear();

            base.Render();

            ShowMenuTextBlock();
            Console.ReadKey();
        }
    }
}
