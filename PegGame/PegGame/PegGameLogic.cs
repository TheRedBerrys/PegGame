using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A class handling logic for playing the peg game.
    /// </summary>
    class PegGameLogic
    {
        /// <summary>
        /// The boolean values of the target pegs.
        /// </summary>
        public bool[] Target { get; set; }
        /// <summary>
        /// The boolean values of the current pegs.
        /// </summary>
        public bool[] Current { get; set; }
        /// <summary>
        /// The number of moves the user has taken so far.
        /// </summary>
        public int Moves { get; set; }
        /// <summary>
        /// The rule set governing the playing of this instance of the game.
        /// </summary>
        public Ruleset CurrentRuleset { get; set; }
        /// <summary>
        /// The text hint telling the player about the current game's rule set.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Creates a new instance of the game.
        /// </summary>
        public PegGameLogic()
        {
            //For clarity in dealing with the numbered pegs, the boolean arrays are numbered 0 - 8
            Target = new bool[9];
            Current = new bool[9];

            //The 0 index is not used, but it is easier to deal with them if they're set to true.
            Target[0] = true;
            Current[0] = true;

            ResetTargetAndCurrent(true, true);
        }

        /// <summary>
        /// Resets the target and current pegs to random configurations, and selects a random rule set.
        /// </summary>
        /// <param name="original">True, if the game should default to the original rule set. Defaults to false.</param>
        /// <param name="allCurrentOff">True, if the current pegs should all be set to the "OFF" position. Defaults to false.</param>
        public void ResetTargetAndCurrent(bool original = false, bool allCurrentOff = false)
        {
            CurrentRuleset = Ruleset.CreateRandomRuleset(original);
            Moves = 0;

            Random random = new Random();

            for (int i = 1; i < Target.Length; i++)
            {
                Target[i] = random.Next(2) == 1;
                if (allCurrentOff)
                    Current[i] = false;
                else
                    Current[i] = random.Next(2) == 1;
            }

            Hint = CurrentRuleset.Hint();
        }

        /// <summary>
        /// Attempts to switch a current peg.
        /// </summary>
        /// <param name="toSwitch">The index of the peg to switch.</param>
        public void Switch(int toSwitch)
        {
            //Whether or not the move is allowed, we charge a move to the user.
            Moves++;

            if (!CurrentRuleset.CanMove(toSwitch, Current))
                return;

            Current[toSwitch] = !Current[toSwitch];
        }

        /// <summary>
        /// Determines whether the current game is solved or not.
        /// </summary>
        /// <returns>True if the current game is solved; false otherwise.</returns>
        public bool IsSolved()
        {
            for (int i = 1; i < Current.Length; i++)
                if (Current[i] != Target[i])
                    return false;

            return true;
        }
    }
}
