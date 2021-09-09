using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Utilities;
using System;

namespace NameSorterTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ShouldSortGivenList()
        {
            List<string> names = ListSupplier( "Janet Parsons",
                                                    "Vaughn Lewis",
                                                    "Adonis Julius Archer",
                                                    "Shelby Nathan Yoder",
                                                    "Marin Alvarez",
                                                    "London Lindsey",
                                                    "Beau Tristan Bentley",
                                                    "Leo Gardner",
                                                    "Hunter Uriah Mathew Clarke",
                                                    "Mikayla Lopez",
                                                    "Frankie Conner Ritter");
            
            List<string> expected = ListSupplier("Marin Alvarez",
                                                "Adonis Julius Archer",
                                                "Beau Tristan Bentley",
                                                "Hunter Uriah Mathew Clarke",
                                                "Leo Gardner",
                                                "Vaughn Lewis",
                                                "London Lindsey",
                                                "Mikayla Lopez",
                                                "Janet Parsons",
                                                "Frankie Conner Ritter",
                                                "Shelby Nathan Yoder");
            CollectionAssert.AreEqual(expected, NameSort.SortNames(names));
        }

        [TestMethod]
        public void ShouldSortSingleElementList()
        {
            List<string> name = new List<string> {"Kevin Manalili"};

            CollectionAssert.AreEqual(name, NameSort.SortNames(name));
        }

        
        [TestMethod]
        public void ShouldSortSameLastNameButDifferentGivenName()
        {
            List<string> name = ListSupplier("Kevin Manalili", "Abba Manalili");

            List<string> expected = ListSupplier("Abba Manalili", "Kevin Manalili");
            CollectionAssert.AreEqual(expected, NameSort.SortNames(name));
        }

        [TestMethod]
        public void ShouldSortEvenRegardlessOfCasing()
        {
            List<string> name = ListSupplier("Kevin manalili", "Abba Manalili");

            List<string> expected = ListSupplier("Abba Manalili", "Kevin manalili");
            CollectionAssert.AreEqual(expected, NameSort.SortNames(name));
        }

        [TestMethod]
        public void ShouldSortWithMultipleGivenNames()
        {
            List<string> name = ListSupplier("A B C", "A B D C", "A C");

            List<string> expected = ListSupplier("A C", "A B C", "A B D C");
            CollectionAssert.AreEqual(expected, NameSort.SortNames(name));
        }

        [DataTestMethod]
        [DataRow("")]  //Empty String aka No Name
        [DataRow("Madonna")]  //Single Name
        [DataRow(" Madonna")] //Single Name
        [DataRow(" Madonna ")] //Single Name
        [DataRow("Madonna ")] //Single Name
        [DataRow("Kevin Nick Aj Martin Luke")] //More than 3 Given Names
        [DataRow("Janet Parsons,Vaughn Lewis,Adonis Julius Archer,Invalid Element Found Here In This Test")] //All valid element except for one
        [DataRow("Janet Parsons,Invalid,Adonis Julius Archer")] //All valid element except for one
        [DataRow("Janet Parsons,,Adonis Julius Archer")] //All valid element except for one
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionOnInvalidNames(string data)
        {
            List<string> name = data.Split(',').ToList();

            NameSort.SortNames(name);
        }


        private List<string> ListSupplier(params string[] testData)
        {
            return testData.ToList();
        }

    }
}
