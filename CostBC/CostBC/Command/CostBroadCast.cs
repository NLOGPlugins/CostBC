using System;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;

namespace CostBC.Command
{
    public class CostBroadCast : CostBC
    {
        [Command(Name = "costbroadcast")]
        public void Execute(Player sender, params string[] text)
        {
            var hg = Heconomy.GetMoney(sender.Username);
            if (hg < cost)
            {
                sender.SendMessage($"{ChatColors.Red}[CostBC] 자금이 부족합니다! ( 현재 자금: {hg}{Heconomy.Symbol} )");
            }
            else
            {
                Heconomy.SetMoney(sender.Username, hg - cost);
                string msg = string.Empty;
                for (int i = 0; i < text.Length; i++)
                {
                    msg += text[i];
                }
                SerBroadCast($"{sender.Username} : {ChatColors.Green}[BroadCast] {msg}");
                sender.SendMessage($"{ChatColors.LightPurple}[CostBC] {cost}{Heconomy.Symbol} 을 지불하였습니다. ( 현재 자금: {hg}{Heconomy.Symbol} )");
                Console.WriteLine($"{sender.Username} : [BroadCast] {msg}");
            }
        }
        #region short command
        [Command(Name = "cbc")]
        public void Execute2(Player sender, params string[] text)
        {
            Execute(sender, text);
        }
        #endregion
    }
}
