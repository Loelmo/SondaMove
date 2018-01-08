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
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("************************| MISSÃO MARTE |*****************************");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("********************| CONTROLE DAS SONDAS |**************************");
            Console.WriteLine("---------------------------------------------------------------------");


            int opcao;
            do
            {
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
            sonda.Malha = new MalhaVO();
            DefinirMalha(sonda);
            DefinirPosicaoInicialSonda(sonda);
            MovimentarSonda(sonda);

            Console.WriteLine("Posição Atual da Sonda");
            Console.WriteLine(String.Concat(sonda.Latitude.ToString(), sonda.Longitude.ToString(), sonda.Direcao.ToString()));
        }

        private static void posicionarSondaMars2()
        {
            SondaMars2 sonda = new SondaMars2();
            sonda.Malha = new MalhaVO();
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
            foreach (char movimento in arr)
            {
                switch (movimento)
                {
                    case 'M':
                        MoverSonda(sonda);
                        break;

                    default:
                        GirarSonda(sonda, movimento);
                        break;
                }
            }
        }
        private static void GirarSonda(SondaVO sonda, char direcaogiro)
        {
            switch (direcaogiro)
            {
                case 'L':
                    GirarEsquerda(sonda);
                    break;
                case 'R':
                    GirarDireita(sonda);
                    break;
                default:
                    Console.WriteLine("Direção Incorreta");
                    break;
            }
        }

        private static void GirarEsquerda(SondaVO sonda)
        {
            switch (sonda.Direcao)
            {
                case eDirecao.Norte:
                    sonda.Direcao = eDirecao.Oeste;
                    break;
                case eDirecao.Oeste:
                    sonda.Direcao = eDirecao.Sul;
                    break;
                case eDirecao.Sul:
                    sonda.Direcao = eDirecao.Leste;
                    break;
                case eDirecao.Leste:
                    sonda.Direcao = eDirecao.Norte;
                    break;
            }
        }

        private static void GirarDireita(SondaVO sonda)
        {
            switch (sonda.Direcao)
            {
                case eDirecao.Norte:
                    sonda.Direcao = eDirecao.Leste;
                    break;
                case eDirecao.Leste:
                    sonda.Direcao = eDirecao.Sul;
                    break;
                case eDirecao.Sul:
                    sonda.Direcao = eDirecao.Oeste;
                    break;
                case eDirecao.Oeste:
                    sonda.Direcao = eDirecao.Norte;
                    break;
            }
        }

        private static void MoverSonda(SondaVO sonda)
        {
            switch (sonda.Direcao)
            {
                case eDirecao.Norte:
                    sonda.SetLongitude(sonda.Longitude+ 1);
                    break;
                case eDirecao.Oeste:
                    sonda.SetLatitude(sonda.Latitude- 1);
                    break;
                case eDirecao.Sul:
                    sonda.SetLongitude(sonda.Longitude- 1);
                    break;
                case eDirecao.Leste:
                    sonda.SetLatitude(sonda.Latitude+ 1);
                    break;
            }
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
            arr = Console.ReadLine().ToUpper().ToCharArray();
            sonda.SetLatitude(Int32.Parse(arr[0].ToString()));
            sonda.SetLongitude(Int32.Parse(arr[1].ToString()));

            switch (arr[2])
            {
                case 'N':
                    sonda.Direcao = eDirecao.Norte;
                    break;

                case 'E':
                    sonda.Direcao = eDirecao.Leste;
                    break;

                case 'S':
                    sonda.Direcao = eDirecao.Sul;
                    break;

                case 'W':
                    sonda.Direcao = eDirecao.Oeste;
                    break;
            }
}

    }

     
}
