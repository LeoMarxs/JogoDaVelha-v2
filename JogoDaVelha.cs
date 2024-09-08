using System;

namespace JogoDaVelha
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; 
        static int choice;
        static int flag = 0; 
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+-----------------------------+\n"
                + "| BEM VINDO AO JOGO DA VELHA! |\n"
                + "+--------------+--------------+\n"
                + "| Jogador 1: X | Jogador 2: O |\n"
                + "+--------------+--------------+");


                Console.ForegroundColor = ConsoleColor.Green;
                Board();

                if (player % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                     Console.WriteLine("+-----------------------------+\n"
                    + "|      Turno do Jogador 2     |\n"
                    + "+-----------------------------+");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("+-----------------------------+\n"
                    + "|      Turno do Jogador 1     |\n"
                    + "+-----------------------------+");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                choice = int.Parse(Console.ReadLine());

           
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  +-----------------------------+\n"
                    + "  |            BURRO!           |\n"
                    + "  +-----------------------------+");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("A linha {0} já está marcada com um {1}.", choice, arr[choice]);
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Espere 5 segundos para continuar...");
                    System.Threading.Thread.Sleep(5000);
                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+-----------------------------+\n"
                + "|       Jogador {0} ganhou!     |\n"
                + "+-----------------------------+", (player % 2) + 1);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+-----------------------------+\n"
                + "|            Empate!          |\n"
                + "+-----------------------------+");
            }

            Console.WriteLine("Deseja recomeçar o jogo? (S/N)");
            char restartChoice = Console.ReadLine().ToUpper()[0];
            if (restartChoice == 'S')
            {
                ResetBoard();
                Main(args);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|                             |            ______________ "); 
                Console.WriteLine("|                             |            |            | ");
                Console.WriteLine("|                             |            |Desenvolvido| ");
                Console.WriteLine("|          Obrigado           |            |    por     | ");
                Console.WriteLine("|            por              |            |  LeoMarxs  | ");
                Console.WriteLine("|           jogar!            |            |____________| ");
                Console.WriteLine("|                             |           ( __/) ||       ");
                Console.WriteLine("|                             |           (•ㅅ•) ||       ");
                Console.WriteLine("|                             |           /    づ         ");
                Console.WriteLine("+-----------------------------+\n");  
            }
        }

        private static void ResetBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                arr[i] = (char)(i + '0');
            }
            player = 1;
            flag = 0;
        }

        private static void Board()
        {
            Console.WriteLine("|           |     |           |");
            Console.WriteLine("|        {0}  |  {1}  |  {2}        |", arr[1], arr[2], arr[3]);
            Console.WriteLine("|      _____|_____|_____      | ");
            Console.WriteLine("|           |     |           |");
            Console.WriteLine("|        {0}  |  {1}  |  {2}        |", arr[4], arr[5], arr[6]);
            Console.WriteLine("|      _____|_____|_____      | ");
            Console.WriteLine("|           |     |           |");
            Console.WriteLine("|        {0}  |  {1}  |  {2}        |", arr[7], arr[8], arr[9]);
            Console.WriteLine("|           |     |           |");
        }

        private static int CheckWin()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }


            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }


            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }


            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }


            else
            {
                return 0;
            }
        }
    }
}
