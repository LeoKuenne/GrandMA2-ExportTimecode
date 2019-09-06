using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    class Client
    {

        StreamReader input = null;
        StreamWriter output = null;

        public Client(StreamReader input)
        {
            this.input = input;

        }

        public void Run()
        {
            String line;
            while ((line = input.ReadLine()) != null)
            {
                output.Write((line) + "\r\n");
                Console.Write((line) + "\r\n");
            }
        }


        private String removeASCIICodes(string line)
        {
            String newLine = Regex.Replace(line, @"\e\[(\d+;)*(\d+)?[ABCDHJKfmsu]", "");

            return newLine;
        }
    }
}
