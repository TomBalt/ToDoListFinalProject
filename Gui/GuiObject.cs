using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Gui
{
    abstract class GuiObject
    {
        protected int X;
        protected int Y;
        protected int Width;
        protected int Height;

        public GuiObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        abstract public void Render();
    }
}
