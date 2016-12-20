using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebGrease;

namespace DDAC_Website.Classes
{
    public class RetryHelper
    {
        public static List<Exception> exceptions = new List<Exception>();


        public static void RetryOnException(int times,TimeSpan delay, Action operation)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    operation();
                    break; // Success !
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                        throw new AggregateException(exceptions);
                    exceptions.Add(ex);

                    Task.Delay(delay).Wait();
                }
            } while (true);
        }
    }
}