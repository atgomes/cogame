using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;
using COgame_Calc;

namespace COgame
{
    public partial class Form1 : Form
    {
        //criação de classes:
        //-para guardar em disco
        [Serializable]
        public partial class Guardar
        {
            public double metalS;
            public double cristalS;
            public double deuterioS;
            public double[,] recursosS;
            public string[] nomes;
            public int NPlanS;
        }
        Guardar GR = new Guardar();
        //-para escrever na caixa de texto
        public class CaixaTexto
        {
            public static void Escrever(TextBox caixa, string texto, string tipo = "default")
            {
                if (tipo == "app")
                {
                    caixa.AppendText(texto);
                }
                else
                {
                    caixa.Clear();
                    caixa.Text = texto;
                }
            }
            public static void Limpar(TextBox caixa)
            {
                caixa.Clear();
            }
        }

        Dados entradas = new Dados();//cria novo objecto para suportar os dados de entrada

        int index = 0;
        int text_length = 0; //para método de colar recursos

        public Form1()
        {
            InitializeComponent();
        }

        //Organiza todos os dados lidos, calcula e apresenta resultados
        private void Calc_Click(object sender, EventArgs e)
        {   //limpa saida
            CaixaTexto.Limpar(Saida);
            //numero de planetas
            int nmrPlanetas = Lista.Items.Count;
            //cálculos
            COgameCalcSimple Calcular = new COgameCalcSimple(entradas.metal, entradas.cristal,entradas.deuterio);
            double[,] resultado = new double[nmrPlanetas, 4];
            switch (entradas.metodo)
            {
                case 2:
                    Calcular.DistribuicaoOrdenada(entradas, resultado);
                    break;
                case 3:
                    Calcular.DistribuicaoEquilibrada(entradas, resultado);
                    break;
                default:
                    Calcular.DistribuicaoSimples(entradas, resultado);
                    break;
            }
            
            int k;
            for (k = 0; k < nmrPlanetas; k++)
            {
                CaixaTexto.Escrever(Saida, Calcular.mostra[k], "app");
            }
        }
        //---------------------------------------------------------------
        //funções pessoais
        private void actualizar(object sender, EventArgs e)
        {
            if (CGr.Checked == true)
                entradas.cargos = 25000;
            else if (CPe.Checked == true)
                entradas.cargos = 5000;
            if (ordemLista.Checked == true)
                entradas.metodo = 1;
            else if (ordemRecursos.Checked == true)
                entradas.metodo = 2;
            else if (equilibrado.Checked == true)
                entradas.metodo = 3;
            if (destino.Checked == true)
                entradas.dest = index;

        }
        //limpar caixas de texto ao clicar
        private void limpaTexto(object sender, EventArgs e)
        {
            TextBox caixaTextoTemp = sender as TextBox;
            CaixaTexto.Limpar(caixaTextoTemp);
        }        
        //formata a maneira como os dados são apresentados
        public void formatData(TextBox caixa, double numero)
        {
            caixa.Text = numero.ToString("0,0", CultureInfo.InvariantCulture);           
        }
        //desformata os dados apresentados
        public double dFormatData(TextBox caixa)
        {
            return (Convert.ToDouble(caixa.Text.Replace(",","")));
        }
        //---------------------------------------------------------------
        private void NPlan_ValueChanged(object sender, EventArgs e)
        {
            //Seleccionar o primeiro elemento
            Lista.SelectedIndex = 0;
            //Actualizar Lista
            int i = Lista.Items.Count;
            if (NPlan.Value > i)
            {
                int k;
                for (k = i; k < NPlan.Value; k++)
                {
                    Lista.Items.Insert(k,string.Format("Planeta {0}", k + 1));
                    entradas.nomesPlanetas[k] = string.Format("Planeta {0}", k + 1);
                    entradas.indices[k] = k;
                }                
            }
            if (NPlan.Value < i)
            {
                int k;
                for (k = i-1; k >= NPlan.Value; k--)
                {
                    Lista.Items.RemoveAt(k);
                    entradas.nomesPlanetas[k] = "";
                    entradas.indices[k] = -1;
                }                 
            }
            Lista.Update();
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Lista.Tag) != -1)
            {
                index = Lista.SelectedIndex;

                //mostra os recursos actuais para o planeta seleccionado
                MPlan.Text = Convert.ToString(entradas.recursos[entradas.indices[index], 0]);
                CPlan.Text = Convert.ToString(entradas.recursos[entradas.indices[index], 1]);
                DPlan.Text = Convert.ToString(entradas.recursos[entradas.indices[index], 2]);
                galaxyPos.Text = Convert.ToString(entradas.galaxia[entradas.indices[index]]);
                systemPos.Text = Convert.ToString(entradas.sistema[entradas.indices[index]]);
                slotPos.Text = Convert.ToString(entradas.slot[entradas.indices[index]]);

                //actualiza o estado de "destino" para o planeta seleccionado
                if (entradas.indices[index] == entradas.dest)
                {
                    destino.Checked = true;
                }
                else
                {
                    destino.Checked = false;
                }
            }
        }

        private void MetNeed_Leave(object sender, EventArgs e)
        {
            try
            {
                entradas.metal = dFormatData(MetNeed);
                formatData(MetNeed, entradas.metal);                
            }
            catch (FormatException)
            {
                //não faz nada
            }
            catch (OverflowException)
            {
                //não faz nada
            }
        }

        private void CrisNeed_Leave(object sender, EventArgs e)
        {
            try
            {
                entradas.cristal = dFormatData(CrisNeed);
                formatData(CrisNeed, entradas.cristal);
            }
            catch (FormatException)
            {
                if (CrisNeed.Text == "/getteste")
                {
                    //CaixaTexto.Escrever(Saida, Convert.ToString(_teste));
                    CrisNeed.Text = "";
                }
            }
            catch (OverflowException)
            {
                //não faz nada
            }
        }

        private void DeuNeed_Leave(object sender, EventArgs e)
        {
            try
            {
                entradas.deuterio = dFormatData(DeuNeed);
                formatData(DeuNeed, entradas.deuterio);
            }
            catch (FormatException)
            {
                //não faz nada
            }
            catch (OverflowException)
            {
                //não faz nada
            }
        }

        //limpa todas as caixas de texto e variaveis
        private void LimTudo_Click(object sender, EventArgs e)
        {
            //limpa caixas de texto
            foreach (Control control in this.Controls)
            {
                TextBox box = control as TextBox;
                if (box != null)
                {
                    box.Text = "";
                }
            }
            entradas.Reset();
        }

        //confirma os dados actuais para o planeta seleccionado
        private void Confirm_Click(object sender, EventArgs e)
        {
            //recursos
            try
            {
                entradas.recursos[index, 0] = dFormatData(MPlan);
                formatData(MPlan, entradas.recursos[index, 0]);
            }
            catch (FormatException)
            {}
            try
            {
                entradas.recursos[index, 1] = dFormatData(CPlan);
                formatData(CPlan, entradas.recursos[index, 1]);
            }
            catch (FormatException)
            {}
            try
            {
                entradas.recursos[index, 2] = dFormatData(DPlan);
                formatData(DPlan, entradas.recursos[index, 2]);
            }
            catch (FormatException)
            {}
            //~recursos
            //coordenadas
            try
            {
                if (Convert.ToInt32(galaxyPos.Text) < 1)
                {
                    entradas.galaxia[index] = 1;
                }
                else if (Convert.ToInt32(galaxyPos.Text) > 9)
                {
                    entradas.galaxia[index] = 9;
                }
                else
                {
                    entradas.galaxia[index] = Convert.ToInt32(galaxyPos.Text);
                }
                galaxyPos.Text = Convert.ToString(entradas.galaxia[index]);
            }
            catch (FormatException)
            { }
            try
            {
                if (Convert.ToInt32(systemPos.Text) < 1)
                {
                    entradas.sistema[index] = 1;
                }
                else if (Convert.ToInt32(systemPos.Text) > 499)
                {
                    entradas.sistema[index] = 499;
                }
                else
                {
                    entradas.sistema[index] = Convert.ToInt32(systemPos.Text);
                }
                systemPos.Text = Convert.ToString(entradas.sistema[index]);
            }
            catch (FormatException)
            { }
            try
            {
                if (Convert.ToInt32(slotPos.Text) < 1)
                {
                    entradas.slot[index] = 1;
                }
                else if (Convert.ToInt32(slotPos.Text) > 15)
                {
                    entradas.slot[index] = 15;
                }
                else
                {
                    entradas.slot[index] = Convert.ToInt32(slotPos.Text);
                }
                slotPos.Text = Convert.ToString(entradas.slot[index]);
            }
            catch (FormatException)
            { }
            //~coordenadas
            //verificação de destino
            if (destino.Checked == true)
            {
                entradas.dest = index;
            }
            //~verificação de destino
            //actualiza o valor em falta e controla cores
            double[] actual = new double[]{0,0,0};
            int k;
            for(k=0;k<15;k++)
            {
                actual[0]+=entradas.recursos[k,0];
                actual[1]+=entradas.recursos[k,1];
                actual[2]+=entradas.recursos[k,2];
            }
            if ((entradas.metal - actual[0]) > 0)
            {
                formatData(ShowMet, (entradas.metal - actual[0]));
                ShowMet.BackColor = Color.FromName("Red");
            }
            else
            {
                formatData(ShowMet, 0);
                ShowMet.BackColor = Color.FromName("Green");
            }
            if ((entradas.cristal - actual[1]) > 0)
            {
                formatData(ShowCris, (entradas.cristal - actual[1]));
                ShowCris.BackColor = Color.FromName("Red");
            }
            else
            {
                formatData(ShowCris, 0);
                ShowCris.BackColor = Color.FromName("Green");
            }
            if ((entradas.deuterio - actual[2]) > 0)
            {
                formatData(ShowDeu, (entradas.deuterio - actual[2]));
                ShowDeu.BackColor = Color.FromName("Red");
            }
            else
            {
                formatData(ShowDeu, 0);
                ShowDeu.BackColor = Color.FromName("Green");
            }
        }

        //MENUS
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COgame Beta by gorila\r\nEnglish Translation by Crusader\r\nThis program is free to use. COgame 2014", "Sair", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "COGAME files (*.cog)|*.cog";
            saveFileDialog1.RestoreDirectory = true;

            GR.metalS = entradas.metal;
            GR.cristalS = entradas.cristal;
            GR.deuterioS = entradas.deuterio;
            GR.recursosS = entradas.recursos;
            GR.NPlanS = (int)NPlan.Value;
            GR.nomes = new string[GR.NPlanS];
            //nomes
            int i;
            for (i = 0; i < GR.NPlanS; i++)
            {
                GR.nomes[i] = entradas.nomesPlanetas[i];
                //Lista.SetSelected(i, true);
                //try
                //{
                //    GR.nomes[i] = Lista.SelectedItem.ToString();
                //}
                //catch
                //{
                //}
                //Lista.SetSelected(i, false);
            }

            //Stream str = File.Open("data.cog", FileMode.Create);
            Stream str;
            BinaryFormatter bformatter = new BinaryFormatter();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((str = saveFileDialog1.OpenFile()) != null)
                {
                    bformatter.Serialize(str, GR);
                    str.Close();
                }
            }

            //bformatter.Serialize(str, GR);
            //str.Close();

            CaixaTexto.Escrever(Saida, "Dados guardados.");
        }

        private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GR = null;
            //********************************************************************
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "C:\Users\André\Documents\Visual Studio 2012\Projects\COgamev2\COgame\bin\Debug";
            //openFileDialog1.InitialDirectory.
            openFileDialog1.Filter = "COGAME files (*.cog)|*.cog";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            Stream str1;
            BinaryFormatter bformatter1 = new BinaryFormatter();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((str1 = openFileDialog1.OpenFile()) != null)
                    {
                        using (str1)
                        {
                            GR = (Guardar)bformatter1.Deserialize(str1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: Não foi possível ler o ficheiro do disco. Erro: " + ex.Message);
                }
            }
            //********************************************************************

            //Stream str1 = File.Open("data.cog", FileMode.Open);
            //BinaryFormatter bformatter1 = new BinaryFormatter();

            //GR = (Guardar)bformatter1.Deserialize(str1);
            //str1.Close();

            entradas.metal = GR.metalS;
            entradas.cristal = GR.cristalS;
            entradas.deuterio = GR.deuterioS;
            entradas.recursos = GR.recursosS;

            //load nomes
            int i;
            for (i = 0; i < GR.NPlanS; i++)
            {
                Lista.Items.Insert(i, GR.nomes[i]);
                entradas.nomesPlanetas[i] = GR.nomes[i];
            }
            NPlan.Value = GR.NPlanS;

            MetNeed.Text = Convert.ToString(entradas.metal);
            CrisNeed.Text = Convert.ToString(entradas.cristal);
            DeuNeed.Text = Convert.ToString(entradas.deuterio);

            CaixaTexto.Escrever(Saida, "Dados carregados.");
        }

        private void limpar_Click(object sender, EventArgs e)
        {
            CaixaTexto.Limpar(galaxyPos);
            CaixaTexto.Limpar(systemPos);
            CaixaTexto.Limpar(slotPos);
            CaixaTexto.Limpar(MPlan);
            CaixaTexto.Limpar(CPlan);
            CaixaTexto.Limpar(DPlan);
        }

        private void manterAcimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        //mudar o nome dos planetas
        int idx;
        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            idx = Lista.SelectedIndex;
            insertPlanetName.Visible = true;
            insertPlanetName.Focus();
        }

        private void ConfirmarNome(object sender, EventArgs e)
        {
            //Lista.SelectedIndex = 0;
            Lista.Tag = -1;
            Lista.Items.RemoveAt(idx);
            Lista.Items.Insert(idx, insertPlanetName.Text);
            Lista.Update();
            insertPlanetName.Visible = false;
            Lista.Tag = 0;
            entradas.nomesPlanetas[idx] = insertPlanetName.Text;//actualiza tabela de nomes
            insertPlanetName.Text = "";
        }

        private void insertPlanetName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                ConfirmarNome(sender, e);
                e.SuppressKeyPress = true;
                Lista.Focus();
                Lista.SelectedIndex = idx;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] debugData = new string[1];
            debugData[0] = "Destino (indice): "+Convert.ToString(entradas.dest)+"\r\n";
            //debugData[1] = "Destino (indice): "+Convert.ToString(entradas.dest);
            //debugData[0] = "Destino (indice): "+Convert.ToString(entradas.dest);
            //debugData[0] = "Destino (indice): "+Convert.ToString(entradas.dest);

            CaixaTexto.Escrever(Saida, debugData[0], "app");
        }
        //TOOLTIPS
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            string idioma = Properties.Settings.Default.idiomaSett;
            //LoadNames nomesPT;
            switch (idioma)
            {
                case "english":
                    //tooltips
                    toolTip1.SetToolTip(this.ordemLista, "The shipment is made by taking the maximum available \rresources from each planet from the list on the left side.");
                    toolTip1.SetToolTip(this.ordemRecursos, "The shipment is made by taking the maximum availabe resources\r in dicreasing order from what is necessary in bigger amount.");
                    toolTip1.SetToolTip(this.equilibrado, "The shipment tries to carry the same amount of each\r resource from each planet, provided it does have that resource.");
                    toolTip1.SetToolTip(this.label1, "Necessary resources. From right to left: \rmetal, crystal, deutérium. (in units)");
                    toolTip1.SetToolTip(this.ShowMet, "Metal missing.");
                    toolTip1.SetToolTip(this.ShowCris, "Crystal missing.");
                    toolTip1.SetToolTip(this.ShowDeu, "Deuterium missing.");
                    toolTip1.SetToolTip(this.label2, "Total number of planets from where is pretended to send resources.");
                    toolTip1.SetToolTip(this.label4, "Resources available at the selected planet from the left side list.");
                    toolTip1.SetToolTip(this.label5, "Coordinates of the selected planet from the left side list.");
                    toolTip1.SetToolTip(this.destino, "Select the planet from the left side list as the destination planet. \rOnly one planet at a time can be selected as destination.");
                    toolTip1.SetToolTip(this.limpar, "Reset the resources and coordinates from the selected planet.");
                    toolTip1.SetToolTip(this.Confirm, "Confirms the inserted values for the selected planet. \rAlso confirms if the planet is or is not the destination.");
                    toolTip1.SetToolTip(this.Calc, "Runs the program for the chosen values.");
                    toolTip1.SetToolTip(this.LimTudo, "Reset all the inserted values.");
                    toolTip1.SetToolTip(this.CGr, "Use Large Cargo. 25000 units of capacity.");
                    toolTip1.SetToolTip(this.CPe, "Use Small Cargo. 5000 units of capacity.");

                    //labels
                    this.fileToolStripMenuItem.Text = "&File";
                    this.carregarToolStripMenuItem.Text = "&Load";
                    this.guardarToolStripMenuItem.Text = "&Save";
                    this.sairToolStripMenuItem.Text = "&Exit";
                    this.opçõesToolStripMenuItem.Text = "&Options";
                    this.manterAcimaToolStripMenuItem.Text = "Keep Above";
                    this.idiomaToolStripMenuItem.Text = "Language";
                    this.portuguêsToolStripMenuItem.Text = "Portuguese";
                    this.inglêsToolStripMenuItem.Text = "English";
                    this.aboutToolStripMenuItem.Text = "&About";
                    this.label1.Text = "Necessary Resources (M/C/D)";
                    this.groupBox1.Text = "Cargos";
                    this.CGr.Text = "CLarge Cargo";
                    this.CPe.Text = "Small Cargo";
                    this.label2.Text = "Number of Planets";
                    this.groupBox2.Text = "Method";
                    this.ordemLista.Text = "List Order";
                    this.ordemRecursos.Text = "Resources Order";
                    this.equilibrado.Text = "Equilibrium";
                    this.label4.Text = "Resources (M/C/D)";
                    this.label5.Text = "Coordinates";
                    this.destino.Text = "Destination";
                    this.Confirm.Text = "OK";
                    this.limpar.Text = "Delete Data";
                    this.LimTudo.Text = "Delete All Data";
                    this.Calc.Text = "Run";
                    break;
                default:
                    //...
                    //tooltips
                    toolTip1.SetToolTip(this.ordemLista, "Os transportes são efectuados levando o máximo possível \rde cada planeta pela ordem da lista à esquerda.");
                    toolTip1.SetToolTip(this.ordemRecursos, "Os transportes são efectuados levando o máximo possível \rde cada planeta pela ordem decrescente do recurso que é \rnecessário em maior quantidade.");
                    toolTip1.SetToolTip(this.equilibrado, "Os transportes são efectuados tentando levar a mesma quantidade \rde cada recurso de cada planeta que tenha uma quantidade \rnão nula desse recurso.");
                    toolTip1.SetToolTip(this.label1, "Recursos necessários. Da direita para a esquerda: \rmetal, cristal, deutério em unidades.");
                    toolTip1.SetToolTip(this.ShowMet, "Metal em falta.");
                    toolTip1.SetToolTip(this.ShowCris, "Cristal em falta.");
                    toolTip1.SetToolTip(this.ShowDeu, "Deutério em falta.");
                    toolTip1.SetToolTip(this.label2, "Número total de planetas dos quais se pretendem enviar recursos.");
                    toolTip1.SetToolTip(this.label4, "Recursos presentes no planeta seleccionado na lista à esquerda.");
                    toolTip1.SetToolTip(this.label5, "Coordenadas do planeta seleccionado na lista à esquerda.");
                    toolTip1.SetToolTip(this.destino, "Escolhe o planeta seleccionado na lista à esquerda como o destino dos transportes. \rApenas um planeta pode ser seleccionado como destino de cada vez.");
                    toolTip1.SetToolTip(this.limpar, "Limpa os recursos e coordenadas do planeta seleccionado.");
                    toolTip1.SetToolTip(this.Confirm, "Confirma os valores introduzidos para o planeta seleccionado. \rConfirma também se o planeta é ou não destino.");
                    toolTip1.SetToolTip(this.Calc, "Calcula a optimização escolhida para os transportes a efetuar.");
                    toolTip1.SetToolTip(this.LimTudo, "Limpa todos os valores introduzidos.");
                    toolTip1.SetToolTip(this.CGr, "Utilizar cargueiros grandes. 25000 unidades de capacidade.");
                    toolTip1.SetToolTip(this.CPe, "Utilizar cargueiros pequenos. 5000 unidades de capacidade.");

                    //labels
                    this.fileToolStripMenuItem.Text = "&Ficheiro";
                    this.carregarToolStripMenuItem.Text = "&Carregar";
                    this.guardarToolStripMenuItem.Text = "&Guardar";
                    this.sairToolStripMenuItem.Text = "Sai&r";
                    this.opçõesToolStripMenuItem.Text = "&Opções";
                    this.manterAcimaToolStripMenuItem.Text = "Manter Acima";
                    this.idiomaToolStripMenuItem.Text = "Idioma";
                    this.portuguêsToolStripMenuItem.Text = "Português";
                    this.inglêsToolStripMenuItem.Text = "Inglês";
                    this.aboutToolStripMenuItem.Text = "&Sobre";
                    this.label1.Text = "Recursos Necessários (M/C/D)";
                    this.groupBox1.Text = "Cargueiros";
                    this.CGr.Text = "Cargueiros Grandes";
                    this.CPe.Text = "Cargueiros Pequenos";
                    this.label2.Text = "Número de Planetas";
                    this.groupBox2.Text = "Método";
                    this.ordemLista.Text = "Ordem da Lista";
                    this.ordemRecursos.Text = "Ordem de Recursos";
                    this.equilibrado.Text = "Equilibrado";
                    this.label4.Text = "Recursos (M/C/D)";
                    this.label5.Text = "Coordenadas";
                    this.destino.Text = "Destino";
                    this.Confirm.Text = "OK";
                    this.limpar.Text = "Limpar";
                    this.LimTudo.Text = "Limpar Tudo";
                    this.Calc.Text = "Calcular";
                    break;
            }
            

        }
        //MUDA IDIOMA
        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.idiomaSett = "english";
            Properties.Settings.Default.Save();

            string idioma = Properties.Settings.Default.idiomaSett;
            //LoadNames nomesPT;
            switch (idioma)
            {
                case "english":
                    //labels
                    this.fileToolStripMenuItem.Text = "&File";
                    this.carregarToolStripMenuItem.Text = "&Load";
                    this.guardarToolStripMenuItem.Text = "&Save";
                    this.sairToolStripMenuItem.Text = "&Exit";
                    this.opçõesToolStripMenuItem.Text = "&Options";
                    this.manterAcimaToolStripMenuItem.Text = "Keep Above";
                    this.idiomaToolStripMenuItem.Text = "Language";
                    this.portuguêsToolStripMenuItem.Text = "Portuguese";
                    this.inglêsToolStripMenuItem.Text = "English";
                    this.aboutToolStripMenuItem.Text = "&About";
                    this.label1.Text = "Necessary Resources (M/C/D)";
                    this.groupBox1.Text = "Cargos";
                    this.CGr.Text = "Large Cargo";
                    this.CPe.Text = "Small Cargo";
                    this.label2.Text = "Number of Planets";
                    this.groupBox2.Text = "Method";
                    this.ordemLista.Text = "List Order";
                    this.ordemRecursos.Text = "Resources Order";
                    this.equilibrado.Text = "Equilibrium";
                    this.label4.Text = "Resources (M/C/D)";
                    this.label5.Text = "Coordinates";
                    this.destino.Text = "Destination";
                    this.Confirm.Text = "OK";
                    this.limpar.Text = "Delete Data";
                    this.LimTudo.Text = "Delete All Data";
                    this.Calc.Text = "Run";
                    this.modoEcra.Text = "Mini mode";
                    break;
                default:
                    //...
                    //labels
                    this.fileToolStripMenuItem.Text = "&Ficheiro";
                    this.carregarToolStripMenuItem.Text = "&Carregar";
                    this.guardarToolStripMenuItem.Text = "&Guardar";
                    this.sairToolStripMenuItem.Text = "Sai&r";
                    this.opçõesToolStripMenuItem.Text = "&Opções";
                    this.manterAcimaToolStripMenuItem.Text = "Manter Acima";
                    this.idiomaToolStripMenuItem.Text = "Idioma";
                    this.portuguêsToolStripMenuItem.Text = "Português";
                    this.inglêsToolStripMenuItem.Text = "Inglês";
                    this.aboutToolStripMenuItem.Text = "&Sobre";
                    this.label1.Text = "Recursos Necessários (M/C/D)";
                    this.groupBox1.Text = "Cargueiros";
                    this.CGr.Text = "Cargueiros Grandes";
                    this.CPe.Text = "Cargueiros Pequenos";
                    this.label2.Text = "Número de Planetas";
                    this.groupBox2.Text = "Método";
                    this.ordemLista.Text = "Ordem da Lista";
                    this.ordemRecursos.Text = "Ordem de Recursos";
                    this.equilibrado.Text = "Equilibrado";
                    this.label4.Text = "Recursos (M/C/D)";
                    this.label5.Text = "Coordenadas";
                    this.destino.Text = "Destino";
                    this.Confirm.Text = "OK";
                    this.limpar.Text = "Limpar";
                    this.LimTudo.Text = "Limpar Tudo";
                    this.Calc.Text = "Calcular";
                    this.modoEcra.Text = "Modo Pequeno";
                    break;
            }
        }

        private void portuguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.idiomaSett = "portuguese";
            Properties.Settings.Default.Save();

            string idioma = Properties.Settings.Default.idiomaSett;
            //LoadNames nomesPT;
            switch (idioma)
            {
                case "english":
                    //labels
                    this.fileToolStripMenuItem.Text = "&File";
                    this.carregarToolStripMenuItem.Text = "&Load";
                    this.guardarToolStripMenuItem.Text = "&Save";
                    this.sairToolStripMenuItem.Text = "&Exit";
                    this.opçõesToolStripMenuItem.Text = "&Options";
                    this.manterAcimaToolStripMenuItem.Text = "Keep Above";
                    this.idiomaToolStripMenuItem.Text = "Language";
                    this.portuguêsToolStripMenuItem.Text = "Portuguese";
                    this.inglêsToolStripMenuItem.Text = "English";
                    this.aboutToolStripMenuItem.Text = "&About";
                    this.label1.Text = "Necessary Resources (M/C/D)";
                    this.groupBox1.Text = "Cargos";
                    this.CGr.Text = "Large Cargo";
                    this.CPe.Text = "Small Cargo";
                    this.label2.Text = "Number of Planets";
                    this.groupBox2.Text = "Method";
                    this.ordemLista.Text = "List Order";
                    this.ordemRecursos.Text = "Resources Order";
                    this.equilibrado.Text = "Equilibrium";
                    this.label4.Text = "Resources (M/C/D)";
                    this.label5.Text = "Coordinates";
                    this.destino.Text = "Destination";
                    this.Confirm.Text = "OK";
                    this.limpar.Text = "Delete Data";
                    this.LimTudo.Text = "Delete All Data";
                    this.Calc.Text = "Run";
                    this.modoEcra.Text = "Mini mode";
                    break;
                default:
                    //...
                    //labels
                    this.fileToolStripMenuItem.Text = "&Ficheiro";
                    this.carregarToolStripMenuItem.Text = "&Carregar";
                    this.guardarToolStripMenuItem.Text = "&Guardar";
                    this.sairToolStripMenuItem.Text = "Sai&r";
                    this.opçõesToolStripMenuItem.Text = "&Opções";
                    this.manterAcimaToolStripMenuItem.Text = "Manter Acima";
                    this.idiomaToolStripMenuItem.Text = "Idioma";
                    this.portuguêsToolStripMenuItem.Text = "Português";
                    this.inglêsToolStripMenuItem.Text = "Inglês";
                    this.aboutToolStripMenuItem.Text = "&Sobre";
                    this.label1.Text = "Recursos Necessários (M/C/D)";
                    this.groupBox1.Text = "Cargueiros";
                    this.CGr.Text = "Cargueiros Grandes";
                    this.CPe.Text = "Cargueiros Pequenos";
                    this.label2.Text = "Número de Planetas";
                    this.groupBox2.Text = "Método";
                    this.ordemLista.Text = "Ordem da Lista";
                    this.ordemRecursos.Text = "Ordem de Recursos";
                    this.equilibrado.Text = "Equilibrado";
                    this.label4.Text = "Recursos (M/C/D)";
                    this.label5.Text = "Coordenadas";
                    this.destino.Text = "Destino";
                    this.Confirm.Text = "OK";
                    this.limpar.Text = "Limpar";
                    this.LimTudo.Text = "Limpar Tudo";
                    this.Calc.Text = "Calcular";
                    this.modoEcra.Text = "Modo Pequeno";
                    break;
            }
        }

        //MINI-MODE
        //dados publicos entre form original e mini mode
        public static int[,] coordMini = new int[,] {{1,1,1}, {1,1,1}, {1,1,1}, {1,1,1}, {1,1,1},
                {1,1,1}, {1,1,1}, {1,1,1}, {1,1,1}, {1,1,1}, {1,1,1}, {1,1,1}, 
                {1,1,1}, {1,1,1}, {1,1,1}}; 
        public static double[,] recursosMini = new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, 
                { 0, 0, 0 }, { 0, 0, 0 } };
        //public static int destMini = 0;

        public static string[] listaMini;
        //public static string listaMini = new List<string>();

        private void modoEcra_CheckedChanged(object sender, EventArgs e)
        {
            if (modoEcra.Checked == true)
            {
                MiniMode miniIntro = new MiniMode();

                listaMini = entradas.nomesPlanetas;

                miniIntro.Show();
                this.Hide();

                miniIntro.FormClosed += new FormClosedEventHandler(miniIntro_FormClosed);
            }
        }
        //volta a mostrar o form original quando se fecha o mini mode
        void miniIntro_FormClosed(object sender, FormClosedEventArgs e)
        {
            int i, j;
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    entradas.recursos[i, j] = recursosMini[i, j];
                }
                entradas.galaxia[i] = coordMini[i, 0];
                entradas.sistema[i] = coordMini[i, 1];
                entradas.slot[i] = coordMini[i, 2];
            }

            //entradas.dest = 

            this.Show(); //volta a mostrar o Form prinipal

            modoEcra.Checked = false;
        }

        //4 ABRIL 2014: INTRODUÇÃO DA POSSIBILIDADE DE COLAR TUDO NA PRIMEIRA CAIXA
        private void MPlan_TextChanged(object sender, EventArgs e)
        {
            
            int current_length = MPlan.Text.Length;
            if (Math.Abs(current_length - text_length) > 1)
            {
                text_length = current_length;
                if (MPlan.Tag as string == "0" && text_length > 0)
                {
                    MPlan.Tag = "1";
                    // tratamento do texto colado
                    int meta = 0, cris = 0, deut = 0, cnt = 0;
                    string str = string.Empty;
                    string str2 = string.Empty;
                    //MPlan.Text = "";

                    if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
                    {
                        str = Convert.ToString(Clipboard.GetData(DataFormats.Text));
                        str = str.Replace("\r", "X").Replace("\n", "");
                        str += 'X';
                    }

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (char.IsDigit(str[i]))
                        {
                            str2 += str[i];
                        }
                        if (str2 != "" && str[i] == 'X')
                        {
                            switch (cnt)
                            {
                                case 0:
                                    meta = Convert.ToInt32(str2);
                                    cnt += 1;
                                    str2 = "";
                                    break;
                                case 1:
                                    cris = Convert.ToInt32(str2);
                                    cnt += 1;
                                    str2 = "";
                                    break;
                                case 2:
                                    deut = Convert.ToInt32(str2);
                                    cnt += 1;
                                    str2 = "";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    Clipboard.SetText(meta.ToString());
                    if(cris !=0)
                        CPlan.Text = Convert.ToString(cris);
                    if (deut != 0)
                        DPlan.Text = Convert.ToString(deut);
                    MPlan.Text = Convert.ToString(meta);
                    MPlan.Tag = "0";
                }
            }
            text_length = current_length;
        }
        
    }
}
