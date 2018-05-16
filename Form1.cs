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

namespace NicknameRandomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String jbappdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JacenBoy", "Nuzlocke Dashboard");
        Boolean serverconnect = false;

        private void btnAddPokemon_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtSpecies.Text) || String.IsNullOrWhiteSpace(txtNickname.Text))
                {
                    throw new Exception("One or more required text boxes are empty.");
                }

                if (radSlot1.Checked)
                {
                    lblSlot1.Text = txtNickname.Text + " the " + txtSpecies.Text;
                }
                if (radSlot2.Checked)
                {
                    lblSlot2.Text = txtNickname.Text + " the " + txtSpecies.Text;
                }
                if (radSlot3.Checked)
                {
                    lblSlot3.Text = txtNickname.Text + " the " + txtSpecies.Text;
                }
                if (radSlot4.Checked)
                {
                    lblSlot4.Text = txtNickname.Text + " the " + txtSpecies.Text;
                }
                if (radSlot5.Checked)
                {
                    lblSlot5.Text = txtNickname.Text + " the " + txtSpecies.Text;
                }
                if (radSlot6.Checked)
                {
                    lblSlot6.Text = txtNickname.Text + " the " + txtSpecies.Text;
                }

                //There's probably a better way to do this but ¯\_(ツ)_/¯
                String slot1json;
                String slot2json;
                String slot3json;
                String slot4json;
                String slot5json;
                String slot6json;
                if (lblSlot1.Text == "Empty")
                {
                    slot1json = "false";
                }
                else
                {
                    slot1json = "[\"" + lblSlot1.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot1.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
                }
                if (lblSlot2.Text == "Empty")
                {
                    slot2json = "false";
                }
                else
                {
                    slot2json = "[\"" + lblSlot2.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot2.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
                }
                if (lblSlot3.Text == "Empty")
                {
                    slot3json = "false";
                }
                else
                {
                    slot3json = "[\"" + lblSlot3.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot3.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
                }
                if (lblSlot4.Text == "Empty")
                {
                    slot4json = "false";
                }
                else
                {
                    slot4json = "[\"" + lblSlot4.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot4.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
                }
                if (lblSlot5.Text == "Empty")
                {
                    slot5json = "false";
                }
                else
                {
                    slot5json = "[\"" + lblSlot5.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot5.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
                }
                if (lblSlot6.Text == "Empty")
                {
                    slot6json = "false";
                }
                else
                {
                    slot6json = "[\"" + lblSlot6.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot6.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
                }

                using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "pokes.js"), false))
                {
                    file.WriteLine("pokelist = {");
                    file.WriteLine("\"poke1\" : " + slot1json + ",");
                    file.WriteLine("\"poke2\" : " + slot2json + ",");
                    file.WriteLine("\"poke3\" : " + slot3json + ",");
                    file.WriteLine("\"poke4\" : " + slot4json + ",");
                    file.WriteLine("\"poke5\" : " + slot5json + ",");
                    file.WriteLine("\"poke6\" : " + slot6json);
                    file.WriteLine("};");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radSlot1.Checked = true;
            txtBadges.Text = "0";
            txtDeaths.Text = "0";

            try
            {
                // If naming files do not already exist, set them up.
                if (!File.Exists(Path.Combine(jbappdata, "names", "namingschemes.txt")))
                {
                    Directory.CreateDirectory(jbappdata);
                    Directory.CreateDirectory(Path.Combine(jbappdata, "names"));
                    var namingfile = File.Create(Path.Combine(jbappdata, "names", "namingschemes.txt"));
                    namingfile.Close();

                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "namingschemes.txt")))
                    {
                        file.WriteLine("Flowers\r\nFruits\r\nTrees");
                    }

                    Directory.CreateDirectory(Path.Combine(jbappdata, "names", "Male"));
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "Male", "Flowers.txt")))
                    {
                        file.WriteLine("Aster\r\nCarnation\r\nClover\r\nDaisy\r\nDahlia\r\nEdelweiss\r\nFreesia\r\nFuschia\r\nGerbera\r\nGeranium\r\nHolly\r\nIvy\r\nLilac\r\nLily\r\nLotus\r\nPansy\r\nPeony\r\nRose\r\nRue\r\nSunflower\r\nSnapdragon\r\nSnowdrop\r\nSweet Pea\r\nTulip\r\nViolet");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "Male", "Fruits.txt")))
                    {
                        file.WriteLine("Apple\r\nApricot\r\nAvocado\r\nBanana\r\nBlackberry\r\nBloodorange\r\nBlueberry\r\nCherry\r\nCoconut\r\nCranberry\r\nDamson\r\nDate\r\nDurian\r\nEggplant\r\nElderberry\r\nFig\r\nGrape\r\nGrapefruit\r\nGuava\r\nHala\r\nHawthorne berry\r\nHoneydew\r\nIlama\r\nItaPalm\r\nJackfruit\r\nKiwi\r\nKumquat\r\nLemon\r\nLime\r\nLingonberry\r\nMango\r\nMelon\r\nNectarine\r\nOrange\r\nPassionfruit\r\nPapaya\r\nPeach\r\nPear\r\nPersimmon\r\nPlum\r\nPrune\r\nQuince\r\nRaisin\r\nRaspberry\r\nRhubarb\r\nStarfruit\r\nStrawberry\r\nTamarind\r\nTangerine\r\nTomato\r\nUgli\r\nWatermelon\r\nXocotl\r\nZucchini");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "Male", "Trees.txt")))
                    {
                        file.WriteLine("Acacia\r\nAlder\r\nAlmond\r\nApricot\r\nApple\r\nArrowwood\r\nArborvitae\r\nAsh\r\nAspen\r\nBalsa\r\nBanana\r\nBeech\r\nBirch\r\nBoxwood\r\nBubinga\r\nCasuarina\r\nCamphorwood\r\nCashew\r\nCedar\r\nCherry\r\nChestnut\r\nCocobolo\r\nCottonwood\r\nCypress\r\nDogwood\r\nEbony\r\nElm\r\nEucalyptus\r\nFig\r\nFicus\r\nFir\r\nGuelder\r\nHackberry\r\nHemlock\r\nHickory\r\nIronwood\r\nIpe\r\nJuniper\r\nLancewood\r\nLarch\r\nLauan\r\nLemon\r\nLocust\r\nMagnolia\r\nMahogany\r\nMaple\r\nMerry\r\nMesquite\r\nMimosa\r\nMyrtle\r\nNectarine\r\nOak\r\nOlive\r\nOrange\r\nOsage\r\nOsier\r\nPadauk\r\nPalm\r\nPeach\r\nPear\r\nPecan\r\nPersimmon\r\nPine\r\nPlum\r\nPoplar\r\nPurpleheart\r\nQuince\r\nRedbud\r\nRedwood\r\nRosewood\r\nRowan\r\nRubber\r\nSassafras\r\nSequoia\r\nSnowball\r\nSpruce\r\nSumac\r\nSweetgum\r\nSycamore\r\nTamarisk\r\nThuya\r\nThuja\r\nTea\r\nTeak\r\nTulipwood\r\nUpas\r\nWalnut\r\nWattle\r\nWenge\r\nWillow\r\nYew");
                    }

                    Directory.CreateDirectory(Path.Combine(jbappdata, "names", "Female"));
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "Female", "Flowers.txt")))
                    {
                        file.WriteLine("Aster\r\nCarnation\r\nClover\r\nDaisy\r\nDahlia\r\nEdelweiss\r\nFreesia\r\nFuschia\r\nGerbera\r\nGeranium\r\nHolly\r\nIvy\r\nLilac\r\nLily\r\nLotus\r\nPansy\r\nPeony\r\nRose\r\nRue\r\nSunflower\r\nSnapdragon\r\nSnowdrop\r\nSweet Pea\r\nTulip\r\nViolet");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "Female", "Fruits.txt")))
                    {
                        file.WriteLine("Apple\r\nApricot\r\nAvocado\r\nBanana\r\nBlackberry\r\nBloodorange\r\nBlueberry\r\nCherry\r\nCoconut\r\nCranberry\r\nDamson\r\nDate\r\nDurian\r\nEggplant\r\nElderberry\r\nFig\r\nGrape\r\nGrapefruit\r\nGuava\r\nHala\r\nHawthorne berry\r\nHoneydew\r\nIlama\r\nItaPalm\r\nJackfruit\r\nKiwi\r\nKumquat\r\nLemon\r\nLime\r\nLingonberry\r\nMango\r\nMelon\r\nNectarine\r\nOrange\r\nPassionfruit\r\nPapaya\r\nPeach\r\nPear\r\nPersimmon\r\nPlum\r\nPrune\r\nQuince\r\nRaisin\r\nRaspberry\r\nRhubarb\r\nStarfruit\r\nStrawberry\r\nTamarind\r\nTangerine\r\nTomato\r\nUgli\r\nWatermelon\r\nXocotl\r\nZucchini");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "names", "Female", "Trees.txt")))
                    {
                        file.WriteLine("Acacia\r\nAlder\r\nAlmond\r\nApricot\r\nApple\r\nArrowwood\r\nArborvitae\r\nAsh\r\nAspen\r\nBalsa\r\nBanana\r\nBeech\r\nBirch\r\nBoxwood\r\nBubinga\r\nCasuarina\r\nCamphorwood\r\nCashew\r\nCedar\r\nCherry\r\nChestnut\r\nCocobolo\r\nCottonwood\r\nCypress\r\nDogwood\r\nEbony\r\nElm\r\nEucalyptus\r\nFig\r\nFicus\r\nFir\r\nGuelder\r\nHackberry\r\nHemlock\r\nHickory\r\nIronwood\r\nIpe\r\nJuniper\r\nLancewood\r\nLarch\r\nLauan\r\nLemon\r\nLocust\r\nMagnolia\r\nMahogany\r\nMaple\r\nMerry\r\nMesquite\r\nMimosa\r\nMyrtle\r\nNectarine\r\nOak\r\nOlive\r\nOrange\r\nOsage\r\nOsier\r\nPadauk\r\nPalm\r\nPeach\r\nPear\r\nPecan\r\nPersimmon\r\nPine\r\nPlum\r\nPoplar\r\nPurpleheart\r\nQuince\r\nRedbud\r\nRedwood\r\nRosewood\r\nRowan\r\nRubber\r\nSassafras\r\nSequoia\r\nSnowball\r\nSpruce\r\nSumac\r\nSweetgum\r\nSycamore\r\nTamarisk\r\nThuya\r\nThuja\r\nTea\r\nTeak\r\nTulipwood\r\nUpas\r\nWalnut\r\nWattle\r\nWenge\r\nWillow\r\nYew");
                    }

                    Directory.CreateDirectory(Path.Combine(jbappdata, "obs"));
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "info.txt")))
                    {
                        file.Write("Badges: 0\r\nDeaths: 0");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "lastgenerated.txt")))
                    {
                        file.Write("");
                    }

                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "pokes.js"), false))
                    {
                        file.WriteLine("pokelist = {");
                        file.WriteLine("\"poke1\" : false,");
                        file.WriteLine("\"poke2\" : false,");
                        file.WriteLine("\"poke3\" : false,");
                        file.WriteLine("\"poke4\" : false,");
                        file.WriteLine("\"poke5\" : false,");
                        file.WriteLine("\"poke6\" : false");
                        file.WriteLine("};");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "index.html"), false))
                    {
                        file.WriteLine("<title>Pokemon Layout Test</title><link href=style.css rel=stylesheet><table><tr><td class=poke><img id=slot1><span id=name1></span><td class=poke><img id=slot2><span id=name2></span><td class=poke><img id=slot3><span id=name3></span><td class=poke><img id=slot4><span id=name4></span><td class=poke><img id=slot5><span id=name5></span><td class=poke><img id=slot6><span id=name6></span></table><script src=functions.js></script><script>updatePokes(),updatetimer=setInterval(updatePokes,5e3)</script>");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "style.css"), false))
                    {
                        file.WriteLine("table{max-width:1280px;white-space:nowrap}table td.poke{width:204px;height:204px;overflow:hidden;display:inline-block;white-space:nowrap;padding:10px;position:relative}table td.name{padding:0;margin:0;width:224px;overflow:hidden;display:inline-block;white-space:nowrap;text-align:center}span{text-align:center;position:absolute;bottom:8px;left:50%;transform:translate(-50%,-50%);font-size:1.5em;font-weight:700;font-family:sans-serif;-webkit-text-fill-color:white;-webkit-text-stroke-width:1.25px;-webkit-text-stroke-color:black}img{max-width:204px;max-height:204px}");
                    }
                    using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "functions.js"), false))
                    {
                        file.WriteLine("function updatePokes(){var pokejs=document.createElement(\"script\");pokejs.type=\"application/javascript\";pokejs.src=\"pokes.js\";document.body.appendChild(pokejs);pokejs.onload=function(){getPokes(pokelist.poke1,1);getPokes(pokelist.poke2,2);getPokes(pokelist.poke3,3);getPokes(pokelist.poke4,4);getPokes(pokelist.poke5,5);getPokes(pokelist.poke6,6);document.body.removeChild(pokejs)}}");
                        file.WriteLine("function getPokes(indata,slotno){var imgslot=document.getElementById(\"slot\"+slotno);var nameslot=document.getElementById(\"name\"+slotno);if(!indata){nameslot.innerHTML=\"\";imgslot.src=\"\"}else{nameslot.innerHTML=indata[0];imgslot.src=\"images/\"+indata[1]+\".png\"}}");
                    }
                }

                using (StreamReader file = new StreamReader(Path.Combine(jbappdata, "names", "namingschemes.txt")))
                {
                    String line;
                    while ((line = file.ReadLine()) != null)
                    {
                        cmbNamingScheme.Items.Add(line);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
                this.Close();
            }
        }

        private void btnRemovePokemon_Click(object sender, EventArgs e)
        {
            if (radSlot1.Checked)
            {
                lblSlot1.Text = "Empty";
            }
            if (radSlot2.Checked)
            {
                lblSlot2.Text = "Empty";
            }
            if (radSlot3.Checked)
            {
                lblSlot3.Text = "Empty";
            }
            if (radSlot4.Checked)
            {
                lblSlot4.Text = "Empty";
            }
            if (radSlot5.Checked)
            {
                lblSlot5.Text = "Empty";
            }
            if (radSlot6.Checked)
            {
                lblSlot6.Text = "Empty";
            }

            //There's probably a better way to do this but ¯\_(ツ)_/¯
            String slot1json;
            String slot2json;
            String slot3json;
            String slot4json;
            String slot5json;
            String slot6json;
            if (lblSlot1.Text == "Empty")
            {
                slot1json = "false";
            }
            else
            {
                slot1json = "[\"" + lblSlot1.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot1.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
            }
            if (lblSlot2.Text == "Empty")
            {
                slot2json = "false";
            }
            else
            {
                slot2json = "[\"" + lblSlot2.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot2.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
            }
            if (lblSlot3.Text == "Empty")
            {
                slot3json = "false";
            }
            else
            {
                slot3json = "[\"" + lblSlot3.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot3.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
            }
            if (lblSlot4.Text == "Empty")
            {
                slot4json = "false";
            }
            else
            {
                slot4json = "[\"" + lblSlot4.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot4.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
            }
            if (lblSlot5.Text == "Empty")
            {
                slot5json = "false";
            }
            else
            {
                slot5json = "[\"" + lblSlot5.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot5.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
            }
            if (lblSlot6.Text == "Empty")
            {
                slot6json = "false";
            }
            else
            {
                slot6json = "[\"" + lblSlot6.Text.Split(new String[] { " the " }, StringSplitOptions.None)[0] + "\", \"" + lblSlot6.Text.Split(new String[] { " the " }, StringSplitOptions.None)[1] + "\"]";
            }

            try
            {
                using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "pokes.js"), false))
                {
                    file.WriteLine("pokelist = {");
                    file.WriteLine("\"poke1\" : " + slot1json + ",");
                    file.WriteLine("\"poke2\" : " + slot2json + ",");
                    file.WriteLine("\"poke3\" : " + slot3json + ",");
                    file.WriteLine("\"poke4\" : " + slot4json + ",");
                    file.WriteLine("\"poke5\" : " + slot5json + ",");
                    file.WriteLine("\"poke6\" : " + slot6json);
                    file.WriteLine("};");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
                return;
            }
        }

        private void btnGenerateMale_Click(object sender, EventArgs e)
        {
            List<String> namelist = new List<string>();
            try
            {
                if (String.IsNullOrWhiteSpace(cmbNamingScheme.GetItemText(cmbNamingScheme.SelectedItem)))
                {
                    throw new Exception("No naming scheme has been selected.");
                }

                String namingscheme = cmbNamingScheme.GetItemText(cmbNamingScheme.SelectedItem);

                using (StreamReader file = new StreamReader(Path.Combine(jbappdata, "names", "Male", namingscheme + ".txt")))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        namelist.Add(line);
                    }
                }

                Random rnd = new Random();
                lblNameGen.Text = namelist[rnd.Next(namelist.Count)];

                using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "lastgenerated.txt"), false))
                {
                    file.Write(lblNameGen.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
                return;
            }
        }

        private void btnGenerateFemale_Click(object sender, EventArgs e)
        {
            List<String> namelist = new List<string>();
            try
            {
                if (String.IsNullOrWhiteSpace(cmbNamingScheme.GetItemText(cmbNamingScheme.SelectedItem)))
                {
                    throw new Exception("No naming scheme has been selected.");
                }

                String namingscheme = cmbNamingScheme.GetItemText(cmbNamingScheme.SelectedItem);

                using (StreamReader file = new StreamReader(Path.Combine(jbappdata, "names", "Female", namingscheme + ".txt")))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        namelist.Add(line);
                    }
                }

                Random rnd = new Random();
                lblNameGen.Text = namelist[rnd.Next(namelist.Count)];

                using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "lastgenerated.txt"), false))
                {
                    file.Write(lblNameGen.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
                return;
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(Path.Combine(jbappdata, "obs", "info.txt"), false))
                {
                    file.Write("Badges: " + txtBadges.Text + "\r\nDeaths: " + txtDeaths.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverconnect)
            {

            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
        }
    }
}
