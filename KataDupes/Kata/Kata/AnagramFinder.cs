namespace Kata;

public class AnagramFinder
{
    private string CleanString(string inputWord)
    {
        if (string.IsNullOrEmpty(inputWord))
        {
            return inputWord;
        }

        inputWord = inputWord.Trim(' ', '.');
        inputWord = inputWord.Replace("\r\n", ""); // for Windows
        inputWord = inputWord.Replace("\n", ""); // for Unix/Linux
        inputWord = inputWord.Replace("\r", ""); // for Mac OS (classic)
        inputWord = inputWord.ToLower();

        return inputWord;
    }

    public List<string> Find(string inputString)
    {
        var twoWordAnagrams = new List<string>();
        
        //Clean Up
        var inputText = CleanString(inputString);
        
        // Get Valid Words
        var validWords = GetValidWordList();

        // Find All Anagrams
        var anagrams = GetAnagramWords(inputString, validWords);
        
        //Check 2 Word Anagrams
        return twoWordAnagrams;
    }

    private string[] GetAnagramWords(string inputString, string[] validWords)
    {
        var inputWordCharacters = GetInputWordCharacterCounts(inputString);
        var matchedWords = new List<string>();
        foreach (var validword in validWords)
        {
            var isAnagram = true;
            var validWordCharacters = GetInputWordCharacterCounts(validword);

            foreach (var character in validWordCharacters)
            {
                // Get Char from Input if it exists
                if (inputWordCharacters.TryGetValue(character.Key, out var inputCharacterCount))
                {
                    if (inputCharacterCount >= character.Value) ;
                    {
                        continue;
                    }
                }

                isAnagram = false;
                break;
            }
            
            if(isAnagram)
                matchedWords.Add(validword);
            
        }
        
        return matchedWords.ToArray();
    }

    private Dictionary<char, int> GetInputWordCharacterCounts(string inputString)
    {
        return inputString
            .GroupBy(x => x).ToDictionary(
                group => group.Key,
                group => group.Count()
            )
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);
    }

    private string[] GetValidWordList()
    {
        var fileContent = File.ReadAllText("wordList.txt");
        fileContent = fileContent.ToLower();

        fileContent = CleanString(fileContent);
        
        var words = fileContent.Split(' ');
        var validWords = words.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        return validWords;
    }
}