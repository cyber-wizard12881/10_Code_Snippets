/*
 * 3. To Determine whether a word is an Anagram of the other or not?
 *    i.e TEAM & MATE are Anagrams but TEAM & GATE are not!
 */

bool is_anagram(string word1, string word2)
{
    string ordered_word1 = string.Empty;
    string ordered_word2 = string.Empty;

    if (!string.IsNullOrEmpty(word1)){
        char[] chars1 = word1.ToCharArray();
        ordered_word1 = string.Join(null, chars1.OrderBy(c => c).ToArray()); //Sort the letters of the Word1!
    }

    if (!string.IsNullOrEmpty(word2))
    {
        char[] chars2 = word2.ToCharArray();
        ordered_word2 = string.Join(null, chars2.OrderBy(c => c).ToArray()); //Sort the letters of the Word2!
    }

    //If the Sorted Versions of the words match, then they must be Anagrams!!
    if (!string.IsNullOrEmpty(ordered_word1) && !string.IsNullOrEmpty(ordered_word2) && ordered_word1.Equals(ordered_word2))
    {
        Console.WriteLine($"{word1} and {word2} are Anagrams of each other!");
        return true;
    }

    //Else, they are NOT!!
    Console.WriteLine($"{word1} and {word2} are NOT Anagrams of each other!");
    return false;
}

is_anagram("TEAM", "MATE");
is_anagram("TEAM", "GATE");
