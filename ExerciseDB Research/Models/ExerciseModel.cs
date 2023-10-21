using System.Net.Http.Headers;

namespace ExerciseDB_Research.Models
{
    public class ExerciseModel
    {
        private readonly List<string> exerciseArea = new List<string> { "back", "cardio", "chest", "lower arms", "lower legs", "neck", "shoulders" };
        public List<object> input { get; set;}

        public List<string> getExerciseList()
        {
            return exerciseArea;
        }

        public async void updateResult(string execriseType)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://exercisedb.p.rapidapi.com/exercises/bodyPart/${execriseType}?limit=10"),
                Headers =
                {
                    { "X-RapidAPI-Key", "f69f2da5c1msh1331231abd4a573p1d8d45jsn4af60eda3f35"
                    },
                    { "X-RapidAPI-Host", "exercisedb.p.rapidapi.com"
                    },
                },
            };

            using (var response = await  client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.Write(body);
            }
        }
 
    }
}
