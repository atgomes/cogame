using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COgame
{
    public partial class MiniMode : Form
    {
        public MiniMode()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            //para aceder aos metodos do form principal
            var originalForm = Application.OpenForms.OfType<Form1>().Single();

            int index = Lista.SelectedIndex;
            if (index < 0)
            {
                index = 0;
                Lista.SelectedIndex = 0;
            }
            //recursos
            try
            {
                Form1.recursosMini[index, 0] = originalForm.dFormatData(MPlan);
                originalForm.formatData(MPlan, Form1.recursosMini[index, 0]);
            }
            catch (FormatException)
            { }
            try
            {
                Form1.recursosMini[index, 1] = originalForm.dFormatData(CPlan);
                originalForm.formatData(CPlan, Form1.recursosMini[index, 1]);
            }
            catch (FormatException)
            { }
            try
            {
                Form1.recursosMini[index, 2] = originalForm.dFormatData(DPlan);
                originalForm.formatData(DPlan, Form1.recursosMini[index, 2]);
            }
            catch (FormatException)
            { }
            //~recursos
            //coordenadas
            try
            {
                if (Convert.ToInt32(galaxyPos.Text) < 1)
                {
                    Form1.coordMini[index, 0] = 1;
                }
                else if (Convert.ToInt32(galaxyPos.Text) > 9)
                {
                    Form1.coordMini[index, 0] = 9;
                }
                else
                {
                    Form1.coordMini[index, 0] = Convert.ToInt32(galaxyPos.Text);
                }
                //galaxyPos.Text = Convert.ToString(entradas.galaxia[index]);
            }
            catch (FormatException)
            { }
            try
            {
                if (Convert.ToInt32(systemPos.Text) < 1)
                {
                    Form1.coordMini[index, 1] = 1;
                }
                else if (Convert.ToInt32(systemPos.Text) > 499)
                {
                    Form1.coordMini[index, 1] = 9;
                }
                else
                {
                    Form1.coordMini[index, 1] = Convert.ToInt32(systemPos.Text);
                }
                //systemPos.Text = Convert.ToString(entradas.sistema[index]);
            }
            catch (FormatException)
            { }
            try
            {
                if (Convert.ToInt32(slotPos.Text) < 1)
                {
                    Form1.coordMini[index, 2] = 1;
                }
                else if (Convert.ToInt32(slotPos.Text) > 15)
                {
                    Form1.coordMini[index, 2] = 1;
                }
                else
                {
                    Form1.coordMini[index, 2] = Convert.ToInt32(slotPos.Text);
                }
                //slotPos.Text = Convert.ToString(entradas.slot[index]);
            }
            catch (FormatException)
            { }
            //~coordenadas
            //verificação de destino
            //if (destino.Checked == true)
            //{
            //    entradas.dest = index;
            //}
            //~verificação de destino
        }

        private void modoEcra_CheckedChanged(object sender, EventArgs e)
        {
            if (modoEcra.Checked == false)
            {
                this.Close();
            }            
        }
        //actualiza lista conforme lista original
        private void MiniMode_Activated(object sender, EventArgs e)
        {
            modoEcra.Checked = true;
            Lista.Items.Clear();
            foreach (string x in Form1.listaMini)
            {
                try
                {
                    Lista.Items.Add(x);
                }
                catch(System.ArgumentNullException)
                {
                    break;
                }
            }
        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Lista.SelectedIndex;

            //mostra os recursos actuais para o planeta seleccionado
            MPlan.Text = Convert.ToString(Form1.recursosMini[index, 0]);
            CPlan.Text = Convert.ToString(Form1.recursosMini[index, 1]);
            DPlan.Text = Convert.ToString(Form1.recursosMini[index, 2]);
            galaxyPos.Text = Convert.ToString(Form1.coordMini[index, 0]);
            systemPos.Text = Convert.ToString(Form1.coordMini[index, 1]);
            slotPos.Text = Convert.ToString(Form1.coordMini[index, 2]);

            //actualiza o estado de "destino" para o planeta seleccionado
            //if (Form1.destMini == index)
            //{
            //    destino.Checked = true;
            //}
            //else
            //{
            //    destino.Checked = false;
            //}
        }

        private void LimpaCaixa(object sender, EventArgs e)
        {
            TextBox caixaTextoTemp = sender as TextBox;
            caixaTextoTemp.Text = "";
        }

    }
}
