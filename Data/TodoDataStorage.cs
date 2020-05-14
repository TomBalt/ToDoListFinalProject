using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ToDoList.BackEnd;

namespace ToDoList.Data
{
    class TodoDataStorage
    {
        public List<ToDoTask> ToDoList { get; set; }
        public string DataFilePath { get; set; }

        public TodoDataStorage()
        {
            ToDoList = new List<ToDoTask>();
            DataFilePath = @"..\..\..\Data\SavedData.json";

        }
    }
}
