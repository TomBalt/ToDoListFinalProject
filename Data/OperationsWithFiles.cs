using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ToDoList.BackEnd;
using ToDoList.Data;

namespace ToDoList.BackEnd
{
    class OperationsWithFiles
    {

        public void LoadDataFromFile(TodoDataStorage data)
        {
            if (File.Exists(data.DataFilePath))
            {
                using (StreamReader file = File.OpenText(data.DataFilePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    if ((List<ToDoTask>)serializer.Deserialize(file, typeof(List<ToDoTask>)) != null)
                    {
                        var test = (List<ToDoTask>)serializer.Deserialize(file, typeof(List<ToDoTask>));
                       data.ToDoList = (List<ToDoTask>)serializer.Deserialize(file, typeof(List<ToDoTask>));
                    }
                    
                }
            }

        }

        public void SaveDataToFile(ref TodoDataStorage data)
        {
            using (StreamWriter file = File.CreateText(data.DataFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data.ToDoList);
            }
        }
    }
}
