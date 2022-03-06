﻿namespace PopStudio.MAUI
{
    internal static partial class Permission
    {
        public static Language GetDefaultLanguage()
        {
            return Thread.CurrentThread.CurrentCulture.Name switch
            {
                "zh-CN" => Language.ZHCN,
                _ => Language.ENUS
            };
        }

        public static partial string GetSettingPath();

        public static partial Task<bool> CheckAndRequestPermissionAsync(this ContentPage page);
    }
}
