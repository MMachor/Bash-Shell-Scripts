using System;
using System.Collections.Generic;
using System.Data;

namespace Wireless_Audit_Test_1
{
    class Deconstruct_CSV 
    {
        public static DataTable deconstructInformation(List<string> infoToParse, int columnCount, string delimiter)
        {
            DataTable parsedItems = new DataTable();

            var columnHeaders = infoToParse[0].ToString().Split(new string[] { delimiter }, StringSplitOptions.None);

            for (int columnPosition = 0; columnPosition < columnCount; columnPosition++)
            {
                parsedItems.Columns.Add(columnHeaders[columnPosition]);
            }

            infoToParse.RemoveAt(0);

            for (int dataRow = 0; dataRow < infoToParse.Count; dataRow++)
            {
                parsedItems.Rows.Add();

                var rowItems = infoToParse[dataRow].ToString().Split(new string[] { delimiter }, StringSplitOptions.None);

                if (rowItems.Length > columnCount) {
                    rowItems = combineItems(rowItems, columnCount);
                }

                for(int columnPosition = 0; columnPosition < columnCount; columnPosition++)
                {
                    parsedItems.Rows[parsedItems.Rows.Count - 1][columnPosition] = rowItems[columnPosition];
                }
            }

            infoToParse.RemoveAt(0);
            
            return parsedItems;
        }

        private static string[] combineItems(string[] items, int columnCount)
        {
            string combinedItems = "";

            for(int X = columnCount - 1; X < items.Length; X++)
            {
                combinedItems = combinedItems + items[X] + ", ";
            }

            combinedItems = combinedItems.Substring(0, combinedItems.Length - 2);

            items[columnCount - 1] = combinedItems;

            return items;
        } 
    }
}
