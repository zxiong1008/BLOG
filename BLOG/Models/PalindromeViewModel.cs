using System.Linq;

namespace BLOG.Models
{
    public class PalindromeViewModels
    {
        public string inputWord { get; set; }
        public string outputWord { get; set; }

        public void CheckPalindrome()
        {
            var text = inputWord.ToLower();
            //remove all whitespaces
            text = text.Replace(" ", "");
            //reverse the text
            var textReverse = new string(text.Reverse().ToArray());

            if (text == textReverse)
                outputWord = "<mark>\"" + inputWord + "\"</mark> is a palindrome.";
            else
                outputWord =  "<mark>\"" + inputWord + "\"</mark> is not a palindrome.";
        }
    }
}
