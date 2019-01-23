using Android.OS;

namespace Xamarin.Forms.Toolkit
{
    static class Platform
    {
        internal static bool HasApiLevel(BuildVersionCodes versionCode) =>
            (int)Build.VERSION.SdkInt >= (int)versionCode;
    }
}
