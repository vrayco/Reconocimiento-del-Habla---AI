using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Reconocimiento_de_Voz___AI
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
            sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
            
              // Create a simple grammar that recognizes “red”, “green”, or “blue”.
              Choices colors = new Choices();
              colors.Add("Apagar sistema");
              colors.Add("Bajar volumen");
              colors.Add("Subir volumen");
              colors.Add("Listar home");

            GrammarBuilder gb = new GrammarBuilder();
             gb.Append(colors);

           // Create the actual Grammar instance, and then load it into the speech recognizer.
           Grammar g = new Grammar(gb);
          sre.LoadGrammar(g);

      // Register a handler for the SpeechRecognized event.
      sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
      sre.SetInputToDefaultAudioDevice();
      sre.RecognizeAsync(RecognizeMode.Multiple);
    }

    // Simple handler for the SpeechRecognized event.
    void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      //label1.Text += e.Result.Text;
      string result = ExecuteCommand("dir");
      //MessageBox.Show(result);
      label_out.Text += e.Result.Text+"\n";
    }

    SpeechRecognitionEngine sre;

    private void Form1_Resize(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            Hide();
            notifyIcon1.Visible = true;
        }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        Show();
        this.WindowState = FormWindowState.Normal;
        notifyIcon1.Visible = false;
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        Hide();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    static string ExecuteCommand(string _Command)
    {
        //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
        //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
        //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
        System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);
        // Indicamos que la salida del proceso se redireccione en un Stream
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
        procStartInfo.CreateNoWindow = false;
        //Inicializa el proceso
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
        //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
        string result = proc.StandardOutput.ReadToEnd();
        return result;
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

  }
}
