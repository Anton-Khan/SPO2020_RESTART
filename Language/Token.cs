using System;
using System.Collections.Generic;
using System.Text;

namespace Language
{
    class Token
    {
        public Lexem lexem { get; }
        public String value { get; set; }

        public Token(Lexem lexem, string value)
        {
            this.lexem = lexem;
            this.value = value;
        }


    }
}
