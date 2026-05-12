using WordGame.Models;
using WordGame.Repositories;
using WordGame.Interfaces;

namespace WordGame.WordGenerator
{
    public class WordProvider
    {
        //private usage for security and abstraction
        //own words used for getting random words in a list
        IRepository<int,Words> wordsRepo = new WordRepository();
        private List<string> words = new List<string>();

        public WordProvider()
        {
            var wordsList =  wordsRepo.GetAll();
            foreach(var items in wordsList)
            {
                string word = items.Word;
                words.Add(word);
            }
        }
        
        //implementation of getting the elements from the list randomly
        private Random random = new Random();
        public string GetRandomWord()
        {
            return words[random.Next(words.Count)];
        }
    }

}