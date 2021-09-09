using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utilities {
    public static class NameSort {

        public static List<string> SortNames(IEnumerable<string> names) {
            InputValidation(names);
            Func<string, string> lastName = fullName => {
                return fullName.ToLower().Substring(fullName.LastIndexOf(' ') + 1);
            };

            Func<string, string> givenName = fullName => {
                return fullName.ToLower().Substring(0, fullName.LastIndexOf(' ') - 1);
            };

            return names.OrderBy(lastName).ThenBy(givenName).ToList();
        }

        private static void InputValidation(IEnumerable<string> names) {
            Func<string, bool> invalidNames = n => {
                var nameMatch = new Regex(@"\w+");
                var nameCount = nameMatch.Matches(n).Count();
                return nameCount > 4 || nameCount < 2;
            };
            
            if (names.Any(invalidNames)) throw new ArgumentException("Found invalid names in the input.");
        }


    }
}