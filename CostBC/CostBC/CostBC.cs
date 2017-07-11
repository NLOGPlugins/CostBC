using System;
using System.IO;
using System.Reflection;

using MiNET.Plugins;
using MiNET.Plugins.Attributes;

namespace CostBC
{
    [Plugin(Author = "푸른곡괭이(BluePickaxe)", Description = "Cost BroadCast", PluginName = "CostBC", PluginVersion = "1.0")]
    public class CostBC : Plugin
    {
        protected int cost = 300;
        private HeconomyAPI.HeconomyAPI heconomy;
        protected HeconomyAPI.HeconomyAPI Heconomy { get => heconomy; set => heconomy = value; }
        public void SerBroadCast(string msg)
        {
            foreach (var i in Context.LevelManager.Levels)
            {
                i.BroadcastMessage(msg);
            }
        }
        public string GetDataFolder() => Path.Combine(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath, "Essentials");
        public void EIO()
        {
            CTDT(GetDataFolder());
            CTFL(Path.Combine(GetDataFolder(),"settings.json"));
        }
        public void CTDT(string name)
        {
            DirectoryInfo temp = new DirectoryInfo(name);
            if (!temp.Exists)
            {
                temp.Create();
            }
        }
        public void CTFL(string name)
        {
            FileInfo temp = new FileInfo(name);
            if (!temp.Exists)
            {
                FileStream fs = temp.Create();
                fs.Close();
            }
        }
    }
}
