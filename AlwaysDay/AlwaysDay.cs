
using System;

using Terraria;
using TerrariaApi;
using TerrariaApi.Server;

using TShockAPI;

namespace AlwaysDay
{

    [ApiVersion(1, 14)]
    public class AlwaysDay : TerrariaPlugin
    {




        private bool AlwaysDayToggle = false;
        
        
        
        
        
        public override Version Version
        {
            get { return new Version("1.0.0.1"); }
        }

        public override string Name
        {
            get { return "Always Day"; }
        }

        public override string Author
        {
            get { return "BigGreenBudz"; }
        }

        public override string Description
        {
            get { return "Allows for the time to be set to day and stay that way."; }
        }

        public AlwaysDay(Main game)
            : base(game)
        {
            Order = 0;
        }

        #region Initialize
        public override void Initialize()
        {

            ServerApi.Hooks.GameUpdate.Register(this, OnUpdate);

            Commands.ChatCommands.Add(new Command("alwaysdaytoggle", AlDay, "always-day"));
            
        }
#endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.GameUpdate.Deregister(this, OnUpdate);
            }
            base.Dispose(disposing);
        }
#endregion

         #region OnUpdate
         public void OnUpdate(EventArgs args)
                {
                    if (AlwaysDayToggle)
                    {
                        TSPlayer.Server.SetTime(true, 27000.0);
                    }

                }
#endregion

#region AlwaysDayToggle 
        public void AlDay(CommandArgs args)
                     {
            if (args.Player != null)
            {
                AlwaysDayToggle = !AlwaysDayToggle;
                args.Player.SendInfoMessage("Always Day now: " + ((AlwaysDayToggle) ? "Enabled" : "Disabled"));
            }
                     }
#endregion
    }
}