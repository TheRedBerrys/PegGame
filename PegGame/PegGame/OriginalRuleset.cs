using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if the next lower numbered peg is "ON" and no other lower numbered peg is "ON".
    /// </summary>
    class OriginalRuleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public OriginalRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "One Lower";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            for (int i = 1; i < index - 1; i++)
                if (current[i])
                    return false;

            if (!current[index - 1])
                return false;

            return true;
        }
    }
}
