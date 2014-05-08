using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be changed if only its Totient-numbered peg (out of the lower numbered pegs) is "ON".
    /// If you are unfamiliar with Totients: http://en.wikipedia.org/wiki/Euler's_totient_function
    /// </summary>
    class TotientRuleset : Ruleset
    {
        /// <summary>
        /// The totients of the numbers 0-8.
        /// </summary>
        public static int[] totients = new int[] { 1, 1, 1, 2, 2, 4, 2, 6, 4 };

        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public TotientRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Totients";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //Since the Totient of 1 is 1, always return true for 1.
            if (index == 1)
                return true;

            int totient = totients[index];

            //If any pegs numbered lower than the Totient are "ON", return false.
            for (int i = 1; i < totient; i++)
                if (current[i])
                    return false;

            //If the Totient is "OFF", return false.
            if (!current[totient])
                return false;

            //If any pegs numbered higher than the Totient but lower than the target peg are "ON", return false.
            for (int i = totient + 1; i < index; i++)
                if (current[i])
                    return false;

            return true;
        }
    }
}
