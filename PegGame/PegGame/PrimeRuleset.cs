using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if all prime-numbered pegs lower than the target peg are "ON" and no other lower numbered pegs are "ON".
    /// </summary>
    class PrimeRuleset : Ruleset
    {
        /// <summary>
        /// The set of prime numbers in the available pegs.
        /// </summary>
        private static int[] primes = new int[] { 2, 3, 5, 7 };

        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public PrimeRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Primes";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //Note that only pegs lower-numbered than the target are checked for primality.
            for (int i = 1; i < index; i++)
                if ((primes.Contains(i) && !current[i]) || (!primes.Contains(i) && current[i]))
                    return false;

            return true;
        }
    }
}