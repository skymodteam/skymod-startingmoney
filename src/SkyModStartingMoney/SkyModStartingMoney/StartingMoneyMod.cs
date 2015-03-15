namespace SkyModStartingMoney
{
    using ICities;
    using System;
    using System.Threading;
    using UnityEngine;

    public class StartingMoneyMod : IUserMod
    {
        public string Description
        {
            get { return "Gives you $500,000 starting cash on new cities."; }
        }

        public string Name
        {
            get { return "SkyMod Start Money"; }
        }
    }

    public class StartingMoneyLoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode == LoadMode.NewGame)
            {
                try
                {
                    var type = typeof(EconomyManager);
                    var cashAmountField = type.GetField("m_cashAmount", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                    cashAmountField.SetValue(EconomyManager.instance, 50000000);
                }
                catch (Exception ex)
                {
                    // Gulp
                }
            }

            base.OnLevelLoaded(mode);
        }
    }
}
