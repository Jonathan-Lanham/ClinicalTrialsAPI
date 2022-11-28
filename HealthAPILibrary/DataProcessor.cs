using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAPILibrary
{
    public class DataProcessor
    {   
        public void Process()
        {
            HealthProcessorI2.LoadHealthInformation();

            HealthProcessorI2.allContents();

            string filePath = @"..\..\..\test.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                var healthInfo = File.Create(filePath);
                healthInfo.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            List<string> contents = new List<string>();

            //foreach (var item in AllContents)
            foreach (var item in AllContents.Select(AllContents => AllContents.BriefTitle))
            {
                Console.WriteLine(item[item.Length - 1]);
                contents.Append<string>(item[item.Length - 1]);
            }

            foreach (var item in AllContents.Select(AllContents => AllContents.BriefSummary))
            {
                Console.WriteLine(item[item.Length - 1]);
                contents.Append<string>(item[item.Length - 1]);
            }

            foreach (var item in AllContents.Select(AllContents => AllContents.NctId))
            {
                Console.WriteLine(item[item.Length - 1]);
                contents.Append<string>(item[item.Length - 1]);
            }

            foreach (var item in AllContents.Select(AllContents => AllContents.Condition))
            {
                Console.WriteLine(item[item.Length - 1]);
                contents.Append<string>(item[item.Length - 1]);
            }

            foreach (var content in contents)
            {
                Console.WriteLine(content);
                File.WriteAllText(filePath, content);
            }
        }
    }
}
