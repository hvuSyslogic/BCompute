﻿using System.Collections.Generic;

namespace BCompute
{
    public interface INucleotideSequence
    {
        /// <summary>
        /// The set of symbols that are allowed in the sequence's alphabet
        /// </summary>
        ISet<Nucleotide> AllowedSymbols { get; }

        /// <summary>
        /// Mapping of codon triplets to proteins. (Works for DNA, too.)
        /// </summary>
        IDictionary<string, AminoAcid> TranslationTable { get; }

        /// <summary>
        /// Translates from a DnaSequence or RnaSequence to protein sequence based on the GeneticCode
        /// </summary>
        /// <returns></returns>
        ProteinSequence Translate();

        /// <summary>
        /// Mapping of nucleotide complements
        /// </summary>
        IDictionary<Nucleotide, Nucleotide> ComplementTable { get; }

        /// <summary>
        /// Mapping of DNA to RNA and RNA to DNA transciptions
        /// </summary>
        IDictionary<Nucleotide, Nucleotide> TranscriptionTable { get; }

        /// <summary>
        /// Transcribes or back transcribes from a DnaSequence to an RnaSequence, and vice versa
        /// </summary>
        /// <returns></returns>
        NucleotideSequence Transcribe();

        /// <summary>
        /// Returns the number of times the specified nucleotide appears in the sequence data
        /// </summary>
        /// <param name="nucleotide"></param>
        /// <returns></returns>
        long NucleotideCount(Nucleotide nucleotide);

        /// <summary>
        /// Returns the GC content of the sequence to 6 decimal places
        /// </summary>
        double GcContentPercentage { get; }

        /// <summary>
        /// Returns a set of the alphabet symbols that were used to compute the GC content
        /// </summary>
        ISet<Nucleotide> GcContentSymbols { get; }

        /// <summary>
        /// Provides the complementary DnaSequence or RnaSequence object
        /// </summary>
        NucleotideSequence Complement();

        /// <summary>
        /// Provides the reversed complementary DnaSequence or RnaSequence object
        /// </summary>
        NucleotideSequence ReverseComplement();

        /// <summary>
        /// Returns the Hamming Distance between this nucleotide sequence, and another nucleotide sequence of the same type
        /// </summary>
        /// <param name="nucleotideSequence"></param>
        /// <returns></returns>
        long CalculateHammingDistance(NucleotideSequence nucleotideSequence);
    }
}
