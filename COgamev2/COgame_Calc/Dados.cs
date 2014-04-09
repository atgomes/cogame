using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COgame_Calc
{
    public class Dados
    {
        //recursos
        public double metal;
        public double cristal;
        public double deuterio;
        public double[,] recursos;
        //coordenadas
        public int[] galaxia;
        public int[] sistema;
        public int[] slot;
        public int dest; //o seu valor determina qual o planeta considerado como destina para efeitos de calculos de consumo
        //cargueiros
        public int cargos; //capacidade de carga
        public int[] qtCargos; //quantidade de cargueiros em cada planeta
        //metodo de distribuição
        public int metodo;
        //nomes planetas
        public string[] nomesPlanetas;
        //indice dos planetas na lista (indices associados aos nomes)
        public int[] indices;

        public Dados()
        {
            metal = 0;
            cristal = 0;
            deuterio = 0;
            recursos = new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 } };
            galaxia = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            sistema = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            slot = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            dest = 0;
            cargos = 25000;
            qtCargos = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            metodo = 1;
            nomesPlanetas = new string[15];
            nomesPlanetas[0] = "Planeta 1";
            indices = new int[15];
        }
        public void Reset()
        {
            metal = 0;
            cristal = 0;
            deuterio = 0;
            recursos = new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 } };
            galaxia = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            sistema = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            slot = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            dest = 0;
            cargos = 25000;
            qtCargos = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            metodo = 1;
            nomesPlanetas = new string[15];
            nomesPlanetas[0] = "Planeta 1";
            indices = new int[15];
        }
    }
}
