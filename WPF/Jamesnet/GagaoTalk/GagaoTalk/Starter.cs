using GagaoTalk.Settings;

namespace GagaoTalk
{
    class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddInversionModule<DirectModules>()
                .AddInversionModule<ViewModules>()
                .Run();
        }
    }
}
