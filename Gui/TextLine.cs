using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Gui
{
    class TextLine : GuiObject
    {
        private string data;

        public TextLine(int x, int y, int width, string data) : base(x, y, width, 0)
        {
            this.data = data;
        }

        public override void Render()
        {
            Console.SetCursorPosition(X, Y);
            if (Width > data.Length)
            {
                int offset = (Width - data.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }

            Console.Write(data);
        }


        public void UpdateTextlineText(string newText)
        {
            data = newText;
        }
    }
}
