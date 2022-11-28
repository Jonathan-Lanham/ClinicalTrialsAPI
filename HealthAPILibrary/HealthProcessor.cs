using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HealthAPILibrary
{
    public class HealthProcessor
    {
        public static async Task<List<HealthModel>> LoadHealthInformation()
        {

           /* using (var webClient = new WebClient())
            {
                string rawJSON =  webClient.DownloadString("https://www.clinicaltrials.gov/api/query/study_fields?expr=heart+attack&fields=NCTId%2CBriefTitle%2CCondition%2CBriefSummary&min_rnk=1&max_rnk=&fmt=json");

                HealthStudyFieldsResponseModel healthStudyFieldsResponseModel = JsonConvert.DeserializeObject<HealthStudyFieldsResponseModel>(rawJSON);

                Console.WriteLine(healthStudyFieldsResponseModel.StudyFieldsResponse.StudyFields.Count);

                return healthStudyFieldsResponseModel.StudyFieldsResponse.StudyFields;
            }*/

            string url = "https://www.clinicaltrials.gov/api/query/study_fields?expr=heart+attack&fields=NCTId%2CBriefTitle%2CCondition%2CBriefSummary&min_rnk=1&max_rnk=&fmt=json";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                    var webClient = new WebClient();
                string rawJSON = webClient.DownloadString(url);

                HealthStudyFieldsResponseModel result = JsonConvert.DeserializeObject<HealthStudyFieldsResponseModel>(rawJSON);

                //HealthStudyFieldsResponseModel result = await response.Content.ReadAsAsync<HealthStudyFieldsResponseModel>();

                Console.WriteLine(result.StudyFieldsResponse.StudyFields.Count);

                    private static List<HealthModel> allContents;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            /*string url = "";

            url = $"https://www.clinicaltrials.gov/api/query/study_fields?expr=cancer&fields=NCTId,BriefTitle,BriefSummary,Condition&min_rnk=1&max_rnk=&fmt=json";

            *//*(if (rank > 1)
            {
                url = $"https://www.clinicaltrials.gov/api/query/study_fields?expr=cancer&fields=NCTId,BriefTitle,BriefSummary,Condition&min_rnk={rank}&max_rnk={rank}&fmt=json";
            }
            else
            {
                url = $"https://www.clinicaltrials.gov/api/query/study_fields?expr=cancer&fields=NCTId,BriefTitle,BriefSummary,Condition&min_rnk=&max_rnk=&fmt=json";
            }*//*

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {                
                HealthStudyFieldsResponseModel result = await response.Content.ReadAsAsync<HealthStudyFieldsResponseModel>();

                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine(result.ToString());
                    

                    return result.StudyFieldsResponse.StudyFields;
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }*/
    }
}
