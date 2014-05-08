using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if all of its factors (and, out of all lower numbered pegs, only its factors) are set to "ON".
    /// </summary>
    class FactorRuleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public FactorRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Factors";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //If a lower numbered peg is not a factor and "ON" or is a factor and "OFF", return false.
            for (int i = 1; i < index; i++)
                if ((index % i == 0 && !current[i]) || (index % i != 0 && current[i]))
                    return false;

            return true;
        }
    }
}
