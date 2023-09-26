/*
@problem https://leetcode.com/problems/letter-combinations-of-a-phone-number/

This is an example of recursion for generating all possible solutions.
*/
class LetterCombinationsOnAPhoneNumber{
    static public IList<string> LetterCombinations(string digits) {
        if(string.IsNullOrEmpty(digits))return new List<string>();//Empty string
        List<string> combinations = new List<string>();//For storing the combinations
        GenerateCombinations(digits,0,combinations);
        return combinations;
    }
    /*
    On digits are stored the dialed digits.
    On pos is stored the actual digit.
    On storage it stores the generated combinations.
    On generated it stores the string being generated
    */
    static private void GenerateCombinations(string digits,int pos,List<string> storage,string generated=""){
        if(pos == digits.Length){
            //This means the string is fully generated
            storage.Add(generated);
            return;
        }
        int digit = int.Parse(digits[pos].ToString());
        foreach(string letter in MapToLetters(digit)){
            GenerateCombinations(digits,pos+1,storage,generated + letter);
        }

    }
    //Mapps numbers to letters
    static private List<string> MapToLetters(int x){
        if(x < 2 || x > 9)throw new Exception("Invaid input");
        switch(x){
            case 2:
                return new List<string>(){"a","b","c"};
            case 3:
                return new List<string>(){"d","e","f"};
            case 4:
                return new List<string>(){"g","h","i"};
            case 5:
                return new List<string>(){"j","k","l"};
            case 6:
                return new List<string>(){"m","n","o"};
            case 7:
                return new List<string>(){"p","q","r","s"};
            case 8:
                return new List<string>(){"t","u","v"};
            case 9:
                return new List<string>(){"w","x","y","z"};
        }
        throw new Exception("Invalid execution path");
    }
}