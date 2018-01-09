using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ControlarSonda
    {
        public static void MovimentarSonda(SondaVO sonda, char[] movimentos)
        {
            foreach (char movimento in movimentos)
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

        public static void SetPosicaoInicialSonda(SondaVO sonda, int latitude, int longitude, char direcao)
        {
            sonda.SetLatitude(latitude);
            sonda.SetLongitude(longitude);

            switch (direcao)
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

        private static void MoverSonda(SondaVO sonda)
        {
            switch (sonda.Direcao)
            {
                case eDirecao.Norte:
                    sonda.SetLongitude(sonda.Longitude + 1);
                    break;
                case eDirecao.Oeste:
                    sonda.SetLatitude(sonda.Latitude - 1);
                    break;
                case eDirecao.Sul:
                    sonda.SetLongitude(sonda.Longitude - 1);
                    break;
                case eDirecao.Leste:
                    sonda.SetLatitude(sonda.Latitude + 1);
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

    }
}
