using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace COgame_Calc
{
    public class COgameCalcSimple
    {
        //variaveis
        //public double[,] resultado;
        public double[] total;
        private double[] temp;
        public string[] mostra;
        //construtor
        public COgameCalcSimple(double metal, double cristal, double deuterio)
        {
            total = new double[] { metal, cristal, deuterio };
            temp = total;
            mostra = new string[16];
        }
        //métodos
        //ORDENAÇÃO
        private void OrdenaRecursos(Dados entradas, int tipo)
        {
            //nota: tipo = 0->metal
            //      tipo = 1->cristal
            //      tipo = 2->deuterio
            //ordena recursos 
            int i,k,j;
            double[] temp = new double[3];
            string tempS = "";
            int tempI;
            for (i = 0; i < entradas.recursos.GetUpperBound(0)+1; i++)//percorre vector para baixo
            {
                for (k = entradas.recursos.GetUpperBound(0); k > i; k--)//percorre vector para cima
                {
                    if (entradas.recursos[k, tipo] >= entradas.recursos[i, tipo])
                    {
                        for (j = 0; j < 3; j++)//ordena recursos
                        {
                            temp[j] = entradas.recursos[k, j];
                            entradas.recursos[k, j] = entradas.recursos[i, j];
                            entradas.recursos[i, j] = temp[j];
                        }
                        tempS = entradas.nomesPlanetas[k];//ordena nomes de planetas
                        entradas.nomesPlanetas[k] = entradas.nomesPlanetas[i];
                        entradas.nomesPlanetas[i] = tempS;

                        tempI = entradas.indices[k];//ordena indices dos planetas
                        entradas.indices[k] = entradas.indices[i];
                        entradas.indices[i] = tempI;

                        //actualiza destino
                        if (entradas.dest == k)//se o planeta no indice k era o p. de destino
                        {
                            entradas.dest = i;
                        }
                        if (entradas.dest == i)//se o planeta no indice i era o p. de destino
                        {
                            entradas.dest = k;
                        }
                    }
                }
            }
        }
        //DISTRIBUIÇÃO SIMPLES (ORDEM DE ENTRADAS)
        public void DistribuicaoSimples(Dados entradas, double[,] resultado)
        {
            int tamMax = resultado.GetUpperBound(0)+1;
            //retira primeiro os recursos do planeta de destino
            int k, j;
            for (j = 0; j < 3; j++)
            {
                if (entradas.recursos[entradas.dest, j] <= temp[j])
                {
                    resultado[entradas.dest, j] = entradas.recursos[entradas.dest, j];
                    temp[j] -= entradas.recursos[entradas.dest, j];
                }
                else
                {
                    resultado[entradas.dest, j] = temp[j];
                    temp[j] = 0;
                }
            }
            //para os restantes planetas
            for (k = 0; k < tamMax; k++)
            {
                if (k != entradas.dest)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (entradas.recursos[k, j] <= temp[j]) //verificação recursos
                        {
                            //if (entradas.recursos[k,j] <
                            resultado[k, j] = entradas.recursos[k, j];
                            temp[j] -= entradas.recursos[k, j];
                        }
                        else
                        {
                            resultado[k, j] = temp[j];
                            temp[j] = 0;
                        }
                    }
                }
                //resultado exacto para o numero de cargueiros necessario
                resultado[k, 3] = (resultado[k, 0] + resultado[k, 1] + resultado[k, 2]) / entradas.cargos;
                //verificação do tipo de viagem e calculo do consumo
                double cgAdi = 0;
                if (entradas.galaxia[entradas.dest] - entradas.galaxia[k] != 0)//galaxias diferentes
                {
                    double consumo = CalculaConsumo(resultado[k, 3], entradas.cargos, 1, entradas.galaxia[k], entradas.galaxia[entradas.dest]);
                    //calculo de cargos adicionais (previous)
                    //if (Math.Ceiling(resultado[k, 3]) * entradas.cargos < resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo)
                    //{
                    //    //cargueiros não chegam
                    //    cgAdi = consumo / entradas.cargos;
                    //}
                    //calculo de cargos adicionais (7/março/2014)
                    double tCarg = resultado[k, 3];
                    double tRec = resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo;
                    double espacoLivre;
                    bool good = false;
                    while (!good)
                    {
                        //espaço livre = cargos*espaço/cargo - soma de recursos&consumo
                        espacoLivre = Math.Ceiling(tCarg * entradas.cargos - tRec);
                        if (espacoLivre < 0)
                        {
                            tCarg = Math.Ceiling(tCarg + consumo / entradas.cargos);
                            tRec = tRec - consumo;
                            consumo = CalculaConsumo(tCarg, entradas.cargos, 1, entradas.galaxia[k], entradas.galaxia[entradas.dest]);
                            tRec = tRec + consumo;
                            good = false;
                        }
                        else
                        {
                            cgAdi = tCarg - resultado[k, 3];
                            good = true;
                        }
                    }
                }
                else//mesma galaxia
                {
                    if (entradas.sistema[entradas.dest] - entradas.sistema[k] != 0)//sistemas diferentes
                    {
                        double consumo = CalculaConsumo(resultado[k, 3], entradas.cargos, 2, entradas.sistema[k], entradas.sistema[entradas.dest]);
                        //calculo de cargos adicionais (previous)
                        //if (Math.Ceiling(resultado[k, 3]) * entradas.cargos < resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo)
                        //{
                        //    //cargueiros não chegam
                        //    cgAdi = consumo / entradas.cargos;
                        //}
                        //calculo de cargos adicionais (7/março/2014)
                        double tCarg = resultado[k, 3];
                        double tRec = resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo;
                        double espacoLivre;
                        bool good = false;
                        while (!good)
                        {
                            //espaço livre = cargos*espaço/cargo - soma de recursos&consumo
                            espacoLivre = Math.Ceiling(tCarg * entradas.cargos - tRec);
                            if (espacoLivre < 0)
                            {
                                tCarg = Math.Ceiling(tCarg + consumo / entradas.cargos);
                                tRec = tRec - consumo;
                                consumo = CalculaConsumo(tCarg, entradas.cargos, 2, entradas.sistema[k], entradas.sistema[entradas.dest]);
                                tRec = tRec + consumo;
                                good = false;
                            }
                            else
                            {
                                cgAdi = tCarg - resultado[k, 3];
                                good = true;
                            }
                        }
                    }
                    else//mesmo sistema
                    {
                        double consumo = CalculaConsumo(resultado[k, 3], entradas.cargos, 3, entradas.slot[k], entradas.slot[entradas.dest]);
                        //calculo de cargos adicionais (previous)
                        //if (Math.Ceiling(resultado[k, 3]) * entradas.cargos < resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo)
                        //{
                        //    //cargueiros não chegam
                        //    cgAdi = consumo / entradas.cargos;
                        //}
                        //calculo de cargos adicionais (7/março/2014)
                        double tCarg = resultado[k, 3];
                        double tRec = resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo;
                        double espacoLivre;
                        bool good = false;
                        while (!good)
                        {
                            //espaço livre = cargos*espaço/cargo - soma de recursos&consumo
                            espacoLivre = Math.Ceiling(tCarg * entradas.cargos - tRec);
                            if (espacoLivre < 0)
                            {
                                tCarg = Math.Ceiling(tCarg + consumo / entradas.cargos);
                                tRec = tRec - consumo;
                                consumo = CalculaConsumo(tCarg, entradas.cargos, 3, entradas.slot[k], entradas.slot[entradas.dest]);
                                tRec = tRec + consumo;
                                good = false;
                            }
                            else
                            {
                                cgAdi = tCarg - resultado[k, 3];
                                good = true;
                            }
                        }
                    }
                }
                if (resultado[k, 3] != 0)//se houver realmente algo para transportar
                {  //            Nome Teste   99999999999 99999999999 99999999999 999999
                    mostra[0] = "PLANETA     |METAL      |CRISTAL    |DEUTÉRIO   |CARGOS\r\n";
                    if (k != entradas.dest)
                    {
                        //mostra[k + 1] = String.Format(" {0,-12}", entradas.nomesPlanetas[k])+String.Format(" {0,-12}", resultado[k, 0].ToString("0,0", CultureInfo.InvariantCulture))+
                        //        String.Format(" {0,-12}", resultado[k, 1].ToString("0,0", CultureInfo.InvariantCulture))+
                        //        String.Format(" {0,-12}", resultado[k, 2].ToString("0,0", CultureInfo.InvariantCulture))+
                        //        String.Format(" {0,-6}", Math.Ceiling(resultado[k, 3] + cgAdi).ToString("0,0", CultureInfo.InvariantCulture));
                        mostra[k + 1] = String.Format("{0,-12}", entradas.nomesPlanetas[k]) + " | " +
                            resultado[k, 0].ToString("0,0", CultureInfo.InvariantCulture) + " | " +//metal
                            resultado[k, 1].ToString("0,0", CultureInfo.InvariantCulture) + " | " +//cristal
                            resultado[k, 2].ToString("0,0", CultureInfo.InvariantCulture) + " | " +//deutério
                            Math.Ceiling(resultado[k, 3] + cgAdi).ToString("0,0", CultureInfo.InvariantCulture) + "\r\n";//cargueiros
                    }
                    else
                    {
                        //mostra[k + 1] = String.Format(" {0,-12}", entradas.nomesPlanetas[k]);
                        mostra[k + 1] = String.Format("{0,-12}", entradas.nomesPlanetas[k]) + " | " +
                            resultado[k, 0].ToString("0,0", CultureInfo.InvariantCulture) + " | " +//metal
                            resultado[k, 1].ToString("0,0", CultureInfo.InvariantCulture) + " | " +//cristal
                            resultado[k, 2].ToString("0,0", CultureInfo.InvariantCulture) + " | " + "DESTINO!\r\n";//deutério
                    }
                }
                else//caso nao tenha nada para transportar
                {
                    //mostra[k + 1] = "NADA!";
                    mostra[k + 1] = String.Format("{0,-12} | 0 | 0 | 0 | 0\r\n", entradas.nomesPlanetas[k]);
                }
            }
        }
        //CALCULO CONSUMO
        private double CalculaConsumo(double nCargos, int tipo, int dist, int pOrigem, int pDestino)
        {
            nCargos = Math.Ceiling(nCargos);
            double fuel;
            switch (tipo)
            {
                case 5000://cargueiros pequenos
                    fuel = nCargos * 20;
                    break;
                default://cargueiros grandes
                    fuel = nCargos * 50;
                    break;
            }
            switch (dist)
            {
                case 1://viagem entre galaxias
                    //double temp = 1 + (fuel * ((20 * Math.Abs(pOrigem - pDestino)) / 35) * Math.Pow(2, 2));
                    //return (1 + (fuel * ((20 * Math.Abs(pOrigem - pDestino)) / 35) * Math.Pow(2, 2)));
                    //double temp0 = Math.Abs(pOrigem - pDestino);
                    //double temp0_0 = 20 * temp0;
                    //double temp0_1 = fuel * temp0_0;
                    //double temp0_2 = temp0_1 / 35;
                    //double temp0_3 = temp0_2 * 4;
                    //double temp0_4 = 1 + Math.Round(temp0_3);
                    //double temp1 = fuel * ((20 * Math.Abs(pOrigem - pDestino)) / 35) * 4;
                    //double temp = 1+Math.Round((4*((fuel*(20*(Math.Abs(pOrigem-pDestino))))/35)));
                    return (1 + Math.Round((4 * ((fuel * (20 * (Math.Abs(pOrigem - pDestino)))) / 35))));
                case 2://viagem entre sistemas solares
                    return (1 + Math.Round((4 * ((fuel * (2.7+0.095 * (Math.Abs(pOrigem - pDestino)))) / 35))));
                    //return (1 + (fuel * ((2.7 + 0.095 * Math.Abs(pOrigem - pDestino)) / 35) * Math.Pow(2, 2)));
                default://viagem dentro do mesmo sistema
                    return (1 + Math.Round((4 * ((fuel * (1+0.005 * (Math.Abs(pOrigem - pDestino)))) / 35))));
                    //return (1 + (fuel * ((1 + 0.005 * Math.Abs(pOrigem - pDestino)) / 35) * Math.Pow(2, 2)));
            }
        }
        //DISTRIBUIÇÃO ORDENADA (ORDEM DE RECURSOS)
        public void DistribuicaoOrdenada(Dados entradas, double[,] resultado)
        {
            //ordenar planetas segundo a maior necessidade
            if (entradas.metal > entradas.cristal)
            {
                if (entradas.metal > entradas.deuterio)//metal é a maior necessidade
                {
                    OrdenaRecursos(entradas, 0);
                }
                else //deuterio é a maior necessidade
                {
                    OrdenaRecursos(entradas, 2);
                }
            }
            else
            {
                if (entradas.cristal > entradas.deuterio)//cristal é a maior necessidade
                {
                    OrdenaRecursos(entradas, 1);
                }
                else//deuterio é a maior necessidade
                {
                    OrdenaRecursos(entradas, 2);
                }
            }
            //com os planetas ordenados o resto do algoritmo é semelhante ao caso simples
            DistribuicaoSimples(entradas, resultado);
        }
        //DISTRIBUIÇÃO EQUILIBRADA (RECURSOS DISTRIBUIDOS)
        public void DistribuicaoEquilibrada(Dados entradas, double[,] resultado)
        {
            double emFaltaM = 0, emFaltaC = 0, emFaltaD = 0;
            double[,] tempRecursos = new double[15, 3];//matriz com recursos distribuidos
            int[,] ocupMat = new int[15, 3];//vector que indica quais planetas ainda têm recursos (0 tem, 1 não tem)
            int tamMax = resultado.GetUpperBound(0) + 1;

            double minMetNeedPP = -1;
            double minCrisNeedPP = -1;
            double minDeutNeedPP = -1;

            //verifica que recursos são necessários
            if(entradas.metal > 0)
                minMetNeedPP = Math.Ceiling(entradas.metal / tamMax);
            if(entradas.cristal > 0)
                minCrisNeedPP = Math.Ceiling(entradas.cristal / tamMax);
            if(entradas.deuterio > 0)
                minDeutNeedPP = Math.Ceiling(entradas.deuterio / tamMax);

            //obtem o minimo de metal, cristal e deuterio em todos os planetas
            int k;
            double minMetal = entradas.recursos[0, 0];
            double minCristal = entradas.recursos[0, 1];
            double minDeuterio = entradas.recursos[0, 2];

            for (k = 1; k < tamMax; k++)
            {
                //metal
                if (entradas.recursos[k, 0] < minMetal && entradas.recursos[k, 0] != 0)
                    minMetal = entradas.recursos[k, 0];

                //cristal
                if (entradas.recursos[k, 1] < minCristal && entradas.recursos[k, 1] != 0)
                    minCristal = entradas.recursos[k, 1];

                //deuterio
                if (entradas.recursos[k, 2] < minDeuterio && entradas.recursos[k, 2] != 0)
                    minDeuterio = entradas.recursos[k, 2];
            }
            //se o minimo encontrado para cada recurso for maior que o minimo necessário = GOOD!   
            if (minMetal > minMetNeedPP && minCristal > minCrisNeedPP && minDeuterio > minDeutNeedPP)
            {
                for (k = 0; k < tamMax; k++)
                {
                    tempRecursos[k, 0] = minMetNeedPP;
                    tempRecursos[k, 1] = minCrisNeedPP;
                    tempRecursos[k, 2] = minDeutNeedPP;
                }
                //chama a distribuição simples alterada e está concluido! (espera-se que seja o caso mais comum)
                DistribuicaoSimples2(entradas, tempRecursos, resultado);
            }
            //se o minimo encontrado para cada recurso for menor que o minimo necessário = BAD! calculos adicionais   
            else
            {
                //percorre os recursos mantendo uma soma cumulativa parcial dos recursos que faltam e
                //tenta envia-los na ronda seguinte no primeiro planeta que tiver capacidade

                do//
                {
                    for (k = 0; k < tamMax; k++)
                    {
                        //METAL
                        if (ocupMat[k, 0] == 0) //apenas se não se souber à partida que o planeta não tem mais recursos disponiveis para distribuir
                        {
                            if (entradas.recursos[k, 0] == minMetNeedPP) //metal suficiente marginalmente
                            {
                                tempRecursos[k, 0] = entradas.recursos[k, 0];
                                ocupMat[k, 0] = 1;//não tem mais metal disponivel
                            }
                            if (entradas.recursos[k, 0] > minMetNeedPP) //metal superior ao necessário
                            {
                                if (emFaltaM > 0)
                                {
                                    if (entradas.recursos[k, 0] > (minMetNeedPP + emFaltaM))//chega e sobra para compensar o que está em falta
                                    {
                                        tempRecursos[k, 0] = minMetNeedPP + emFaltaM;
                                        emFaltaM = 0;
                                    }
                                    else//não chega (ou chega marginalmente) só por si para compensar tudo o que está em falta (tira o que tem à mesma)
                                    {
                                        tempRecursos[k, 0] = entradas.recursos[k, 0];
                                        //actualiza valor que está em falta
                                        emFaltaM = emFaltaM - (entradas.recursos[k, 0] - minMetNeedPP);// em falta = em falta - (o que foi enviado a mais do minimo)
                                        ocupMat[k, 0] = 1;//não tem mais metal disponivel
                                    }
                                }
                                else //não há recursos em falta
                                {
                                    tempRecursos[k, 0] = minMetNeedPP;
                                }
                            }
                            //METAL INSUFICIENTE
                            if (entradas.recursos[k, 0] < minMetNeedPP) //metal insuficiente
                            {
                                if (entradas.recursos[k, 0] != tempRecursos[k, 0])
                                {
                                    emFaltaM = emFaltaM + (minMetNeedPP - entradas.recursos[k, 0]);//actualiza valor em falta
                                    tempRecursos[k, 0] = entradas.recursos[k, 0];
                                    ocupMat[k, 0] = 1;//não tem mais metal
                                }
                            }
                        }
                        //CRISTAL
                        if (ocupMat[k, 1] == 0) //apenas se não se souber à partida que o planeta não tem mais recursos disponiveis para distribuir
                        {
                            if (entradas.recursos[k, 1] == minCrisNeedPP) //cristal suficiente marginalmente
                            {
                                tempRecursos[k, 1] = entradas.recursos[k, 1];
                                ocupMat[k, 1] = 1;//não tem mais cristal disponivel
                            }
                            if (entradas.recursos[k, 1] > minCrisNeedPP) //cristal superior ao necessário
                            {
                                if (emFaltaC > 0)
                                {
                                    if (entradas.recursos[k, 1] > (minCrisNeedPP + emFaltaC))//chega e sobra para compensar o que está em falta
                                    {
                                        tempRecursos[k, 1] = minCrisNeedPP + emFaltaC;
                                        emFaltaC = 0;
                                    }
                                    else//não chega (ou chega marginalmente) só por si para compensar tudo o que está em falta (tira o que tem à mesma)
                                    {
                                        tempRecursos[k, 1] = entradas.recursos[k, 1];
                                        //actualiza valor que está em falta
                                        emFaltaC = emFaltaC - (entradas.recursos[k, 1] - minCrisNeedPP);// em falta = em falta - (o que foi enviado a mais do minimo)
                                        ocupMat[k, 1] = 1;//não tem mais cristal disponivel
                                    }
                                }
                                else //não há recursos em falta
                                {
                                    tempRecursos[k, 1] = minCrisNeedPP;
                                }
                            }
                            //CRISTAL INSUFICIENTE
                            if (entradas.recursos[k, 1] < minCrisNeedPP) //cristal insuficiente
                            {
                                if (entradas.recursos[k, 1] != tempRecursos[k, 1])
                                {
                                    emFaltaC = emFaltaC + (minCrisNeedPP - entradas.recursos[k, 1]);//actualiza valor em falta
                                    tempRecursos[k, 1] = entradas.recursos[k, 1];
                                    ocupMat[k, 1] = 1;//não tem mais cristal
                                }
                            }
                        }
                        //DEUTÉRIO
                         if (ocupMat[k, 2] == 0) //apenas se não se souber à partida que o planeta não tem mais recursos disponiveis para distribuir
                        {
                            if (entradas.recursos[k, 2] == minDeutNeedPP) //deutério suficiente marginalmente
                            {
                                tempRecursos[k, 2] = entradas.recursos[k, 2];
                                ocupMat[k, 2] = 1;//não tem mais deutério disponivel
                            }
                            if (entradas.recursos[k, 2] > minDeutNeedPP) //deutério superior ao necessário
                            {
                                if (emFaltaD > 0)
                                {
                                    if (entradas.recursos[k, 2] > (minDeutNeedPP + emFaltaD))//chega e sobra para compensar o que está em falta
                                    {
                                        tempRecursos[k, 2] = minDeutNeedPP + emFaltaD;
                                        emFaltaD = 0;
                                    }
                                    else//não chega (ou chega marginalmente) só por si para compensar tudo o que está em falta (tira o que tem à mesma)
                                    {
                                        tempRecursos[k, 2] = entradas.recursos[k, 2];
                                        //actualiza valor que está em falta
                                        emFaltaD = emFaltaD - (entradas.recursos[k, 2] - minDeutNeedPP);// em falta = em falta - (o que foi enviado a mais do minimo)
                                        ocupMat[k, 2] = 1;//não tem mais deutério disponivel
                                    }
                                }
                                else //não há recursos em falta
                                {
                                    tempRecursos[k, 2] = minDeutNeedPP;
                                }
                            }
                            //DEUTÉRIO INSUFICIENTE
                            if (entradas.recursos[k, 2] < minDeutNeedPP) //deuterio insuficiente
                            {
                                if (entradas.recursos[k, 2] != tempRecursos[k, 2])
                                {
                                    emFaltaD = emFaltaD + (minDeutNeedPP - entradas.recursos[k, 2]);//actualiza valor em falta
                                    tempRecursos[k, 2] = entradas.recursos[k, 2];
                                    ocupMat[k, 2] = 1;//não tem mais deutério
                                }
                            }
                        }
                        
                    }
                } while (emFaltaC > 0 || emFaltaM > 0 || emFaltaD > 0);
                //chama a função de distribuição simples alterada - feito!
                DistribuicaoSimples2(entradas, tempRecursos, resultado);

            }

        }
        //DISTRIBUIÇÃO SIMPLES ALTERADA (para funcionar corretamente com a distruibuição equilibrada
        public void DistribuicaoSimples2(Dados entradas, double[,] reqEqui, double[,] resultado)
        {
            int tamMax = resultado.GetUpperBound(0) + 1;
            //retira primeiro os recursos do planeta de destino
            int k, j;
            for (j = 0; j < 3; j++)
            {
                if (reqEqui[entradas.dest, j] <= temp[j])
                {
                    resultado[entradas.dest, j] = reqEqui[entradas.dest, j];
                    temp[j] -= reqEqui[entradas.dest, j];
                }
                else
                {
                    resultado[entradas.dest, j] = temp[j];
                    temp[j] = 0;
                }
            }
            //para os restantes planetas
            for (k = 0; k < tamMax; k++)
            {
                if (k != entradas.dest)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (reqEqui[k, j] <= temp[j])
                        {
                            resultado[k, j] = reqEqui[k, j];
                            temp[j] -= reqEqui[k, j];
                        }
                        else
                        {
                            resultado[k, j] = temp[j];
                            temp[j] = 0;
                        }
                    }
                }
                //resultado exacto para o numero de cargueiros necessario
                resultado[k, 3] = (resultado[k, 0] + resultado[k, 1] + resultado[k, 2]) / entradas.cargos;
                //verificação do tipo de viagem e calculo do consumo
                double cgAdi = 0;
                if (entradas.galaxia[entradas.dest] - entradas.galaxia[k] != 0)//galaxias diferentes
                {
                    double consumo = CalculaConsumo(resultado[k, 3], entradas.cargos, 1, entradas.galaxia[k], entradas.galaxia[entradas.dest]);
                    //calculo de cargos adicionais
                    if (Math.Ceiling(resultado[k, 3]) * entradas.cargos < resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo)
                    {
                        //cargueiros não chegam
                        cgAdi = consumo / entradas.cargos;
                    }
                }
                else//mesma galaxia
                {
                    if (entradas.sistema[entradas.dest] - entradas.sistema[k] != 0)//sistemas diferentes
                    {
                        double consumo = CalculaConsumo(resultado[k, 3], entradas.cargos, 2, entradas.sistema[k], entradas.sistema[entradas.dest]);
                        //calculo de cargos adicionais
                        if (Math.Ceiling(resultado[k, 3]) * entradas.cargos < resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo)
                        {
                            //cargueiros não chegam
                            cgAdi = consumo / entradas.cargos;
                        }
                    }
                    else//mesmo sistema
                    {
                        double consumo = CalculaConsumo(resultado[k, 3], entradas.cargos, 3, entradas.slot[k], entradas.slot[entradas.dest]);
                        //calculo de cargos adicionais
                        if (Math.Ceiling(resultado[k, 3]) * entradas.cargos < resultado[k, 0] + resultado[k, 1] + resultado[k, 2] + consumo)
                        {
                            //cargueiros não chegam
                            cgAdi = consumo / entradas.cargos;
                        }
                    }
                }
                if (resultado[k, 3] != 0)//se houver realmente algo para transportar
                {
                    if (k != entradas.dest)
                    {
                        mostra[k] = entradas.nomesPlanetas[k] + ": " +
                            resultado[k, 0].ToString("0,0", CultureInfo.InvariantCulture) +" metal, " +//metal
                            resultado[k, 1].ToString("0,0", CultureInfo.InvariantCulture) + " cristal, " +//cristal
                            resultado[k, 2].ToString("0,0", CultureInfo.InvariantCulture) + " deutério, " +//deutério
                            Math.Ceiling(resultado[k, 3] + cgAdi).ToString("0,0", CultureInfo.InvariantCulture) + " Cargueiro(s)\r\n";//cargueiros
                    }
                    else
                    {
                        mostra[k] = entradas.nomesPlanetas[k] + " (destino): " +
                            resultado[k, 0].ToString("0,0", CultureInfo.InvariantCulture) + " metal, " +//metal
                            resultado[k, 1].ToString("0,0", CultureInfo.InvariantCulture) + " cristal, " +//cristal
                            resultado[k, 2].ToString("0,0", CultureInfo.InvariantCulture) + " deutério\r\n";//deutério
                    }
                }
                else//caso nao tenha nada para transportar
                {
                    mostra[k] = entradas.nomesPlanetas[k] + ": 0.\r\n";
                }
            }
        }
        //LIMITAÇÃO DE CARGUEIROS (trata a situação de não haver cargos suficientes num dado planeta
        //public double RedistCargos(double[] recursos, int cargosExistentes, double cargosNecessarios, int[] dataConsumo)
        //{
        //    //cargos necessários > cargos existentes
        //    double dif = cargosNecessarios - cargosExistentes;
        //    double consumo = CalculaConsumo(cargosExistentes, dataConsumo[0], dataConsumo[1], dataConsumo[2], dataConsumo[3]);

        //    double capReal = (dataConsumo[0] * cargosExistentes) - consumo;

        //    return (0);
        //}

    }
}
