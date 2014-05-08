using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if the peg number two higher than itself is "ON" and no other higher-numbered pegs are "ON".
    /// </summary>
    class NPlus2Ruleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public NPlus2Ruleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Two Higher";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            if (index == current.Length - 1)
                return true;

            if (index == current.Length - 2)
                return !current[index + 1];

            if (current[index + 1])
                return false;

            if (!current[index + 2])
                return false;

            for (int i = index + 3; i < current.Length; i++)
                if (current[i])
                    return false;

            return true;
        }
    }
}
