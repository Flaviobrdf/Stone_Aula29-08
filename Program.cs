using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using static Aula08_29.Program;

namespace Aula08_29
{

    internal class Program
    {

        static void Main(string[] args)
        {
            inicio();
        }

        public static void inicio()
        {
            Console.Write("\nESCOLHA UMA OPÇÃO:\n\n" +
                "1 _ LISTAR DISPONÍVEIS\n" +
                //"2 _ LISTAR PRODUTOS EM FALTA\n" +
                "2 _ CADASTRAR\n" +
                "3 _ MODIFICAR\n" +
                "4 _ DELETAR\n\n" +
                "5 _ SAIR\n\n"
                );

            string menu = Console.ReadLine();

            if (menu == "1" || menu == "2" || menu == "3" || menu == "4" || menu == "5" || menu == "6")
            {

                switch (menu)
                {
                    case "1":
                        //Console.Write("\nLISTAR\n");
                        //disponiveis();
                        //buscaList();
                        break;
                    case "2":
                        Console.Write("CADASTRAR\n");
                        cadastrar();
                        break;
                    case "3":
                        //Console.Write("CADASTRAR\n");

                        break;
                    case "4":
                        Console.Write("MODIFICAR\n");
                        break;
                    /* case "5":
                         Console.Write("DELETAR\n");
                         break;*/
                    case "5":
                        return;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Write("\nDigite uma opção válida de 1 a 5\n\n");
                inicio();
            }

        }
        public static void disponiveis()
        {
            Console.Write("\nLISTA DE PRODUTOS\n\n" +
                "0 _ VOLTAR\n" +
                "1 _ LISTA COMPLETA\n" +
                "2 _ BUSCA AVANÇADA\n\n");

            string menu = Console.ReadLine();

            if (menu == "0" || menu == "1" || menu == "2")
            {

                switch (menu)
                {
                    case "0":
                        //Console.Write("VOLTAR\n");
                        inicio();
                        break;
                    case "1":
                        Console.Write("LISTA COMPLETA\n");
                        break;
                    case "2":
                        Console.Write("BUSCA AVANÇADA\n");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Write("\nDigite uma opção válida de 0 a 2\n\n");
                disponiveis();
            }
        }


        public static void addProduto(
            int ID,
         string GRUPO,
         string PRODUTO,
         string DESCRICAO,
         string MARCA,
         string MODELO,
         string NS,
         int DISPONIBILIDADE,
         string PRATELEIRA,
         double vlCOMPRA,
         double vlVENDA,
         double vlLUCRO
            )
        {
            var listOfProd = new List<Produto>();
            listOfProd.Add(new Produto(
                 ID,
          GRUPO,
          PRODUTO,
          DESCRICAO,
          MARCA,
          MODELO,
          NS,
          DISPONIBILIDADE,
          PRATELEIRA,
          vlCOMPRA,
          vlVENDA,
          vlLUCRO
                )
            {
                ID = ID,
                GRUPO = GRUPO,
                PRODUTO = PRODUTO,
                DESCRICAO = DESCRICAO,
                MARCA = MARCA,
                MODELO = MODELO,
                NS = NS,
                DISPONIBILIDADE = DISPONIBILIDADE,
                PRATELEIRA = PRATELEIRA,
                vlCOMPRA = vlCOMPRA,
                vlVENDA = vlVENDA,
                vlLUCRO = vlLUCRO
            });

            for (int i = 0; i < listOfProd.Count; i++)
            {
                Console.WriteLine(
                    "ID  " +
                    "| GRUPO   " +
                    "| PRODUTO " +
                    "| CARACTERÍSTICA " +
                    "| MARCA   " +
                    "| MODELO  " +
                    "| NS    " +
                    "| DISPONÍVEL " +
                    "| LOCAL" +
                    "| VL COMPRA" +
                    "| VL VENDA " +
                    "| VL LUCRO ");

                Console.WriteLine(
               "----" +
               "----------" +
               "----------" +
               "----------" +
               "----------" +
               "--------" +
               "----------------" +
               "-------------" +
               "--------" +
               "-----------" +
               "-----------" +
               "-----------");



                Console.WriteLine(
                     ID + "    |" +
                        GRUPO + "|    " +
                        PRODUTO + " |  " +
                        DESCRICAO + "|    " +
                        MARCA + " |     " +
                        MODELO + " |     " +
                        NS + "|       " +
                        DISPONIBILIDADE + "|     " +
                        PRATELEIRA + " |    " +
                        vlCOMPRA + "|   " +
                        vlVENDA + " |    " +
                        vlLUCRO + " |    ");
            }

            Console.ReadKey();

            inicio();
        }




        public static void dadosProd(string categoria, string tipProd)
        {

            Produtos produtos = new Produtos();

            produtos.GRUPO = categoria;

            produtos.PRODUTO = tipProd;

            Console.Write("\nDigite as DESCIRÇÕES do produto:\n\n");
            produtos.DESCRICAO = Console.ReadLine();

            Console.Write("\nDigite a MARCA do produto:\n\n");
            produtos.MARCA = Console.ReadLine();

            Console.Write("\nDigite a MODELO do produto:\n\n");
            produtos.MODELO = Console.ReadLine();

            Console.Write("\nDigite a NS do produto:\n\n");
            produtos.NS = Console.ReadLine();

            Console.Write("\nDigite a quantidade de produtos DISPONÍVEIS:\n\n");
            produtos.DISPONIBILIDADE = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDigite a PRATELEIRA do produto:\n\n");
            produtos.PRATELEIRA = Console.ReadLine();

            Console.Write("\nDigite o valor da COMPRA do produto:\n\n");
            produtos.vlCOMPRA = Double.Parse(Console.ReadLine());

            String vendaLucro;
            Console.Write("\nDigite 'V' para inserir o valor da VENDA " +
                "ou 'L' para inserir o valor do LUCRO pretendido para o produto:\n");
            vendaLucro = Console.ReadLine();

            if (vendaLucro == "V")
            {
                Console.Write("\nDigite o valor da VENDA do produto:\n");

                produtos.vlVENDA = Double.Parse(Console.ReadLine());
                produtos.vlLUCRO = produtos.vlVENDA - produtos.vlCOMPRA;
            }

            if (vendaLucro == "L")
            {
                String novoLucro;
                double novoLC;

                Console.Write("\n Digite o valor do lucro ou a porcentagem com sinal do '%'.\n");
                novoLucro = Console.ReadLine();

                if (novoLucro.Contains("%"))
                {
                    //REMOVER CARACTERES "%"
                    string str = novoLucro;
                    string[] charsToRemove = new string[] { "%" };
                    foreach (var c in charsToRemove)
                    {
                        str = str.Replace(c, string.Empty);
                    }
                    Console.WriteLine(str);
                    //REMOVER CARACTERES "%"

                    novoLC = Convert.ToDouble(str);

                    produtos.vlLUCRO = produtos.vlCOMPRA * (novoLC / 100);
                    produtos.vlVENDA = produtos.vlCOMPRA + produtos.vlLUCRO;

                }
                else
                {
                    novoLC = Convert.ToDouble(novoLucro);
                    produtos.vlLUCRO = novoLC;
                    produtos.vlVENDA = produtos.vlCOMPRA + produtos.vlLUCRO;
                }

            }


            /*
            Console.Write(
               " " + produtos.DESCRICAO+
              " " + produtos.MARCA+
              " " + produtos.MODELO+
              " " + produtos.NS+
              " " + produtos.DISPONIBILIDADE+
              " " + produtos.PRATELEIRA+
              " " + produtos.vlCOMPRA+
              " " + produtos.vlVENDA+
              " " + produtos.vlLUCRO
                );*/




            addProduto(
                produtos.ID,
                produtos.GRUPO,
                produtos.PRODUTO,
                produtos.DESCRICAO,
                produtos.MARCA,
                produtos.MODELO,
                produtos.NS,
                produtos.DISPONIBILIDADE,
                produtos.PRATELEIRA,
                produtos.vlCOMPRA,
                produtos.vlVENDA,
                produtos.vlLUCRO
                );

        }














        public static void cadastrar()
        {
            Console.Write("\nCADASTRO DE PRODUTO:\n\n");

            Console.Write("\nCATEGORIA DO PRODUTO:\n\n" +
                "0 _ VOLTAR\n" +
                "1 _ PERIFÉRICOS\n" +
                "2 _ PLACAS\n" +
                "3 _ MEMÓRIAS\n" +
                "4 _ COMPUTADORES\n\n");

            string menu = Console.ReadLine();

            if (menu == "0" || menu == "1" || menu == "2" || menu == "3" || menu == "4")
            {

                switch (menu)
                {
                    case "0":
                        //Console.Write("VOLTAR\n");
                        inicio();
                        break;
                    case "1":
                        //Console.Write("LISTA COMPLETA\n");
                        break;
                    case "2":
                        //Console.Write("BUSCA AVANÇADA\n");
                        break;
                    case "3":
                        //Console.Write("BUSCA AVANÇADA\n");
                        tipPROD("Memória");
                        break;
                    case "4":
                        //Console.Write("BUSCA AVANÇADA\n");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Write("\nDigite uma opção válida de 0 a 4\n\n");
                disponiveis();
            }

        }

        public static void tipPROD(string categoria)
        {
            Console.Write("\nTIPO DO PRODUTO:\n\n" +
               "0 _ VOLTAR\n" +
               "1 _ RAM\n" +
               "2 _ SSD\n" +
               "3 _ HD\n" +
               "4 _ PENDRIVE\n\n");

            string menu = Console.ReadLine();

            if (menu == "0" || menu == "1" || menu == "2" || menu == "3" || menu == "4")
            {

                switch (menu)
                {
                    case "0":
                        //Console.Write("VOLTAR\n");
                        cadastrar();
                        break;
                    case "1":
                        //Console.Write("LISTA COMPLETA\n");
                        break;
                    case "2":
                        //Console.Write("BUSCA AVANÇADA\n");
                        break;
                    case "3":
                        //Console.Write("BUSCA AVANÇADA\n");
                        break;
                    case "4":
                        //Console.Write("BUSCA AVANÇADA\n");
                        dadosProd(categoria, "PenDrive");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Write("\nDigite uma opção válida de 0 a 4\n\n");
                disponiveis();
            }
        }


        public class Produto
        {
            public Produto(
                int ID,
            string GRUPO,
             string PRODUTO,
             string DESCRICAO,
             string MARCA,
             string MODELO,
             string NS,
             int DISPONIBILIDADE,
             string PRATELEIRA,
             double vlCOMPRA,
             double vlVENDA,
             double vlLUCRO

                )
            {
                this.ID = ID;
                this.GRUPO = GRUPO;
                this.PRODUTO = PRODUTO;
                this.DESCRICAO = DESCRICAO;
                this.MARCA = MARCA;
                this.MODELO = MODELO;
                this.NS = NS;
                this.DISPONIBILIDADE = DISPONIBILIDADE;
                this.PRATELEIRA = PRATELEIRA;
                this.vlCOMPRA = vlCOMPRA;
                this.vlVENDA = vlVENDA;
                this.vlLUCRO = vlLUCRO;
            }
            public int ID { get; set; }
            public string GRUPO { get; set; }
            public string PRODUTO { get; set; }
            public string DESCRICAO { get; set; }
            public string MARCA { get; set; }
            public string MODELO { get; set; }
            public string NS { get; set; }
            public int DISPONIBILIDADE { get; set; }
            public string PRATELEIRA { get; set; }
            public double vlCOMPRA { get; set; }
            public double vlVENDA { get; set; }
            public double vlLUCRO { get; set; }




            /*
            public Produto(
                int ID ,
            string GRUPO ,
             string PRODUTO ,
             string DESCRICAO,
             string MARCA,
             string MODELO,
             string NS,
             int DISPONIBILIDADE,
             string PRATELEIRA,
             double vlCOMPRA,
             double vlVENDA,
             double vlLUCRO
                )
           
            {
                this.ID = ID;
                this.GRUPO = GRUPO;
                this.PRODUTO = PRODUTO;
                this.DESCRICAO = DESCRICAO;
                this.MARCA = MARCA;
                this.MODELO = MODELO;
                this.NS = NS;
                this.DISPONIBILIDADE = DISPONIBILIDADE;
                this.PRATELEIRA = PRATELEIRA;
                this.vlCOMPRA = vlCOMPRA;
                this.vlVENDA = vlVENDA;
                this.vlLUCRO = vlLUCRO;
            }*/


        }

        public static void readFile()
        {
            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            /*
            int counter = 0;

            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\Flavio\Desktop\test.txt"))
            {
                System.Console.WriteLine(line);
                counter++;
            }

            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();*/
        }

        public static void listar()
        {
            var listOfProd = new List<Produto>();

            foreach (var elemento in listOfProd)
            {
                Console.WriteLine(elemento.ID);
                Console.WriteLine(elemento.GRUPO);
            }
        }


    }
}
