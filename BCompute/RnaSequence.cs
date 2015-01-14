﻿using System.Collections.Generic;
using BCompute.Data.Alphabets;
using BCompute.Data.GeneticCode;

namespace BCompute
{
    public class RnaSequence : NucleotideSequence
    {
        public RnaSequence(string rawBasePairs, AlphabetType alphabet, GeneticCode geneticCode = GeneticCode.Standard) : base(rawBasePairs, alphabet, geneticCode) { }

        internal static RnaSequence FastRnaSequence(string safeSequence, AlphabetType alphabet, GeneticCode geneticCode, Dictionary<Nucleotide, long> symbolCounts)
        {
            return new RnaSequence(safeSequence, alphabet, geneticCode, symbolCounts);
        }

        internal RnaSequence(string safeSequence, AlphabetType alphabet, GeneticCode geneticCode, Dictionary<Nucleotide, long> symbolCounts)
            : base(safeSequence, alphabet, geneticCode, symbolCounts)
        {
            //Convert the symbol counts...
            //Get the complementary symbol (T -> A)
            //Get the count of its complement
            //Fill in the new dictionary(complement, complementCount)

            var newSymbolCounts = new Dictionary<Nucleotide, long>(symbolCounts.Count);
            foreach (var symbol in symbolCounts)
            {
                var complement = NucleotideAlphabet.ComplementTable[symbol.Key];
                var complementCount = symbolCounts[complement];
                newSymbolCounts.Add(complement, complementCount);
            }
            SymbolCounts = newSymbolCounts;
        }
    }
}
