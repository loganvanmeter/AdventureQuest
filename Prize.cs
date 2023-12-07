using System;

namespace Quest
{
    public class Prize {
        private string _text;
         public Prize(string text) {
        _text = text;
    }
        public void ShowPrize(Adventurer adventurer)
        {
            if(adventurer.Awesomeness > 0){
                for (int i = 1; i <= adventurer.Awesomeness; i++){
                Console.WriteLine(_text);
                }
            } else if (adventurer.Awesomeness <= 0){
                Console.WriteLine("Too bad you suck. No prize for you.");
            }
        }
    }

   

}