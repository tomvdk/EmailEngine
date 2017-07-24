using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EmailEngine.Reader
{
    public class InputRecordReader : IInputRecordReader
    {
        private readonly string _inputFileName;
        public InputRecordReader(string inputFileName)
        {
            _inputFileName = inputFileName;
        }

        public IList<InputRecord> ReadAllInputRecords()
        {
            IList<InputRecord> inputRecords = new List<InputRecord>();
            var allCsvLines = File.ReadAllLines(_inputFileName);
            for (int i = 0; i < allCsvLines.Length; i++)
            {
                //skip header
                if (i > 0)
                {
                    var splittedLine = CSVRowToStringArray(allCsvLines[i], ';');
                    try
                    {
                        var inputRecord = new InputRecord(splittedLine[0], splittedLine[1], splittedLine[2], splittedLine[3]);
                        inputRecords.Add(inputRecord);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return inputRecords;
        }

        private string[] CSVRowToStringArray(string r, char fieldSep = ',', char stringSep = '\"')
        {
            bool bolQuote = false;
            StringBuilder bld = new StringBuilder();
            List<string> retAry = new List<string>();

            foreach (char c in r.ToCharArray())
                if ((c == fieldSep && !bolQuote))
                {
                    retAry.Add(bld.ToString());
                    bld.Clear();
                }
                else
                    if (c == stringSep)
                    bolQuote = !bolQuote;
                else
                    bld.Append(c);

            /* to solve the last element problem */
            retAry.Add(bld.ToString()); /* added this line */
            return retAry.ToArray();
        }
    }
}
