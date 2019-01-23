using System;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.Toolkit.Effects.Droid
{
    [Preserve(AllMembers = true)]
    public static class Effects
    {
#pragma warning disable 414
        static List<PlatformEffect> allEffects = new List<PlatformEffect>();
#pragma warning restore 414

        public static void Init()
        {
            allEffects = new List<PlatformEffect>(typeof(Effects).Assembly.GetTypes().Where(t => typeof(PlatformEffect).IsAssignableFrom(t)).Select(t => (PlatformEffect)Activator.CreateInstance(t)));
        }
    }
}
