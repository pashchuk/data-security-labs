using System;
using System.IO;
using Newtonsoft.Json;

namespace lab1.Models
{
    public class FileCapchaRepository : ICapchaRepository
    {
        private string _contentFilePath;
        public FileCapchaRepository(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            _contentFilePath = filePath;
        }

        public int FunctionA => JsonConvert.DeserializeObject<JsonData>(
            File.ReadAllText(_contentFilePath)).FunctionInfo.FunctionA;

        public int FunctionB => JsonConvert.DeserializeObject<JsonData>(
            File.ReadAllText(_contentFilePath)).FunctionInfo.FunctionB;

        public int CurrentX
        {
            get
            {
                return JsonConvert.DeserializeObject<JsonData>(
                    File.ReadAllText(_contentFilePath)).FunctionInfo.CurrentX;
            }
            set
            {
                var data = JsonConvert.DeserializeObject<JsonData>(
                    File.ReadAllText(_contentFilePath));
                data.FunctionInfo.CurrentX = value;
                var str = JsonConvert.SerializeObject(data);
                File.WriteAllText(_contentFilePath, str);
            }
        }
    }
}