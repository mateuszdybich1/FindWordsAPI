using Microsoft.AspNetCore.Mvc;

namespace FindWordsAPI.Controllers
{
    [ApiController]
    public class MyController : ControllerBase
    {
        [Route("/getWords/{word}")]
        public string GetWords(string word)
        {
            var words = Letters.From(word).SetMinWordLength(2).CreateWords();
            string answer = SearchInDB.Search(words);
            return answer;
        }
    }
}