using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BelieveOrNot
{
   

    public class LogicGame
    {
        public int Mistakes { get; set; }
        public int ClientMistakes { get; set; }
        public List<BaseQuestion> Questions { get; set; }
        public GameStatus GameStatus { get; private set; }
        public event EventHandler<GameResultEventArgs> EndOfGame;
        public  int counter { get; set; } 


        public LogicGame(string path, int mistakes = 2)
        {
            if (path == null)
                throw new ArgumentNullException("Path has to exist");

            if (path == "")
                throw new ArgumentException("Path must not be empty");

            if (mistakes < 2)
                throw new ArgumentException("Mistakes must be >= 2");

            Random rnd = new Random();
            Questions = File.ReadAllLines(path)
                .Skip(1)
                .Select(BaseQuestion.ParseFileCsv)
                .OrderBy(question => rnd.Next())
                .ToList();
            Mistakes = mistakes;
            GameStatus = GameStatus.GameInProgres;
        }

        public BaseQuestion GetNextQuestion()
        {
            return Questions[counter];
        }

        public void GiveAnswer(bool answer)
        {
            if(Questions[counter].Answer != answer)
            {
                ClientMistakes ++;
            }
            if(counter == Questions.Count -1 || ClientMistakes> Mistakes)
            {
                GameStatus = GameStatus.GameOver;
                if (EndOfGame != null)
                    EndOfGame(this, new GameResultEventArgs(counter+1, ClientMistakes, ClientMistakes <= Mistakes));
            }
            counter++;
        }

        

    }
}
