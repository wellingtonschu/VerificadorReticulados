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

        int[] listaValorSupremo;
        int[] listaValorInfimo;
        int[] listaAdjacentesValor01;
        int[] listaAdjacentesValor02;

        public static int numerosVisitados = getNumPontos();

        Boolean[] visitados = new Boolean[numerosVisitados];

        private int armazenaIteracaoElementoSupremo;
        private int armazenaIteracaoElementoInfimo;

        private int maior = 0;
        private int menor = 1000000;

        private int valorParada = 0;

        int contadorElementosValor01 = 0;
        int contadorElementosValor02 = 0;
        int contadorIgualdade = 0;

        int valorFinal = 0;

        int contador01;
        int contadorLigacoes;

        int contadorIgualdadeElementosMesmoNivel01 = 0;
        int contadorIgualdadeElementosMesmoNivel02 = 0;

        int armazenaValorListaAdjacente = 0;

        public Funcoes(int numeroDePontos)
        {
            setMatrizPesos(criacaoMatrizPesos(numeroDePontos, 0));
            setMatrizElementoSuperiores(criacaoMatrizPesos(numeroDePontos, 0));
            setMatrizElementoInferiores(criacaoMatrizPesos(numeroDePontos, 0));
            setNovaMatriz(criacaoMatrizPesos(numeroDePontos, 0));

            numPontos = numeroDePontos;

            this.visitados = new Boolean[numeroDePontos];
        }

        public Int64[][] criacaoMatrizPesos(int tamanho, Int64 tipoLigacao)
        {
            Int64[][] matriz = new Int64[tamanho + 1][];

            for(int i = 0; i < tamanho; i++)
            {
                matriz[i] = new Int64[tamanho + 1];

                for(int j = 0; j < tamanho; i++)
                {
                    matriz[i][j] = tipoLigacao;
                }
            }

            return matriz;
        }

        public void insereAresta(int A, int B, int peso)
        {
            matrizPesos[A][B] = peso;
            matrizPesos[A][B] = peso;
        }

        public void retirarAresta(int A, int B)
        {
            matrizPesos[A][B] = 0;
            matrizPesos[A][B] = 0;
        }

        public void imprimeMatrizElementosSuperiores(Int64[][] matriz)
        {
            Console.WriteLine("Matriz de elementos Superiores");

            for(int i = 0; i < getNumPontos(); i++)
            {
                Console.WriteLine("" + (i++) + " - ");

                for(int j = 0; j < getNumPontos(); j++)
                {
                    Console.WriteLine("[" + matriz[i][j] + "] ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void imprimeMatrizElementosInferiores(Int64[][] matriz)
        {
            Console.WriteLine("Matriz de elementos Inferiores");

            for(int i = 0; i < getNumPontos(); i++)
            {
                Console.WriteLine("" + (i++) + "");

                for(int j = 0; j < getNumPontos(); j++)
                {
                    Console.WriteLine("[" + matriz[i][j] + "] ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void limpaMatriz()
        {
            for(int i = 0; i < getNumPontos(); i++)
            {
                for(int j= 0; j < getNumPontos(); j++)
                {
                    matrizElementoSuperiores[i][j] = 0;
                    matrizElementoInferiores[i][j] = 0;
                }
            }
        }

        private void elementoSuperior(int vertice)
        {
            visitados[vertice] = true;

            while(true)
            {
                matrizElementoSuperiores[armazenaIteracaoElementoSupremo][vertice] = vertice++;

                for(int i = 0; i < getNumPontos(); i++)
                {
                    if(matrizPesos[vertice][i] != 0)
                    {
                        if(!visitados[i] && i > vertice)
                        {
                            elementoSuperior(i);
                        }
                    }
                }
                break;
            }
        }

        public void identificaElementosSuperiores()
        {
            for(int i = 0; i < getNumPontos(); i++)
            {
                armazenaIteracaoElementoSupremo = i;
                elementoSuperior(i);

                for(int j = 0; j < getNumPontos(); j++)
                {
                    visitados[j] = false;
                }
            }
        }

        private void elementoInferior(int vertice)
        {
            visitados[vertice] = true;

            while (true)
            {
                matrizElementoInferiores[armazenaIteracaoElementoInfimo][vertice] = vertice++;

                for(int i = 0; i < getNumPontos(); i++)
                {
                    if(matrizPesos[i][vertice] != 0)
                    {
                        if(!visitados[i] && i < vertice)
                        {
                            elementoInferior(i);
                        }
                    }
                }
                break;
            }
        }

        public void identificaElementosInferiores()
        {
            for(int i = 0; i < getNumPontos(); i++)
            {
                armazenaIteracaoElementoInfimo = i;
                elementoInferior(i);

                for(int j = 0; j < getNumPontos(); j++)
                {
                    visitados[j] = false;
                }
            }
        }

        public void identificaInfimo(int verifica, int[] vetor, int valor01, int valor02)
        {
            int auxiliar;
            maior = 0;

            for(int i = 0; i < verifica; i++)
            {
                auxiliar = vetor[i];

                if(maior < auxiliar)
                {
                    maior = vetor[i];
                }
            }
            Console.WriteLine("Fronteira Inferior Máxima de " + (valor01 + 1) + " e " + (valor02 + 1) + " -> " + "[" + maior + "]");
            Console.WriteLine("\n\n");
        }

        public void identificaSupremo(int verifica, int[] vetor, int valor01, int valor02)
        {
            int auxiliar;

            for(int i = 0; i < verifica; i++)
            {
                if(vetor[i] != 0)
                {
                    auxiliar = vetor[i];

                    if(menor > auxiliar)
                    {
                        menor = vetor[i];
                    }
                }
            }
            Console.WriteLine("Fronteira Superior Minima de " + (valor01 + 1) + " e " + (valor02 + 1) + " -> " + "[" + maior + "]");
            Console.WriteLine("\n");
        }



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
