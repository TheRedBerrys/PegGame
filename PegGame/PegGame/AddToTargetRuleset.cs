using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if the "ON" pegs lower than it sum to its index.
    /// </summary>
    class AddToTargetRuleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public AddToTargetRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Sum of activated pegs lower";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //Since 1 and 2 cannot be summed without using themselves, they are always allowed to move.
            if (index < 3)
                return true;

            int sum = 0;
            //Note that the sum is the sum of the indexes of "ON" pegs numbered less than the target peg.
            for (int i = 1; i < index; i++)
                if (current[i])
                    sum += i;

            return (sum == index);
        }
    }
}
