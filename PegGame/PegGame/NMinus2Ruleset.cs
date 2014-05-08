using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if the peg two lower than its index is "ON" and all other lower-numbered pegs are "OFF".
    /// </summary>
    class NMinus2Ruleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public NMinus2Ruleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Two Lower";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //Since 1 does not have a peg numbered two lower than itself, return true.
            if (index == 1)
                return true;

            for (int i = 1; i < index - 2; i++)
                if (current[i])
                    return false;

            if (!current[index - 2])
                return false;

            //Note that the next lower numbered peg must be "OFF" for the target peg to move.
            if (current[index - 1])
                return false;

            return true;
        }
    }
}
