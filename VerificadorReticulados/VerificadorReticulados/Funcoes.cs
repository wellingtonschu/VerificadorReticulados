using System;

namespace VerificadorReticulados
{
    class Funcoes
    {
        public static int numNodos;

        private static Int64[][] matrizPesos;
        private static Int64[][] matrizElementoSuperiores;
        private static Int64[][] matrizElementoInferiores;
        private static Int64[][] novaMatriz;

        static Int64[] listaValorSupremo;
        static Int64[] listaValorInfimo;
        static Int64[] listaAdjacentesValor01;
        static Int64[] listaAdjacentesValor02;

        public static int numerosVisitados = getNumNodos();

        static Boolean[] visitados = new Boolean[numerosVisitados];

        private static int armazenaIteracaoElementoSupremo;
        private static int armazenaIteracaoElementoInfimo;

        private static Int64 maior = 0;
        private static Int64 menor = 1000000;

        private static int valorParada = 0;

        static int contadorElementosValor01 = 0;
        static int contadorElementosValor02 = 0;
        static int contadorIgualdade = 0;

        static int valorFinal = 0;

        static int contador01;
        static int contadorLigacoes01;
        static int contadorLigacoes02;

        static int contadorIgualdadeElementosMesmoNivel01 = 0;
        static int contadorIgualdadeElementosMesmoNivel02 = 0;

        static Int64 armazenaValorListaAdjacente = 0;

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

        public void insereAresta(Int64 A, Int64 B, Int64 peso)
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

            for(int i = 0; i < getNumNodos(); i++)
            {
                Console.WriteLine("" + (i++) + " - ");

                for(int j = 0; j < getNumNodos(); j++)
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

            for(int i = 0; i < getNumNodos(); i++)
            {
                Console.WriteLine("" + (i++) + "");

                for(int j = 0; j < getNumNodos(); j++)
                {
                    Console.WriteLine("[" + matriz[i][j] + "] ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void limpaMatriz()
        {
            for(int i = 0; i < getNumNodos(); i++)
            {
                for(int j= 0; j < getNumNodos(); j++)
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

                for(int i = 0; i < getNumNodos(); i++)
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
            for(int i = 0; i < getNumNodos(); i++)
            {
                armazenaIteracaoElementoSupremo = i;
                elementoSuperior(i);

                for(int j = 0; j < getNumNodos(); j++)
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

                for(int i = 0; i < getNumNodos(); i++)
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
            for(int i = 0; i < getNumNodos(); i++)
            {
                armazenaIteracaoElementoInfimo = i;
                elementoInferior(i);

                for(int j = 0; j < getNumNodos(); j++)
                {
                    visitados[j] = false;
                }
            }
        }

        public void identificaInfimo(Int64 verifica, Int64[] vetor, Int64 valor01, Int64 valor02)
        {
            Int64 auxiliar;
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

        public void identificaSupremo(Int64 verifica, Int64[] vetor, Int64 valor01, Int64 valor02)
        {
            Int64 auxiliar;

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

        public void listaAdjacentes(int vertice, int primeiroOuSegundo)
        {
            int contadorListaAdjacentes = 0;
            
            if(primeiroOuSegundo == 1)
            {
                listaAdjacentesValor01 = new Int64[getNumNodos()];

                for(int i = 0; i < getNumNodos(); i++)
                {
                    if(matrizPesos[vertice][i] == 1)
                    {
                        listaAdjacentesValor01[contadorListaAdjacentes] = (i + 1);
                        contadorListaAdjacentes++;
                    }
                }
            }
            else
            {
                listaAdjacentesValor02 = new Int64[getNumNodos()];

                for(int i = 0; i < getNumNodos(); i++)
                {
                    if(matrizPesos[vertice][i] == 1)
                    {
                        listaAdjacentesValor02[contadorListaAdjacentes] = (i + 1);
                        contadorListaAdjacentes++;
                    }
                }
            }
        }

        public void identificaFronteiraSuperiorMinima(int valor01, int valor02)
        {
            listaValorSupremo = new Int64[getNumNodos()];

            contadorElementosValor01 = 0;
            contadorElementosValor02 = 0;
            contadorIgualdade = 0;
            contadorIgualdadeElementosMesmoNivel01 = 0;
            armazenaValorListaAdjacente = 0;

            for(int i = 0; i < getNumNodos(); i++)
            {
                listaValorSupremo[i] = 0;
            }

            for(int i = 0; i < getNumNodos(); i++)
            {
                if(matrizElementoSuperiores[valor01][i] != 0 && matrizElementoSuperiores[valor01][i] != (valor01 + 1))
                {
                    contadorElementosValor01++;
                }
            }

            for (int i = 0; i < getNumNodos(); i++)
            {
                if (matrizElementoSuperiores[valor02][i] != 0 && matrizElementoSuperiores[valor02][i] != (valor02 + 1))
                {
                    contadorElementosValor02++;
                }
            }

            for(int i = 0; i < getNumNodos(); i++)
            {
                if((matrizElementoSuperiores[valor01][i] != 0) && (matrizElementoSuperiores[valor01][i] == matrizElementoSuperiores[valor02][i]))
                {
                    listaValorSupremo[contadorIgualdade] = matrizElementoSuperiores[valor01][i];
                    contadorIgualdade++;
                }
            }

            if(contadorIgualdade == 0)
            {
                Console.WriteLine("Não existe fronteira superior para os elementos " + (valor01 + 1) + " e " + (valor02 + 1) + ".\n");
            }
            else
            {
                Console.WriteLine("Fronteira Superior dos elementos " + (valor01 + 1) + " e " + (valor02 + 1) + ": ");
                for(int i = 0; i < contadorIgualdade; i++)
                {
                    if(listaValorSupremo[i] != 0)
                    {
                        Console.WriteLine("[" + (listaValorSupremo[i]) + "]");
                    }
                }
                Console.WriteLine("\n");

                listaAdjacentes(valor01, 1);
                listaAdjacentes(valor02, 2);

                for(int j = 0; j < getNumNodos(); j++)
                {
                    armazenaValorListaAdjacente = 0;

                    if(listaAdjacentesValor01[j] > (valor01 + 1) && listaAdjacentesValor01[j] > (valor02 + 1))
                    {
                        armazenaValorListaAdjacente = listaAdjacentesValor01[j];
                    }

                    if(armazenaValorListaAdjacente != 0)
                    {
                        for(int i = 0; i < getNumNodos(); i++)
                        {
                            if(armazenaValorListaAdjacente == listaAdjacentesValor02[i])
                            {
                                contadorIgualdadeElementosMesmoNivel01++;
                            }
                        }
                    }
                }

                if(contadorIgualdadeElementosMesmoNivel01 == 2)
                {
                    Console.WriteLine("Não possui fronteira superior mínima.");
                }
                else
                {
                    identificaSupremo(contadorIgualdade, listaValorSupremo, valor01, valor02);
                }
            }
        }

        public void indetificaFronteiraInferiorMaxima(int valor01, int valor02)
        {
            listaValorInfimo = new Int64[getNumNodos()];

            contadorElementosValor01 = 0;
            contadorElementosValor02 = 0;
            contadorIgualdade = 0;
            contadorIgualdadeElementosMesmoNivel01 = 0;
            armazenaValorListaAdjacente = 0;

            for(int i = 0; i < getNumNodos(); i++)
            {
                listaValorInfimo[i] = 0;
            }

            for(int i = 0; i < getNumNodos(); i++)
            {
                if(matrizElementoInferiores[valor01][i] != 0 && matrizElementoInferiores[valor01][i] != (valor01 + 1))
                {
                    contadorElementosValor01++;
                }
            }

            for(int i = 0; i < getNumNodos(); i++)
            {
                if (matrizElementoInferiores[valor02][i] != 0 && matrizElementoInferiores[valor02][i] != (valor02 + 1))
                {
                    contadorElementosValor02++;
                }
            }

            for(int i = 0; i < getNumNodos(); i++)
            {
                if((matrizElementoInferiores[valor01][i] != 0) && (matrizElementoInferiores[valor01][i] == matrizElementoInferiores[valor02][i]))
                {
                    listaValorInfimo[contadorIgualdade] = matrizElementoInferiores[valor01][i];
                    contadorIgualdade++;
                }
            }

            if(contadorIgualdade == 0)
            {
                Console.WriteLine("Não existe fronteira inferior para os elementos " + (valor01 + 1) + " e " + (valor02 + 1) + ".\n");
            }
            else
            {
                Console.WriteLine("Fronteira Inferior dos elementos " + (valor01 + 1) + " e " + (valor02 + 1) + ": ");

                for(int i = 0; i < contadorIgualdade; i++)
                {
                    if(listaValorInfimo[i] != 0)
                    {
                        Console.WriteLine("[" + (listaValorInfimo[i]) + "]");
                    }
                }
                Console.WriteLine("\n");

                listaAdjacentes(valor01, 1);
                listaAdjacentes(valor02, 2);

                for(int i = 0; i < getNumNodos(); i++)
                {
                    armazenaValorListaAdjacente = 0;

                    if(listaAdjacentesValor01[i] < (valor01 + 1) && listaAdjacentesValor01[i] < (valor02 + 1) && listaAdjacentesValor01[i] != 0 && listaAdjacentesValor01[i] != 0)
                    {
                        armazenaValorListaAdjacente = listaAdjacentesValor01[i];
                    }

                    if(armazenaValorListaAdjacente != 0)
                    {
                        for(int j = 0; j < getNumNodos(); j++)
                        {
                            if(armazenaValorListaAdjacente == listaAdjacentesValor02[j])
                            {
                                contadorIgualdadeElementosMesmoNivel01++;
                            }
                        }
                    }
                }
                if(contadorIgualdadeElementosMesmoNivel01 == 2)
                {
                    Console.WriteLine("Não possui fronteira inferior máxima.");
                }
                else
                {
                    identificaInfimo(contadorIgualdade, listaValorInfimo, valor01, valor02);
                }
            }
        }

        public void complementoVerificacaoReticulado(int valor01, int valor02)
        {
            listaValorInfimo = new Int64[getNumNodos()];

            contadorElementosValor01 = 0;
            contadorElementosValor02 = 0;
            contadorIgualdade = 0;
            contadorIgualdadeElementosMesmoNivel01 = 0;
            contadorIgualdadeElementosMesmoNivel02 = 0;

            listaAdjacentes(valor01, 1);
            listaAdjacentes(valor02, 2);

            for(int i = 0; i < getNumNodos(); i++)
            {
                armazenaValorListaAdjacente = 0;

                if(listaAdjacentesValor01[i] < (valor01 + 1) && listaAdjacentesValor02[1] < (valor02 + 1) && listaAdjacentesValor01[i] != 0 && listaAdjacentesValor01[i] != 0)
                {
                    armazenaValorListaAdjacente = listaAdjacentesValor01[i];
                }

                if(armazenaValorListaAdjacente != 0)
                {
                    for(int j = 0; j < getNumNodos(); j++)
                    {
                        if(armazenaValorListaAdjacente == listaAdjacentesValor02[j])
                        {
                            contadorIgualdadeElementosMesmoNivel01++;
                        }
                    }
                }
            }

            listaAdjacentes(valor01, 1);
            listaAdjacentes(valor02, 2);

            for(int i = 0; i < getNumNodos(); i++)
            {
                armazenaValorListaAdjacente = 0;

                if(listaAdjacentesValor01[i] > (valor01 + 1) && listaAdjacentesValor01[i] > (valor02 + 1))
                {
                    armazenaValorListaAdjacente = listaAdjacentesValor02[i];
                }

                if(armazenaValorListaAdjacente != 0)
                {
                    for(int j = 0; j < getNumNodos(); j++)
                    {
                        if(armazenaValorListaAdjacente == listaAdjacentesValor02[i])
                        {
                            contadorIgualdadeElementosMesmoNivel02++;
                        }
                    }
                }
            }

            if (contadorIgualdadeElementosMesmoNivel01 == 2 || contadorIgualdadeElementosMesmoNivel02 == 2)
            {
                valorParada = 1;
            }
        }

        public void verificaReticulado()
        {
            valorFinal = getNumNodos();
            contador01 = 0;
            contadorLigacoes01 = 0;
            contadorLigacoes02 = 0;
            valorParada = 0;

            for(int i = 0; i < valorFinal; i++)
            {
                if(matrizElementoSuperiores[i][valorFinal - 1] == getNumNodos())
                {
                    contadorLigacoes01++;
                }
            }

            for(int i = 0; i < valorFinal; i++)
            {
                if(matrizElementoInferiores[i][0] == 1)
                {
                    contadorLigacoes02++;
                }
            }

            if((contadorLigacoes01 == valorFinal) && (contadorLigacoes02 == valorFinal))
            {
                for(int i = 0; i < valorFinal; i++)
                {
                    for(int j = 0; j < valorFinal; j++)
                    {
                        if((contador01 != i) && (contador01 > 1))
                        {
                            if(valorParada != 1)
                            {
                                complementoVerificacaoReticulado(i, contador01);
                            }
                        }
                        contador01++;
                    }
                    contador01 = 0;
                }
                if(valorParada != 1)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("É Reticulado.");
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Não é reticulado, pois não existe fronteira inferior máxima e fronteira superior mínima em todos os pares de elementos.");
                }
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("Não é reticulado, pois não possui limite mínimo ou limite máximo.");
            }

        }

        public static int getNumNodos()
        {
            return numNodos;
        }
    }
}
