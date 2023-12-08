namespace OrdenarImagem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    /*public class VetorEventArgs // EventArgs
    {
        public int indice;
        public int valor;
        public Color cor;

        public override string ToString()
        {
            return indice.ToString() + " - " + valor.ToString();
        }
    }*/
}