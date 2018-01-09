using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("************************| MISSÃO MARTE |*****************************");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("********************| CONTROLE DAS SONDAS |**************************");
                Console.WriteLine("---------------------------------------------------------------------");

                Console.WriteLine("ESCOLHA UMA OPÇÃO");
                Console.WriteLine("[ 1 ] Posicionar Sonda Mars1");
                Console.WriteLine("[ 2 ] Posicionar Sonda Mars2");
                Console.WriteLine("[ 9 ] Help");
                Console.WriteLine("[ 0 ] Sair do Controle de Sondas");
                Console.WriteLine("-------------------------------------");
                Console.Write("Digite uma opção: ");

                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        posicionarSondaMars1();
                        break;
                    case 2:
                        posicionarSondaMars2();
                        break;
                    case 9:
                        Help();
                        break;
                    default:

                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);
        }

        private static void posicionarSondaMars1()
        {
            SondaMars1 sonda = new SondaMars1();
            DefinirMalha(sonda);
            DefinirPosicaoInicialSonda(sonda);
            MovimentarSonda(sonda);

            Console.WriteLine("Posição Atual da Sonda");
            Console.WriteLine(String.Concat(sonda.Latitude.ToString(), sonda.Longitude.ToString(), sonda.Direcao.ToString()));
        }

        private static void posicionarSondaMars2()
        {
            SondaMars2 sonda = new SondaMars2();
            DefinirMalha(sonda);
            DefinirPosicaoInicialSonda(sonda);
            MovimentarSonda(sonda);

            Console.WriteLine("Posição Atual da Sonda");
            Console.WriteLine(String.Concat(sonda.Latitude.ToString(), sonda.Longitude.ToString(), sonda.Direcao.ToString()));
        }

        private static void MovimentarSonda(SondaVO sonda)
        {
            Console.WriteLine(String.Concat("Informe deslocamento da Sonda ", sonda.GetNome(), ": "));
            char[] arr;
            arr = Console.ReadLine().ToUpper().ToCharArray();
            ControlarSonda.MovimentarSonda(sonda, arr);
        }   

        private static void DefinirMalha(SondaVO sonda)
        {
            Console.Write("Informe o tamanho da malha a ser explorada: ");
            char[] arr;
            arr = Console.ReadLine().ToUpper().ToCharArray();
            sonda.Malha.EixoX = Int32.Parse(arr[0].ToString());
            sonda.Malha.EixoY = Int32.Parse(arr[1].ToString());
        }

        private static void DefinirPosicaoInicialSonda(SondaVO sonda)
        {
            Console.Write(String.Concat("Informe a posição inicial da Sonda ", sonda.GetNome(), ": "));
            char[] arr;
            arr = Console.ReadLine().Replace(" ","").ToUpper().ToCharArray();
            ControlarSonda.SetPosicaoInicialSonda(sonda, Int32.Parse(arr[0].ToString()), Int32.Parse(arr[1].ToString()), arr[2]);
        }

        private static void Help()
        {
            Console.Clear();
            Console.WriteLine("Para controlar as sondas, utilise as seguintes letras:");
            Console.WriteLine("L: Para girar a sonda para a Esquerda.");
            Console.WriteLine("R: Para girar a sonda para a Direita.");
            Console.WriteLine("M: Para mover a sonda para o quadrante a frente.");


        }

    }

     
}
