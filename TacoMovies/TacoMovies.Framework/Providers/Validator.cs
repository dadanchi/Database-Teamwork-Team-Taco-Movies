using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;

namespace TacoMovies.Framework.Providers
{
    public class Validator
    {
        private const string IncorectUsernameOrPassword = "Input should be between 4 and 20 character inclusive.\n Enter again : ";
       

        private readonly IWriter writer;
        private readonly IReader reader; 
        public Validator(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }


        public void ValidateUsernameOrPassword(string input)
        {
            while(input.Length < 4 || input.Length > 20)
            {

                this.writer.Write(IncorectUsernameOrPassword);
                input = this.reader.Read();
            }
        }

    }
}
