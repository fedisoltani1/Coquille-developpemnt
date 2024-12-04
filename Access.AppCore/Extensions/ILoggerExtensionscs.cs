using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace Access.AppCore.Extensions
{
    public static class ILoggerExtensions
    {
        public static ILogger AfficherInfoMethode(
            this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            logger.LogDebug("*** {FileName}  {MemberName}  {SourceLineNumber} ***", Path.GetFileName(sourceFilePath), memberName, sourceLineNumber);
            return logger;
        }

        public static ILogger LogProprietesPublic(this ILogger logger, object paramClass)
        {
            if (paramClass != null)
            {
                if (paramClass is IList && paramClass.GetType().IsGenericType && paramClass.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
                {
                    foreach (var item in (IList)paramClass)
                    {
                        logger.LogDebug("Afficher les informations pour la liste générique {ParamClass} avec {ElementCount} éléments", paramClass, ((IList)paramClass).Count);
                        LogClassInformation(logger, item);
                    }
                }
                else
                {
                    LogClassInformation(logger, paramClass);
                }
            }

            return logger;
        }

        private static void LogClassInformation(ILogger logger, object paramClass)
        {
            if (paramClass != null)
            {
                logger.LogDebug("Afficher les informations pour la classe {ParamClass}", paramClass);
                List<Type> acceptedTypes = new List<Type>() { typeof(string), typeof(int), typeof(DateTime), typeof(DateTime?), typeof(int?), typeof(bool?), typeof(bool) };

                var properties =
                  from prop
                  in paramClass.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                  orderby prop.Name
                  where acceptedTypes.Contains(prop.PropertyType) &&
                        prop.CanWrite &&
                        prop.CanRead
                  select prop;

                properties.ToList().ForEach(p => logger.LogDebug("{PropertyName} = {PropertyValue}", p.Name, p.GetValue(paramClass)));
            }
        }
    }
}
