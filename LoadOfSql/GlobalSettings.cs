using System;
using System.Reflection;
using System.Linq;
using System.Drawing.Printing;
using System.IO;
using Microsoft.Win32;
using DomainModel.Entities;

namespace LoadOfSql
{
    static class GlobalSettings
    {
        public static string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["JournalDB"].ConnectionString;
        public static Employee LoginUser { get; set; }
        public static string ScanDirectory { get; internal set; }
        public static string LastUserDirectory { get; internal set; }

        public static string[] printers;
        public static readonly string PrintTemplatePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Шаблон формы выдачи информации.docx";
        public static int SelectPrinter;

        static RegistryKey key = Registry.CurrentUser;
        static RegistryKey regKeyJournal;

        static object GetDefaultKeyValue(string keyName, object defaulValue)
        {
            regKeyJournal.SetValue(keyName, defaulValue);
            return regKeyJournal.GetValue(keyName);
        }
        public static void ReadRegistryKeys()
        {
            regKeyJournal = key.CreateSubKey(@"Software\Журнал выданной информации");

            SelectPrinter = regKeyJournal.GetValue("SelectPrinter") == null ? Convert.ToInt32(GetDefaultKeyValue("SelectPrinter", 0)) : Convert.ToInt32(regKeyJournal.GetValue("SelectPrinter"));
            ScanDirectory = regKeyJournal.GetValue("ScanDirectory")?.ToString() ?? GetDefaultKeyValue("ScanDirectory", @"\\FS-05\UaigApps\Журнал УАиГ\scan").ToString();
            LastUserDirectory = regKeyJournal.GetValue("LastScanDirectory")?.ToString() ?? GetDefaultKeyValue("LastScanDirectory", "").ToString();
            regKeyJournal.Close();
        }
        public static void SaveRegistryKeys()
        {
            regKeyJournal = key.CreateSubKey(@"Software\Журнал выданной информации");

            regKeyJournal.SetValue("SelectPrinter", SelectPrinter);
            regKeyJournal.Close();
        }

        public static void SetLastUserDirectoryRegKey(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            regKeyJournal = key.CreateSubKey(@"Software\Журнал выданной информации");

            regKeyJournal.SetValue("LastScanDirectory", value);
            regKeyJournal.Close();
        }
       
        public static void SetLoginPassRegistryKeys(string login, string pass)
        {
            regKeyJournal = key.CreateSubKey(@"Software\Журнал выданной информации");
            regKeyJournal.SetValue("Login", login);
            regKeyJournal.SetValue("Password", pass);
        }
        public static void SetReadOnlyProp(string path)  //Устанавливаем файлу Атрибут Read Only
        {
            FileAttributes attributes = File.GetAttributes(path);
            if ((attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
            {
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);
            }
        }
        public static void Printers()  //Создает массив принтеров, подключенных к компьютеру
        {
            PrinterSettings.StringCollection sc = PrinterSettings.InstalledPrinters;
            printers = new string[sc.Count];
            for (int i = 0; i < sc.Count; i++)
            {
                printers[i] = sc[i].ToString();
            }
        }
    }
}
