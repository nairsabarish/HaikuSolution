using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Haiku.Models
{

    public class HaikuModel
    {
        [Required]
        [CustomHikauValidator]
        public string HaikuText { get; set; }
        
        public int SyllableCountFirstLine { get; set; }

        public int SyllableCountSecondLine { get; set; }

        public int SyllableCountThirdLine { get; set; }

        public string HaikuResult { get; set; }
    }

    /// <summary>
    /// Custom validator for Hikau Text
    /// </summary>
    public class CustomHikauValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool l_IsHiakuValid = false;
            string l_HikauValue = string.Empty;

            /*
            String should not be empty
            Only small characters allowed with forward slash and space
            count excluding forward slash should be less than equals 200
            */
            if (value!=null)
            {
                l_HikauValue = value.ToString();

                if(Regex.IsMatch(l_HikauValue.Trim(), @"^[a-z/ ]+$") && l_HikauValue.Count(s => s != '/') <= 200)
                {
                    var l_HikaluLines = l_HikauValue.Split('/');

                    //There should exist at least 3 lines with at least one character
                    if (l_HikaluLines != null && l_HikaluLines.Length == 3
                        && l_HikaluLines.All(x => !string.IsNullOrEmpty(x)))
                    {
                        l_IsHiakuValid = true;
                    }
                    else
                    {
                        l_IsHiakuValid = false;
                    }
                }
                else
                {
                    l_IsHiakuValid = false;
                }
            }
            else
            {
                l_IsHiakuValid = false;
            }

            if(l_IsHiakuValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Please Enter Valid Haiku text!!");
            }
        }
    }
}