using Application.Configuration.Extentions;
using Application.Configuration.Helpers;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace Application.Configuration.ExtentionsExtractor
{
    public class ApplicationConfigExtractor
    {
        //Get the value by key
        static string GetValueByKey(XDocument doc, string key)
        {
            XElement element = doc.Root.Elements("add").FirstOrDefault(e => e.Attribute("key")?.Value == key);
            return element?.Attribute("value")?.Value;
        }

        //Get database context information
        public static ContextInfos GetDatabaseContext()
        {
            XDocument doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationConfig/" + Constantes.DatabaseConfigFile));
            return new ContextInfos { Database = GetValueByKey(doc, "Database"), PasswordSql = GetValueByKey(doc, "PasswordSql"), Server = GetValueByKey(doc, "Server"), UserSql = GetValueByKey(doc, "UserSql") };
        }

        //Url de l'application API
        public static string GetApiUrl()
        {
            XDocument doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationConfig/" + Constantes.ApplicationConfigFile));
            return GetValueByKey(doc, "ApiUrl");
        }

        //Path des backup
        public static string GetDatabaseBackupPath()
        {
            XDocument doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationConfig/" + Constantes.ApplicationConfigFile));
            return GetValueByKey(doc, "DataBaseBackups");
        }

        //Aes security key
        public static string GetAesKey()
        {
            XDocument doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationConfig/" + Constantes.ApplicationConfigFile));
            return GetValueByKey(doc, "SecurityAesKey");
        }

        //Smtp server
        //public static MailingInfos GetSmtpServer()
        //{
        //    XDocument doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationConfig/" + Constants.SmtpServerConfigFile));
        //    string AdresseMail = GetValueByKey(doc, "AdresseMail");
        //    string Name = GetValueByKey(doc, "Name");
        //    string SmtpServer = GetValueByKey(doc, "SmtpServer");
        //    string SmtpPort = GetValueByKey(doc, "SmtpPort");
        //    string Username = GetValueByKey(doc, "Username");
        //    string Password = GetValueByKey(doc, "Password");
        //    return new MailingInfos { SmtpPort = Convert.ToInt32(SmtpPort), AdresseMail = AdresseMail, Name = Name, SmtpServer = SmtpServer, Username = Username, Password = Password };
        //}

        //Licence
        //public static LicenceInfos GetLicence()
        //{
        //    XDocument doc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ApplicationConfig/Licence.key"));
        //    string LicenceEncrypted = GetValueByKey(doc, "Licence");
        //    string Email = GetValueByKey(doc, "Email");
        //    var LicenceDecrypted = Encryptor.Decrypt(LicenceEncrypted).Split(new string[] { "--" }, StringSplitOptions.None);
        //    return new LicenceInfos { DateExpiration = Convert.ToDateTime(LicenceDecrypted[0]), Email = Email };
        //}

        //Contrat de maintenance status
        //public static bool isValidContratMaintenance()
        //{
        //    return GetLicence().DateExpiration <= DateTime.Now.Date ? true : false;
        //}
    }
}
