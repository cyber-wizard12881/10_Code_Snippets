// 9. List out all Permutations & Combinations of a String?
//    i.e P(n,r) & C(n,r)??
SortedSet<string> permutations = new SortedSet<string>();
SortedSet<string> combinations = new SortedSet<string>();

//Generates all Permutations of a String
static void permute(string left, string right, int n, SortedSet<string> permutations)
{
    int ll = left.Length;

    if (ll == n)
    {
        permutations.Add(right);
    }

    if (ll != 0)
    {
        for (int i = ll - 1; i >= 0; i--)
        {
            char s = left.ElementAt(i);
            string ls = left.Substring(0, i);
            string rs = left.Substring(i + 1);
            string rss = string.Concat(right, s);
            string lss = string.Concat(ls, rs);

            permute(lss, rss, n, permutations);
        }
    }
}

//The Actual String i.e. n=[A,B,C,D,E]
string str = "ABCDE";
//The length of the output, i.e. r=3
int n = 3;

//Prints all Permutations of a String
permute(str, string.Empty, str.Length - n, permutations);

Console.WriteLine("---------Permutations----------");

foreach (string s in permutations)
{
    Console.WriteLine(s);
}

//Generates all Combinations of a String using Permutations
static void combination(string str, int n, SortedSet<string> combinations)
{
    SortedSet<string> permutations = new SortedSet<string>();
    permute(str, string.Empty, n, permutations);
    deduplicate(permutations, combinations);
}

static void deduplicate(SortedSet<string> set, SortedSet<string> sset)
{
    foreach(string s in set)
    {
        char[] chars = s.ToCharArray();
        string sstr = new string(chars.OrderBy(c => c).ToArray());
        if(sstr != null)
            sset.Add(sstr);
    }
}

//Prints all Combinations of a String
combination(str, str.Length - n, combinations);

Console.WriteLine("---------Combinations----------");

foreach (string s in combinations)
{
    Console.WriteLine(s);
}
