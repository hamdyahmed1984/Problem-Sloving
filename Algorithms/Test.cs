using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Test
    {
        int checkWinner(List<List<string>> codeList, List<string> shoppingCart)
        {
            int startIndexOfSearch = 0;
            foreach (List<string> codeOfItems in codeList)
            {
                int index = getStartIndexOfPattern(codeOfItems, shoppingCart, startIndexOfSearch);

                if (index == -1)
                    return 0;

                while (!checkExistenceOfCode(codeOfItems, shoppingCart, index))
                {
                    startIndexOfSearch++;
                    index = getStartIndexOfPattern(codeOfItems, shoppingCart, startIndexOfSearch);
                    if (index == -1)
                        return 0;
                }

                startIndexOfSearch = index + codeOfItems.Count;
            }

            return 1;
        }

        bool checkExistenceOfCode(List<string> codeOfItems, List<string> shoppingCart, int startIndex)
        {
            foreach (string item in codeOfItems)
            {
                if (shoppingCart[startIndex].Trim().ToLower() == "anything" ||
                    shoppingCart[startIndex].Trim().ToLower() != item.Trim().ToLower())
                {
                    return false;
                }
                startIndex++;
            }

            return true;
        }

        int getStartIndexOfPattern(List<string> codeOfItems, List<string> shoppingCart, int startIndex)
        {
            int index = -1;
            for (int i = startIndex; i < shoppingCart.Count; i++)
            {
                if (shoppingCart[i].Trim().ToLower() == "anything" ||
                    shoppingCart[i].Trim().ToLower() == codeOfItems[0].Trim().ToLower())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
