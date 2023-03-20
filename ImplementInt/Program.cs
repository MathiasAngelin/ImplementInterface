using ImplementInt;
var theasaurus = new Thesaurus();
theasaurus.words.Add(new Word { Theword = "Bok" });
theasaurus.words.Add(new Word { Theword = "Dator" });

// Uppgiftsinfo
// PGA att detta endast skulle ta 1-2 timmar har jag sparat på krutet lite då jag ville hålla på tiden.
// Har fokuserat på att få alla funktioner att funkera ok, samt att programmet inte craschar
// 
// Om jag skulle lägga ner mer tid hade jag fixat följande:
//
// Nullcheckar
// Refaktorering av kod, hade nog kunnat bryta en del snyggare i metoder
// Kontrollera input från användaren, de kan skriva in vad som helst
// Upper/lowercase hantering och undvika dubbellagring av synonymer
// AddSynonymsfunktionen funkar sådär. Hade velat förbättra den. 


//Kontroll om ordet finns
bool CheckWord(string word)
{
    if(theasaurus.words.Any(w => w.Theword == word))
    return true;
    else return false;
}

//Kontroll om synonym redan finns, fungerar dock bara om man gått ut funktionen och in igen.
//Hade kunnat göras helt klart, osnyggt med nestlade if:ar också. 
bool CheckSynonym(string synonym, string word)
{
    var theWord = theasaurus.words.FirstOrDefault(w => w.Theword == word);
    if(theWord.Synonyms != null)
    {
    if (theWord.Synonyms.Contains(synonym)) return false;
    else return true;
    }

    else return true;
}

while (true)
{
    Console.WriteLine("\nWhat do you want to do?");
    Console.WriteLine("a: Add Synonyms\ns: Get Synonyms \nw: Get Words \nESC: Exit\n");

    var initialInput = Console.ReadKey(true);
    Console.Clear();
    switch (initialInput.KeyChar)
    {
        //ADD SYNONYMS TO WORD
        case 'a':
            List<string> synonymsToAdd = new List<string>();
            Console.WriteLine("Select a word");

            foreach (var word in theasaurus.words)
            {
                Console.WriteLine(word.Theword);
            }
            var wordToAddSynonyms = Console.ReadLine();

            var isword = CheckWord(wordToAddSynonyms);
            if (!isword)
            {
                Console.WriteLine("Doesn't exist");
                break;
            }


            Console.WriteLine("Add synonymes for " + wordToAddSynonyms + ", press Enter after each word\nWhen you're done, Write X and press Enter");
            synonymsToAdd.Add(wordToAddSynonyms);
            var SynonymAdd = Console.ReadLine();

            while(SynonymAdd != "X")
            {
                var isSyn = CheckSynonym(SynonymAdd, wordToAddSynonyms);
                if (!isSyn) {
                    Console.WriteLine("Word already exists, sorry");
                    break;
                }
                else
                {
                synonymsToAdd.Add(SynonymAdd);
                SynonymAdd = Console.ReadLine();
                }
            }

           theasaurus.AddSynonyms(synonymsToAdd);

            break;


        //GET SYNONYMS FOR WORD
        case 's':

            Console.WriteLine("Select a word");
            foreach(var word in theasaurus.words)
            {
                Console.WriteLine(word.Theword);
            }
            string wordSearch = Console.ReadLine();
            var isWord = CheckWord(wordSearch);
            if (!isWord)
            {
                Console.WriteLine("Doesn't exist");
                break;
            }


            var wordSynonyms = theasaurus.GetSynonyms(wordSearch);
            if(wordSynonyms != null) {
            Console.WriteLine("\nThe Synonyms are\n------------");
                foreach (var synonyms in wordSynonyms)
                {
                    Console.WriteLine(synonyms);
                }
                Console.WriteLine("------------");
            }
            else
            {
                Console.WriteLine("no synonyms");
            }
            

            break;

        //GET ALL WORDS
        case 'w':
            var wordList = theasaurus.GetWords();
            Console.WriteLine("------------");
            foreach (var word in wordList)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("------------");
            break;

        default:
            Console.WriteLine("Wrong input");
            break;
    }
}



