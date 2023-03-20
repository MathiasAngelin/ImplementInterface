using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementInt
{
    public class Thesaurus : IThesaurus
    {
        //Lista av alla ord. Skapade en modell som har en string för själva ordet sedan en lista av strängar som synonymer
        public List<Word> words = new List<Word>();

        //Hämtar ordet genom att ta det första i listan "synonyms" som ju är det faktiskta ordet
        //Lägg in alla synonymer i en ny lista men skippar det första ordet då det är det faktiska ordet. 
        //Om man hade lagt till en metod för GetWord hade man kunnat lösa detta mycket bättre. 
        public void AddSynonyms(IEnumerable<string> synonyms)
        {
            Word word = words.FirstOrDefault(w => w.Theword == synonyms.First());
            var newlist = synonyms.Skip(1);
            word.Synonyms = new List<string>();
            word.Synonyms.AddRange(newlist);
        }

        //Hämtar synonymerna för ordet som efterfrågas och returnerar dem
        public IEnumerable<string> GetSynonyms(string word)
        {
            Word theWord = words.FirstOrDefault(w => w.Theword == word);
            return theWord.Synonyms;
        }

        //skickar tillbaka en lista med alla ord
        public IEnumerable<string> GetWords()
        {
            var wordsToSend = new List<string>();
            foreach (var word in words)
            {
                wordsToSend.Add(word.Theword);
            }
            return wordsToSend;
        }


    }
}
