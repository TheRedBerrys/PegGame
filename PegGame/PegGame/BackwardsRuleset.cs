using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if the next higher numbered peg is "ON" (and no other higher-numbered pegs are "ON")
    /// </summary>
    class BackwardsRuleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public BackwardsRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "One Higher";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //If the next higher numbered peg is "OFF", return false.
            if (index + 1 < current.Length && !current[index + 1])
                return false;

            //If any other higher numbered pegs are "ON", return false.
            for (int i = index + 2; i < current.Length; i++)
                if (current[i])
                    return false;

            return true;
        }
    }
}