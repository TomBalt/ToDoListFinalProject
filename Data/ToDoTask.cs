using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.BackEnd
{
    class ToDoTask
    {
        public TaskStatus Status { get; set; } = TaskStatus.Active; //pakeisti i enumeratoriu
        public int Priority { get; set; }
        public string TaskContent {get;set;}
        
        //data and time, tik dienas ir sukurti deadline

        public ToDoTask(int priority, string taskContent) {
            Priority = priority;
            TaskContent = taskContent;
        }

        
    }
    enum TaskStatus { 
        
        Active = 0,
        Done,
        Expired
    }
}
