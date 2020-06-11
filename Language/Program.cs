using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = File.ReadAllText(@"C:\Users\Khan\source\repos\mirea\SPO_RESTART\Language\SPO2020_RESTART\Language\INPUT.txt");

            
            Lexer lex = new Lexer(input);
            
            var tokens = lex.returnTokens();


            Parser p = new Parser(tokens);
            Console.WriteLine("Работа Парсера\n");
            p.lang();


            Console.WriteLine();
            Console.WriteLine("POLIZ -> ");
            SyntaxAnalyzer s = new SyntaxAnalyzer();
            tokens.Add(new Token(Lexem.END, "$"));
            var poliz = s.convert(tokens);

            
            Console.WriteLine();
            foreach (var item in poliz)
            {
                Console.Write(item.value + "  ");
            }
            Console.WriteLine("\n\nВыполнение программы->");


            StackMachine st = new StackMachine();
            st.calculate(poliz);

            Console.WriteLine("______________________");
            Console.WriteLine();
            Console.WriteLine("Конечные значения переменных->");

            Console.WriteLine();
            foreach (KeyValuePair<string, object> var in st.Variables)
            {
                Console.WriteLine("{0}: {1}", var.Key, var.Value);
            }
            Console.WriteLine();
            foreach (var item in st.Lists)
            {
                
                Console.WriteLine(item.Key);
                item.Value.Display();
            }
            Console.WriteLine();
            foreach (var item in st.HTables)
            {

                Console.WriteLine(item.Key);
                item.Value.Display();
            }


            Console.ReadLine();
            
            
        }
    }
}


/*
 a = n.Count() - 1;

while( 1 == 1 ){

	List n;
	n.Add(a * n .GetIndex(12-1)/2);
	n.Insert(a, 12*12/3);
	n.Display();
	n.Clear();

	HashTable v;
	v.Search(3);
	v.Insert(b,1);
	
	
	if( a > b)
	{
		b = 2;
		a = b + 2 * 3;
	}
	else if(b > a ) {
		b = 3;
		a= a * 2 / 1 / b;
	}else{
		a =20;
	}
}
     
      
     
     
     
     
     */



/*
        LinkedList a = new LinkedList();
        a.insertAt(new HTElement(1, 2), a.count());
        a.insertAt(new HTElement(3, 4), a.count());
        a.insertAt(new HTElement(5, 6), a.count());
        a.insertAt(new HTElement(7, 8), a.count());

        for (int i = 0; i < a.count(); i++)
        {
            Console.WriteLine( (a.getValue(i) as HTElement).Key + " " + (a.getValue(i) as HTElement).Value);
        }

        HashTable h = new HashTable();
        h.insert(1, 2);
        h.insert(3, 4);
        h.insert(5, 6);
        h.insert(6, 6);
        h.insert(10, 2);

        h.display();

        */
