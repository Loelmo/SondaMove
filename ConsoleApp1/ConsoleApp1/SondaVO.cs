using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum eDirecao
    {
        None = ' ',
        Norte = 'N',
        Leste = 'E',
        Sul = 'S',
        Oeste = 'W'
    }
    class SondaVO
    {
        private string nome;
        private int latitude;
        private int longitude;
        private eDirecao direcao;
        private MalhaVO malha;

        public int Latitude => latitude;

        public void SetLatitude(int value)
        {
            if (value < 0)
                latitude = 0;
            else if (value > this.Malha.EixoX)
                latitude = this.Malha.EixoX;
            else
              latitude = value;
        }

        public int Longitude => longitude;

        public void SetLongitude(int value)
        {
            if (value < 0)
                longitude = 0;
            else if (value > this.Malha.EixoY)
                longitude = this.Malha.EixoY;
            else
                longitude = value;
        }

        public eDirecao Direcao { get => direcao; set => direcao = value; }

        public string GetNome()
        {
            return nome;
        }

        public virtual void SetNome(string value)
        {
            nome = value;
        }

        internal MalhaVO Malha { get => malha; set => malha = value; }
    }

    class SondaMars1 : SondaVO
    {
        public override void SetNome(string value)
        {
            base.SetNome("MARS1");
        }
    }

    class SondaMars2 : SondaVO
    {
        public override void SetNome(string value)
        {
            base.SetNome("MARS2");
        }
    }
}
        