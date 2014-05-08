using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// An abstract class representing a rule set for the peg game.
    /// </summary>
    abstract class Ruleset
    {
        /// <summary>
        /// The hint that will be shown to the player.
        /// </summary>
        /// <returns>The hint that will be shown to the player.</returns>
        public abstract string Hint();

        /// <summary>
        /// Determines whether a given peg is allowed to switch in the current configuration.
        /// </summary>
        /// <param name="index">The index of the peg to attempt to switch.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the given peg is currently allowed to switch; false otherwise.</returns>
        public abstract bool CanMove(int index, bool[] current);

        /// <summary>
        /// Returns a randomly selected rule set.
        /// </summary>
        /// <param name="original">True, if the original rule set is desired.</param>
        /// <returns>The randomly selected (or original, if desired) rule set.</returns>
        public static Ruleset CreateRandomRuleset(bool original = false)
        {
            if (original)
                return new OriginalRuleset();

            Random random = new Random();

            switch (random.Next(9))
            {
                case 0:
                    return new OriginalRuleset();
                case 1:
                    return new PrimeRuleset();
                case 2:
                    return new BackwardsRuleset();
                case 3:
                    return new OddEvenRuleset();
                case 4:
                    return new FactorRuleset();
                case 5:
                    return new NPlus2Ruleset();
                case 6:
                    return new NMinus2Ruleset();
                case 7:
                    return new AddToTargetRuleset();
                case 8:
                    return new TotientRuleset();
                default:
                    return new OriginalRuleset();
            }
        }
    }
}
