namespace BLOG.Models
{
    public class FizzBuzzViewModel
    {
        public int fizz {  get; set;}
        public int buzz { get; set; }
        public string result { get; set; }
        
        public void GetFizzBuzz()
        {
            result = "<br />";
            for(var i = 1; i<=100; i++)
            {
                if (i % fizz == 0 && i % buzz == 0)
                {
                    result += " <mark>FizzBuzz</mark> ";
                }
                else if (i % fizz == 0)
                {
                    result += " <mark>Fizz</mark>";
                }
                else if (i % buzz == 0)
                {
                    result += " <mark>Buzz</mark> ";
                }
                else
                {
                    result += " " + i + " ";
                }
            }
        }
    }
}

    
