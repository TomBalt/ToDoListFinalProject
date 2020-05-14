using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.BackEnd
{
    class ToDoTask
    {
        public TaskStatus Status { get; set; } = TaskStatus.Active;
        public int Priority { get; set; }
        public string TaskContent {get;set;}

        public DateTime DeadlineDate { get; set; } = Convert.ToDateTime("9999/01/01");

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
