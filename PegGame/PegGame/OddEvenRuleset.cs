using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegGame
{
    /// <summary>
    /// A rule set in which a peg can be switched if the number of "ON" pegs has the same evenness as the target  peg.
    /// </summary>
    class OddEvenRuleset : Ruleset
    {
        /// <summary>
        /// Creates a new instance of this rule set.
        /// </summary>
        public OddEvenRuleset() { }

        /// <summary>
        /// Returns the hint to show to the user about this rule set.
        /// </summary>
        /// <returns>A hint describing this rule set.</returns>
        public override string Hint()
        {
            return "Odds and Evens";
        }

        /// <summary>
        /// Determines whether a given peg can be switched, given the current configuration of the pegs.
        /// </summary>
        /// <param name="index">The index of the target peg.</param>
        /// <param name="current">The current configuration of the pegs.</param>
        /// <returns>True if the target peg is allowed to move; false otherwise.</returns>
        public override bool CanMove(int index, bool[] current)
        {
            //Note that this rule set counts all "ON" pegs, not just those higher (or lower) than the target peg.
            int numOn = current.Count(b => b) - 1;

            //When an even numbers of pegs is "ON", all even pegs can be switched. Same with an odd number.
            return (numOn % 2 == index % 2);
        }
    }
}
