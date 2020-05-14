using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.BackEnd
{
    class ToDoTask
    {
        public string Status { get; set; } = "Active"; //pakeisti i enumeratoriu
        public int Priority { get; set; }
        public string TaskContent {get;set;}
        
        //data and time, tik dienas ir sukurti deadline

        public ToDoTask(int priority, string taskContent) {
            Priority = priority;
            TaskContent = taskContent;
        }

        
    }
}
