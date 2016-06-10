using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificadorReticulados
{
    class Funcoes
    {
        public static int numPontos;

        private Int64[][] matrizPesos;
        private Int64[][] matrizElementoSuperiores;
        private Int64[][] matrizElementoInferiores;
        private Int64[][] novaMatriz;

        int[] listaEulariana;
        int[] listaAdjacentes;
        int[] listaValorSupremo;
        int[] listaValorInfimo;

        int[] armazenaVertice;
        int[] armazenaChegadas;

        public static int numerosVisitados = getNumPontos();

        Boolean[] visitados = new Boolean[numerosVisitados];

        private int armazenaIteracaoElementoSupremo;
        private int armazenaIteracaoElementoInfimo;

        private int varificaValoresIguais = 0;

        private int maior01 = 0;
        private int segundoMaior01 = 0;
        private int maior02 = 0;
        private int segundoMaior02 = 0;
        private int menor01 = 1000000;
        private int segundoMenor01 = 1000000;
        private int menor02 = 1000000;
        private int segundoMenor02 = 1000000;
        private int menor03 = 1000000;

        private int valorParada = 0;

        int contatarElementosValor01 = 0;
        int contatarElementosValor02 = 0;
        int contatarIgualdade = 0;

        int grau01 = 0;
        int grau02 = 0;

        int contadorImpares = 0;

        int armazenaElementoInfimo = 0;
        int armazenaElementoSupremo = 0;


        public Int64[][] getMatrizPesos()
        {
            return this.matrizPesos;
        }

        public void setMatrizPesos(Int64[][] pesos)
        {
            this.matrizPesos = pesos;
        }

        public Int64[][] getMatrizElementoSuperiores()
        {
            return this.matrizElementoSuperiores;
        }

        public void setMatrizElementoSuperiores(Int64[][] zero)
        {
            this.matrizElementoSuperiores = zero;
        }

        public Int64[][] getMatrizElementoInferiores()
        {
            return this.matrizElementoInferiores;
        }

        public void setMatrizElementoInferiores(Int64[][] zero)
        {
            this.matrizElementoInferiores = zero;
        }

        public Int64[][] getNovaMatriz()
        {
            return novaMatriz;
        }

        public void setNovaMatriz(Int64[][] novaMatriz)
        {
            this.novaMatriz = novaMatriz;
        }

        public static int getNumPontos()
        {
            return numPontos;
        }
    }
}
