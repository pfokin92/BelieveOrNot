using System;

namespace BelieveOrNot
{
    public class GameResultEventArgs : EventArgs
    {
        public GameResultEventArgs(int questionPassed, int mistakesMade, bool isWin)
        {
            QuestionPassed = questionPassed;
            MistakesMade = mistakesMade;
            IsWin = isWin;
        }

        public int QuestionPassed { get; }
        public int MistakesMade { get; }
        public bool IsWin { get; }
    }
}
