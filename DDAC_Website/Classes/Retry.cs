using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using DDAC_Website.Models;

namespace DDAC_Website.Classes
{
    public static class Retry
    {
           public static void Do(
       Action action,
       TimeSpan retryInterval,
       int retryCount = 3)
   {
       Do<object>(() => 
       {
           action();
           return null;
       }, retryInterval, retryCount);
   }

   public static T Do<T>(
       Func<T> action, 
       TimeSpan retryInterval,
       int retryCount = 3)
   {
       var exceptions = new List<Exception>();

       for (int retry = 0; retry < retryCount; retry++)
       {
          try
          { 
              if (retry > 0)
                  Thread.Sleep(retryInterval);
              return action();
          }
          catch (Exception ex)
          { 
              exceptions.Add(ex);
          }
       }

       throw new AggregateException(exceptions);
   }

        internal static Cruise Do(object v, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }
    }

   

}