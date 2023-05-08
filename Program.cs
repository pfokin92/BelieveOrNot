using System.Threading.Tasks;
using System.Collections.Generic;
using System.Timers;
using System;


namespace BelieveOrNot
{

    partial class Program
    {
        private const string path = "baseQuestion.csv";

        static void Main(string[] args)
        {
            LogicGame game = new LogicGame(path, 2);
            IEnumerable<BaseQuestion> list = game.Questions;
            game.EndOfGame += (sender, eventArgs) =>
            {
                Console.WriteLine($"Questions asked {eventArgs.QuestionPassed}. Mistakes made: {eventArgs.MistakesMade}");
                Console.WriteLine(eventArgs.IsWin ? "You win!" : "You Lost!");
            };

            while (game.GameStatus == GameStatus.GameInProgres)
            {
                BaseQuestion question = game.GetNextQuestion();
                Console.WriteLine("Do you belive in the next statment or question? Enter 'y' or 'n'");
                Console.WriteLine(question.Text);

                string answer = Console.ReadLine();
                bool boolAnswer = answer == "y";

                if(question.Answer == boolAnswer)
                {
                    Console.WriteLine("Good job. You're right!");
                }
                else
                {
                    Console.WriteLine("Ooops, actually you're mistaken. Here is the commentary:");
                    Console.WriteLine(question.Description);
                }
                game.GiveAnswer(boolAnswer);
            }
            Console.ReadLine();

        }
    }
}
