using Haiku.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haiku.HaikuContext
{
    public class HaikuContext : IHaikuContext
    {
        /// <summary>
        /// This function is used to check if the Hikau is Valid
        /// </summary>
        /// <param name="argHikauData"></param>
        /// <returns></returns>
        public string CheckIfHikauIsValid(List<int> argHikauData)
        {
            #region Declarations
            string l_HikauOutput = string.Empty;
            #endregion

            if (argHikauData != null && argHikauData.Count == 3)
            {
                if (argHikauData[0] == 5 && argHikauData[1] == 7 && argHikauData[2] == 5)
                {
                    l_HikauOutput = "Y";
                }
                else
                {
                    l_HikauOutput = "N";
                }
            }
            else
            {
                l_HikauOutput = "N";
            }

            return l_HikauOutput;
        }

        /// <summary>
        /// This function is used to get the syllable count in a line of Hikau
        /// </summary>
        /// <param name="argWord"></param>
        /// <returns></returns>
        public int GetSyllableCount(string argWord)
        {
            #region Declarations
            int l_SyllableCount = 0;
            string l_vowels = "aeiouy";
            int l_WordLength = argWord.Length;
            #endregion

            if (!string.IsNullOrEmpty(argWord))
            {
                //check on first letter
                if (l_vowels.Contains(argWord[0]))
                {
                    l_SyllableCount += 1;
                }

                //Check on remaining adjacent letters
                for (int i = 1; i < l_WordLength; i++)
                {
                    if (l_vowels.Contains(argWord[i]) && !l_vowels.Contains(argWord[i - 1]))
                    {
                        l_SyllableCount += 1;
                    }
                }

            }

            return l_SyllableCount;
        }
    }
}