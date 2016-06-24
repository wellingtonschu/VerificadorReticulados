using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificadorReticulados
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 numeroDeElementos;
            Int64 opcao = 0;
            Int64 elemento01;
            Int64 elemento02;

            Console.WriteLine("Informe a quantidade de elementos: ");
            numeroDeElementos = Convert.ToInt64(Console.ReadLine());

            Funcoes func = new Funcoes();

            for(Int64 i = 0; i < numeroDeElementos; i++)
            {
                func.insereAresta(i, i, i);
            }

            while(opcao != 5)
            {
                Console.WriteLine("\nOpções: ");
                Console.WriteLine("1 - Inserir Relação");
                Console.WriteLine("2 - Eliminar Relação");
                Console.WriteLine("3 - Consultar Relação");
                Console.WriteLine("4 - Verificar Reticulado");
                Console.WriteLine("5 - Sair");
                opcao = Convert.ToInt64(Console.ReadLine());

                if(opcao == 1)
                {
                    Console.WriteLine("Informe o primeiro elemento: ");
                    elemento01 = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Informe o segundo elemento: ");
                    elemento02 = Convert.ToInt64(Console.ReadLine());

                    func.insereAresta((elemento01 - 1), (elemento02 - 1), 1);
                }
                else if(opcao == 2)
                {

                }
            }
        }
    }
}
