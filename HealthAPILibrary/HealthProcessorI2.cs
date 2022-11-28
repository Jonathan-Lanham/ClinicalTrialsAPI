using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HealthAPILibrary
{
    public class HealthProcessorI2
    {   
        public static List<HealthModel> allContents;

        public static List<HealthModel> AllContents { get => allContents; set => allContents = value; }

        public static async Task<List<HealthModel>> LoadHealthInformation(int rank = 1, string study = "")
        {
            string url = $"https://www.clinicaltrials.gov/api/query/study_fields?expr={study}&fields=NCTId%2CBriefTitle%2CCondition%2CBriefSummary&min_rnk={rank}&max_rnk={rank}&fmt=json";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var webClient = new WebClient();

                    string rawJSON = webClient.DownloadString(url);

                    HealthStudyFieldsResponseModel result = JsonConvert.DeserializeObject<HealthStudyFieldsResponseModel>(rawJSON);

                    AllContents = result.StudyFieldsResponse.StudyFields;

                    //Console.WriteLine(AllContents);

                    Process();

                    return AllContents;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static void Process()
        {
            string filePath = @"..\..\..\test.csv";

            List<string> contents = new List<string>();

            string[] list = contents.ToArray();

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

            //foreach (var item in AllContents)
            foreach (var item in AllContents.Select(AllContents => AllContents.BriefTitle))
            {
                contents.Add(item[list.Length]);
            }

            foreach (var item in AllContents.Select(AllContents => AllContents.BriefSummary))
            {
                contents.Add(item[list.Length]);
            }

            foreach (var item in AllContents.Select(AllContents => AllContents.NctId))
            {
                contents.Add(item[list.Length]);
            }

            foreach (var item in AllContents.Select(AllContents => AllContents.Condition))
            {
                contents.Add(item[list.Length]);
            }

            File.WriteAllLines(filePath, contents);
        }
    }
}
